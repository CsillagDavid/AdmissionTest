using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionTest.model.entity {
    public class ReportProperty {
        public double SummedTime { get; set; }
        public Category Category { get; set; }
        public IList<Activity> Activities { get; set; }
    }
}
