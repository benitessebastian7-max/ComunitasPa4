using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class AutorDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<AutorBO> findAll()
        {
            List<AutorBO> lista = new List<AutorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarAutorTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AutorBO obj = new AutorBO();

                    obj.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.nombre = dr["nomautor"].ToString();
                    obj.apellidopaterno = dr["apepautor"].ToString();
                    obj.apellidomaterno = dr["apemautor"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estautor"]);

                    obj.pais = new PaisBO();
                    obj.pais.codigo = Convert.ToInt32(dr["idpais"]);
                    obj.pais.nombre = dr["nompais"].ToString();

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

        public List<AutorBO> findAllCustom()
        {
            List<AutorBO> lista = new List<AutorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarAutor";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AutorBO obj = new AutorBO();

                    obj.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.nombre = dr["nomautor"].ToString();
                    obj.apellidopaterno = dr["apepautor"].ToString();
                    obj.apellidomaterno = dr["apemautor"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estautor"]);

                    obj.pais = new PaisBO();
                    obj.pais.codigo = Convert.ToInt32(dr["idpais"]);
                    obj.pais.nombre = dr["nompais"].ToString();

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

        public bool add(AutorBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apep", obj.apellidopaterno);
                cmd.Parameters.AddWithValue("@apem", obj.apellidomaterno);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idpais", obj.pais.codigo);

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

        public AutorBO findById(int id)
        {
            AutorBO obj = new AutorBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarAutorXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idautor"]);
                    obj.nombre = dr["nomautor"].ToString();
                    obj.apellidopaterno = dr["apepautor"].ToString();
                    obj.apellidomaterno = dr["apemautor"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estautor"]);

                    obj.pais = new PaisBO();
                    obj.pais.codigo = Convert.ToInt32(dr["idpais"]);
                    obj.pais.nombre = dr["nompais"].ToString();
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

        public bool update(AutorBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarAutor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apep", obj.apellidopaterno);
                cmd.Parameters.AddWithValue("@apem", obj.apellidomaterno);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idpais", obj.pais.codigo);

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
                cmd.CommandText = "SP_EliminarAutor";
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
                cmd.CommandText = "SP_HabilitarAutor";
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
                cmd.CommandText = "SP_CodigoAutor";
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