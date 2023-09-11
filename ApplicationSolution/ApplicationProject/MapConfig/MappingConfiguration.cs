using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationProject.Models;
using AutoMapper;

namespace ApplicationProject.MapConfig
{
    public class MappingConfiguration
    {
        public static Mapper InitializeAutoMapper()
        {
            var configuration = new MapperConfiguration(cfgn =>
            {
                cfgn.CreateMap<OrderDTO, Order>();
                cfgn.CreateMap<ClientDTO, Client>();
            });

            var mapper = new Mapper(configuration);
            return mapper;
        }
    }
}