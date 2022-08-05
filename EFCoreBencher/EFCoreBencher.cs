using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using EFCoreBenchmark.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBenchmark
{
    [MemoryDiagnoser]
    public class EFCoreBencher
    {
        private static PooledDbContextFactory<AdventureWorksContext> _factory;
        private static List<int> _keysForIndividualFetches;

        private static Func<AdventureWorksContext, int, SalesOrderHeader> _fetchIndividual =
            EF.CompileQuery((AdventureWorksContext ctx, int key) =>
               ctx.SalesOrderHeaders.AsNoTracking().Single(e => e.SalesOrderId == key));  

        private static Func<AdventureWorksContext, IEnumerable<SalesOrderHeader>> _fetchList =
            EF.CompileQuery((AdventureWorksContext ctx) =>
               ctx.SalesOrderHeaders.AsNoTracking());

        [GlobalSetup]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AdventureWorksContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDb;Integrated Security=SSPI;Initial Catalog=AdventureWorks;")
                .EnableThreadSafetyChecks(false)
                .Options;

            _factory = new PooledDbContextFactory<AdventureWorksContext>(options);
            using var ctx = _factory.CreateDbContext();
            _keysForIndividualFetches = ctx.SalesOrderHeaders.Select(p => p.SalesOrderId).Take(100).ToList();;
        }

        [Benchmark()]
        public List<SalesOrderHeader> LoadListWithAsNoTracking()
        {
            using var ctx = _factory.CreateDbContext();
            return ctx.SalesOrderHeaders.AsNoTracking().ToList();
        }

        [Benchmark()]
        public List<SalesOrderHeader> LoadListWithAsNoTrackingWithIdentityResolution()
        {
            using var ctx = _factory.CreateDbContext();
            return ctx.SalesOrderHeaders.AsNoTrackingWithIdentityResolution().ToList();
        }

        [Benchmark()]
        public List<SalesOrderHeader> LoadListWithCompiledQueryAsNoTracking()
        {
            using var ctx = _factory.CreateDbContext();
            return _fetchList(ctx).ToList();
        }

        [Benchmark()]
        public List<SalesOrderHeader> LoadListWithChangeTracking()
        {
            using var ctx = _factory.CreateDbContext();
            return ctx.SalesOrderHeaders.AsTracking().ToList();
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LoadSingleWithAsNoTracking()
        {
            foreach (var key in _keysForIndividualFetches)
            { 
                using var ctx = _factory.CreateDbContext();
                { 
                    var element = ctx.SalesOrderHeaders.AsNoTracking().FirstOrDefault(p => p.SalesOrderId == key);
                }
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LoadSingleWithAsNoTrackingWithIdentityResolution()
        {
            foreach (var key in _keysForIndividualFetches)
            {
                using var ctx = _factory.CreateDbContext();
                {
                    var element = ctx.SalesOrderHeaders.AsNoTrackingWithIdentityResolution().FirstOrDefault(p => p.SalesOrderId == key);
                }
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LoadSingleWithChangeTracking()
        {
            foreach (var key in _keysForIndividualFetches)
            {
                using var ctx = _factory.CreateDbContext();
                {
                    var element = ctx.SalesOrderHeaders.AsTracking().FirstOrDefault(p => p.SalesOrderId == key);
                }
            }
        }

        [Benchmark(OperationsPerInvoke = 100)]
        public void LoadSingleWithCompiledQueryAsNoTracking()
        {
            foreach (var key in _keysForIndividualFetches)
            {
                using var ctx = _factory.CreateDbContext();
                {
                    var element = _fetchIndividual(ctx, key);
                }
            }
        }
    }
}
