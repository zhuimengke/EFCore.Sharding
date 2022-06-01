using EFCore.Sharding.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Kdbndp.EntityFrameworkCore.KingbaseES.Infrastructure.Internal;
using Kdbndp.EntityFrameworkCore.KingbaseES.Migrations;
using System.Linq;

namespace EFCore.Sharding.KingbaseES
{
    internal class ShardingKingbaseESMigrationsSqlGenerator : KdbndpMigrationsSqlGenerator
    {
#pragma warning disable EF1001 // Internal EF Core API usage.
        public ShardingKingbaseESMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies, IKdbndpOptions npgsqlOptions) : base(dependencies, npgsqlOptions)
#pragma warning restore EF1001 // Internal EF Core API usage.
        {
        }

        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            var oldCmds = builder.GetCommandList().ToList();
            base.Generate(operation, model, builder);
            var newCmds = builder.GetCommandList().ToList();
            var addCmds = newCmds.Where(x => !oldCmds.Contains(x)).ToList();

            MigrationHelper.Generate(operation, builder, Dependencies.SqlGenerationHelper, addCmds);
        }
    }
}
