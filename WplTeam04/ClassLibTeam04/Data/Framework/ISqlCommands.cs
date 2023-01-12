using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Data.Framework
{
   internal interface ISqlCommands<T>
    {
        SelectResult select();
        InsertResult Insert(T t);
     
    }
}
