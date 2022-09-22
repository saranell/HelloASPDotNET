using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")] //Adding route attribute to entire class so code is DRY
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        //[Route("/helloworld")] -> set at class level so less redundant
        //Welcome() method can respond to a POST request & Index() method can respond to a GET request at the same URL.
        //To make this happen, we change the route in the action attribute in the<form> tag and change the route in the[Route("path")] attribute above the Welcome() method to /helloworld.


        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" + //specifies a post request used for form submission
            //action is the route we are sending info to; we want to send a name from the form to welcome method via conventional routing
            "<input type='text' name='name' />" + //textbox
            "<select name='language' />" +
            "<option value='english' selected>English</option>" +
            "<option value='french'>French</option>" +
            "<option value='spanish'>Spanish</option>" +
            "<option value='german'>German</option>" +
            "<option value='japanese'>Japanese</option></select>" +
            "<input type='submit' value='Call me by my name' />" + //button
            "</form>"; // closing tag
            return Content(html, "text/html");
        }

        //GET: /hello/welcome
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]

        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
        //[Route("/helloworld/")] -> see comment on line 17
        public IActionResult Welcome(string name = "World")
        {
            return Content("<h1>Welcome to my app " + name + "!</html>", "text/html");
        }

        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name="World" , string language = "english")
        {
            return Content(CreateMessage(name, language));
        }
        public static string CreateMessage(string name, string language)
        {
            string helloTranslate = "";
            switch (language)
            {
                case "french":
                    helloTranslate = "Bonjour";
                    break;
                case "spanish":
                    helloTranslate = "Hola";
                    break;
                case "german":
                    helloTranslate = "Guten Tag";
                    break;
                case "japanese":
                    helloTranslate = "こんにちは\nKon'nichiwa";
                    break;
            }
            return helloTranslate + name;
        }
    }
}

