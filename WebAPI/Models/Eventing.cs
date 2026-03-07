using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Eventing
    {
        public long id { get; set; }
        public DateTime created_at { get; set; }
        public string place { get; set; }
        public string description { get; set; }
        public long id_stage { get; set; }
        public int min_age { get; set; }
        public int max_age { get; set; }
        public string name { get; set; }
        public DateTime started_at { get; set; }
    }
}
