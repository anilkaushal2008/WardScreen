using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WardScreen.Models;
using System.Linq;
    
namespace WardScreen.Controllers
{
    public class ForthICUController : Controller
    {
        private readonly IHMSContext Entity;
        private readonly IConfiguration _configurationBuilder;
        public ForthICUController(IHMSContext ihmscontext, IConfiguration configurationBuilder)
        {
            Entity = ihmscontext;
            _configurationBuilder = configurationBuilder;
        }
        public ActionResult Screen()
        {
            return View();
        }       
        public ActionResult Index(string id)
        {
                 
            //string getWard = "PRIVATE ROOM";
            List<spScreenGetWardResult> selectedlist = new List<spScreenGetWardResult>();
            string Floor = id.ToString();
            //_configurationBuilder.GetSection("ConnectionStrings").GetSection("Ward").Value;
            selectedlist = Entity.Procedures.spScreenGetWardAsync(Floor).Result.ToList();
            if (selectedlist.Count() != 0)
            {
                return View(selectedlist);
            }
            else
            {
                return View(selectedlist);
            }  
            
        }
        public ActionResult BootstrapIndex()
        {
            //string getWard = "PRIVATE ROOM";
            List<spScreenGetWardResult> selectedlist = new List<spScreenGetWardResult>();
            string wards = _configurationBuilder.GetSection("ConnectionStrings").GetSection("Ward").Value;
            selectedlist = Entity.Procedures.spScreenGetWardAsync(wards).Result.ToList();
            if (selectedlist.Count() != 0)
            {
                return View(selectedlist);
            }
            else
            {
                return View(selectedlist);
            }
        }
    }
}
