using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;
using SampleAPI.Repositories;
using SampleAPI.Requests;
using System.Collections.Generic;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        // Add more dependencies as needed.
        private readonly IUnitOfWork unitOfWork;
        /// <summary>
        /// Injecting IUnitOfWork in constructor using DI
        /// </summary>
        /// <param name="Work"></param>
        public OrdersController(IUnitOfWork Work)
        {
            this.unitOfWork = Work;
        }
        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        [HttpGet("")] // TODO: Change route, if needed.
        public async Task<IActionResult> GetAllOrders()
        {
            var data = unitOfWork.OrderRepository.GetAllAsync().ToList();
            return Ok(data);
        }
        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="tblOrder"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(TblOrder tblOrder)
        {
            var _data = await this.unitOfWork.OrderRepository.AddEntity(tblOrder);
            await this.unitOfWork.CompleteAsync();
            return Ok(_data);
        }
        /// <summary>
        /// Updating Order
        /// </summary>
        /// <param name="tblOrder"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(TblOrder tblOrder)
        {
            var _data = await this.unitOfWork.OrderRepository.UpdateEntity(tblOrder);
            await this.unitOfWork.CompleteAsync();
            return Ok(_data);
        }
    }
}
