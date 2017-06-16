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
    public partial class BusCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                grid_Clientes.DataSource = null;
                grid_Clientes.DataBind();
            }
        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {
            //txt_dni.Value == "" ? "1" : txt_dni.Value; 

            BusinessSolicitud business = new BusinessSolicitud();
            Cliente filtro = new Cliente();

            filtro.nombres = txt_nom.Value;
            filtro.apellido_paterno = txt_pat.Value;
            filtro.apellido_materno = txt_mat.Value; 
            filtro.codigo_tipo_documento = 0;
            filtro.numero_documento = txt_dni.Value; 

            //grid_Clientes.DataSource = clientes.ObtenerClientes(datosCliente.nombres, datosCliente.apellido_paterno, datosCliente.apellido_materno, datosCliente.codigo_tipo_documento, datosCliente.numero_documento);

            DataTable dt = business.ObtenerClientes(filtro);

            if (dt.Rows.Count>0)
            { 
            grid_Clientes.DataSource = dt;            
            grid_Clientes.DataBind();
            grid_Clientes.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grid_Clientes.DataSource = null;
                grid_Clientes.DataBind();
                Response.Write("<script>alert('El Cliente no existe')</script>");
            }
        
        }

        protected void grid_Clientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.Attributes.Add("onclick", "top.top.fnCerrarDivConsulta3_parametro('" + e.Row.Cells[4].Text + "','" + e.Row.Cells[3].Text + "','" + e.Row.Cells[1].Text + " " + e.Row.Cells[2].Text + "','" + e.Row.Cells[0].Text + "','" + " " + "','" + "CLIENTE" + "')");
            }            
            
        }
       
    }
}