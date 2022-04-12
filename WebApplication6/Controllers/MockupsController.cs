using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication6.Controllers
{
    public class MockupsController : Controller
    {
        private readonly ILogger<MockupsController> _logger;

        public MockupsController(ILogger<MockupsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult PassReset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PassReset(Data User, string action)
        {
            if (ModelState["Email"].ValidationState == ModelValidationState.Valid)
            {
                if (action == "Send me a code")
                {
                    ViewBag.Code = "Your code: " + User.Code;
                    return View(User);
                    
                }
                return Redirect("Confirm");
            }
            return View();
        }

        public IActionResult Confirm(string value)
        {
            Data User = new Data();
            if (Request.Method == "POST")
            {
                if ((User.Code).ToString() == value)
                    ViewBag.Check = "You can Reset your Password";
                else
                    ViewBag.Check = "Wrong code";
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Data inf)
        {
            Data a = new Data();
            if (ModelState["FirstName"].ValidationState == ModelValidationState.Valid &
                ModelState["LastName"].ValidationState == ModelValidationState.Valid &
                ModelState["Gender"].ValidationState == ModelValidationState.Valid)
                return RedirectToAction("SignUpPrt2", inf);
            return View();
        }
        [HttpGet]
        public IActionResult SignUpPrt2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUpPrt2(Data inf)
        {

            if (ModelState["Email"].ValidationState == ModelValidationState.Valid &
                ModelState["Password"].ValidationState == ModelValidationState.Valid &
                ModelState["ComparePassword"].ValidationState == ModelValidationState.Valid)
                return View("Result",inf);
                
            return View();
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}