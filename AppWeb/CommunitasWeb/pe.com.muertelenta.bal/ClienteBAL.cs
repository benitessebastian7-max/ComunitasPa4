using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class ClienteBAL
    {
        private ClienteDAL objdal = new ClienteDAL();

        public List<ClienteBO> findAll()
        {
            return objdal.findAll();
        }

        public List<ClienteBO> findAllCustom()
        {
            return objdal.findAllCustom();
        }

        public bool add(ClienteBO obj)
        {
            return objdal.add(obj);
        }

        public ClienteBO findById(int id)
        {
            return objdal.findById(id);
        }

        public bool update(ClienteBO obj, int id)
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