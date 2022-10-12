using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackSaludMigrantes.Models.Entities
{
    [Table("MIGRANTES_ACREDITADOM")]

    public class MigrantsAcreditadom
    {
    
        [Column("DOC_TIP")]
        public string? TypeDoc { get; set; }

        [Column("DOC_NUM")]
        public string? DocNum { get; set; }

        [Column("APELLIDO_A")]
        public string? Surname { get; set; }

        [Column("APELLIDO_B")]
        public string? SecondSurname { get; set; }

        [Column("NOMBRE_A")]
        public string? FirstName { get; set; }

        [Column("NOMBRE_B")]
        public string? SecondName { get; set; }

        [Column("FEC_NAC")]
        public DateTime? BirthDate { get; set; }

        [Column("FICHA")]
        public string MigrantsStatementsFile { get; set; }

        [Column("LOCALIDAD")]
        public string? LocationName { get; set; }

        [Column("PARENTESCO")]
        public string? Relationship { get; set; }

        [Column("DIR_VIVIENDA")]
        public string? Direction { get; set; }

        [Column("NUCLEO")]
        public string Nucleo { get; set; } 

    }
}
