using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chave.Models.ChaveViewModels
{
    
    public class EmpresaViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Deve colocar o nome da Empresa para cadastrar.")]
        [Display(Name = "Empresa")]
        public string Nome { get; set; }
    }
}
