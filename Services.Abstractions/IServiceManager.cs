using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        ICanvasService CanvasService { get; }

        IMsToDoService MsToDoService { get; }

        IDatabaseService DatabaseService { get; }
    }
}
