using Microsoft.CodeAnalysis.CSharp.Syntax;
using Semmle.Extraction.Kinds;

namespace Semmle.Extraction.CSharp.Entities.Expressions
{
    class Await : Expression<AwaitExpressionSyntax>
    {
        Await(ExpressionNodeInfo info) : base(info.SetKind(ExprKind.AWAIT)) { }

        public static Expression Create(ExpressionNodeInfo info) => new Await(info).TryPopulate();

        protected override void Populate()
        {
            Create(cx, Syntax.Expression, this, 0);
        }
    }
}
