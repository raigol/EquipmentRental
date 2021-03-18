using AutoMapper;
using EquipmentRental.Api.Dto;
using EquipmentRental.Data;
using EquipmentRental.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EquipmentRental.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceController(IMapper mapper)
        {
            _mapper = mapper;
            _invoiceRepository = new InvoiceRepository(new EquipmentRentalContext());
        }

        [HttpGet("/[controller]/{customerId}", Name = "Customer Invoices")]
        public IEnumerable<InvoiceDto> GetInvoices(int customerId)
        {
            var invoices = _invoiceRepository.GetCustomerInvoices(customerId);
            IEnumerable<InvoiceDto> invoiceDto = _mapper.Map<InvoiceDto[]>(invoices);
            return invoiceDto;
        }

        [HttpGet("/[controller]/LoyaltyPoints/{customerId}", Name = "Customer Loyalty Points")]
        public int GetLoyaltyPoints(int customerId)
        {
            return _invoiceRepository.GetCustomerLoyaltyPoints(customerId);            
        }

        [HttpGet("/[controller]/details/{invoiceId}", Name = "Invoice details")]
        public InvoiceDetailDto GetInvoiceDetails(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoiceDetails(invoiceId);
            InvoiceDetailDto invoiceDto = _mapper.Map<InvoiceDetailDto>(invoice);
            return invoiceDto;
        }


    }
}
