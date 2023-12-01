using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;
using SampleAPI.Models;
using SampleAPI.Requests;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Entity;


namespace SampleAPI.Repositories
{
    public class OrderRepository : GenericRepository<TblOrder>, IOrderRepository
    {
        /// <summary>
        /// OrderRepository Constructor
        /// </summary>
        /// <param name="sampleApiDbContext"></param>
        public OrderRepository(SampleApiDbContext sampleApiDbContext) : base(sampleApiDbContext)
        {
        }
        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>Task<List<TblOrder>></returns>
        public override IEnumerable<TblOrder> GetAllAsync()
        {
            try
            {
                var data = table.ToList();
                return data;
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// AddEntity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public override async Task<bool> AddEntity(TblOrder entity)
        {
            try
            {
                await table.AddAsync(entity);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// UpdateEntity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public override async Task<bool> UpdateEntity(TblOrder entity)
        {
            try
            {
                var existdata = await table.FirstOrDefaultAsync(item => item.Id == entity.Id);
                if (existdata != null)
                {

                    existdata.ProductName = entity.ProductName;
                    existdata.OrderQty = entity.OrderQty;
                    existdata.TotalPrice = entity.TotalPrice;
                    existdata.IsInvoiced = entity.IsInvoiced;
                    existdata.IsDeleted = entity.IsDeleted;
                    existdata.UpdatedDate = entity.UpdatedDate;
                    existdata.Description = entity.Description;
                    existdata.IsActive = entity.IsActive;
                    table.Update(existdata);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
