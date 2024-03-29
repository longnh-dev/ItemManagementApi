﻿using ItemManagement.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace ItemManagement.Data.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Department Department { get; set; }
    }
}