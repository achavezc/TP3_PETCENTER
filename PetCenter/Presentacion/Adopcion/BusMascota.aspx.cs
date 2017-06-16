using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Entidades;
using PetCenter.Negocio;
using System.Data;

namespace PetCenter.Presentacion.Adopcion
{
    public partial class BusMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ListarRazas();
                grid_Mascotas.DataSource = null;
                grid_Mascotas.DataBind();
            }
        }

        private void ListarRazas()
        {
            BusinessSolicitud business = new BusinessSolicitud();

            DataTable dt = business.ObtenerRazas(0, string.Empty);

            DataRow dr = dt.NewRow();
            dr["codigo_raza"] = "0";
            dr["nombreRaza"] = "";
            //dt.Rows.Add(dr);

            dt.Rows.InsertAt(dr, 0);

            ddl_raza.DataSource = dt;
            ddl_raza.DataValueField = "codigo_raza";
            ddl_raza.DataTextField = "nombreRaza";
            ddl_raza.DataBind();
        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {

            BusinessSolicitud business = new BusinessSolicitud();
            Mascota filtro = new Mascota();

            
            filtro.codigo_cliente = 0;
            filtro.genero = "";
            filtro.edad = "";

            filtro.nombre_mascota = txt_nombre.Value;
            filtro.descripcion_raza = ddl_raza.SelectedItem.Text;

            DataTable dt = business.ObtenerMascotas(filtro);

            grid_Mascotas.DataSource = dt;
            grid_Mascotas.DataBind();

        }

        protected void grid_Clientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "top.top.fnCerrarDivConsulta3_parametro('" + e.Row.Cells[1].Text + "','" + e.Row.Cells[3].Text + "','" + e.Row.Cells[4].Text + "','" + e.Row.Cells[0].Text + "','" + " " + "','" + "MASCOTA" + "')");

            }    
        }
    }
}