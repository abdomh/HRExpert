using Microsoft.AspNet.Mvc.Razor.Precompilation;
using Microsoft.Dnx.Compilation.CSharp;
namespace HRExpert.Core.Compiler.PreProcess
{
    public class RazorPreCompilation : RazorPreCompileModule
    {
        protected override bool EnablePreCompilation(BeforeCompileContext context) => true;
    }
}
