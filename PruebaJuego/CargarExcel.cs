using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuego
{
    public partial class CargarExcel : Form
    {
        public CargarExcel()
        {
            InitializeComponent();
        }

        private void CargarExcel_Load(object sender, EventArgs e)
        {
            tabla = null;
            ResultadoDatos = null;
            ResultadoOk = false;
        }

        public int Filas;
        public int Columnas;

        public DistritoTableroRondaTablas ResultadoDatos;
        public bool ResultadoOk;

        DataTable tabla;
        private void bt_examinar_Click(object sender, EventArgs e)
        {
            ofd_archivos.FileName = "";
            ofd_archivos.Filter = "Excel (*.xlsx)|*.xlsx";
            ofd_archivos.Multiselect = false;
            DialogResult dr = ofd_archivos.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    tabla = ImportExceltoDatatable(ofd_archivos.FileName, "");
                    dgv_datos.DataSource = tabla;
                }
                catch (Exception er)
                {
                    dgv_datos.DataSource = null;
                    MessageBox.Show("Error: " + er);
                }
                AgregarColumnas();
            }
        }
        
        private void AgregarColumnas()
        {
            cb_distrito.Items.Clear();
            cb_tablero.Items.Clear();
            cb_jugador.Items.Clear();
            cb_ronda.Items.Clear();
            cb_estadoI.Items.Clear();
            cb_estadoF.Items.Clear();
            cb_posicion.Items.Clear();
            
            if (tabla != null)
            {
                List<string> cols = new List<string>();
                for (int i = 0; i < tabla.Columns.Count; i++)
                { cols.Add(tabla.Columns[i].ColumnName); }
                for (int i = 0; i < cols.Count; i++)
                {
                    cb_distrito.Items.Add(cols[i]);
                    cb_tablero.Items.Add(cols[i]);
                    cb_jugador.Items.Add(cols[i]);
                    cb_ronda.Items.Add(cols[i]);
                    cb_estadoI.Items.Add(cols[i]);
                    cb_estadoF.Items.Add(cols[i]);
                    cb_posicion.Items.Add(cols[i]);
                }
            }
        }


        public static DataTable ImportExceltoDatatable(string filePath, string sheetName)
        {
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;

                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                return dt;
            }
        }

        private void bt_analizar_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            string columna;
            bool NoNum;
            int Indice;
            if (tabla != null && tabla.Rows.Count > 0 &&
                cb_distrito.SelectedIndex >= 0 && cb_tablero.SelectedIndex >= 0 &&
                cb_jugador.SelectedIndex >= 0 && cb_ronda.SelectedIndex >= 0 &&
                cb_estadoI.SelectedIndex >= 0 && cb_estadoF.SelectedIndex >= 0 &&
                cb_posicion.SelectedIndex >= 0)
            {
                bool continuar = true;
                if (continuar)
                {
                    columna = ValorCB(cb_distrito);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_tablero);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_jugador);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_ronda);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_posicion);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_estadoI);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }
                if (continuar)
                {
                    columna = ValorCB(cb_estadoF);
                    continuar = EsColumnaNumerica(columna, out NoNum, out Indice);
                    if (NoNum)
                    {
                        dr = MessageBox.Show("Existe Valores no numericos en la fila " + Indice +
                                             " de la columna " + columna + ". Desea continuar?", "Advertencia",
                                             MessageBoxButtons.YesNo);
                        continuar = dr == DialogResult.Yes;
                    }
                }

                if (continuar)
                {
                    AnalisisConjunto ac = new AnalisisConjunto();
                    ac.AgregarDatosDesdeTabla(tabla, ValorCB(cb_distrito),
                                              ValorCB(cb_tablero), ValorCB(cb_ronda),
                                              ValorCB(cb_jugador), ValorCB(cb_posicion),
                                              ValorCB(cb_estadoI), ValorCB(cb_estadoF));
                    DistritoTableroRondaJPE dtablero = Tablero.AnalisisAgruparTablero(ac, Filas, Columnas);
                    DistritoTableroRondaTablas dtablas = new DistritoTableroRondaTablas();
                    dtablas.ConvertirDesdeJPE(dtablero, Filas, Columnas);

                    ResultadoOk = dtablas.datos.Keys.ToArray().Length > 0;
                    ResultadoDatos = dtablas;

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Error: Se deben elegir todas las columnas");
            }
        }

        private string ValorCB(ComboBox cb)
        {
            return cb.Items[cb.SelectedIndex].ToString();
        }

        private bool EsColumnaNumerica(string columna, out bool ExistenValoresNoNumericos, out int indice)
        {
            indice = 0;
            ExistenValoresNoNumericos = false;
            if (tabla == null) { return false; }
            if (!tabla.Columns.Contains(columna)) { return false; }
            int p;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (!int.TryParse(tabla.Rows[i][columna].ToString(), out p))
                { indice = i; ExistenValoresNoNumericos = true; }
            }
            return true;
        }

    }
}
