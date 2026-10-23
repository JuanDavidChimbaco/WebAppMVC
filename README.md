# WebAppMVC

Aplicación web ASP.NET Core MVC con Entity Framework Core. De forma predeterminada utiliza SQLite y guarda la base de datos local en `WebAppMVCDB.db`.

## Requisitos

- .NET SDK 10.0
- (Para aplicar migraciones) herramienta `dotnet-ef` 10.0

Comprueba que el SDK está disponible:

```powershell
dotnet --version
```

## Inicializar el proyecto

Desde la carpeta que contiene `WebAppMVC.csproj`, restaura las dependencias:

```powershell
dotnet restore
```

Instala `dotnet-ef` si aún no está disponible:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.13
```

Si ya está instalado, puedes actualizarlo con:

```powershell
dotnet tool update --global dotnet-ef --version 10.0.13
```

Crea o actualiza la base SQLite aplicando las migraciones:

```powershell
dotnet ef database update
```

Las migraciones del proyecto están en `Migrations/`. La aplicación usa SQLite por defecto; no necesita un servidor de base de datos aparte.

## Ejecutar

Inicia la aplicación con:

```powershell
dotnet run
```

Abre en el navegador la URL que muestre la consola, normalmente una dirección `https://localhost:...` o `http://localhost:...`. Para detener el servidor, pulsa `Ctrl+C`.

También puedes iniciar con recarga automática durante el desarrollo:

```powershell
dotnet watch run
```

## Base de datos

La aplicación usa SQLite por defecto. Su conexión está configurada en `appsettings.json` y utiliza el archivo `WebAppMVCDB.db` en la carpeta de ejecución. Ese archivo es local y está excluido del control de versiones por `.gitignore`.

### Usar SQL Server en desarrollo

El proyecto está preparado para guardar secretos de desarrollo con **User Secrets**. La cadena de conexión de SQL Server no se guarda en `appsettings.json`; configura una cadena local con:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnectionSqlServer" 'Server=localhost,1433;Database=WebAppMVC;User Id=sa;Password=TU_CLAVE;TrustServerCertificate=True;MultipleActiveResultSets=true'
```

Reemplaza `TU_CLAVE` por la contraseña real de SQL Server. No compartas ni publiques el valor del secreto. User Secrets evita incluirlo en el repositorio, pero lo almacena como texto sin cifrar en el perfil local del usuario; no es un almacén para producción.

`dotnet user-secrets list` muestra los valores completos; úsalo solo localmente y no compartas su salida:

```powershell
dotnet user-secrets list
```

En ASP.NET Core, `WebApplication.CreateBuilder` carga User Secrets automáticamente cuando la aplicación se ejecuta en el entorno `Development`. **SQLite sigue siendo el proveedor activo** en `Program.cs`; para usar SQL Server también debes cambiar la configuración de `UseSqlite` a `UseSqlServer` y leer `ConnectionStrings:DefaultConnectionSqlServer`.

En producción, configura `ConnectionStrings__DefaultConnectionSqlServer` como variable de entorno o utiliza un gestor de secretos del entorno de despliegue. No guardes credenciales en `appsettings.json`.

Para crear una migración después de cambiar los modelos o `DataContext`, ejecuta:

```powershell
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update
```
