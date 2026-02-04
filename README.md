# Shoppe

## Setting Database

### Connection String for PostgreSql

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ShoppeDb;Username=postgres;Password=sandeep"
}
```

### Packages

`Microsoft.EntityFrameworkCore` 
`Npgsql.EntityFrameworkCore.PostgreSQL` 
`Microsoft.EntityFrameworkCore.Tools: for command line tools`

### Migrating

```
add-migration AddCategoryToDb
update-database
```

### N-Tier Architecture

Create a class library for, `Shoppe.DataAccess`, `Shoppe.Models`, `Shoppe.utils`

Put all related files in respective library.

## Menu Items Features

1. Upload Image

2. Document formatter using `tiny`

3. Upsert (Single page for update & insert)

4. 
