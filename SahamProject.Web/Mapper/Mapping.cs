﻿using AutoMapper;
using SahamProject.Web.Models;
using SahamProject.Web.ViewModels;

namespace SahamProject.Web.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            #region Shipment
            CreateMap<Shipment, ShipmentVM>().
                 ForMember(x => x.CustomersId, a => a.MapFrom(e => e.CustomerId)).
                 ForMember(x=> x.StatusId, a=> a.MapFrom(e=> e.StatusId)).
                 ForMember(x => x.Customers, a => a.Ignore()).
                 ForMember(x => x.Status, a => a.Ignore()).
                 ReverseMap();
            #endregion
        }
    }
}