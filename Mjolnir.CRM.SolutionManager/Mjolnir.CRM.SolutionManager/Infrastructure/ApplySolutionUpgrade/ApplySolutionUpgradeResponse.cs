﻿using Mjolnir.CRM.JavaScriptOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.SolutionManager.Infrastructure.ApplySolutionUpgrade
{
    public class ApplySolutionUpgradeResponse : IJavaScriptOperationResponse
    {
        public string ErrorMessage { get; set; }

        public bool IsSuccesful { get; set; }
    }
}