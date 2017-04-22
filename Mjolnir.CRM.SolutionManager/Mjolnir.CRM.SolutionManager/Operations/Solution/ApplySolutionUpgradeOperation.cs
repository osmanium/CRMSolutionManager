﻿using Mjolnir.CRM.Core;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.JavaScriptOperation;
using Mjolnir.CRM.SolutionManager.BusinessManagers;
using Mjolnir.CRM.SolutionManager.Infrastructure;
using Mjolnir.CRM.SolutionManager.Infrastructure.ApplySolutionUpgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.SolutionManager.Operations.Solution
{
    //public class ApplySolutionUpgradeOperation : JavaScriptOperationBase<ApplySolutionUpgradeRequest, ApplySolutionUpgradeResponse>
    //{
    //    public override ApplySolutionUpgradeResponse ExecuteInternal(ApplySolutionUpgradeRequest req, ApplySolutionUpgradeResponse res, CRMContext context)
    //    {
    //        return new SolutionBusiness().ApplySolutionUpgrade(req, res, context); ;
    //    }
    //}

    //[ConsoleCommandAttribute(
    //    Command = "ApplySolutionUpgrade",
    //    Desription = "",
    //    DependentCommand = typeof(CrmConnectCommand))]
    //public class ApplySolutionUpgradeCommand : ConsoleCommandBase
    //{
    //    [StringInput(Description = "Solution uniuq name to be upgraded.", IsRequired = true)]
    //    public string SelectedSolutionUniqueName { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="tracer"></param>
    //    /// <param name="input"></param>
    //    /// <returns>ApplySolutionUpgradeResponse</returns>
    //    public override object Execute(ITracingService tracer, object input)
    //    {
    //        CrmContext context = (CrmContext)input;

    //        var solutionId = Core.EntityManagers.SolutionManager.GetSolutionIdByUniqueSolutionName(SelectedSolutionUniqueName);
    //        if (solutionId != Guid.Empty)
    //        {
    //            var req = new ApplySolutionUpgradeRequest()
    //            {
    //                SelectedSolutionIds = new string[] { solutionId }
    //            };

    //            return new Mjolnir.CRM.SolutionManager.Business.SolutionBusiness().ApplySolutionUpgrade(req, new ApplySolutionUpgradeResponse(), context); ;
    //        }
    //        else
    //        {
    //            Console.WriteLine($"Solution with name : {SelectedSolutionUniqueName} not found.");
    //        }
    //    }
    //}
}