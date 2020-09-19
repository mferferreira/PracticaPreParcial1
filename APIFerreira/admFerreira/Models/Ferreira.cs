using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace admFerreira.Models
{
    public class Ferreira
    {
        [Key]
        [Required]
        public int FerreiraID { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 2)]
        [DisplayName("Nombre Completo")]
        public string FriendofFerreira { get; set; }

        [Required(ErrorMessage = "Debe ingresar el lugar")]
        public CategoryType place { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese email en el formato correcto")]
        public string Email { get; set; }

        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
    public enum CategoryType
    {
       Universidad=10,
       Plaza=20,
       Colegio=30,
       Piscina=40,
       Cine=50
    }
}