using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManagementSystem.DbGateway
{
  public   class ConnectionGateway
  {
      protected SqlConnection connection;

      public ConnectionGateway()
      {


          string connectionString = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=AccountDb66;User=sa;Password=SystemAdministrator;Persist Security Info=true";
         // string connectionString = @"Data Source=KYOTO-PC06\SQLSERVER2018;Initial Catalog=LastUpdateAccountDb50;User=sa;Password=SystemAdministrator;Persist Security Info=true"; 

          connection=new SqlConnection(connectionString);

      }
      
  }
}
