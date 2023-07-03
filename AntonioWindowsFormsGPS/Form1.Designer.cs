namespace AntonioWindowsFormsGPS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textLatitud = new System.Windows.Forms.TextBox();
            this.textLongitud = new System.Windows.Forms.TextBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.label_latitud = new System.Windows.Forms.Label();
            this.label_longitud = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_poligon = new System.Windows.Forms.Button();
            this.button_ruta = new System.Windows.Forms.Button();
            this.button_normal = new System.Windows.Forms.Button();
            this.button_relieve = new System.Windows.Forms.Button();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.label_zoom = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_buscarDireccionWeb = new System.Windows.Forms.Button();
            this.button_buscarCoordenadas = new System.Windows.Forms.Button();
            this.button_buscarDireccion = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 12);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(550, 417);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(575, 34);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(297, 34);
            this.textDescripcion.TabIndex = 1;
            // 
            // textLatitud
            // 
            this.textLatitud.Location = new System.Drawing.Point(575, 97);
            this.textLatitud.Name = "textLatitud";
            this.textLatitud.Size = new System.Drawing.Size(297, 20);
            this.textLatitud.TabIndex = 2;
            // 
            // textLongitud
            // 
            this.textLongitud.Location = new System.Drawing.Point(575, 138);
            this.textLongitud.Name = "textLongitud";
            this.textLongitud.Size = new System.Drawing.Size(297, 20);
            this.textLongitud.TabIndex = 3;
            // 
            // button_agregar
            // 
            this.button_agregar.Location = new System.Drawing.Point(575, 168);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(154, 42);
            this.button_agregar.TabIndex = 4;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(745, 168);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(127, 42);
            this.button_eliminar.TabIndex = 5;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(572, 12);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(63, 13);
            this.label_descripcion.TabIndex = 6;
            this.label_descripcion.Text = "Descripción";
            // 
            // label_latitud
            // 
            this.label_latitud.AutoSize = true;
            this.label_latitud.Location = new System.Drawing.Point(572, 81);
            this.label_latitud.Name = "label_latitud";
            this.label_latitud.Size = new System.Drawing.Size(39, 13);
            this.label_latitud.TabIndex = 7;
            this.label_latitud.Text = "Latitud";
            // 
            // label_longitud
            // 
            this.label_longitud.AutoSize = true;
            this.label_longitud.Location = new System.Drawing.Point(572, 122);
            this.label_longitud.Name = "label_longitud";
            this.label_longitud.Size = new System.Drawing.Size(48, 13);
            this.label_longitud.TabIndex = 8;
            this.label_longitud.Text = "Longitud";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(575, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(397, 203);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SeleccionarRegistro);
            // 
            // button_poligon
            // 
            this.button_poligon.Location = new System.Drawing.Point(890, 97);
            this.button_poligon.Name = "button_poligon";
            this.button_poligon.Size = new System.Drawing.Size(82, 61);
            this.button_poligon.TabIndex = 10;
            this.button_poligon.Text = "Área/    Polígono";
            this.button_poligon.UseVisualStyleBackColor = true;
            this.button_poligon.Click += new System.EventHandler(this.button_poligon_Click);
            // 
            // button_ruta
            // 
            this.button_ruta.Location = new System.Drawing.Point(888, 34);
            this.button_ruta.Name = "button_ruta";
            this.button_ruta.Size = new System.Drawing.Size(84, 57);
            this.button_ruta.TabIndex = 11;
            this.button_ruta.Text = "Ruta";
            this.button_ruta.UseVisualStyleBackColor = true;
            this.button_ruta.Click += new System.EventHandler(this.button_ruta_Click);
            // 
            // button_normal
            // 
            this.button_normal.Location = new System.Drawing.Point(12, 436);
            this.button_normal.Name = "button_normal";
            this.button_normal.Size = new System.Drawing.Size(124, 23);
            this.button_normal.TabIndex = 14;
            this.button_normal.Text = "Normal";
            this.button_normal.UseVisualStyleBackColor = true;
            this.button_normal.Click += new System.EventHandler(this.button_normal_Click);
            // 
            // button_relieve
            // 
            this.button_relieve.Location = new System.Drawing.Point(142, 436);
            this.button_relieve.Name = "button_relieve";
            this.button_relieve.Size = new System.Drawing.Size(122, 23);
            this.button_relieve.TabIndex = 15;
            this.button_relieve.Text = "Relieve";
            this.button_relieve.UseVisualStyleBackColor = true;
            this.button_relieve.Click += new System.EventHandler(this.button_relieve_Click);
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(310, 436);
            this.trackZoom.Maximum = 21;
            this.trackZoom.Minimum = 2;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(252, 45);
            this.trackZoom.TabIndex = 16;
            this.trackZoom.Value = 2;
            this.trackZoom.ValueChanged += new System.EventHandler(this.trackZoom_ValueChanged);
            // 
            // label_zoom
            // 
            this.label_zoom.AutoSize = true;
            this.label_zoom.Location = new System.Drawing.Point(270, 441);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(34, 13);
            this.label_zoom.TabIndex = 17;
            this.label_zoom.Text = "Zoom";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_buscarDireccionWeb
            // 
            this.button_buscarDireccionWeb.Location = new System.Drawing.Point(876, 435);
            this.button_buscarDireccionWeb.Name = "button_buscarDireccionWeb";
            this.button_buscarDireccionWeb.Size = new System.Drawing.Size(96, 34);
            this.button_buscarDireccionWeb.TabIndex = 18;
            this.button_buscarDireccionWeb.Text = "Buscar dirección via Web";
            this.button_buscarDireccionWeb.UseVisualStyleBackColor = true;
            this.button_buscarDireccionWeb.Click += new System.EventHandler(this.button_buscarDireccionViaWeb_Click);
            // 
            // button_buscarCoordenadas
            // 
            this.button_buscarCoordenadas.Location = new System.Drawing.Point(726, 436);
            this.button_buscarCoordenadas.Name = "button_buscarCoordenadas";
            this.button_buscarCoordenadas.Size = new System.Drawing.Size(144, 34);
            this.button_buscarCoordenadas.TabIndex = 19;
            this.button_buscarCoordenadas.Text = "Buscar coordenadas";
            this.button_buscarCoordenadas.UseVisualStyleBackColor = true;
            this.button_buscarCoordenadas.Click += new System.EventHandler(this.button_buscarDireccionCoordenadas_Click);
            // 
            // button_buscarDireccion
            // 
            this.button_buscarDireccion.Location = new System.Drawing.Point(575, 436);
            this.button_buscarDireccion.Name = "button_buscarDireccion";
            this.button_buscarDireccion.Size = new System.Drawing.Size(145, 34);
            this.button_buscarDireccion.TabIndex = 20;
            this.button_buscarDireccion.Text = "Buscar dirección de descripción";
            this.button_buscarDireccion.UseVisualStyleBackColor = true;
            this.button_buscarDireccion.Click += new System.EventHandler(this.button_buscarDireccionApp_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(890, 168);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(82, 42);
            this.button_reset.TabIndex = 21;
            this.button_reset.Text = "RESET Ruta/Área";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 481);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_buscarDireccion);
            this.Controls.Add(this.button_buscarCoordenadas);
            this.Controls.Add(this.button_buscarDireccionWeb);
            this.Controls.Add(this.label_zoom);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.button_relieve);
            this.Controls.Add(this.button_normal);
            this.Controls.Add(this.button_ruta);
            this.Controls.Add(this.button_poligon);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_longitud);
            this.Controls.Add(this.label_latitud);
            this.Controls.Add(this.label_descripcion);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.textLongitud);
            this.Controls.Add(this.textLatitud);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.gMapControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 520);
            this.MinimumSize = new System.Drawing.Size(812, 480);
            this.Name = "Form1";
            this.Text = "GPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.TextBox textLatitud;
        private System.Windows.Forms.TextBox textLongitud;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.Label label_latitud;
        private System.Windows.Forms.Label label_longitud;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_poligon;
        private System.Windows.Forms.Button button_ruta;
        private System.Windows.Forms.Button button_normal;
        private System.Windows.Forms.Button button_relieve;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.Label label_zoom;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_buscarDireccionWeb;
        private System.Windows.Forms.Button button_buscarCoordenadas;
        private System.Windows.Forms.Button button_buscarDireccion;
        private System.Windows.Forms.Button button_reset;
    }
}

