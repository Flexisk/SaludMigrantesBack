
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackSaludMigrantes.Models.Entities
{
    
    [Table("LOCALIDAD")]
    public class Location
    {
        [Key]
        [Column("ID_loc")]
        public int LocationId { set; get; }
        
        [Column("Nombre_loc")]
        public string LocationName { get; set; }
        
        [Column("Cod_Red")]
        public string NetId { get; set; }
        
        [Column("ID_localidad")]
        public string LocationIdString { get; set; }
    }

}
