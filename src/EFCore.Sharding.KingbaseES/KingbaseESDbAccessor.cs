namespace EFCore.Sharding.KingbaseES
{
    internal class KingbaseESDbAccessor : GenericDbAccessor, IDbAccessor
    {
        public KingbaseESDbAccessor(GenericDbContext baseDbContext)
            : base(baseDbContext)
        {
        }

        protected override string FormatFieldName(string name)
        {
            return $"\"{name}\"";
        }

        protected override string GetSchema(string schema)
        {
            if (schema.IsNullOrEmpty())
                return "public";
            else
                return schema;
        }
    }
}
