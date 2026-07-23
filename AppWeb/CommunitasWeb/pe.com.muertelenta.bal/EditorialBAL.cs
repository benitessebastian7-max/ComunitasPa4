using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class EditorialBAL
    {
        private EditorialDAL objdal = new EditorialDAL();

        public List<EditorialBO> findAll()
        {
            return objdal.findAll();
        }

        public List<EditorialBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(EditorialBO obj)
        {
            return objdal.add(obj);
        }

        public EditorialBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(EditorialBO obj, int id)
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