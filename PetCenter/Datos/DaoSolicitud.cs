using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
//using log4net;
using System.Web;
using PetCenter.Entidades;
using PetCenter.Datos;
using System.Data;
using System.Configuration;


namespace PetCenter.Datos
{
    public class DaoSolicitud
    {
        //private string cadenaCnx = "Data source=(local); Initial catalog=PETCENTER; Integrated Security=SSPI";
        private string cadenaCnx = @"Data Source=ETAIPE_12PYC\SQLEXPRESS64;Database=PETCENTER;User Id=sa; Password=123456";
                
        #region Clientes

        public DataTable ObtenerClientes(Cliente filtro)
        {
            using (SqlConnection conn = new SqlConnection(cadenaCnx))
            {
                //conn.ConnectionString = cadenaCnx;
                using (SqlCommand command = new SqlCommand("sp_ObtenerClientes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //Envió los parámetros que necesito
                        SqlParameter param1 = new SqlParameter("@nombres", SqlDbType.VarChar);
                        SqlParameter param2 = new SqlParameter("@apellidoPaterno", SqlDbType.VarChar);
                        SqlParameter param3 = new SqlParameter("@apellidoMaterno", SqlDbType.VarChar);
                        SqlParameter param4 = new SqlParameter("@tipoDocumento", SqlDbType.Char);
                        SqlParameter param5 = new SqlParameter("@numeroDocumento", SqlDbType.VarChar);
                        param1.Value = filtro.nombres;
                        param2.Value = filtro.apellido_paterno;
                        param3.Value = filtro.apellido_materno;
                        param4.Value = filtro.codigo_tipo_documento;
                        param5.Value = filtro.numero_documento;

                        command.Parameters.Add(param1);
                        command.Parameters.Add(param2);
                        command.Parameters.Add(param3);
                        command.Parameters.Add(param4);
                        command.Parameters.Add(param5);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            conn.Open();
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion

        #region Mascotas

        public DataTable ObtenerMascotas(Mascota filtro)
        {
            using (SqlConnection conn = new SqlConnection(cadenaCnx))
            {
                //conn.ConnectionString = cadenaCnx; //args;
                using (SqlCommand command = new SqlCommand("sp_ObtenerMascotas", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //Envió los parámetros que necesito
                        SqlParameter param1 = new SqlParameter("@codigo_cliente", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@genero", SqlDbType.VarChar);
                        SqlParameter param3 = new SqlParameter("@nombreMascota", SqlDbType.VarChar);
                        SqlParameter param4 = new SqlParameter("@nombreRaza", SqlDbType.Char);
                        SqlParameter param5 = new SqlParameter("@EdadMayorIgual", SqlDbType.VarChar);
                        SqlParameter param6 = new SqlParameter("@EdadDias", SqlDbType.VarChar);

                        param1.Value = filtro.codigo_cliente;
                        param2.Value = filtro.genero;
                        param3.Value = filtro.nombre_mascota;
                        param4.Value = filtro.descripcion_raza;
                        param5.Value = filtro.edad;
                        param6.Value = filtro.edadDias;

                        command.Parameters.Add(param1);
                        command.Parameters.Add(param2);
                        command.Parameters.Add(param3);
                        command.Parameters.Add(param4);
                        command.Parameters.Add(param5);
                        command.Parameters.Add(param6);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            conn.Open();
                            return dt;
                        }
                    }
                }
            }
        }
        
        public DataTable ObtenerRazas(int codEspecie, string nombreRaza)
        {
            using (SqlConnection conn = new SqlConnection(cadenaCnx))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerRazas", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //Envió los parámetros que necesito
                        SqlParameter param1 = new SqlParameter("@codigo_especie", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@nombreRaza", SqlDbType.VarChar);

                        param1.Value = codEspecie;
                        param2.Value = nombreRaza;

                        command.Parameters.Add(param1);
                        command.Parameters.Add(param2);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            conn.Open();
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion

        #region Solicitudes

        public DataTable ConsultarSolicitudes(SolicitudPedigri filtro)
        {
            
            using (SqlConnection conn = new SqlConnection(cadenaCnx))
            {
                //conn.ConnectionString = cadenaCnx;                

                using (SqlCommand cmd = new SqlCommand("sp_ConsultarSolicitud", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        //Envió los parámetros que necesito
                        SqlParameter param1 = new SqlParameter("@numero_solicitud", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@nombres", SqlDbType.VarChar);
                        //SqlParameter param3 = new SqlParameter("@apePaterno", SqlDbType.VarChar);
                        //SqlParameter param4 = new SqlParameter("@apeMaterno", SqlDbType.VarChar);

                        param1.Value = filtro.numero_solicitud;
                        param2.Value = filtro.cliente.nombres;
                        //param3.Value = filtro.cliente.apellido_paterno;
                        //param4.Value = filtro.cliente.apellido_materno;

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        //cmd.Parameters.Add(param3);
                        //cmd.Parameters.Add(param4);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            conn.Open();
                            return dt;
                        }
                    }
                }
            }
        }

        public bool RegistrarSolicitudPedigri(SolicitudPedigri solicitud)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cadenaCnx))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarSolicitud", cnx))
                    {
                        cnx.Open();
                        //SqlTransaction transaccion = cnx.BeginTransaction();

                        //cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param1 = new SqlParameter("@codigo_cliente", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@codigo_mascota_padre", SqlDbType.Int);
                        SqlParameter param3 = new SqlParameter("@codigo_mascota_madre", SqlDbType.Int);
                        SqlParameter param4 = new SqlParameter("@comentarios", SqlDbType.VarChar);
                        SqlParameter param5 = new SqlParameter("@tipoSolicitud", SqlDbType.Char);
                        SqlParameter param6 = new SqlParameter("@UsuarioCreacion", SqlDbType.Int);
                        SqlParameter param7 = new SqlParameter("@codigo_solicitud", SqlDbType.Int);

                        param1.Value = solicitud.cliente.codigo_cliente;
                        param2.Value = solicitud.mascota_padre.codigo_mascota;
                        param3.Value = solicitud.mascota_madre.codigo_mascota;
                        param4.Value = solicitud.comentarios;
                        param5.Value = solicitud.tipo_solicitud;
                        param6.Value = solicitud.usuario_creacion.codigo_usuario;
                        param7.Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);
                        cmd.Parameters.Add(param5);
                        cmd.Parameters.Add(param6);
                        cmd.Parameters.Add(param7);
                                                
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            int codigo_solicitud = Convert.ToInt32(cmd.Parameters["@codigo_solicitud"].Value.ToString());

                            foreach (var mascota in solicitud.camada_cachorros)
                            {
                                RegistrarCamada(codigo_solicitud, mascota.codigo_mascota, cnx);
                            }

                            //transaccion.Commit();

                            return true;
                        }
                        else
                        {
                            //transaccion.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
            
        }

        private void RegistrarCamada(int codigo_solicitud, int codigo_mascota, SqlConnection cnx)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarCamada", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter param1 = new SqlParameter("@codigo_solicitud_pedigri", SqlDbType.Int);
                    SqlParameter param2 = new SqlParameter("@codigo_mascota", SqlDbType.Int);
                    
                    param1.Value = codigo_solicitud;
                    param2.Value = codigo_mascota;
                    
                    cmd.Parameters.Add(param1);
                    

                    cmd.Parameters.Add(param2);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool RegistrarSolicitudAdopcion(SolicitudAdopcion solicitud)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cadenaCnx))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarSolicitudAdopcion", cnx))
                    {
                        cnx.Open();
                        //SqlTransaction transaccion = cnx.BeginTransaction();

                        //cmd.Transaction = transaccion;
                        cmd.CommandType = CommandType.StoredProcedure;
                                        
	
                        SqlParameter param1 = new SqlParameter("@codigo_cliente", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@codigo_mascota", SqlDbType.Int);
                        SqlParameter param3 = new SqlParameter("@comentarios", SqlDbType.VarChar);
                        SqlParameter param4 = new SqlParameter("@tipoSolicitud", SqlDbType.VarChar);                        
                        SqlParameter param5 = new SqlParameter("@UsuarioCreacion", SqlDbType.Int);
                        SqlParameter param6 = new SqlParameter("@codigo_solicitud", SqlDbType.Int);

                        param1.Value = solicitud.cliente.codigo_cliente;
                        param2.Value = solicitud.mascota.codigo_mascota;
                        param3.Value = solicitud.comentarios;
                        param4.Value = solicitud.tipo_solicitud;
                        param5.Value = solicitud.UsuarioCreacion;
                        param6.Direction = ParameterDirection.Output;                        

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);
                        cmd.Parameters.Add(param5);
                        cmd.Parameters.Add(param6);                        

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            int codigo_solicitud = Convert.ToInt32(cmd.Parameters["@codigo_solicitud"].Value.ToString());
                            
                            //transaccion.Commit();

                            return true;
                        }
                        else
                        {
                            //transaccion.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public DataTable ConsultarSolicitudesAdopcion(SolicitudAdopcion filtro)
        {

            using (SqlConnection conn = new SqlConnection(cadenaCnx))
            {
                //conn.ConnectionString = cadenaCnx;                

                using (SqlCommand cmd = new SqlCommand("sp_ConsultarSolicitudAdopcion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        //Envió los parámetros que necesito
                        SqlParameter param1 = new SqlParameter("@numero_solicitud", SqlDbType.Int);
                        SqlParameter param2 = new SqlParameter("@apellidos", SqlDbType.VarChar);                        
                        SqlParameter param3 = new SqlParameter("@numeroDocumento", SqlDbType.VarChar);
                        SqlParameter param4 = new SqlParameter("@nombre_mascota", SqlDbType.VarChar);
                        SqlParameter param5 = new SqlParameter("@codigo_raza", SqlDbType.Int);
                        SqlParameter param6 = new SqlParameter("@fechaInicial", SqlDbType.Date);
                        SqlParameter param7 = new SqlParameter("@fechaFinal", SqlDbType.Date);


                        param1.Value = filtro.numero_solicitud;
                        param2.Value = filtro.cliente.nombres;
                        param3.Value = filtro.numero_documento;
                        param4.Value = filtro.mascota.nombre_mascota;
                        param5.Value = filtro.mascota.codigo_raza;
                        param6.Value = filtro.fecha_inicial;
                        param7.Value = filtro.fecha_final;

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);
                        cmd.Parameters.Add(param5);
                        cmd.Parameters.Add(param6);
                        cmd.Parameters.Add(param7);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            conn.Open();
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion
    }
}