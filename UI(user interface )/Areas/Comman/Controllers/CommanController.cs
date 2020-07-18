using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL_business_object_layer_;
using DAL_data_access_layer_;

namespace UI_user_interface__.Areas.Comman.Controllers
{
    [AllowAnonymous]
    public class CommanController : Controller
    {

        ContactUsDB ContactUsDB_Obj = new ContactUsDB();

        PackagesDB PackagesDB_Obj = new PackagesDB();

        MyTripDB MyTrip_Obj = new MyTripDB();

        MemberShipDB Membership_Obj = new MemberShipDB();

        GuideDB GuideDB_Obj = new GuideDB();

        HotelsDB HotelsDB_Obj = new HotelsDB();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }






        [HttpGet]
        public ActionResult Packages()
        {

            

            var PackagesList = PackagesDB_Obj.GetAll();
            return View(PackagesList);

          
        }


        [HttpGet]
        public ActionResult PackagesDetail(int Packages_Id)
        {

            var Packages = PackagesDB_Obj.GetById(Packages_Id);

            return View(Packages);


        }







        [HttpGet]
        public ActionResult BookATrip()
        {
            return View();
        }



        [HttpPost]
        public ActionResult BookATrip(tbl_MakeMyTrip Obj)
        {
            MyTrip_Obj.Insert(Obj);

            TempData["SENT"] = "Your Message Sent Successfully";

            return View();
        }




        [HttpGet]
        public ActionResult MemeberShip()
        {
            var MemebershipList = Membership_Obj.GetAll();

            return View(MemebershipList);
        }

        




        [HttpGet]
        public ActionResult Contact()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Contact(tbl_ContactUs obj)
        {
            ContactUsDB_Obj.Insert(obj);

            TempData["SENT"] = "Your Message Sent SuccessFully";

            return View();
        }







        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Guiders()
        {
            var guides =GuideDB_Obj.GetAll();

            return View(guides);

        }


        [HttpGet]
        public ActionResult Hotels()
        {
            var guides = HotelsDB_Obj.GetAll();

            return View(guides);

        }


    }
}