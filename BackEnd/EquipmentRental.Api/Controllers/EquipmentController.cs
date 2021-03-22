using AutoMapper;
using EquipmentRental.Api.Dto;
using EquipmentRental.Data;
using EquipmentRental.Data.Domain;
using EquipmentRental.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EquipmentRepository _equipmentRepository;
        private readonly EquipmentRentalContext _context;

        public EquipmentController(IMapper mapper, EquipmentRentalContext context)
        {
            _mapper = mapper;
            _context = context;
            _equipmentRepository = new EquipmentRepository(_context);
        }


        [HttpGet]
        public IEnumerable<EquipmentDto> GetEquipments()
        {
            var equipments = _equipmentRepository.GetEquipments();
            IEnumerable<EquipmentDto> equipmentDto = _mapper.Map<EquipmentDto[]>(equipments);
            return equipmentDto;
        }

        [HttpGet("/[controller]/{equipmentId}", Name = "Equipment details")]
        public EquipmentDto GetEquipmentById(int equipmentId)
        {
            var equipment = _equipmentRepository.GetEquipmentById(equipmentId);
            EquipmentDto equipmentDto = _mapper.Map<EquipmentDto>(equipment);
            return equipmentDto;
        }

    }
}
