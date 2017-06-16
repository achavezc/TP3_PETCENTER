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
    public partial class BuscarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {

            BusinessSolicitud business = new BusinessSolicitud();
            Mascota filtro = new Mascota();
            
            var cliente = (Cliente)Session["solicitud_cliente"];
            
            if (cliente != null)
                filtro.codigo_cliente = cliente.codigo_cliente;

            var genero = Session["genero_mascota"];

            if (genero != null)
                if (!string.IsNullOrEmpty(genero.ToString()))
                    filtro.genero = genero.ToString();
                else
                    filtro.genero = string.Empty;

            var edadMayorIgual = Session["edad_mascota"];

            if (edadMayorIgual != null)
                if (!string.IsNullOrEmpty(edadMayorIgual.ToString()))
                    filtro.edad = edadMayorIgual.ToString();
                else
                    filtro.edad = string.Empty;
            
            filtro.nombre_mascota = txt_BuscaNombre.Text;
            filtro.descripcion_raza = ddl_raza.SelectedItem.Text;

            DataTable dt = business.ObtenerMascotas(filtro);

            grid_Mascotas.DataSource = dt;
            grid_Mascotas.DataBind();
                                   
        }

        private void Inicializar()
        {
            ListarRazas();
        }

        private void ListarRazas(){
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

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            var rows = grid_Mascotas.Rows;
            var genero_mascota = Session["genero_mascota"].ToString();

            for (int i = 0; i < rows.Count; i++)
            {
                RadioButton rb = (RadioButton)rows[i].Cells[0].FindControl("rbSeleccion");

                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        var row = rows[i];

                        Mascota mascota = new Mascota
                        {
                            codigo_mascota = Convert.ToInt32(grid_Mascotas.DataKeys[i].Values["codigo_mascota"].ToString()),
                            nombre_mascota = row.Cells[2].Text,
                            descripcion_raza = row.Cells[8].Text,
                            edad = row.Cells[9].Text
                        };

                        if (genero_mascota.Equals(Constantes.Constantes.GENERO_MACHO))
                        {
                            Session.Remove("mascota_macho");
                            Session.Add("mascota_macho", mascota);
                        }
                        else
                        {
                            if (genero_mascota.Equals(Constantes.Constantes.GENERO_HEMBRA))
                            {
                                Session.Remove("mascota_hembra");
                                Session.Add("mascota_hembra", mascota);
                            }

                        }
                        break;
                    }
                }
            }
            
            Response.Redirect("RegistroSolicitudPedigri.aspx");
        }
    }
}