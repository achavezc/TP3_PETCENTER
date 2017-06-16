using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter;

namespace PetCenter.Presentacion
{
    public partial class Solicitud : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void btn_Pedigri_Click(object sender, EventArgs e)
        {
            Response.Redirect(FuncionesUrlString.getPath() + "Presentacion/ConsultaSolicitud.aspx");
        }

        protected void btn_Cruces_Click(object sender, EventArgs e)
        {
            Response.Redirect(FuncionesUrlString.getPath() + "Presentacion/SolicitudCruces.aspx");
        }

        protected void btn_Adopciones_Click(object sender, EventArgs e)
        {
            Response.Redirect( FuncionesUrlString.getPath() + "Presentacion/Adopcion/GestionSolicitudAdopcion.aspx");
        }
    }
}