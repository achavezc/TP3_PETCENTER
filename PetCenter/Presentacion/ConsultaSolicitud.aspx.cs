using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Entidades;
using PetCenter.Negocio;
using System.Data;

namespace PetCenter.Presentacion
{
    public partial class ConsultaSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_crearSolicitud_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }

        protected void btn_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            SolicitudPedigri filtro = new SolicitudPedigri();

            if (!string.IsNullOrEmpty(txt_numSolicitud.Text))
            {
                filtro.numero_solicitud = Convert.ToInt32(txt_numSolicitud.Text);
            }

            filtro.cliente = new Cliente();
            filtro.cliente.nombres = txt_nombres.Text;
            
            BusinessSolicitud business = new BusinessSolicitud();

            DataTable dt = business.ConsultarSolicitudes(filtro);

            grid_Solicitudes.DataSource = dt;
            grid_Solicitudes.DataBind();
        }

        
    }
}