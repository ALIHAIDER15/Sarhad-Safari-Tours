using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BOL_business_object_layer_;
using DAL_data_access_layer_;
using Mixed_Models;

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

        CrawelCustomModel CrawelCustomModel_Obj = new CrawelCustomModel();

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
            try
            {
                if (ModelState.IsValid)
                {
                    MyTrip_Obj.Insert(Obj);

                    TempData["SENT"] = "Your Message Sent Successfully";
                }
            }
            catch (Exception e)
            {

                TempData["SENT"] = "Your Message Sent Successfully" + e.Message;
            }


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
            try
            {
                if (ModelState.IsValid)
                {
                    ContactUsDB_Obj.Insert(obj);

                    TempData["SENT"] = "Your Message Sent SuccessFully";
                }
            }
            catch (Exception e)
            {

                TempData["SENT"] = "Your Message Sent SuccessFully" + e.Message;
            }


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
            var guides = GuideDB_Obj.GetAll();

            return View(guides);

        }


        [HttpGet]
        public ActionResult Hotels()
        {
            var guides = HotelsDB_Obj.GetAll();

            return View(guides);

        }












        [HttpGet]
        public ActionResult CompareTrips()
        {

            CrawelCustomModel CrawelCustomModel_Obj = new CrawelCustomModel();

            CrawelCustomModel_Obj.Packages = PackagesDB_Obj.GetAll();



            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.saiyah.com.pk/tour/");


            // Counter is leye liya hai k title zeyada or numb of days kam a rai thay to jitne NumOfDay ai usko counter mai dal kr us ki base pr title fetch hon
            //or yehi chez pe view k lop mai bhi use hui hai k k hmri web k packges and dsuir web k packges same hon or view distrub na ho
            int Counter = 0;


            //FETCHING NUMBER OF DAYS
            foreach (var item in doc.DocumentNode.SelectNodes("  //*[@class='tourmaster-tour-info tourmaster-tour-info-duration-text '] "))
            {
                try
                {
                    string NumOfDay = item.InnerText;

                    NumOfDay = Regex.Replace(NumOfDay, "&#038;", "&");

                    CrawelCustomModel_Obj.NumOfDayList.Add(new NumOfDay() { NumOfDays = NumOfDay });


                    Counter = CrawelCustomModel_Obj.NumOfDayList.Count();

                }
                catch (Exception e)
                {

                    TempData["CrawelError"]= "There is error in fetching data from the other website" + e.Message;
                }

            }


            //FETCHING TITLE
            for(int i = 0; i< Counter; i++)
            {
                try
                {
                    var item = doc.DocumentNode.SelectNodes("//*[@class='tourmaster-tour-title gdlr-core-skin-title']")[i];

                    string name = item.InnerText;

                    name = Regex.Replace(name, "&#038;", "&");

                    CrawelCustomModel_Obj.NameList.Add(new Name() { names = name });
                
                }
                catch (Exception e)
                {
                    TempData["CrawelError"] = "There is error in fetching data from the other website" + e.Message;
                }


            }

            //FETCHING Months
            for (int i = 0; i < Counter; i++)
            {
                try
                {

                    var item = doc.DocumentNode.SelectNodes("//*[@class='tourmaster-tour-info tourmaster-tour-info-availability ']  ")[i];

                    string Months = item.InnerText;

                    Months = Regex.Replace(Months, "Availability :", "");

                    CrawelCustomModel_Obj.MonthsList.Add(new Month() { Months = Months });

                }
                catch (Exception e)
                {
                    TempData["CrawelError"] = "There is error in fetching data from the other website" + e.Message;
                }

            }



            //FETCHING Random Images form folder
            for (int i = 0; i < Counter; i++)
            {
                string file = null;
                string path = @"C:\Users\adasd\Desktop\visual studio\TourAgencyProject\UI(user interface )\Imges_Crawel";
                if (!string.IsNullOrEmpty(path))
                {
                    var extensions = new string[] { ".png", ".jpg", ".gif" };
                    try
                    {
                        var di = new DirectoryInfo(path);
                        var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                        Random R = new Random();
                        file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;

                        file = file.Replace(@"C:\Users\adasd\Desktop\visual studio\TourAgencyProject\UI(user interface )", "");

                        CrawelCustomModel_Obj.ImagesList.Add(new ImageModel() { Images = file });
                }
                 
                    catch(Exception e) { }
                }
                
              }

            ViewBag.Counter = Counter;

            return View(CrawelCustomModel_Obj);
        }

    }




}