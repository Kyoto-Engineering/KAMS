using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManagementSystem.DAO
{
  public   class Voucher
  {
      private int voucherId;
      private string voucherNo;
      private string statuss;

      public int VoucherId
      {
          set { voucherId = value; }
          get { return voucherId; }
      }

      public string VoucherNo
      {
          set { voucherNo = value; }
          get { return voucherNo; }
      }

      public string Statuss
      {
          set { statuss = value; }
          get { return statuss; }
      }
  }
}
