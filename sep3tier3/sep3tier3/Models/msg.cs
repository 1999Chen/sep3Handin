using System.ComponentModel.DataAnnotations;

namespace sep3tier3.Models
{
    public class msg
    {
        [Required,StringLength(256)]
        private string user_message { set; get; }
    }
}