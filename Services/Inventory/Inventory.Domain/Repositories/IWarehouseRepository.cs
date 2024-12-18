using System.Linq.Expressions;
using Abstractions.ResultsPattern;
using Inventory.Domain.DTOs.WarehouseDtos;
using Inventory.Domain.Entities;

namespace Inventory.Domain.Repositories;

public interface IWarehouseRepository
{
    Task<Result<IEnumerable<Warehouse>>> GetWarehousesAsync(CancellationToken cancellationToken = default);
    Task<Result<Warehouse?>> GetWarehouseByIdAsync(Guid warehouseId, CancellationToken cancellationToken = default);
    Task<Result> AddWarehouseAsync(Warehouse warehouse);
    Task<Result> RemoveWarehouseAsync(Warehouse warehouse);
    Task<Result> UpdateWarehouseAsync(Warehouse warehouse);
    Task<Result> AddInventoryToWarehouse(Warehouse warehouse, Inventories inventory);
    Task<Result> RemoveInventoryFromWarehouse(Warehouse warehouse, Inventories inventory);
    Task<Result<IEnumerable<Warehouse>>> GetWarehousesSellingProductAsync(string productId, CancellationToken cancellationToken = default);
    Task<Result<WarehouseForProductDto>> GetWarehouseSellingProductDtoAsync(string productId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Warehouse>>> GetWarehousesByConditionAsync(
        Expression<Func<Warehouse, bool>> predicate, 
        CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<WarehouseNamesDto>>> GetWarehouseIdsAndNamesAsync(
        CancellationToken cancellationToken = default);
}