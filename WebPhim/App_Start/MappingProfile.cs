using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPhim.Dtos;
using WebPhim.Models;

namespace WebPhim.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
        //NOTE:
        //Class MappingProfile thừa kế từ class base Profile.
        //Constructor gọi phương thức CreateMap() nó chỉ định
        //kiểu nguồn và đích để ánh xạ với nhau.Trong trường
        //hợp này Customer là nguồn và CustomerDto là đích.
    }
}