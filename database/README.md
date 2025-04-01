# TEI Database

The data model requires a PostgreSQL database with the PostGIS extension installed.

Scripts for initializing the database can be found in the [./init](./init/) folder.

## Production Environment

The [deploy-db.yml](/.github/workflows/deploy-db.yml) workflow runs the SQL scripts in the [./init](./init/) folder on the production database. This workflow is automatically triggered on pushes to the main branch that modify the scripts.

## Local Environment

A local database can be quickly created and removed using Docker with the docker-compose.yml file in this directory.

### Start Up Local Database

This create, initializes, and runs the database.

```console
docker compose up -d
```

### Shut Down Local Database

This stops the database but does not erase its contents.

```console
docker compose down
```

### Delete Local Database

This removes the volume containing the database, erasing its contents. This can only be done when the database is not running.

```console
docker volume rm tei-postgres.local
```
