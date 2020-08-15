using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.entity {
    [Table(name: "category")]
    public class Category {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int ID { get; set; }

        [NotNull]
        [Column(name: "created_at")]
        public DateTime CreateAt { get; set; }

        [AllowNull]
        [Column(name: "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        [Column(name: "archived")]
        public bool Archived { get; set; }

        [NotNull]
        [Column(name: "name")]
        public string Name { get; set; }

        public virtual IList<Subcategory> Subcategories { get; set; }

    }
}