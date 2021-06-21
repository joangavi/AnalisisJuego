namespace PruebaJuego
{
    partial class SelectFila
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp_principal = new System.Windows.Forms.TableLayoutPanel();
            this.cb_Vecino = new System.Windows.Forms.CheckBox();
            this.cb_Columna = new System.Windows.Forms.CheckBox();
            this.tlp_principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_principal
            // 
            this.tlp_principal.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_principal.ColumnCount = 3;
            this.tlp_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_principal.Controls.Add(this.cb_Columna, 1, 0);
            this.tlp_principal.Controls.Add(this.cb_Vecino, 0, 0);
            this.tlp_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_principal.Location = new System.Drawing.Point(0, 0);
            this.tlp_principal.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_principal.Name = "tlp_principal";
            this.tlp_principal.RowCount = 1;
            this.tlp_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_principal.Size = new System.Drawing.Size(195, 19);
            this.tlp_principal.TabIndex = 0;
            // 
            // cb_Vecino
            // 
            this.cb_Vecino.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_Vecino.AutoSize = true;
            this.cb_Vecino.Enabled = false;
            this.cb_Vecino.Location = new System.Drawing.Point(1, 1);
            this.cb_Vecino.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Vecino.Name = "cb_Vecino";
            this.cb_Vecino.Size = new System.Drawing.Size(88, 17);
            this.cb_Vecino.TabIndex = 1;
            this.cb_Vecino.Text = "Solo Vecinos";
            this.cb_Vecino.UseVisualStyleBackColor = true;
            this.cb_Vecino.CheckedChanged += new System.EventHandler(this.cb_Vecino_CheckedChanged);
            // 
            // cb_Columna
            // 
            this.cb_Columna.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_Columna.AutoSize = true;
            this.cb_Columna.Location = new System.Drawing.Point(90, 1);
            this.cb_Columna.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Columna.Name = "cb_Columna";
            this.cb_Columna.Size = new System.Drawing.Size(67, 17);
            this.cb_Columna.TabIndex = 2;
            this.cb_Columna.Text = "Columna";
            this.cb_Columna.UseVisualStyleBackColor = true;
            this.cb_Columna.CheckedChanged += new System.EventHandler(this.cb_Columna_CheckedChanged);
            // 
            // SelectFila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_principal);
            this.Name = "SelectFila";
            this.Size = new System.Drawing.Size(195, 19);
            this.tlp_principal.ResumeLayout(false);
            this.tlp_principal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_principal;
        private System.Windows.Forms.CheckBox cb_Columna;
        private System.Windows.Forms.CheckBox cb_Vecino;
    }
}
