using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int IdFabricante { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorCompra { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public double ValorVenda { get; set; }
    }
}
