using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HomeBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                API.HomeBook.UploadFile(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
    }
}