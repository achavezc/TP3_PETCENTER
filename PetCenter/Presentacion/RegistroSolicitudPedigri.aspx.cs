using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Entidades;
using PetCenter.Negocio;
using PetCenter.Presentacion.Constantes;

namespace PetCenter.Presentacion
{
    public partial class RegistroSolicitudPedigri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Inicializar();               
            }
            
        }

        protected void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCliente.aspx");
        }

        protected void btn_buscarPadre_Click(object sender, EventArgs e)
        {
            Session["genero_mascota"] = Constantes.Constantes.GENERO_MACHO;
            Session["edad_mascota"] = Constantes.Constantes.EDAD;

            Response.Redirect("BuscarMascota.aspx");
        }

        protected void btn_buscarMadre_Click(object sender, EventArgs e)
        {
            Session["genero_mascota"] = Constantes.Constantes.GENERO_HEMBRA;
            Session["edad_mascota"] = Constantes.Constantes.EDAD;

            Response.Redirect("BuscarMascota.aspx");
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaSolicitud.aspx");
        }

        #region Metodos Privados

        private void Inicializar()
        {
            AsignarDatosClientes();
            AsignarDatosMascotaPadre();
            AsignarDatosMascotaMadre();
            AsignarDatosCamada();
        }

        private void AsignarDatosClientes()
        {
            var cliente = (Cliente)Session["solicitud_cliente"];
            
            if (Session["solicitud_cliente"] != null)
            {
                txt_nombreCliente.Text = cliente.nombres;
                txt_ApellidoPaterno.Text = cliente.apellido_paterno;
                txt_ApellidoMaterno.Text = cliente.apellido_materno;
                txt_Direccion.Text = cliente.direccion;
            }
        }

        private void AsignarDatosMascotaPadre()
        {
            var mascotaMacho = (Mascota)Session["mascota_macho"];
            
            if (mascotaMacho != null)
            {
                txt_PadreMascota.Text = mascotaMacho.nombre_mascota;
                txt_razaPadre.Text = mascotaMacho.descripcion_raza;
                txt_edadPadre.Text = mascotaMacho.edad;
            }
        }

        private void AsignarDatosMascotaMadre()
        {
            var mascotaHembra = (Mascota)Session["mascota_hembra"];

            if (Session["mascota_hembra"] != null)
            {
                txt_MadreMascota.Text = mascotaHembra.nombre_mascota;
                txt_razaMadre.Text = mascotaHembra.descripcion_raza;
                txt_edadMadre.Text = mascotaHembra.edad;
            }
        }

        private void AsignarDatosCamada()
        {
            var camada = (List<Mascota>)Session["camada"];

            if (camada != null)
            {
                grid_camada.DataSource = camada;
                grid_camada.DataBind();
            }
        }

        #endregion

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            SolicitudPedigri solicitud = new SolicitudPedigri();

            if (Session["solicitud_cliente"] != null)
                solicitud.cliente = (Cliente)Session["solicitud_cliente"];

            if (Session["mascota_macho"] != null)
                solicitud.mascota_padre = (Mascota)Session["mascota_macho"];

            if (Session["mascota_hembra"] != null)
                solicitud.mascota_madre = (Mascota)Session["mascota_hembra"];

            if (Session["camada"] != null)
                solicitud.camada_cachorros = (List<Mascota>)Session["camada"];

            solicitud.comentarios = txtComentarios.Text;
            solicitud.tipo_solicitud = Constantes.Constantes.TIPO_SOLICITUD_PEDIGRI;
            solicitud.usuario_creacion = new Empleado
            {
                codigo_usuario = Constantes.Constantes.CODUSUARIO_REGISTRO
            };

            BusinessSolicitud business = new BusinessSolicitud();

            if (business.RegistrarSolicitudPedigri(solicitud))
            {
                // Mensaje Solicitud Registrada Correctamente
                Response.Write("<script>alert('El Registro de guardó Correctamente')</script>");
                //Response.Redirect("ConsultaSolicitud.aspx");
            }
            else
            {
                // Mensaje La solicitud no se registro Contactarse con el administrador del sistema
                Response.Write("<script>alert('Error al guardar registro')</script>");
            }
            
        }

        protected void btn_agregar_camada_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarCamada.aspx");
        }

    }
}