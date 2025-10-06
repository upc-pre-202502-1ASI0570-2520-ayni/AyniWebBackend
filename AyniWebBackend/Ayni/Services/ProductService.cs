using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred when saving the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync(int productId, Product product)
    {
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        if (existingProduct == null)
            return new ProductResponse("Product not found");
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.UnitPrice = product.UnitPrice;
        existingProduct.Quantity = product.Quantity;
        existingProduct.ImageUrl = product.ImageUrl;

        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred when updating the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int productId)
    {
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        if (existingProduct == null)
            return new ProductResponse("Product not found");
        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred when deleting the product: {e.Message}");
        }
    }
}