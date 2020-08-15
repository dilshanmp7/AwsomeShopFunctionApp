using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AwsomeShop.AzureQueueLibrary.Message;
using AwsomeShop.AzureQueueLibrary.QueueConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AwsomeShop.WebApp.Models;

namespace AwsomeShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueueCommunicator _queueCommunicator;

        public HomeController(IQueueCommunicator queueCommunicator)
        {
            _queueCommunicator = queueCommunicator;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult ContactUs()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(string contactName,string emailAddress)
        {
            // send Thankyou email to contact
            var thankYouEmail=new SendEmailCommand()
            {
                To=emailAddress,
                Subject = "Thank you for reaching out",
                Body = "we will contact you shortly"
            };

            await _queueCommunicator.SendAsync(thankYouEmail);

            // send new contact email to admin 
            var adminEmailCommand = new SendEmailCommand()
            {
                To = "dilshanmp7@gmail.com",
                Subject = "New Contact",
                Body = $"{contactName} has reached out via contact form. Please respond back at {emailAddress}"
            };

            await _queueCommunicator.SendAsync(adminEmailCommand);

            ViewBag.Message = "Thank you we've recived your message =)";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
