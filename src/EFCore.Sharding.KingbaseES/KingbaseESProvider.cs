using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Kdbndp;
using Kdbndp.EntityFrameworkCore.KingbaseES.Metadata.Conventions;
using System.Data.Common;

namespace EFCore.Sharding.KingbaseES
{
    internal class KingbaseESProvider : AbstractProvider
    {
        public override DbProviderFactory DbProviderFactory => KdbndpFactory.Instance;

#pragma warning disable EF1001 // Internal EF Core API usage.
        public override ModelBuilder GetModelBuilder() => new ModelBuilder(KdbndpConventionSetBuilder.Build());
#pragma warning restore EF1001 // Internal EF Core API usage.

        public override IDbAccessor GetDbAccessor(GenericDbContext baseDbContext) => new KingbaseESDbAccessor(baseDbContext);

        public override void UseDatabase(DbContextOptionsBuilder dbContextOptionsBuilder, DbConnection dbConnection)
        {
            dbContextOptionsBuilder.UseKdbndp(dbConnection);
            dbContextOptionsBuilder.ReplaceService<IMigrationsSqlGenerator, ShardingKingbaseESMigrationsSqlGenerator>();
        }
    }
}
