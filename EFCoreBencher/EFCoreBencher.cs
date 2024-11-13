using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using EFCoreBenchmark.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreBenchmark;

[MemoryDiagnoser]
public class EFCoreBencher
{
    private static PooledDbContextFactory<AdventureWorksContext> _factory;

    [GlobalSetup]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AdventureWorksContext>()
            .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDb;Integrated Security=SSPI;Initial Catalog=AdventureWorks;")
            .EnableThreadSafetyChecks(false)
            .Options;

        _factory = new PooledDbContextFactory<AdventureWorksContext>(options);
        using var ctx = _factory.CreateDbContext();
    }

    [Benchmark()]
    public List<SalesOrderHeader> LoadSalesOrderHeaders()
    {
        using var ctx = _factory.CreateDbContext();
        return ctx.SalesOrderHeaders.AsNoTracking()
            .Where(p => p.SalesOrderId > 50000 && p.SalesOrderId <= 50300)
            .Include(p => p.Customer)
            .Include(p => p.SalesOrderDetails)
            .ToList();
    }   
}