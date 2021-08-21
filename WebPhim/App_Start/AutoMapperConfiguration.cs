using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPhim.App_Start
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var Config = new MapperConfiguration(c =>
           {
               c.AddProfile<MappingProfile>();
           });
            return Config;
        }
        //NOTE: Sau khi MappingProfile đã sẵn sàng, ta khởi tạo để sử dụng
    }
}