using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class CategoriaBAL
    {
        private CategoriaDAL objdal = new CategoriaDAL();

        public List<CategoriaBO> findAll()
        {
            return objdal.findAll();
        }

        public List<CategoriaBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(CategoriaBO obj)
        {
            return objdal.add(obj);
        }

        public CategoriaBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(CategoriaBO obj, int id)
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