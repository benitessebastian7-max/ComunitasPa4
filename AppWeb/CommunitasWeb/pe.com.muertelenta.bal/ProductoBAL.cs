using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class ProductoBAL
    {
        private ProductoDAL objdal = new ProductoDAL();

        public List<ProductoBO> findAll()
        {
            return objdal.findAll();
        }

        public List<ProductoBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(ProductoBO obj)
        {
            return objdal.add(obj);
        }

        public ProductoBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(ProductoBO obj, int id)
        {
            return objdal.update(obj, id);
        }

        public bool delete(int id)
        {
            return objdal.delete(id);
        }

        public bool enable(int id)
        {
            return objdal.enable(id);
        }

        public int setCode()
        {
            return objdal.setCode();
        }
    }
}