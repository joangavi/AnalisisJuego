namespace PruebaJuego
{
    partial class Grafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_importar = new System.Windows.Forms.Button();
            this.bt_pPorcentaje = new System.Windows.Forms.Button();
            this.bt_pCantidad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudIntervalo = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_intervalo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ct)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ct, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ct
            // 
            chartArea1.Name = "ChartArea1";
            this.ct.ChartAreas.Add(chartArea1);
            this.ct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ct.Location = new System.Drawing.Point(3, 3);
            this.ct.Name = "ct";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.ct.Series.Add(series1);
            this.ct.Size = new System.Drawing.Size(748, 379);
            this.ct.TabIndex = 0;
            this.ct.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_intervalo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_importar);
            this.panel1.Controls.Add(this.bt_pPorcentaje);
            this.panel1.Controls.Add(this.bt_pCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudIntervalo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 74);
            this.panel1.TabIndex = 1;
            // 
            // bt_importar
            // 
            this.bt_importar.Location = new System.Drawing.Point(629, 20);
            this.bt_importar.Name = "bt_importar";
            this.bt_importar.Size = new System.Drawing.Size(113, 39);
            this.bt_importar.TabIndex = 4;
            this.bt_importar.Text = "Importar\r\nDatos";
            this.bt_importar.UseVisualStyleBackColor = true;
            this.bt_importar.Click += new System.EventHandler(this.bt_importar_Click);
            // 
            // bt_pPorcentaje
            // 
            this.bt_pPorcentaje.Location = new System.Drawing.Point(251, 20);
            this.bt_pPorcentaje.Name = "bt_pPorcentaje";
            this.bt_pPorcentaje.Size = new System.Drawing.Size(113, 39);
            this.bt_pPorcentaje.TabIndex = 3;
            this.bt_pPorcentaje.Text = "Graficar P\r\nPorcentaje";
            this.bt_pPorcentaje.UseVisualStyleBackColor = true;
            this.bt_pPorcentaje.Click += new System.EventHandler(this.bt_pPorcentaje_Click);
            // 
            // bt_pCantidad
            // 
            this.bt_pCantidad.BackColor = System.Drawing.SystemColors.Control;
            this.bt_pCantidad.Location = new System.Drawing.Point(144, 20);
            this.bt_pCantidad.Name = "bt_pCantidad";
            this.bt_pCantidad.Size = new System.Drawing.Size(101, 39);
            this.bt_pCantidad.TabIndex = 2;
            this.bt_pCantidad.Text = "Graficar P\r\nCantidad";
            this.bt_pCantidad.UseVisualStyleBackColor = false;
            this.bt_pCantidad.Click += new System.EventHandler(this.bt_pCantidad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agrupar Por Intervalo";
            // 
            // nudIntervalo
            // 
            this.nudIntervalo.DecimalPlaces = 1;
            this.nudIntervalo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudIntervalo.Location = new System.Drawing.Point(12, 28);
            this.nudIntervalo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntervalo.Name = "nudIntervalo";
            this.nudIntervalo.Size = new System.Drawing.Size(106, 20);
            this.nudIntervalo.TabIndex = 0;
            this.nudIntervalo.ValueChanged += new System.EventHandler(this.nudIntervalo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sugerido:";
            // 
            // lb_intervalo
            // 
            this.lb_intervalo.AutoSize = true;
            this.lb_intervalo.Location = new System.Drawing.Point(60, 52);
            this.lb_intervalo.Name = "lb_intervalo";
            this.lb_intervalo.Size = new System.Drawing.Size(10, 13);
            this.lb_intervalo.TabIndex = 6;
            this.lb_intervalo.Text = "-";
            // 
            // Grafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Grafico";
            this.Text = "Grafico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Grafico_FormClosing);
            this.Load += new System.EventHandler(this.Grafico_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudIntervalo;
        private System.Windows.Forms.Button bt_pPorcentaje;
        private System.Windows.Forms.Button bt_pCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_importar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lb_intervalo;
        private System.Windows.Forms.Label label2;
    }
}