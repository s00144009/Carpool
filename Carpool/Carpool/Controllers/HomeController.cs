using Carpool.Models;
using Geocoding;
using Geocoding.Google;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Carpool.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home(string option, string search, string sortOrder, string searchString)
        {
            var _lifts = from l in db.Lifts select l;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            //if a user choose the radio button option as Subject  
            IQueryable<Lift> lifts = db.Lifts;
            string currentUserId = User.Identity.GetUserId();
            var UserEmail = User.Identity.GetUserName();

            //if current user = null redirect to login page
            if (currentUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bool driverRole = User.IsInRole("Driver");
            if (driverRole == true)
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        _lifts = _lifts.OrderByDescending(l => l.StartPoint);
                        break;
                    case "Date":
                        _lifts = _lifts.OrderBy(l => l.LiftDate);
                        break;
                    case "date_desc":
                        _lifts = _lifts.OrderByDescending(l => l.LiftDate);
                        break;
                    default:
                        _lifts = _lifts.OrderBy(l => l.StartPoint);
                        break;
                }
                ViewBag.userType = 0;
                return View(lifts.Where(x => x.UserEmailAddress == UserEmail).ToList());
            }
            else
            {

                ViewBag.userType = 1;
                if (option == "StartPoint")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    return View(db.Lifts.Where(x => x.StartPoint.Contains(search) || search == null).ToList());
                }
                else if (option == "EndPoint")
                {
                    return View(db.Lifts.Where(x => x.EndPoint.Contains(search) || search == null).ToList());
                }
                else if (option == "LiftDate")
                {

                    DateTime searchDate;
                    if (DateTime.TryParse(search, out searchDate))
                    {
                        lifts = db.Lifts.Where(x => x.LiftDate == searchDate);
                        // do not use .Equals() which can not be converted to SQL
                    }
                    return View(lifts);
                }
                else
                {
                    return View(lifts.ToList());
                }

                
            }

        }


        public ActionResult ViewWeeklyLifts(string option, string search)
        {
            IQueryable<WeeklyLift> weeklylifts = db.weeklyLifts;
            //Get the currentely logged in user
            string currentUserId = User.Identity.GetUserId();
            var UserEmail = User.Identity.GetUserName();

            //if current user = null redirect to login page
            if (currentUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            bool driverRole = User.IsInRole("Driver");
            if (driverRole == true)
            {
                ViewBag.userType = 0;
                return View(weeklylifts.Where(x => x.UserEmailAddress == UserEmail).ToList());
            }
            else
            {
                ViewBag.userType = 1;
                if (option == "StartPoint")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    return View(db.weeklyLifts.Where(x => x.StartPoint.Contains(search) || search == null).ToList());
                }
                else if (option == "EndPoint")
                {
                    return View(db.weeklyLifts.Where(x => x.EndPoint.Contains(search) || search == null).ToList());
                }
                else
                {
                    return View(weeklylifts.ToList());
                }
            }
        }

        public ActionResult OfferWeeklyLift()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyLift lift = db.weeklyLifts.Find(id);
            if (lift == null)
            {
                return HttpNotFound();
            }
            return View(lift);
        }
        public ActionResult WeeklyLiftList()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfferWeeklyLift([Bind(Include = "LiftID,StartPoint,EndPoint,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunda,OutboundStartTime,OutboundEndTime,InboundStartTime,InboundEndTime,DifferentTimes,MondayStartTime,MondayEndTime,TuesdayStartTime,TuesdayEndTime,WednesdayStartTime,WednesdayEndTime,ThursdayStartTime,ThursdayEndTime,FridayStartTime,FridayEndTime,SaturdayStartTime,SaturdayEndTime,SundayStartTime,SundayEndTime,Description")] WeeklyLift weeklyLift)
        {

            string currentUserId = User.Identity.GetUserId();
            weeklyLift.UserId = currentUserId;

            var email = User.Identity.GetUserName();
            weeklyLift.UserEmailAddress = email;


            if (ModelState.IsValid)
            {
                db.weeklyLifts.Add(weeklyLift);
                db.SaveChanges();
                return RedirectToAction("ViewWeeklyLifts");
            }

            return View(weeklyLift);
        }

        public ActionResult OfferLift()
        {
            return View();
        }

        public ActionResult RequestsSent()
        {
            IQueryable<RequestLift> requestLift = db.requestLifts;
            //var email = User.Identity.GetUserName();
            var UserEmail = User.Identity.GetUserName();

            return View(requestLift.Where(x => x.PassengerEmail == UserEmail).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfferLift([Bind(Include = "LiftID,StartPoint,EndPoint,LiftDate,OutboundStartTime,OutboundEndTime,InboundStartTime,InboundEndTime,OneWayLift,LiftType,Description")] Lift lift)
        {
            var email = User.Identity.GetUserName();
            lift.UserEmailAddress = email;
            string currentUserId = User.Identity.GetUserId();
            lift.UserId = currentUserId;
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ModelState.Remove("InboundStartTime");
            ModelState.Remove("InboundEndTime");
            if (ModelState.IsValid)
            {
                db.Lifts.Add(lift);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(lift);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewLift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lift lift = db.Lifts.Find(id);
            if (lift == null)
            {
                return HttpNotFound();
            }

            IGeocoder geoCode;
            geoCode = new GoogleGeocoder();

            string startPoint = string.Format("{0}", lift.StartPoint);
            string endPoint = string.Format("{0}", lift.EndPoint);

            ViewBag.StartPoint = startPoint;
            ViewBag.EndPoint = endPoint;

            return View(lift);
        }
        public ActionResult ViewWeeklyLift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyLift weeklyLift = db.weeklyLifts.Find(id);
            if (weeklyLift == null)
            {
                return HttpNotFound();
            }

            IGeocoder geoCode;
            geoCode = new GoogleGeocoder();

            string startPoint = string.Format("{0}", weeklyLift.StartPoint);
            string endPoint = string.Format("{0}", weeklyLift.EndPoint);

            ViewBag.StartPoint = startPoint;
            ViewBag.EndPoint = endPoint;

            return View(weeklyLift);
        }
        public ActionResult ViewRequests(int id)
        {
            var UserEmail = User.Identity.GetUserName();
            int requests = db.requestLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;

            var requestLifts = (from r in db.requestLifts
                                where r.DriverId == id && r.bookingStatus == null
                                select r).ToList();

            return View("ViewRequests", requestLifts);
        }

        public ActionResult ViewWeeklyRequests(int id)
        {

            int requests = db.requestWeeklyLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;

            var requestLifts = (from r in db.requestWeeklyLifts
                                where r.DriverId == id && r.bookingStatus == null
                                select r).ToList();

            return View("ViewWeeklyRequests", requestLifts);
        }

        public ActionResult AcceptedRequests(int id)
        {
            int requests = db.requestLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;
            var UserEmail = User.Identity.GetUserName();
            var req = (from r in db.requestLifts
                                where r.DriverId == id && r.bookingStatus == "Accepted" && r.DriverEmail == UserEmail
                                select r).ToList();

            return View("AcceptedRequests", req);
        }

        public ActionResult AcceptedWeeklyRequests(int id)
        {
            var UserEmail = User.Identity.GetUserName();
            int requests = db.requestWeeklyLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;
            var req = (from r in db.requestWeeklyLifts
                                where r.DriverId == id && r.bookingStatus == "Accepted" && r.DriverEmail == UserEmail
                                select r).ToList();

            return View("AcceptedWeeklyRequests", req);
        }

        public ActionResult RejectedRequests(int id)
        {
            var UserEmail = User.Identity.GetUserName();
            int requests = db.requestLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;
            var req = (from r in db.requestLifts
                                where r.DriverId == id && r.bookingStatus == "Rejected" && r.DriverEmail == UserEmail
                                select r).ToList();

            return View("RejectedRequests", req);
        }

        public ActionResult RejectedWeeklyRequests(int id)
        {
            var UserEmail = User.Identity.GetUserName();
            int requests = db.requestWeeklyLifts.Where(x => x.DriverId == id).ToList().Count();
            ViewBag.requests = requests;
            var req = (from r in db.requestWeeklyLifts
                                where r.DriverId == id && r.bookingStatus == "Rejected" && r.DriverEmail == UserEmail
                                select r).ToList();

            return View("RejectedWeeklyRequests", req);
        }

        [HttpGet]
        public ActionResult RequestLiftPartialView()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult WeeklyLiftPartialView()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WeeklyLiftPartialView([Bind(Include = "RequestId,StartPoint,MeetingPoint,EndPoint,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,OutboundTime,InboundTime,PassengerEmail,DriverId,DifferentTimes,MondayStartTime,MondayEndTime,TuesdayStartTime,TuesdayEndTime,WednesdayStartTime,WednesdayEndTime,ThursdayStartTime,ThursdayEndTime,FridayStartTime,FridayEndTime,SaturdayStartTime,SaturdayEndTime,SundayStartTime,SundayEndTime,Description")]RequestWeeklyLift requestWeeklyLift, int id)
        {
            
            if (ModelState.IsValid)
            {
                var selLift = db.weeklyLifts.Find(id);
                var driverEmail = selLift.UserEmailAddress;

                //Set the logged on users email adress to the bookers email address
                var email = User.Identity.GetUserName();
                requestWeeklyLift.PassengerEmail = email;
                db.requestWeeklyLifts.Add(requestWeeklyLift);
                requestWeeklyLift.DriverId = id;
                db.requestWeeklyLifts.Add(requestWeeklyLift);
                db.SaveChanges();

                if (requestWeeklyLift.EmailSent == false)
                {

                    string Link = string.Format("<A HREF=\"http://carpoolirl.azurewebsites.net/Account/Login\" > here</A>");
                    GMailer.GmailUsername = "cpapp8128@gmail.com";
                    GMailer.GmailPassword = "repeat313";

                    GMailer mailer = new GMailer();
                    mailer.ToEmail = driverEmail;
                    mailer.Subject = "Weekly Lift Request";
                    mailer.Body = String.Format("You have a new lift request from {0} for your lift from {1} to {2}. Please login at {3} to see the request and let them know if you Accept or Reject there lift.", requestWeeklyLift.PassengerEmail, requestWeeklyLift.StartPoint, requestWeeklyLift.EndPoint, Link);
                    mailer.IsHtml = true;
                    mailer.Send();
                }
            }

            return RedirectToAction("ViewWeeklyLifts", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestLiftPartialView([Bind(Include = "RequestId,StartPoint,MeetingPoint,EndPoint,OutboundTime,InboundTime,PassengerEmail,DriverId,Description")]RequestLift requestLift, int id)
        {
            if (ModelState.IsValid)
            {
                var selLift = db.Lifts.Find(id);
                var driverEmail = selLift.UserEmailAddress;

                //Set the logged on users email adress to the bookers email address
                var email = User.Identity.GetUserName();
                requestLift.PassengerEmail = email;
                db.requestLifts.Add(requestLift);
                requestLift.DriverId = id;
                db.requestLifts.Add(requestLift);
                db.SaveChanges();

                if (requestLift.EmailSent == false)
                {
                    string Link = string.Format("<A HREF=\"http://carpoolirl.azurewebsites.net/Account/Login\" > here</A>");
                    GMailer.GmailUsername = "cpapp8128@gmail.com";
                    GMailer.GmailPassword = "repeat313";

                    GMailer mailer = new GMailer();
                    mailer.ToEmail = driverEmail;
                    mailer.Subject = "Lift Request";
                    mailer.Body = String.Format("You have a new lift request from {0} for your lift from {1} to {2}. Please login at {3} to see the request let them know if you Accept or Reject there lift.", requestLift.PassengerEmail, requestLift.StartPoint, requestLift.EndPoint, Link);
                    mailer.IsHtml = true;
                    mailer.Send();
                }
            }

            return RedirectToAction("Home", "Home");
        }
        public ActionResult ViewRequest(string Home, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestLift requestLifts = db.requestLifts.Find(id);

            if (requestLifts == null)
            {
                return HttpNotFound();
            }
            Lift lifts = db.Lifts.Find(id);
            string Link = string.Format("<A HREF=\"http://carpoolirl.azurewebsites.net/Account/Login\" > here</A>");
            var selLift = db.requestLifts.Find(id);
            var passengerEmail = selLift.PassengerEmail.ToString();
            var UserEmail = User.Identity.GetUserName();
            if (Home == "Accept")
            {
                requestLifts.DriverEmail = UserEmail;
                requestLifts.bookingStatus = "Accepted";
                db.SaveChanges();
                GMailer.GmailUsername = "cpapp8128@gmail.com";
                GMailer.GmailPassword = "repeat313";

                GMailer mailer = new GMailer();
                mailer.ToEmail = passengerEmail;
                mailer.Subject = "Accepted Lift Request";
                mailer.Body = String.Format("Your lift request from {0} to {1} has been rejected by {2}. Please login here {3} and go to your profile to see your requests and responses.", requestLifts.StartPoint, requestLifts.EndPoint, requestLifts.DriverEmail, Link);
                mailer.IsHtml = true;
                mailer.Send();
                return RedirectToAction("Accepted", "Home");
            }
            else if (Home == "Reject")
            {
                requestLifts.DriverEmail = UserEmail;
                requestLifts.bookingStatus = "Rejected";
                db.SaveChanges();
                GMailer.GmailUsername = "cpapp8128@gmail.com";
                GMailer.GmailPassword = "repeat313";

                GMailer mailer = new GMailer();
                mailer.ToEmail = passengerEmail;
                mailer.Subject = "Rejected Lift Request";
                mailer.Body = String.Format("Your lift request from {0} to {1} has been rejected by {2}. Please login here {3} and go to your profile to see your requests and responses.", requestLifts.StartPoint, requestLifts.EndPoint, requestLifts.DriverEmail, Link);
                mailer.IsHtml = true;
                mailer.Send();
                return RedirectToAction("Rejected", "Home");

                //return RedirectToAction("Index");
            }

            return View(requestLifts);
        }

        public ActionResult Accepted()
        {
            return View();
        }

        public ActionResult Rejected()
        {
            return View();
        }

        public ActionResult WeeklyRequest(string Home, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestWeeklyLift weeklyLifts = db.requestWeeklyLifts.Find(id);

            if (weeklyLifts == null)
            {
                return HttpNotFound();
            }


            var selLift = db.requestWeeklyLifts.Find(id);
            var passengerEmail = selLift.PassengerEmail.ToString();
            //string buttonClicked = SubmitButton;
            var UserEmail = User.Identity.GetUserName();
            if (Home == "Accept")
            {
                weeklyLifts.DriverEmail = UserEmail;
                weeklyLifts.bookingStatus = "Accepted";
                db.SaveChanges();
                GMailer.GmailUsername = "cpapp8128@gmail.com";
                GMailer.GmailPassword = "repeat313";

                GMailer mailer = new GMailer();
                mailer.ToEmail = passengerEmail;
                mailer.Subject = "Lift Request";
                mailer.Body = String.Format("Your lift request from {0} to {1} has been accepted by {2}.", weeklyLifts.StartPoint, weeklyLifts.EndPoint, weeklyLifts.DriverEmail);
                mailer.IsHtml = true;
                mailer.Send();
                return RedirectToAction("Accepted", "Home");
            }
            else if (Home == "Reject")
            {
                weeklyLifts.DriverEmail = UserEmail;
                weeklyLifts.bookingStatus = "Rejected";
                db.SaveChanges();
                GMailer.GmailUsername = "cpapp8128@gmail.com";
                GMailer.GmailPassword = "repeat313";

                GMailer mailer = new GMailer();
                mailer.ToEmail = passengerEmail;
                mailer.Subject = "Lift Request";
                mailer.Body = String.Format("Your lift request from {0} to {1} has been rejected by {2}.", weeklyLifts.StartPoint, weeklyLifts.EndPoint, weeklyLifts.DriverEmail);
                mailer.IsHtml = true;
                mailer.Send();
                return RedirectToAction("Rejected", "Home");

                //return RedirectToAction("Index");
            }

            return View(weeklyLifts);

        }
        public ActionResult DirectRequest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lift lift = db.Lifts.Find(id);
            if (lift == null)
            {
                return HttpNotFound();
            }
            return View(lift);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lift lift = db.Lifts.Find(id);
            if (lift == null)
            {
                return HttpNotFound();
            }
            return View(lift);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Lift lift = db.Lifts.Find(id);
                db.Lifts.Remove(lift);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                return View("DeleteError", new HandleErrorInfo(ex, "Home", "Home"));
            }
        }

        public ActionResult DeleteWeeklyLift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyLift weeklyLift = db.weeklyLifts.Find(id);
            if (weeklyLift == null)
            {
                return HttpNotFound();
            }
            return View(weeklyLift);
        }

        [HttpPost, ActionName("DeleteWeeklyLift")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeeklyLiftConfirmed(int id)
        {
            try
            {
                WeeklyLift weeklyLift = db.weeklyLifts.Find(id);
                db.weeklyLifts.Remove(weeklyLift);
                db.SaveChanges();
                return RedirectToAction("ViewWeeklyLifts");
            }

            catch (Exception ex)
            {
                return View("DeleteError", new HandleErrorInfo(ex, "Home", "ViewWeeklyLifts"));
            }
        }

        public ActionResult DeleteRequest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestLift requestLift = db.requestLifts.Find(id);
            if (requestLift == null)
            {
                return HttpNotFound();
            }
            return View(requestLift);
        }

        [HttpPost, ActionName("DeleteRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRequestConfirmed(int id)
        {
                RequestLift requestLift = db.requestLifts.Find(id);
                db.requestLifts.Remove(requestLift);
                db.SaveChanges();
                return RedirectToAction("Home", "Home");
        }

        public ActionResult DeleteWeeklyRequest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestWeeklyLift requestWeeklyLift = db.requestWeeklyLifts.Find(id);
            if (requestWeeklyLift == null)
            {
                return HttpNotFound();
            }
            return View(requestWeeklyLift);
        }

        [HttpPost, ActionName("DeleteWeeklyRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeeklyRequestConfirmed(int id)
        {
            RequestWeeklyLift requestWeeklyLift = db.requestWeeklyLifts.Find(id);
            db.requestWeeklyLifts.Remove(requestWeeklyLift);
            db.SaveChanges();
            return RedirectToAction("Index", "Manage");
        }

        [HttpGet]
        public ActionResult CollegeLiftPartialView()
        {
            IQueryable<Lift> lifts = db.Lifts;
            return PartialView(lifts.Where(x => x.liftType == Lift.LiftType.College).ToList());
        }

        [HttpGet]
        public ActionResult SportsLiftPartialView()
        {
            IQueryable<Lift> lifts = db.Lifts;
            return PartialView(lifts.Where(x => x.liftType == Lift.LiftType.SportEvents).ToList());
        }
        [HttpGet]
        public ActionResult ShoppingLiftPartialView()
        {
            IQueryable<Lift> lifts = db.Lifts;
            return PartialView(lifts.Where(x => x.liftType == Lift.LiftType.Shopping).ToList());
        }

        [HttpGet]
        public ActionResult ConcertLiftPartialView()
        {
            IQueryable<Lift> lifts = db.Lifts;
            return PartialView(lifts.Where(x => x.liftType == Lift.LiftType.ConcertFestival).ToList());
        }
        [HttpGet]
        public ActionResult GeneralLiftPartialView()
        {
            IQueryable<Lift> lifts = db.Lifts;
            return PartialView(lifts.Where(x => x.liftType == Lift.LiftType.General).ToList());
        }
    }
}