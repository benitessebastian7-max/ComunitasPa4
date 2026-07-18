using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class PaisBAL
    {
        private PaisDAL objdal = new PaisDAL();

        public List<PaisBO> findAll()
        {
            return objdal.findAll();
        }

        public List<PaisBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(PaisBO obj)
        {
            return objdal.add(obj);
        }

        public PaisBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(PaisBO obj, int id)
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