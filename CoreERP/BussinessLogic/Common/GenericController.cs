using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Common
{
    public class GenericController
    {
    }

    public class ControllerServiceProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach( var partType in parts.OfType<IApplicationPartTypeProvider>())
            {
                foreach(var part in partType.Types)
                {
                    if (part.IsSubclassOf(typeof(Controller)) || feature.Controllers.Contains(part))
                    {
                        feature.Controllers.Add(part);
                    }
                }
            }
        }
    }

    //public class ActionSerivceProvider
    //{
    //    public static void ProcessAction(Type type, IRepository<TblLanguage> repository)
    //    {

    //    }
    //}
}
