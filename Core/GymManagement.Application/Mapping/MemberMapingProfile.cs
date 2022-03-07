using AutoMapper;
using AutoMapper.Execution;
using GymManagement.Application.ViewModels.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Mapping
{
    public class MemberMapingProfile : Profile
    {
        public MemberMapingProfile()
        {
            CreateMap<Member, MemberRegisterViewModel>().ReverseMap();
            CreateMap<Member, MemberLoginViewModel>().ReverseMap();
        }
            
    }
}
