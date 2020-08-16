using System.Collections.Generic;

namespace AdmissionTest.model.entity {
    public class ReportProperty {
        public double SummedTime { get; set; }
        public Category Category { get; set; }
        public IList<Activity> Activities { get; set; }
    }
}
