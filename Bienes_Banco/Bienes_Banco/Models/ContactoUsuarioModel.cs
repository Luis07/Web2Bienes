using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bienes_Banco.Models
{
    public class ContactoUsuarioModel
    {
        [Key]
        public int ContactoUsuarioModelId { get; set; }
        [Required]
        public string UsuarioName { get; set; }
        [Required]
        public string UsuarioPassword { get; set; }
        [Required]
        public string UsuarioLastName { get; set; }
        [Required]
        public string UsuarioEmail { get; set; }
        [Required]
        public string UsuarioUbicacion { get; set; }
        [Required]
        public bool UsuarioEstado { get; set; }
        [Required]
        public bool UsuarioTipo { get; set; }
        
    }
}