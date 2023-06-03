using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LozhkaGames.Models
{
    [Table("Accounts")]
    public class User
    {
        [Key]
        public int id {  get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("password")] 
        public string password { get; set; }    
    }
}