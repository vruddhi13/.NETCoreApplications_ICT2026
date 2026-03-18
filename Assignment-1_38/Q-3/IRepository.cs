using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_38.Q_3
{
    public interface IRepository<T>
    {
        void Save(T item);
    }
}
