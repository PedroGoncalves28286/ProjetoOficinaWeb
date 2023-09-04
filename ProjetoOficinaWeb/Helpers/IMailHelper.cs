using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IMailHelper
    {
      Response SendEmail(string to, string subject, string body);

    }
}
