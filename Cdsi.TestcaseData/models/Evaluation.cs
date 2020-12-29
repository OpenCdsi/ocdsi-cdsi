using System;
using System.Collections.Generic;
using System.Text;

namespace Cdsi.TestcaseData
{
    public class Evaluation
    {
        public string Series_Status { get; set; }
        public IEnumerable<Dose> AdministeredDoses { get; set; }
    }
}
