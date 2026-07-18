using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class LibroAutorBAL
    {
        private LibroAutorDAL objdal = new LibroAutorDAL();

        public List<LibroAutorBO> findAll()
        {
            return objdal.findAll();
        }

        public List<LibroAutorBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(LibroAutorBO obj)
        {
            return objdal.add(obj);
        }

        public LibroAutorBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(LibroAutorBO obj, int id)
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