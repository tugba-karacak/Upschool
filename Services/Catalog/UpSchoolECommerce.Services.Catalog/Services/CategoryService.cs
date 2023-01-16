﻿using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Catalog.Dtos;
using UpSchoolECommerce.Services.Catalog.Models;
using UpSchoolECommerce.Services.Catalog.Settings;
using UpSchoolECommerce.Shared.Dtos;

namespace UpSchoolECommerce.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private MongoClientSettings databaseSettings;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryColllectionName);
            _mapper = mapper;
        }
        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var categories = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(categories);
            return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(categories), 200);

        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(x => true).ToListAsync();
           
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category==null)
            {
                return ResponseDto<CategoryDto>.Fail("Kategori Bulunamadı.", 404);
            }
            else
            {
                return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }
        }
    }
}
