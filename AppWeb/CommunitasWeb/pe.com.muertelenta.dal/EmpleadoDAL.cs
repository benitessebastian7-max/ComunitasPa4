using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class EmpleadoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<EmpleadoBO> findAll()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleadoTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();

                    obj.codigo = Convert.ToInt32(dr["idemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidopaterno = dr["apepemp"].ToString();
                    obj.apellidomaterno = dr["apememp"].ToString();
                    obj.numerodocumento = dr["numdocemp"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnacemp"]);
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.fechaingreso = Convert.ToDateTime(dr["fecinemp"]);
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString();
                    obj.sueldo = Convert.ToDecimal(dr["sueldoemp"]);
                    obj.numerohoras = Convert.ToInt32(dr["numhoremp"]);
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.rol = new RolBO();
                    obj.rol.codigo = Convert.ToInt32(dr["idrol"]);
                    obj.rol.nombre = dr["nomrol"].ToString();

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

        public List<EmpleadoBO> findAllCustom()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleado";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();

                    obj.codigo = Convert.ToInt32(dr["idemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidopaterno = dr["apepemp"].ToString();
                    obj.apellidomaterno = dr["apememp"].ToString();
                    obj.numerodocumento = dr["numdocemp"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnacemp"]);
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.fechaingreso = Convert.ToDateTime(dr["fecinemp"]);
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString();
                    obj.sueldo = Convert.ToDecimal(dr["sueldoemp"]);
                    obj.numerohoras = Convert.ToInt32(dr["numhoremp"]);
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.rol = new RolBO();
                    obj.rol.codigo = Convert.ToInt32(dr["idrol"]);
                    obj.rol.nombre = dr["nomrol"].ToString();

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

        public bool add(EmpleadoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarEmpleado";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apep", obj.apellidopaterno);
                cmd.Parameters.AddWithValue("@apem", obj.apellidomaterno);
                cmd.Parameters.AddWithValue("@numerodoc", obj.numerodocumento);
                cmd.Parameters.AddWithValue("@fecnac", obj.fechanacimiento);
                cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@correo", obj.correo);
                cmd.Parameters.AddWithValue("@fechaingreso", obj.fechaingreso);
                cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                cmd.Parameters.AddWithValue("@clave", obj.clave);
                cmd.Parameters.AddWithValue("@sueldo", obj.sueldo);
                cmd.Parameters.AddWithValue("@numhoras", obj.numerohoras);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idtipdoc", obj.tipodocumento.codigo);
                cmd.Parameters.AddWithValue("@idrol", obj.rol.codigo);
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

        public EmpleadoBO findById(int id)
        {
            EmpleadoBO obj = new EmpleadoBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarEmpleadoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidopaterno = dr["apepemp"].ToString();
                    obj.apellidomaterno = dr["apememp"].ToString();
                    obj.numerodocumento = dr["numdocemp"].ToString();
                    obj.fechanacimiento = Convert.ToDateTime(dr["fecnacemp"]);
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.fechaingreso = Convert.ToDateTime(dr["fecinemp"]);
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString();
                    obj.sueldo = Convert.ToDecimal(dr["sueldoemp"]);
                    obj.numerohoras = Convert.ToInt32(dr["numhoremp"]);
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    obj.tipodocumento = new TipoDocumentoBO();
                    obj.tipodocumento.codigo = Convert.ToInt32(dr["idtipdoc"]);
                    obj.tipodocumento.nombre = dr["nomtipdoc"].ToString();

                    obj.rol = new RolBO();
                    obj.rol.codigo = Convert.ToInt32(dr["idrol"]);
                    obj.rol.nombre = dr["nomrol"].ToString();

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

        public bool update(EmpleadoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarEmpleado";
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
                cmd.Parameters.AddWithValue("@fechaingreso", obj.fechaingreso);
                cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                cmd.Parameters.AddWithValue("@clave", obj.clave);
                cmd.Parameters.AddWithValue("@sueldo", obj.sueldo);
                cmd.Parameters.AddWithValue("@numhoras", obj.numerohoras);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idtipdoc", obj.tipodocumento.codigo);
                cmd.Parameters.AddWithValue("@idrol", obj.rol.codigo);
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
                cmd.CommandText = "SP_EliminarEmpleado";
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
                cmd.CommandText = "SP_HabilitarEmpleado";
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
                cmd.CommandText = "SP_CodigoEmpleado";
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