using PetCenter.Datos;
using PetCenter.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PetCenter.Negocio
{
    public class BusinessSolicitud
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(BusinessSolicitud));
        private DaoSolicitud daoSolicitud;

        #region Clientes
        
        public DataTable ObtenerClientes(Cliente filtro)
        {            
            try
            {
                daoSolicitud = new DaoSolicitud();
                
                return daoSolicitud.ObtenerClientes(filtro);
            }
            catch (Exception ex)
            {
                //log.Info("Error en el metodo ObtenerClientes", ex);
                //return daoSolicitud.ObtenerClientes(nombres, apPaterno, apMaterno, tipoDoc, numDoc); 
                return new DataTable();
            }
            finally
            {
                daoSolicitud = null;
            }
        }

        #endregion

        #region Mascotas

        public DataTable ObtenerRazas(int codEspecie, string nombreRaza)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.ObtenerRazas(codEspecie, nombreRaza);
            }
            catch (Exception ex)
            {
                //log.Info("Error en el metodo ObtenerMascotas", ex);
                return new DataTable();
            }
            finally
            {
                daoSolicitud = null;
            }
        }

        public DataTable ObtenerMascotas(Mascota mascota)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.ObtenerMascotas(mascota);
            }
            catch (Exception ex)
            {
                //log.Info("Error en el metodo ObtenerMascotas", ex);
                return new DataTable();
            }
            finally
            {
                daoSolicitud = null;
            }
        }

        #endregion

        #region Solicitudes

        public DataTable ConsultarSolicitudes(SolicitudPedigri filtro)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.ConsultarSolicitudes(filtro);
            }
            catch (Exception ex)
            {
                //log.Info("Error en el metodo ObtenerMascotas", ex);
                return new DataTable();  //daoSolicitud.ObtenerMascotas(codCliente, genero, nombreMascota, nombreRaza);
            }
            finally
            {
                daoSolicitud = null;
            }
        }

        public bool RegistrarSolicitudPedigri(SolicitudPedigri solicitud)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.RegistrarSolicitudPedigri(solicitud);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RegistrarSolicitudAdopcion(SolicitudAdopcion solicitud)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.RegistrarSolicitudAdopcion(solicitud);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ConsultarSolicitudesAdopcion(SolicitudAdopcion filtro)
        {
            try
            {
                daoSolicitud = new DaoSolicitud();

                return daoSolicitud.ConsultarSolicitudesAdopcion(filtro);
            }
            catch (Exception ex)
            {
                //log.Info("Error en el metodo ObtenerMascotas", ex);
                return new DataTable();  //daoSolicitud.ObtenerMascotas(codCliente, genero, nombreMascota, nombreRaza);
            }
            finally
            {
                daoSolicitud = null;
            }
        }

        #endregion

    }
}