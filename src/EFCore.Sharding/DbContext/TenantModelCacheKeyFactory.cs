using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Sharding
{
    internal class TenantModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context, bool designTime)
            => context is GenericDbContext dynamicContext
                ? (context.GetType(), $"{dynamicContext.Paramter.EntityNamespace}:{dynamicContext.Paramter.Suffix}:{(dynamicContext.ShardingOption.GetTenantId==null?"":dynamicContext.ShardingOption.GetTenantId())}", designTime)
                : (object)context.GetType();

        public object Create(DbContext context)
            => Create(context, false);
    }
}
