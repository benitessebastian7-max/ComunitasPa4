
using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class VentaDAL
    {
        //crear un objeto de la clase Conexion
        private ConexionDAL objconexion = new ConexionDAL();

        //objeto SqlCommand -> consultas SQL
        private SqlCommand cmd;

        //objeto de SqlDataReader -> resultados de una consulta
        private SqlDataReader dr;

        //objeto para la transaccion
        SqlTransaction transaccion = null;

        //creamos una variable para los resultados de la actualizacion de la BD
        private int res = 0;

        public bool add(VentaBO obj)
        {
            try
            {
                //conectamos a la BD
                SqlConnection xcon = objconexion.Conectar();

                //abrimos transaccion
                transaccion = xcon.BeginTransaction();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarVenta";
                cmd.Connection = xcon;
                cmd.Transaction = transaccion;

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@idcli", obj.cliente.codigo);
                cmd.Parameters.AddWithValue("@idemp", obj.empleado.codigo);
                cmd.Parameters.AddWithValue("@idtippag", obj.tipopago.codigo);
                cmd.Parameters.AddWithValue("@total", obj.subtotal);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                SqlParameter parametrosalida = new SqlParameter("@idventa", SqlDbType.Int);
                parametrosalida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametrosalida);

                res = cmd.ExecuteNonQuery();

                int codigoVenta = Convert.ToInt32(parametrosalida.Value);

                foreach (DetalleVentaBO detalle in obj.detalles)
                {
                    SqlCommand cmddetalle = new SqlCommand("SP_RegistrarDetalleVenta", xcon, transaccion);
                    cmddetalle.CommandType = CommandType.StoredProcedure;
                    cmddetalle.Parameters.AddWithValue("@idventa", codigoVenta);
                    cmddetalle.Parameters.AddWithValue("@idprod", detalle.codigoproducto);
                    cmddetalle.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                    cmddetalle.Parameters.AddWithValue("@precio", detalle.precio);
                    cmddetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());

                if (transaccion != null)
                {
                    transaccion.Rollback();
                }

                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        public int setCode()
        {
            //creamos una variable para el codigo
            int code = 0;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoVenta";
                cmd.Connection = objconexion.Conectar();

                object res = cmd.ExecuteScalar();

                //evaluamos el valor
                if (res != null)
                {
                    code = Convert.ToInt32(res);
                }

                //devolvemos el codigo
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
                if (dr != null) dr.Close();
            }
        }

        //venta y detalle
        public List<VentaBO> SaleDetails()
        {
            List<VentaBO> lista = new List<VentaBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarVentaDetalle";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    VentaBO obj = new VentaBO();
                    ClienteBO objcli = new ClienteBO();
                    EmpleadoBO objemp = new EmpleadoBO();
                    TipoPagoBO objtipopago = new TipoPagoBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigoventa = Convert.ToInt32(dr["idventa"]);
                    obj.fecha = Convert.ToDateTime(dr["fecventa"]);
                    obj.estado = Convert.ToBoolean(dr["estventa"].ToString());

                    //cliente
                    objcli.nombre = dr["nomcli"].ToString();
                    objcli.apellidopaterno = dr["apepcli"].ToString();
                    objcli.apellidomaterno = dr["apemcli"].ToString();
                    obj.cliente = objcli;

                    //empleado
                    objemp.nombre = dr["nomemp"].ToString();
                    objemp.apellidopaterno = dr["apepemp"].ToString();
                    objemp.apellidomaterno = dr["apememp"].ToString();
                    obj.empleado = objemp;

                    //tipo pago
                    objtipopago.nombre = dr["nomtippag"].ToString();
                    obj.tipopago = objtipopago;

                    obj.subtotal = Convert.ToDecimal(dr["Subtotal"]);

                    //agregamos el objeto a la lista
                    lista.Add(obj);
                }

                //devolvemos la lista
                return lista;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                //cerramos la conexion
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        public List<VentaBO> Sale()
        {
            List<VentaBO> lista = new List<VentaBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarVenta";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    VentaBO obj = new VentaBO();
                    ClienteBO objcli = new ClienteBO();
                    EmpleadoBO objemp = new EmpleadoBO();
                    TipoPagoBO objtipopago = new TipoPagoBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigoventa = Convert.ToInt32(dr["idventa"]);
                    obj.fecha = Convert.ToDateTime(dr["fecventa"]);
                    obj.estado = Convert.ToBoolean(dr["estventa"].ToString());

                    //cliente
                    objcli.nombre = dr["nomcli"].ToString();
                    objcli.apellidopaterno = dr["apepcli"].ToString();
                    objcli.apellidomaterno = dr["apemcli"].ToString();
                    obj.cliente = objcli;

                    //empleado
                    objemp.nombre = dr["nomemp"].ToString();
                    objemp.apellidopaterno = dr["apepemp"].ToString();
                    objemp.apellidomaterno = dr["apememp"].ToString();
                    obj.empleado = objemp;

                    //tipo pago
                    objtipopago.nombre = dr["nomtippag"].ToString();
                    obj.tipopago = objtipopago;

                    //agregamos el objeto a la lista
                    lista.Add(obj);
                }

                //devolvemos la lista
                return lista;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                //cerramos la conexion
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        public List<DetalleVentaBO> Details(int cod)
        {
            List<DetalleVentaBO> lista = new List<DetalleVentaBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarDetalleVenta";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", cod);

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    DetalleVentaBO obj = new DetalleVentaBO();
                    ProductoBO objprod = new ProductoBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigoventa = Convert.ToInt32(dr["idventa"]);
                    obj.cantidad = Convert.ToInt32(dr["canventa"]);
                    obj.precio = Convert.ToDecimal(dr["precuventa"]);
                    obj.subtotal = obj.cantidad * obj.precio;

                    //producto
                    objprod.codigo = Convert.ToInt32(dr["idprod"]);
                    objprod.titulo = dr["titprod"].ToString();
                    obj.producto = objprod;
                    obj.codigoproducto = objprod.codigo;

                    //agregamos el objeto a la lista
                    lista.Add(obj);
                }

                //devolvemos la lista
                return lista;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                //cerramos la conexion
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        public bool disable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AnularVenta";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@codigo", id);

                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();

                //devolvemos el valor
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
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
                cmd.CommandText = "SP_HabilitarVenta";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@codigo", id);

                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();

                //devolvemos el valor
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }
    }
}