using AutoMapper;
using EquipmentRental.Api.Dto;
using EquipmentRental.Api.Services;
using EquipmentRental.Data.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EquipmentRental.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper)
        {
            _orderService = new OrderService();
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateOrder(List<OrderItemDto> orderItems)
        {
            Invoice invoice = _orderService.ProcessOrder(orderItems);
            InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return Ok(invoiceDto);
        }
    }
}
