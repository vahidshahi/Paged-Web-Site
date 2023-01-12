using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data.Framework
{
    public abstract class BaseResult
    {
        
        public int Rows { get; set; }
        public DataTable DataTable { get; set; }
        
        private List<string> errors = new List<string>();      // zet het resultaat om in een list 

        public bool Succeeded { get; set; }
        public string Bericht { get; set; }

        public IEnumerable<string> Errors => errors;

        public void Adderror(string error)
        {
            errors.Add(error);
        }
    }
}
