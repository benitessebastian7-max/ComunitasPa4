using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class ProveedorBAL
    {
        private ProveedorDAL objdal = new ProveedorDAL();

        public List<ProveedorBO> findAll()
        {
            return objdal.findAll();
        }

        public List<ProveedorBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(ProveedorBO obj)
        {
            return objdal.add(obj);
        }

        public ProveedorBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(ProveedorBO obj, int id)
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