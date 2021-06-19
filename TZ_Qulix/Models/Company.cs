using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TZ_Qulix.Models
{
    public class Company
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Размер компании")]
        public int Size { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public string Form { get; set; }
    }
}