using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.entity {
    [Table(name: "category_subcategory")]
    public class CategorySubcategory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int ID { get; set; }

        [NotNull]
        [ForeignKey(name: "category")]
        public Category Category { get; set; }

        [NotNull]
        [ForeignKey(name: "subcategory")]
        public Subcategory Subcategory { get; set; }
    }
}
