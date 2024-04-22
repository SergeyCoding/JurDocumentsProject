# Migrations sqlite

### Добавить миграцию

```
 Add-Migration <NAME MIGRATION> -Context JurDocsMigrationDbContext -StartupProject JurDocs.DbModel -Project JurDocs.DbModel
```

### Обновить миграцию

```
Update-Database -Context JurDocsMigrationDbContext
```

или

```
Update-Database -Context JurDocsMigrationDbContext -Connection "Data Source=D:\TFS\JurDocsProject\Data\DB\jur-docs.db"
```

### Скрипт

```
Script-Migration -Context JurDocsMigrationDbContext -From 0 -To init
```

```
Script-Migration -From AddIsDeletedToProject -To table_Project_makeNameUniq -Context JurDocsMigrationDbContext -Project JurDocs.DbModel
```
