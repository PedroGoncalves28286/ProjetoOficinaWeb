using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
