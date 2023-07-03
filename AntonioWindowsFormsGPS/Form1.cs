using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using Geocoding;
using Geocoding.Google;
using System.Net;
using System.IO;

namespace AntonioWindowsFormsGPS
{
    public partial class Form1 : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        GMapOverlay Ruta = null;
        GMapOverlay Poligono = null;

        int i = 1;

        //Ruta automatizada (como llegar)
        bool trazarRuta = false;
        int ContadorIndicadoresRuta = 0;
        PointLatLng inicio;
        PointLatLng final;

        //Punto inicial
        int filaSeleccionada = 0;
        double LatInicial = 41.40232;
        double LngInicial = 2.20862;

        //Obtener direccion
        private const string GoogleMapsGeocodingApiUrl = "https://maps.googleapis.com/maps/api/geocode/json";

        public Form1()
        {
            InitializeComponent();
        }

        //Creación elementos principales de inicio en la aplicación
        private void Form1_Load(object sender, EventArgs e)
        {
            //creamos y añadimos datos al dataTable
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripción",typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            //Insertando datos al dt para mostrar en la list
            dt.Rows.Add("Oficina central", LatInicial, LngInicial);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //desactivar las columnas de lat y long para que no salgan en datagrid
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            //deshabilitamos botones de inicio
            button_ruta.Enabled = false;
            button_poligon.Enabled = false;
            button_reset.Enabled = false;

            //Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);//Agregamos al mapa el marker

            //agregamos un tooltip de texto a los marcadores (Bocadillo de texto)
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", LatInicial, LngInicial);

            //Ahora agregamos el mapa y el marcador al map control añadiendo el markeroverlay que contiene el marker
            gMapControl1.Overlays.Add(markerOverlay);
        }

