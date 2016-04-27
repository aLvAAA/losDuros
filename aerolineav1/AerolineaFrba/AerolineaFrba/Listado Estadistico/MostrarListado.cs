using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class MostrarListado : Form
    {
        private int semestre, anio;
        String listado;

        public MostrarListado(int semestre, int anio, String listado)
        {
            InitializeComponent();
            this.semestre = semestre;
            this.anio = anio;
            this.listado = listado;
        }
        
        private void MostrarListado_Load(object sender, EventArgs e)
        {
            //Configurar rango de fechas
            int inicio,fin;
            if(semestre == 1){
                inicio = 1;
                fin = 6;
            }else{
                inicio = 6;
                fin = 12;
            }

            DateTime rangoInicio = new DateTime(anio, inicio, 1);
            DateTime rangoFin = new DateTime(anio, fin, 1);

            //Segun el tipo de listado, mostrar el indicado
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter(); 
            switch (listado)
            {
                case "pasajes_comprados":
                    listadoGrid.DataSource = ciudadAdapter.DestinosMasComprados(rangoInicio, rangoFin);
                    break;
                case "aeronaves_vacias":
                    listadoGrid.DataSource = ciudadAdapter.DestinosMasVacios(rangoInicio, rangoFin);
                    break;
                case "pasajes_cancelados":
                    listadoGrid.DataSource = ciudadAdapter.DestinosCancelados(rangoInicio, rangoFin);
                    break;
                case "aeronaves_servicio":
                    GD2C2015DataSetTableAdapters.AeronaveTableAdapter aeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
                    GD2C2015DataSet.AeronaveDataTable aeroData = aeronaveAdapter.AeronavesFueraServicio(rangoInicio, rangoFin);
                    //Borrar columnas que no se interesa mostrar
                    aeroData.Columns.Remove("servicio");
                    aeroData.Columns.Remove("aero_fecha_alta");
                    aeroData.Columns.Remove("aero_kg_disp");
                    aeroData.Columns.Remove("aero_baja_fuera_serv");
                    aeroData.Columns.Remove("aero_baja_vida_util");
                    aeroData.Columns.Remove("aero_fecha_baja_def");
                    aeroData.Columns.Remove("aero_fecha_fuera_serv");
                    aeroData.Columns.Remove("aero_fecha_reinicio_serv");
                    listadoGrid.DataSource = aeroData;
                    break;

                case "puntos":
                    GD2C2015DataSetTableAdapters.ClienteTableAdapter clienteAdapter = new GD2C2015DataSetTableAdapters.ClienteTableAdapter();
                    GD2C2015DataSet.ClienteDataTable clienteData = clienteAdapter.MasPuntosAcumulados(rangoInicio, rangoFin);
                    //Borrar columnas que no se interesa mostrar
                    clienteData.Columns.Remove("cliente_dir");
                    clienteData.Columns.Remove("cliente_tel");
                    clienteData.Columns.Remove("cliente_fecha_nac");
                    clienteData.Columns.Remove("rol_id");
                    listadoGrid.DataSource = clienteData;
                    break;
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.SeleccionarListado a = new Listado_Estadistico.SeleccionarListado();
            a.Show();
            this.Close();
        }

    }
}
