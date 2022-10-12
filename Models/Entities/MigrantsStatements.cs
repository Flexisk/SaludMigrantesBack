using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackSaludMigrantes.Models.Entities
{

    [Table("DECLARACIONES_MIGRANTES")]
    public class MigrantsStatements
    {
        [Key]
        [Column("FICHA_SISBEN")]
        public string DataSISBEN { get; set; }

        [Column("DIRECCION")]
        public string Direction { get; set; }

        [Column("TELEFONO")]
        public string? Mobile { get; set; }

       
        [Column("LOCALIDAD")]
        public byte? LocationId { get; set; }

        [Column("FECHA_DECLARA")]
        public DateTime? StatamentsDate { get; set; }

        [NotMapped]
        [Column("FECHA_VIGENCIA")]
        public DateTime? ValidityDate { get; set; }

    }
}
