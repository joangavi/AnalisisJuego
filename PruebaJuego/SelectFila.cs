using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuego
{
    [DefaultEvent("SelectChange")]
    public partial class SelectFila : UserControl
    {
        public event EventHandler SelectChange;

        public SelectFila()
        {
            InitializeComponent();
            seleccionado = false;
            soloVecinos = false;
        }

        private string nombreColumna;
        public string NombreColumna
        {
            get { return nombreColumna; }
            set { nombreColumna = value; cb_Columna.Text = value; }
        }

        private bool seleccionado;
        private bool soloVecinos;

        public bool Ocultar
        {
            get { return !cb_Vecino.Visible; }
            set { cb_Vecino.Visible = !value; }
        }

        public bool Seleccionado
        {
            get { return seleccionado; }
            set { seleccionado = value; cb_Columna.Checked = value; }
        }

        public bool SoloVecinos
        {
            get { return soloVecinos; }
            set { soloVecinos = value; cb_Vecino.Checked = value; }
        }

        private void cb_Columna_CheckedChanged(object sender, EventArgs e)
        {
            seleccionado = cb_Columna.Checked;
            cb_Vecino.Enabled = cb_Columna.Checked;
            SelectChange?.Invoke(this, new EventArgs());
        }

        private void cb_Vecino_CheckedChanged(object sender, EventArgs e)
        {
            soloVecinos = cb_Vecino.Checked;
            SelectChange?.Invoke(this, new EventArgs());
        }

        public Tipo TipoPlanta { get; set; }
    }
}
