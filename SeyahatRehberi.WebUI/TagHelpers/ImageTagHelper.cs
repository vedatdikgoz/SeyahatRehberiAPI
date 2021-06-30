using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SeyahatRehberi.WebUI.Enums;
using SeyahatRehberi.WebUI.Services.Abstract;


namespace SeyahatRehberi.WebUI.TagHelpers
{
    [HtmlTargetElement("getarticleimage")]
    public class ImageTagHelper:TagHelper
    {
        private readonly IPhotoApiService _photoApiService;
        public ImageTagHelper(IPhotoApiService photoApiService)
        {
            _photoApiService = photoApiService; 
        }
        public int Id { get; set; }
        public ArticleImageType ArticleImageType { get; set; } = ArticleImageType.ArticleHome; 

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob= await _photoApiService.GetArticleImageByIdAsync(Id);

            string html=string.Empty;
            if (ArticleImageType == ArticleImageType.ArticleHome)
            {
                html = $"<img src='{blob}' class='card-img-top'/>";
            }
            else
            {
                html = $"<img src='{blob}' class='img-fluid rounded'/>";
            }
            output.Content.SetHtmlContent(html);
        }
    }
}
