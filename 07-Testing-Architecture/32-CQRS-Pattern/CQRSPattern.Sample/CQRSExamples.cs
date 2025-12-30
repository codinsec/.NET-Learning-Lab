// CQRS Pattern Examples with MediatR
using MediatR;

namespace CQRSPattern.Sample;

// ========== COMMANDS (Write Operations) ==========

// 1. Create Product Command
public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}

// 2. Create Product Command Handler
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = _nextId++,
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };

        _products.Add(product);
        return Task.FromResult(product.Id);
    }
}

// 3. Update Product Command
public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

// 4. Update Product Command Handler
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" }
    };

    public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _products.FirstOrDefault(p => p.Id == request.Id);
        if (product == null)
            return Task.FromResult(false);

        product.Name = request.Name;
        product.Price = request.Price;
        return Task.FromResult(true);
    }
}

// 5. Delete Product Command
public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}

// 6. Delete Product Command Handler
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" }
    };

    public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _products.FirstOrDefault(p => p.Id == request.Id);
        if (product == null)
            return Task.FromResult(false);

        _products.Remove(product);
        return Task.FromResult(true);
    }
}

// ========== QUERIES (Read Operations) ==========

// 7. Get Product Query
public class GetProductQuery : IRequest<Product?>
{
    public int Id { get; set; }
}

// 8. Get Product Query Handler
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m, Category = "Electronics" }
    };

    public Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = _products.FirstOrDefault(p => p.Id == request.Id);
        return Task.FromResult(product);
    }
}

// 9. Get All Products Query
public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
}

// 10. Get All Products Query Handler
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m, Category = "Electronics" },
        new Product { Id = 3, Name = "Desk", Price = 199.99m, Category = "Furniture" }
    };

    public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_products.AsEnumerable());
    }
}

// 11. Get Products By Category Query
public class GetProductsByCategoryQuery : IRequest<IEnumerable<Product>>
{
    public string Category { get; set; } = string.Empty;
}

// 12. Get Products By Category Query Handler
public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<Product>>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m, Category = "Electronics" },
        new Product { Id = 3, Name = "Desk", Price = 199.99m, Category = "Furniture" }
    };

    public Task<IEnumerable<Product>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = _products.Where(p => p.Category == request.Category);
        return Task.FromResult(products);
    }
}

// 13. Search Products Query
public class SearchProductsQuery : IRequest<IEnumerable<Product>>
{
    public string SearchTerm { get; set; } = string.Empty;
}

// 14. Search Products Query Handler
public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<Product>>
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m, Category = "Electronics" },
        new Product { Id = 3, Name = "Desk", Price = 199.99m, Category = "Furniture" }
    };

    public Task<IEnumerable<Product>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _products.Where(p => 
            p.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
            p.Category.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(products);
    }
}

// ========== SERVICE USING MEDIATR ==========

// 15. Product Service Using MediatR
public class ProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<int> CreateProductAsync(string name, decimal price, string category)
    {
        var command = new CreateProductCommand
        {
            Name = name,
            Price = price,
            Category = category
        };

        return await _mediator.Send(command);
    }

    public async Task<bool> UpdateProductAsync(int id, string name, decimal price)
    {
        var command = new UpdateProductCommand
        {
            Id = id,
            Name = name,
            Price = price
        };

        return await _mediator.Send(command);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var command = new DeleteProductCommand { Id = id };
        return await _mediator.Send(command);
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        var query = new GetProductQuery { Id = id };
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var query = new GetAllProductsQuery();
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        var query = new GetProductsByCategoryQuery { Category = category };
        return await _mediator.Send(query);
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        var query = new SearchProductsQuery { SearchTerm = searchTerm };
        return await _mediator.Send(query);
    }
}

// Entity Class

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}
