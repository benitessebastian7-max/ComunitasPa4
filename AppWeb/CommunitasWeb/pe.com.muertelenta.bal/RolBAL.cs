using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class RolBAL
    {
        private RolDAL objdal = new RolDAL();

        public List<RolBO> findAll()
        {
            return objdal.findAll();
        }

        public List<RolBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(RolBO obj)
        {
            return objdal.add(obj);
        }

        public RolBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(RolBO obj, int id)
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