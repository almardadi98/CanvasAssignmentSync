using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
    public interface IDatabaseService
    {
        public Task AddCanvasOptions(CanvasOptionsDto canvasOptions);

        public Task UpdateCanvasOptions(CanvasOptionsDto canvasOptions);

        public Task<CanvasOptionsDto?> GetCanvasOptions();

        public Task AddOwner(OwnerDto owner);

    }
}
