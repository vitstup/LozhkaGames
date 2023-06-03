using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LozhkaGames.Models
{
    [Table("Keys")]
    public class SteamKey
    {
        [Key]
        public int id { get; set; }
        [Column("steamKey")]
        public string keyValue { get; set; }
        [Column("gameId")]
        public int gameId { get; set; }
    }
}