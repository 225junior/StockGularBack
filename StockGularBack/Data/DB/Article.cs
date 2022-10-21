using System;
using System.Collections.Generic;

namespace StockGularBack.Data.DB
{
    public partial class Article
    {
        public int Id { get; set; }
        public string? CodeArticle { get; set; }
        public string? Designation { get; set; }
        public double? PrixUnitaireHt { get; set; }
        public double? TauxTva { get; set; }
        public double? PrixUnitaireTtc { get; set; }
        public string? Photo { get; set; }
        public int? IdEntreprise { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? UpdatedAt { get; set; }
    }
}
