using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsManagementSystem.DAO;
using AccountsManagementSystem.Gateway;

namespace AccountsManagementSystem.Manager
{
  public   class VoucherManager
    {
      private VoucherGateway ngateway;
        public int SaveCheque(Voucher aVoucher)
        {

            ngateway = new VoucherGateway();
            return ngateway.SaveCheque(aVoucher);
        }
    }
}
