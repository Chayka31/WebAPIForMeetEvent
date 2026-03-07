 
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Meeting
    {
        public long id { get; set; }
        public DateTime created_at { get; set; }
        public long id_account { get; set; }
        public long id_event { get; set; }
        public long id_role { get; set; }
    }
}
