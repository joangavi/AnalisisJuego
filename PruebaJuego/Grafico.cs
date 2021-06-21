using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuego
{
    public partial class Grafico : Form
    {
        public Grafico()
        {
            InitializeComponent(); UsarDecisionesCompartidas = true;
        }

        public bool UsarDecisionesCompartidas;
        public Decisiones DcTemporal;

        private void Grafico_Load(object sender, EventArgs e)
        {
            if (UsarDecisionesCompartidas)
            {
                DcTemporal = Form1.Gdecisiones;
                DcTemporal.CambioDatos += Gdecisiones_CambioDatos;
            }
            else if (DcTemporal != null)
            {
                DcTemporal.CambioDatos += Gdecisiones_CambioDatos;
            }

            GraficarPNormal = true;
            GraficarPPorcentaje = false;
            GraficarGNormal = false;
            GraficarGPorcentaje = false;
            ColorearBotones();
            GenerarDatosGraficar();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void GenerarGrafico(bool pNormal, bool pPorcen, bool gNormal, bool gPorcen)
        {
            if (pNormal) { Graficar(PxNormal, PyNormal, false); }
            else if (pPorcen) { Graficar(PxPorcentaje, PyPorcentaje, true); }
        }

        private void Graficar(decimal[] Px, decimal[] Py, bool esPorcen)
        {
            ct.Series.Clear();
            ct.Series.Add("S");
            ct.Series["S"].IsVisibleInLegend = false;
            if (Px != null && Px.Length > 0)
            {
                double interv = (double)nudIntervalo.Value;
                //if (interv)
                double maximo = 0;
                for (int i = 0; i < Px.Length; i++)
                {
                    ct.Series["S"].Points.AddXY(Px[i], Py[i]);
                    ct.Series["S"].IsValueShownAsLabel = true;
                    //ct.ChartAreas[0].AxisX.Interval = PendienteIntervalo;
                    ct.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    ct.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    ct.ChartAreas[0].AxisX.Minimum = 0;
                    ct.ChartAreas[0].AxisX.Maximum = 1;
                    if (maximo < (double)Py[i]) { maximo = (double)Py[i] + 0.0; }
                }
                if (esPorcen)
                {
                    ct.ChartAreas[0].AxisY.Minimum = 0;
                    ct.ChartAreas[0].AxisY.Maximum = 1;
                }
                else
                {
                    ct.ChartAreas[0].AxisY.Minimum = 0;
                    ct.ChartAreas[0].AxisY.Maximum = (double)maximo;
                }
            }
        }

        private decimal[] PxNormal;
        private decimal[] PyNormal;

        private decimal[] PxPorcentaje;
        private decimal[] PyPorcentaje;

        private bool GraficarPNormal;
        private bool GraficarPPorcentaje;
        private bool GraficarGNormal;
        private bool GraficarGPorcentaje;

        private void ColorearBotones()
        {
            if (GraficarPNormal) { bt_pCantidad.BackColor = Color.LightBlue; } else { bt_pCantidad.BackColor = DefaultBackColor; }
            if (GraficarPPorcentaje) { bt_pPorcentaje.BackColor = Color.LightBlue; } else { bt_pPorcentaje.BackColor = DefaultBackColor; }
            //if (GraficarGNormal) { bt_gCantidad.BackColor = Color.LightBlue; } else { bt_gCantidad.BackColor = DefaultBackColor; }
            //if (GraficarGPorcentaje) { bt_gPorcentaje.BackColor = Color.LightBlue; } else { bt_gPorcentaje.BackColor = DefaultBackColor; }
        }

        private void GenerarDatosGraficar()
        {
            lb_intervalo.Text = "-";
            if (DcTemporal.ContP > 0)
            {
                DcTemporal.ObtenerPIntervalo(nudIntervalo.Value, out decimal[] listPX, out decimal[] listPY);

                PxNormal = listPX.Clone() as decimal[];
                PxPorcentaje = listPX.Clone() as decimal[];

                PyNormal = listPY.Clone() as decimal[];

                decimal sumaPy = 0.0m;
                decimal sumaGy = 0.0m;
                for (int i = 0; i < listPY.Length; i++) { sumaPy += listPY[i]; }

                PyPorcentaje = listPY.Clone() as decimal[];
                for (int i = 0; i < PyPorcentaje.Length; i++) { PyPorcentaje[i] = PyPorcentaje[i] / sumaPy; }

                double sugerido = ObtenerIntervaloSugerido(DcTemporal.ConteoP);
                if (!double.IsNaN(sugerido))
                {
                    lb_intervalo.Text = sugerido.ToString("N2", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                PxNormal = new decimal[] { };
                PxPorcentaje = new decimal[] { };

                PyNormal = new decimal[] { };
                PyPorcentaje = new decimal[] { };
            }
        }

        private double ObtenerIntervaloSugerido(Dictionary<decimal,int> DicValores)
        {
            decimal[] valores = DicValores.Keys.ToArray();
            if (valores.Length <= 1) { return double.NaN; }
            Dictionary<decimal, double> PromedioDistanciaNormalizada = new Dictionary<decimal, double>();
            Dictionary<decimal, double> PromedioDistanciaEscalada = new Dictionary<decimal, double>();
            Dictionary<decimal, double> VarianzaDistanciaEscalada = new Dictionary<decimal, double>();
            Dictionary<decimal, double> DivisionesMaximasPosibles = new Dictionary<decimal, double>();
            Dictionary<decimal, double> DivisionesRealesDadas = new Dictionary<decimal, double>();
            Dictionary<decimal, double> RelacionDivisionesDadas = new Dictionary<decimal, double>();
            Dictionary<decimal, double> PromedioDistanciaDatosPosibles = new Dictionary<decimal, double>();
            Dictionary<decimal, double> PromedioDistanciaDatosPosiblesNormal = new Dictionary<decimal, double>();
            Dictionary<decimal, double> ValorMayorAgrupacion = new Dictionary<decimal, double>();
            Dictionary<decimal, double> PromedioMulti = new Dictionary<decimal, double>();
            Dictionary<decimal, int> conteoGrup;


            for (decimal i = 0.1m; i < 1.0m; i += 0.1m)
            {

                //Promedio Distancias Normalizadas
                double sum = 0.0;
                double con = 0.0;
                double promedioDistancias = 0.0;
                for (int j = 0; j < valores.Length; j++)
                {
                    decimal val1 = valores[j];
                    decimal val2 = ObtenerValIntervalo(valores[j], i);
                    sum += (double)Math.Abs(val1 - val2);
                    con += 1.0;
                }
                promedioDistancias = sum / con;
                PromedioDistanciaNormalizada.Add(i + 0.0m, promedioDistancias);

                //Promedio Distancias en Escala
                sum = 0.0;
                con = 0.0;
                double promedioDistanciaEscala = 0.0;
                for (int j = 0; j < valores.Length; j++)
                {
                    decimal val1 = valores[j];
                    decimal val2 = ObtenerValIntervalo(valores[j], i);
                    sum += (double)(Math.Abs(val1 - val2) / (i / 2.0m));
                    con += 1.0;
                }
                promedioDistanciaEscala = sum / con;
                PromedioDistanciaEscalada.Add(i + 0.0m, promedioDistanciaEscala);

                //Varianza Distancias en Escala
                sum = 0.0;
                con = 0.0;
                double VarianzaDistanciaEscala = 0.0;
                double sumVar = 0.0;
                for (int j = 0; j < valores.Length; j++)
                {
                    decimal val1 = valores[j];
                    decimal val2 = ObtenerValIntervalo(valores[j], i);
                    double valnorm = (double)(Math.Abs(val1 - val2) / (i / 2.0m));
                    sumVar += Math.Pow(valnorm - promedioDistanciaEscala, 2.0);
                    con += 1.0;
                }
                VarianzaDistanciaEscala = sumVar / (con - 1.0);
                VarianzaDistanciaEscalada.Add(i + 0.0m, promedioDistanciaEscala);

                //divisiones maximas posibles
                double DivisionesMaxPosibles = Math.Floor(1.0 / (double)i);
                DivisionesMaximasPosibles.Add(i + 0.0m, DivisionesMaxPosibles);

                //conteo Divisiones Reales
                Dictionary<decimal, int> conteoDiv = new Dictionary<decimal, int>();
                for (int j = 0; j < valores.Length; j++)
                {
                    decimal val2 = ObtenerValIntervalo(valores[j], i);
                    if (!conteoDiv.ContainsKey(val2)) { conteoDiv.Add(val2, 0); }
                    conteoDiv[val2] += 1;
                }
                double DivisionesReales = conteoDiv.Keys.Count + 0.0;
                DivisionesRealesDadas.Add(i + 0.0m, DivisionesReales);

                double RelacionDivisiones = DivisionesReales / DivisionesMaxPosibles;
                RelacionDivisionesDadas.Add(i + 0.0m, RelacionDivisiones);

                //divisiones datos posibles
                double DivisionesDatosPosibles = (valores.Length + 0.0) / DivisionesReales;

                //Promedio distancia datos posible vs reales
                sum = 0.0;
                con = 0.0;
                decimal[] keys = conteoDiv.Keys.ToArray();
                for (int j = 0; j < keys.Length; j++)
                {
                    double valor = conteoDiv[keys[j]] + 0.0;
                    sum += Math.Abs(DivisionesDatosPosibles - valor);
                    con += 1.0;
                }
                double PromDistDatosPosibleRales = sum / con;
                PromedioDistanciaDatosPosibles.Add(i + 0.0m, PromDistDatosPosibleRales);

                //Promedio distancia datos posible vs reales Normalizado
                sum = 0.0;
                con = 0.0;
                for (int j = 0; j < keys.Length; j++)
                {
                    double valor = conteoDiv[keys[j]] + 0.0;
                    sum += Math.Abs(DivisionesDatosPosibles - valor) / DivisionesDatosPosibles;
                    con += 1.0;
                }
                double PromDistDatosPosibleRalesNormal = sum / con;
                PromedioDistanciaDatosPosiblesNormal.Add(i + 0.0m, PromDistDatosPosibleRalesNormal);

                //Maxima Cantidad de Valores Agrupados
                double MayorAgrupacionReal = 0;
                for (int j = 0; j < keys.Length; j++)
                {
                    double valor = conteoDiv[keys[j]] + 0.0;
                    if (valor > MayorAgrupacionReal) { MayorAgrupacionReal = valor + 0.0; }
                }
                ValorMayorAgrupacion.Add(i + 0.0m, MayorAgrupacionReal);

                //Valor Multipicado
                double temp = 0;
                if (DivisionesMaxPosibles == 1 || VarianzaDistanciaEscala > 1) { temp = 0; } else { temp = 1; }
                double resultado = temp * Math.Abs(promedioDistanciaEscala);
                //resultado = temp * promedioDistanciaEscala * (1 / (1 - (double)i));
                PromedioMulti.Add(i + 0.0m, resultado);
            }

            decimal salida = 0;
            double min = 0.0;
            decimal[] vals = PromedioMulti.Keys.ToArray();
            bool encontrado = false;
            for (int i = 0; i < vals.Length; i++)
            {
                if (PromedioMulti[vals[i]] > min) { salida = vals[i]; min = PromedioMulti[vals[i]]; }
                if (min > 0) { encontrado = true; }
            }
            if (!encontrado) { salida = 0; }
            return (double)salida;
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

        private void Gdecisiones_CambioDatos(object sender, EventArgs e)
        {
            GenerarDatosGraficar();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void Grafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            DcTemporal.CambioDatos -= Gdecisiones_CambioDatos;
        }

        private void bt_pCantidad_Click(object sender, EventArgs e)
        {
            GraficarPNormal = true;
            GraficarPPorcentaje = false;
            GraficarGNormal = false;
            GraficarGPorcentaje = false;
            ColorearBotones();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void bt_pPorcentaje_Click(object sender, EventArgs e)
        {
            GraficarPNormal = false;
            GraficarPPorcentaje = true;
            GraficarGNormal = false;
            GraficarGPorcentaje = false;
            ColorearBotones();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void bt_gCantidad_Click(object sender, EventArgs e)
        {
            GraficarPNormal = false;
            GraficarPPorcentaje = false;
            GraficarGNormal = true;
            GraficarGPorcentaje = false;
            ColorearBotones();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void bt_gPorcentaje_Click(object sender, EventArgs e)
        {
            GraficarPNormal = false;
            GraficarPPorcentaje = false;
            GraficarGNormal = false;
            GraficarGPorcentaje = true;
            ColorearBotones();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void nudIntervalo_ValueChanged(object sender, EventArgs e)
        {
            GenerarDatosGraficar();
            GenerarGrafico(GraficarPNormal, GraficarPPorcentaje, GraficarGNormal, GraficarGPorcentaje);
        }

        private void bt_importar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ".xlsx Files (*.xlsx)|*.xlsx";
            DialogResult dres = saveFileDialog1.ShowDialog();
            if (dres == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                DataTable TablaN = new DataTable();
                TablaN.Columns.Add("Peso", typeof(decimal));
                TablaN.Columns.Add("Decisiones", typeof(int));

                DataTable TablaP = new DataTable();
                TablaP.Columns.Add("Peso", typeof(decimal));
                TablaP.Columns.Add("Porcentaje", typeof(int));

                if (PxNormal != null && PyNormal != null)
                {
                    for (int i = 0; i < PxNormal.Length; i++)
                    {
                        DataRow dr = TablaN.NewRow();
                        dr["Peso"] = PxNormal[i];
                        dr["Decisiones"] = PyNormal[i];
                        TablaN.Rows.Add(dr);
                    }
                }

                if (PxPorcentaje != null && PyPorcentaje != null)
                {
                    for (int i = 0; i < PxPorcentaje.Length; i++)
                    {
                        DataRow dr = TablaP.NewRow();
                        dr["Peso"] = PxPorcentaje[i];
                        dr["Porcentaje"] = PyPorcentaje[i];
                        TablaP.Rows.Add(dr);
                    }
                }

                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(TablaN, "Datos Numericos");
                wb.Worksheets.Add(TablaP, "Datos Porcentaje");
                string guardar = Path.Combine(path);
                try
                {
                    wb.SaveAs(guardar);
                    System.Diagnostics.Process.Start(guardar);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al guardar el archivo: " + error);
                }
            }
        }
    }
}

