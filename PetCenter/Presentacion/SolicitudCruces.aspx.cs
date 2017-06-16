using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetCenter.Presentacion
{
    public partial class SolicitudCruces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCliente.aspx");
        }
    }
}