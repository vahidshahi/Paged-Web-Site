using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTeam04.Repository
{
    public class UserRecord
    {
        public UserRecord(string name, string password)
        {
            UserName = name;
            Password = password;
        }
        public UserRecord()
        {

        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
   
}
