# TEI

## Solution Layout

| Project         | Description                                                                       |
|-----------------|-----------------------------------------------------------------------------------|
| Codes.Client    | Front-end Blazor web application.                                                 |
| Codes.Data      | Simple models or utilities shared between Codes.Client and Codes.Data.            |
| Codes.Server    | **Back-end ASP.NET Core web API and start-up project for the Codes application.** |
| Common.Data     | Simple models or utilities useful for front-end and back-end projects.            |
| Common.Server   | Generalized configuration code for back-end applications.                         |
| Database.Model  | Scaffolded database context and entities.                                         |
| Database.Server | Centralized access to the database.                                               |

### Project References

- Common.Data can be referenced by anything.
- Codes.Data can be referenced by Codes.Client and Codes.Server.
- Database.Model can be referenced by Database.Server, Common.Server, and Codes.Server.
- Database.Server can be referenced by Common.Server and Codes.Server.
- Common.Server can be referenced by Codes.Server.
- Codes.Client can be referenced by Codes.Server.

## Additional Documentation

### Secrets

Some of the configuration values required by the application should be kept secret. These can be configured via environmental variables or other means, but for local development, a good option is to use the [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets#secret-manager). The projects are all configured to use the same user secrets file (through [Directory.Build.props](./Directory.Build.props)).

Here are the configuration settings that should be stored as secrets, with example values for local development.

```json
{
    "ConnectionStrings:TEI": "Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=postgres;"
}
```

### Scaffolding the Data Model

Instructions for scaffolding the data model can be found in the [./Database/Database.Model/](./Database/Database.Model/) folder.
