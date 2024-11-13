using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using EFCoreBenchmark.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        ctx.Database.CanConnect(); 
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

    [Benchmark()]
    public async Task<List<SalesOrderHeader>> LoadSalesOrderHeadersAsync()
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.SalesOrderHeaders.AsNoTracking()
            .Where(p => p.SalesOrderId > 50000 && p.SalesOrderId <= 50300)
            .Include(p => p.Customer)
            .Include(p => p.SalesOrderDetails)
            .ToListAsync();
    }   
}