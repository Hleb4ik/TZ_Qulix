using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TZ_Qulix.Models
{
    public class Worker
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string Otchestvo { get; set; }

        [Display(Name = "Дата")]
        public string Date { get; set; }

        [Display(Name = "Должность")]
        public string Post { get; set; }

        [Display(Name = "Компания")]
        public string Company { get; set; }
    }
}