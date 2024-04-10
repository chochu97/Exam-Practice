namespace DatosZone
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aplicacion")]
    public partial class Aplicacion
    {
        public int id { get; set; }

        public int id_categoria { get; set; }

        [Required]
        public string titulo { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]
        public string desarrolladora { get; set; }

        public decimal precio { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
