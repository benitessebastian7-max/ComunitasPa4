using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class LibroAutorDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<LibroAutorBO> findAll()
        {
            List<LibroAutorBO> lista = new List<LibroAutorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarLibroAutorTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LibroAutorBO obj = new LibroAutorBO();

                    obj.codigo = Convert.ToInt32(dr["idlibroautor"]);
                    obj.estado = Convert.ToBoolean(dr["estlibroautor"]);

                    obj.autor = new AutorBO();
                    obj.autor.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.autor.nombre = dr["nomautor"].ToString();

                    obj.producto = new ProductoBO();
                    obj.producto.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.producto.titulo = dr["titprod"].ToString();

                    lista.Add(obj);
                }

                return lista;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (dr != null) dr.Close();
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public List<LibroAutorBO> findAllCustom()
        {
            List<LibroAutorBO> lista = new List<LibroAutorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarLibroAutor";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LibroAutorBO obj = new LibroAutorBO();

                    obj.codigo = Convert.ToInt32(dr["idlibroautor"]);
                    obj.estado = Convert.ToBoolean(dr["estlibroautor"]);

                    obj.autor = new AutorBO();
                    obj.autor.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.autor.nombre = dr["nomautor"].ToString();

                    obj.producto = new ProductoBO();
                    obj.producto.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.producto.titulo = dr["titprod"].ToString();

                    lista.Add(obj);
                }

                return lista;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (dr != null) dr.Close();
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public bool add(LibroAutorBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarLibroAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@idautor", obj.autor.codigo);
                cmd.Parameters.AddWithValue("@idprod", obj.producto.codigo);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                res = cmd.ExecuteNonQuery();

                return res == 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public LibroAutorBO findById(int id)
        {
            LibroAutorBO obj = new LibroAutorBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarLibroAutorXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idlibroautor"]);
                    obj.estado = Convert.ToBoolean(dr["estlibroautor"]);

                    obj.autor = new AutorBO();
                    obj.autor.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.autor.nombre = dr["nomautor"].ToString();

                    obj.producto = new ProductoBO();
                    obj.producto.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.producto.titulo = dr["titprod"].ToString();
                }

                return obj;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (dr != null) dr.Close();
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public bool update(LibroAutorBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarLibroAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@idautor", obj.autor.codigo);
                cmd.Parameters.AddWithValue("@idprod", obj.producto.codigo);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                res = cmd.ExecuteNonQuery();

                return res == 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarLibroAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                res = cmd.ExecuteNonQuery();

                return res == 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarLibroAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                res = cmd.ExecuteNonQuery();

                return res == 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public int setCode()
        {
            int code = 0;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoLibroAutor";
                cmd.Connection = objconexion.Conectar();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    code = Convert.ToInt32(result);
                }

                return code;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }
    }
}