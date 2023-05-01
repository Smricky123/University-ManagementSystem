using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IAuthC<CLASS, ID>
    {
        CLASS GetChecker(ID id);
    }
}
