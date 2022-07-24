using Domain.Models;
using Domain.Settings;

namespace Domain.Repositories;

public interface IDatabaseRepository
{
    public Task AddCanvasOptions(CanvasOptions canvasOptions);

    public Task UpdateCanvasOptions(CanvasOptions canvasOptions);

    public Task<CanvasOptions?> GetCanvasOptions();

    public Task AddOwner(Owner owner);


}