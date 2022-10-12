using System;
using System.ComponentModel.DataAnnotations;

namespace BackSaludMigrantes.Requests
{
    public class ValidationRequest
    {
        public string DocNum { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
