using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add (submit) attendance details for particular student
    /// </summary>
    public class AttendanceDTOAdd
    {
        public int StudentId { get; set; }
        //Attendance status such as True/False - Attended/Not Attended
        [Required(ErrorMessage ="Status is required")]
        public bool Status { get; set; }
    }
}
