using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceData.Model
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CartInfo { get; set; }
    }
}
