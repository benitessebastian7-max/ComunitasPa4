using pe.com.communitas.bo;
using pe.com.communitas.dal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class CompraBAL
    {
        private CompraDAL objdal = new CompraDAL();

        public bool add(CompraBO obj)
        {
            return objdal.add(obj);
        }

        public int setCode()
        {
            return objdal.setCode();
        }

        public List<CompraBO> PurchaseDetails()
        {
            return objdal.PurchaseDetails();
        }

        public List<CompraBO> Purchase()
        {
            return objdal.Purchase();
        }

        public List<DetalleCompraBO> Details(int cod)
        {
            return objdal.Details(cod);
        }

        public bool disable(int id)
        {
            return objdal.disable(id);
        }

        public bool enable(int id)
        {
            return objdal.enable(id);
        }
    }
}