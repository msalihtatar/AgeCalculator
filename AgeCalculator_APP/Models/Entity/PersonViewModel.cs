using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Models.Entity
{
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        public IFormFile PhotoFile { get; set; }
        public string CityName { get; set; }
        [Required(ErrorMessage = "Şehir seçiniz.")]
        public int CityID { get; set; }
        [Display(Name = "Şehir")]
        public IList<City> Cities { get; set; }
        [Required(ErrorMessage = "Adınızı yazınız.")]
        [RegularExpression(@"(\D)+", ErrorMessage = " Adınız rakam içeremez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3, En fazla 50 karakterlik Ad girmelisiniz.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadınızı yazınız.")]
        [RegularExpression(@"(\D)+", ErrorMessage = " Adınız rakam içeremez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="En az 3, En fazla 50 karakterlik Soyad girmelisiniz.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Display(Name = "Yaş")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Doğum tarihinizi giriniz.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        //public Nullable<System.DateTime> BirthDate { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Cinsiyet seçiniz.")]
        [Display(Name = "Cinsiyet")]
        public int Gender { get; set; }
        public string GenderName { get; set; }
    }
}
