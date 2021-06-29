using System.Threading.Tasks;

namespace SeyahatRehberi.WebUI.Services.Abstract
{
    public interface IPhotoApiService
    {
        Task<string> GetArticleImageByIdAsync(int id);
    }
}
