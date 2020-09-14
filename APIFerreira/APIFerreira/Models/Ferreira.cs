using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIFerreira.Models
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
        public Place place { get; set; }

        [EmailAddress(ErrorMessage= "Ingrese email en el formato correcto")]
        public string Email { get; set; }

        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
        public enum Place
    {
        Registro1 = 1, 
        Registro2 = 2,
        Registro3 = 3,
        Registro4 = 4,
        Registro5 = 5
    }
}