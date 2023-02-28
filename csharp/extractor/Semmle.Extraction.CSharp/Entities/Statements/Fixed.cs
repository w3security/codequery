using Microsoft.CodeAnalysis.CSharp.Syntax;
using Semmle.Extraction.CSharp.Entities.Expressions;
using Semmle.Extraction.Kinds;

namespace Semmle.Extraction.CSharp.Entities.Statements
{
    class Fixed : Statement<FixedStatementSyntax>
    {
        Fixed(Context cx, FixedStatementSyntax @fixed, IStatementParentEntity parent, int child)
            : base(cx, @fixed, StmtKind.FIXED, parent, child) { }

        public static Fixed Create(Context cx, FixedStatementSyntax node, IStatementParentEntity parent, int child)
        {
            var ret = new Fixed(cx, node, parent, child);
            ret.TryPopulate();
            return ret;
        }

        protected override void Populate()
        {
            VariableDeclarations.Populate(cx, Stmt.Declaration, this, -1, childIncrement: -1);
            Create(cx, Stmt.Statement, this, 0);
        }
    }
}
