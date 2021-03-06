﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models
{
    [Table("Coins")]
    public class Coin
    {
        [Key]
        public int CoinId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Logo_url { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string TwitterWidgetId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }
        public List<Tag> Category { get; set; }

        public Coin(string name, string symbol, string logo_url, string tagline, string website, List<Tag> category, string twitterWidgetId, int userId)
        {
            Name = name;
            Symbol = symbol;
            Logo_url = logo_url;
            Tagline = tagline;
            Website = website;
            Category = category;
            TwitterWidgetId = twitterWidgetId;
        }

        public Coin()
        {
        }


    }
}
