using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sep3tier3.Models
{
    public class SocialLine
    {
        public string message { set; get; }

        public DateTime date { set; get; }

        public byte[] image { set; get; }
        [Key,NotNull]
        public int id { set; get; }
        
        public string username { set; get; }
        
    }
}