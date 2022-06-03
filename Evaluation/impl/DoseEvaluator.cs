﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public class DoseEvaluator : IDoseEvaluator, IEvaluator
    {
        public ITargetDose TargetDose { get; set; }
        public IAntigenDose AntigenDose { get; set; }

        public void Evaluate()
        {
            if (!this.CanBeEvaluated() || this.CanSkip() || this.IsInadvertentVaccine())
            {
                // TODO Set status of the doses?
                return;
            }

           this.SatisfyTargetDose();
        }
    }
}
