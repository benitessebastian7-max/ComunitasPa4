using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class CompraDAL
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

        public bool add(CompraBO obj)
        {
            try
            {
                //conectamos a la BD
                SqlConnection xcon = objconexion.Conectar();

                //abrimos transaccion
                transaccion = xcon.BeginTransaction();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarCompra";
                cmd.Connection = xcon;
                cmd.Transaction = transaccion;

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@idprov", obj.proveedor.codigo);
                cmd.Parameters.AddWithValue("@total", obj.subtotal);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                SqlParameter parametrosalida = new SqlParameter("@idcompra", SqlDbType.Int);
                parametrosalida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametrosalida);

                res = cmd.ExecuteNonQuery();

                int codigoCompra = Convert.ToInt32(parametrosalida.Value);

                foreach (DetalleCompraBO detalle in obj.detalles)
                {
                    SqlCommand cmddetalle = new SqlCommand("SP_RegistrarDetalleCompra", xcon, transaccion);
                    cmddetalle.CommandType = CommandType.StoredProcedure;
                    cmddetalle.Parameters.AddWithValue("@idcompra", codigoCompra);
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
                cmd.CommandText = "SP_CodigoCompra";
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

        //compra y detalle
        public List<CompraBO> PurchaseDetails()
        {
            List<CompraBO> lista = new List<CompraBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarCompraDetalle";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    CompraBO obj = new CompraBO();
                    ProveedorBO objprov = new ProveedorBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigocompra = Convert.ToInt32(dr["idcompra"]);
                    obj.fecha = Convert.ToDateTime(dr["feccompra"]);
                    obj.estado = Convert.ToBoolean(dr["estcompra"].ToString());

                    //proveedor
                    objprov.razonsocial = dr["razsocprov"].ToString();
                    objprov.ruc = dr["rucprov"].ToString();
                    obj.proveedor = objprov;

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

        public List<CompraBO> Purchase()
        {
            List<CompraBO> lista = new List<CompraBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarCompra";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    CompraBO obj = new CompraBO();
                    ProveedorBO objprov = new ProveedorBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigocompra = Convert.ToInt32(dr["idcompra"]);
                    obj.fecha = Convert.ToDateTime(dr["feccompra"]);
                    obj.estado = Convert.ToBoolean(dr["estcompra"].ToString());

                    //proveedor
                    objprov.razonsocial = dr["razsocprov"].ToString();
                    objprov.ruc = dr["rucprov"].ToString();
                    obj.proveedor = objprov;

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

        public List<DetalleCompraBO> Details(int cod)
        {
            List<DetalleCompraBO> lista = new List<DetalleCompraBO>();

            //manejamos los errores con try-catch
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand -> Procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarDetalleCompra";

                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", cod);

                //ejecutamos el procedimiento y guardamos los resultados
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    DetalleCompraBO obj = new DetalleCompraBO();
                    ProductoBO objprod = new ProductoBO();

                    //leemos los datos y los asignamos al objeto
                    obj.codigocompra = Convert.ToInt32(dr["idcompra"]);
                    obj.cantidad = Convert.ToInt32(dr["cancompra"]);
                    obj.precio = Convert.ToDecimal(dr["precucomp"]);
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
                cmd.CommandText = "SP_AnularCompra";
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
                cmd.CommandText = "SP_HabilitarCompra";
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
