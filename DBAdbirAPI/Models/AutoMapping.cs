using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBAdbir.Models;
using DBAdbir.Models.ViewModels;

namespace DBAdbirAPI.Models
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        { 
            CreateMap<DBAdbir.Models.Item, ItemVM > ();
        }
    }
}
