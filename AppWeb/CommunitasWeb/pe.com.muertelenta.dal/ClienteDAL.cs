using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class ClienteDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<ClienteBO> findAll()
        {
            List<ClienteBO> lista = new List<ClienteBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarClienteTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();

                    obj.codigo = Convert.ToInt32(dr["idcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidopaterno = dr["apepcli"].ToString();
                    obj.apellidomaterno = dr["apemcli"].ToString();
                    obj.numerodocumento = dr["numdoccli"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnaccli"]);
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.distrito = new DistritoBO();
                    obj.distrito.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.distrito.nombre = dr["nomdis"].ToString();

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

        public List<ClienteBO> findAllCustom()
        {
            List<ClienteBO> lista = new List<ClienteBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarCliente";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();

                    obj.codigo = Convert.ToInt32(dr["idcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidopaterno = dr["apepcli"].ToString();
                    obj.apellidomaterno = dr["apemcli"].ToString();
                    obj.numerodocumento = dr["numdoccli"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnaccli"]);
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.distrito = new DistritoBO();
                    obj.distrito.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.distrito.nombre = dr["nomdis"].ToString();

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

        public bool add(ClienteBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apep", obj.apellidopaterno);
                cmd.Parameters.AddWithValue("@apem", obj.apellidomaterno);
                cmd.Parameters.AddWithValue("@numerodoc", obj.numerodocumento);
                cmd.Parameters.AddWithValue("@fecnac", obj.fechanacimiento);
                cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@correo", obj.correo);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idtipdoc", obj.tipodocumento.codigo);
                cmd.Parameters.AddWithValue("@iddis", obj.distrito.codigo);

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

        public ClienteBO findById(int id)
        {
            ClienteBO obj = new ClienteBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarClienteXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidopaterno = dr["apepcli"].ToString();
                    obj.apellidomaterno = dr["apemcli"].ToString();
                    obj.numerodocumento = dr["numdoccli"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnaccli"]);
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.distrito = new DistritoBO();
                    obj.distrito.codigo = Convert.ToInt32(dr["iddis"]);
                    obj.distrito.nombre = dr["nomdis"].ToString();
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

        public bool update(ClienteBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apep", obj.apellidopaterno);
                cmd.Parameters.AddWithValue("@apem", obj.apellidomaterno);
                cmd.Parameters.AddWithValue("@numerodoc", obj.numerodocumento);
                cmd.Parameters.AddWithValue("@fecnac", obj.fechanacimiento);
                cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@correo", obj.correo);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idtipdoc", obj.tipodocumento.codigo);
                cmd.Parameters.AddWithValue("@iddis", obj.distrito.codigo);

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
                cmd.CommandText = "SP_EliminarCliente";
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
                cmd.CommandText = "SP_HabilitarCliente";
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
                cmd.CommandText = "SP_CodigoCliente";
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