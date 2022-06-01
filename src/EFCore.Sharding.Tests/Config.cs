namespace EFCore.Sharding.Tests
{
    public static class Config
    {
        public const string CONSTRING1 = "Data Source=localhost;Initial Catalog=EFCore.Sharding1;Integrated Security=True";
        public const string CONSTRING2 = "Data Source=localhost;Initial Catalog=EFCore.Sharding2;Integrated Security=True";
        public const string SQLITE1 = "DataSource=db1.db";
        public const string SQLITE2 = "DataSource=db2.db";
        public const string Kdbndp = "Server=192.168.0.141;User ID=SYSTEM;Password=123456;Database=alwayscheck47;Port=54321";
    }
}
