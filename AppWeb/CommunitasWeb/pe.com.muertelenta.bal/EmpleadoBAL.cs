using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class EmpleadoBAL
    {
        private EmpleadoDAL objdal = new EmpleadoDAL();

        public List<EmpleadoBO> findAll()
        {
            return objdal.findAll();
        }

        public List<EmpleadoBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(EmpleadoBO obj)
        {
            return objdal.add(obj);
        }

        public EmpleadoBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(EmpleadoBO obj, int id)
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