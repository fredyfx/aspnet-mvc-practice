using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Adding this two:
using DemoIdentity.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoIdentity.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //Add User related (this is one to many: one user could have one or more Oders)
        //We dont need it, UserID (Pink Floyd breaking the wall style)
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        
    }
}