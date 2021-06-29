using AutoMapper;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.WebAPI.Models;


namespace SeyahatRehberi.WebAPI.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ArticleAddModel, Article>();
            CreateMap<Article, ArticleAddModel>();

         

            
        }
    }
}
