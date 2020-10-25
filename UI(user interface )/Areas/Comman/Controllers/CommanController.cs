using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

        ItemsDB ItemsDB_Obj = new ItemsDB();

        CrawelCustomModel CrawelCustomModel_Obj = new CrawelCustomModel();
        

        tbl_MakeMyTrip tbl_Obj = new tbl_MakeMyTrip();


        Hotle_Images_Custom_Model hotle_Images_Custom_Model_Obj = new Hotle_Images_Custom_Model();

        //itmeModelForCheckBox itmeModelForCheckBox_Obj = new itmeModelForCheckBox();


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
        public ActionResult BookATrip(int Guider_Id = 0 , int Hotel_Id = 0 , int Packages_Id =0) 
        {
            //CREATING LISTS


            var ItemList = ItemsDB_Obj.GetAll();

            tbl_Obj.ItemList = new SelectList(ItemList, "ID", "Name");




            var PackageList = PackagesDB_Obj.GetAll();
      
            tbl_Obj.PackageList = new SelectList(PackageList, "ID", "PackageName", PackageList.Where(x => x.ID == Packages_Id).Select(item => item.ID).SingleOrDefault());



       


            var HotelsList = HotelsDB_Obj.GetAll();
            // here on the basis of id we are selecting the selected item by user in drowp down list
            tbl_Obj.HotelList = new SelectList(HotelsList, "ID", "Name", HotelsList.Where(x => x.ID == Hotel_Id).Select(item => item.Name).SingleOrDefault());





            var GuideList = GuideDB_Obj.GetAll();
            // here on the basis of id we are selecting the selected item by user in drowp down list
            tbl_Obj.GuideList = new SelectList(GuideList, "ID", "Name", GuideList.Where(x => x.ID == Guider_Id).Select(item => item.ID).SingleOrDefault());



         


            return View(tbl_Obj);

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

                    //SENDING EMAIL TO CUSTOMER , sending emails using gmail you have to turn on => allow less sucre app to access this mail
                    string from = "alihaiderwm15@gmail.com";
                    string to = "alihaiderwm15@gmail.com"; /* = Obj.Email*/
                    MailMessage MailMessage = new MailMessage(from , to);
                    MailMessage.Subject = "Package Request";
                    MailMessage.Body = "Your Package Request has been delivered to Our Team , Someone From Our Team Will Be In Touch Soon";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Send(MailMessage);





                }
            }
            catch (Exception e)
            {

                TempData["FAILED"] = e.Message;
            }

            var ItemList = ItemsDB_Obj.GetAll();

            Obj.ItemList = new SelectList(ItemList, "ID", "Name");



            var PackageList = PackagesDB_Obj.GetAll();

            Obj.PackageList = new SelectList(PackageList, "ID", "PackageName");





            var HotelsList = HotelsDB_Obj.GetAll();

            Obj.HotelList = new SelectList(HotelsList, "ID", "Name");





            var GuideList = GuideDB_Obj.GetAll();

            Obj.GuideList = new SelectList(GuideList, "ID", "Name");

            return View(Obj);
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
            var Hotels = HotelsDB_Obj.GetAll();

            return View(Hotels);

        }






        [HttpGet]
        public ActionResult Hotels2()
        {
            var Hotels_info = HotelsDB_Obj.GetAllWithImages();

            return View(Hotels_info);
  

        }


        [HttpGet]
        public ActionResult Hotels2Details(int Hotel_Id)
        {
           

            var Hotels_info = HotelsDB_Obj.GetByIdWithImages(Hotel_Id);

            hotle_Images_Custom_Model_Obj.Name = Hotels_info[0].Name;
            hotle_Images_Custom_Model_Obj.Location = Hotels_info[0].Location;
            hotle_Images_Custom_Model_Obj.Gov_License = Hotels_info[0].Gov_License;
            hotle_Images_Custom_Model_Obj.Standard = Hotels_info[0].Standard;
            hotle_Images_Custom_Model_Obj.Charges = Hotels_info[0].Charges;

            foreach(var item in Hotels_info)
            {
             
                hotle_Images_Custom_Model_Obj.Images.Add(new ImagePath() { Images = item.ImagePath });

      
            }

            return View(hotle_Images_Custom_Model_Obj);


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

                    name = Regex.Replace(name, "&#8211;", "&");

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
           
                string path = @"C:\Users\Ali\Desktop\desktop data\visual studio\TourAgencyProject\UI(user interface )\Imges_Crawel";
                if (!string.IsNullOrEmpty(path))
                {
                    var extensions = new string[] { ".png", ".jpg", ".gif" };
                    try
                    {
                        var di = new DirectoryInfo(path);
                        var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                        Random R = new Random();
                        file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;

                        file = file.Replace(@"C:\Users\Ali\Desktop\desktop data\visual studio\TourAgencyProject\UI(user interface )", "");

                        CrawelCustomModel_Obj.ImagesList.Add(new ImageModel() { Images = file });
                }
                 
                    catch(Exception ) { }
                }
                
              }

            ViewBag.Counter = Counter;

            return View(CrawelCustomModel_Obj);
        }

    }




}