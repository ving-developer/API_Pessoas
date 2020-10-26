using API_Pessoas.Validations;
using API_Pessoas.Validations.DateValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int id_pessoa { get; set; }
        [Required]
        [MaxLength(100)]
        [FirstLetterUppercase]
        public string nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string cpf { get; set; }
        [Required]
        [DateLessHigherCurrent]
        public DateTime dt_nascimento { get; set; }
        [Required]
        [MaxLength(100)]
        [Email]
        public string email { get; set; }
        [MinLength(5)]
        [MaxLength(20)]
        public string senha { get; set; }
    }
}
