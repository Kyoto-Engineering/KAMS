using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsManagementSystem.DAO;
using AccountsManagementSystem.DbGateway;

namespace AccountsManagementSystem.Gateway
{
  public   class VoucherGateway:ConnectionGateway
    {
      public int SaveCheque(Voucher aVoucher)
      {
          connection.Open();
          string insertEQuery = "insert into ChequeLoad (BankName,AccountNo,CheckNo,Status) Values()";
          SqlCommand comnd = new SqlCommand(insertEQuery, connection);
          int affectedRows = comnd.ExecuteNonQuery();
          connection.Close();
          return affectedRows;
      }
    }
}
