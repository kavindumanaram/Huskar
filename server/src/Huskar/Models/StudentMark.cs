//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Huskar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentMark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int Mark { get; set; }
    
        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
    }
}
