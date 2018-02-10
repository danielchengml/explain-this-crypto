using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models
{
    [Table("Descriptions")]
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public int CoinId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Coin Coins { get; set; }

        public Description(string content, string author, string source, int coinId)
        {
            Content = content;
            Author = author;
            Source = source;
            CoinId = coinId;
        }

        public Description()
        {
        }
    }
}
