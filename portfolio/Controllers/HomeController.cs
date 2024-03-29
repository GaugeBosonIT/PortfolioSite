﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using portfolio.Models;
using System.Configuration;
using System.Net.Mail;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        public string username = ConfigurationManager.AppSettings["username"].ToString();
        public string password = ConfigurationManager.AppSettings["password"].ToString();
        public string SmtpClient = ConfigurationManager.AppSettings["SmtpClient"].ToString();
        public string FromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
        public string EmailSubject = ConfigurationManager.AppSettings["EmailSubject"].ToString();
            
        
       
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            ViewBag.PageTitle = "Build your vision in 6 sprints.";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.PageTitle = "About. Your questions answered.";
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.PageTitle = "Services.";
            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.PageTitle = "Projects.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.PageTitle = "Contact";
            ViewBag.MessageStatus = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact m)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(SmtpClient);
            mail.From = new MailAddress(FromAddress);
            mail.To.Add(FromAddress);
            mail.Subject = m.Email + " -- " + m.Name;
            mail.Body = m.Message;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            ViewBag.PageTitle = "Contact";
            ViewBag.MessageStatus = "Thanks! We will be in touch.";
            return View();
        }
     
    }
}
