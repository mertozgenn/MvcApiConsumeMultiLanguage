using Microsoft.AspNetCore.Mvc;
using UI.Utils.Restsharp;
using UI.Utils.Results;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            DataResult<string> apiResult;
            try
            {
                apiResult = RestsharpHelper.Get<DataResult<string>>("https://localhost:7292/api", "home/TestLanguage");
            }
            catch (Exception e)
            {
                apiResult = new DataResult<string>(null, false, e.Message);
            }
            return View(apiResult);
        }
    }
}