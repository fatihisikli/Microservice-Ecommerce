﻿using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.ProductDetailDtos;
using Ecommerce.Catalog.Dtos.ProductDtos;
using Ecommerce.Catalog.Dtos.ProductImageDtos;
using Ecommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            //Category Sınıfı için
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            //Product Sınıfı için
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            //ProductImage Sınıfı için
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            //ProductDetail Sınıfı için
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
        }
    }
}
