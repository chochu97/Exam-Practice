using EntityZone;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosZone
{
    public class AplicacionDAO
    {
        public List<AplicacionEntity> GetEntities()
        {
            using(AplicacionContext context = new AplicacionContext())
            {
                try
                {
                    List<Aplicacion> aplicaciones = context.Aplicacion.ToList();

                    return aplicaciones.Select(app => new AplicacionEntity
                    {
                        Id = app.id,
                        Titulo = app.titulo,
                        Descripcion = app.descripcion,
                        Desarrolladora = app.desarrolladora,
                        IdCategoria = app.id_categoria,
                        Precio = app.precio,

                    }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void GuardarApp(AplicacionEntity app)
        {
            using(AplicacionContext context = new AplicacionContext())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Aplicacion api = new Aplicacion();
                        api.titulo = app.Titulo;
                        api.descripcion = app.Descripcion;
                        api.desarrolladora = app.Desarrolladora;
                        api.id_categoria = app.IdCategoria;
                        api.precio = app.Precio;

                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                    
                }
            }
        }

        /* public void ModificarApp(AplicacionEntity app)
        {
            using(SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AplicacionContext"].ConnectionString))
            {
                conexion.Open();
                using(SqlTransaction trans = conexion.BeginTransaction())
                {
                    
                    string query = "UPDATE Aplicacion SET titulo = @titulo, desarrolladora = @desarrolladora WHERE id == @id";

                    using(SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@titulo", app.Titulo);
                        comando.Parameters.AddWithValue("@titulo", app.Titulo);
                        comando.Parameters.AddWithValue("@desarrolladora", app.Desarrolladora);

                        comando.ExecuteNonQuery();
                    }
                }
            }
        }
        */
        public void ModificarApp(AplicacionEntity app)
        {
            using(AplicacionContext context = new AplicacionContext())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Aplicacion api = context.Aplicacion.FirstOrDefault(ap => ap.id == app.Id);
                        
                        api.titulo = app.Titulo;
                        api.descripcion = app.Descripcion;
                        api.desarrolladora = app.Desarrolladora;
                        api.precio = app.Precio;

                        trans.Commit();
                        context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }

        /*
        public void EliminarApp(AplicacionEntity app)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AplicacionContext"].ConnectionString))
            {
                conexion.Open();
                using(SqlTransaction trans = conexion.BeginTransaction())
                {
                    try
                    {
                        string query = "DELETE FROM Aplicacion WHERE Id == @id";

                        using(SqlCommand comando = new SqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", app.Id);
                            comando.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }
        */
                public void EliminarApp(AplicacionEntity app)
        {
            using(AplicacionContext context = new AplicacionContext())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Aplicacion api = context.Aplicacion.FirstOrDefault(ap => ap.id == app.Id);
                        context.Aplicacion.Remove(api);

                        trans.Commit();
                        context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }


    }
}
