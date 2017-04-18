﻿using Mjolnir.ConsoleCommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Mjolnir.ConsoleCommandLine.InputAttributes;

namespace Mjolnir.CRM.SolutionManager.CLI.Commands.Solution
{
    [ConsoleCommandAttribute(
        Command = "ApplySolutionUpgrade",
        Desription = "",
        DependentCommand = typeof(CrmConnectCommand))]
    public class PublishAllCommand : ConsoleCommandBase
    {
        [StringInput(Description = "Solution uniuq name to be upgraded.", IsRequired = true)]
        public string SelectedSolutionUniqueName { get; set; }

        public override object Execute(ITracingService tracer, object input)
        {


            return null;
        }
    }
}
