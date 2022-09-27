using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Contracts.Dto;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Persistence.Base;
using Northwind.Web.Mapping;
using NorthwindServices;
using NorthwindServicesAbstraction;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Northwind.Test
{
    public class NorthwindIntegrationTest
    {
        private static IConfigurationRoot Configuration;
        private static DbContextOptionsBuilder<NorthwindContext> optionBuilder;
        private static MapperConfiguration mapperConfig;
        private static IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static IRepositoryManager _repositoryManager;

        public NorthwindIntegrationTest()
        {
            BuildConfiguration();
            SetupOption();

        }

        
        

        [Fact]
        public void TestCreateCategoryService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServicesManager(_repositoryManager, mapper);

                var categoryDto = new CategoryForCreateDto
                {
                    CategoryName = "Toys",
                    Description = "BuzzLightYear"
                };

                serviceManager.CategoryServices.insert(categoryDto);

                var category = serviceManager.CategoryServices.GetAllCategories(false);
                //assert
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(10);

            }
        }


        [Fact]
        public void TestGetCategoryService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServicesManager(_repositoryManager, mapper);

                var category = serviceManager.CategoryServices.GetAllCategories(false);
                //assert
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(9);
            }
        }



        /*public void TestCreateCatagoryRepo()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                //act
                _repositoryManager = new RepositoryManager(context);

                var categoryModel = new Category
                {
                    CategoryName = "Movie",
                    Description = "Movie entertaiment"
                };
                _repositoryManager.CategoryRepository.insert(categoryModel);
                _repositoryManager.save();

                categoryModel.CategoryId.ShouldBeEquivalentTo(9);

                _repositoryManager = new RepositoryManager(context);
                var category = _repositoryManager.CategoryRepository.GetAllCategories(false);

                //assert
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(9);

            }
        }*/

        /*public void TestGetCatagoryRepo()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                //act
                _repositoryManager = new RepositoryManager(context);
                var category = _repositoryManager.CategoryRepository.GetAllCategories(false);

                //assert
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(8);
            }
        }*/


        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private void SetupOption()
        {
            optionBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionBuilder.UseSqlServer(Configuration.GetConnectionString("NorthwindDb"));

            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile));
            serviceProvider = services.BuildServiceProvider();

            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapperConfig.AssertConfigurationIsValid();
            mapper = mapperConfig.CreateMapper();
        }
    }
}
