using Microsoft.CodeAnalysis;

namespace Semmle.Extraction.CSharp.Entities
{
    sealed class Namespace : CachedEntity<INamespaceSymbol>
    {
        Namespace(Context cx, INamespaceSymbol init)
            : base(cx, init) { }

        public override Microsoft.CodeAnalysis.Location ReportingLocation => null;

        public override void Populate()
        {
            Context.Emit(Tuples.namespaces(this, symbol.Name));

            if (symbol.ContainingNamespace != null)
            {
                Namespace parent = Create(Context, symbol.ContainingNamespace);
                Context.Emit(Tuples.parent_namespace(this, parent));
            }
        }

        public override bool NeedsPopulation => true;

        public override IId Id
        {
            get
            {
                return symbol.IsGlobalNamespace ? new Key(";namespace") :
                    new Key(Create(Context, symbol.ContainingNamespace), ".", symbol.Name, ";namespace");
            }
        }

        public static Namespace Create(Context cx, INamespaceSymbol ns) => NamespaceFactory.Instance.CreateEntity2(cx, ns);

        class NamespaceFactory : ICachedEntityFactory<INamespaceSymbol, Namespace>
        {
            public static readonly NamespaceFactory Instance = new NamespaceFactory();

            public Namespace Create(Context cx, INamespaceSymbol init) => new Namespace(cx, init);
        }

        public override TrapStackBehaviour TrapStackBehaviour => TrapStackBehaviour.NoLabel;

        public override int GetHashCode() => QualifiedName.GetHashCode();

        string QualifiedName => symbol.ToDisplayString();

        public override bool Equals(object obj)
        {
            return obj is Namespace ns && QualifiedName == ns.QualifiedName;
        }
    }
}
