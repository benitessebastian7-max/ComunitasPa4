using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class AutorBAL
    {
        private AutorDAL objdal = new AutorDAL();

        public List<AutorBO> findAll()
        {
            return objdal.findAll();
        }

        public List<AutorBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(AutorBO obj)
        {
            return objdal.add(obj);
        }

        public AutorBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(AutorBO obj, int id)
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