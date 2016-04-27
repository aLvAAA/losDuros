-- Selecciona la base de datos
use GD2C2015

-- Crea schema
BEGIN TRANSACTION

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'JOHNNY_B_SQL')
EXEC sys.sp_executesql N'CREATE SCHEMA [JOHNNY_B_SQL] AUTHORIZATION [gd]'

COMMIT

-- Drop de tables

IF OBJECT_ID('JOHNNY_B_SQL.IntentoLogin', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.IntentoLogin; 

IF OBJECT_ID('JOHNNY_B_SQL.Rol', 'U') IS NOT NULL
  DROP TABLE JOHNNY_B_SQL.Rol; 

IF OBJECT_ID('JOHNNY_B_SQL.Funcionalidad', 'U') IS NOT NULL
  DROP TABLE JOHNNY_B_SQL.Funcionalidad; 

IF OBJECT_ID('JOHNNY_B_SQL.Tarjeta', 'U') IS NOT NULL
  DROP TABLE JOHNNY_B_SQL.Tarjeta; 

IF OBJECT_ID('JOHNNY_B_SQL.Cliente', 'U') IS NOT NULL
  DROP TABLE JOHNNY_B_SQL.Cliente; 

IF OBJECT_ID('JOHNNY_B_SQL.Usuario', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Usuario; 
  
IF OBJECT_ID('JOHNNY_B_SQL.Pasaje', 'U') IS NOT NULL
  DROP TABLE JOHNNY_B_SQL.Pasaje; 

IF OBJECT_ID('JOHNNY_B_SQL.TipoButaca', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.TipoButaca; 

IF OBJECT_ID('JOHNNY_B_SQL.Butaca', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Butaca; 

IF OBJECT_ID('JOHNNY_B_SQL.Servicio', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Servicio; 

IF OBJECT_ID('JOHNNY_B_SQL.Ruta', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Ruta; 

IF OBJECT_ID('JOHNNY_B_SQL.RutasInconscistentes', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.RutasInconscistentes;

IF OBJECT_ID('JOHNNY_B_SQL.Aeronave', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Aeronave; 

IF OBJECT_ID('JOHNNY_B_SQL.Ciudad', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Ciudad; 

IF OBJECT_ID('JOHNNY_B_SQL.Viaje', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Viaje; 

IF OBJECT_ID('JOHNNY_B_SQL.Encomienda', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Encomienda; 

IF OBJECT_ID('JOHNNY_B_SQL.Canje', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Canje; 

IF OBJECT_ID('JOHNNY_B_SQL.Producto', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Producto; 

IF OBJECT_ID('JOHNNY_B_SQL.Devolucion', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Devolucion; 

IF OBJECT_ID('JOHNNY_B_SQL.Compra', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.Compra; 

IF OBJECT_ID('JOHNNY_B_SQL.FuncionalidadXRol', 'U') IS NOT NULL
DROP TABLE JOHNNY_B_SQL.FuncionalidadXRol;

-- Creacion de Tables

CREATE TABLE JOHNNY_B_SQL.Funcionalidad(
	func_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	func_desc NVARCHAR(255)
)

CREATE TABLE JOHNNY_B_SQL.Rol(
	rol_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	rol_desc NVARCHAR(255),
	rol_habilitado BIT DEFAULT 1
)


CREATE TABLE JOHNNY_B_SQL.Cliente(
	cliente_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY, 
	cliente_nombre NVARCHAR(255),
	cliente_apellido NVARCHAR(255) ,
	cliente_dni numeric(18, 0) ,
	cliente_mail NVARCHAR(255) ,
	cliente_dir NVARCHAR(255) ,
	cliente_tel numeric(18, 0),
	cliente_fecha_nac DATETIME
)

CREATE TABLE JOHNNY_B_SQL.Tarjeta(
	tarjeta_numero numeric(18, 0),
	tarjeta_cliente numeric(18, 0) REFERENCES JOHNNY_B_SQL.Cliente IDENTITY (1,1) PRIMARY KEY,
	tarjeta_codigo NVARCHAR(255),
	tarjeta_vencimiento DATETIME,
	tarjeta_tipo NVARCHAR(255)
)

CREATE TABLE JOHNNY_B_SQL.Usuario(
	usuario_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	usuario_name NVARCHAR(255) ,
	usuario_password varbinary(8000),
	rol_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Rol 
)

CREATE TABLE JOHNNY_B_SQL.Compra(
	compra_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	compra_fecha DATETIME,
	compra_monto numeric(18,2),
	compra_cuotas numeric(18,0) DEFAULT 1,
	compra_comprador numeric(18, 0) REFERENCES JOHNNY_B_SQL.Cliente,
	compra_tarjeta numeric(18, 0) REFERENCES JOHNNY_B_SQL.Tarjeta
)

CREATE TABLE JOHNNY_B_SQL.Pasaje(
	pasaje_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	viaje_id numeric(18, 0),
	pasaje_butaca numeric(18, 0),
	pasaje_precio numeric(18, 2),
	pasaje_cliente numeric(18, 0) REFERENCES JOHNNY_B_SQL.Cliente,
	compra_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Compra
)

CREATE TABLE JOHNNY_B_SQL.TipoButaca(
	t_butaca_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	t_butaca_descripcion NVARCHAR(255) 

)
CREATE TABLE JOHNNY_B_SQL.Butaca(
	butaca_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	aeronave_id numeric(18, 0),
	butaca_numero numeric(18, 0),
	butaca_tipo numeric(18, 0) REFERENCES JOHNNY_B_SQL.TipoButaca ,
	butaca_piso numeric(18, 0)	
)
CREATE TABLE JOHNNY_B_SQL.Servicio(
	servicio_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	servicio_descripcion NVARCHAR(255),
	servicio_porcentaje_adicional numeric(18,2)
)

CREATE TABLE JOHNNY_B_SQL.Ruta(
	ruta_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	ruta_origen numeric(18, 0),
	ruta_destino numeric(18, 0),
	ruta_servicio numeric(18, 0) REFERENCES JOHNNY_B_SQL.Servicio,
	ruta_precio_base numeric(18, 2),
	ruta_precio_base_KG numeric(18, 2),
	ruta_habilitada BIT DEFAULT 1
)

CREATE TABLE JOHNNY_B_SQL.RutasInconscistentes(
	ruta_id numeric(18, 0),
	ruta_origen numeric(18, 0),
	ruta_destino numeric(18, 0),
	ruta_servicio numeric(18, 0),
	ruta_precio_base numeric(18, 2),
	ruta_precio_base_KG numeric(18, 2)
)

CREATE TABLE JOHNNY_B_SQL.Aeronave( 
	aero_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	servicio numeric(18, 0) REFERENCES JOHNNY_B_SQL.Servicio,
	aero_fecha_alta DATETIME,
	aero_matricula NVARCHAR(255),
	aero_modelo NVARCHAR(255),
	aero_fabricante NVARCHAR(255),
	aero_kg_disp numeric(18, 2),
	aero_baja_vida_util DATETIME,
	aero_fecha_fuera_serv DATETIME,
	aero_fecha_reinicio_serv DATETIME
	
)

CREATE TABLE JOHNNY_B_SQL.Ciudad(
	ciudad_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	ciudad_desc NVARCHAR(255)
)

CREATE TABLE JOHNNY_B_SQL.Viaje(
	viaje_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	ruta_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Ruta,
	aero_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Aeronave,
	viaje_fecha_salida DATETIME,
	viaje_fecha_estimada DATETIME,
	viaje_fecha_llegada DATETIME
)
CREATE TABLE JOHNNY_B_SQL.Encomienda(
	encom_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	viaje_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Viaje,
	encom_precio numeric(18, 2),
	encom_KG numeric(18, 2),
	compra_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Compra
)

CREATE TABLE JOHNNY_B_SQL.Producto(
	prod_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	prod_desc NVARCHAR(255),
	prod_stock numeric(18, 0),
	prod_millas numeric(18, 0)
)

CREATE TABLE JOHNNY_B_SQL.Canje(
	canje_id numeric(18,0)  IDENTITY (1,1) PRIMARY KEY,
	cliente numeric(18, 0),
	producto numeric(18, 0) REFERENCES JOHNNY_B_SQL.Producto,
	canje_cantidad numeric(18, 0),
	canje_fecha DATETIME,
	canje_millas numeric(18, 0)
)

CREATE TABLE JOHNNY_B_SQL.Devolucion(
	devol_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	compra numeric(18, 0) REFERENCES JOHNNY_B_SQL.Compra,
	devol_fecha DATETIME,
	devol_motivo NVARCHAR(255),
	pasaje_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Pasaje,
	encomienda_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Encomienda
)

CREATE TABLE JOHNNY_B_SQL.FuncionalidadXRol(
	func_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Funcionalidad,
	rol_id numeric(18, 0) REFERENCES JOHNNY_B_SQL.Rol
)

CREATE TABLE JOHNNY_B_SQL.IntentoLogin(
	int_id numeric(18, 0) IDENTITY (1,1) PRIMARY KEY,
	cliente numeric(18, 0) REFERENCES JOHNNY_B_SQL.Usuario
)
-- Migracion: clientes
INSERT INTO JOHNNY_B_SQL.Cliente(cliente_nombre, cliente_apellido, cliente_dni, cliente_dir, cliente_tel, cliente_mail, cliente_fecha_nac)
	SELECT DISTINCT Cli_Nombre,Cli_Apellido,Cli_Dni,Cli_Dir,Cli_Telefono,Cli_Mail,Cli_Fecha_Nac
	FROM gd_esquema.Maestra
	ORDER BY Cli_Dni;

-- Migracion: Ciudades
INSERT INTO JOHNNY_B_SQL.Ciudad(ciudad_desc)
	SELECT DISTINCT Ruta_Ciudad_Destino FROM gd_esquema.Maestra
	UNION
	SELECT DISTINCT Ruta_Ciudad_Origen FROM gd_esquema.Maestra;

-- Migracion: Servicios
INSERT INTO JOHNNY_B_SQL.Servicio(servicio_descripcion,servicio_porcentaje_adicional)
	SELECT DISTINCT Tipo_servicio,0 
	FROM gd_esquema.Maestra;

-- Migracion: Aeronaves
INSERT INTO JOHNNY_B_SQL.Aeronave(servicio,aero_matricula,aero_modelo,aero_fabricante,aero_kg_disp)
	SELECT DISTINCT (SELECT servicio_id FROM JOHNNY_B_SQL.Servicio WHERE servicio_descripcion = M.Tipo_Servicio),
					Aeronave_Matricula,Aeronave_Modelo,Aeronave_Fabricante,Aeronave_KG_Disponibles
	FROM gd_esquema.Maestra M;

-- Migracion: Tipo de Butacas
INSERT INTO JOHNNY_B_SQL.TipoButaca(t_butaca_descripcion)
	SELECT DISTINCT Butaca_Tipo
	FROM gd_esquema.Maestra M;

-- Migracion: Butacas
INSERT INTO JOHNNY_B_SQL.Butaca(aeronave_id,butaca_numero,butaca_tipo,butaca_piso)
	SELECT DISTINCT (SELECT aero_id FROM JOHNNY_B_SQL.Aeronave WHERE aero_matricula = M.Aeronave_Matricula),
					Butaca_Nro,(SELECT t_butaca_id FROM JOHNNY_B_SQL.TipoButaca WHERE t_butaca_descripcion = Butaca_Tipo)
					,Butaca_Piso
	FROM gd_esquema.Maestra M;

-- Migracion: Rutas, agregar en tabla RutasDuplicadas, aquellas con igual codigo pero diferentes valores para las demas columnas
SET IDENTITY_INSERT JOHNNY_B_SQL.Ruta ON
declare @ruta_codigo numeric(18, 0), @origen numeric(18, 0), @destino numeric(18, 0), @precioBase numeric(18,2), @precioBaseKG numeric(18,2),@servicio numeric(18, 0) 
declare rutaCursor5 CURSOR FOR
        SELECT DISTINCT ruta_codigo,
			(SELECT ciudad_id FROM JOHNNY_B_SQL.Ciudad WHERE ciudad_desc = M.Ruta_Ciudad_Origen),
			(SELECT ciudad_id FROM JOHNNY_B_SQL.Ciudad WHERE ciudad_desc = M.Ruta_Ciudad_Destino),
			Ruta_Precio_BasePasaje,Ruta_Precio_BaseKG,
			(SELECT servicio_id FROM JOHNNY_B_SQL.Servicio WHERE servicio_descripcion = Tipo_Servicio)
        FROM gd_esquema.Maestra M
    OPEN rutaCursor5

	FETCH NEXT FROM rutaCursor5 INTO @ruta_codigo,@origen,@destino,@precioBase,@precioBaseKG,@servicio

	WHILE @@FETCH_STATUS = 0 BEGIN
		BEGIN TRY
			INSERT INTO JOHNNY_B_SQL.Ruta(ruta_id,ruta_origen,ruta_destino,ruta_precio_base,ruta_precio_base_KG,ruta_servicio)
			VALUES (@ruta_codigo,@origen,@destino,@precioBase,@precioBaseKG,@servicio)
		END TRY
		BEGIN CATCH
			INSERT INTO JOHNNY_B_SQL.RutasInconscistentes(ruta_id,ruta_origen,ruta_destino,ruta_precio_base,ruta_precio_base_KG,ruta_servicio)
			VALUES (@ruta_codigo,@origen,@destino,@precioBase,@precioBaseKG,@servicio)
		END CATCH
		FETCH NEXT FROM rutaCursor5 INTO @ruta_codigo,@origen,@destino,@precioBase,@precioBaseKG,@servicio
	END
	close rutaCursor5
	deallocate rutaCursor5
GO
SET IDENTITY_INSERT JOHNNY_B_SQL.Ruta OFF

-- Migracion: Viajes
INSERT INTO JOHNNY_B_SQL.Viaje(ruta_id,aero_id,viaje_fecha_salida,viaje_fecha_estimada,viaje_fecha_llegada)
	SELECT DISTINCT Ruta_Codigo,
		(SELECT aero_id FROM JOHNNY_B_SQL.Aeronave WHERE aero_matricula = M.Aeronave_Matricula),FechaSalida,Fecha_LLegada_Estimada,FechaLLegada
	FROM gd_esquema.Maestra M

-- Migracion: Compras
INSERT INTO JOHNNY_B_SQL.Compra(compra_fecha,compra_monto,compra_comprador)
SELECT DISTINCT Pasaje_FechaCompra,Pasaje_Precio,(SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = Cli_Dni) FROM gd_esquema.Maestra
INSERT INTO JOHNNY_B_SQL.Compra(compra_fecha,compra_monto,compra_comprador)
SELECT DISTINCT Paquete_FechaCompra,Paquete_Precio,(SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = Cli_Dni) FROM gd_esquema.Maestra

-- Migracion: Pasajes
SET IDENTITY_INSERT JOHNNY_B_SQL.Pasaje ON
INSERT INTO JOHNNY_B_SQL.Pasaje(pasaje_id,viaje_id,pasaje_butaca,pasaje_precio,pasaje_cliente,compra_id)
	SELECT DISTINCT Pasaje_Codigo,(SELECT viaje_id FROM JOHNNY_B_SQL.Viaje WHERE ruta_id = ruta_codigo AND aero_id = (SELECT aero_id FROM JOHNNY_B_SQL.Aeronave WHERE aero_matricula = Aeronave_Matricula)
		AND viaje_fecha_salida = FechaSalida AND viaje_fecha_llegada = FechaLLegada),
	(SELECT TOP 1 butaca_id FROM JOHNNY_B_SQL.Butaca WHERE butaca_nro = butaca_Nro AND aeronave_id IN (SELECT aero_id FROM JOHNNY_B_SQL.Aeronave WHERE aero_matricula = Aeronave_Matricula)),
	Pasaje_Precio,(SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = Cli_Dni),
	(SELECT TOP 1 compra_id FROM JOHNNY_B_SQL.Compra WHERE compra_fecha = Pasaje_FechaCompra AND compra_monto = Pasaje_Precio AND compra_comprador = (SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = Cli_Dni))
	FROM gd_esquema.Maestra WHERE Pasaje_Codigo != 0
SET IDENTITY_INSERT JOHNNY_B_SQL.Pasaje OFF

-- Migracion: Encomiendas
SET IDENTITY_INSERT JOHNNY_B_SQL.Encomienda ON
INSERT INTO JOHNNY_B_SQL.Encomienda(encom_id,viaje_id,encom_precio,encom_KG,compra_id)
	SELECT DISTINCT Paquete_Codigo,(SELECT viaje_id FROM JOHNNY_B_SQL.Viaje WHERE ruta_id = ruta_codigo AND aero_id = (SELECT aero_id FROM JOHNNY_B_SQL.Aeronave WHERE aero_matricula = Aeronave_Matricula)
		AND viaje_fecha_salida = FechaSalida AND viaje_fecha_llegada = FechaLLegada),Paquete_Precio,Paquete_KG,
	(SELECT TOP 1 compra_id FROM JOHNNY_B_SQL.Compra WHERE compra_fecha = Paquete_FechaCompra AND compra_monto = Paquete_Precio AND compra_comprador = (SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = Cli_Dni))
	FROM gd_esquema.Maestra WHERE Paquete_Codigo != 0
SET IDENTITY_INSERT JOHNNY_B_SQL.Encomienda OFF


--Triggers y Procedures

--Eliminar ciudad, elimina todas sus rutas
IF OBJECT_ID('JOHNNY_B_SQL.EliminarCiudad') IS NOT NULL
	DROP TRIGGER JOHNNY_B_SQL.EliminarCiudad;
GO
CREATE TRIGGER JOHNNY_B_SQL.EliminarCiudad
    ON JOHNNY_B_SQL.Ciudad
    INSTEAD OF DELETE
AS
	--Elimina rutas asociadas
    DELETE FROM JOHNNY_B_SQL.Ruta
    WHERE ruta_destino IN(SELECT ciudad_id FROM deleted) 
	OR ruta_origen IN (SELECT ciudad_id FROM deleted)

	--Elimina Ciudades
	DELETE FROM JOHNNY_B_SQL.Ciudad
    WHERE ciudad_id IN(SELECT ciudad_id FROM deleted)
GO

IF OBJECT_ID('JOHNNY_B_SQL.Agregar_Viaje') IS NOT NULL
	DROP TRIGGER JOHNNY_B_SQL.Agregar_Viaje;
GO
CREATE TRIGGER JOHNNY_B_SQL.Agregar_Viaje
    ON JOHNNY_B_SQL.Viaje
    INSTEAD OF INSERT
AS
	BEGIN TRANSACTION
	declare @ruta_id numeric(18, 0), @aero_id numeric(18, 0), @fecha_salida datetime, @fecha_llegada datetime

	declare cursorViaje CURSOR FOR
        SELECT ruta_id,aero_id,viaje_fecha_salida,viaje_fecha_estimada
        FROM inserted
    OPEN cursorViaje

	FETCH NEXT FROM cursorViaje INTO @ruta_id,@aero_id,@fecha_salida,@fecha_llegada

	WHILE @@FETCH_STATUS = 0 BEGIN
		
		--Chequear que la aeronave y la ruta no tengan el mismo tipo de servicio
		declare @ruta_servicio numeric(18, 0), @aero_servicio numeric(18,0)
		SET @ruta_servicio = (SELECT ruta_servicio FROM Ruta WHERE ruta_id = @ruta_id)
		SET @aero_servicio = (SELECT servicio FROM Aeronave a WHERE aero_id = @aero_id)

		IF(@ruta_servicio != @aero_servicio) BEGIN
			RAISERROR (15599,-1,-1, 'La ruta y la aeronave no ofrecen el mismo tipo de servicio!')
			ROLLBACK
		END

		--Chequear que la aeronave esté disponible
		
		IF((SELECT count(*) FROM Viaje WHERE aero_id = @aero_id AND viaje_fecha_salida <= @fecha_llegada
			 AND viaje_fecha_estimada >= @fecha_salida) > 0) BEGIN
			 RAISERROR (15600,-1,-1, 'La aeronave ya realiza otro viaje en esa fecha!')
			 ROLLBACK
		END

		IF((SELECT count(*) FROM Aeronave WHERE aero_id = @aero_id AND (aero_baja_vida_util IS NOT NULL OR
				(aero_fecha_fuera_serv IS NOT NULL AND aero_fecha_reinicio_serv > @fecha_salida))) > 0) BEGIN
			 RAISERROR (15601,-1,-1, 'La aeronave no estará en servicio para la fecha de salida!')
			 ROLLBACK
		END


		FETCH NEXT FROM cursorViaje INTO @ruta_id,@aero_id,@fecha_salida,@fecha_llegada
	END

	INSERT INTO Viaje([ruta_id],[aero_id],[viaje_fecha_salida],[viaje_fecha_estimada])
		SELECT ruta_id,aero_id,viaje_fecha_salida,viaje_fecha_estimada FROM inserted
	CLOSE cursorViaje
	DEALLOCATE cursorViaje

	COMMIT
GO

--Eliminar ruta, elimina todos sus pasajes y encomiendas
IF OBJECT_ID('JOHNNY_B_SQL.EliminarRuta') IS NOT NULL
	DROP TRIGGER JOHNNY_B_SQL.EliminarRuta;
GO
CREATE TRIGGER JOHNNY_B_SQL.EliminarRuta
    ON JOHNNY_B_SQL.Ruta
    INSTEAD OF DELETE
AS
	declare @viajes table(viaje numeric(18,0))
	INSERT INTO @viajes SELECT viaje_id FROM JOHNNY_B_SQL.Viaje v WHERE v.ruta_id IN (SELECT ruta_id FROM deleted)

	INSERT INTO JOHNNY_B_SQL.Devolucion(compra,devol_fecha,devol_motivo,pasaje_id) SELECT p.compra_id,GETDATE(),'Ruta Eliminada',pasaje_id FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id IN (SELECT viaje_id FROM @viajes)
	INSERT INTO JOHNNY_B_SQL.Devolucion(compra,devol_fecha,devol_motivo,encomienda_id) SELECT p.compra_id,GETDATE(),'Ruta Eliminada',encom_id FROM JOHNNY_B_SQL.Encomienda p WHERE p.viaje_id IN (SELECT viaje_id FROM @viajes)
	UPDATE [JOHNNY_B_SQL].[Ruta]
		SET [ruta_habilitada] = 0 WHERE ruta_id IN (SELECT ruta_id FROM deleted)
GO

--Buscar Rutas
IF OBJECT_ID('JOHNNY_B_SQL.BuscarRutas') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.BuscarRutas;
GO
CREATE PROCEDURE JOHNNY_B_SQL.BuscarRutas(@origen numeric(18,0),@destino numeric(18,0),@servicio numeric(18,0),@pasaje numeric(18,2),@kg numeric(18,2))
AS
	declare @query nvarchar(256)
	set @query = 'SELECT * FROM JOHNNY_B_SQL.Ruta WHERE 1=1 '

	if(@origen != -1) SET @query += ' AND ruta_origen = '+CAST(@origen as nvarchar(2))+' ';
	if(@destino != -1) SET @query += ' AND ruta_destino = '+CAST(@destino as nvarchar(2))+' ';
	if(@servicio != -1) SET @query += ' AND ruta_servicio = '+CAST(@servicio as nvarchar(2))+' ';
	if(@pasaje != -1) SET @query += ' AND ruta_precio_base = '+CAST(@pasaje as nvarchar(6))+' ';
	if(@kg != -1) SET @query += ' AND ruta_precio_base_KG = '+CAST(@kg as nvarchar(6))+' ';

		
	print @query

	execute sp_executesql @query
GO
--Intentar Login
IF OBJECT_ID('JOHNNY_B_SQL.IntentarLogin') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.IntentarLogin;
GO
CREATE PROCEDURE [JOHNNY_B_SQL].[IntentarLogin](@usuario nvarchar(255),@password varbinary(8000))
AS
	declare @cantUsuarios numeric
	declare @usrId numeric

	set @cantUsuarios = (select isNull((select usuario_id FROM JOHNNY_B_SQL.Usuario 
	left join JOHNNY_B_SQL.IntentoLogin i on usuario_id = i.cliente
	WHERE 1=1 AND usuario_name = @usuario
	AND usuario_password = @password
	group by usuario_id
	having count(i.cliente)<3),0))
	IF @cantUsuarios = 0
	BEGIN
		set @usrId = (select usuario_id FROM JOHNNY_B_SQL.Usuario where usuario_name = @usuario)
		
		if (not exists (select usuario_id FROM JOHNNY_B_SQL.Usuario where usuario_name = @usuario))
		begin 
			RAISERROR (40001,-1,-1, 'El Usuario no existe!')
			select 0
			return;
		end
		
		if((select count(int_id) from JOHNNY_B_SQL.IntentoLogin  where cliente = @usrId) > 2)
		begin
			RAISERROR (40002,-1,-1, 'Usuario Bloqueado!')
			select 0
			return;
		end
		if (exists (select usuario_id FROM JOHNNY_B_SQL.Usuario where usuario_name = @usuario))
		begin 
			RAISERROR (40003,-1,-1, 'Password incorrecta')
			insert into JOHNNY_B_SQL.IntentoLogin (cliente)
			values(@usrId);
			
			return;
		end 
		
	END
	ELSE 
	BEGIN
	set @usrId = (SELECT usuario_id FROM JOHNNY_B_SQL.Usuario WHERE usuario_name = @usuario 
	AND usuario_password = @password )
	DELETE FROM JOHNNY_B_SQL.IntentoLogin WHERE cliente = @usrId
	
	SELECT @usrId
	END
GO
-- Registrar Usuario
IF OBJECT_ID('JOHNNY_B_SQL.RegistrarUsuario') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.RegistrarUsuario;
GO
CREATE PROCEDURE JOHNNY_B_SQL.RegistrarUsuario(@usuario nvarchar(255),@pass nvarchar(255))
AS
INSERT INTO JOHNNY_B_SQL.Usuario SELECT @usuario,HASHBYTES('SHA2_256',@pass),null
GO
--Buscar Por Viaje
IF OBJECT_ID('JOHNNY_B_SQL.BuscarPorViaje') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.BuscarPorViaje;
GO
CREATE PROCEDURE JOHNNY_B_SQL.BuscarPorViaje(@matricula nvarchar(255),@origen numeric(18,0),@destino numeric(18,0))
AS
	SELECT TOP 1 a.[aero_id]
		,[servicio]
      ,[aero_fecha_alta]
      ,[aero_matricula]
      ,[aero_modelo]
      ,[aero_fabricante]
      ,[aero_kg_disp], v.viaje_id FROM JOHNNY_B_SQL.Aeronave a JOIN JOHNNY_B_SQL.Viaje v ON a.aero_id=v.aero_id
	  JOIN JOHNNY_B_SQL.Ruta r ON v.ruta_id = r.ruta_id WHERE a.aero_matricula=@matricula AND ruta_origen=@origen AND ruta_destino=@destino
	  AND v.viaje_fecha_llegada IS NULL 
	  AND (aero_baja_vida_util IS NULL AND
				(aero_fecha_fuera_serv IS NULL OR aero_fecha_reinicio_serv < GETDATE()))
	  ORDER BY v.viaje_id DESC
GO
-- Registrar Llegada
IF OBJECT_ID('JOHNNY_B_SQL.RegistrarLLegada') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.RegistrarLLegada;
GO
CREATE PROCEDURE JOHNNY_B_SQL.RegistrarLLegada(@viaje numeric(18,0),@fecha datetime)
AS
BEGIN TRANSACTION
	declare @salida datetime

	-- Obtener fecha de salida del viaje
	SET @salida = (SELECT [viaje_fecha_salida] FROM [JOHNNY_B_SQL].[Viaje] WHERE [viaje_id] = @viaje)

	-- Validar que sea anterior a la de llegada
	IF(@fecha <= @salida)BEGIN
			RAISERROR (40001,-1,-1, 'La fecha ingresada es anterior a la fecha de salida!')
			ROLLBACK
	END

	UPDATE [JOHNNY_B_SQL].[Viaje]
	SET [viaje_fecha_llegada] = @fecha
	WHERE [viaje_id] = @viaje
COMMIT
GO

-- Buscar Aeronave Por Fecha De Viaje
IF OBJECT_ID('JOHNNY_B_SQL.BuscarAeronavePorFechaDeViaje') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.BuscarAeronavePorFechaDeViaje;
GO
CREATE PROCEDURE JOHNNY_B_SQL.BuscarAeronavePorFechaDeViaje(@fecha datetime,@origen numeric(18,0),@destino numeric(18,0))
AS
	SELECT (SELECT servicio_descripcion FROM JOHNNY_B_SQL.Servicio WHERE [servicio_id]=a.[servicio]) as 'servicio_descripcion'
      ,[aero_matricula]
      ,[aero_modelo]
	  ,((SELECT count(*) FROM JOHNNY_B_SQL.Butaca b WHERE b.aeronave_id=a.aero_id) -
		(SELECT count(*) FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id=v.viaje_id)) as 'butacasDisponibles',
		([aero_kg_disp]) -
		(SELECT count(*) FROM JOHNNY_B_SQL.Encomienda e WHERE e.viaje_id=v.viaje_id) as 'KilosDisponibles'
      , v.viaje_id FROM JOHNNY_B_SQL.Aeronave a JOIN JOHNNY_B_SQL.Viaje v ON a.aero_id=v.aero_id
	  JOIN JOHNNY_B_SQL.Ruta r ON v.ruta_id = r.ruta_id WHERE CONVERT(date,v.viaje_fecha_salida)=CONVERT(date,@fecha) 
	  AND ruta_origen=@origen AND ruta_destino=@destino AND ruta_habilitada = 1
		AND (aero_baja_vida_util IS NULL AND
				(aero_fecha_fuera_serv IS NULL OR aero_fecha_reinicio_serv < @fecha))
		ORDER BY v.viaje_id DESC
GO

IF OBJECT_ID('JOHNNY_B_SQL.ButacasPorViaje') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ButacasPorViaje;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ButacasPorViaje(@viaje numeric(18,0))
AS
	SELECT butaca_id, butaca_numero,butaca_tipo FROM JOHNNY_B_SQL.Butaca 
	JOIN JOHNNY_B_SQL.Aeronave a ON aeronave_id=aero_id
	JOIN JOHNNY_B_SQL.Viaje v ON v.aero_id=a.aero_id
	WHERE v.viaje_id=@viaje
	AND ((butaca_id NOT IN (SELECT pasaje_butaca FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id = @viaje)) OR
	((butaca_id IN (SELECT pasaje_butaca FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id = @viaje)) 
		AND (butaca_id IN (SELECT pasaje_butaca FROM JOHNNY_B_SQL.Pasaje p 
		JOIN JOHNNY_B_SQL.Compra c ON p.compra_id=c.compra_id
		JOIN JOHNNY_B_SQL.Devolucion d ON d.compra=p.compra_id
		WHERE p.viaje_id=@viaje))))		
	ORDER BY butaca_numero
GO

IF OBJECT_ID('JOHNNY_B_SQL.CalcularPrecioPasaje') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.CalcularPrecioPasaje;
GO
CREATE PROCEDURE JOHNNY_B_SQL.CalcularPrecioPasaje(@viaje_id decimal)
AS

declare @procentaje int, @base decimal
SET @procentaje = (SELECT servicio_porcentaje_adicional FROM JOHNNY_B_SQL.Viaje v JOIN JOHNNY_B_SQL.Ruta r ON v.ruta_id = r.ruta_id
	JOIN JOHNNY_B_SQL.Servicio s ON r.ruta_servicio = s.servicio_id WHERE viaje_id=@viaje_id)

SET @base = (SELECT ruta_precio_base FROM JOHNNY_B_SQL.Viaje v JOIN JOHNNY_B_SQL.Ruta r ON v.ruta_id = r.ruta_id WHERE viaje_id=@viaje_id)

SELECT @base + (@base * @procentaje) / 100

GO

IF OBJECT_ID('JOHNNY_B_SQL.CalcularPrecioEncomienda') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.CalcularPrecioEncomienda;
GO
CREATE PROCEDURE JOHNNY_B_SQL.CalcularPrecioEncomienda(@viaje_id decimal,@kilos decimal)
AS

declare @base decimal

SET @base = (SELECT ruta_precio_base_KG FROM JOHNNY_B_SQL.Viaje v JOIN JOHNNY_B_SQL.Ruta r ON v.ruta_id = r.ruta_id
	WHERE viaje_id = @viaje_id)

SELECT (@base * @kilos)

GO

IF OBJECT_ID('JOHNNY_B_SQL.AgregarTarjeta') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AgregarTarjeta;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AgregarTarjeta(@numero int,@codigo nvarchar(128),@vencimiento datetime, @tipo nvarchar(128), @comprador numeric(18,0))
AS

SET IDENTITY_INSERT JOHNNY_B_SQL.Tarjeta ON
INSERT INTO JOHNNY_B_SQL.Tarjeta
                         (tarjeta_numero, tarjeta_codigo, tarjeta_vencimiento, tarjeta_tipo, tarjeta_cliente)
VALUES(@numero,@codigo,@vencimiento,@tipo,@comprador)

GO
IF OBJECT_ID('JOHNNY_B_SQL.UpdateClientePorDni') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.UpdateClientePorDni;
GO
CREATE PROCEDURE JOHNNY_B_SQL.UpdateClientePorDni(@cliente_nombre nvarchar(255),@cliente_apellido nvarchar(255),
	@cliente_mail nvarchar(255),@cliente_dir nvarchar(255), @cliente_tel int, @cliente_fecha_nac datetime, @cliente_dni numeric(18,0))
AS
	UPDATE JOHNNY_B_SQL.Cliente
	SET cliente_nombre = @cliente_nombre, cliente_apellido = @cliente_apellido, cliente_mail = @cliente_mail, cliente_dir = @cliente_dir, cliente_tel = @cliente_tel, cliente_fecha_nac = @cliente_fecha_nac
	WHERE (cliente_dni = @cliente_dni)

	SELECT TOP 1 cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = @cliente_dni
GO
IF OBJECT_ID('JOHNNY_B_SQL.GenerarCompra') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.GenerarCompra;
GO

CREATE PROCEDURE JOHNNY_B_SQL.GenerarCompra
(
	@compra_fecha datetime,
	@compra_monto numeric(18, 2),
	@compra_cuotas numeric(18, 0),
	@compra_comprador numeric(18, 0),
	@compra_tarjeta numeric(18, 0)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [JOHNNY_B_SQL].[Compra] ([compra_fecha], [compra_monto], [compra_cuotas], [compra_comprador], [compra_tarjeta]) VALUES (@compra_fecha, @compra_monto, @compra_cuotas, @compra_comprador, @compra_tarjeta);
	
SELECT compra_id, compra_fecha, compra_monto, compra_cuotas, compra_comprador, compra_tarjeta FROM JOHNNY_B_SQL.Compra WHERE (compra_id = SCOPE_IDENTITY())
GO

IF OBJECT_ID('JOHNNY_B_SQL.ObtenerViajesSolapantes') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ObtenerViajesSolapantes;
GO

CREATE PROCEDURE JOHNNY_B_SQL.ObtenerViajesSolapantes
(
	@cliente numeric(18, 0),
	@viaje_id numeric(18, 0)
)
AS
declare @fecha_salida datetime, @fecha_llegada datetime
set @fecha_salida = (SELECT viaje_fecha_salida FROM JOHNNY_B_SQL.Viaje WHERE viaje_id = @viaje_id)
set @fecha_llegada = (SELECT viaje_fecha_estimada FROM JOHNNY_B_SQL.Viaje WHERE viaje_id = @viaje_id)

SELECT count(*) FROM JOHNNY_B_SQL.Viaje v JOIN JOHNNY_B_SQL.Pasaje p ON p.viaje_id = v.viaje_id
 WHERE v.viaje_id != @viaje_id AND pasaje_cliente = @cliente 
 AND viaje_fecha_salida <= @fecha_llegada AND viaje_fecha_estimada >= @fecha_salida
GO
IF OBJECT_ID('JOHNNY_B_SQL.CompraTieneEncomienda') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.CompraTieneEncomienda;
GO
CREATE PROCEDURE JOHNNY_B_SQL.CompraTieneEncomienda(@compra numeric(18,0))
AS
	SELECT TOP 1 * FROM JOHNNY_B_SQL.Encomienda e WHERE e.compra_id = @compra
		AND e.encom_id NOT IN (SELECT d.encomienda_id FROM JOHNNY_B_SQL.Devolucion d WHERE d.compra = @compra)
GO
IF OBJECT_ID('JOHNNY_B_SQL.ObtenerPasajesDeCompra') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ObtenerPasajesDeCompra;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ObtenerPasajesDeCompra(@compra numeric(18,0))
AS
	SELECT pasaje_id,pasaje_precio, (cliente_nombre + ' ' + cliente_apellido) as 'NombreApellido' FROM JOHNNY_B_SQL.Cliente 
		JOIN JOHNNY_B_SQL.Pasaje p ON pasaje_cliente = cliente_id WHERE p.compra_id = @compra
		AND pasaje_id NOT IN (SELECT d.pasaje_id FROM JOHNNY_B_SQL.Devolucion d WHERE d.compra = @compra)
GO
IF OBJECT_ID('JOHNNY_B_SQL.DestinosMasComprados') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.DestinosMasComprados;
GO
CREATE PROCEDURE JOHNNY_B_SQL.DestinosMasComprados(@inicio datetime, @fin datetime)
AS
	declare @comprasPorDestino table (ciudad_id numeric(18,0),ciudad_desc varchar(128),compras int)
	INSERT INTO @comprasPorDestino (ciudad_id,ciudad_desc,compras)
		(SELECT ciudad_id,ciudad_desc,COUNT(*) FROM JOHNNY_B_SQL.Ciudad JOIN JOHNNY_B_SQL.Ruta r ON ruta_destino=ciudad_id
			JOIN JOHNNY_B_SQL.Viaje v ON v.ruta_id=r.ruta_id
			JOIN JOHNNY_B_SQL.Pasaje p ON p.viaje_id = v.viaje_id
			JOIN JOHNNY_B_SQL.Compra c ON p.compra_id = c.compra_id
			WHERE c.compra_fecha > @inicio AND c.compra_fecha < @fin
			GROUP BY ciudad_id,ciudad_desc)
	SELECT TOP 5 * FROM @comprasPorDestino ORDER BY compras DESC
GO
IF OBJECT_ID('JOHNNY_B_SQL.DestinosConAeronavesMasVacias') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.DestinosConAeronavesMasVacias;
GO
CREATE PROCEDURE JOHNNY_B_SQL.DestinosConAeronavesMasVacias(@inicio datetime, @fin datetime)
AS
	declare @butacasVaciasPorDestino table (ciudad_id numeric(18,0),ciudad_desc varchar(128),butacasVacias int)
	INSERT INTO @butacasVaciasPorDestino (ciudad_id,ciudad_desc,butacasVacias)
		(SELECT ciudad_id,ciudad_desc,COUNT(*) FROM JOHNNY_B_SQL.Ciudad 
			JOIN JOHNNY_B_SQL.Ruta r ON ruta_destino=ciudad_id
			JOIN JOHNNY_B_SQL.Viaje v ON v.ruta_id=r.ruta_id
			JOIN JOHNNY_B_SQL.Aeronave a ON a.aero_id = v.viaje_id
			JOIN JOHNNY_B_SQL.Butaca b ON a.aero_id = b.aeronave_id
			WHERE v.viaje_fecha_salida > @inicio AND v.viaje_fecha_salida < @fin 
				AND b.butaca_id NOT IN (Select pasaje_butaca FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id = v.viaje_id)
			GROUP BY ciudad_id,ciudad_desc)
	SELECT TOP 5 * FROM @butacasVaciasPorDestino ORDER BY butacasVacias DESC
GO
IF OBJECT_ID('JOHNNY_B_SQL.DestinosCancelados') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.DestinosCancelados;
GO
CREATE PROCEDURE JOHNNY_B_SQL.DestinosCancelados(@inicio datetime, @fin datetime)
AS
	declare @pasajesCancelados table (ciudad_id numeric(18,0),ciudad_desc varchar(128),pasajes_cancelados int)
	INSERT INTO @pasajesCancelados (ciudad_id,ciudad_desc,pasajes_cancelados)
		(SELECT ciudad_id,ciudad_desc,COUNT(*) FROM JOHNNY_B_SQL.Ciudad 
			JOIN JOHNNY_B_SQL.Ruta r ON ruta_destino=ciudad_id
			JOIN JOHNNY_B_SQL.Viaje v ON v.ruta_id=r.ruta_id
			JOIN JOHNNY_B_SQL.Pasaje p ON p.viaje_id=v.viaje_id
			JOIN JOHNNY_B_SQL.Devolucion d ON p.pasaje_id=d.pasaje_id
			WHERE d.devol_fecha > @inicio AND d.devol_fecha < @fin 
			GROUP BY ciudad_id,ciudad_desc)
	SELECT TOP 5 * FROM @pasajesCancelados ORDER BY pasajes_cancelados DESC
GO
IF OBJECT_ID('JOHNNY_B_SQL.AeronavesMasFueraDeServicio') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AeronavesMasFueraDeServicio;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AeronavesMasFueraDeServicio(@inicio datetime, @fin datetime)
AS
	declare @aeronaves table (aero_id numeric(18,0),aero_matricula varchar(128),aero_modelo varchar(128),
		aero_fabricante varchar(128),dias_fuera_servicio int)
	INSERT INTO @aeronaves (aero_id,aero_matricula,aero_modelo,aero_fabricante,dias_fuera_servicio)
		(SELECT aero_id,aero_matricula,aero_modelo,aero_fabricante,SUM(DATEDIFF(dy,aero_fecha_fuera_serv,aero_fecha_reinicio_serv))
			FROM JOHNNY_B_SQL.Aeronave
			WHERE aero_fecha_fuera_serv > @inicio AND aero_fecha_fuera_serv < @fin AND aero_fecha_reinicio_serv IS NOT NULL
			GROUP BY aero_id,aero_matricula,aero_modelo,aero_fabricante)
	SELECT TOP 5 * FROM @aeronaves ORDER BY dias_fuera_servicio DESC
GO
IF OBJECT_ID('JOHNNY_B_SQL.MasPuntosAcumulados') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.MasPuntosAcumulados;
GO
CREATE PROCEDURE JOHNNY_B_SQL.MasPuntosAcumulados(@inicio datetime, @fin datetime)
AS
	declare @encomiendas table (cliente_id numeric(18,0),cliente_dni numeric(18,0),cliente_nombre varchar(128),cliente_apellido varchar(128),
		cliente_mail varchar(128),puntos int)
	INSERT INTO @encomiendas (cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos)
		(SELECT cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,SUM(encom_precio/10)
			FROM JOHNNY_B_SQL.Cliente
			JOIN JOHNNY_B_SQL.Compra c ON c.compra_comprador = cliente_id
			JOIN JOHNNY_B_SQL.Encomienda e ON e.compra_id = c.compra_id
			WHERE c.compra_fecha > @inicio AND c.compra_fecha < @fin
			GROUP BY cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail)

	declare @pasajes table (cliente_id numeric(18,0),cliente_dni numeric(18,0),cliente_nombre varchar(128),cliente_apellido varchar(128),
		cliente_mail varchar(128),puntos int)
	INSERT INTO @pasajes (cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos)
		(SELECT cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,SUM(pasaje_precio/10)
			FROM JOHNNY_B_SQL.Cliente
			JOIN JOHNNY_B_SQL.Pasaje p ON p.pasaje_cliente = cliente_id
			JOIN JOHNNY_B_SQL.Viaje v ON p.viaje_id = v.viaje_id
			WHERE v.viaje_fecha_salida > @inicio AND v.viaje_fecha_salida < @fin
			GROUP BY cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail)

	declare @puntos table (cliente_id numeric(18,0),cliente_dni numeric(18,0),cliente_nombre varchar(128),cliente_apellido varchar(128),
		cliente_mail varchar(128),puntos int)
	INSERT INTO @puntos (cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos)
	(SELECT cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos
	FROM @encomiendas UNION SELECT cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos
	FROM @pasajes)

	declare @puntosTotales table (cliente_id numeric(18,0),cliente_dni numeric(18,0),cliente_nombre varchar(128),cliente_apellido varchar(128),
		cliente_mail varchar(128),puntos int)
	INSERT INTO @puntosTotales (cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,puntos)
	(SELECT cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail,SUM(puntos)
	FROM @puntos GROUP BY cliente_id,cliente_dni,cliente_nombre,cliente_apellido,cliente_mail)

	SELECT TOP 5 * FROM @puntosTotales ORDER BY puntos DESC
GO
IF OBJECT_ID('JOHNNY_B_SQL.AgregarRuta') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AgregarRuta;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AgregarRuta(@ruta_codigo numeric(18,0),@ruta_origen numeric(18,0),@ruta_destino numeric(18,0),@ruta_servicio numeric(18,0)
	,@ruta_precio_base numeric(18,2),@ruta_precio_base_KG numeric(18,2))
AS
	SET IDENTITY_INSERT JOHNNY_B_SQL.Ruta ON
		INSERT INTO JOHNNY_B_SQL.Ruta(ruta_id, ruta_origen, ruta_destino, ruta_servicio, ruta_precio_base, ruta_precio_base_KG)
		VALUES(@ruta_codigo,@ruta_origen,@ruta_destino,@ruta_servicio,@ruta_precio_base,@ruta_precio_base_KG)
	SET IDENTITY_INSERT JOHNNY_B_SQL.Ruta OFF
GO

--Consultar millas
IF OBJECT_ID('JOHNNY_B_SQL.ConsultaMillas') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ConsultaMillas;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ConsultaMillas(@dni numeric(18,0))
AS
	declare @encomiendas numeric(18,0)
	declare @viajes numeric(18,0)
	declare @canjes numeric(18,0)

	set @viajes = (SELECT SUM(pasaje_precio/10)
					FROM JOHNNY_B_SQL.Cliente c
					JOIN JOHNNY_B_SQL.Compra co ON co.compra_comprador = cliente_id
					JOIN JOHNNY_B_SQL.Pasaje p ON p.pasaje_cliente = cliente_id
					JOIN JOHNNY_B_SQL.Viaje v ON p.viaje_id = v.viaje_id WHERE c.cliente_dni = @dni and co.compra_fecha > DATEADD(year, -1, GETDATE()))

	set @canjes = (SELECT ISNULL(( SELECT SUM(c.canje_millas) from JOHNNY_B_SQL.Canje c 
					join JOHNNY_B_SQL.Cliente cl on  c.cliente = cl.cliente_id WHERE cl.cliente_dni = @dni and c.canje_fecha > DATEADD(year, -1, GETDATE())),0))

	set @encomiendas = (SELECT SUM(encom_precio/10)
							FROM JOHNNY_B_SQL.Cliente c
							JOIN JOHNNY_B_SQL.Compra co ON co.compra_comprador = cliente_id
							JOIN JOHNNY_B_SQL.Encomienda e ON e.compra_id = co.compra_id
							JOIN JOHNNY_B_SQL.Viaje v ON e.viaje_id = v.viaje_id WHERE c.cliente_dni = 1115843 and co.compra_fecha > DATEADD(year, -1, GETDATE()))

	SELECT (@viajes + @encomiendas) - @canjes
GO
--Agregar aeronave
IF OBJECT_ID('JOHNNY_B_SQL.AgregarAeronave') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AgregarAeronave;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AgregarAeronave(@matricula nvarchar(255),@modelo nvarchar(255),@fabricante nvarchar(255),@servicio numeric(18,0),@kgDisp numeric(18,2), @cantVentanilla numeric(18,0), @cantPasillo numeric(18,0))
AS
	declare @aeroId numeric(18,0)
	declare @i numeric(18,0)

	IF (not exists (SELECT aero_matricula from JOHNNY_B_SQL.Aeronave where aero_matricula = @matricula))
	BEGIN
		--Insertar aeronave
		INSERT INTO [JOHNNY_B_SQL].[Aeronave]
           ([servicio]
           ,[aero_fecha_alta]
           ,[aero_matricula]
           ,[aero_modelo]
           ,[aero_fabricante]
           ,[aero_kg_disp])
           
		VALUES
           (@servicio
           ,GETDATE()
           ,@matricula
           ,@modelo
           ,@fabricante
           ,@kgDisp)

		--Obtener Id
		set @aeroId = (SELECT aero_id from JOHNNY_B_SQL.Aeronave where aero_matricula = @matricula)

		--Insertar butacas
		set @i = 1
		while @i <= @cantVentanilla
		BEGIN
			INSERT INTO [JOHNNY_B_SQL].[Butaca]
					([aeronave_id]
					,[butaca_numero]
					,[butaca_tipo]
					,[butaca_piso])
				VALUES
					(@aeroId
					,@i
					,(SELECT t_butaca_id FROM [JOHNNY_B_SQL].[TipoButaca] WHERE t_butaca_descripcion LIKE 'Ventanilla')
					,0)
			set @i = (@i + 1)
		END

		set @i = 1
		while @i <= @cantPasillo
		BEGIN
			INSERT INTO [JOHNNY_B_SQL].[Butaca]
					([aeronave_id]
					,[butaca_numero]
					,[butaca_tipo]
					,[butaca_piso])
				VALUES
					(@aeroId
					,@i
					,(SELECT t_butaca_id FROM [JOHNNY_B_SQL].[TipoButaca] WHERE t_butaca_descripcion LIKE 'Pasillo')
					,0)
			set @i = (@i + 1)
		END
	END
	ELSE 
	BEGIN
		RAISERROR (40001,-1,-1, 'Ya existe una Aeronave con esa matricula')
		RETURN
	END
GO
IF OBJECT_ID('JOHNNY_B_SQL.CanjesPorDni') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.CanjesPorDni;
GO
CREATE PROCEDURE JOHNNY_B_SQL.CanjesPorDni(@dni numeric(18,0))
AS
	SELECT canje_id,prod_desc as 'Nombre Producto',canje_cantidad as 'cantidad',canje_millas as 'millas',canje_fecha as 'fecha' FROM JOHNNY_B_SQL.Canje 
	JOIN  JOHNNY_B_SQL.Producto ON producto = prod_id
	WHERE cliente IN (SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = @dni)
GO
IF OBJECT_ID('JOHNNY_B_SQL.MillasDeEncomiendas') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.MillasDeEncomiendas;
GO
CREATE PROCEDURE JOHNNY_B_SQL.MillasDeEncomiendas(@dni numeric(18,0))
AS
	SELECT encom_id, encom_KG as 'Kilos', convert(int,ROUND(encom_precio/10,0)) as 'Millas Adquiridas',compra_fecha as 'Fecha'
	FROM JOHNNY_B_SQL.Encomienda e
	JOIN JOHNNY_B_SQL.Compra c ON e.compra_id = c.compra_id
	WHERE c.compra_comprador IN (SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = @dni)
	AND c.compra_fecha > DATEADD(year, -1, GETDATE())
GO
IF OBJECT_ID('JOHNNY_B_SQL.MillasDeViajes') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.MillasDeViajes;
GO
CREATE PROCEDURE JOHNNY_B_SQL.MillasDeViajes(@dni numeric(18,0))
AS
	SELECT pasaje_id,convert(int,ROUND(pasaje_precio/10,0)) as 'Millas Adquiridas', c.compra_fecha as 'Fecha'
	FROM JOHNNY_B_SQL.Pasaje p
	JOIN JOHNNY_B_SQL.Compra c ON p.compra_id = c.compra_id
	JOIN JOHNNY_B_SQL.Viaje v ON p.viaje_id = v.viaje_id
	WHERE p.pasaje_cliente IN (SELECT cliente_id FROM JOHNNY_B_SQL.Cliente WHERE cliente_dni = @dni)
	AND c.compra_fecha > DATEADD(year, -1, GETDATE())
GO
IF OBJECT_ID('JOHNNY_B_SQL.RestarStock') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.RestarStock;
GO
CREATE PROCEDURE JOHNNY_B_SQL.RestarStock(@id numeric(18,0),@cant int)
AS
	UPDATE [JOHNNY_B_SQL].[Producto]
	SET [prod_stock] -= @cant
	WHERE prod_id=@id
GO

IF OBJECT_ID('JOHNNY_B_SQL.TienePasajesVendidosEntre') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.TienePasajesVendidosEntre;
GO
CREATE PROCEDURE JOHNNY_B_SQL.TienePasajesVendidosEntre(@id_aero numeric(18,0), @fechaInicio datetime, @fechaFin datetime)
AS
	declare @pasajesVendidos numeric(18,0)
	declare @encomiendas numeric(18,0)

	set @pasajesVendidos = (SELECT count(p.pasaje_id)
							FROM JOHNNY_B_SQL.Viaje v
							join JOHNNY_B_SQL.Aeronave a on v.aero_id = @id_aero
							join JOHNNY_B_SQL.Pasaje p on p.viaje_id = v.viaje_id
							where (v.viaje_fecha_salida >= @fechaInicio) or (v.viaje_fecha_salida <= @fechaFin))

	set @encomiendas = (SELECT count(e.encom_id)
							FROM JOHNNY_B_SQL.Viaje v
							join JOHNNY_B_SQL.Aeronave a on v.aero_id = @id_aero
							join JOHNNY_B_SQL.Encomienda e on e.viaje_id = v.viaje_id
							where (v.viaje_fecha_salida >= @fechaInicio) or (v.viaje_fecha_salida <= @fechaFin))

	SELECT @encomiendas + @pasajesVendidos

GO
IF OBJECT_ID('JOHNNY_B_SQL.TienePasajesVendidosAPartirDe') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.TienePasajesVendidosAPartirDe;
GO
CREATE PROCEDURE JOHNNY_B_SQL.TienePasajesVendidosAPartirDe(@id_aero numeric(18,0), @fecha datetime)
AS
	declare @pasajesVendidos numeric(18,0)
	declare @encomiendas numeric(18,0)

	set @pasajesVendidos = (SELECT count(p.pasaje_id)
							FROM JOHNNY_B_SQL.Viaje v
							join JOHNNY_B_SQL.Aeronave a on v.aero_id = @id_aero
							join JOHNNY_B_SQL.Pasaje p on p.viaje_id = v.viaje_id
							where v.viaje_fecha_salida >= @fecha )

	set @encomiendas = (SELECT count(e.encom_id)
							FROM JOHNNY_B_SQL.Viaje v
							join JOHNNY_B_SQL.Aeronave a on v.aero_id = @id_aero
							join JOHNNY_B_SQL.Encomienda e on e.viaje_id = v.viaje_id
							where v.viaje_fecha_salida >= @fecha )

	SELECT @encomiendas + @pasajesVendidos as 'Numero'
GO

IF OBJECT_ID('JOHNNY_B_SQL.ReasignarAeronaveDesdeHasta') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ReasignarAeronaveDesdeHasta;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ReasignarAeronaveDesdeHasta(@aero_nueva numeric(18,0), @aero_anterior numeric(18,0), @fechaDesde datetime, @fechaHasta datetime)
AS
	UPDATE [JOHNNY_B_SQL].[Viaje]
   SET  [aero_id] = @aero_nueva
   where aero_id = @aero_anterior and (([viaje_fecha_salida] >= @fechaDesde) or ([viaje_fecha_salida] <= @fechaHasta))
      
GO

IF OBJECT_ID('JOHNNY_B_SQL.ReasignarAeronaveDesde') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ReasignarAeronaveDesde;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ReasignarAeronaveDesde(@aero_nueva numeric(18,0), @aero_anterior numeric(18,0), @fechaDesde datetime)
AS
	UPDATE [JOHNNY_B_SQL].[Viaje]
   SET  [aero_id] = @aero_nueva
   where aero_id = @aero_anterior and ([viaje_fecha_salida] >= @fechaDesde) 
      
GO 
IF OBJECT_ID('JOHNNY_B_SQL.FueraDeServicio') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.FueraDeServicio;
GO
CREATE PROCEDURE JOHNNY_B_SQL.FueraDeServicio(@id_aero numeric(18,0), @desde datetime, @hasta datetime)
AS
	BEGIN
		UPDATE [JOHNNY_B_SQL].[Aeronave]
		SET [aero_fecha_fuera_serv] = @desde
		,[aero_fecha_reinicio_serv] = @hasta
		WHERE aero_id = @id_aero
    END
GO
--Aeronaves de la misma flota
IF OBJECT_ID('JOHNNY_B_SQL.ObtenerAeronavesMismaFlota') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.ObtenerAeronavesMismaFlota;
GO
CREATE PROCEDURE JOHNNY_B_SQL.ObtenerAeronavesMismaFlota(@id_aero numeric(18,0))
AS
	declare @serv numeric(18,0)
	declare @modelo nvarchar(255)
	declare @fab nvarchar(255)
	declare @rutas table (ruta_id numeric(18,0), fecha datetime )
	
	insert into @rutas (ruta_id, fecha )
	(SELECT v.ruta_id, v.viaje_fecha_salida FROM JOHNNY_B_SQL.Pasaje p join JOHNNY_B_SQL.Viaje v on p.viaje_id = v.viaje_id where v.aero_id = @id_aero)
	
	set @serv = (SELECT [servicio] FROM [JOHNNY_B_SQL].[Aeronave] WHERE [aero_id] = @id_aero)
	set @modelo = (SELECT [aero_modelo] FROM [JOHNNY_B_SQL].[Aeronave] WHERE [aero_id] = @id_aero)
	set @fab = (SELECT [aero_fabricante] FROM [JOHNNY_B_SQL].[Aeronave] WHERE [aero_id] = @id_aero)
	
	SELECT aero_id , servicio, aero_matricula, aero_modelo, aero_fabricante, aero_kg_disp
	FROM [JOHNNY_B_SQL].[Aeronave]
	where servicio = @serv and aero_fabricante = @fab and aero_modelo = @modelo
GO

IF OBJECT_ID('JOHNNY_B_SQL.TienenMismosViajesProgramadosDesde') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.TienenMismosViajesProgramadosDesde;
GO
CREATE PROCEDURE JOHNNY_B_SQL.TienenMismosViajesProgramadosDesde(@id_aero1 numeric(18,0), @desde datetime, @id_aero2 numeric(18,0))
AS
	declare @corte numeric(18,0)
	set @corte = 0
	declare @viaje_fecha_salida datetime
	declare @viaje_fecha_estimada datetime

	declare viajeAero1 CURSOR FOR
        	SELECT vv.viaje_fecha_salida,vv.viaje_fecha_estimada
			FROM [JOHNNY_B_SQL].Viaje vv
			where vv.aero_id = @id_aero1 and vv.viaje_fecha_salida >= @desde
    OPEN viajeAero1

	FETCH NEXT FROM viajeAero1 INTO @viaje_fecha_salida , @viaje_fecha_estimada 

	--Chequear que por cada viaje del aero1, no haya uno que colisione del aero2
	WHILE @@FETCH_STATUS = 0 AND @corte = 0 BEGIN		
		IF exists (SELECT v.viaje_id FROM [JOHNNY_B_SQL].Viaje v where v.aero_id = @id_aero2 AND viaje_fecha_salida <= @viaje_fecha_estimada AND viaje_fecha_estimada >= @viaje_fecha_salida)
			BEGIN
				set @corte = 1
			END
		FETCH NEXT FROM viajeAero1 INTO @viaje_fecha_salida , @viaje_fecha_estimada 
	END
	close viajeAero1
	deallocate viajeAero1
	SELECT @corte as 'hayColision'
GO

IF OBJECT_ID('JOHNNY_B_SQL.TienenMismosViajesProgramadosDesdeHasta') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.TienenMismosViajesProgramadosDesdeHasta;
GO
CREATE PROCEDURE JOHNNY_B_SQL.TienenMismosViajesProgramadosDesdeHasta(@id_aero1 numeric(18,0), @desde datetime, @hasta datetime, @id_aero2 numeric(18,0))
AS
	declare @corte numeric(18,0)
	set @corte = 0
	declare @viaje_fecha_salida datetime
	declare @viaje_fecha_estimada datetime

	declare viajeAero1 CURSOR FOR
        	SELECT vv.viaje_fecha_salida,vv.viaje_fecha_estimada
			FROM [JOHNNY_B_SQL].Viaje vv
			where vv.aero_id = @id_aero1 and vv.viaje_fecha_salida >= @desde and vv.viaje_fecha_salida <= @hasta
    OPEN viajeAero1

	FETCH NEXT FROM viajeAero1 INTO @viaje_fecha_salida , @viaje_fecha_estimada 

	--Chequear que por cada viaje del aero1, no haya uno que colisione del aero2
	WHILE @@FETCH_STATUS = 0 AND @corte = 0 BEGIN		
		IF exists (SELECT v.viaje_id FROM [JOHNNY_B_SQL].Viaje v where v.aero_id = @id_aero2 AND viaje_fecha_salida <= @viaje_fecha_estimada AND viaje_fecha_estimada >= @viaje_fecha_salida)
			BEGIN
				set @corte = 1
			END
		FETCH NEXT FROM viajeAero1 INTO @viaje_fecha_salida , @viaje_fecha_estimada 
	END
	close viajeAero1
	deallocate viajeAero1
	SELECT @corte as 'hayColision'
GO
IF OBJECT_ID('JOHNNY_B_SQL.GetAeronavesHabilitadas') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.GetAeronavesHabilitadas;
GO
CREATE PROCEDURE JOHNNY_B_SQL.GetAeronavesHabilitadas
AS
	SELECT aero_id,aero_matricula,aero_fabricante,aero_modelo,servicio,aero_kg_disp,
	(SELECT count(*) FROM JOHNNY_B_SQL.Butaca WHERE aeronave_id = aero_id) as 'Total Butacas'
	FROM JOHNNY_B_SQL.Aeronave WHERE aero_baja_vida_util IS NULL AND (aero_fecha_fuera_serv IS NULL OR aero_fecha_reinicio_serv < GETDATE())
GO
IF OBJECT_ID('JOHNNY_B_SQL.BuscarAeronaves') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.BuscarAeronaves;
GO
CREATE PROCEDURE JOHNNY_B_SQL.BuscarAeronaves(@modelo nvarchar(128),@fabricante nvarchar(128),@servicio numeric(18,0),@kilosDisponibles numeric(18,2))
AS
	declare @query nvarchar(256)
	set @query = 'SELECT aero_id,aero_matricula,aero_fabricante,aero_modelo,servicio,aero_kg_disp,
	(SELECT count(*) FROM JOHNNY_B_SQL.Butaca WHERE aeronave_id = aero_id) as '+QUOTENAME('Total Butacas','''')+' FROM JOHNNY_B_SQL.Aeronave WHERE 1=1 '

	if(LEN(@modelo) > 0) SET @query += ' AND aero_modelo LIKE '+QUOTENAME(@modelo,'''') +' ';
	if(LEN(@fabricante) > 0) SET @query += ' AND aero_fabricante LIKE '+QUOTENAME(@fabricante,'''')+' ';
	if(@servicio != -1) SET @query += ' AND servicio = '+CAST(@servicio as nvarchar(6))+' ';
	if(@kilosDisponibles != -1) SET @query += ' AND aero_kg_disp = '+CAST(@kilosDisponibles as nvarchar(6))+' ';
		
	print @query

	execute sp_executesql @query
GO
IF OBJECT_ID('JOHNNY_B_SQL.UpdateAeronave') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.UpdateAeronave;
GO
CREATE PROCEDURE JOHNNY_B_SQL.UpdateAeronave(@modelo nvarchar(128),@fabricante nvarchar(128),@servicio numeric(18,0),@kilosDisponibles numeric(18,2),@id numeric(18,0))
AS
	UPDATE [JOHNNY_B_SQL].[Aeronave]
	   SET [servicio] = @servicio
		  ,[aero_modelo] = @modelo
		  ,[aero_fabricante] = @fabricante
		  ,[aero_kg_disp] = @kilosDisponibles
	 WHERE aero_id = @id
GO
IF OBJECT_ID('JOHNNY_B_SQL.AeronaveBajaDefinitiva') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AeronaveBajaDefinitiva;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AeronaveBajaDefinitiva(@id numeric(18,0))
AS
	UPDATE [JOHNNY_B_SQL].[Aeronave]
	   SET aero_baja_vida_util = GETDATE()
	 WHERE aero_id = @id
GO
IF OBJECT_ID('JOHNNY_B_SQL.AeronaveEliminarViajes') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AeronaveEliminarViajes;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AeronaveEliminarViajes(@id numeric(18,0))
AS
	DELETE FROM [JOHNNY_B_SQL].Viaje
	 WHERE aero_id = @id
GO
IF OBJECT_ID('JOHNNY_B_SQL.AeronaveEliminarViajesComprendidos') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AeronaveEliminarViajesComprendidos;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AeronaveEliminarViajesComprendidos(@id numeric(18,0),@desde datetime, @hasta datetime)
AS
	DELETE FROM [JOHNNY_B_SQL].Viaje
	 WHERE aero_id = @id
	 AND viaje_fecha_salida >= @desde AND viaje_fecha_salida <= @hasta
GO
--Eliminar viaje, elimina todos sus pasajes y encomiendas
IF OBJECT_ID('JOHNNY_B_SQL.EliminarViaje') IS NOT NULL
	DROP TRIGGER JOHNNY_B_SQL.EliminarViaje;
GO
CREATE TRIGGER JOHNNY_B_SQL.EliminarViaje
    ON JOHNNY_B_SQL.Viaje
    INSTEAD OF DELETE
AS
	declare @viajes table(viaje numeric(18,0))
	INSERT INTO @viajes SELECT viaje_id FROM JOHNNY_B_SQL.Viaje v WHERE v.ruta_id IN (SELECT ruta_id FROM deleted)

	INSERT INTO JOHNNY_B_SQL.Devolucion(compra,devol_fecha,devol_motivo,pasaje_id) SELECT p.compra_id,GETDATE(),'Viaje Eliminado',pasaje_id FROM JOHNNY_B_SQL.Pasaje p WHERE p.viaje_id IN (SELECT viaje_id FROM @viajes)
	INSERT INTO JOHNNY_B_SQL.Devolucion(compra,devol_fecha,devol_motivo,encomienda_id) SELECT p.compra_id,GETDATE(),'Viaje Eliminado',encom_id FROM JOHNNY_B_SQL.Encomienda p WHERE p.viaje_id IN (SELECT viaje_id FROM @viajes)
GO
IF OBJECT_ID('JOHNNY_B_SQL.AeronaveIdPorMatricula') IS NOT NULL
	DROP PROCEDURE JOHNNY_B_SQL.AeronaveIdPorMatricula;
GO
CREATE PROCEDURE JOHNNY_B_SQL.AeronaveIdPorMatricula(@matricula varchar(128))
AS
	SELECT aero_id FROM [JOHNNY_B_SQL].[Aeronave]
	 WHERE aero_matricula = @matricula
GO

--Insercion
exec JOHNNY_B_SQL.RegistrarUsuario 'user1','w23e'
exec JOHNNY_B_SQL.RegistrarUsuario 'user2','w23e'
Insert into JOHNNY_B_SQL.Producto(prod_desc,prod_millas,prod_stock) VALUES ('Auto',1000,15),('Picada',15,50),('Entrada de teatro',10,2)