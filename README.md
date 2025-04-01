# Terrestrial Ecosystem Information

[![MIT License](https://img.shields.io/github/license/bcgov/tei.svg)](/LICENSE)
[![Lifecycle](https://img.shields.io/badge/Lifecycle-Experimental-339999)](https://github.com/bcgov/repomountie/blob/master/doc/lifecycle-badges.md)

## Project Information

This project contains a prototype data model and web application used for Biogeoclimatic Ecosystem Classification.

Code for the application can be found in the [/apps](./apps/) folder and files for the database can be found in the [/database](./database/) folder. Additional documentation can be found within.

## Workflows

The [deploy-app.yml](/.github/workflows/deploy-app.yml) workflow builds and deploys the app. This workflow is automatically triggered on all pushes to the main branch.

The [deploy-db.yml](/.github/workflows/deploy-db.yml) workflow runs the SQL scripts in the [/database/init](./database/init/) folder on the production database. This workflow is automatically triggered on pushes to the main branch that modify the scripts.
