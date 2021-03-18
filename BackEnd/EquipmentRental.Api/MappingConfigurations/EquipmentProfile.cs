using AutoMapper;
using EquipmentRental.Api.Dto;
using EquipmentRental.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Api.MappingConfigurations
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {            
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<Invoice, InvoiceDto>();

            CreateMap<Invoice, InvoiceDetailDto>()
                .ForMember(d => d.InvoiceRows, o => o.MapFrom(s => s.InvoiceRows));


            CreateMap<InvoiceRow, InvoiceRowDto>();

        }
    }
}
