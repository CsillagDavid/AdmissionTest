using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.entity {
    [Table(name: "subcategory")]
    public class Subcategory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int ID { get; set; }

        [NotNull]
        [Column(name: "name")]
        public string Name { get; set; }

        [NotNull]
        [Column(name: "created_at")]
        public DateTime CreateAt { get; set; }
    }
}
