using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Input
{
    public class JogoInput
    {
        public required string Nome { get; set; }

        public required string Genero { get; set; }

        public required string Desenvolvedor { get; set; }


        public required DateTime DataLancamento { get; set; }


        public required string Descricao { get; set; }


        public required string ClassificacaoIndicativa { get; set; }
        public decimal Preco { get; set; }

        public int Status { get; set; }

    }
}
