using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IObserver
    {
        void Update(bool value1, bool value2);
    }
}
