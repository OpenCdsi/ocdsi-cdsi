using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{
        public enum Gender
        {
            Female,
            Male
        }
  public  class ProcessingData
    {
        public DateTime AssessmentDate { get; set; } = DateTime.Now;
        public DateTime EarliestDate { get; set; }
    }
}
