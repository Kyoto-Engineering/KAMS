using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManagementSystem.DbGateway
{
  public  class ConnectionString
  {
     // public string DBConn = @"Data Source=KYOTO-PC06\SQLSERVER2018;Initial Catalog=AccountDb;User=sa;Password=SystemAdministrator;Persist Security Info=true";
     // public string DBConn = @"Data Source=KYOTO-PC06\SQLSERVER2018;Initial Catalog=LastUpdateAccountDb50;User=sa;Password=SystemAdministrator;Persist Security Info=true";
      public string DBConn = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=LastUpdateAccountDb22;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
  }
}
