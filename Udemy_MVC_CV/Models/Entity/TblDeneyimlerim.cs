//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Udemy_MVC_CV.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblDeneyimlerim
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Bu alan bo� b�rak�lamaz !")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz !")]
        public string AltBaslik { get; set; }
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz !")]
        public string Aciklama { get; set; }
        public string Tarih { get; set; }
    }
}
