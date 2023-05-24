using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select T.Id, T.Fecha, T.Cliente, S.Corte, A.Nombre, T.Importe from AUTOR A, SERVICIO S, TURNOS T where T.IdServicio = S.Id and T.IdAutor = A.Id order by Fecha asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Cliente = (string)datos.Lector["Cliente"];
                    aux.Servicio = new Servicio();
                    aux.Servicio.Id = (int)datos.Lector["Id"];
                    aux.Servicio.Corte = (string)datos.Lector["Corte"];
                    aux.Autor = new Autor();
                    aux.Autor.Id = (int)datos.Lector["Id"];
                    aux.Autor.Nombre = (string)datos.Lector["Nombre"];
                    aux.Importe = (decimal)datos.Lector["Importe"];

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

        public void agregar(Turno nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into TURNOS(Fecha,Cliente,IdServicio,IdAutor,Importe) values (@Fecha,@Cliente,@IdServicio,@IdAutor,@Importe)");
                datos.setearParametro("@Fecha", nuevo.Fecha);
                datos.setearParametro("@Cliente", nuevo.Cliente);
                datos.setearParametro("@IdServicio", nuevo.Servicio.Id);
                datos.setearParametro("@IdAutor", nuevo.Autor.Id);
                datos.setearParametro("@Importe", nuevo.Importe);
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

        public void modificar(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update TURNOS set Fecha = @Fecha, Cliente = @Cliente, IdServicio = @IdServicio, IdAutor = @IdAutor, Importe = @Importe where Id = @Id");
                datos.setearParametro("@Fecha", turno.Fecha);
                datos.setearParametro("@Cliente", turno.Cliente);
                datos.setearParametro("@IdServicio", turno.Servicio.Id);
                datos.setearParametro("@IdAutor", turno.Autor.Id);
                datos.setearParametro("@Importe", turno.Importe);
                datos.setearParametro("@Id", turno.Id);
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

        public void eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from TURNOS where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Turno> listarHoy()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select T.Id, T.Fecha, T.Cliente, S.Corte, A.Nombre, T.Importe from AUTOR A, SERVICIO S, TURNOS T where T.IdServicio = S.Id and T.IdAutor = A.Id and DATEDIFF(day,FECHA,GETDATE())=0 order by Fecha asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Cliente = (string)datos.Lector["Cliente"];
                    aux.Servicio = new Servicio();
                    aux.Servicio.Id = (int)datos.Lector["Id"];
                    aux.Servicio.Corte = (string)datos.Lector["Corte"];
                    aux.Autor = new Autor();
                    aux.Autor.Id = (int)datos.Lector["Id"];
                    aux.Autor.Nombre = (string)datos.Lector["Nombre"];
                    aux.Importe = (decimal)datos.Lector["Importe"];

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

        public List<Turno> listarSemana()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT T.Id, T.Fecha, T.Cliente, S.Corte, A.Nombre, T.Importe FROM AUTOR A, SERVICIO S, TURNOS T WHERE T.IdServicio = S.Id AND T.IdAutor = A.Id and t.Fecha >= DATEADD(wk,(DATEDIFF(wk,0,GETDATE()-1)),0) and t.Fecha <= DATEADD(ms,-3,(DATEADD(wk,DATEDIFF(wk,0,GETDATE()-1),7))) ORDER BY T.Fecha ASC ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Cliente = (string)datos.Lector["Cliente"];
                    aux.Servicio = new Servicio();
                    aux.Servicio.Id = (int)datos.Lector["Id"];
                    aux.Servicio.Corte = (string)datos.Lector["Corte"];
                    aux.Autor = new Autor();
                    aux.Autor.Id = (int)datos.Lector["Id"];
                    aux.Autor.Nombre = (string)datos.Lector["Nombre"];
                    aux.Importe = (decimal)datos.Lector["Importe"];

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
    }
}
