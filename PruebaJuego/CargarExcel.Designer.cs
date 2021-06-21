namespace PruebaJuego
{
    partial class CargarExcel
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
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_analizar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_examinar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ofd_archivos = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_distrito = new System.Windows.Forms.ComboBox();
            this.cb_tablero = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_jugador = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ronda = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_estadoI = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_posicion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_estadoF = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_datos
            // 
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Location = new System.Drawing.Point(12, 149);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.Size = new System.Drawing.Size(876, 340);
            this.dgv_datos.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bt_cancelar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_analizar, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 495);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 28);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bt_analizar
            // 
            this.bt_analizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_analizar.Location = new System.Drawing.Point(132, 3);
            this.bt_analizar.Name = "bt_analizar";
            this.bt_analizar.Size = new System.Drawing.Size(173, 22);
            this.bt_analizar.TabIndex = 0;
            this.bt_analizar.Text = "Analizar";
            this.bt_analizar.UseVisualStyleBackColor = true;
            this.bt_analizar.Click += new System.EventHandler(this.bt_analizar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_cancelar.Location = new System.Drawing.Point(560, 3);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(193, 22);
            this.bt_cancelar.TabIndex = 1;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            // 
            // bt_examinar
            // 
            this.bt_examinar.Location = new System.Drawing.Point(12, 12);
            this.bt_examinar.Name = "bt_examinar";
            this.bt_examinar.Size = new System.Drawing.Size(75, 23);
            this.bt_examinar.TabIndex = 2;
            this.bt_examinar.Text = "Examinar";
            this.bt_examinar.UseVisualStyleBackColor = true;
            this.bt_examinar.Click += new System.EventHandler(this.bt_examinar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(93, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(795, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Columna Distrito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Columna Tablero";
            // 
            // cb_distrito
            // 
            this.cb_distrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_distrito.FormattingEnabled = true;
            this.cb_distrito.Location = new System.Drawing.Point(105, 48);
            this.cb_distrito.Name = "cb_distrito";
            this.cb_distrito.Size = new System.Drawing.Size(134, 21);
            this.cb_distrito.TabIndex = 6;
            // 
            // cb_tablero
            // 
            this.cb_tablero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tablero.FormattingEnabled = true;
            this.cb_tablero.Location = new System.Drawing.Point(105, 83);
            this.cb_tablero.Name = "cb_tablero";
            this.cb_tablero.Size = new System.Drawing.Size(134, 21);
            this.cb_tablero.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Columna Jugador";
            // 
            // cb_jugador
            // 
            this.cb_jugador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_jugador.FormattingEnabled = true;
            this.cb_jugador.Location = new System.Drawing.Point(105, 119);
            this.cb_jugador.Name = "cb_jugador";
            this.cb_jugador.Size = new System.Drawing.Size(134, 21);
            this.cb_jugador.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Columna Ronda";
            // 
            // cb_ronda
            // 
            this.cb_ronda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ronda.FormattingEnabled = true;
            this.cb_ronda.Location = new System.Drawing.Point(389, 48);
            this.cb_ronda.Name = "cb_ronda";
            this.cb_ronda.Size = new System.Drawing.Size(134, 21);
            this.cb_ronda.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Columna Estado Inicial";
            // 
            // cb_estadoI
            // 
            this.cb_estadoI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estadoI.FormattingEnabled = true;
            this.cb_estadoI.Location = new System.Drawing.Point(389, 83);
            this.cb_estadoI.Name = "cb_estadoI";
            this.cb_estadoI.Size = new System.Drawing.Size(134, 21);
            this.cb_estadoI.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Columna Estado Final";
            // 
            // cb_posicion
            // 
            this.cb_posicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_posicion.FormattingEnabled = true;
            this.cb_posicion.Location = new System.Drawing.Point(652, 48);
            this.cb_posicion.Name = "cb_posicion";
            this.cb_posicion.Size = new System.Drawing.Size(134, 21);
            this.cb_posicion.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Columna Posicion";
            // 
            // cb_estadoF
            // 
            this.cb_estadoF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estadoF.FormattingEnabled = true;
            this.cb_estadoF.Location = new System.Drawing.Point(389, 119);
            this.cb_estadoF.Name = "cb_estadoF";
            this.cb_estadoF.Size = new System.Drawing.Size(134, 21);
            this.cb_estadoF.TabIndex = 17;
            // 
            // CargarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.cb_estadoF);
            this.Controls.Add(this.cb_posicion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_estadoI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_ronda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_jugador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_tablero);
            this.Controls.Add(this.cb_distrito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_examinar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_datos);
            this.Name = "CargarExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CargarExcel";
            this.Load += new System.EventHandler(this.CargarExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_analizar;
        private System.Windows.Forms.Button bt_examinar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog ofd_archivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_distrito;
        private System.Windows.Forms.ComboBox cb_tablero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_jugador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_ronda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_estadoI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_posicion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_estadoF;
    }
}