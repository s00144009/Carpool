using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Carpool.Models
{
    public class Lift
    {
        public enum LiftType { General, College, [Display(Name="Concert/Festival")]ConcertFestival, [Display(Name="Sport Events")]SportEvents, Shopping}
        public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        [Key]
        public int LiftID { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a Start Point")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Start Point cannot be longer than 150 characters")]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Required(ErrorMessage = "You must enter a End Point")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "End Point cannot be longer than 150 characters")]
        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a date for this lift")]
        public DateTime LiftDate { get; set; }

        [Required(ErrorMessage = "Please enter the approximate start time of your outbound journey")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OutboundStartTime { get; set; }

        [Required(ErrorMessage = "Please enter the approximate end time of your outbound journey")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OutboundEndTime { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? InboundStartTime { get; set; }

        //[Required(ErrorMessage = "Please enter the approximate end time of your inbound journey")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? InboundEndTime { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string UserEmailAddress { get; set; }

        public string UserId { get; set; }
        public virtual List<RequestLift> requestLifts { get; set; }

        [Display(Name = "One Way Lift")]
        public bool OneWayLift { get; set; }

        [Required]
        [Display(Name = "Lift Type")]
        public LiftType liftType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class WeeklyLift
    {
        [Key]
        public int LiftID { get; set; }

        [Required(ErrorMessage = "You must enter a Start Point")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Start Point cannot be longer than 150 characters")]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Required(ErrorMessage = "You must enter an End Point")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "End Point cannot be longer than 150 characters")]
        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        public bool Monday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? MondayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? MondayEndTime { get; set; }

        public bool Tuesday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? TuesdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? TuesdayEndTime { get; set; }

        public bool Wednesday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? WednesdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? WednesdayEndTime { get; set; }

        public bool Thursday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? ThursdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? ThursdayEndTime { get; set; }

        public bool Friday { get; set; }

        [Display(Name = "Friday Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? FridayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? FridayEndTime { get; set; }

        public bool Saturday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SaturdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SaturdayEndTime { get; set; }

        public bool Sunday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SundayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SundayEndTime { get; set; }

        [Required(ErrorMessage = "Please enter the approximate start time of your outbound journey")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OutboundStartTime { get; set; }

        [Required(ErrorMessage = "Please enter the approximate end time of your outbound journey")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OutboundEndTime { get; set; }

        [Required(ErrorMessage = "Please enter the approximate start time of your inbound journey")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime InboundStartTime { get; set; }

        [Required(ErrorMessage = "Please enter the approximate end time of your inbound journey")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime InboundEndTime { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string UserEmailAddress { get; set; }

        public string UserId { get; set; }
        public string bookingStatus { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }

    public class RequestLift
    {
        [Key]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "You must enter where you want to be collected")]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Required(ErrorMessage = "You must enter a meeting point")]
        [Display(Name = "Meeting Point")]
        public string MeetingPoint { get; set; }

        [Required(ErrorMessage = "You must where you would like to get off")]
        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        [Required(ErrorMessage = "Please enter the approximate end time of your outbound journey")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OutboundTime { get; set; }

        //[Required(ErrorMessage = "Please enter the approximate start time of your inbound journey")]
        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? InboundTime { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string PassengerEmail { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool EmailSent { get; set; }

        public int DriverId { get; set; }
        [Display(Name ="Booking Status")]
        public string bookingStatus { get; set; }
        public string DriverEmail { get; set; }
    }

    public class RequestWeeklyLift
    {
        [Key]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "You must enter where you want to be collected")]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Required(ErrorMessage = "You must enter a meeting point")]
        [Display(Name = "Meeting Point")]
        public string MeetingPoint { get; set; }

        [Required(ErrorMessage = "You must where you would like to get off")]
        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        public bool Monday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? MondayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? MondayEndTime { get; set; }

        public bool Tuesday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? TuesdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? TuesdayEndTime { get; set; }

        public bool Wednesday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? WednesdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? WednesdayEndTime { get; set; }

        public bool Thursday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? ThursdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? ThursdayEndTime { get; set; }

        public bool Friday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? FridayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? FridayEndTime { get; set; }

        public bool Saturday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SaturdayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SaturdayEndTime { get; set; }

        public bool Sunday { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SundayStartTime { get; set; }

        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? SundayEndTime { get; set; }

        //[Required(ErrorMessage = "Please enter the approximate end time of your outbound journey")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? OutboundTime { get; set; }

        //[Required(ErrorMessage = "Please enter the approximate start time of your inbound journey")]
        [Display(Name = "Return Time")]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? InboundTime { get; set; }

        //Bookers Email
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string PassengerEmail { get; set; }

        public bool EmailSent { get; set; }

        public int DriverId { get; set; }
        [Display(Name = "Booking Status")]
        public string bookingStatus { get; set; }
        public string DriverEmail { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
    public class GMailer
    {
        [Key]
        public int id { get; set; }
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 25; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            GmailSSL = true;
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }
    }
}