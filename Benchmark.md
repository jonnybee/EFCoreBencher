**EF 8.0.11 vs EF 9.0.0 på hhv .NET 8.0.11 og .NET 9.0.0**

| Method                     | Job       | Runtime     | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Allocated | Alloc Ratio |
|--------------------------- |---------- |------------ |---------:|---------:|---------:|------:|--------:|---------:|---------:|----------:|------------:|
| LoadSalesOrderHeaders      | EF 8.0.11 | .NET 8.0.11 | 11.12 ms | 0.219 ms | 0.384 ms |  1.00 |    0.05 | 156.2500 |  62.5000 |   2.44 MB |        1.00 |
| LoadSalesOrderHeaders      | EF 9.0.0  | .NET 9.0.0  | 20.81 ms | 0.146 ms | 0.114 ms |  1.87 |    0.06 | 500.0000 | 218.7500 |   7.76 MB |        3.19 |
|                            |           |             |          |          |          |       |         |          |          |           |             |
| LoadSalesOrderHeadersAsync | EF 8.0.11 | .NET 8.0.11 | 11.15 ms | 0.201 ms | 0.401 ms |  1.00 |    0.05 | 187.5000 |  62.5000 |   3.24 MB |        1.00 |
| LoadSalesOrderHeadersAsync | EF 9.0.0  | .NET 9.0.0  | 22.55 ms | 0.421 ms | 0.373 ms |  2.03 |    0.08 | 562.5000 | 250.0000 |   8.56 MB |        2.64 |

**EF 8.0.12 vs EF 9.0.1 på hhv .NET 8.0.11 og .NET 9.0.0**

| Method                     | Job       | Runtime     | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Allocated | Alloc Ratio |
|--------------------------- |---------- |------------ |---------:|---------:|---------:|------:|--------:|---------:|---------:|----------:|------------:|
| LoadSalesOrderHeaders      | EF 8.0.12 | .NET 8.0.11 | 10.89 ms | 0.179 ms | 0.167 ms |  1.00 |    0.02 | 156.2500 |  62.5000 |   2.44 MB |        1.00 |
| LoadSalesOrderHeaders      | EF 9.0.1  | .NET 9.0.0  | 11.86 ms | 0.076 ms | 0.067 ms |  1.09 |    0.02 | 171.8750 |  78.1250 |   2.74 MB |        1.13 |
|                            |           |             |          |          |          |       |         |          |          |           |             |
| LoadSalesOrderHeadersAsync | EF 8.0.12 | .NET 8.0.11 | 10.74 ms | 0.164 ms | 0.145 ms |  1.00 |    0.02 | 187.5000 |  62.5000 |   3.24 MB |        1.00 |
| LoadSalesOrderHeadersAsync | EF 9.0.0  | .NET 9.0.1  | 13.58 ms | 0.258 ms | 0.485 ms |  1.26 |    0.05 | 234.3750 |  93.7500 |   3.54 MB |        1.09 |

**EF 8.0.12 vs EF 9.0.1 på hhv .NET 8.0.12 og .NET 9.0.1**

| Method                     | Job       | Runtime     | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Allocated | Alloc Ratio |
|--------------------------- |---------- |------------ |---------:|---------:|---------:|------:|--------:|---------:|---------:|----------:|------------:|
| LoadSalesOrderHeaders      | EF 8.0.12 | .NET 8.0.12 | 10.86 ms | 0.203 ms | 0.200 ms |  1.00 |    0.03 | 156.2500 |  62.5000 |   2.44 MB |        1.00 |
| LoadSalesOrderHeaders      | EF 9.0.1  | .NET 9.0.1  | 12.03 ms | 0.069 ms | 0.058 ms |  1.11 |    0.02 | 171.8750 |  78.1250 |   2.74 MB |        1.13 |
|                            |           |             |          |          |          |       |         |          |          |           |             |
| LoadSalesOrderHeadersAsync | EF 8.0.12 | .NET 8.0.12 | 10.96 ms | 0.135 ms | 0.126 ms |  1.00 |    0.02 | 203.1250 |  78.1250 |   3.24 MB |        1.00 |
| LoadSalesOrderHeadersAsync | EF 9.0.1  | .NET 9.0.1  | 13.37 ms | 0.129 ms | 0.121 ms |  1.22 |    0.02 | 218.7500 |  93.7500 |   3.54 MB |        1.09 |
