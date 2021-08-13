namespace tier1.Models
{
    public class Birthday
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }

        public override string ToString()
        {
            return year + "/" + month + "/" + day;
        }
        
        
    }
    
}