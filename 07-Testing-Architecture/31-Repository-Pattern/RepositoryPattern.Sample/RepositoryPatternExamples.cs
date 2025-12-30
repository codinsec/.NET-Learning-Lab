// Repository Pattern Examples
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryPattern.Sample;

// 1. Generic Repository Interface
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

// 2. Generic Repository Implementation
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly List<T> _entities = new();

    public Task<T?> GetByIdAsync(int id)
    {
        // In real implementation, this would query a database
        var entity = _entities.FirstOrDefault();
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_entities.AsEnumerable());
    }

    public Task<T> AddAsync(T entity)
    {
        _entities.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(T entity)
    {
        // In real implementation, this would update database
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        // In real implementation, this would delete from database
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(int id)
    {
        // In real implementation, this would check database
        return Task.FromResult(_entities.Any());
    }
}

// 3. Specific Repository Interface
public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByNameAsync(string name);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    Task<IEnumerable<Product>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
}

// 4. Specific Repository Implementation
public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<Product?> GetByNameAsync(string name)
    {
        var product = _products.FirstOrDefault(p => p.Name == name);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        var products = _products.Where(p => p.Category == category);
        return Task.FromResult(products);
    }

    public Task<IEnumerable<Product>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        var products = _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
        return Task.FromResult(products);
    }
}

// 5. Unit of Work Pattern
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public UnitOfWork(
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public IProductRepository Products => _productRepository;
    public IOrderRepository Orders => _orderRepository;

    public Task<int> SaveChangesAsync()
    {
        // In real implementation, this would save changes to database
        return Task.FromResult(1);
    }

    public Task BeginTransactionAsync()
    {
        // In real implementation, this would begin a database transaction
        return Task.CompletedTask;
    }

    public Task CommitTransactionAsync()
    {
        // In real implementation, this would commit the transaction
        return Task.CompletedTask;
    }

    public Task RollbackTransactionAsync()
    {
        // In real implementation, this would rollback the transaction
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        // Cleanup resources
    }
}

// 6. Service Using Repository
public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetProductByNameAsync(string name)
    {
        return await _productRepository.GetByNameAsync(name);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        return await _productRepository.GetByCategoryAsync(category);
    }

    public async Task<IEnumerable<Product>> GetAffordableProductsAsync(decimal maxPrice)
    {
        return await _productRepository.GetByPriceRangeAsync(0, maxPrice);
    }
}

// 7. Order Repository
public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
    Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId)
    {
        var orders = _orders.Where(o => o.CustomerId == customerId);
        return Task.FromResult(orders);
    }

    public Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var orders = _orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
        return Task.FromResult(orders);
    }
}

// 8. Dependency Injection Setup
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ProductService>();
        return services;
    }
}

// Entity Classes

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
}
