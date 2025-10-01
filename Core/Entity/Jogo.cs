using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
  
    public class Jogo : EntityBase
    {
       
     
        public required string Nome { get; set; }

        public required string Genero { get; set; }
      
        public required string Desenvolvedor { get; set; }

     
        public required DateOnly DataLancamento { get; set; }

    
        public required string Descricao { get; set; }

     
        public required string ClassificacaoIndicativa { get; set; }
        public decimal Preco { get; set; }
    }
}



