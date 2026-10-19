-- ejecuta primero schema.sql y despues datos.sql para cargar los ejemplos
-- deja lo que ya esta guardado y necesita SQL Server 2016 SP1 o mas nuevo
USE master;
GO
IF DB_ID(N'SistemaInventarioDB') IS NULL
    EXEC(N'CREATE DATABASE SistemaInventarioDB');
GO
USE SistemaInventarioDB;
GO
IF OBJECT_ID(N'dbo.Categorias', N'U') IS NULL
CREATE TABLE dbo.Categorias (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500) NOT NULL,
    Activo BIT NOT NULL CONSTRAINT DF_Categorias_Activo DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Categorias_Creacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2 NOT NULL CONSTRAINT DF_Categorias_Modificacion DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_Categorias_Nombre UNIQUE(Nombre),
    CONSTRAINT CK_Categorias_Nombre CHECK(LEN(LTRIM(RTRIM(Nombre))) BETWEEN 3 AND 100),
    CONSTRAINT CK_Categorias_Descripcion CHECK(LEN(LTRIM(RTRIM(Descripcion))) BETWEEN 1 AND 500)
);
GO
IF OBJECT_ID(N'dbo.Suplidores', N'U') IS NULL
CREATE TABLE dbo.Suplidores (
    Id INT IDENTITY PRIMARY KEY,
    NombreEmpresa NVARCHAR(150) NOT NULL,
    NombreContacto NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(12) NOT NULL,
    Correo NVARCHAR(150) NOT NULL,
    SitioWeb NVARCHAR(250) NOT NULL CONSTRAINT DF_Suplidores_Web DEFAULT N'',
    Activo BIT NOT NULL CONSTRAINT DF_Suplidores_Activo DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Suplidores_Creacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2 NOT NULL CONSTRAINT DF_Suplidores_Modificacion DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_Suplidores_Empresa UNIQUE(NombreEmpresa),
    CONSTRAINT CK_Suplidores_Empresa CHECK(LEN(LTRIM(RTRIM(NombreEmpresa))) BETWEEN 3 AND 150),
    CONSTRAINT CK_Suplidores_Contacto CHECK(LEN(LTRIM(RTRIM(NombreContacto))) BETWEEN 3 AND 100),
    CONSTRAINT CK_Suplidores_Telefono CHECK(LEN(Telefono)=12 AND LEFT(Telefono,3) IN ('809','829','849') AND Telefono LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')
);
GO
IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
CREATE TABLE dbo.Productos (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    CategoriaId INT NOT NULL,
    SuplidorId INT NOT NULL,
    FotoNombre NVARCHAR(260) NULL,
    Foto VARBINARY(MAX) NULL,
    Activo BIT NOT NULL CONSTRAINT DF_Productos_Activo DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Productos_Creacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2 NOT NULL CONSTRAINT DF_Productos_Modificacion DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY(CategoriaId) REFERENCES dbo.Categorias(Id),
    CONSTRAINT FK_Productos_Suplidores FOREIGN KEY(SuplidorId) REFERENCES dbo.Suplidores(Id),
    CONSTRAINT CK_Productos_Precio CHECK(PrecioUnitario > 0),
    CONSTRAINT CK_Productos_Nombre CHECK(LEN(LTRIM(RTRIM(Nombre))) BETWEEN 3 AND 150)
);
GO
-- si la base ya existe agrega las columnas que faltan y deja los datos que tenia
IF COL_LENGTH(N'dbo.Productos',N'FotoNombre') IS NULL
    ALTER TABLE dbo.Productos ADD FotoNombre NVARCHAR(260) NULL;
IF COL_LENGTH(N'dbo.Productos',N'Foto') IS NULL
    ALTER TABLE dbo.Productos ADD Foto VARBINARY(MAX) NULL;
GO
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Productos_Foto' AND parent_object_id=OBJECT_ID(N'dbo.Productos'))
    ALTER TABLE dbo.Productos ADD CONSTRAINT CK_Productos_Foto CHECK(
        (Foto IS NULL AND FotoNombre IS NULL) OR
        (Foto IS NOT NULL AND FotoNombre IS NOT NULL AND LEN(LTRIM(RTRIM(FotoNombre))) BETWEEN 1 AND 260 AND DATALENGTH(Foto) BETWEEN 1 AND 2097152)
    );
GO
IF OBJECT_ID(N'dbo.FotosCategoria', N'U') IS NULL
CREATE TABLE dbo.FotosCategoria (
    Id INT IDENTITY PRIMARY KEY,
    CategoriaId INT NOT NULL,
    NombreArchivo NVARCHAR(260) NOT NULL,
    Contenido VARBINARY(MAX) NOT NULL,
    Activo BIT NOT NULL CONSTRAINT DF_Fotos_Activo DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Fotos_Creacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2 NOT NULL CONSTRAINT DF_Fotos_Modificacion DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Fotos_Categorias FOREIGN KEY(CategoriaId) REFERENCES dbo.Categorias(Id),
    CONSTRAINT CK_Fotos_Tamano CHECK(DATALENGTH(Contenido) BETWEEN 1 AND 2097152)
);
GO
IF OBJECT_ID(N'dbo.Usuarios', N'U') IS NULL
CREATE TABLE dbo.Usuarios (
    Id INT IDENTITY PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(100) NOT NULL,
    ClaveHash VARCHAR(100) NOT NULL,
    Sal VARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL,
    Activo BIT NOT NULL CONSTRAINT DF_Usuarios_Activo DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Usuarios_Creacion DEFAULT SYSDATETIME(),
    FechaModificacion DATETIME2 NOT NULL CONSTRAINT DF_Usuarios_Modificacion DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Usuarios_Rol CHECK(Rol IN (N'Administrador',N'Usuario'))
);
GO
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Productos_CategoriaActivo' AND object_id=OBJECT_ID('dbo.Productos'))
CREATE INDEX IX_Productos_CategoriaActivo ON dbo.Productos(CategoriaId,Activo);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Productos_SuplidorActivo' AND object_id=OBJECT_ID('dbo.Productos'))
CREATE INDEX IX_Productos_SuplidorActivo ON dbo.Productos(SuplidorId,Activo);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Fotos_CategoriaActivo' AND object_id=OBJECT_ID('dbo.FotosCategoria'))
CREATE INDEX IX_Fotos_CategoriaActivo ON dbo.FotosCategoria(CategoriaId,Activo);
GO

CREATE OR ALTER PROCEDURE dbo.sp_Categoria_Agregar
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(500),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    INSERT dbo.Categorias(Nombre,Descripcion) VALUES(@Nombre,@Descripcion);
    SET @Id=CONVERT(INT,SCOPE_IDENTITY());
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Categoria_Actualizar
    @Id INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    UPDATE dbo.Categorias SET Nombre=@Nombre, Descripcion=@Descripcion,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o esta en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Categoria_Eliminar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND Activo=1)
        THROW 50003,N'El registro no existe o esta en la papelera.',1;
    IF EXISTS(SELECT 1 FROM dbo.Productos WITH(UPDLOCK,HOLDLOCK) WHERE CategoriaId=@Id AND Activo=1)
        THROW 50004,N'No se puede eliminar porque tiene productos activos asociados.',1;
    UPDATE dbo.Categorias SET Activo=0,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o ya fue eliminado.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Categoria_Restaurar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    UPDATE dbo.Categorias SET Activo=1,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=0;
    IF @@ROWCOUNT=0 THROW 50005,N'El registro no existe en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Suplidor_Agregar
    @NombreEmpresa NVARCHAR(150),
    @NombreContacto NVARCHAR(100),
    @Telefono NVARCHAR(12),
    @Correo NVARCHAR(150),
    @SitioWeb NVARCHAR(250),
    @Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    INSERT dbo.Suplidores(NombreEmpresa,NombreContacto,Telefono,Correo,SitioWeb) VALUES(@NombreEmpresa,@NombreContacto,@Telefono,@Correo,@SitioWeb);
    SET @Id=CONVERT(INT,SCOPE_IDENTITY());
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Suplidor_Actualizar
    @Id INT,
    @NombreEmpresa NVARCHAR(150),
    @NombreContacto NVARCHAR(100),
    @Telefono NVARCHAR(12),
    @Correo NVARCHAR(150),
    @SitioWeb NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    UPDATE dbo.Suplidores SET NombreEmpresa=@NombreEmpresa, NombreContacto=@NombreContacto, Telefono=@Telefono, Correo=@Correo, SitioWeb=@SitioWeb,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o esta en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Suplidor_Eliminar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NOT EXISTS(SELECT 1 FROM dbo.Suplidores WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND Activo=1)
        THROW 50003,N'El registro no existe o esta en la papelera.',1;
    IF EXISTS(SELECT 1 FROM dbo.Productos WITH(UPDLOCK,HOLDLOCK) WHERE SuplidorId=@Id AND Activo=1)
        THROW 50004,N'No se puede eliminar porque tiene productos activos asociados.',1;
    UPDATE dbo.Suplidores SET Activo=0,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o ya fue eliminado.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Suplidor_Restaurar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    UPDATE dbo.Suplidores SET Activo=1,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=0;
    IF @@ROWCOUNT=0 THROW 50005,N'El registro no existe en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Producto_Agregar
    @Nombre NVARCHAR(150),
    @PrecioUnitario DECIMAL(18,2),
    @CategoriaId INT,
    @SuplidorId INT,
    @Id INT OUTPUT,
    @FotoNombre NVARCHAR(260)=NULL,
    @Foto VARBINARY(MAX)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    -- mantiene estos bloqueos hasta que termine la transaccion del repositorio
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@CategoriaId AND Activo=1)
        THROW 50001,N'La categoria debe estar activa.',1;
    IF NOT EXISTS(SELECT 1 FROM dbo.Suplidores WITH(UPDLOCK,HOLDLOCK) WHERE Id=@SuplidorId AND Activo=1)
        THROW 50002,N'El suplidor debe estar activo.',1;
    INSERT dbo.Productos(Nombre,PrecioUnitario,CategoriaId,SuplidorId,FotoNombre,Foto) VALUES(@Nombre,@PrecioUnitario,@CategoriaId,@SuplidorId,@FotoNombre,@Foto);
    SET @Id=CONVERT(INT,SCOPE_IDENTITY());
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Producto_Actualizar
    @Id INT,
    @Nombre NVARCHAR(150),
    @PrecioUnitario DECIMAL(18,2),
    @CategoriaId INT,
    @SuplidorId INT,
    @FotoNombre NVARCHAR(260)=NULL,
    @Foto VARBINARY(MAX)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    -- mantiene estos bloqueos hasta que termine la transaccion del repositorio
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@CategoriaId AND Activo=1)
        THROW 50001,N'La categoria debe estar activa.',1;
    IF NOT EXISTS(SELECT 1 FROM dbo.Suplidores WITH(UPDLOCK,HOLDLOCK) WHERE Id=@SuplidorId AND Activo=1)
        THROW 50002,N'El suplidor debe estar activo.',1;
    UPDATE dbo.Productos SET Nombre=@Nombre, PrecioUnitario=@PrecioUnitario, CategoriaId=@CategoriaId, SuplidorId=@SuplidorId,FotoNombre=@FotoNombre,Foto=@Foto,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o esta en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Producto_Eliminar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    UPDATE dbo.Productos SET Activo=0,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=1;
    IF @@ROWCOUNT=0 THROW 50003,N'El registro no existe o ya fue eliminado.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Producto_Restaurar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    DECLARE @CategoriaId INT,@SuplidorId INT;
    SELECT @CategoriaId=CategoriaId,@SuplidorId=SuplidorId FROM dbo.Productos WHERE Id=@Id AND Activo=0;
    -- mantiene estos bloqueos hasta que termine la transaccion del repositorio
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@CategoriaId AND Activo=1)
        THROW 50001,N'La categoria debe estar activa.',1;
    IF NOT EXISTS(SELECT 1 FROM dbo.Suplidores WITH(UPDLOCK,HOLDLOCK) WHERE Id=@SuplidorId AND Activo=1)
        THROW 50002,N'El suplidor debe estar activo.',1;
    UPDATE dbo.Productos SET Activo=1,FechaModificacion=SYSDATETIME() WHERE Id=@Id AND Activo=0;
    IF @@ROWCOUNT=0 THROW 50005,N'El registro no existe en la papelera.',1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_FotoCategoria_Desactivar
    @CategoriaId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@CategoriaId AND Activo=1)
        THROW 50006,N'La categoria no esta activa.',1;
    UPDATE dbo.FotosCategoria SET Activo=0,FechaModificacion=SYSDATETIME() WHERE CategoriaId=@CategoriaId AND Activo=1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_FotoCategoria_Agregar
    @CategoriaId INT,
    @NombreArchivo NVARCHAR(260),
    @Contenido VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF NOT EXISTS(SELECT 1 FROM dbo.Categorias WITH(UPDLOCK,HOLDLOCK) WHERE Id=@CategoriaId AND Activo=1)
        THROW 50006,N'La categoria no esta activa.',1;
    IF (SELECT COUNT(*) FROM dbo.FotosCategoria WHERE CategoriaId=@CategoriaId AND Activo=1)>=5
        THROW 50007,N'Solo se permiten hasta cinco fotos activas por categoria.',1;
    INSERT dbo.FotosCategoria(CategoriaId,NombreArchivo,Contenido) VALUES(@CategoriaId,@NombreArchivo,@Contenido);
    UPDATE dbo.Categorias SET FechaModificacion=SYSDATETIME() WHERE Id=@CategoriaId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Buscar
    @NombreUsuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    SELECT Id,NombreUsuario,NombreCompleto,ClaveHash,Sal,Rol,Activo,FechaCreacion,FechaModificacion
    FROM dbo.Usuarios WHERE NombreUsuario=@NombreUsuario;
END;
GO

-- datos.sql usa este procedimiento para poner las fotos de ejemplo y dejar las tuyas
CREATE OR ALTER PROCEDURE dbo.sp_Producto_FotoInicial
    @Nombre NVARCHAR(150),
    @FotoNombre NVARCHAR(260),
    @Foto VARBINARY(MAX),
    @FotoAnterior VARBINARY(MAX)=NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    -- corrige solo la foto vieja de ejemplo y deja la que hayas puesto por tu cuenta
    UPDATE dbo.Productos SET FotoNombre=@FotoNombre,Foto=@Foto,FechaModificacion=SYSDATETIME()
    WHERE Nombre=@Nombre AND (Foto IS NULL OR (@FotoAnterior IS NOT NULL AND Foto=@FotoAnterior));
END;
GO
