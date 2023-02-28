using Microsoft.CodeAnalysis;

namespace Semmle.Extraction.CSharp.Entities
{
    class EventAccessor : Accessor
    {
        EventAccessor(Context cx, IMethodSymbol init)
            : base(cx, init) { }

        /// <summary>
        /// Gets the event symbol associated with this accessor.
        /// </summary>
        IEventSymbol EventSymbol => symbol.AssociatedSymbol as IEventSymbol;

        public override void Populate()
        {
            PopulateMethod();
            ContainingType.ExtractGenerics();

            var @event = EventSymbol;
            if (@event == null)
            {
                Context.ModelError(symbol, "Unhandled event accessor associated symbol");
                return;
            }

            var parent = Event.Create(Context, @event);
            int kind;
            EventAccessor unboundAccessor;
            if (symbol.Equals(@event.AddMethod))
            {
                kind = 1;
                unboundAccessor = Create(Context, @event.OriginalDefinition.AddMethod);
            }
            else if (symbol.Equals(@event.RemoveMethod))
            {
                kind = 2;
                unboundAccessor = Create(Context, @event.OriginalDefinition.RemoveMethod);
            }
            else
            {
                Context.ModelError(symbol, "Undhandled event accessor kind");
                return;
            }

            Context.Emit(Tuples.event_accessors(this, kind, symbol.Name, parent, unboundAccessor));

            foreach (var l in Locations)
                Context.Emit(Tuples.event_accessor_location(this, l));

            Overrides();
        }

        public new static EventAccessor Create(Context cx, IMethodSymbol symbol) =>
            EventAccessorFactory.Instance.CreateEntity(cx, symbol);

        class EventAccessorFactory : ICachedEntityFactory<IMethodSymbol, EventAccessor>
        {
            public static readonly EventAccessorFactory Instance = new EventAccessorFactory();

            public EventAccessor Create(Context cx, IMethodSymbol init) => new EventAccessor(cx, init);
        }
    }
}
