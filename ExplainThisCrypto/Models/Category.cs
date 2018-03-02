using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public List<Tag> Coin { get; set; }

        public Category(string name, List<Tag> coin, int userId)
        {
            Name = name;
            Coin = coin;
        }
        
        public Category()
        {
        }
    }
}
