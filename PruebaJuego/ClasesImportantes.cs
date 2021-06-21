using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJuego
{
    public class AnalisisConjunto
    {
        public AnalisisConjunto()
        {
            Datos = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int[]>>>>>();
        }

        //Distrito, Tablero, Ronda, Jugador, Posicion, Estado
        public Dictionary<int,
                          Dictionary<int,
                                     Dictionary<int,
                                                Dictionary<int, Dictionary<int, int[]>>>>> Datos;
        public void AgregarDatosDesdeTabla(DataTable tabla,
                                           string ColumnaDistritos,
                                           string ColumnaTablero,
                                           string ColumnaRonda,
                                           string ColumnaJugador,
                                           string ColumnaPosicion,
                                           string ColumnaEstadoI,
                                           string ColumnaEstadoF)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (int.TryParse(tabla.Rows[i][ColumnaDistritos].ToString(), out int Distrito) &&
                    int.TryParse(tabla.Rows[i][ColumnaTablero].ToString(), out int Tablero) &&
                    int.TryParse(tabla.Rows[i][ColumnaRonda].ToString(), out int Ronda) &&
                    int.TryParse(tabla.Rows[i][ColumnaJugador].ToString(), out int Jugador) &&
                    int.TryParse(tabla.Rows[i][ColumnaPosicion].ToString(), out int Posicion) &&
                    int.TryParse(tabla.Rows[i][ColumnaEstadoI].ToString(), out int EstadoI) &&
                    int.TryParse(tabla.Rows[i][ColumnaEstadoF].ToString(), out int EstadoF))
                {
                    if (!Datos.ContainsKey(Distrito))
                    { Datos.Add(Distrito, new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, int[]>>>>()); }
                    if (!Datos[Distrito].ContainsKey(Tablero))
                    { Datos[Distrito].Add(Tablero, new Dictionary<int, Dictionary<int, Dictionary<int, int[]>>>()); }
                    if (!Datos[Distrito][Tablero].ContainsKey(Ronda))
                    { Datos[Distrito][Tablero].Add(Ronda, new Dictionary<int, Dictionary<int, int[]>>()); }
                    if (!Datos[Distrito][Tablero][Ronda].ContainsKey(Jugador))
                    { Datos[Distrito][Tablero][Ronda].Add(Jugador, new Dictionary<int, int[]>()); }
                    if (!Datos[Distrito][Tablero][Ronda][Jugador].ContainsKey(Posicion))
                    { Datos[Distrito][Tablero][Ronda][Jugador].Add(Posicion, new int[] { EstadoI, EstadoF}); }
                }
            }
            int er = 0;
        }
    }

    public class Tablero
    {
        public static void CalcularValoresGrupo(ref Arbol[][] Grupo, ConfigBusqueda conf)
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
                            if (conf.Variables2)
                            {
                                if (DistanciaMinimaConfig2Variables(Grupo, conf, filas,
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
                            else if (conf.Variables1)
                            {
                                if (DistanciaMinimaConfig1Variable(Grupo, conf, filas,
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
        
        public static bool DistanciaMinimaConfig2Variables(Arbol[][] grupo,
                                                 ConfigBusqueda cb,
                                                 int Filas, int Columnas,
                                                 int Fil, int Col,
                                                 int divFil, int divCol,
                                                 out double Distancia0,
                                                 out double Distancia1,
                                                 out int GrupoA)
        {
            Distancia0 = double.MaxValue;
            Distancia1 = double.MaxValue;
            List<double> ListaD0 = new List<double>();
            List<double> ListaD1 = new List<double>();
            bool encontradoA = false;
            bool encontradoB = false;

            TiposConfiguaracion(cb, out List<Tipo> T0, out List<Tipo> T1,
                                    out List<bool> SV0, out List<bool> SV1);
            GrupoA = DetectarGrupo(Fil, Col, divFil, divCol);

            if (T0.Contains(Tipo.Borde))
            { ListaD0.Add(DistanciaBorde(grupo, Fil, Col)); encontradoA = true; }

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    int indiceT = T0.IndexOf(grupo[j][i].Tipo);
                    if ((i != Fil || j != Col) && indiceT >= 0 &&
                        T0[indiceT] != Tipo.Borde)
                    {
                        int GrupoB = DetectarGrupo(i, j, divFil, divCol);
                        if (SV0[indiceT] && GrupoA != GrupoB)
                        { double d = distacia(Fil, Col, i, j); ListaD0.Add(d); encontradoA = true; }
                        else if (!SV0[indiceT])
                        { double d = distacia(Fil, Col, i, j); ListaD0.Add(d); encontradoA = true; }
                    }
                }
            }

            if (T1.Contains(Tipo.Borde))
            { ListaD1.Add(DistanciaBorde(grupo, Fil, Col)); encontradoB = true; }

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    int indiceT = T1.IndexOf(grupo[j][i].Tipo);
                    if ((i != Fil || j != Col) && indiceT >= 0 &&
                        T1[indiceT] != Tipo.Borde)
                    {
                        int GrupoB = DetectarGrupo(i, j, divFil, divCol);
                        if (SV1[indiceT] && GrupoA != GrupoB)
                        { double d = distacia(Fil, Col, i, j); ListaD1.Add(d); encontradoB = true; }
                        else if (!SV1[indiceT])
                        { double d = distacia(Fil, Col, i, j); ListaD1.Add(d); encontradoB = true; }
                    }
                }
            }

            if (cb.Var2CalculoMinimo)
            {
                for (int i = 0; i < ListaD0.Count; i++)
                { if (ListaD0[i] < Distancia0) { Distancia0 = ListaD0[i] + 0; } }
                for (int i = 0; i < ListaD1.Count; i++)
                { if (ListaD1[i] < Distancia1) { Distancia1 = ListaD1[i] + 0; } }
            }
            else if (cb.Var2CalculoPromedio)
            {
                double d0 = 0.0;
                for (int i = 0; i < ListaD0.Count; i++) { d0 += ListaD0[i] + 0; }
                double d1 = 0.0;
                for (int i = 0; i < ListaD1.Count; i++) { d1 += ListaD1[i] + 0; }
                Distancia0 = d0 / ListaD0.Count;
                Distancia1 = d1 / ListaD1.Count;
            }

            return encontradoA && encontradoB;
        }

        public static bool DistanciaMinimaConfig1Variable(Arbol[][] grupo,
                                                 ConfigBusqueda cb,
                                                 int Filas, int Columnas,
                                                 int Fil, int Col,
                                                 int divFil, int divCol,
                                                 out double Distancia,
                                                 out double DisMaxPosible,
                                                 out int GrupoA)
        {
            Distancia = double.MaxValue;
            List<double> ListaD0 = new List<double>();
            bool encontradoA = false;

            TiposConfiguaracion(cb, out List<Tipo> T0, out List<Tipo> T1,
                                    out List<bool> SV0, out List<bool> SV1);
            GrupoA = DetectarGrupo(Fil, Col, divFil, divCol);

            if (!T0.Contains(Tipo.Borde) || T0.Count > 1)
            { DisMaxPosible = Math.Sqrt(Math.Pow(Filas + 0.0, 2.0) + Math.Pow(Columnas + 0.0, 2.0)); }
            else
            { DisMaxPosible = (Math.Sqrt(Math.Pow(Filas + 0.0, 2.0) + Math.Pow(Columnas + 0.0, 2.0))) / 2.0; }

            if (T0.Contains(Tipo.Borde))
            {
                ListaD0.Add(DistanciaCentro(grupo, Fil, Col)); encontradoA = true;
            }

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    int indiceT = T0.IndexOf(grupo[j][i].Tipo);
                    if ((i != Fil || j != Col) && indiceT >= 0 &&
                        T0[indiceT] != Tipo.Borde)
                    {
                        int GrupoB = DetectarGrupo(i, j, divFil, divCol);
                        if (SV0[indiceT] && GrupoA != GrupoB)
                        { double d = distacia(Fil, Col, i, j); ListaD0.Add(d); encontradoA = true; }
                        else if (!SV0[indiceT])
                        { double d = distacia(Fil, Col, i, j); ListaD0.Add(d); encontradoA = true; }
                    }
                }
            }

            if (cb.Var1CalculoMinimo)
            {
                for (int i = 0; i < ListaD0.Count; i++)
                { if (ListaD0[i] < Distancia) { Distancia = ListaD0[i] + 0; } }
            }
            else if (cb.Var1CalculoPromedio)
            {
                double d0 = 0.0;
                for (int i = 0; i < ListaD0.Count; i++) { d0 += ListaD0[i] + 0; }
                Distancia = d0 / ListaD0.Count;
            }

            return encontradoA;
        }

        private static double DistanciaBorde(Arbol[][] grupo, int Fil, int Col)
        {
            int columnas = grupo.Length - 1;
            int filas = grupo[0].Length - 1;
            double salida = double.MaxValue;
            double d1 = filas - Fil + 0.0;
            double d2 = Fil + 0.0;
            double d3 = columnas - Col + 0.0;
            double d4 = Col + 0.0;
            if (salida > d1) { salida = d1; }
            if (salida > d2) { salida = d2; }
            if (salida > d3) { salida = d3; }
            if (salida > d4) { salida = d4; }
            return salida;
        }

        private static double DistanciaCentro(Arbol[][] grupo, int Fil, int Col)
        {
            double centCol = (grupo.Length + 0.0) / 2.0;
            double centFil = (grupo[0].Length + 0.0) / 2.0;
            double PosCol = Col + 0.5;
            double PosFil = Fil + 0.5;
            return Math.Sqrt(Math.Pow(centFil - PosFil + 0.0, 2.0) + Math.Pow(centCol - PosCol + 0.0, 2.0));
        }

        private static void TiposConfiguaracion(ConfigBusqueda cb,
                                                out List<Tipo> Tipos0, out List<Tipo> Tipos1,
                                                out List<bool> SV0, out List<bool> SV1)
        {
            Tipos0 = new List<Tipo>();
            Tipos1 = new List<Tipo>();
            SV0 = new List<bool>();
            SV1 = new List<bool>();

            if (cb.Variables2)
            {
                for (int i = 0; i < cb.Data0.Busqueda.Count; i++)
                {
                    Tipos0.Add(cb.Data0.Busqueda[i].EsteTipo);
                    SV0.Add(cb.Data0.Busqueda[i].SoloVecinos);
                }
                for (int i = 0; i < cb.Data1.Busqueda.Count; i++)
                {
                    Tipos1.Add(cb.Data1.Busqueda[i].EsteTipo);
                    SV1.Add(cb.Data1.Busqueda[i].SoloVecinos);
                }
            }
            else if (cb.Variables1)
            {
                for (int i = 0; i < cb.Data1Variable.Busqueda.Count; i++)
                {
                    Tipos0.Add(cb.Data1Variable.Busqueda[i].EsteTipo);
                    SV0.Add(cb.Data1Variable.Busqueda[i].SoloVecinos);
                }
            }
        }

        private static double distacia(int filI, int ColI, int filF, int ColF)
        {
            return Math.Sqrt(Math.Pow(filI - filF + 0.0, 2.0) + Math.Pow(ColI - ColF + 0.0, 2.0));
        }

        public static DistritoTableroRondaJPE AnalisisAgruparTablero(AnalisisConjunto ac, int filas, int columnas)
        {
            DistritoTableroRondaJPE jpe = new DistritoTableroRondaJPE();
            //Distrito, Tablero, Ronda, Jugador, Posicion, Estado
            int[] distritos = ac.Datos.Keys.ToArray();
            Array.Sort(distritos);
            for (int i = 0; i < distritos.Length; i++)
            {
                int[] tablero = ac.Datos[distritos[i]].Keys.ToArray();
                Array.Sort(tablero);
                for (int j = 0; j < tablero.Length; j++)
                {
                    int[] ronda = ac.Datos[distritos[i]][tablero[j]].Keys.ToArray();
                    Array.Sort(ronda);
                    for (int k = 0; k < ronda.Length; k++)
                    {
                        int[] jugador = ac.Datos[distritos[i]][tablero[j]][ronda[k]].Keys.ToArray();
                        for (int l = 0; l < jugador.Length; l++)
                        {
                            int[] posicion = ac.Datos[distritos[i]][tablero[j]][ronda[k]][jugador[l]].Keys.ToArray();
                            for (int m = 0; m < posicion.Length; m++)
                            {
                                int[] estado = ac.Datos[distritos[i]][tablero[j]][ronda[k]][jugador[l]][posicion[m]];
                                jpe.Agregar(distritos[i], tablero[j], ronda[k],
                                            jugador[l], posicion[m], estado[0]);
                                if (k == ronda.Length - 1)
                                {
                                    jpe.Agregar(distritos[i], tablero[j], ronda[k] + 1,
                                                jugador[l], posicion[m], estado[1]);
                                }
                            }
                        }
                    }
                }
            }
            return jpe;
        }

        public static Arbol[][] ConvertirListaEnTablero(int filas,
                                                        int columnas,
                                                        JugadorPosicionEstado[] Estados)
        {
            Arbol[][] tablero = new Arbol[columnas][];
            for (int i = 0; i < columnas; i++)
            { tablero[i] = new Arbol[filas]; }

            for (int i = 0; i < tablero.Length; i++)
            {
                for (int j = 0; j < tablero[i].Length; j++)
                {
                    tablero[i][j] = new Arbol();
                }
            }

            int divFil = (int)(Math.Floor((filas - 1.0) / 2.0));
            int divCol = (int)(Math.Floor((columnas - 1.0) / 2.0));
            GrupoNumeroPosicionXY grupoDicionario = PosicionIntPosicionXY(divFil, divCol, filas, columnas);

            for (int i = 0; i < Estados.Length; i++)
            {
                if (grupoDicionario.Consultar(Estados[i].Jugador, 
                                              Estados[i].Posicion, 
                                              out int Fil, out int Col))
                {
                    tablero[Col][Fil] = new Arbol();
                    tablero[Col][Fil].Tipo = EstadoATipo(Estados[i].Estado);
                }
            }
            return tablero;
        }

        public static Tipo EstadoATipo(int num)
        {
            switch (num)
            {
                case 1: return Tipo.VerdeFlor;
                case 2: return Tipo.Verde;
                case 3: return Tipo.Amarilla;
                case 4: return Tipo.Roja;
                case 5: return Tipo.Muerta;
                case 6: return Tipo.Intervenida;
                case 31: return Tipo.AmarillaCortada;
                case 41: return Tipo.RojaCortada;
                default: return Tipo.Vacio;
            }
        }

        public static GrupoNumeroPosicionXY PosicionIntPosicionXY(int divFil, int divCol, int filas, int columnas)
        {
            GrupoNumeroPosicionXY salida = new GrupoNumeroPosicionXY();
            int fils = divFil;
            int cols = divCol;
            int conteo = 1;
            int grupo = DetectarGrupo(0, 0, divFil, divCol);
            while (true)
            {
                for (int i = 0; i <= cols; i++)
                { salida.Agregar(grupo + 0, conteo + 0, fils >= 0 ? fils: 0, i + 0); conteo++; }
                fils--;
                for (int i = fils; i >= 0; i--)
                { salida.Agregar(grupo + 0, conteo + 0, i + 0, cols >= 0 ? cols : 0); conteo++; }
                cols--;
                if (fils < 0 && cols < 0) { break; }
            }

            fils = divFil;
            cols = divCol + 1;
            conteo = 1;
            grupo = DetectarGrupo(0, columnas, divFil, divCol);
            while (true)
            {
                for (int i = columnas - 1; i >= cols; i--)
                { salida.Agregar(grupo + 0, conteo + 0, fils >= 0 ? fils : 0, i + 0); conteo++; }
                fils--;
                for (int i = fils; i >= 0; i--)
                { salida.Agregar(grupo + 0, conteo + 0, i + 0, cols < columnas ? cols: columnas - 1); conteo++; }
                cols++;
                if (fils < 0 && cols > columnas - 1) { break; }
            }

            fils = divFil + 1;
            cols = divCol;
            conteo = 1;
            grupo = DetectarGrupo(filas, 0, divFil, divCol);
            while (true)
            {
                for (int i = 0; i <= cols; i++)
                { salida.Agregar(grupo + 0, conteo + 0, fils < filas ? fils : filas - 1, i + 0); conteo++; }
                fils++;
                for (int i = fils; i < filas; i++)
                { salida.Agregar(grupo + 0, conteo + 0, i + 0, cols >= 0 ? cols : 0); conteo++; }
                cols--;
                if (fils > filas - 1 && cols < 0) { break; }
            }

            fils = divFil + 1;
            cols = divCol + 1;
            conteo = 1;
            grupo = DetectarGrupo(filas, columnas, divFil, divCol);
            while (true)
            {
                for (int i = columnas - 1; i >= cols; i--)
                { salida.Agregar(grupo + 0, conteo + 0, fils < filas ? fils : filas - 1, i + 0); conteo++; }
                fils++;
                for (int i = fils; i < filas; i++)
                { salida.Agregar(grupo + 0, conteo + 0, i + 0, cols < columnas ? cols : columnas - 1); conteo++; }
                cols++;
                if (fils > filas - 1 && cols > columnas - 1) { break; }
            }

            return salida;
        }

        public static int DetectarGrupo(int Fil, int Col, int divFil, int divCol)
        {
            if (Fil <= divFil)
            {
                if (Col <= divCol) { return 2; }
                else { return 4; }
            }
            else
            {
                if (Col <= divCol) { return 1; }
                else { return 3; }
            }
        }
    }

    public class GrupoNumeroPosicionXY
    {
        public GrupoNumeroPosicionXY()
        {
            GPXY = new Dictionary<int, Dictionary<int, int[]>>();
        }

        //GrupoNumeroPosicion
        private Dictionary<int, Dictionary<int, int[]>> GPXY;

        public void Agregar(int Grupo, int Posicion, int fila, int columna)
        {
            if (!GPXY.ContainsKey(Grupo))
            { GPXY.Add(Grupo, new Dictionary<int, int[]>()); }
            if (!GPXY[Grupo].ContainsKey(Posicion))
            { GPXY[Grupo].Add(Posicion, new int[] { fila, columna }); }
        }

        public bool Consultar(int Grupo, int Posicion, out int fila, out int columna)
        {
            fila = -1; columna = -1;
            if (!GPXY.ContainsKey(Grupo)) { return false; }
            if (!GPXY[Grupo].ContainsKey(Posicion)) { return false; }
            fila = GPXY[Grupo][Posicion][0];
            columna = GPXY[Grupo][Posicion][1];
            return true;
        }
    }
    
    public class DistritoTableroRondaJPE
    {
        public DistritoTableroRondaJPE()
        {
            data = new Dictionary<int, Dictionary<int, Dictionary<int, List<JugadorPosicionEstado>>>>();
        }
        //distrito, tablero, ronda, JPE
        public Dictionary<int, Dictionary<int, Dictionary<int, List<JugadorPosicionEstado>>>> data;

        public void Agregar(int distrito, int tablero, int ronda, 
                            int jugador, int posicion, int estado)
        {
            if (!data.ContainsKey(distrito))
            { data.Add(distrito, new Dictionary<int, Dictionary<int, List<JugadorPosicionEstado>>>()); }
            if (!data[distrito].ContainsKey(tablero))
            { data[distrito].Add(tablero, new Dictionary<int, List<JugadorPosicionEstado>>()); }
            if (!data[distrito][tablero].ContainsKey(ronda))
            { data[distrito][tablero].Add(ronda, new List<JugadorPosicionEstado>()); }
            data[distrito][tablero][ronda].Add(new JugadorPosicionEstado(jugador, posicion, estado));
        }
    }

    public class DistritoTableroRondaTablas
    {
        public DistritoTableroRondaTablas()
        {
            datos = new Dictionary<int, Dictionary<int, Dictionary<int, Arbol[][]>>>();
        }
        //distrito, tablero, ronda, tabla
        public Dictionary<int, Dictionary<int, Dictionary<int, Arbol[][]>>> datos;

        public void ConvertirDesdeJPE(DistritoTableroRondaJPE data, int filas, int columnas)
        {
            int[] distrito = data.data.Keys.ToArray();
            for (int i = 0; i < distrito.Length; i++)
            {
                int[] tableros = data.data[distrito[i]].Keys.ToArray();
                for (int j = 0; j < tableros.Length; j++)
                {
                    int[] rondas = data.data[distrito[i]][tableros[j]].Keys.ToArray();
                    for (int k = 0; k < rondas.Length; k++)
                    {
                        if (!datos.ContainsKey(distrito[i]))
                        { datos.Add(distrito[i], new Dictionary<int, Dictionary<int, Arbol[][]>>()); }
                        if (!datos[distrito[i]].ContainsKey(tableros[j]))
                        { datos[distrito[i]].Add(tableros[j], new Dictionary<int, Arbol[][]>()); }
                        if (!datos[distrito[i]][tableros[j]].ContainsKey(rondas[k]))
                        {
                            datos[distrito[i]][tableros[j]].Add
                                (rondas[k], Tablero.ConvertirListaEnTablero
                                (filas, columnas, data.data[distrito[i]][tableros[j]][rondas[k]].ToArray()));
                        }
                    }
                }
            }
        }

        public DistritoTableroRondaTablas Clone()
        {
            DistritoTableroRondaTablas salida = new DistritoTableroRondaTablas();
            int[] cD = datos.Keys.ToArray();
            for (int i = 0; i < cD.Length; i++)
            {
                salida.datos.Add(cD[i] + 0, new Dictionary<int, Dictionary<int, Arbol[][]>>());
                int[] cT = datos[cD[i]].Keys.ToArray();
                for (int j = 0; j < cT.Length; j++)
                {
                    salida.datos[cD[i]].Add(cT[j] + 0, new Dictionary<int, Arbol[][]>());
                    int[] cR = datos[cD[i]][cT[j]].Keys.ToArray();
                    for (int k = 0; k < cR.Length; k++)
                    {
                        salida.datos[cD[i]][cT[j]].Add(cR[k] + 0,
                            datos[cD[i]][cT[j]][cR[k]].Clone() as Arbol[][]);
                    }
                }
            }
            return salida;
        }

    }

    public class JugadorPosicionEstado
    {
        public JugadorPosicionEstado(int Jugador, int Posicion, int Estado)
        {
            this.Jugador = Jugador;
            this.Posicion = Posicion;
            this.Estado = Estado;
        }
        public int Jugador;
        public int Posicion;
        public int Estado;
    }

    public class DistritoTableroRondas
    {
        public DistritoTableroRondas()
        {
            ListaDatos = new Dictionary<int, Dictionary<int, Dictionary<int, List<Arbol[][]>>>>();
        }
        private Dictionary<int, Dictionary<int, Dictionary<int, List<Arbol[][]>>>> ListaDatos;

        public void AgregarDistritoTableroRonda(int Distrito, int Tablero, int Rondas, Arbol[][] Tabla)
        {

        }
        //public void AgregarDatos(int Distrito, int Ronda, )
    }

    public class RondaTablero
    {
        public RondaTablero(int Ronda, Arbol[][] Tablero)
        {
            this.Ronda = Ronda;
            this.Tablero = Tablero;
        }
        public int Ronda;
        public Arbol[][] Tablero;
    }
}
