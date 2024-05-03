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
Update-Database -Context JurDocsMigrationDbContext -Connection "Data Source=C:\Work\TFS\JurDocumentsProject\Data\DB\jur-docs.db"
```

### Скрипт

```
Script-Migration -Context JurDocsMigrationDbContext -From 0 -To init
```

```
Script-Migration -From AddIsDeletedToProject -To table_Project_makeNameUniq -Context JurDocsMigrationDbContext -Project JurDocs.DbModel
Script-Migration -From table_Project_makeNameUniq -To AddTable_JurDocLetter -Context JurDocsMigrationDbContext -Project JurDocs.DbModel -StartupProject JurDocs.DbModel
Script-Migration -From AddTable_JurDocLetter -To Table_JurDocLetter_Add_ProjectId -Context JurDocsMigrationDbContext -Project JurDocs.DbModel -StartupProject JurDocs.DbModel
Script-Migration -From Table_JurDocLetter_Add_ProjectId -To Table_JurDocLetter_RemoveAttr -Context JurDocsMigrationDbContext -Project JurDocs.DbModel -StartupProject JurDocs.DbModel
Script-Migration -From Table_JurDocLetter_RemoveAttr -To Table_JurDocLetter_DateNull -Context JurDocsMigrationDbContext -Project JurDocs.DbModel -StartupProject JurDocs.DbModel
```
