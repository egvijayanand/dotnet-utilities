using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen._1
{
    [Generator(LanguageNames.CSharp)]
#if Incremental
    public class Class1 : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Incremental generator initialization goes here
        }
    }
#else
    public class Class1 : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            // Code generation goes here
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // Initialization goes here
        }
    }
#endif
}
