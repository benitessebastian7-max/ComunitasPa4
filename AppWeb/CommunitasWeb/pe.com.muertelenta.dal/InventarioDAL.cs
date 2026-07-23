using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class InventarioDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<InventarioBO> findAll()
        {
            List<InventarioBO> lista = new List<InventarioBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarInventarioTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InventarioBO obj = new InventarioBO();

                    obj.codigo = Convert.ToInt32(dr["idinv"]);
                    obj.stockdisponible = Convert.ToInt32(dr["stockdis"]);
                    obj.stockminimo = Convert.ToInt32(dr["stockmin"]);
                    obj.fechaactualizacion = Convert.ToDateTime(dr["fecact"]);
                    obj.estado = Convert.ToBoolean(dr["estinv"]);

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

        public List<InventarioBO> findAllCustom()
        {
            List<InventarioBO> lista = new List<InventarioBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarInventario";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InventarioBO obj = new InventarioBO();

                    obj.codigo = Convert.ToInt32(dr["idinv"]);
                    obj.stockdisponible = Convert.ToInt32(dr["stockdis"]);
                    obj.stockminimo = Convert.ToInt32(dr["stockmin"]);
                    obj.fechaactualizacion = Convert.ToDateTime(dr["fecact"]);
                    obj.estado = Convert.ToBoolean(dr["estinv"]);

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

        public bool add(InventarioBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarInventario";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@idprod", obj.producto.codigo);
                cmd.Parameters.AddWithValue("@stockdis", obj.stockdisponible);
                cmd.Parameters.AddWithValue("@stockmin", obj.stockminimo);
                cmd.Parameters.AddWithValue("@fechaact", obj.fechaactualizacion);
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

        public InventarioBO findById(int id)
        {
            InventarioBO obj = new InventarioBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarInventarioXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idinv"]);
                    obj.stockdisponible = Convert.ToInt32(dr["stockdis"]);
                    obj.stockminimo = Convert.ToInt32(dr["stockmin"]);
                    obj.fechaactualizacion = Convert.ToDateTime(dr["fecact"]);
                    obj.estado = Convert.ToBoolean(dr["estinv"]);

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

        public bool update(InventarioBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarInventario";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@idprod", obj.producto.codigo);
                cmd.Parameters.AddWithValue("@stockdis", obj.stockdisponible);
                cmd.Parameters.AddWithValue("@stockmin", obj.stockminimo);
                cmd.Parameters.AddWithValue("@fechaact", obj.fechaactualizacion);
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
                cmd.CommandText = "SP_EliminarInventario";
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
                cmd.CommandText = "SP_HabilitarInventario";
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
                cmd.CommandText = "SP_CodigoInventario";
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