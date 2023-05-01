using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IRole<Type, ID, RET>
    {
        RET Create(ID id,Type obj);
        List<Type> Read();
        Type Read(ID id);
        RET Update(Type obj);
        bool Delete(ID id);
        Type GetChecker(ID id);
    }
}
