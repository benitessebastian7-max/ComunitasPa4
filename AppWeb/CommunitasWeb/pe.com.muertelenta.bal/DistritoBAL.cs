using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class DistritoBAL
    {
        private DistritoDAL objdal = new DistritoDAL();

        public List<DistritoBO> findAll()
        {
            return objdal.findAll();
        }

        public List<DistritoBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(DistritoBO obj)
        {
            return objdal.add(obj);
        }

        public DistritoBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(DistritoBO obj, int id)
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