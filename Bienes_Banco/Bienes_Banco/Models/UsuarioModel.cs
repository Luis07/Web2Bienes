using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bienes_Banco.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        public string UsuarioName { get; set; }
        [Required]
        public string UsuarioPassword { get; set; }
    }
}