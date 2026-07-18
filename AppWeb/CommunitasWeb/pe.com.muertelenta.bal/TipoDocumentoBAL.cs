using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class TipoDocumentoBAL
    {
        private TipoDocumentoDAL objdal = new TipoDocumentoDAL();

        public List<TipoDocumentoBO> findAll()
        {
            return objdal.findAll();
        }

        public List<TipoDocumentoBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(TipoDocumentoBO obj)
        {
            return objdal.add(obj);
        }

        public TipoDocumentoBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(TipoDocumentoBO obj, int id)
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