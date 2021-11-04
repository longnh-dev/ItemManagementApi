using System;
using System.Collections.Generic;

namespace ItemManagement.Data.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Leader { get; set; }
        public int Personnel { get; set; }
        public DateTime DateOfEstablish { get; set; }
        
    }
}