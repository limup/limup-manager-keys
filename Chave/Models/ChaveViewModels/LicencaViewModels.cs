using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chave.Models.ChaveViewModels
{
    [Table("Licenca")]
    public class LicencaViewModels
    {
        public int Id { get; set; }

        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Não podemos cadastrar sem a Chave do dispositivo.")]
        [Display(Name ="Chave")]
        public string Chave { get; set; }

        [Required(ErrorMessage = "Não podemos cadastrar sem a Nome do dispositivo.")]
        [Display(Name = "Dispositivo")]
        public string Dispositivo { get; set; }

        [Required(ErrorMessage = "Não podemos cadastrar sem a Chave do dispositivo.")]
        [StringLength(1, ErrorMessage = "É permitido apenas {0} caracteres.")]
        [Display(Name = "Plataforma")]
        public string Plataforma { get; set; }

        [Required(ErrorMessage = "Entre com a data atual.")]
        [Display(Name = "Licença")]
        [DataType(DataType.Date)]
        public DateTime DataLicenca { get; set; } 

        [ForeignKey("IdEmpresa")]
        public virtual EmpresaViewModels Empresa { get; set; }

    }
}
