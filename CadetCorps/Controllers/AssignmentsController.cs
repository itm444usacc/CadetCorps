﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadetCorps.Controllers
{
    public class AssignmentsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Assignments Contoller.";

            return View("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }
    }
}
