using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SampleAPI.Controllers;
using SampleAPI.Entities;
using SampleAPI.Models;
using SampleAPI.Repositories;
using SampleAPI.Requests;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SampleAPI.Tests.Controllers
{
    // [ExcludeFromCodeCoverage]
    public class OrdersControllerTests
    {
        // Add more dependencies as needed.
        private readonly SampleApiDbContext _sampleApiDbContext;
        private readonly IUnitOfWork UnitOfWork;
      
        public OrdersControllerTests()
        {
            _sampleApiDbContext = new SampleApiDbContext();
            UnitOfWork = new UnitOfWork(_sampleApiDbContext);
        }

        // TODO: Write controller unit tests
        [Fact]
        public void CreateOrder()
        {
            //arrange
            var newOrder = new TblOrder()
            {
                Id = Guid.NewGuid(),
                ProductName = "Mobile",
                OrderQty = 10,
                TotalPrice = (decimal)120.00,
                IsInvoiced = true,
                IsDeleted = false,
                CreatedDate = DateTime.Today,
                UpdatedDate = null,
                Description = "Description",
                IsActive = true,
            };
            //Act
            var order = UnitOfWork.OrderRepository.AddEntity(newOrder);
            //assert
            Assert.NotNull(order);
        }
        [Fact]
        public void UpdateOrder()
        {
            //arrange
            var UpdateOrder = new TblOrder();
            var newOrder = new TblOrder()
            {
                Id = Guid.NewGuid(),
                ProductName = "Mobile",
                OrderQty = 10,
                TotalPrice = (decimal)120.00,
                IsInvoiced = true,
                IsDeleted = false,
                CreatedDate = DateTime.Today,
                UpdatedDate = null
            };
            //Act
            UpdateOrder = newOrder;
            UpdateOrder.ProductName = "Laptop";
            UpdateOrder.UpdatedDate = DateTime.Today;
            var data = UnitOfWork.OrderRepository.UpdateEntity(UpdateOrder);
            //assert
            Assert.Equal(newOrder.Id, UpdateOrder.Id);
            Assert.NotNull(data);
        }
        [Fact]
        public void GetOrder()
        {

        }
    }
}
