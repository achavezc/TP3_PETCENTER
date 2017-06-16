using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Entidades;
using PetCenter.Negocio;
using System.Data;

namespace PetCenter.Presentacion.NewFolder1
{
    public partial class RegistroSolicitudAdopcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarRazas();
                txt_fec_ini.Value = "01/01/" + DateTime.Now.Date.Year;
                txt_fechafin.Value = "" + +DateTime.Now.Date.Day + "/" + +DateTime.Now.Date.Month + "/" + DateTime.Now.Date.Year;
                grid_Solicitudes.DataSource = null;
                grid_Solicitudes.DataBind();
            }
        }

        private void ListarRazas()
        {
            BusinessSolicitud business = new BusinessSolicitud();

            DataTable dt = business.ObtenerRazas(0, string.Empty);

            DataRow dr = dt.NewRow();
            dr["codigo_raza"] = "0";
            dr["nombreRaza"] = "--Todos--";
            //dt.Rows.Add(dr);

            dt.Rows.InsertAt(dr, 0);

            ddl_raza.DataSource = dt;
            ddl_raza.DataValueField = "codigo_raza";
            ddl_raza.DataTextField = "nombreRaza";
            ddl_raza.DataBind();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            SolicitudAdopcion filtro = new SolicitudAdopcion();
            Cliente cliente = new Cliente();
            Mascota mascota = new Mascota();

            cliente.nombres = txt_nombre_cliente.Value;
            mascota.nombre_mascota = txt_nombre_mascota.Value;
            mascota.codigo_raza = int.Parse(ddl_raza.Text);

            filtro.numero_solicitud = int.Parse(txt_numero.Value == "" ? "0" : txt_numero.Value);
            filtro.cliente = cliente;
            filtro.numero_documento = txt_dni.Value;
            filtro.mascota = mascota;
            filtro.fecha_inicial = DateTime.Parse(txt_fec_ini.Value);
            filtro.fecha_final = DateTime.Parse(txt_fechafin.Value); 

            BusinessSolicitud business = new BusinessSolicitud();

            DataTable dt = business.ConsultarSolicitudesAdopcion(filtro);

            grid_Solicitudes.DataSource = dt;
            grid_Solicitudes.DataBind();
        }

        protected void grid_Clientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

    }
}