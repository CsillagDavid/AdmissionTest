using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AdmissionTest.model.entity {
    [Table(name: "activity")]
    public class Activity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public int ID { get; set; }

        [NotNull]
        [Column(name: "comment")]
        public string Comment { get; set; }

        [NotNull]
        [ForeignKey(name: "category")]
        public Category Category { get; set; }

        [NotNull]
        [ForeignKey(name: "subcategory")]
        public Subcategory Subcategory { get; set; }

        [NotNull]
        [Column(name: "start_date")]
        public DateTime StartDate { get; set; }

        [NotNull]
        [Column(name: "end_date")]
        public DateTime EndDate { get; set; }

        [NotNull]
        [Column(name: "created_at")]
        public DateTime CreateAt { get; set; }
    }
}
