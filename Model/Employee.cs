namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Designation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Salary { get; set; }

        public DateTime? DateOfJoin { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public long Author { get; set; }

        public long Editor { get; set; }
    }
}
