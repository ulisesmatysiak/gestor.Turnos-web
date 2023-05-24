using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class ServicioNegocio
    {
        public List<Servicio> listar()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Corte from SERVICIO");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Servicio aux = new Servicio();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Corte = (string)datos.Lector["Corte"];                   

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Servicio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into SERVICIO(Corte) values(@Corte)");
                datos.setearParametro("@Corte", nuevo.Corte);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //public void modificar(Servicio servicio)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("update SERVICIO set Corte = @Corte where Id = @Id");
        //        datos.setearParametro("@Corte", servicio.Id);
        //        datos.setearParametro("@Id", servicio.Id);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public void eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from SERVICIO where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
