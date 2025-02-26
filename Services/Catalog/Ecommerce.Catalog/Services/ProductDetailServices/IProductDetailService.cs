using Ecommerce.Catalog.Dtos.ProductDetailDtos;

namespace Ecommerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CrateProductDetailAsync(CreateProductDetailDto ProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
