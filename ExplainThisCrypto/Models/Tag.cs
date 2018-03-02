using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models
{
    public class Tag
    {
        public int CoinId { get; set; }
        public Coin Coin { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
