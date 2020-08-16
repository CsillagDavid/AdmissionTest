using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AdmissionTest.model.entity {
    public class BaseEntity<T> {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public T ID { get; set; }

        [NotNull]
        [Column(name: "created_at")]
        public DateTime CreateAt { get; set; }

        [Column(name: "modified_at")]
        public DateTime ModifiedAt { get; set; }
    }
}
