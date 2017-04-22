﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Mjolnir.ConsoleCommandLine;
using Mjolnir.ConsoleCommandLine.InputAttributes;
using Mjolnir.CRM.Core;
using Mjolnir.CRM.Sdk.Entities;
using Mjolnir.CRM.SolutionManager.BusinessManagers;
using Mjolnir.CRM.SolutionManager.Operations.CRM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.SolutionManager.Operations.Solution.WebResource
{
    [ConsoleCommandAttribute(
        Command = "CompareWebResourcesInCRMDEConfig",
        Desription = "",
        DependentCommand = typeof(CrmConnectCommand))]
    public class CompareWebResourcesInCRMDEConfigCommand : ConsoleCommandBase
    {
        [StringInput(Description = "CRMDeveloperExtensionsConfig Path", IsRequired = true)]
        public string CRMDeveloperExtensionsConfigPath { get; set; }

        public override object ExecuteCommand(ITracingService tracer, object input)
        {
            try
            {
                tracer.Trace($"Reading CRMDeveloperExtensionsConfigPath {CRMDeveloperExtensionsConfigPath}...");

                CrmContext ctx = (CrmContext)input;

                var webResourceManager = new Core.EntityManagers.WebResourceManager(ctx);
                var crmDeveloperExtensionsManager = new CRMDeveloperExtensionsBusinessManager(CRMDeveloperExtensionsConfigPath);


                tracer.Trace($"Getting web resource with contents");
                var webResourcesWithContents = webResourceManager.GetWebResourcesContentsByIds(crmDeveloperExtensionsManager
                                                                    .WebResourceDeployerModel
                                                                    .Files
                                                                        .Select(s => s.WebResourceId.ToString()).ToArray());


                tracer.Trace($"Comparing web resources with local files, total file count: {webResourcesWithContents.Count}");
                foreach (var webResource in webResourcesWithContents)
                {
                    string localWebResourceContentBase64 = null;

                    var webResourceFile = crmDeveloperExtensionsManager.WebResourceDeployerModel.Files.Where(w => w.WebResourceId == webResource.Id).First();

                    var configFolderPath = Path.GetDirectoryName(CRMDeveloperExtensionsConfigPath);
                    try
                    {
                        localWebResourceContentBase64 = Utils.FileUtilities.ReadFileContentInBase64(Path.Combine(configFolderPath, webResourceFile.Path.Replace('/', '\\').TrimStart('\\')));

                        //TODO : Compare with web resource fetched from CRM
                        if (localWebResourceContentBase64 != webResource.Content)
                        {
                            tracer.Trace($"WebResource : {webResource.Name} is different.");
                        }
                    }
                    catch (Exception ex)
                    {
                        tracer.Trace($"Error : {ex.Message} ");
                    }
                }


                tracer.Trace($"Successfully web resources compared");
                return true;
            }
            catch (Exception ex)
            {
                HandleCommandException(tracer, ex);
                return false;
            }
        }
    }
}