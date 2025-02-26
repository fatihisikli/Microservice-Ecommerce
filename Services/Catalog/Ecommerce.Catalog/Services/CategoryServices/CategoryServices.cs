using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;

namespace Ecommerce.Catalog.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            
        }

        public async Task CrateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var value=_mapper.Map<Category>(categoryDto);   
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value=await _categoryCollection.Find<Category>(x => x.CategoryID==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var values= _mapper.Map<Category>(categoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID==categoryDto.CategoryID,values);
        }
    }
}
