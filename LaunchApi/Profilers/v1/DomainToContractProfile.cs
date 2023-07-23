using AutoMapper;

namespace LaunchApi.Profilers.v1
{
    public class DomainToContractProfile : Profile
    {
        public DomainToContractProfile()
        {
            CreateMaps();
        }

        public void CreateMaps()
        {
            CreateMap<Domain.Models.PagedResult<Domain.Models.Launch>,
                Contracts.v1.Transport.Responses.PagedResult<Contracts.v1.Transport.Models.Launch>>()
                .ForMember(x => x.PageNumber, options => options.MapFrom(y => y.Page))
                .ForMember(x => x.PageSize, options => options.MapFrom(y => y.Limit))
                .ForMember(x => x.Items, options => options.MapFrom(y => y.Docs))
                .ForMember(x => x.Total, options => options.MapFrom(y => y.TotalDocs))
                .ForMember(x => x.TotalPages, options => options.MapFrom(y => y.TotalPages))
                .ForMember(x => x.HasPreviousPage, options => options.MapFrom(y => y.HasPrevPage))
                .ForMember(x => x.HasNextPage, options => options.MapFrom(y => y.HasNextPage));

            CreateMap<Domain.Models.Launch, Contracts.v1.Transport.Models.Launch>();
            CreateMap<Domain.Models.Links, Contracts.v1.Transport.Models.Links>();
            CreateMap<Domain.Models.Patch, Contracts.v1.Transport.Models.Patch>();
            CreateMap<Domain.Models.Reddit, Contracts.v1.Transport.Models.Reddit>();
            CreateMap<Domain.Models.Flickr, Contracts.v1.Transport.Models.Flickr>();
        }
    }
}
