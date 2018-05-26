using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bueller.MVC.Models
{
    public class Class
    {
        [ScaffoldColumn(false)]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Room")]
        [StringLength(20, ErrorMessage = "Room number cannot be more than 100 characters")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Section is required")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Section cannot be more than 100 characters")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Number of credits must be between 1 and 6")]
        public int Credits { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Room number cannot be more than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:h\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
    
        [Required(ErrorMessage = "End time is required")]
        [DisplayFormat(DataFormatString = "{0:h\\:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        //different ways to do this.. try 5 columns for now
        [Required]
        [Range(0, 1, ErrorMessage = "Enter 1 if class held on corresponsing day, 0 otherwise")]
        public int Mon { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Enter 1 if class held on corresponsing day, 0 otherwise")]
        public int Tues { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Enter 1 if class held on corresponsing day, 0 otherwise")]
        public int Wed { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Enter 1 if class held on corresponsing day, 0 otherwise")]
        public int Thurs { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Enter 1 if class held on corresponsing day, 0 otherwise")]
        public int Fri { get; set; }

        //no class level for now

        [ScaffoldColumn(false)]
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Employee Teacher { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [Required]
        public string SubjectName { get; set; }

        //public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        //[NotMapped]
        [Display(Name = "Class Days")]
        public string ClassDays
        {
            get
            {
                return ((Mon == 1) ? ("Mo") : "") + ((Tues == 1) ? ("Tu") : "") +
                       ((Wed == 1) ? ("We") : "") + ((Thurs == 1) ? ("Th") : "") +
                       ((Fri == 1) ? ("Fr") : "");
            }
        }
        [DataType(DataType.Text)]
        public string StartTimeFormatted
        {
            get
            {
                if (TimeSpan.Compare(StartTime, TimeSpan.FromHours(13)) >= 0)
                    return StartTime.Subtract(TimeSpan.FromHours(12)).ToString(@"h\:mm") + "PM";
                if (TimeSpan.Compare(StartTime, TimeSpan.FromHours(1)) < 0)
                    return StartTime.Add(TimeSpan.FromHours(12)).ToString(@"h\:mm") + "AM";
                if (TimeSpan.Compare(StartTime, TimeSpan.FromHours(12)) >= 0)
                    return StartTime.ToString(@"h\:mm") + "PM";
                return StartTime.ToString(@"h\:mm") + "AM";
                //return StartTime.ToString("{0:h\\:mm}") + "AM";
            }
        }
        [DataType(DataType.Text)]
        public string EndTimeFormatted
        {
            get
            {
                if (TimeSpan.Compare(EndTime, TimeSpan.FromHours(13)) >= 0)
                    return EndTime.Subtract(TimeSpan.FromHours(12)).ToString(@"h\:mm") + "PM";
                if (TimeSpan.Compare(EndTime, TimeSpan.FromHours(1)) < 0)
                    return EndTime.Add(TimeSpan.FromHours(12)).ToString(@"h\:mm") + "AM";
                if (TimeSpan.Compare(EndTime, TimeSpan.FromHours(12)) >= 0)
                    return EndTime.ToString(@"h\:mm") + "PM";
                return EndTime.ToString(@"h\:mm") + "AM";
            }
        }
    }
}