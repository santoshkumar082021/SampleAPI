using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using SampleAPI.Models;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Tests.Repositories
{
    public class OrderRepositoryTests 
    {
        private readonly Mock<IGenericRepository<TblOrder>> service;
        public OrderRepositoryTests()
        {
            service = new Mock<IGenericRepository<TblOrder>>();
        }

        // TODO: Write repository unit tests
        public Task<bool> AddEntity(TblOrder entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TblOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TblOrder> GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(TblOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}