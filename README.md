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

### ViewComponents

A ViewComponent is like a mini reusable UI component with its own logic + view.

Think of it like:

🔹 Partial View + Controller logic combined
🔹 Reusable widget (Cart, Category menu, Notifications, etc.)

Use ViewComponent when:

🔹You need database data inside layout
🔹You need reusable UI section
🔹You want logic separated from main page

Examples:
🔹Shopping cart summary
🔹Category sidebar
🔹Latest products
🔹User profile box