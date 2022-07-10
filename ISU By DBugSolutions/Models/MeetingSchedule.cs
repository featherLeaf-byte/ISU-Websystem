using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Models
{
    public class MeetingSchedule
    {
        [Key]
        public int MeetingScheduleID { get; set; }
       
        public string Scheduler { get; set; }
       
        public string Venue { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Details { get; set; }
        [Display(Name = "Date Scheduled")]
    
        public DateTime Date { get; set; }
        [Display(Name = "Start")]
     
        public DateTime StartTime { get; set; }
        [Display(Name = "End")]
        public DateTime EndTime { get; set; }
        public MeetingSchedule()
        {
           Date = DateTime.Now;
        
        }
    }
}
