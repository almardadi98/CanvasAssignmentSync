using Contracts;
using Domain.Models;
using Domain.Models.Canvas;
using Domain.Repositories;
using Domain.Settings;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class DatabaseService : IDatabaseService
{
    private readonly IRepositoryManager _repositoryManager;


    public DatabaseService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }


    public async Task AddCanvasOptions(CanvasOptionsDto canvasOptionsDto)
    {
        var canvasOptions = canvasOptionsDto.Adapt<CanvasOptions>();
        await _repositoryManager.DatabaseRepository.AddCanvasOptions(canvasOptions);
    }

    public async Task UpdateCanvasOptions(CanvasOptionsDto canvasOptionsDto)
    {
        var canvasOptions = canvasOptionsDto.Adapt<CanvasOptions>();
        await _repositoryManager.DatabaseRepository.UpdateCanvasOptions(canvasOptions);
    }

    public async Task<CanvasOptionsDto?> GetCanvasOptions()
    {
        var canvasOptions = await _repositoryManager.DatabaseRepository.GetCanvasOptions();
        return canvasOptions?.Adapt<CanvasOptionsDto>();
    }

    public async Task AddOwner(OwnerDto ownerDto)
    {
        var owner = ownerDto.Adapt<Owner>();
        await _repositoryManager.DatabaseRepository.AddOwner(owner);
    }
}