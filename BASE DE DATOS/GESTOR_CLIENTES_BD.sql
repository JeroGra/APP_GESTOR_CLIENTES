USE [master]
GO
/****** Object:  Database [GESTOR_CLIENTES_BD]    Script Date: 9/4/2024 18:39:32 ******/
CREATE DATABASE [GESTOR_CLIENTES_BD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GESTOR_CLIENTES_BD', FILENAME = N'C:\SQLData\GESTOR_CLIENTES_BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GESTOR_CLIENTES_BD_log', FILENAME = N'C:\SQLData\GESTOR_CLIENTES_BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GESTOR_CLIENTES_BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ARITHABORT OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET  MULTI_USER 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET QUERY_STORE = ON
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GESTOR_CLIENTES_BD]
GO
/****** Object:  Table [dbo].[ADMINISTRADORES]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMINISTRADORES](
	[id_usuario] [int] NOT NULL,
	[clave] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[id_usuario] [int] NOT NULL,
	[id_direccion] [int] NOT NULL,
	[estado] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIRECCIONES]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIRECCIONES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[localidad] [varchar](50) NOT NULL,
	[calle] [varchar](50) NOT NULL,
	[numero] [int] NOT NULL,
	[codigo_postal] [int] NOT NULL,
	[numero_telefono] [bigint] NOT NULL,
 CONSTRAINT [pk_id_direccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fechaNacimiento] [datetime] NOT NULL,
	[dni] [int] NOT NULL,
	[correo] [varchar](50) NOT NULL,
 CONSTRAINT [pk_id_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ADMINISTRADORES] ([id_usuario], [clave]) VALUES (1, N'cxsadm123')
GO
INSERT [dbo].[CLIENTES] ([id_usuario], [id_direccion], [estado]) VALUES (3, 1, 1)
INSERT [dbo].[CLIENTES] ([id_usuario], [id_direccion], [estado]) VALUES (53, 21, 1)
INSERT [dbo].[CLIENTES] ([id_usuario], [id_direccion], [estado]) VALUES (54, 22, 0)
GO
SET IDENTITY_INSERT [dbo].[DIRECCIONES] ON 

INSERT [dbo].[DIRECCIONES] ([id], [provincia], [localidad], [calle], [numero], [codigo_postal], [numero_telefono]) VALUES (1, N'CABA', N'Villa Urquiza', N'XXassds', 2020, 2718, 54911222222)
INSERT [dbo].[DIRECCIONES] ([id], [provincia], [localidad], [calle], [numero], [codigo_postal], [numero_telefono]) VALUES (21, N'Buenos Aires', N'Bosques', N'Alvear', 160, 1889, 23123123123)
INSERT [dbo].[DIRECCIONES] ([id], [provincia], [localidad], [calle], [numero], [codigo_postal], [numero_telefono]) VALUES (22, N'Buenos Aires', N'San Miguel', N'Papugomez', 190, 1663, 9116544775)
SET IDENTITY_INSERT [dbo].[DIRECCIONES] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([id], [nombre], [apellido], [fechaNacimiento], [dni], [correo]) VALUES (1, N'Cosmoxs', N'Zero', CAST(N'2000-07-21T00:00:00.000' AS DateTime), 42489444, N'cxs0@gmail.com')
INSERT [dbo].[USUARIOS] ([id], [nombre], [apellido], [fechaNacimiento], [dni], [correo]) VALUES (3, N'Ana', N'Test', CAST(N'2003-04-17T00:00:00.000' AS DateTime), 22222222, N'anaT@gmail.com')
INSERT [dbo].[USUARIOS] ([id], [nombre], [apellido], [fechaNacimiento], [dni], [correo]) VALUES (53, N'Erika', N'Paredes', CAST(N'2000-05-11T00:00:00.000' AS DateTime), 4260003, N'eriikaaParedes@gmail.com')
INSERT [dbo].[USUARIOS] ([id], [nombre], [apellido], [fechaNacimiento], [dni], [correo]) VALUES (54, N'Facundo', N'Peralta', CAST(N'2006-02-10T00:00:00.000' AS DateTime), 4569458, N'facuper007@gmail.com')
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uk_]    Script Date: 9/4/2024 18:39:32 ******/
ALTER TABLE [dbo].[USUARIOS] ADD  CONSTRAINT [uk_] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [uk_dni]    Script Date: 9/4/2024 18:39:32 ******/
ALTER TABLE [dbo].[USUARIOS] ADD  CONSTRAINT [uk_dni] UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ADMINISTRADORES]  WITH CHECK ADD  CONSTRAINT [adms_fk_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[USUARIOS] ([id])
GO
ALTER TABLE [dbo].[ADMINISTRADORES] CHECK CONSTRAINT [adms_fk_usuario]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD  CONSTRAINT [clis_fk_direccion] FOREIGN KEY([id_direccion])
REFERENCES [dbo].[DIRECCIONES] ([id])
GO
ALTER TABLE [dbo].[CLIENTES] CHECK CONSTRAINT [clis_fk_direccion]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD  CONSTRAINT [clis_fk_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[USUARIOS] ([id])
GO
ALTER TABLE [dbo].[CLIENTES] CHECK CONSTRAINT [clis_fk_usuario]
GO
/****** Object:  StoredProcedure [dbo].[eliminarCliente]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarCliente] 
@idUs int
as
update CLIENTES set estado=0 where id_usuario = @idUs
GO
/****** Object:  StoredProcedure [dbo].[insertarCLiente]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarCLiente] (
@idUs int,
@idDir int
) as begin 
	insert into CLIENTES(id_usuario,id_direccion,estado) 
	values(@idUs ,@idDir,1);
end 
GO
/****** Object:  StoredProcedure [dbo].[insertarDireccion]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarDireccion] (
@provincia varchar(50),
@localidad varchar(50),
@calle varchar(50),
@numero int,
@codigo_postal int,
@numero_telefono bigint
) as begin 
	insert into DIRECCIONES(provincia,localidad,calle,numero,codigo_postal,numero_telefono) 
	values(@provincia ,@localidad,@calle,@numero ,@codigo_postal,@numero_telefono)
	end 
GO
/****** Object:  StoredProcedure [dbo].[insertarTraerDireccion]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarTraerDireccion] (
@provincia varchar(50),
@localidad varchar(50),
@calle varchar(50),
@numero int,
@codigo_postal int,
@numero_telefono bigint
) as begin 
	insert into DIRECCIONES(provincia,localidad,calle,numero,codigo_postal,numero_telefono) 
	values(@provincia ,@localidad,@calle,@numero ,@codigo_postal,@numero_telefono);
	select id from DIRECCIONES where provincia = @provincia and localidad = @localidad and calle = @calle and numero = @numero  and codigo_postal = @codigo_postal and numero_telefono = @numero_telefono
	end 
GO
/****** Object:  StoredProcedure [dbo].[insertarUsuario]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarUsuario] (
@nombre varchar(50),
@apellido varchar(50),
@fechaNacimiento datetime,
@dni int,
@correo varchar(50)
) as begin 
	insert into USUARIOS(nombre,apellido,fechaNacimiento,dni,correo) 
	values(@nombre ,@apellido,@fechaNacimiento,@dni ,@correo);
	select id from USUARIOS where dni = @dni 
end 
GO
/****** Object:  StoredProcedure [dbo].[listarClientes]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listarClientes] AS   SELECT DISTINCT c.*, u.nombre, u.apellido, u.fechaNacimiento, u.dni, u.correo, d.provincia, d.localidad, d.calle, d.numero, d.codigo_postal, d.numero_telefono 
FROM CLIENTES AS c, USUARIOS AS u, DIRECCIONES AS d
WHERE c.id_usuario = u.id AND c.id_direccion = d.id AND c.estado = 1  
GO
/****** Object:  StoredProcedure [dbo].[listarUsuarios]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[listarUsuarios] AS SELECT * FROM USUARIOS
GO
/****** Object:  StoredProcedure [dbo].[modificarUsuarioDireccion]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[modificarUsuarioDireccion]
@idUs int,
@idDir int,
@nombre varchar(50),
@apellido varchar(50),
@fechaNacimiento datetime,
@dni int,
@correo varchar(50),
@provincia varchar(50),
@localidad varchar(50),
@calle varchar(50),
@numero int,
@codigoPostal int,
@numeroTelefono bigint
as
UPDATE USUARIOS set nombre=@nombre, apellido=@apellido, fechaNacimiento=@fechaNacimiento, dni=@dni, correo=@correo where id=@idUs;
UPDATE DIRECCIONES set provincia=@provincia, localidad=@localidad, calle=@calle, numero=@numero, codigo_postal=@codigoPostal, numero_telefono=@numeroTelefono where id=@idDir;
SELECT DISTINCT c.*, u.nombre, u.apellido, u.fechaNacimiento, u.dni, u.correo, d.provincia, d.localidad, d.calle, d.numero, d.codigo_postal, d.numero_telefono 
FROM CLIENTES AS c, USUARIOS AS u, DIRECCIONES AS d
WHERE c.id_usuario = u.id AND c.id_direccion = d.id   
GO
/****** Object:  StoredProcedure [dbo].[obtenerAdministradorPorCredenciales]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[obtenerAdministradorPorCredenciales]
@correo varchar(50),
@clave varchar(50)
as
SELECT u.* , a.clave FROM USUARIOS AS u, ADMINISTRADORES as a 
WHERE a.id_usuario = u.id AND u.correo = @correo AND a.clave = @clave;
GO
/****** Object:  StoredProcedure [dbo].[obtenerClientePorCredenciales]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[obtenerClientePorCredenciales]
@correo varchar(50),
@dni int
as
SELECT c.*, u.nombre, u.apellido, u.fechaNacimiento, u.dni, u.correo, d.provincia, d.localidad, d.calle, d.numero, d.codigo_postal, d.numero_telefono 
FROM CLIENTES AS c, USUARIOS AS u, DIRECCIONES AS d
WHERE c.id_usuario = u.id AND c.id_direccion = d.id AND c.estado = 1 AND u.correo = @correo AND u.dni = @dni
GO
/****** Object:  StoredProcedure [dbo].[obtenerClientePorId]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtenerClientePorId] 
@id int
AS  SELECT DISTINCT c.*, u.nombre, u.apellido, u.fechaNacimiento, u.dni, u.correo, d.provincia, d.localidad, d.calle, d.numero, d.codigo_postal, d.numero_telefono 
FROM CLIENTES AS c, USUARIOS AS u, DIRECCIONES AS d
WHERE c.id_usuario = u.id AND c.id_direccion = d.id AND u.id = @id  
GO
/****** Object:  StoredProcedure [dbo].[obtenerClientesEliminados]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[obtenerClientesEliminados] 
AS  SELECT DISTINCT c.*, u.nombre, u.apellido, u.fechaNacimiento, u.dni, u.correo, d.provincia, d.localidad, d.calle, d.numero, d.codigo_postal, d.numero_telefono 
FROM CLIENTES AS c, USUARIOS AS u, DIRECCIONES AS d
WHERE c.id_usuario = u.id AND c.id_direccion = d.id AND c.estado = 0    
GO
/****** Object:  StoredProcedure [dbo].[traerDireccionId]    Script Date: 9/4/2024 18:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[traerDireccionId] (
@provincia varchar(50),
@localidad varchar(50),
@calle varchar(50),
@numero int,
@codigo_postal int,
@numero_telefono bigint
) as begin 
	select id from DIRECCIONES where provincia = @provincia and localidad = @localidad and calle = @calle and numero = @numero  and codigo_postal = @codigo_postal and numero_telefono = @numero_telefono
	end
GO
USE [master]
GO
ALTER DATABASE [GESTOR_CLIENTES_BD] SET  READ_WRITE 
GO
