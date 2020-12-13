using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace sep3tier3.Models
{
    public class Friend
    {
       
        public string username1{ set; get; }
        
        public string username2{ set; get; }
        
        public Boolean accept { set; get; }


    }
}