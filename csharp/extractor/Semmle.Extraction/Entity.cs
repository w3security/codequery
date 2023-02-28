using Microsoft.CodeAnalysis;
using System;

namespace Semmle.Extraction
{
    /// <summary>
    /// Any program entity which has a corresponding label in the trap file.
    ///
    /// Entities are divided into two types: normal entities and cached
    /// entities.
    ///
    /// Normal entities implement <see cref="IEntity"/> directly, and they
    /// (may) emit contents to the trap file during object construction.
    ///
    /// Cached entities implement <see cref="ICachedEntity"/>, and they
    /// emit contents to the trap file when <see cref="ICachedEntity.Populate"/>
    /// is called. Caching prevents <see cref="ICachedEntity.Populate"/>
    /// from being called on entities that have already been emitted.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The label of the entity, as it is in the trap file.
        /// </summary>
        Label Label { set; get; }

        /// <summary>
        /// The ID used for the entity, as it is in the trap file.
        /// Could be '*'.
        /// </summary>
        IId Id { get; }

        /// <summary>
        /// The location for reporting purposes.
        /// </summary>
        Location ReportingLocation { get; }

        TrapStackBehaviour TrapStackBehaviour { get; }
    }

    /// <summary>
    /// How an entity behaves with respect to .push and .pop
    /// </summary>
    public enum TrapStackBehaviour
    {
        /// <summary>
        /// The entity must not be extracted inside a .push/.pop
        /// </summary>
        NoLabel,

        /// <summary>
        /// The entity defines its own label, creating a .push/.pop
        /// </summary>
        PushesLabel,

        /// <summary>
        /// The entity must be extracted inside a .push/.pop
        /// </summary>
        NeedsLabel,

        /// <summary>
        /// The entity can be extracted inside or outside of a .push/.pop
        /// </summary>
        OptionalLabel
    }

    /// <summary>
    /// A cached entity.
    ///
    /// The <see cref="IEntity.Id"/> property is used as label in caching.
    /// </summary>
    public interface ICachedEntity : IEntity
    {
        /// <summary>
        /// Populates the <see cref="Label"/> field and generates output in the trap file
        /// as required. Is only called when <see cref="NeedsPopulation"/> returns
        /// <code>true</code> and the entity has not already been populated.
        /// </summary>
        void Populate();

        bool NeedsPopulation { get; }
    }

    /// <summary>
    /// A factory for creating cached entities.
    /// </summary>
    /// <typeparam name="Initializer">The type of the initializer.</typeparam>
    public interface ICachedEntityFactory<Initializer, Entity> where Entity : ICachedEntity
    {
        /// <summary>
        /// Initializes the entity, but does not generate any trap code.
        /// </summary>
        Entity Create(Context cx, Initializer init);
    }

    public static class ICachedEntityFactoryExtensions
    {
        public static Entity CreateEntity<Entity, T1, T2>(this ICachedEntityFactory<(T1, T2), Entity> factory, Context cx, T1 t1, T2 t2)
            where Entity : ICachedEntity
        {
            return factory.CreateEntity(cx, (t1, t2));
        }

        public static Entity CreateEntity<Entity, T1, T2, T3>(this ICachedEntityFactory<(T1, T2, T3), Entity> factory, Context cx, T1 t1, T2 t2, T3 t3)
            where Entity : ICachedEntity
        {
            return factory.CreateEntity(cx, (t1, t2, t3));
        }

        public static Entity CreateEntity<Entity, T1, T2, T3, T4>(this ICachedEntityFactory<(T1, T2, T3, T4), Entity> factory, Context cx, T1 t1, T2 t2, T3 t3, T4 t4)
            where Entity : ICachedEntity
        {
            return factory.CreateEntity(cx, (t1, t2, t3, t4));
        }

        /// <summary>
        /// Creates a new entity or returns the existing one from the cache.
        /// </summary>
        /// <typeparam name="Type">The symbol type used to construct the entity.</typeparam>
        /// <typeparam name="Entity">The type of the entity to create.</typeparam>
        /// <param name="cx">The extractor context.</param>
        /// <param name="factory">The factory used to construct the entity.</param>
        /// <param name="t">The initializer for the entity.</param>
        /// <returns></returns>
        public static Entity CreateEntity<Type, Entity>(this ICachedEntityFactory<Type, Entity> factory, Context cx, Type init)
            where Entity : ICachedEntity
        {
            using (cx.StackGuard)
            {
                var entity = factory.Create(cx, init);
                if (cx.GetOrAddCachedLabel(entity))
                    return entity;

                if (!entity.NeedsPopulation)
                    return entity;

                cx.Populate(init as ISymbol, entity);

                return entity;
            }
        }
    }
}
