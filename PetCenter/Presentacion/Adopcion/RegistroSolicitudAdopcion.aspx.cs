using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCenter.Entidades;
using PetCenter.Negocio;

namespace PetCenter.Presentacion.Adopcion
{
    public partial class RegistroSolicitudAdopcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {

            SolicitudAdopcion solicitud = new SolicitudAdopcion();
            Cliente cliente = new Cliente();
            Mascota mascota = new Mascota();

            if (id_codigo_cliente.Text == "")
            {
                Response.Write("<script>alert('Seleccione el Cliente')</script>");
                return;
            }

            if (id_codigo_mascota.Text == "")
            {
                Response.Write("<script>alert('Seleccione la Mascota')</script>");
                return;
            }

            cliente.codigo_cliente = int.Parse(id_codigo_cliente.Text);
            mascota.codigo_mascota = int.Parse(id_codigo_mascota.Text);

            solicitud.cliente = cliente;
            solicitud.mascota = mascota;
            solicitud.comentarios = "";
            solicitud.tipo_solicitud = Constantes.Constantes.TIPO_SOLICITUD_PEDIGRI;
            solicitud.UsuarioCreacion = Constantes.Constantes.CODUSUARIO_REGISTRO;

            BusinessSolicitud business = new BusinessSolicitud();

            if (business.RegistrarSolicitudAdopcion(solicitud))
            {
                // Mensaje Solicitud Registrada Correctamente
                Response.Write("<script>alert('El Registro de guardó Correctamente');top.fnCerrarDivConsulta3();</script>");
                //Response.Redirect("ConsultaSolicitud.aspx");
            }
            else
            {
                // Mensaje La solicitud no se registro Contactarse con el administrador del sistema
                Response.Write("<script>alert('Error al guardar registro')</script>");
            }
        }
    }
}