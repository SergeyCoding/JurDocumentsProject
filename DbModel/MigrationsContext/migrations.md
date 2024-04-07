# Migrations sqlite

### Добавить миграцию

```
 Add-Migration init -Context JurDocsMigrationDbContext
```

### Обновить миграцию

```
Update-Database -Context JurDocsMigrationDbContext
```

или

```
Update-Database -Context JurDocsMigrationDbContext -Connection "Data Source=D:\TFS\JurDocumentsProject\Data\DB\jur-docs.db"
```

### Скрипт

```
Script-Migration -Context JurDocsMigrationDbContext -From 0 -To init
```
