using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sep3tier3.Models
{
    public class User
    {
        [Key,NotNull]
        public string username{ set; get; }
        public string password{ set; get; }
        public string firstname{ set; get; }
        public string lastname{ set; get; }
        public string birthday { set; get; }
        public string sex{ set; get; }
        public string major{ set; get; }
        public string hometown{ set; get; }
        public string description{ set; get; }
        public int age{ set; get; }
        public string hobbies{ set; get; }
        
        
        
        
        
        
        
        
        
    }
}