﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime dateTime { get; set; }
        public string ShipCity { get; set; }
    }
    //yeni bir tabloyu eklerken ilk yaratman gereken yer burası
}
