# Database.Model

## Scaffolding the Data Model

After altering the data model using SQL scripts, the corresponding Entity Framework models in this project will need to
be updated to match.

General information about scaffolding can be found in the Entity Framework Core documentation:

[Scaffolding (Reverse Engineering)](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)

The command and options used to scaffold this data model are given below.

> [!IMPORTANT]
> The placeholder value `CONNECTION_STRING` displayed in this article should be replaced with the "ConnectionStrings:TEI" configuration value that contains the connection string used to access your local database.

`dotnet ef dbcontext scaffold`

| Option               | Parameter                                                         |
| -------------------- | :---------------------------------------------------------------- |
| `--project`          | `Database.Model.csproj`                                           |
| `--startup-project`  | `Database.Model.csproj`                                           |
| `--configuration`    | `Debug "CONNECTION_STRING" Npgsql.EntityFrameworkCore.PostgreSQL` |
| `--context`          | `TeiDbContext`                                                    |
| `--context-dir`      | `Context`                                                         |
| `--output-dir`       | `Entities`                                                        |
| `--no-onconfiguring` |                                                                   |
| `--force`            |                                                                   |

Put together, this looks like:

```
dotnet ef dbcontext scaffold --project Database.Model.csproj --startup-project Database.Model.csproj --configuration Debug "CONNECTION_STRING" Npgsql.EntityFrameworkCore.PostgreSQL --context TeiDbContext --context-dir Context --output-dir Entities --no-onconfiguring --force
```

> [!TIP]
> If any tables in the data model are deleted or renamed, it is best to delete the existing Context and Entities folders prior to scaffolding. Otherwise, obsolete entity classes may linger.
