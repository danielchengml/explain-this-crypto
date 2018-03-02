using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models.AccountViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Coin> Coin { get; set; }

        public CategoryViewModel(string name, List<Coin> coin)
        {
            Name = name;
            Coin = coin;
        }
    }
}
