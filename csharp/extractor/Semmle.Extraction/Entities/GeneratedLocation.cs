namespace Semmle.Extraction.Entities
{
    public class GeneratedLocation : SourceLocation
    {
        readonly File GeneratedFile;

        GeneratedLocation(Context cx)
            : base(cx, null)
        {
            GeneratedFile = File.CreateGenerated(cx);
        }

        public override void Populate()
        {
            Context.Emit(Tuples.locations_default(this, GeneratedFile, 0, 0, 0, 0));
        }

        public override IId Id => new Key("loc,", GeneratedFile, ",0,0,0,0");

        public override int GetHashCode() => 98732567;

        public override bool Equals(object obj) => obj != null && obj.GetType() == typeof(GeneratedLocation);

        public static GeneratedLocation Create(Context cx) => GeneratedLocationFactory.Instance.CreateEntity(cx, null);

        class GeneratedLocationFactory : ICachedEntityFactory<string, GeneratedLocation>
        {
            public static GeneratedLocationFactory Instance = new GeneratedLocationFactory();

            public GeneratedLocation Create(Context cx, string init) => new GeneratedLocation(cx);
        }
    }
}
