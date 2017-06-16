using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Negocio;
using PetCenter.Entidades;
using System.Data;

namespace PetCenter.Presentacion
{
    public partial class BuscarCliente : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            BusinessSolicitud business = new BusinessSolicitud();
            Cliente filtro = new Cliente();

            filtro.nombres = txt_Nombre.Text;
            filtro.apellido_paterno = txt_ApPaterno.Text;
            filtro.apellido_materno = txt_ApMaterno.Text;
            filtro.codigo_tipo_documento = Convert.ToInt32(ddl_tipoDocumento.SelectedItem.Value);
            filtro.numero_documento = txt_numeroDocumento.Text;

            //grid_Clientes.DataSource = clientes.ObtenerClientes(datosCliente.nombres, datosCliente.apellido_paterno, datosCliente.apellido_materno, datosCliente.codigo_tipo_documento, datosCliente.numero_documento);

            DataTable dt = business.ObtenerClientes(filtro);

            if (dt!=null)
            { 
            grid_Clientes.DataSource = dt;
            grid_Clientes.DataBind();
            Response.Write("<script>alert('El Cliente no existe')</script>");
            }
            else
            {
                Response.Write("<script>alert('El Cliente no existe')</script>");
            }
        }


        protected void grid_Clientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void grid_Clientes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {

            var rows = grid_Clientes.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                RadioButton rb = (RadioButton)rows[i].Cells[0].FindControl("rbSeleccion");

                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        var row = rows[i];

                        var cliente = new Cliente {
                            codigo_cliente = Convert.ToInt32(grid_Clientes.DataKeys[i].Values["codigo_cliente"].ToString()),
                            nombres = row.Cells[2].Text,
                            apellido_paterno = row.Cells[3].Text,
                            apellido_materno = row.Cells[4].Text,
                            direccion = row.Cells[8].Text
                        };

                        Session.Remove("solicitud_cliente");
                        Session.Add("solicitud_cliente", cliente);

                        break;
                    }
                }
            }

            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }



    }
}