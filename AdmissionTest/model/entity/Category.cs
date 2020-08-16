using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AdmissionTest.model.entity {
    [Table(name: "category")]
    public class Category {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int ID { get; set; }

        [NotNull]
        [Column(name: "created_at")]
        public DateTime CreatedAt { get; set; }

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