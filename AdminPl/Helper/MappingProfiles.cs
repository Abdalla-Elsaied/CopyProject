using AdminPl.ViewModel;
using AutoMapper;
using DAL;

namespace AdminPl.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {

            CreateMap<CompanyVm, Company>().ReverseMap();

            CreateMap<Admin, AdminVM>().ReverseMap();

            CreateMap<Company, CompanyDetailsVM>().ReverseMap();
        }

    }
}
