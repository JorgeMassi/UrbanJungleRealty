using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanJungleRealty.Domain.Model.Estates
{
    public class Value
    {
        public int Id { get; set; }
        public string? Currency { get; set; } = "EUR";
        public double Price { get; set; }
        public enum TypeOfPrice { Total, MonthlyValue }
    }
}
