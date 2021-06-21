using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuego
{
    public partial class Form1 : Form
    {
        public ConfigBusqueda confiBusqueda;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AnalisisProceso = null;
            confiBusqueda = new ConfigBusqueda();
            confiBusqueda.Data0.AgregarQuitarBusqueda(true, true, Tipo.Borde);
            confiBusqueda.Data1.AgregarQuitarBusqueda(true, true, Tipo.Verde);
            confiBusqueda.Data1.AgregarQuitarBusqueda(true, true, Tipo.VerdeFlor);
            confiBusqueda.Data1.AgregarQuitarBusqueda(true, true, Tipo.Amarilla);
            confiBusqueda.Data1.AgregarQuitarBusqueda(true, true, Tipo.Roja);
            confiBusqueda.Var2CalculoMinimo = true;
            confiBusqueda.AccionCortarAmarillo = true;
            confiBusqueda.AccionCortarRojo = true;
            Gdecisiones = new Decisiones();
            CambiarFilasColumnas(6, 6);
            CentrarTablero();
        }

        const int tamano = 50;

        public void CambiarFilasColumnas(int filas, int columnas)
        {
            tlp_tablero.Size = new Size(columnas * tamano, filas * tamano);

            if (filas > 0 && columnas > 0)
            {
                tlp_tablero.RowCount = filas + 1;
                tlp_tablero.ColumnCount = columnas + 1;
                tlp_tablero.RowStyles.Clear();
                tlp_tablero.ColumnStyles.Clear();

                int mitadF = (int)(Math.Floor(filas / 2.0));
                int mitadC = (int)(Math.Floor(columnas / 2.0));

                //float size = (columnas * tamano - 4.0f) / (columnas + 0.0f);

                for (int i = 0; i < filas + 1; i++)
                {
                    if (i != mitadF)
                    { tlp_tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); }
                    else { tlp_tablero.RowStyles.Add(new RowStyle(SizeType.Absolute, 1)); }
                }
                for (int i = 0; i < columnas + 1; i++)
                {
                    if (i != mitadC)
                    { tlp_tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); }
                    else { tlp_tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1)); }
                }
            }

            CentrarTablero();
            GenerarElementos(filas, columnas);
        }
        
        private void TextDistrito(int num)
        { Tlb_distrito.Text = "Distrito: " + num; }

        private void TextTablero(int num)
        { Tlb_tablero.Text = "Tablero: " + num; }

        private void TextRonda(int num)
        { Tlb_ronda.Text = "Ronda: " + num; }

        public void CentrarTablero()
        {
            tlp_tablero.Location =
                new Point((pnl_contenedor.Size.Width - tlp_tablero.Width) / 2,
                          (pnl_contenedor.Size.Height - tlp_tablero.Height) / 2);

            bt_izq.Location = new Point(bt_izq.Location.X, (bt_izq.Location.Y - tlp_tablero.Height) / 2);
            bt_der.Location = new Point(bt_der.Location.X, (bt_der.Location.Y - tlp_tablero.Height) / 2);
        }
        public static Decisiones Gdecisiones;
        Arbol[][] Grupo;

        private void GenerarElementos(int filas, int columnas)
        {
            tlp_tablero.Visible = false;
            LimpiarElementos();

            int mitadF = (int)(Math.Floor(filas / 2.0));
            int mitadC = (int)(Math.Floor(columnas / 2.0));
            Grupo = new Arbol[columnas][];
            for (int i = 0; i < columnas; i++)
            { Grupo[i] = new Arbol[filas]; }

            for (int i = 0; i < filas; i++)
            { for (int j = 0; j < columnas; j++) { Grupo[j][i] = new Arbol(); } }

            for (int i = 0; i < filas + 1; i++)
            {
                if (i < mitadF)
                {
                    for (int j = 0; j < columnas + 1; j++)
                    {
                        if (j < mitadF)
                        {
                            tlp_tablero.Controls.Add(Grupo[j][i], j, i);
                        }
                        else if (j > mitadC)
                        {
                            tlp_tablero.Controls.Add(Grupo[j - 1][i], j, i);
                        }
                    }
                }
                else if (i > mitadF)
                {
                    for (int j = 0; j < columnas + 1; j++)
                    {
                        if (j < mitadC)
                        {
                            tlp_tablero.Controls.Add(Grupo[j][i - 1], j, i);
                        }
                        else if (j > mitadC)
                        {
                            tlp_tablero.Controls.Add(Grupo[j - 1][i - 1], j, i);
                        }
                    }
                }
            }

            CalcularValores();

            for (int i = 0; i < Grupo.Length; i++)
            {
                for (int j = 0; j < Grupo[i].Length; j++)
                {
                    Grupo[i][j].TipoCambia += TipoCambio;
                    Grupo[i][j].ClickOwn += ClickOwn;
                }
            }

            tlp_tablero.Visible = true;
        }

        private void ClickOwn(object sender, OwnerArg args)
        {
            ArbolSelected = sender as Arbol;
            if (EncontrarArbol(ArbolSelected, out int fila, out int columna))
            {
                if ((ArbolSelected.Tipo == Tipo.Roja || 
                     ArbolSelected.Tipo == Tipo.Amarilla ||
                     ArbolSelected.Tipo == Tipo.VerdeFlor) 
                    && ArbolSelected.ValorP > 0.000001)
                {
                    gb_decision.Enabled = true;
                    cortar_columna.Text = columna.ToString();
                    cortar_estado.BackColor = ArbolSelected.BackColor;
                    cortar_fila.Text = fila.ToString();
                    cortar_p.Text = ArbolSelected.ValorP.ToString("N2", CultureInfo.InvariantCulture);
                    cortar_g.Text = ArbolSelected.valorG.ToString("N2", CultureInfo.InvariantCulture);
                    cortar_grupo.Text = ArbolSelected.Tablero.ToString();
                }
                else
                { LimpiarDesactivarCortarArbol(); }
            }
            else
            { LimpiarDesactivarCortarArbol(); }
        }

        Arbol ArbolSelected;
        private void bt_Cortar_Click(object sender, EventArgs e)
        {
            bool Accion = false;
            if ((confiBusqueda.AccionCortarFlor && ArbolSelected.Tipo == Tipo.VerdeFlor) ||
                (confiBusqueda.AccionCortarAmarillo && ArbolSelected.Tipo == Tipo.Amarilla) ||
                (confiBusqueda.AccionCortarRojo && ArbolSelected.Tipo == Tipo.Roja))
            {
                Accion = true;
                Gdecisiones.AgregarP(ArbolSelected.ValorP);
            }

            if (ArbolSelected.Tipo == Tipo.VerdeFlor) { ArbolSelected.Tipo = Tipo.Verde; }
            else if (ArbolSelected.Tipo == Tipo.Roja) { ArbolSelected.Tipo = Tipo.RojaCortada; }
            else if (ArbolSelected.Tipo == Tipo.Amarilla) { ArbolSelected.Tipo = Tipo.AmarillaCortada; }
            ArbolSelected = null;

            if (Accion) { MessageBox.Show("Accion Guardada"); }
            LimpiarDesactivarCortarArbol();
        }

        private void LimpiarDesactivarCortarArbol()
        {
            gb_decision.Enabled = false;
            cortar_columna.Text = "";
            cortar_estado.BackColor = Color.White;
            cortar_fila.Text = "";
            cortar_g.Text = "";
            cortar_grupo.Text = "";
            cortar_p.Text = "";
        }

        public bool EncontrarArbol(Arbol arbol, out int fila, out int columna)
        {
            fila = -1; columna = -1;
            if (Grupo == null) { return false; }
            int columnas = Grupo.Length;
            int filas = Grupo[0].Length;
            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    if (Grupo[i][j] == arbol) { fila = j; columna = i; return true; }
                }
            }
            return false;
        }

        private void TipoCambio(object sender, EventArgs e)
        {
            CalcularValores();
        }

        public void CalcularValores()
        {
            if (Grupo != null)
            {
                int columnas = Grupo.Length;
                int filas = Grupo[0].Length;
                int mitadF = (int)(Math.Floor(filas / 2.0)) - 1;
                int mitadC = (int)(Math.Floor(columnas / 2.0)) - 1;
                for (int i = 0; i < columnas; i++)
                {
                    for (int j = 0; j < filas; j++)
                    {
                        if (Grupo[i][j].Tipo != Tipo.Vacio)
                        {
                            if (confiBusqueda.Variables2)
                            {
                                if (Tablero.DistanciaMinimaConfig2Variables(Grupo, confiBusqueda, filas,
                                                                            columnas, j, i, mitadF, mitadC,
                                                                            out double D0, out double D1, out int Group))
                                {
                                    Grupo[i][j].ValorP = (D0 + 1.0) / (D0 + D1 + 2.0);
                                    Grupo[i][j].valorG = 0;
                                    Grupo[i][j].Tablero = Group + 0;
                                }
                                else
                                {
                                    Grupo[i][j].ValorP = 0;
                                    Grupo[i][j].valorG = 0;
                                    Grupo[i][j].Tablero = Group + 0;
                                }
                            }
                            else if (confiBusqueda.Variables1)
                            {
                                if (Tablero.DistanciaMinimaConfig1Variable(Grupo, confiBusqueda, filas,
                                                                   columnas, j, i, mitadF, mitadC,
                                                                   out double Dmedido, out double Dmaximo, out int Group))
                                {
                                    Grupo[i][j].ValorP = (Dmaximo - Dmedido) / Dmaximo;
                                    Grupo[i][j].valorG = 0;
                                    Grupo[i][j].Tablero = Group + 0;
                                }
                                else
                                {
                                    Grupo[i][j].ValorP = 0;
                                    Grupo[i][j].valorG = 0;
                                    Grupo[i][j].Tablero = Group + 0;
                                }
                            }
                            else
                            {
                                Grupo[i][j].ValorP = 0;
                                Grupo[i][j].valorG = 0;
                                Grupo[i][j].Tablero = -1;
                            }
                        }
                    }
                }
            }
        }

        private void LimpiarElementos()
        {
            LimpiarDesactivarCortarArbol();
            tlp_tablero.Controls.Clear();
            if (Grupo != null)
            {
                for (int i = 0; i < Grupo.Length; i++)
                {
                    for (int j = 0; j < Grupo[i].Length; j++)
                    {
                        Grupo[i][j].TipoCambia -= TipoCambio;
                        Grupo[i][j].ClickOwn -= ClickOwn;
                    }
                }
            }
        }

        private void nud_filas_ValueChanged(object sender, EventArgs e)
        {
            CambiarFilasColumnas((int)nud_filas.Value, (int)nud_columnas.Value);
        }

        private void nud_columnas_ValueChanged(object sender, EventArgs e)
        {
            CambiarFilasColumnas((int)nud_filas.Value, (int)nud_columnas.Value);
        }

        private void pnl_contenedor_Resize(object sender, EventArgs e)
        {
            CentrarTablero();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_grafico_Click(object sender, EventArgs e)
        {
            Grafico Grafi = new Grafico();
            Grafi.Owner = this;
            Grafi.Show();
        }

        private void bt_configurar_Click(object sender, EventArgs e)
        {
            Configurar confi = new Configurar();
            confi.configuracion = confiBusqueda.Clone();
            confi.ShowDialog();
            if (confi.EsNuevo)
            {
                confiBusqueda = confi.configuracion.Clone();
                if (AnalisisProceso != null && DataDTRT != null)
                {
                    CargarAnalisisExcel(DataDTRT, confiBusqueda);
                }
                else
                {
                    CalcularValores();
                }
            }
        }


        private void bt_cargarExcel_Click(object sender, EventArgs e)
        {
            CargarExcel carga = new CargarExcel();
            carga.Filas = (int)nud_filas.Value;
            carga.Columnas = (int)nud_columnas.Value;
            carga.ShowDialog();
            if (carga.ResultadoOk)
            {
                DataDTRT = carga.ResultadoDatos.Clone();
                CargarAnalisisExcel(DataDTRT, confiBusqueda);
            }
        }
        
        AnalisisExcel AnalisisProceso;
        DistritoTableroRondaTablas DataDTRT;

        private void CargarAnalisisExcel(DistritoTableroRondaTablas DataDTRT, ConfigBusqueda conf)
        {
            CambiarFilasColumnas(6, 6);
            CentrarTablero();
            AnalisisProceso = new AnalisisExcel(DataDTRT, conf);
            gb_CambioFilasColumnas.Enabled = false;
            bt_izq.Enabled = true; bt_der.Enabled = true;
            //bt_configurar.Enabled = false;
            bt_grafico_Totales.Enabled = true;
            if (AnalisisProceso.ItemSelected != null)
            {
                CopiarTablaGrupo(AnalisisProceso.ItemSelected.Tabla);
                TextDistrito(AnalisisProceso.ItemSelected.Distrito);
                TextRonda(AnalisisProceso.ItemSelected.Ronda);
                TextTablero(AnalisisProceso.ItemSelected.Tablero);
                Decisiones dec = AnalisisProceso.CargarDecision(AnalisisProceso.ItemSelected.Distrito,
                                                                AnalisisProceso.ItemSelected.Tablero);
                CopiarDecision(dec);
            }
        }

        public void CopiarTablaGrupo(Arbol[][] nuevo)
        {
            if (nuevo.Length == Grupo.Length && nuevo[0].Length == Grupo[0].Length)
            {
                for (int i = 0; i < Grupo.Length; i++)
                {
                    for (int j = 0; j < Grupo[i].Length; j++)
                    {
                        Grupo[i][j].Tipo = nuevo[i][j].Tipo;
                    }
                }
            }
        }

        private void LimpiarTextoCarga()
        {
            Tlb_distrito.Text = "Distrito:";
            Tlb_ronda.Text = "Ronda";
            Tlb_tablero.Text = "Tablero";
        }

        private void bt_limpiarAnalisis_Click(object sender, EventArgs e)
        {
            LimpiarTextoCarga();
            CambiarFilasColumnas(6, 6);
            CentrarTablero();
            AnalisisProceso = null;
            gb_CambioFilasColumnas.Enabled = true;
            bt_izq.Enabled = false; bt_der.Enabled = false;
            //bt_configurar.Enabled = true;
            bt_grafico_Totales.Enabled = false;
        }

        private void bt_der_Click(object sender, EventArgs e)
        {
            if (AnalisisProceso != null)
            {
                AnalisisProceso.SelectSiguiente();
                if (AnalisisProceso.ItemSelected != null)
                {
                    CopiarTablaGrupo(AnalisisProceso.ItemSelected.Tabla);
                    TextDistrito(AnalisisProceso.ItemSelected.Distrito);
                    TextRonda(AnalisisProceso.ItemSelected.Ronda);
                    TextTablero(AnalisisProceso.ItemSelected.Tablero);
                    Decisiones dec = AnalisisProceso.CargarDecision(AnalisisProceso.ItemSelected.Distrito,
                                                                    AnalisisProceso.ItemSelected.Tablero);
                    CopiarDecision(dec);
                }
                else
                {
                    int ert = 0;
                }
            }
            else
            {
                int erts = 0;
            }
        }

        private void CopiarDecision(Decisiones dec)
        {
            Gdecisiones.CopiarDatos(dec);
        }

        private void bt_izq_Click(object sender, EventArgs e)
        {
            if (AnalisisProceso != null)
            {
                AnalisisProceso.SelectAnterior();
                if (AnalisisProceso.ItemSelected != null)
                {
                    CopiarTablaGrupo(AnalisisProceso.ItemSelected.Tabla);
                    TextDistrito(AnalisisProceso.ItemSelected.Distrito);
                    TextRonda(AnalisisProceso.ItemSelected.Ronda);
                    TextTablero(AnalisisProceso.ItemSelected.Tablero);
                    Decisiones dec = AnalisisProceso.CargarDecision(AnalisisProceso.ItemSelected.Distrito,
                                                                    AnalisisProceso.ItemSelected.Tablero);
                    CopiarDecision(dec);
                }
            }
        }

        private void bt_grafico_Totales_Click(object sender, EventArgs e)
        {
            if (AnalisisProceso != null)
            {
                Grafico Grafi = new Grafico();
                Grafi.Owner = this;
                Grafi.UsarDecisionesCompartidas = false;
                Grafi.DcTemporal = AnalisisProceso.GrupoDecisionesTotales;
                Grafi.Show();
            }
        }
    }

    public class AnalisisExcel
    {
        public AnalisisExcel(DistritoTableroRondaTablas data, ConfigBusqueda conf)
        {
            ItemSelected = null;
            Datos = data;
            confi = conf;
            Lista = new List<ItemDistTablRondTabla>();
            GrupoDecisiones = new Dictionary<int, Dictionary<int, Decisiones>>();
            GrupoDecisionesTotales = new Decisiones();
            ConvertirALista();
            GenerarDecisiones();
        }
        DistritoTableroRondaTablas Datos;
        ConfigBusqueda confi;

        public List<ItemDistTablRondTabla> Lista;
        public ItemDistTablRondTabla ItemSelected;

        public Dictionary<int, Dictionary<int, Decisiones>> GrupoDecisiones;

        public Decisiones GrupoDecisionesTotales;

        public void ConvertirALista()
        {
            int[] CD = Datos.datos.Keys.ToArray();
            for (int i = 0; i < CD.Length; i++)
            {
                int[] CT = Datos.datos[CD[i]].Keys.ToArray();
                for (int j = 0; j < CT.Length; j++)
                {
                    int[] CR = Datos.datos[CD[i]][CT[j]].Keys.ToArray();
                    for (int k = 0; k < CR.Length; k++)
                    {
                        Lista.Add(new ItemDistTablRondTabla(CD[i], CT[j], CR[k], 
                            Datos.datos[CD[i]][CT[j]][CR[k]]));
                    }
                }
            }
            if (Lista.Count > 0) { ItemSelected = Lista[0]; }
        }

        public void SelectSiguiente()
        {
            if (ItemSelected != null)
            {
                int nuevo = Lista.IndexOf(ItemSelected) + 1;
                if (nuevo < Lista.Count)
                {
                    ItemSelected = Lista[nuevo];
                }
            }
        }

        public void SelectAnterior()
        {
            if (ItemSelected != null)
            {
                int nuevo = Lista.IndexOf(ItemSelected) - 1;
                if (nuevo >= 0)
                {
                    ItemSelected = Lista[nuevo];
                }
            }
        }

        public Decisiones CargarDecision(int Distrito,  int Tablero)
        {
            return GrupoDecisiones[Distrito][Tablero];
        }

        private void GenerarDecisiones()
        {
            int[] CD = Datos.datos.Keys.ToArray();
            for (int i = 0; i < CD.Length; i++)
            {
                GrupoDecisiones.Add(CD[i], new Dictionary<int, Decisiones>());
                int[] CT = Datos.datos[CD[i]].Keys.ToArray();
                for (int j = 0; j < CT.Length; j++)
                {
                    List<Arbol[][]> listablas = new List<Arbol[][]>();
                    int[] CR = Datos.datos[CD[i]][CT[j]].Keys.ToArray();
                    Array.Sort(CR);
                    for (int k = 0; k < CR.Length; k++)
                    {
                        listablas.Add(Datos.datos[CD[i]][CT[j]][CR[k]]);
                    }
                    Decisiones dec = AnalizarTableroDecisiones(listablas, confi);
                    GrupoDecisiones[CD[i]].Add(CT[j], dec);
                    GrupoDecisionesTotales.AgregarDatos(dec);
                }
            }
        }

        private Decisiones AnalizarTableroDecisiones(List<Arbol[][]> tablas, ConfigBusqueda conf)
        {
            Decisiones Salida = new Decisiones();
            for (int i = 0; i < tablas.Count - 1; i++)
            {
                Arbol[][] tempA = tablas[i];
                Arbol[][] tempB = tablas[i + 1];
                Tablero.CalcularValoresGrupo(ref tempA, conf);
                for (int j = 0; j < tempA.Length; j++)
                {
                    for (int k = 0; k < tempA[j].Length; k++)
                    {
                        if (tempA[j][k].ValorP > 0.00001)
                        {
                            if (conf.AccionCortarFlor &&
                            (tempA[j][k].Tipo == Tipo.VerdeFlor &&
                            tempB[j][k].Tipo == Tipo.Verde))
                            {
                                Salida.AgregarP(tempA[j][k].ValorP + 0.0);
                            }
                            if (conf.AccionCortarAmarillo &&
                                (tempA[j][k].Tipo == Tipo.Amarilla &&
                                tempB[j][k].Tipo == Tipo.AmarillaCortada))
                            {
                                Salida.AgregarP(tempA[j][k].ValorP + 0.0);
                            }
                            if (conf.AccionCortarRojo &&
                                (tempA[j][k].Tipo == Tipo.Roja &&
                                tempB[j][k].Tipo == Tipo.RojaCortada))
                            {
                                Salida.AgregarP(tempA[j][k].ValorP + 0.0);
                            }
                        }

                        if (tempB[j][k].ValorP > 0.00001)
                        {
                            if (conf.AccionNuevoAmarillo &&
                                (tempA[j][k].Tipo == Tipo.VerdeFlor || tempA[j][k].Tipo == Tipo.Verde) &&
                                 tempB[j][k].Tipo == Tipo.Amarilla)
                            {
                                Salida.AgregarP(tempB[j][k].ValorP + 0.0);
                            }
                            if (conf.AccionNuevoRojo &&
                                (tempA[j][k].Tipo == Tipo.Amarilla && tempB[j][k].Tipo == Tipo.Roja))
                            {
                                Salida.AgregarP(tempB[j][k].ValorP + 0.0);
                            }
                        }
                    }
                }
            }
            return Salida;
        }

    }

    public class ItemDistTablRondTabla
    {
        public ItemDistTablRondTabla(int Distrito, int Tablero, int Ronda, Arbol[][] Tabla)
        {
            this.Distrito = Distrito + 0;
            this.Tablero = Tablero + 0;
            this.Ronda = Ronda + 0;
            this.Tabla = Tabla.Clone() as Arbol[][];
        }
        public int Distrito;
        public int Tablero;
        public int Ronda;
        public Arbol[][] Tabla;
    }

    public class Decisiones
    {
        public event EventHandler CambioDatos;

        public Decisiones()
        {
            ConteoP = new Dictionary<decimal, int>();
        }

        public void CopiarDatos(Decisiones dec)
        {
            ConteoP.Clear();
            decimal[] valsP = dec.ConteoP.Keys.ToArray();
            for (int i = 0; i < valsP.Length; i++)
            { ConteoP.Add(valsP[i], dec.ConteoP[valsP[i]]); }

            CambioDatos?.Invoke(this, new EventArgs());
        }

        public void AgregarDatos(Decisiones dec)
        {
            decimal[] valsP = dec.ConteoP.Keys.ToArray();
            for (int i = 0; i < valsP.Length; i++)
            {
                if (!ConteoP.ContainsKey(valsP[i]))
                { ConteoP.Add(valsP[i], dec.ConteoP[valsP[i]]); }
                else
                { ConteoP[valsP[i]] += dec.ConteoP[valsP[i]]; }
            }
            CambioDatos?.Invoke(this, new EventArgs());
        }
        
        public void AgregarP(double P)
        {
            decimal ps = (decimal)(Math.Round(P * 100.0) / 100.0);
            if (ConteoP.ContainsKey(ps)) { ConteoP[ps]++; }
            else { ConteoP.Add(ps, 1); }
            CambioDatos?.Invoke(this, new EventArgs());
        }

        public void ObtenerPIntervalo(decimal intervalo, out decimal[] listaX,  out decimal[] listaY)
        {
            List<decimal> X = new List<decimal>();
            List<decimal> Y = new List<decimal>();
            if (intervalo > 0 && ContP > 0)
            {
                Dictionary<decimal, int> NuevoXY = new Dictionary<decimal, int>();
                decimal[] listax = ConteoP.Keys.ToArray();
                for (int i = 0; i < listax.Length; i++)
                {
                    decimal nval = ObtenerValIntervalo(listax[i], intervalo);
                    int valor = ConteoP[listax[i]];
                    if (NuevoXY.ContainsKey(nval)) { NuevoXY[nval] += valor; }
                    else { NuevoXY.Add(nval, valor); }
                }
                X = NuevoXY.Keys.ToList();
                for (int i = 0; i < X.Count; i++)
                { Y.Add(NuevoXY[X[i]] + 0); }
            }
            else
            {
                X = ConteoP.Keys.ToList();
                for (int i = 0; i < X.Count; i++)
                { Y.Add(ConteoP[X[i]] + 0); }
            }
            listaX = X.ToArray();
            listaY = Y.ToArray();
        }
        
        private decimal ObtenerValIntervalo(decimal valor, decimal intervalo)
        {
            double Val = (double)valor;
            double Inv = (double)intervalo;
            double valMin = Math.Round((Math.Floor(Val / Inv) * Inv) * 100) / 100.0;
            double valMax = Math.Round((Math.Ceiling(Val / Inv) * Inv) * 100) / 100.0;
            if (Math.Abs(valMin - Val) < Math.Abs(valMax - Val)) { return (decimal)valMin; }
            else { return (decimal)valMax; }
        }

        public int ContP { get { return ConteoP.Count(); } }

        public Dictionary<decimal, int> ConteoP;
    }

    public class Arbol : Label
    {
        public delegate void OwnerHandler(object sender, OwnerArg args);
        public event EventHandler TipoCambia;
        public event OwnerHandler ClickOwn;
        public Arbol()
        {
            DoubleBuffered = true;
            Margin = new Padding(0);
            Padding = new Padding(0);
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Arial", 8.0f);
            Dock = DockStyle.Fill;
            tipo = Tipo.Vacio;
            valor = 0.0;
            valorG = 0.0;
            Tablero = -1;
            CambioTipo();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Tipo == Tipo.Vacio) { Tipo = Tipo.VerdeFlor; }
                else if (Tipo == Tipo.VerdeFlor) { Tipo = Tipo.Verde; }
                else if (Tipo == Tipo.Verde) { Tipo = Tipo.Amarilla; }
                else if (Tipo == Tipo.Amarilla) { Tipo = Tipo.AmarillaCortada; }
                else if (Tipo == Tipo.AmarillaCortada) { Tipo = Tipo.Roja; }
                else if (Tipo == Tipo.Roja) { Tipo = Tipo.RojaCortada; }
                else if (Tipo == Tipo.RojaCortada) { Tipo = Tipo.Intervenida; }
                else if (Tipo == Tipo.Intervenida) { Tipo = Tipo.Muerta; }
                else if (Tipo == Tipo.Muerta) { Tipo = Tipo.Vacio; }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Tipo == Tipo.Vacio) { Tipo = Tipo.Muerta; }
                else if (Tipo == Tipo.Muerta) { Tipo = Tipo.Intervenida; }
                else if (Tipo == Tipo.Intervenida) { Tipo = Tipo.RojaCortada; }
                else if (Tipo == Tipo.RojaCortada) { Tipo = Tipo.Roja; }
                else if (Tipo == Tipo.Roja) { Tipo = Tipo.AmarillaCortada; }
                else if (Tipo == Tipo.AmarillaCortada) { Tipo = Tipo.Amarilla; }
                else if (Tipo == Tipo.Amarilla) { Tipo = Tipo.Verde; }
                else if (Tipo == Tipo.Verde) { Tipo = Tipo.VerdeFlor; }
                else if (Tipo == Tipo.VerdeFlor) { Tipo = Tipo.Vacio; }
            }
            ClickOwn?.Invoke(this, new OwnerArg(this));
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Tipo == Tipo.Vacio) { Tipo = Tipo.VerdeFlor; }
                else if (Tipo == Tipo.VerdeFlor) { Tipo = Tipo.Verde; }
                else if (Tipo == Tipo.Verde) { Tipo = Tipo.Amarilla; }
                else if (Tipo == Tipo.Amarilla) { Tipo = Tipo.AmarillaCortada; }
                else if (Tipo == Tipo.AmarillaCortada) { Tipo = Tipo.Roja; }
                else if (Tipo == Tipo.Roja) { Tipo = Tipo.RojaCortada; }
                else if (Tipo == Tipo.RojaCortada) { Tipo = Tipo.Intervenida; }
                else if (Tipo == Tipo.Intervenida) { Tipo = Tipo.Muerta; }
                else if (Tipo == Tipo.Muerta) { Tipo = Tipo.Vacio; }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Tipo == Tipo.Vacio) { Tipo = Tipo.Muerta; }
                else if (Tipo == Tipo.Muerta) { Tipo = Tipo.Intervenida; }
                else if (Tipo == Tipo.Intervenida) { Tipo = Tipo.RojaCortada; }
                else if (Tipo == Tipo.RojaCortada) { Tipo = Tipo.Roja; }
                else if (Tipo == Tipo.Roja) { Tipo = Tipo.AmarillaCortada; }
                else if (Tipo == Tipo.AmarillaCortada) { Tipo = Tipo.Amarilla; }
                else if (Tipo == Tipo.Amarilla) { Tipo = Tipo.Verde; }
                else if (Tipo == Tipo.Verde) { Tipo = Tipo.VerdeFlor; }
                else if (Tipo == Tipo.VerdeFlor) { Tipo = Tipo.Vacio; }
            }
            ClickOwn?.Invoke(this, new OwnerArg(this));
        }

        private Tipo tipo;

        public Tipo Tipo
        {
            get { return tipo;}
            set { tipo = value; CambioTipo(); }
        }

        private double valor;
        public double ValorP
        {
            get { return valor; }
            set { if (valor != value) { valor = value; CambioTipo(); } }
        }

        public double valorG;
        public int Tablero;

        public void CambioTipo()
        {
            if (tipo == Tipo.VerdeFlor)
            { BackColor = Color.YellowGreen; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.Verde)
            { BackColor = Color.LightGreen; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.Amarilla)
            { BackColor = Color.Khaki; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.AmarillaCortada)
            { BackColor = Color.DarkKhaki; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.Roja)
            { BackColor = Color.LightSalmon; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.RojaCortada)
            { BackColor = Color.RosyBrown; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.Intervenida)
            { BackColor = Color.LightBlue; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else if (tipo == Tipo.Muerta)
            { BackColor = Color.Silver; Text = valor.ToString("N2", CultureInfo.InvariantCulture); }
            else
            { BackColor = Color.White; Text = ""; }
            TipoCambia?.Invoke(this, new EventArgs());
        }

    }

    public class OwnerArg : EventArgs
    {
        public object Owner { get; private set; }
        public OwnerArg(object Owner)
        {
            this.Owner = Owner;
        }
    }

    public enum Tipo
    {
        Vacio,
        Verde,
        VerdeFlor,
        Amarilla,
        AmarillaCortada,
        Roja,
        RojaCortada,
        Intervenida,
        Muerta,
        Borde,
    }
}
