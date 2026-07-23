using pe.com.communitas.bo;
using pe.com.communitas.bal;
using System.Collections.Generic;

namespace pe.com.communitas.bal
{
    public class VentaBAL
    {
        private VentaBAL objdal = new VentaBAL();

        public bool add(VentaBO obj)
        {
            return objdal.add(obj);
        }

        public int setCode()
        {
            return objdal.setCode();
        }

        public List<VentaBO> SaleDetails()
        {
            return objdal.SaleDetails();
        }

        public List<VentaBO> Sale()
        {
            return objdal.Sale();
        }

        public List<DetalleVentaBO> Details(int cod)
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