using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasty.ApiGenerator.Helpers
{
    public static class RoslynHelper
    {
       
        public static  object GetEntities<T>(string entityName)
        {
            var options = ScriptOptions.Default
                                .AddReferences(typeof(T).Assembly.Location)
                                .AddReferences(typeof(System.Linq.Enumerable).Assembly.Location);

            string context = typeof(T).Name;

            string code = "using System.Linq;" +
                          "var db = new " + context + "();" +
                          "return db." + entityName + ".ToList()";

            var script = CSharpScript.
                         Create(code, options);

            return  script.RunAsync().Result.ReturnValue;            
        }

        public static object AddEntity<T>(string entityName,Dictionary<string,string> paramValues)
        {
            var options = ScriptOptions.Default
                                .AddReferences(typeof(T).Assembly.Location)
                                .AddReferences(typeof(System.Linq.Enumerable).Assembly.Location);

            string context = typeof(T).Name;

           

            string code = "using System.Linq;" +
                          "var db = new " + context + "();" +
                          "db." + entityName + ".Add(new " + entityName + "{" +
                            
                          "});";


            // "return db." + entityName + ".ToList()";

            var script = CSharpScript.
                         Create(code, options);

            
            return script.RunAsync().Result.ReturnValue;
        }
    }
}
