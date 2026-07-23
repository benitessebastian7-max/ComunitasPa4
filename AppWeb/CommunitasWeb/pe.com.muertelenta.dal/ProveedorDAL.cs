
using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class ProveedorDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<ProveedorBO> findAll()
        {
            List<ProveedorBO> lista = new List<ProveedorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProveedorTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProveedorBO obj = new ProveedorBO();

                    obj.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.razonsocial = dr["razsocprov"].ToString();
                    obj.ruc = dr["rucprov"].ToString();
                    obj.telefono = dr["telfprov"].ToString();
                    obj.correo = dr["corprov"].ToString();
                    obj.direccion = dr["direcprov"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estprov"]);

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

        public List<ProveedorBO> findAllCustom()
        {
            List<ProveedorBO> lista = new List<ProveedorBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProveedor";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProveedorBO obj = new ProveedorBO();

                    obj.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.razonsocial = dr["razsocprov"].ToString();
                    obj.ruc = dr["rucprov"].ToString();
                    obj.telefono = dr["telfprov"].ToString();
                    obj.correo = dr["corprov"].ToString();
                    obj.direccion = dr["direcprov"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estprov"]);

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

        public bool add(ProveedorBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarProveedor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.razonsocial);
                cmd.Parameters.AddWithValue("@ruc", obj.ruc);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@correo", obj.correo);
                cmd.Parameters.AddWithValue("@direccion", obj.direccion);
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

        public ProveedorBO findById(int id)
        {
            ProveedorBO obj = new ProveedorBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarProveedorXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.razonsocial = dr["razsocprov"].ToString();
                    obj.ruc = dr["rucprov"].ToString();
                    obj.telefono = dr["telfprov"].ToString();
                    obj.correo = dr["corprov"].ToString();
                    obj.direccion = dr["direcprov"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estprov"]);
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

        public bool update(ProveedorBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarProveedor";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.razonsocial);
                cmd.Parameters.AddWithValue("@ruc", obj.ruc);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@correo", obj.correo);
                cmd.Parameters.AddWithValue("@direccion", obj.direccion);
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
                cmd.CommandText = "SP_EliminarProveedor";
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
                cmd.CommandText = "SP_HabilitarProveedor";
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
                cmd.CommandText = "SP_CodigoProveedor";
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