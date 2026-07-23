using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class DistritoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<DistritoBO> findAll()
        {
            List<DistritoBO> lista = new List<DistritoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistritoTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"]);

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

        public List<DistritoBO> findAllCustom()
        {
            List<DistritoBO> lista = new List<DistritoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistrito";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"]);

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

        public bool add(DistritoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
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

        public DistritoBO findById(int id)
        {
            DistritoBO obj = new DistritoBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarDistritoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"]);
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

        public bool update(DistritoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
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
                cmd.CommandText = "SP_EliminarDistrito";
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
                cmd.CommandText = "SP_HabilitarDistrito";
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
                cmd.CommandText = "SP_CodigoDistrito";
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