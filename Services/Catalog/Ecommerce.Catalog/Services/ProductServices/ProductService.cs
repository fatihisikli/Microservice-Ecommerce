using AutoMapper;
using Ecommerce.Catalog.Dtos.ProductDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;

        }

        public async Task CrateProductAsync(CreateProductDto productDto)
        {
            var value= _mapper.Map<Product>(productDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
           await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values= await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var values = _mapper.Map<Product>(productDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId==productDto.ProductId,values);
        }
    }
}
