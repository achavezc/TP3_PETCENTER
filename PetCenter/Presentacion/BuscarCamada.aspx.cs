using PetCenter.Entidades;
using PetCenter.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetCenter.Presentacion
{
    public partial class BuscarCamada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            BusinessSolicitud business = new BusinessSolicitud();
            Mascota filtro = new Mascota();

            var cliente = (Cliente)Session["solicitud_cliente"];

            if (cliente != null)
                filtro.codigo_cliente = cliente.codigo_cliente;       

            var edadMayorIgual = Session["edad_mascota"];

            if (edadMayorIgual != null)


                if (!string.IsNullOrEmpty(edadMayorIgual.ToString()))
                    filtro.edad = edadMayorIgual.ToString();
                else
                    filtro.edad = string.Empty;

            filtro.nombre_mascota = txt_BuscaNombre.Text;
            filtro.genero = ddlGenero.SelectedValue;
            filtro.descripcion_raza = ddl_raza.SelectedItem.Text;


            DataTable dt = business.ObtenerMascotas(filtro);

            grid_Camada.DataSource = dt;
            grid_Camada.DataBind();

        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Mascota filtro = new Mascota();
            var rows = grid_Camada.Rows;
            var lista_mascotas = new List<Mascota>();
            int seleccionadas = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                CheckBox chk = (CheckBox)rows[i].Cells[0].FindControl("chkSelecion");
                

                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        seleccionadas++;

                        var row = rows[i];
                        
                        
                        //string fNacimiento = Convert.ToString(filtro.fecha_nacimiento);
                        lista_mascotas.Add(new Mascota
                        {
                           
                            codigo_mascota = Convert.ToInt32(grid_Camada.DataKeys[i].Values["codigo_mascota"].ToString()),
                            nombre_mascota = row.Cells[2].Text,                            
                            descripcion_raza = row.Cells[8].Text,
                            edad = row.Cells[9].Text,
                            edadDias = Convert.ToInt32(row.Cells[10].Text)
                        });
                 
                    } 
                }
            } 

            if (seleccionadas == 0)
            {
                Response.Write("Por favor seleccionar por lo menos una mascota");
                return;
            }
            else
            {

                Session.Remove("camada");
                Session["camada"] = lista_mascotas;
                Label1.Text = Convert.ToString(filtro.edadDias);
            }

            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }

        #region 

        private void Inicializar()
        {
            ListarRazas();
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

        #endregion
    }
}