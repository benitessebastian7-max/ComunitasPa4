
using pe.com.communitas.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.communitas.dal
{
    public class ProductoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<ProductoBO> findAll()
        {
            List<ProductoBO> lista = new List<ProductoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProductoTodo";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBO obj = new ProductoBO();

                    obj.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.isbn = dr["isbnprod"].ToString();
                    obj.titulo = dr["titprod"].ToString();
                    obj.descripcion = dr["descprod"].ToString();
                    obj.preciocompra = Convert.ToDecimal(dr["preccompprod"]);
                    obj.precioventa = Convert.ToDecimal(dr["precventprod"]);
                    obj.fechapublicacion = Convert.ToDateTime(dr["fecpubprod"]);
                    obj.estado = Convert.ToBoolean(dr["estprod"]);

                    obj.proveedor = new ProveedorBO();
                    obj.proveedor.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.proveedor.razonsocial = dr["razsocprov"].ToString();

                    obj.categoria = new CategoriaBO();
                    obj.categoria.codigo = Convert.ToInt32(dr["idcategoria"]);
                    obj.categoria.nombre = dr["nomcategoria"].ToString();

                    obj.editorial = new EditorialBO();
                    obj.editorial.codigo = Convert.ToInt32(dr["ideditorial"]);
                    obj.editorial.nombre = dr["nomeditorial"].ToString();

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

        public List<ProductoBO> findAllCustom()
        {
            List<ProductoBO> lista = new List<ProductoBO>();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProducto";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBO obj = new ProductoBO();

                    obj.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.isbn = dr["isbnprod"].ToString();
                    obj.titulo = dr["titprod"].ToString();
                    obj.descripcion = dr["descprod"].ToString();
                    obj.preciocompra = Convert.ToDecimal(dr["preccompprod"]);
                    obj.precioventa = Convert.ToDecimal(dr["precventprod"]);
                    obj.fechapublicacion = Convert.ToDateTime(dr["fecpubprod"]);
                    obj.estado = Convert.ToBoolean(dr["estprod"]);

                    obj.proveedor = new ProveedorBO();
                    obj.proveedor.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.proveedor.razonsocial = dr["razsocprov"].ToString();

                    obj.categoria = new CategoriaBO();
                    obj.categoria.codigo = Convert.ToInt32(dr["idcategoria"]);
                    obj.categoria.nombre = dr["nomcategoria"].ToString();

                    obj.editorial = new EditorialBO();
                    obj.editorial.codigo = Convert.ToInt32(dr["ideditorial"]);
                    obj.editorial.nombre = dr["nomeditorial"].ToString();

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

        public bool add(ProductoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarProducto";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@isbn", obj.isbn);
                cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@preciocompra", obj.preciocompra);
                cmd.Parameters.AddWithValue("@precioventa", obj.precioventa);
                cmd.Parameters.AddWithValue("@fechapublicacion", obj.fechapublicacion);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idprov", obj.proveedor.codigo);
                cmd.Parameters.AddWithValue("@idcategoria", obj.categoria.codigo);
                cmd.Parameters.AddWithValue("@ideditorial", obj.editorial.codigo);

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

        public ProductoBO findById(int id)
        {
            ProductoBO obj = new ProductoBO();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarProductoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["idprod"]);
                    obj.isbn = dr["isbnprod"].ToString();
                    obj.titulo = dr["titprod"].ToString();
                    obj.descripcion = dr["descprod"].ToString();
                    obj.preciocompra = Convert.ToDecimal(dr["preccompprod"]);
                    obj.precioventa = Convert.ToDecimal(dr["precventprod"]);
                    obj.fechapublicacion = Convert.ToDateTime(dr["fecpubprod"]);
                    obj.estado = Convert.ToBoolean(dr["estprod"]);

                    obj.proveedor = new ProveedorBO();
                    obj.proveedor.codigo = Convert.ToInt32(dr["idprov"]);
                    obj.proveedor.razonsocial = dr["razsocprov"].ToString();

                    obj.categoria = new CategoriaBO();
                    obj.categoria.codigo = Convert.ToInt32(dr["idcategoria"]);
                    obj.categoria.nombre = dr["nomcategoria"].ToString();

                    obj.editorial = new EditorialBO();
                    obj.editorial.codigo = Convert.ToInt32(dr["ideditorial"]);
                    obj.editorial.nombre = dr["nomeditorial"].ToString();
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

        public bool update(ProductoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarProducto";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@isbn", obj.isbn);
                cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@preciocompra", obj.preciocompra);
                cmd.Parameters.AddWithValue("@precioventa", obj.precioventa);
                cmd.Parameters.AddWithValue("@fechapublicacion", obj.fechapublicacion);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@idprov", obj.proveedor.codigo);
                cmd.Parameters.AddWithValue("@idcategoria", obj.categoria.codigo);
                cmd.Parameters.AddWithValue("@ideditorial", obj.editorial.codigo);

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
                cmd.CommandText = "SP_EliminarProducto";
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
                cmd.CommandText = "SP_HabilitarProducto";
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
                cmd.CommandText = "SP_CodigoProducto";
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