using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LozhkaGames.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int id { get; set; }
        [Column("gameName")]
        public string gameName { get; set; }
        [Column("price")]
        public int price { get; set; }
        [XmlElement("genres")]
        public string genres { get; set; }
        [Column("publisher")]
        public string publisher { get; set; }
        [XmlElement("images")]
        public string images { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("releaseDate")]
        public DateTime date { get; set; }

        private string[] ParseXml(string xml)
        {
            XDocument xmlDoc = XDocument.Parse(xml);

            string[] values = xmlDoc.Root
            .Elements("value")
            .Select(e => e.Value)
            .ToArray();
            return values;
        }

        public string GetPreviewImg()
        {
            return "/img/games/" + ParseXml(images)[0] + ".jpg";
        }

        public string[] GetScreenshots()
        {
            var imgs = ParseXml(images);
            string[] screenshots = new string[imgs.Length - 1];
            for (int i = 1; i < imgs.Length; i++)
            {
                screenshots[i - 1] = "/img/games/" + imgs[i] + ".jpg";
            }
            return screenshots;
        }

        public string[] GetGenres()
        {
            return ParseXml(genres);
        }
    }
}