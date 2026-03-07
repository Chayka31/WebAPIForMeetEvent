using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Account
    {

        public long id { get; set; } 
        public DateTime created_at { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public string? f_name { get; set; }
        public string? s_name { get; set; }
        public string? m_name { get; set; }
        public string? about { get; set; }
        public string? image { get; set; }
        public string? email { get; set; }
        public long? count_value { get; set; }
        public long id_pol { get; set; }
        public DateTime? date_birth { get; set; }

    }
}
