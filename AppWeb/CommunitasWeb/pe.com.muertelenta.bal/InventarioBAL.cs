using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class InventarioBAL
    {
        private InventarioDAL objdal = new InventarioDAL();

        public List<InventarioBO> findAll()
        {
            return objdal.findAll();
        }

        public List<InventarioBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(InventarioBO obj)
        {
            return objdal.add(obj);
        }

        public InventarioBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(InventarioBO obj, int id)
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