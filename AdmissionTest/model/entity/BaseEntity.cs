using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

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
