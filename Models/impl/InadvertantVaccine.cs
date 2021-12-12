using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class InadvertentVaccine : IInadvertentVaccine
    {
        public string VaccineType { get; internal set; }
        public string Cvx { get; internal set; }
    }
}
