using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure
{
    public interface IManager<T>
    {
        void Add (T item);
        void Edit (T item);
        void Remove (T item);
        T GetById(int id);
       

    }
}
