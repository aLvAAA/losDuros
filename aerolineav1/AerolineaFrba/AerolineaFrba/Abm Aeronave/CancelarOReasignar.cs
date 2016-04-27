using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class CancelarReasignarAeronave : Form
    {
        private decimal id;
        private DateTime? desde;
        private DateTime? hasta;

        public CancelarReasignarAeronave(decimal id, DateTime? desde, DateTime? hasta )
        {
            InitializeComponent();
            this.id = id;
            this.desde = desde;
            this.hasta = hasta;

        }
        
        private void aceptar_Click(object sender, EventArgs e)
        {
            //Validar que haya checkeado una
            if ((!radioEliminar.Checked && !radioReemplazar.Checked))
            {
                MessageBox.Show("Seleccione una opcion!");
                return;
            }

            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            //Si seleccionó eliminar
            if (radioEliminar.Checked)
            {
                //Si es baja definitiva, eliminar viajes futuros
                if (desde == null) AeronaveAdapter.EliminarViajes(id);
                else AeronaveAdapter.EliminarViajesComprendidos(id,desde,hasta);
            }
            //Si seleccionó reemplazar
            else
            {
                GD2C2015DataSet.AeronaveDataTable mismaFlota = AeronaveAdapter.ObtenerAeronavesMismaFlota(id);
                      
                //Si es baja definitiva
                if (desde == null)
                {
                    foreach (GD2C2015DataSet.AeronaveRow aero2 in mismaFlota)
                    {
                        //Chequear que no colisionen sus viajes
                        if (AeronaveAdapter.TienenMismosViajesProgramadosDesde(id, DateTime.Now, aero2.Field<Decimal>("aero_id"))[0].Field<Decimal>("hayColision") == 0)
                        {
                            //Sino, reemplazarla
                            AeronaveAdapter.ReasignarAeronaveDesde(aero2.Field<Decimal>("aero_id"), id, DateTime.Now);
                            this.Close();
                            return;
                        }
                    }
                    MessageBox.Show("No se encontro una aeronave de la misma flota que pueda realizar los viajes de la primera");

                    //Si no encuentra una aeronave, dar de alta una nueva
                    Abm_Aeronave.AltaAeronave form = new Abm_Aeronave.AltaAeronave();
                    while (form.nuevoID == -1)
                        form.ShowDialog();
                    AeronaveAdapter.ReasignarAeronaveDesde(form.nuevoID, id, DateTime.Now);
                }
                else
                {
                    foreach (GD2C2015DataSet.AeronaveRow aero2 in mismaFlota)
                    {
                        //Chequear que no colisionen sus viajes
                        if (AeronaveAdapter.TienenMismosViajesProgramadosDesdeHasta(id, desde, hasta, aero2.Field<Decimal>("aero_id"))[0].Field<Decimal>("hayColision") == 0)
                        {
                            //Sino, reemplazarla
                            AeronaveAdapter.ReasignarAeronaveDesdeHasta(aero2.Field<Decimal>("aero_id"), id, desde,hasta);
                            this.Close();
                            return;
                        }
                    }
                    MessageBox.Show("No se encontro una aeronave de la misma flota que pueda realizar los viajes de la primera");

                    //Si no encuentra una aeronave, dar de alta una nueva
                    Abm_Aeronave.AltaAeronave form = new Abm_Aeronave.AltaAeronave();
                    while (form.nuevoID == -1)
                        form.ShowDialog();
                    AeronaveAdapter.ReasignarAeronaveDesdeHasta(form.nuevoID, id, desde,hasta);
                }
            }
            this.Close();
        }
    }
}
