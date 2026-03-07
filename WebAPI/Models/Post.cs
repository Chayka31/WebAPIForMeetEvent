
namespace WebAPI.Models
{
    public class Post
    {
        public long id { get; set; }
        public DateTime created_at { get; set; }
        public string image { get; set; }
        public string text { get; set; }
        public long id_account { get; set; }
    }
}