        //Método de click que es llamado al hacer click en el dataGrid
        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                filaSeleccionada = e.RowIndex; //Número de fila seleccionada
                                               //Recuperamos los datos del grid y los asignamos a los textbox
                textDescripcion.Text = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
                textLatitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
                textLongitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
                //se asignan los valores del grid al marcado
                marker.Position = new PointLatLng(Convert.ToDouble(textLatitud.Text), Convert.ToDouble(textLongitud.Text));
                //se posiciona el foco del mapa en ese punto
                gMapControl1.Position = marker.Position;
            }catch(Exception ex)
            {
               Console.WriteLine("Has creado una excepcion al clickar en la cabezera de la tabla: "+ex.Message);
            }
        }

        //Método de click llamado al hacer doble click sobre el mapa
        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //se obtiene los datos de lat y long del mapa donde clickemos
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng= gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            //se posiciona en el txt de la latitud y longitud
            textDescripcion.Text = "";
            textLatitud.Text = lat.ToString();
            textLongitud.Text = lng.ToString();

            //Creamos el marcador para moverlo al lugar índicado
            marker.Position = new PointLatLng(lat, lng);
            //También se agrega el mensaje al marcador (tooltip)
            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} Longitud: {1}", lat, lng);

            CrearDireccionTrazarRuta(lat, lng);//Activamos funcionalidad rutas
        }

        public void CrearDireccionTrazarRuta(double lat, double lng)
        {
            if (trazarRuta)
            {
                switch (ContadorIndicadoresRuta)
                {
                    case 0://primer marcador o inicio
                        ContadorIndicadoresRuta++;
                        inicio = new PointLatLng(lat, lng);
                        break;

                    case 1: //Segundo marcador o final
                        ContadorIndicadoresRuta++;
                        final = new PointLatLng(lat, lng);
                        GDirections direccion;

                        var RutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, inicio, final, false, false, false, false, false);
                        GMapRoute RutaObtenida = new GMapRoute(direccion.Route, "Ruta ubicación");
                        GMapOverlay CapaRutas = new GMapOverlay("Capa de la ruta");
                        CapaRutas.Routes.Add(RutaObtenida);
                        gMapControl1.Overlays.Add(CapaRutas);
                        //actualizar el mapa
                        gMapControl1.Zoom = gMapControl1.Zoom + 1;
                        gMapControl1.Zoom = gMapControl1.Zoom - 1;

                        ContadorIndicadoresRuta = 0;
                        trazarRuta = false;

                        break;
                }
            }
        }

        #region "Boton Agregar y Eliminar"
        private void button_agregar_Click(object sender, EventArgs e)
        {
            //agregar a la tabla si tenemos los campos latitud y longitud no vacios
            if (textLatitud.Text != "" && textLongitud.Text != "")
            {
                if (textDescripcion.Text == "")
                {
                    textDescripcion.Text = "Ubicación sin nombre: " + i;
                    i++;
                }
                dt.Rows.Add(textDescripcion.Text, textLatitud.Text, textLongitud.Text);
                button_eliminar.Enabled = true;
                //Comprobamos que tenemos al menos dos elementos para trazar la linea de ruta
                if (dataGridView1.Rows.Count >= 2)
                {
                    button_ruta.Enabled = true;
                    if (dataGridView1.Rows.Count >= 3)//Si tiene 3 o mas elementos activamos tambien el boton de area o poligono
                    {
                        button_poligon.Enabled = true;
                    }
                }
            }
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)//Solo ejecutara la accion de borrar cuando tengamos alguna fila disponible para borrar
                {
                    dataGridView1.Rows.RemoveAt(filaSeleccionada); //remover de la tabla
                    if (dataGridView1.RowCount < 3)
                    {
                        button_poligon.Enabled = false;
                        if (dataGridView1.RowCount < 2)
                        {
                            button_ruta.Enabled = false;

                            if (dataGridView1.RowCount == 0)//Si despues de borrar nos hemos quedado sin filas
                            {
                                button_eliminar.Enabled = false;//deshabilitamos el boton de eliminar
                                i = 1;//Reseteamos el contador de ubicaciones sin nombre
                            }
                        }
                    }
                }
                else//Cuando no haya ningun elemento a eliminar desabilitaremos el boton de eliminar
                {
                    button_eliminar.Enabled = false;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Excepcion ocurrida en button_eliminar_Click: " + ex.Message);
            }
        }
        #endregion

        #region "Botones Ruta y Area/Poligono"
        private void button_poligon_Click(object sender, EventArgs e)
        {
            //GMapOverlay Poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            //variables para almacenar los datos.
            double lng, lat;
            //Agregamos los datos del gridview
            for (int filas = 0; filas < (dataGridView1.Rows.Count); filas++)             
            {                                                                   
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Polígono");
            if (Poligono!= null)//Si ya teniamos un poligono dibujado borramos el anterior
            {
                gMapControl1.Overlays.Remove(Poligono);
            }
            Poligono = new GMapOverlay("Poligono");
            Poligono.Polygons.Add(poligonoPuntos);
            gMapControl1.Overlays.Add(Poligono);
            
            //actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

            button_reset.Enabled = true;
        }

        private void button_ruta_Click(object sender, EventArgs e)
        {
            if (Ruta == null)
            {
                Ruta = new GMapOverlay("Ruta");
            }else if (Ruta.Routes.Count > 0 && Ruta.Routes[0] !=null)
            {
                Ruta.Routes.RemoveAt(0);
            }
            List<PointLatLng> puntos = new List<PointLatLng>();
            //variables para almacenar los datos.
            double lng, lat;
            //Comprobamos que tenemos al menos dos elementos para trazar la linea de ruta
         
            //Agregamos los datos del gridview
            for (int filas = 0; filas < (dataGridView1.Rows.Count); filas++)
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }
            GMapRoute puntosRuta = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(puntosRuta);
            gMapControl1.Overlays.Add(Ruta);
            //actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

            button_reset.Enabled = true;
        }


        //Método que resetea el mapa borrando las rutas o areas marcadas
        private void button_reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ruta.Routes.Count > 0 && Ruta.Routes[0] != null)
                {
                    Ruta.Routes.RemoveAt(0);
                }
                if (Poligono != null)//Si ya teniamos un poligono dibujado borramos el anterior
                {
                    gMapControl1.Overlays.Remove(Poligono);

                    //actualizar el mapa
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    button_reset.Enabled = false;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Ha ocurrido una excepcion en el metodo del boton reset: " + ex.Message);
            }
        }
        #endregion

        #region "Vistas del gps"
        private void button_normal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void button_relieve_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
        }
        #endregion

        #region "Trackzoom y timer asociado"
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                trackZoom.Value = Convert.ToInt32(gMapControl1.Zoom);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ha habido un error relacionado con el zoom: "+ex.Message);
            }
        }

        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                gMapControl1.Zoom = trackZoom.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido una excepcion en el método trackZoom_ValueChanged: "+ex.Message);
            }
        }
        #endregion

        #region "Busquedas por coordenadas o dirección"
        //Boton buscar direccion via web
        private void button_buscarDireccionViaWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com.ar/maps/search/" + textDescripcion.Text.Replace(" ", "%20"));
        }

        //Boton de buscar por coordenadas
        private async void button_buscarDireccionCoordenadas_Click(object sender, EventArgs e)
        {

            if (textLatitud.Text != "" && textLongitud.Text != "")
            {
                double Latitud;  
                double Longitud;

                //Cojemos datos de la latitud y longitud de los textbox y colocamos mapa en esa posición
                if (Double.TryParse(textLatitud.Text, out Latitud))
                {
                    Latitud = Double.Parse(textLatitud.Text);
                    Longitud = Double.Parse(textLongitud.Text);
                    // La conversión se realizó correctamente, y el valor de Latitud contiene el resultado.
                    gMapControl1.Position = new PointLatLng(Latitud, Longitud);
                    //Escribiremos la direccion  en descripcion a partir de las coordenadas escritas
                    string direccion = await ObtenerDireccionDesdeCoordenadas(Latitud, Longitud);
                    if (!string.IsNullOrEmpty(direccion))
                    {
                        textDescripcion.Text = direccion;
                    }
                }
                else
                {
                    // La conversión falló, el valor de textLatitud.Text no es un formato válido de double.
                    MessageBox.Show("Introduce las coordenadas en formato correcto!");
                }
            }else
            {
                MessageBox.Show("Introduce las dos coordenadas!");
            }              
        }

        //Método que devuelve direccion a traves de coordenadas pasadas
        private async Task<string> ObtenerDireccionDesdeCoordenadas(double latitud, double longitud)
        {
            string apiKey = "AIzaSyACtTstNWahfF3YipXHOl0tT40TwPvWL9E"; //clave de API de Geocodificación de Google

            string url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitud},{longitud}&key={apiKey}";

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Analizar la respuesta JSON
                    JObject json = JObject.Parse(jsonResponse);

                    // Verificar si la solicitud tuvo éxito
                    string status = json["status"].ToString();
                    if (status == "OK")
                    {
                        // Obtener la primera dirección del resultado
                        JArray results = (JArray)json["results"];
                        if (results.Count > 0)
                        {
                            string direccion = results[1]["formatted_address"].ToString();
                            return direccion;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el método ObtenerDireccionDesdeCoordenadas: " + ex.Message);
            }

            return string.Empty;
        }

        //Boton de buscar por direccion
        private void button_buscarDireccionApp_Click(object sender, EventArgs e)
        {
            string direccion = textDescripcion.Text;
            string apiKey = "AIzaSyACtTstNWahfF3YipXHOl0tT40TwPvWL9E";

            if (direccion != "")
            {
                GoogleGeocoder geocoder = new GoogleGeocoder() { ApiKey = apiKey };
                IEnumerable<Address> resultados = geocoder.Geocode(direccion);

                if (resultados.Any())
                {
                    Address primerResultado = resultados.First();
                    double latitud = primerResultado.Coordinates.Latitude;
                    double longitud = primerResultado.Coordinates.Longitude;

                    //Metemos las coordenadas tipo doble en los textbox correspondientes
                    textLatitud.Text = latitud.ToString();
                    textLongitud.Text = longitud.ToString();

                    //Hacer lo que quiera con las coordenadas obtenidas
                    if (Double.TryParse(textLatitud.Text, out latitud))
                    {
                        latitud = Double.Parse(textLatitud.Text);
                        longitud = Double.Parse(textLongitud.Text);
                        // La conversión se realizó correctamente, y el valor de Latitud contiene el resultado.
                        gMapControl1.Position = new PointLatLng(latitud, longitud);
                    }
                    else
                    {
                        // La conversión falló, el valor de textLatitud.Text no es un formato válido de double.
                        MessageBox.Show("Introduce las coordenadas en formato correcto!");
                    }
                }
                else
                {
                    // No se encontraron coordenadas para la dirección proporcionada
                    MessageBox.Show("No se encontraron coordenadas para la dirección");
                }
            }
            else
            {
                MessageBox.Show("Introduce una dirección");
            }
        }

        #endregion

    }
}
