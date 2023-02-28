using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Semmle.Extraction.CSharp.Entities;
using Semmle.Extraction.Entities;
using Semmle.Util.Logging;

namespace Semmle.Extraction.CSharp.Populators
{
    public class TypeContainerVisitor : CSharpSyntaxVisitor
    {
        protected readonly Context cx;
        protected readonly IEntity parent;

        public TypeContainerVisitor(Context cx, IEntity parent)
        {
            this.cx = cx;
            this.parent = parent;
        }

        public override void DefaultVisit(SyntaxNode node)
        {
            throw new InternalError(node, "Unhandled top-level syntax node");
        }

        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            Entities.NamedType.Create(cx, cx.Model(node).GetDeclaredSymbol(node)).ExtractRecursive(parent);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax classDecl)
        {
            Entities.Type.Create(cx, cx.Model(classDecl).GetDeclaredSymbol(classDecl)).ExtractRecursive(parent);
        }

        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            Entities.Type.Create(cx, cx.Model(node).GetDeclaredSymbol(node)).ExtractRecursive(parent);
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            Entities.Type.Create(cx, cx.Model(node).GetDeclaredSymbol(node)).ExtractRecursive(parent);
        }

        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            Entities.Type.Create(cx, cx.Model(node).GetDeclaredSymbol(node)).ExtractRecursive(parent);
        }

        public override void VisitAttributeList(AttributeListSyntax node)
        {
            if (cx.Extractor.Standalone) return;

            var outputAssembly = Assembly.CreateOutputAssembly(cx);
            foreach (var attribute in node.Attributes)
            {
                var ae = new Attribute(cx, attribute, outputAssembly);
                cx.BindComments(ae, attribute.GetLocation());
            }
        }
    }

    class TypeOrNamespaceVisitor : TypeContainerVisitor
    {
        public TypeOrNamespaceVisitor(Context cx, IEntity parent)
            : base(cx, parent) { }

        public override void VisitUsingDirective(UsingDirectiveSyntax usingDirective)
        {
            // Only deal with "using namespace" not "using X = Y"
            if (usingDirective.Alias == null)
                new UsingDirective(cx, usingDirective, (NamespaceDeclaration)parent);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            NamespaceDeclaration.Create(cx, node, (NamespaceDeclaration)parent);
        }
    }

    class CompilationUnitVisitor : TypeOrNamespaceVisitor
    {
        public CompilationUnitVisitor(Context cx)
            : base(cx, null) { }

        public override void VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            // This information is not yet extracted.
            cx.Extractor.Message(new Message { severity = Severity.Info, message = "Ignoring extern alias directive" });
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax compilationUnit)
        {
            foreach (var m in compilationUnit.ChildNodes())
            {
                cx.Try(m, null, () => ((CSharpSyntaxNode)m).Accept(this));
            }

            // Gather comments:
            foreach (SyntaxTrivia trivia in compilationUnit.DescendantTrivia(compilationUnit.Span))
            {
                CommentLine.Extract(cx, trivia);
            }

            foreach (var trivia in compilationUnit.GetLeadingTrivia())
            {
                CommentLine.Extract(cx, trivia);
            }

            foreach (var trivia in compilationUnit.GetTrailingTrivia())
            {
                CommentLine.Extract(cx, trivia);
            }
        }
    }

    public class CompilationUnit
    {
        public static void Extract(Context cx, SyntaxNode unit)
        {
            ((CSharpSyntaxNode)unit).Accept(new CompilationUnitVisitor(cx));
        }
    }
}
