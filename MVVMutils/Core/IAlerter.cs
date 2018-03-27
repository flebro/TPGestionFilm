using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.Core
{
    public interface IAlerter
    {
        void ShowError(String message);
    }
}
