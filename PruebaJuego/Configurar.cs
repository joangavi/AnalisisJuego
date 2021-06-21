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
    public partial class Configurar : Form
    {
        public ConfigBusqueda configuracion;
        public bool EsNuevo;

        public Configurar()
        {
            InitializeComponent();
        }

        public bool Cargando;

        private void Configurar_Load(object sender, EventArgs e)
        {
            EsNuevo = false;
            Cargando = true;

            if (configuracion != null)
            {
                if (configuracion.Variables2) { tab_Config.SelectedIndex = 0; }
                else { tab_Config.SelectedIndex = 1; }

                for (int i = 0; i < configuracion.Data0.Busqueda.Count; i++)
                {
                    if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Vacio)
                    {
                        C0_vacio.Seleccionado = true;
                        C0_vacio.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.VerdeFlor)
                    {
                        C0_verdeConFlor.Seleccionado = true;
                        C0_verdeConFlor.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Verde)
                    {
                        C0_verde.Seleccionado = true;
                        C0_verde.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Amarilla)
                    {
                        C0_amarilla.Seleccionado = true;
                        C0_amarilla.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.AmarillaCortada)
                    {
                        C0_amarillaCortada.Seleccionado = true;
                        C0_amarillaCortada.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Roja)
                    {
                        C0_roja.Seleccionado = true;
                        C0_roja.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.RojaCortada)
                    {
                        C0_rojaCortada.Seleccionado = true;
                        C0_rojaCortada.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Intervenida)
                    {
                        C0_intervenida.Seleccionado = true;
                        C0_intervenida.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Muerta)
                    {
                        C0_muerta.Seleccionado = true;
                        C0_muerta.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data0.Busqueda[i].EsteTipo == Tipo.Borde)
                    {
                        C0_borde.Seleccionado = true;
                        C0_borde.SoloVecinos = configuracion.Data0.Busqueda[i].SoloVecinos;
                    }
                }

                for (int i = 0; i < configuracion.Data1.Busqueda.Count; i++)
                {
                    if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Vacio)
                    {
                        C1_vacio.Seleccionado = true;
                        C1_vacio.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.VerdeFlor)
                    {
                        C1_verdeConFlor.Seleccionado = true;
                        C1_verdeConFlor.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Verde)
                    {
                        C1_verde.Seleccionado = true;
                        C1_verde.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Amarilla)
                    {
                        C1_amarilla.Seleccionado = true;
                        C1_amarilla.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.AmarillaCortada)
                    {
                        C1_amarillaCortada.Seleccionado = true;
                        C1_amarillaCortada.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Roja)
                    {
                        C1_roja.Seleccionado = true;
                        C1_roja.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.RojaCortada)
                    {
                        C1_rojaCortada.Seleccionado = true;
                        C1_rojaCortada.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Intervenida)
                    {
                        C1_intervenida.Seleccionado = true;
                        C1_intervenida.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Muerta)
                    {
                        C1_muerta.Seleccionado = true;
                        C1_muerta.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1.Busqueda[i].EsteTipo == Tipo.Borde)
                    {
                        C1_borde.Seleccionado = true;
                        C1_borde.SoloVecinos = configuracion.Data1.Busqueda[i].SoloVecinos;
                    }
                }

                for (int i = 0; i < configuracion.Data1Variable.Busqueda.Count; i++)
                {
                    if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Vacio)
                    {
                        D_vacio.Seleccionado = true;
                        D_vacio.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.VerdeFlor)
                    {
                        D_verdeConFlor.Seleccionado = true;
                        D_verdeConFlor.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Verde)
                    {
                        D_verde.Seleccionado = true;
                        D_verde.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Amarilla)
                    {
                        D_amarilla.Seleccionado = true;
                        D_amarilla.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.AmarillaCortada)
                    {
                        D_amarillaCortada.Seleccionado = true;
                        D_amarillaCortada.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Roja)
                    {
                        D_roja.Seleccionado = true;
                        D_roja.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.RojaCortada)
                    {
                        D_rojaCortada.Seleccionado = true;
                        D_rojaCortada.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Intervenida)
                    {
                        D_intervenida.Seleccionado = true;
                        D_intervenida.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Muerta)
                    {
                        D_muerta.Seleccionado = true;
                        D_muerta.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                    else if (configuracion.Data1Variable.Busqueda[i].EsteTipo == Tipo.Borde)
                    {
                        D_borde.Seleccionado = true;
                        D_borde.SoloVecinos = configuracion.Data1Variable.Busqueda[i].SoloVecinos;
                    }
                }

                Prop_rb_Minimo.Checked = configuracion.Var2CalculoMinimo;
                Prop_rb_Promedio.Checked = configuracion.Var2CalculoPromedio;

                D_rb_minimo.Checked = configuracion.Var1CalculoMinimo;
                D_rb_promedio.Checked = configuracion.Var1CalculoPromedio;

                cb_cortarFlor.Checked = configuracion.AccionCortarFlor;
                cb_cortarAmarillo.Checked = configuracion.AccionCortarAmarillo;
                cb_cortarRojo.Checked = configuracion.AccionCortarRojo;

                cb_nuevoAmarillo.Checked = configuracion.AccionNuevoAmarillo;
                cb_nuevoRojo.Checked = configuracion.AccionNuevoRojo;
            }
            else
            {
                configuracion = new ConfigBusqueda();
            }


            C0_vacio.Ocultar = false;
            C0_verdeConFlor.Ocultar = false;
            C0_verde.Ocultar = false;
            C0_amarilla.Ocultar = false;
            C0_amarillaCortada.Ocultar = false;
            C0_roja.Ocultar = false;
            C0_rojaCortada.Ocultar = false;
            C0_intervenida.Ocultar = false;
            C0_muerta.Ocultar = false;
            C0_borde.Ocultar = true;

            C1_vacio.Ocultar = false;
            C1_verdeConFlor.Ocultar = false;
            C1_verde.Ocultar = false;
            C1_amarilla.Ocultar = false;
            C1_amarillaCortada.Ocultar = false;
            C1_roja.Ocultar = false;
            C1_rojaCortada.Ocultar = false;
            C1_intervenida.Ocultar = false;
            C1_muerta.Ocultar = false;
            C1_borde.Ocultar = true;

            D_vacio.Ocultar = false;
            D_verdeConFlor.Ocultar = false;
            D_verde.Ocultar = false;
            D_amarilla.Ocultar = false;
            D_amarillaCortada.Ocultar = false;
            D_roja.Ocultar = false;
            D_rojaCortada.Ocultar = false;
            D_intervenida.Ocultar = false;
            D_muerta.Ocultar = false;
            D_borde.Ocultar = true;

            Cargando = false;
        }

        private void C0_vacio_SelectChange(object sender, EventArgs e)
        {
            if (C0_vacio.Seleccionado)
            { C1_vacio.SoloVecinos = false; C1_vacio.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_vacio.Seleccionado,
                                                          C0_vacio.SoloVecinos,
                                                          Tipo.Vacio);
            }
        }
        private void C0_verdeConFlor_SelectChange(object sender, EventArgs e)
        {
            if (C0_verdeConFlor.Seleccionado)
            { C1_verdeConFlor.SoloVecinos = false; C1_verdeConFlor.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_verdeConFlor.Seleccionado,
                                                          C0_verdeConFlor.SoloVecinos,
                                                          Tipo.VerdeFlor);
            }
        }
        private void C0_verde_SelectChange(object sender, EventArgs e)
        {
            if (C0_verde.Seleccionado)
            { C1_verde.SoloVecinos = false; C1_verde.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_verde.Seleccionado,
                                                          C0_verde.SoloVecinos,
                                                          Tipo.Verde);
            }
        }
        private void C0_amarilla_SelectChange(object sender, EventArgs e)
        {
            if (C0_amarilla.Seleccionado)
            { C1_amarilla.SoloVecinos = false; C1_amarilla.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_amarilla.Seleccionado,
                                                          C0_amarilla.SoloVecinos,
                                                          Tipo.Amarilla);
            }
        }
        private void C0_amarillaCortada_SelectChange(object sender, EventArgs e)
        {
            if (C0_amarillaCortada.Seleccionado)
            { C1_amarillaCortada.SoloVecinos = false; C1_amarillaCortada.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_amarillaCortada.Seleccionado,
                                                          C0_amarillaCortada.SoloVecinos,
                                                          Tipo.AmarillaCortada);
            }
        }
        private void C0_roja_SelectChange(object sender, EventArgs e)
        {
            if (C0_roja.Seleccionado)
            { C1_roja.SoloVecinos = false; C1_roja.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_roja.Seleccionado,
                                                          C0_roja.SoloVecinos,
                                                          Tipo.Roja);
            }
        }
        private void C0_rojaCortada_SelectChange(object sender, EventArgs e)
        {
            if (C0_rojaCortada.Seleccionado)
            { C1_rojaCortada.SoloVecinos = false; C1_rojaCortada.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_rojaCortada.Seleccionado,
                                                          C0_rojaCortada.SoloVecinos,
                                                          Tipo.RojaCortada);
            }
        }
        private void C0_intervenida_SelectChange(object sender, EventArgs e)
        {
            if (C0_intervenida.Seleccionado)
            { C1_intervenida.SoloVecinos = false; C1_intervenida.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_intervenida.Seleccionado,
                                                          C0_intervenida.SoloVecinos,
                                                          Tipo.Intervenida);
            }
        }
        private void C0_muerta_SelectChange(object sender, EventArgs e)
        {
            if (C0_muerta.Seleccionado)
            { C1_muerta.SoloVecinos = false; C1_muerta.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_muerta.Seleccionado,
                                                          C0_muerta.SoloVecinos,
                                                          Tipo.Muerta);
            }
        }
        private void C0_borde_SelectChange(object sender, EventArgs e)
        {
            if (C0_borde.Seleccionado)
            { C1_borde.SoloVecinos = false; C1_borde.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data0.AgregarQuitarBusqueda(C0_borde.Seleccionado,
                                                          C0_borde.SoloVecinos,
                                                          Tipo.Borde);
            }
        }
        
        private void C1_vacio_SelectChange(object sender, EventArgs e)
        {
            if (C1_vacio.Seleccionado)
            { C0_vacio.SoloVecinos = false; C0_vacio.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_vacio.Seleccionado,
                                                          C1_vacio.SoloVecinos,
                                                          Tipo.Vacio);
            }
        }
        private void C1_verdeConFlor_SelectChange(object sender, EventArgs e)
        {
            if (C1_verdeConFlor.Seleccionado)
            { C0_verdeConFlor.SoloVecinos = false; C0_verdeConFlor.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_verdeConFlor.Seleccionado,
                                                          C1_verdeConFlor.SoloVecinos,
                                                          Tipo.VerdeFlor);
            }
        }
        private void C1_verde_SelectChange(object sender, EventArgs e)
        {
            if (C1_verde.Seleccionado)
            { C0_verde.SoloVecinos = false; C0_verde.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_verde.Seleccionado,
                                                          C1_verde.SoloVecinos,
                                                          Tipo.Verde);
            }
        }
        private void C1_amarilla_SelectChange(object sender, EventArgs e)
        {
            if (C1_amarilla.Seleccionado)
            { C0_amarilla.SoloVecinos = false; C0_amarilla.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_amarilla.Seleccionado,
                                                          C1_amarilla.SoloVecinos,
                                                          Tipo.Amarilla);
            }
        }
        private void C1_amarillaCortada_SelectChange(object sender, EventArgs e)
        {
            if (C1_amarillaCortada.Seleccionado)
            { C0_amarillaCortada.SoloVecinos = false; C0_amarillaCortada.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_amarillaCortada.Seleccionado,
                                                          C1_amarillaCortada.SoloVecinos,
                                                          Tipo.AmarillaCortada);
            }
        }
        private void C1_roja_SelectChange(object sender, EventArgs e)
        {
            if (C1_roja.Seleccionado)
            { C0_roja.SoloVecinos = false; C0_roja.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_roja.Seleccionado,
                                                          C1_roja.SoloVecinos,
                                                          Tipo.Roja);
            }
        }
        private void C1_rojaCortada_SelectChange(object sender, EventArgs e)
        {
            if (C1_rojaCortada.Seleccionado)
            { C0_rojaCortada.SoloVecinos = false; C0_rojaCortada.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_rojaCortada.Seleccionado,
                                                          C1_rojaCortada.SoloVecinos,
                                                          Tipo.RojaCortada);
            }
        }
        private void C1_intervenida_SelectChange(object sender, EventArgs e)
        {
            if (C1_intervenida.Seleccionado)
            { C0_intervenida.SoloVecinos = false; C0_intervenida.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_intervenida.Seleccionado,
                                                          C1_intervenida.SoloVecinos,
                                                          Tipo.Intervenida);
            }
        }
        private void C1_muerta_SelectChange(object sender, EventArgs e)
        {
            if (C1_muerta.Seleccionado)
            { C0_muerta.SoloVecinos = false; C0_muerta.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_muerta.Seleccionado,
                                                          C1_muerta.SoloVecinos,
                                                          Tipo.Muerta);
            }
        }
        private void C1_borde_SelectChange(object sender, EventArgs e)
        {
            if (C1_borde.Seleccionado)
            { C0_borde.SoloVecinos = false; C0_borde.Seleccionado = false; }
            if (!Cargando)
            {
                configuracion.Data1.AgregarQuitarBusqueda(C1_borde.Seleccionado,
                                                          C1_borde.SoloVecinos,
                                                          Tipo.Borde);
            }
        }

        private void rb_Minimo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.Var2CalculoMinimo = Prop_rb_Minimo.Checked; }

        private void rb_Promedio_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.Var2CalculoPromedio = Prop_rb_Promedio.Checked; }

        private void D_rb_minimo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.Var1CalculoMinimo = D_rb_minimo.Checked; }

        private void D_rb_promedio_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.Var1CalculoPromedio = D_rb_promedio.Checked; }

        private void cb_cortarFlor_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.AccionCortarFlor = cb_cortarFlor.Checked; }

        private void cb_cortarAmarillo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.AccionCortarAmarillo = cb_cortarAmarillo.Checked; }

        private void cb_cortarRojo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.AccionCortarRojo = cb_cortarRojo.Checked; }

        private void cb_nuevoAmarillo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.AccionNuevoAmarillo = cb_nuevoAmarillo.Checked; }

        private void cb_nuevoRojo_CheckedChanged(object sender, EventArgs e)
        { if (!Cargando) configuracion.AccionNuevoRojo = cb_nuevoRojo.Checked; }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (configuracion.EsCorrecto(out bool Data0Ok, out bool Data1Ok,
                                         out bool CalculoOk, out bool AccionOk))
            {
                EsNuevo = true;
                Close();
            }
            else
            {
                if (!Data0Ok)
                { MessageBox.Show("Falta seleccionar Datos del grupo 0"); }
                else if (!Data1Ok)
                { MessageBox.Show("Falta seleccionar Datos del grupo 1"); }
                if (!CalculoOk)
                { MessageBox.Show("Falta seleccionar Tipo de Calculo"); }
                if (!AccionOk)
                { MessageBox.Show("Falta seleccionar Acción"); }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicializar2Variables()
        {
            if (!Cargando)
            {
                C0_vacio.Seleccionado = false;
                C0_verdeConFlor.Seleccionado = false;
                C0_verde.Seleccionado = false;
                C0_amarilla.Seleccionado = false;
                C0_amarillaCortada.Seleccionado = false;
                C0_roja.Seleccionado = false;
                C0_rojaCortada.Seleccionado = false;
                C0_intervenida.Seleccionado = false;
                C0_muerta.Seleccionado = false;
                C0_borde.Seleccionado = false;

                C1_vacio.Seleccionado = false;
                C1_verdeConFlor.Seleccionado = false;
                C1_verde.Seleccionado = false;
                C1_amarilla.Seleccionado = false;
                C1_amarillaCortada.Seleccionado = false;
                C1_roja.Seleccionado = false;
                C1_rojaCortada.Seleccionado = false;
                C1_intervenida.Seleccionado = false;
                C1_muerta.Seleccionado = false;
                C1_borde.Seleccionado = false;

                Prop_rb_Minimo.Checked = false;
                Prop_rb_Promedio.Checked = false;
            }
        }
        private void Inicializar1Variables()
        {
            if (!Cargando)
            {
                D_vacio.Seleccionado = false;
                D_verdeConFlor.Seleccionado = false;
                D_verde.Seleccionado = false;
                D_amarilla.Seleccionado = false;
                D_amarillaCortada.Seleccionado = false;
                D_roja.Seleccionado = false;
                D_rojaCortada.Seleccionado = false;
                D_intervenida.Seleccionado = false;
                D_muerta.Seleccionado = false;
                D_borde.Seleccionado = false;

                D_rb_minimo.Checked = false;
                D_rb_promedio.Checked = false;
            }
        }

        private void tab_Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_Config.SelectedIndex == 0)
            {
                Inicializar1Variables();
                if (!Cargando) { configuracion.Variables2 = true; configuracion.Variables1 = false; }
            }
            else if (tab_Config.SelectedIndex == 1)
            {
                Inicializar2Variables();
                if (!Cargando) { configuracion.Variables2 = false; configuracion.Variables1 = true; }
            }
        }

        private void D_vacio_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_vacio.Seleccionado,
                                                                  D_vacio.SoloVecinos,
                                                                  Tipo.Vacio);
            }
        }
        private void D_verdeConFlor_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_verdeConFlor.Seleccionado,
                                                                  D_verdeConFlor.SoloVecinos,
                                                                  Tipo.VerdeFlor);
            }
        }
        private void D_verde_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_verde.Seleccionado,
                                                                  D_verde.SoloVecinos,
                                                                  Tipo.Verde);
            }
        }
        private void D_amarilla_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_amarilla.Seleccionado,
                                                                  D_amarilla.SoloVecinos,
                                                                  Tipo.Amarilla);
            }
        }
        private void D_amarillaCortada_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_amarillaCortada.Seleccionado,
                                                                  D_amarillaCortada.SoloVecinos,
                                                                  Tipo.AmarillaCortada);
            }
        }
        private void D_roja_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_roja.Seleccionado,
                                                                  D_roja.SoloVecinos,
                                                                  Tipo.Roja);
            }
        }
        private void D_rojaCortada_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_rojaCortada.Seleccionado,
                                                                  D_rojaCortada.SoloVecinos,
                                                                  Tipo.RojaCortada);
            }
        }
        private void D_intervenida_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_intervenida.Seleccionado,
                                                                  D_intervenida.SoloVecinos,
                                                                  Tipo.Intervenida);
            }
        }
        private void D_muerta_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_muerta.Seleccionado,
                                                                  D_muerta.SoloVecinos,
                                                                  Tipo.Muerta);
            }
        }
        private void D_borde_SelectChange(object sender, EventArgs e)
        {
            if (!Cargando)
            {
                configuracion.Data1Variable.AgregarQuitarBusqueda(D_borde.Seleccionado,
                                                                  D_borde.SoloVecinos,
                                                                  Tipo.Borde);
            }
        }
    }

    public class ConfigBusqueda
    {
        public ConfigBusqueda()
        {
            Data0 = new ConfigData();
            Data1 = new ConfigData();
            Data1Variable = new ConfigData();

            Var1CalculoMinimo = false;
            Var1CalculoPromedio = false;

            Var2CalculoMinimo = false;
            Var2CalculoPromedio = false;

            AccionCortarAmarillo = false;
            AccionCortarFlor = false;
            AccionCortarRojo = false;

            AccionNuevoAmarillo = false;
            AccionNuevoRojo = false;

            Variables2 = true;
            Variables1 = false;
        }

        public ConfigBusqueda Clone()
        {
            ConfigBusqueda salida = new ConfigBusqueda();
            salida.Data0 = Data0.Clone();
            salida.Data1 = Data1.Clone();
            salida.Data1Variable = Data1Variable.Clone();
            salida.Var1CalculoMinimo = Var1CalculoMinimo && true;
            salida.Var1CalculoPromedio = Var1CalculoPromedio && true;
            salida.Var2CalculoMinimo = Var2CalculoMinimo && true;
            salida.Var2CalculoPromedio = Var2CalculoPromedio && true;
            salida.AccionCortarAmarillo = AccionCortarAmarillo && true;
            salida.AccionCortarFlor = AccionCortarFlor && true;
            salida.AccionCortarRojo = AccionCortarRojo && true;
            salida.AccionNuevoAmarillo = AccionNuevoAmarillo && true;
            salida.AccionNuevoRojo = AccionNuevoRojo && true;
            salida.Variables2 = Variables2 && true;
            salida.Variables1 = Variables1 && true;
            return salida;
        }

        public ConfigData Data0;
        public ConfigData Data1;
        public ConfigData Data1Variable;

        public bool Var1CalculoMinimo;
        public bool Var1CalculoPromedio;

        public bool Var2CalculoMinimo;
        public bool Var2CalculoPromedio;

        public bool AccionCortarFlor;
        public bool AccionCortarAmarillo;
        public bool AccionCortarRojo;

        public bool AccionNuevoAmarillo;
        public bool AccionNuevoRojo;

        public bool Variables2;
        public bool Variables1;

        public bool EsCorrecto(out bool Data0Ok,
                               out bool Data1Ok,
                               out bool CalculoOk,
                               out bool AccionOk)
        {
            Data0Ok = false; Data1Ok = false; CalculoOk = false; AccionOk = false;
            if (Variables2)
            {
                Data0Ok = Data0.Busqueda.Count > 0;
                Data1Ok = Data1.Busqueda.Count > 0;
                CalculoOk = Var2CalculoMinimo || Var2CalculoPromedio;
                AccionOk = AccionCortarFlor || AccionCortarAmarillo || AccionCortarRojo || AccionNuevoAmarillo || AccionNuevoRojo;
                return Data0Ok && Data1Ok && CalculoOk && AccionOk;
            }
            else if (Variables1)
            {
                Data0Ok = Data1Variable.Busqueda.Count > 0;
                Data1Ok = true;
                CalculoOk = Var1CalculoMinimo || Var1CalculoPromedio;
                AccionOk = AccionCortarFlor || AccionCortarAmarillo || AccionCortarRojo || AccionNuevoAmarillo || AccionNuevoRojo;
                return Data0Ok && Data1Ok && CalculoOk && AccionOk;
            }
            return false;
        }

    }

    public class ConfigData
    {
        public ConfigData()
        {
            Busqueda = new List<DataTipo>();
        }

        public List<DataTipo> Busqueda;

        public DataTipo BuscarTipo(Tipo tipo)
        {
            int indice = indiceBusqueda(tipo);
            if (indice > 0) { return Busqueda[indice]; }
            return null;
        }

        public ConfigData Clone()
        {
            ConfigData salida = new ConfigData();
            for (int i = 0; i < Busqueda.Count; i++)
            { salida.Busqueda.Add(Busqueda[i].Clone()); }
            return salida;
        }

        public void AgregarQuitarBusqueda(bool Seleccionar, bool SoloVecinos, Tipo EsteTipo)
        {
            int indice = indiceBusqueda(EsteTipo);
            if (Seleccionar)
            {
                if (indice < 0)
                {
                    DataTipo nuevo = new DataTipo();
                    nuevo.EsteTipo = EsteTipo;
                    nuevo.SoloVecinos = SoloVecinos && true;
                    Busqueda.Add(nuevo);
                }
                else
                {
                    Busqueda[indice].EsteTipo = EsteTipo;
                    Busqueda[indice].SoloVecinos = SoloVecinos && true;
                }
            }
            else
            {
                if (indice >= 0) { Busqueda.RemoveAt(indice); }
            }
        }

        private int indiceBusqueda(Tipo tipo)
        {
            for (int i = 0; i < Busqueda.Count; i++)
            {
                if (Busqueda[i].EsteTipo == tipo) { return i; }
            }
            return -1;
        }
    }

    public class DataTipo
    {
        public DataTipo()
        {
            EsteTipo = Tipo.Vacio;
            SoloVecinos = false;
        }
        public Tipo EsteTipo;
        public bool SoloVecinos;

        public DataTipo Clone()
        {
            DataTipo salida = new DataTipo();
            salida.EsteTipo = EsteTipo;
            salida.SoloVecinos = SoloVecinos && true;
            return salida;
        }
    }

}
