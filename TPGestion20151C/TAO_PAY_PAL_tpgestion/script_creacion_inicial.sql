USE GD1C2015
GO

-- -----------------------------------------------------
-- DROP DE TABLAS
-- -----------------------------------------------------
if OBJECT_ID('TAO_PAY_PAL.Apertura_Cuentas') is not null 
DROP TABLE TAO_PAY_PAL.Apertura_Cuentas;
if OBJECT_ID('TAO_PAY_PAL.Cambio_Categoria') is not null 
DROP TABLE TAO_PAY_PAL.Cambio_Categoria;
if OBJECT_ID('TAO_PAY_PAL.Transferencia') is not null 
DROP TABLE TAO_PAY_PAL.Transferencia;
if OBJECT_ID('TAO_PAY_PAL.Retiro') is not null 
DROP TABLE TAO_PAY_PAL.Retiro;
if OBJECT_ID('TAO_PAY_PAL.Banco') is not null 
DROP TABLE TAO_PAY_PAL.Banco;
if OBJECT_ID('TAO_PAY_PAL.Deposito') is not null 
DROP TABLE TAO_PAY_PAL.Deposito;
if OBJECT_ID('TAO_PAY_PAL.Factura') is not null 
DROP TABLE TAO_PAY_PAL.Factura;
if OBJECT_ID('TAO_PAY_PAL.Historial_Auditoria') is not null 
DROP TABLE TAO_PAY_PAL.Historial_Auditoria;
if OBJECT_ID('TAO_PAY_PAL.Cuenta') is not null 
DROP TABLE TAO_PAY_PAL.Cuenta;
if OBJECT_ID('TAO_PAY_PAL.Tipo_Moneda') is not null 
DROP TABLE TAO_PAY_PAL.Tipo_Moneda;
if OBJECT_ID('TAO_PAY_PAL.Categoria_Cuenta') is not null 
DROP TABLE TAO_PAY_PAL.Categoria_Cuenta;
if OBJECT_ID('TAO_PAY_PAL.Estado_Cuenta') is not null 
DROP TABLE TAO_PAY_PAL.Estado_Cuenta;
if OBJECT_ID('TAO_PAY_PAL.Tarjetas_Clientes') is not null 
DROP TABLE TAO_PAY_PAL.Tarjetas_Clientes;
if OBJECT_ID('TAO_PAY_PAL.Emisor_Tarjeta') is not null 
DROP TABLE TAO_PAY_PAL.Emisor_Tarjeta;
if OBJECT_ID('TAO_PAY_PAL.Cliente') is not null 
DROP TABLE TAO_PAY_PAL.Cliente;
if OBJECT_ID('TAO_PAY_PAL.Usuario_x_Rol') is not null 
DROP TABLE TAO_PAY_PAL.Usuario_x_Rol;
if OBJECT_ID('TAO_PAY_PAL.Usuario') is not null 
DROP TABLE TAO_PAY_PAL.Usuario;
if OBJECT_ID('TAO_PAY_PAL.Tipo_Documento') is not null 
DROP TABLE TAO_PAY_PAL.Tipo_Documento;
if OBJECT_ID('TAO_PAY_PAL.Pais') is not null 
DROP TABLE TAO_PAY_PAL.Pais;
if OBJECT_ID('TAO_PAY_PAL.Funcionalidad_x_Rol') is not null 
DROP TABLE TAO_PAY_PAL.Funcionalidad_x_Rol;
if OBJECT_ID('TAO_PAY_PAL.Funcionalidad') is not null 
DROP TABLE TAO_PAY_PAL.Funcionalidad;
if OBJECT_ID('TAO_PAY_PAL.Rol') is not null 
DROP TABLE TAO_PAY_PAL.Rol;
if OBJECT_ID('TAO_PAY_PAL.HistorialInhabilitados') is not null 
DROP TABLE TAO_PAY_PAL.HistorialInhabilitados;

--DROP PROCEDURES ******************

if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Deudores_Globales') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Deudores_Globales;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Deudores_X_Filtro') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Deudores_X_Filtro;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Mostrar_Transacciones') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Mostrar_Transacciones;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Confirmar_OK') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Confirmar_OK;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Datos_Cliente') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Datos_Cliente;

------------------------------------------------------------------------
if OBJECT_ID('TAO_PAY_PAL.sp_Saldo_BuscarCuentasGlobales') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Saldo_BuscarCuentasGlobales;
if OBJECT_ID('TAO_PAY_PAL.sp_Saldo_BuscarCuentasXFiltro') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Saldo_BuscarCuentasXFiltro;
if OBJECT_ID('TAO_PAY_PAL.sp_Saldo_5Retiros') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Saldo_5Retiros;
if OBJECT_ID('TAO_PAY_PAL.sp_Saldo_5Depositos') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Saldo_5Depositos;
if OBJECT_ID('TAO_PAY_PAL.sp_Saldo_10Transferencias') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Saldo_10Transferencias;
if OBJECT_ID('TAO_PAY_PAL.sp_Usuario_Verificar_Username') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Usuario_Verificar_Username;
if OBJECT_ID('TAO_PAY_PAL.sp_Cliente_Alta') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Cliente_Alta;
if OBJECT_ID('TAO_PAY_PAL.sp_Cliente_Editar') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Cliente_Editar;
if OBJECT_ID('TAO_PAY_PAL.sp_Cliente_Habilitar_Inhabilitar') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Cliente_Habilitar_Inhabilitar;
if OBJECT_ID('TAO_PAY_PAL.sp_Clientes_Listado') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Clientes_Listado;
if OBJECT_ID('TAO_PAY_PAL.sp_Cliente_Informacion') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Cliente_Informacion;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Actualizar_Estados_Por_Fecha') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Actualizar_Estados_Por_Fecha;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Insertar') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Insertar;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Editar') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Editar;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Desasociar') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Desasociar;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Listado') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Listado;
if OBJECT_ID('TAO_PAY_PAL.sp_Tarjeta_Informacion') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Tarjeta_Informacion;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Buscar_Actualizar_Deudores') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Buscar_Actualizar_Deudores;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_TraerDetalle') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_TraerDetalle;
if OBJECT_ID('TAO_PAY_PAL.sp_Factura_Datos_Cliente') is not null
DROP PROCEDURE TAO_PAY_PAL.sp_Factura_Datos_Cliente;
if OBJECT_ID('TAO_PAY_PAL.sp_Mostrar_Paises_tipoDoc_Bancos') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Mostrar_Paises_tipoDoc_Bancos;
if OBJECT_ID('TAO_PAY_PAL.sp_Mostrar_Paises_tipoDoc_Bancos_Monedas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Mostrar_Paises_tipoDoc_Bancos_Monedas;
if OBJECT_ID('TAO_PAY_PAL.sp_Retiro_Actualizar_y_Buscar_Cuentas_Por_UserID') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Retiro_Actualizar_y_Buscar_Cuentas_Por_UserID;
if OBJECT_ID('TAO_PAY_PAL.sp_Retiro_Registrar') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Retiro_Registrar;
if OBJECT_ID('TAO_PAY_PAL.sp_Retiro_Generar_Cheque') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Retiro_Generar_Cheque;
if OBJECT_ID('TAO_PAY_PAL.sp_GetRoles') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_GetRoles;
if OBJECT_ID('TAO_PAY_PAL.sp_GetFuncionalidades') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_GetFuncionalidades;
if OBJECT_ID('TAO_PAY_PAL.sp_ValidarUsuario') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ValidarUsuario;
if OBJECT_ID('TAO_PAY_PAL.sp_TieneMasDeUnRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_TieneMasDeUnRol;
if OBJECT_ID('TAO_PAY_PAL.sp_AgregarFuncionalidadRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_AgregarFuncionalidadRol;
if OBJECT_ID('TAO_PAY_PAL.sp_QuitarFuncionalidadRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_QuitarFuncionalidadRol;
if OBJECT_ID('TAO_PAY_PAL.sp_ModificarRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ModificarRol;
if OBJECT_ID('TAO_PAY_PAL.sp_BajaRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BajaRol;
if OBJECT_ID('TAO_PAY_PAL.sp_AltaRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_AltaRol;
if OBJECT_ID('TAO_PAY_PAL.sp_GetEstadoRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_GetEstadoRol;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarRoles') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarRoles;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarFuncionalidadesRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarFuncionalidadesRol;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarCtaTransf') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarCtaTransf;
if OBJECT_ID('TAO_PAY_PAL.sp_ListarCuentas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ListarCuentas;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarCtaTransf') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarCtaTransf;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuenta_Alta') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuenta_Alta;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuenta_Baja') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuenta_Baja;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuenta_Busqueda_X_Filtro') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuenta_Busqueda_X_Filtro;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuenta_Edicion') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuenta_Edicion;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuentas_Clientes_Filtro') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuentas_Clientes_Filtro;
if OBJECT_ID('TAO_PAY_PAL.sp_ListarCuentas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ListarCuentas;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarFuncionalidadesRol') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarFuncionalidadesRol;
if OBJECT_ID('TAO_PAY_PAL.sp_Transferencia') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Transferencia;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarFuncionalidades') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarFuncionalidades;
if OBJECT_ID('TAO_PAY_PAL.sp_Log_Acceso') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Log_Acceso;
if OBJECT_ID('TAO_PAY_PAL.sp_Login_ID') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Login_ID;
if OBJECT_ID('TAO_PAY_PAL.sp_Cuenta_ActualizarAlaFecha') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Cuenta_ActualizarAlaFecha;
if OBJECT_ID('TAO_PAY_PAL.sp_Listado1') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Listado1;
if OBJECT_ID('TAO_PAY_PAL.sp_Listado2') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Listado2;
if OBJECT_ID('TAO_PAY_PAL.sp_Listado3') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Listado3;
if OBJECT_ID('TAO_PAY_PAL.sp_Listado4') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Listado4;
if OBJECT_ID('TAO_PAY_PAL.sp_Listado5') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Listado5;

if OBJECT_ID('TAO_PAY_PAL.sp_ActualizarEstadoTarjetas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ActualizarEstadoTarjetas;
if OBJECT_ID('TAO_PAY_PAL.sp_Buscar_Actualizar_CuentasCliente') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Buscar_Actualizar_CuentasCliente;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarDatosTarjeta') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarDatosTarjeta;
if OBJECT_ID('TAO_PAY_PAL.sp_BuscarTarjetasXCliente') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_BuscarTarjetasXCliente;
if OBJECT_ID('TAO_PAY_PAL.sp_Depositos_Cuentas_Habilitadas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Depositos_Cuentas_Habilitadas;
if OBJECT_ID('TAO_PAY_PAL.sp_Depositos_Depositar') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Depositos_Depositar;
if OBJECT_ID('TAO_PAY_PAL.sp_DesasociarTarjeta') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_DesasociarTarjeta;
if OBJECT_ID('TAO_PAY_PAL.sp_EditarTarjeta') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_EditarTarjeta;
if OBJECT_ID('TAO_PAY_PAL.sp_GenerarChequeRetiro') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_GenerarChequeRetiro;
if OBJECT_ID('TAO_PAY_PAL.sp_InsertarTarjeta') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_InsertarTarjeta;
if OBJECT_ID('TAO_PAY_PAL.sp_RegistrarRetiro') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_RegistrarRetiro;
if OBJECT_ID('TAO_PAY_PAL.sp_Depositos_Tarjetas_Activas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Depositos_Tarjetas_Activas;

if OBJECT_ID('TAO_PAY_PAL.sp_Registra_Cuenta_Inhabilitadas') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Registra_Cuenta_Inhabilitadas;
if OBJECT_ID('TAO_PAY_PAL.sp_ActulizarCamposTransferencia') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_ActulizarCamposTransferencia;
if OBJECT_ID('TAO_PAY_PAL.sp_Rol_habilitado') is not null 
DROP PROCEDURE TAO_PAY_PAL.sp_Rol_habilitado;



-- DROP FUNCIONES
if OBJECT_ID('TAO_PAY_PAL.func_EstadoTarjeta') is not null 
DROP FUNCTION TAO_PAY_PAL.func_EstadoTarjeta;
if OBJECT_ID('TAO_PAY_PAL.func_CodigoBanco') is not null 
DROP FUNCTION TAO_PAY_PAL.func_CodigoBanco;

--DROP TRIGGERS
if OBJECT_ID('TAO_PAY_PAL.tr_Retiro_Actualizar_Saldo') is not null 
DROP TRIGGER TAO_PAY_PAL.tr_Retiro_Actualizar_Saldo;


-- -----------------------------------------------------
-- DROP SCHEMA TAO_PAY_PAL
-- -----------------------------------------------------
if SCHEMA_ID('TAO_PAY_PAL') is not null
DROP SCHEMA TAO_PAY_PAL;

-- -----------------------------------------------------
-- CREATE SCHEMA TAO_PAY_PAL
-- -----------------------------------------------------
IF NOT EXISTS (select * from sys.schemas where name = 'TAO_PAY_PAL')
exec ('CREATE SCHEMA TAO_PAY_PAL');

-- -----------------------------------------------------
-- CREATE TABLAS
-- -----------------------------------------------------
CREATE TABLE  TAO_PAY_PAL.Funcionalidad (
  fun_id NUMERIC(18) IDENTITY(1,1) NOT NULL,
  fun_descripcion VARCHAR(45) NOT NULL,
  PRIMARY KEY (fun_id));


CREATE TABLE  TAO_PAY_PAL.Rol (
  rol_codigo NUMERIC(18) IDENTITY(1,1) NOT NULL,
  rol_descripcion VARCHAR(50) NOT NULL,
  rol_estado CHAR NULL,
  PRIMARY KEY (rol_codigo));


CREATE TABLE  TAO_PAY_PAL.Funcionalidad_x_Rol (
  rol_codigo NUMERIC(18,0) NOT NULL,
  fun_id NUMERIC(18,0) NOT NULL,
  PRIMARY KEY (rol_codigo, fun_id),  
    FOREIGN KEY (rol_codigo) REFERENCES TAO_PAY_PAL.Rol (rol_codigo),
    FOREIGN KEY (fun_id) REFERENCES TAO_PAY_PAL.Funcionalidad (fun_id));

CREATE TABLE  TAO_PAY_PAL.Pais (
  pais_codigo NUMERIC(18) NOT NULL,
  pais_descripcion VARCHAR(250) NULL,
  PRIMARY KEY (pais_codigo));

CREATE TABLE  TAO_PAY_PAL.Tipo_Documento (
  td_codigo NUMERIC(18) NOT NULL,
  td_descripcion VARCHAR(250) NULL,
  PRIMARY KEY (td_codigo));
  
CREATE TABLE  TAO_PAY_PAL.Usuario (  
  usr_id NUMERIC(18) IDENTITY NOT NULL,
  usr_username VARCHAR(50) unique NOT NULL,
  usr_password VARCHAR(100) NOT NULL,
  usr_fechaCreacion DATETIME NOT NULL,
  usr_fechaUltModificacion DATETIME NULL,
  usr_preguntaSecreta VARCHAR(255) NULL,
  usr_respuestaSecreta VARCHAR(255) NULL,
  usr_estado char(1),
  PRIMARY KEY (usr_id));

CREATE TABLE TAO_PAY_PAL.Cliente(  
  cli_id NUMERIC(18) NOT NULL,
  cli_nombre VARCHAR(255) NULL,
  cli_apellido VARCHAR(255) NULL,
  cli_tipoDoc NUMERIC(18) NOT NULL,
  cli_nroDoc NUMERIC(18) NOT NULL,
  cli_paisCodigo NUMERIC(18) NULL,
  cli_domCalle VARCHAR(255) NULL,
  cli_nroCalle NUMERIC(18) NULL,
  cli_domPiso NUMERIC(18) NULL,
  cli_domDepto VARCHAR(10) NULL,
  cli_fechaNacimiento DATETIME NULL,
  cli_mail VARCHAR(255) UNIQUE NULL,
  cli_estado CHAR NULL, -- 'A'activo; 'I': inactivo
  PRIMARY KEY (cli_id),
  constraint unique1 unique (cli_tipoDoc, cli_nroDoc),  
	FOREIGN KEY (cli_id) REFERENCES TAO_PAY_PAL.Usuario (usr_id),
    FOREIGN KEY (cli_paisCodigo) REFERENCES TAO_PAY_PAL.Pais (pais_codigo),
    FOREIGN KEY (cli_tipoDoc) REFERENCES TAO_PAY_PAL.Tipo_Documento (td_codigo));

CREATE TABLE  TAO_PAY_PAL.Usuario_x_Rol (
  usr_id NUMERIC(18,0) NOT NULL,
  rol_codigo NUMERIC(18,0) NOT NULL,
  PRIMARY KEY (usr_id, rol_codigo),  
    FOREIGN KEY (usr_id) REFERENCES TAO_PAY_PAL.Usuario (usr_id),
    FOREIGN KEY (rol_codigo) REFERENCES TAO_PAY_PAL.Rol (rol_codigo));

CREATE TABLE TAO_PAY_PAL.Emisor_Tarjeta(
	emi_id NUMERIC(10) IDENTITY(1,1) NOT NULL,
	emi_descripcion VARCHAR(255) UNIQUE NOT NULL,
	PRIMARY KEY (emi_id));

CREATE TABLE  TAO_PAY_PAL.Tarjetas_Clientes (
  tar_id NUMERIC(18) IDENTITY(1,1) NOT NULL,
  tar_codigo VARCHAR(44) NOT NULL,
  cli_id NUMERIC(18) NOT NULL,
  tar_fechaEmision DATETIME NOT NULL,
  tar_fechaVencimiento DATETIME NOT NULL,
  tar_fechaDesvinculacion DATETIME NULL,
  tar_emisor NUMERIC(10) NOT NULL,
  tar_codigoSeguridad VARCHAR(40) NULL,
  tar_estado CHAR NULL,
  PRIMARY KEY (tar_id, cli_id),
    FOREIGN KEY (cli_id) REFERENCES TAO_PAY_PAL.Cliente (cli_id),
    FOREIGN KEY (tar_emisor) REFERENCES TAO_PAY_PAL.Emisor_Tarjeta (emi_id));

CREATE TABLE  TAO_PAY_PAL.Historial_Auditoria ( 
  audi_id NUMERIC(18) identity(1,1),
  audi_fechaHora DATETIME NULL,
  audi_usuario NUMERIC(18) NOT NULL,
  audi_concepto VARCHAR(45) NULL,
  audi_bandera tinyint NULL,
  PRIMARY KEY (audi_id),
    FOREIGN KEY (audi_usuario) REFERENCES TAO_PAY_PAL.Usuario (usr_id));

CREATE TABLE  TAO_PAY_PAL.Estado_Cuenta (
  estado_codigo NUMERIC(5) IDENTITY(1,1) NOT NULL,
  estado_descricion VARCHAR(50) NULL,
  PRIMARY KEY (estado_codigo));
  
CREATE TABLE  TAO_PAY_PAL.Categoria_Cuenta (
  cat_codigo NUMERIC(5) IDENTITY(1,1) NOT NULL,
  cat_descripcion VARCHAR(50) NULL,
  cat_costoApertura NUMERIC(10,2) NULL,
  cat_costoTransferencia NUMERIC(3,2) NULL,
  cat_tiempoSuscripcion NUMERIC(10) NULL,
  PRIMARY KEY (cat_codigo));

CREATE TABLE  TAO_PAY_PAL.Tipo_Moneda (
  tm_codigo NUMERIC(5) IDENTITY(1,1) NOT NULL,
  tm_descripcion VARCHAR(50) NULL,
  PRIMARY KEY (tm_codigo));

CREATE TABLE  TAO_PAY_PAL.Cuenta (
  cta_numero NUMERIC(18) NOT NULL,
  cta_cli_id NUMERIC(18) NOT NULL,
  cta_fechaCreacion DATETIME NULL,
  cta_fechaCierre DATETIME NULL,
  cta_categoria NUMERIC(5) NOT NULL,
  cta_paisCodigo NUMERIC(18) NOT NULL,
  cta_tipoMoneda NUMERIC(5) NOT NULL,
  cta_estado NUMERIC(5) NOT NULL,
  cta_saldo NUMERIC(18,2) NULL,   
  cta_contadorTrans NUMERIC(5) NULL,
  PRIMARY KEY (cta_numero),
    FOREIGN KEY (cta_estado) REFERENCES TAO_PAY_PAL.Estado_Cuenta (estado_codigo),
    FOREIGN KEY (cta_categoria) REFERENCES TAO_PAY_PAL.Categoria_Cuenta (cat_codigo),
    FOREIGN KEY (cta_paisCodigo) REFERENCES TAO_PAY_PAL.Pais (pais_codigo),
    FOREIGN KEY (cta_tipoMoneda) REFERENCES TAO_PAY_PAL.Tipo_Moneda (tm_codigo),
    FOREIGN KEY (cta_cli_id) REFERENCES TAO_PAY_PAL.Cliente (cli_id));
    
CREATE TABLE  TAO_PAY_PAL.Banco (
  banco_codigo NUMERIC(18) NOT NULL,
  banco_nombre VARCHAR(255) NULL,
  banco_direccion VARCHAR(255) NULL,
  PRIMARY KEY (banco_codigo));

CREATE TABLE  TAO_PAY_PAL.Factura (
  fact_numero NUMERIC(18) NOT NULL,
  fact_fecha DATETIME NULL,
  fact_cli_id NUMERIC(18) NULL,
  fact_montoTotal NUMERIC(18,2) NULL,
  PRIMARY KEY (fact_numero));

CREATE TABLE  TAO_PAY_PAL.Deposito (
  dep_codigo NUMERIC(18) NOT NULL,
  dep_fecha DATETIME NULL,
  dep_importe NUMERIC(18,2) NULL,
  dep_numeroCuenta NUMERIC(18) NOT NULL,
  dep_tar_id NUMERIC(18) NOT NULL,
  dep_cli_id NUMERIC(18) NOT NULL,
  nroFactura NUMERIC(18) NULL,
  PRIMARY KEY (dep_codigo),
    FOREIGN KEY (dep_numeroCuenta) REFERENCES TAO_PAY_PAL.Cuenta (cta_numero),
    FOREIGN KEY (nroFactura) REFERENCES TAO_PAY_PAL.Factura (fact_numero),
    FOREIGN KEY (dep_tar_id,dep_cli_id) REFERENCES TAO_PAY_PAL.Tarjetas_Clientes (tar_id,cli_id));    
  
CREATE TABLE  TAO_PAY_PAL.Retiro (
  ret_codigo NUMERIC(18) NOT NULL,
  ret_fecha DATETIME NULL,
  ret_nroCuenta NUMERIC(18) NOT NULL,
  ret_nroCheque NUMERIC(18) NOT NULL,
  ret_banco_id NUMERIC(18) NOT NULL,
  ret_importe NUMERIC(18,2) NULL,
  nroFactura NUMERIC(18) NULL,
  PRIMARY KEY (ret_codigo),
    FOREIGN KEY (ret_banco_id) REFERENCES TAO_PAY_PAL.Banco (banco_codigo),
    FOREIGN KEY (nroFactura) REFERENCES TAO_PAY_PAL.Factura (fact_numero),
    FOREIGN KEY (ret_nroCuenta) REFERENCES TAO_PAY_PAL.Cuenta (cta_numero));

CREATE TABLE  TAO_PAY_PAL.Transferencia (
  transf_codigo NUMERIC(18) IDENTITY(1,1) NOT NULL,
  transf_fechaHora DATETIME NULL,
  transf_origenCuenta NUMERIC(18) NOT NULL,
  transf_destinoCuenta NUMERIC(18) NOT NULL,
  transf_importe NUMERIC(18,2) NULL,
  transf_Categoria NUMERIC(5) NOT NULL,
  transf_nroFactura NUMERIC(18) NULL, 
  PRIMARY KEY (transf_codigo),	
    FOREIGN KEY (transf_origenCuenta) REFERENCES TAO_PAY_PAL.Cuenta (cta_numero),
    FOREIGN KEY (transf_destinoCuenta) REFERENCES TAO_PAY_PAL.Cuenta (cta_numero),
    FOREIGN KEY (transf_Categoria) REFERENCES TAO_PAY_PAL.Categoria_Cuenta(cat_codigo),
    FOREIGN KEY (transf_nroFactura) REFERENCES TAO_PAY_PAL.Factura(fact_numero));
    

CREATE TABLE TAO_PAY_PAL.Apertura_Cuentas (
	ape_codigo NUMERIC(18) IDENTITY(1,1) NOT NULL,
	ape_fecha DATETIME NOT NULL,
	ape_nroCuenta NUMERIC(18) NOT NULL,
	ape_nroCategoria NUMERIC(5) NOT NULL,
	ape_cantSuscrip NUMERIC(3) NOT NULL,
	ape_nroFactura NUMERIC(18) NULL,
	PRIMARY KEY (ape_codigo),
		FOREIGN KEY (ape_nroCategoria) REFERENCES TAO_PAY_PAL.Categoria_Cuenta(cat_codigo),
		FOREIGN KEY (ape_nroFactura) REFERENCES TAO_PAY_PAL.Factura(fact_numero));
	
CREATE TABLE TAO_PAY_PAL.Cambio_Categoria (
	cc_codigo NUMERIC(18) IDENTITY(1,1) NOT NULL,
	cc_fecha DATETIME NOT NULL,
	cc_nroCuenta NUMERIC(18) NOT NULL,
	cc_viejaCategoria NUMERIC(5) NOT NULL,
	cc_nuevaCategoria NUMERIC(5) NOT NULL,
	cc_cantSuscrip NUMERIC(3) NOT NULL,
	cc_nroFactura NUMERIC(18) NULL,
	PRIMARY KEY (cc_codigo),
		FOREIGN KEY (cc_viejaCategoria) REFERENCES TAO_PAY_PAL.Categoria_Cuenta(cat_codigo),
		FOREIGN KEY (cc_nuevaCategoria) REFERENCES TAO_PAY_PAL.Categoria_Cuenta(cat_codigo),
		FOREIGN KEY (cc_nroFactura) REFERENCES TAO_PAY_PAL.Factura(fact_numero));

    
CREATE TABLE TAO_PAY_PAL.HistorialInhabilitados(
	hi_cuenta numeric(18,0),
	hi_fechaInhab datetime);


-- -----------------------------------------------------
-- MIGRACION DE DATOS
-- -----------------------------------------------------
--Roles
INSERT INTO TAO_PAY_PAL.Rol
VALUES ('Administrador', 'H'), ('Cliente', 'H');


--Funcionalidades
INSERT INTO TAO_PAY_PAL.Funcionalidad
VALUES ('ABM ROL'),	   
	   ('ABM CLIENTE'),
	   ('ABM CUENTA'),
	   ('DEPOSITOS'),
	   ('RETIRO DE EFECTIVO'),
	   ('TRANSFERENCIAS'),
	   ('FACTURACION'),
	   ('CONSULTA SALDOS'),
	   ('LISTADO ESTADISTICO');


--Funcionalidades_x_Rol
INSERT INTO TAO_PAY_PAL.Funcionalidad_x_Rol
VALUES (1,1),(1,2),(1,3),(1,7),(1,8),(1,9), 
	   (2,3),(2,4),(2,5),(2,6),(2,7),(2,8);

--PAISES
INSERT INTO TAO_PAY_PAL.Pais
select distinct Cli_Pais_Codigo as cod_pais, Cli_Pais_Desc as pais from gd_esquema.Maestra
union
select distinct Cuenta_Pais_Codigo as cod_pais, Cuenta_Pais_Desc as pais from gd_esquema.Maestra
order by 1;

--Bancos
INSERT INTO TAO_PAY_PAL.Banco values (10002,'Banco Nación',''),(10003,'Banco Ciudad 1',''),(10004,'Banco Ciudad 2','');

--TIPO DOCUMENTO
INSERT INTO TAO_PAY_PAL.Tipo_Documento values (10002,'Pasaporte'),(10003,'DNI')

--Tipo_Moneda
insert into TAO_PAY_PAL.Tipo_Moneda values ('dolares');

--Estado_Cuenta
insert into TAO_PAY_PAL.Estado_Cuenta values ('habilitada'),('inhabilitada'),('cerrada'),('pendiente de activacion');

--Categoria_Cuenta
insert into TAO_PAY_PAL.Categoria_Cuenta values ('oro',100,0.15,90),('plata',80,0.12,60),('bronce',60,0.10,50),('gratuita',0,0,20),('migracion',0,0.1,30);

--Usuarios
INSERT INTO TAO_PAY_PAL.Usuario -- username = prefijoMail + Los dos ultimo digitos del año de nacimientos
SELECT SUBSTRING(Cli_Mail,1,charindex('@',Cli_Mail)-1)+RIGHT(convert(varchar,year(Cli_Fecha_Nac)),2), '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92',Cuenta_Fecha_Creacion,null,null,null,'A' --123456 --CAMBIOOOO!!!
from gd_esquema.Maestra
group by Cli_Mail,Cli_Fecha_Nac,Cuenta_Fecha_Creacion
order by 1;

--CLIENTES
INSERT INTO TAO_PAY_PAL.Cliente
select ROW_NUMBER() over (order by Cli_Mail) as ID, Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Pais_Codigo, Cli_Dom_Calle, Cli_Dom_Nro, Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Mail,'A'
from gd_esquema.Maestra
group by Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Nro_Doc, Cli_Pais_Codigo, Cli_Dom_Calle, Cli_Dom_Nro, Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Mail;

--Rol_x_Usuarios
insert into TAO_PAY_PAL.Usuario_x_Rol
select usr_id, 2 from TAO_PAY_PAL.Usuario;

--CUENTAS
insert into TAO_PAY_PAL.Cuenta
select t.Cuenta_Numero, t.cli_id, t.Cuenta_Fecha_Creacion, DATEADD(DAY,30,'2017-01-01'),5,
t.Cuenta_Pais_Codigo,1,1,t.saldo+r.SumarSaldo,0
from
(select Cuenta_Numero,cli_id, Cuenta_Fecha_Creacion, Cuenta_Pais_Codigo,
SUM(ISNULL(Deposito_Importe,0))-SUM(ISNULL(Retiro_Importe,0))-SUM(ISNULL(Trans_Importe,0)) as saldo
from gd_esquema.Maestra, TAO_PAY_PAL.Cliente
where Cli_Tipo_Doc_Cod=cli_tipoDoc and Cli_Nro_Doc=cli_nroDoc
group by Cuenta_Numero,cli_id, Cuenta_Fecha_Creacion,Cuenta_Pais_Codigo) t,
(select Cuenta_Dest_Numero, SUM(ISNULL(Trans_Importe,0)) as SumarSaldo from gd_esquema.Maestra group by Cuenta_Dest_Numero) r
where t.Cuenta_Numero=r.Cuenta_Dest_Numero
group by t.Cuenta_Numero, t.cli_id, t.Cuenta_Fecha_Creacion, t.Cuenta_Pais_Codigo,t.saldo,r.SumarSaldo
order by 1;

-- Emisores de Tarjetas
Insert into TAO_PAY_PAL.Emisor_Tarjeta values ('American Express'),('Master Card'),('Visa')

--Tarjetas_Clientes
INSERT INTO TAO_PAY_PAL.Tarjetas_Clientes
select Convert(CHAR,HASHBYTES('SHA1',SUBSTRING(Tarjeta_Numero,1,12)),2)+SUBSTRING(Tarjeta_Numero,13,4),cli_id, Tarjeta_Fecha_Emision,
	   Tarjeta_Fecha_Vencimiento,null, emi_id, Convert(CHAR,HASHBYTES('SHA1',Tarjeta_Codigo_Seg),2), 'A'
from gd_esquema.Maestra , TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Emisor_Tarjeta
where cli_nroDoc=Cli_Nro_Doc and Tarjeta_Codigo_Seg is not null and Tarjeta_Fecha_Emision is not null and Tarjeta_Emisor_Descripcion=emi_descripcion 
	  and Tarjeta_Fecha_Vencimiento is not null and Tarjeta_Numero is not null and Tarjeta_Emisor_Descripcion is not null 
group by  Tarjeta_Numero, cli_id, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, emi_id, Tarjeta_Codigo_Seg
order by 2;
/*
--ClientePreexistente
Update TAO_PAY_PAL.Usuario Set usr_username='cliente1',usr_password='1234' Where usr_id=1
--insert into TAO_PAY_PAL.Usuario_x_Rol values(1,2)
*/
--AdminNuevo
insert into TAO_PAY_PAL.Usuario (usr_username,usr_password,usr_fechaCreacion,usr_preguntaSecreta,usr_respuestaSecreta,usr_estado)
values ('admin','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',getdate(),'¿De que color es el cielo?','celeste','A')	--CAMBIO!!!							
insert into TAO_PAY_PAL.Usuario_x_Rol values((select usr_id from TAO_PAY_PAL.Usuario where usr_username='admin') ,1)
go

--AdminYCliente----> user_name: agata_duarte26 ; usr_password: 123456
insert into TAO_PAY_PAL.Usuario_x_Rol values (1,1);
go

--TABLA FACTURA
INSERT INTO TAO_PAY_PAL.Factura values (0,null,null,null);
INSERT INTO TAO_PAY_PAL.Factura
select Factura_Numero,Factura_Fecha,cli_id,Item_Factura_Importe 
from gd_esquema.Maestra t, TAO_PAY_PAL.Cliente
where t.Cli_Tipo_Doc_Cod=cli_tipoDoc and t.Cli_Nro_Doc=cli_nroDoc and Factura_Numero is not null

--TABLA TRANSFERENCIA
INSERT INTO TAO_PAY_PAL.Transferencia
select Transf_Fecha,Cuenta_Numero,Cuenta_Dest_Numero,Trans_Importe,5,Factura_Numero from gd_esquema.Maestra
where Factura_Numero is not null
order by 1;
go

--TABLA DEPOSITO
insert into TAO_PAY_PAL.Deposito
select Deposito_Codigo,Deposito_Fecha,Deposito_Importe,c.cta_numero,t.tar_id,t.cli_id,0
from gd_esquema.Maestra m, TAO_PAY_PAL.Cliente cl, TAO_PAY_PAL.Cuenta c, TAO_PAY_PAL.Tarjetas_Clientes t
where (Convert(CHAR,HASHBYTES('SHA1',SUBSTRING(Tarjeta_Numero,1,12)),2)+SUBSTRING(Tarjeta_Numero,13,4))=t.tar_codigo 
	   and t.cli_id=cl.cli_id and m.Cuenta_Numero = c.cta_numero
order by 1;
go

--TABLA RETIRO
INSERT INTO TAO_PAY_PAL.Retiro
select Retiro_Codigo, Retiro_Fecha,Cuenta_Numero, Cheque_Numero, Banco_Cogido, Retiro_Importe, 0 from gd_esquema.Maestra
where Retiro_Codigo is not null and Retiro_Fecha is not null
order by 1;
go


-- -----------------------------------------------------
-- FUNCIONES
-- -----------------------------------------------------
create function TAO_PAY_PAL.func_EstadoTarjeta(@caracter char)
returns varchar(10)
as
begin
	declare @resultado varchar(10)
	if (@caracter = 'A') set @resultado='Activo'
	if (@caracter = 'I') set @resultado='Inactivo'
	
	return @resultado
end;
go
-----------------------------------------------------
create function TAO_PAY_PAL.func_CodigoBanco(@banco varchar(20))
returns numeric(10)
as
begin
	declare @idBanco numeric(10)
	select @idBanco = banco_codigo from TAO_PAY_PAL.Banco where banco_nombre=@banco
	return @idBanco
end;
go
-- -----------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS
-- -----------------------------------------------------

------------------------------------------------------------------------------
-- Transaccion
------------------------------------------------------------------------------
--Inserta en el historial los inhabilitados de cuenta por no pagar (cuando supera 5 transacciones)
create procedure TAO_PAY_PAL.sp_Registra_Cuenta_Inhabilitadas
@fechaTran datetime,
@cuenta numeric(18, 0)
as
begin
if((select cta_contadorTrans from Cuenta where cta_numero=@cuenta)>5)
	insert into TAO_PAY_PAL.HistorialInhabilitados(hi_cuenta, hi_fechaInhab) values (@cuenta, @fechaTran)
end;
go

-- Depositos
create proc TAO_PAY_PAL.sp_Depositos_Cuentas_Habilitadas
@id numeric(18),
@fecha datetime
as begin
	update TAO_PAY_PAL.Cuenta set cta_estado=2 where cta_fechaCierre<@fecha and cta_estado=1;
	select cta_numero Cuenta, cat_descripcion Categoria, pais_descripcion Pais, cta_saldo Saldo
	from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Pais, TAO_PAY_PAL.Categoria_Cuenta
	where @id=cta_cli_id and cta_categoria=cat_codigo and pais_codigo=cta_paisCodigo and cta_estado=1		  
end;
go
create proc TAO_PAY_PAL.sp_Depositos_Depositar
@id numeric(18), @cta numeric(18), @tar varchar(100), @emisor varchar(255), @monto decimal(10,2), @fecha datetime
as begin
	declare @tarjeta numeric(10) = (select tar_id from TAO_PAY_PAL.Tarjetas_Clientes, TAO_PAY_PAL.Emisor_Tarjeta 
									where @id=cli_id and emi_descripcion=@emisor and @tar=tar_codigo)
	insert into TAO_PAY_PAL.Deposito
		select MAX(dep_codigo)+1, @fecha, convert(numeric(10,2),@monto), @cta, @tarjeta, @id, null  
		from TAO_PAY_PAL.Deposito;
	update TAO_PAY_PAL.Cuenta set cta_saldo = cta_saldo + @monto where cta_numero=@cta;	 
end;
go
create proc TAO_PAY_PAL.sp_Depositos_Tarjetas_Activas
@id numeric(18),
@fecha datetime
as begin
	update TAO_PAY_PAL.Tarjetas_Clientes set tar_estado='I' where @fecha>tar_fechaVencimiento and tar_fechaDesvinculacion is not null;
	select tar_codigo Tarjeta, emi_descripcion Emisor
	from TAO_PAY_PAL.Tarjetas_Clientes, TAO_PAY_PAL.Emisor_Tarjeta
	where cli_id=@id and tar_emisor=emi_id
end;
go
---------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Login_ID
@username varchar(50),
@password varchar(255)
as begin 
	select usr_id id from TAO_PAY_PAL.Usuario where @username=usr_username and @password=usr_password
end;
go
---------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cuenta_ActualizarAlaFecha
@fecha datetime
as begin
	update TAO_PAY_PAL.Cuenta set cta_estado=2 where cta_fechaCierre<=@fecha
end;
go
---------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cuenta_Alta
@id numeric(18), @fecha datetime, @categoria varchar(50), 
@pais varchar(255), @moneda varchar(50), @suscrip numeric(3)
as 
begin
	declare @cat numeric(5) = (select cat_codigo from TAO_PAY_PAL.Categoria_Cuenta where @categoria=cat_descripcion);
	declare @paiscod numeric(10) = (select pais_codigo from TAO_PAY_PAL.Pais where pais_descripcion=@pais);
	declare @tiempo numeric(10) = (select cat_tiempoSuscripcion from TAO_PAY_PAL.Categoria_Cuenta where cat_descripcion=@categoria);
	declare @mon numeric(5) = (select tm_codigo from TAO_PAY_PAL.Tipo_Moneda where tm_descripcion=@moneda);
	declare @cuenta numeric(18) = (select MAX(cta_numero)+1 from TAO_PAY_PAL.Cuenta)	
	insert into TAO_PAY_PAL.Cuenta values (@cuenta, @id, @fecha, DATEADD(DAY, @tiempo*@suscrip, @fecha), @cat, @paiscod, @mon, 4, 0, 1);
	insert into TAO_PAY_PAL.Apertura_Cuentas values (@fecha,@cuenta, @cat, @suscrip, null);
end;
go
---------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cuenta_Edicion
@fecha datetime, @cuenta numeric(18), @categoria varchar(50), @suscrip numeric(3)
as
begin
	declare @oldcat numeric(5) = (select cta_categoria from TAO_PAY_PAL.Cuenta where @cuenta=cta_numero);
	declare @newcat numeric(5) = (select cat_codigo from TAO_PAY_PAL.Categoria_Cuenta where @categoria=cat_descripcion);
	declare @tiempo numeric(10) = (select cat_tiempoSuscripcion from TAO_PAY_PAL.Categoria_Cuenta where cat_descripcion=@categoria);
	
	if (exists(select 1 from TAO_PAY_PAL.Cuenta where @cuenta=cta_numero and cta_contadorTrans=5))
	begin
		update TAO_PAY_PAL.Cuenta set cta_contadorTrans=6,cta_estado=2 where @cuenta=cta_numero;
		exec TAO_PAY_PAL.sp_Registra_Cuenta_Inhabilitadas @fecha, @cuenta
		raiserror('Cliente con mas de 5 transacciones, cuenta inhabilitada',16,1);
	end
	else
	begin
		insert into TAO_PAY_PAL.Cambio_Categoria values (@fecha, @cuenta, @oldcat, @newcat, @suscrip, null);
		update TAO_PAY_PAL.Cuenta set cta_categoria=@newcat, cta_fechaCierre= DATEADD(DAY,@tiempo*@suscrip,@fecha), cta_contadorTrans=cta_contadorTrans+1
		where cta_numero=@cuenta;			
	end		
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cuenta_Baja
@cuenta numeric(18),
@fecha datetime
as begin
	if (exists(select 1 from TAO_PAY_PAL.Cuenta where cta_numero=@cuenta and cta_contadorTrans=0))
	begin
		update TAO_PAY_PAL.Cuenta set cta_estado=3 where cta_numero=@cuenta;
	end
	else
		raiserror('No puede dar de baja hasta que haya facturado todas sus transacciones',16,1);
end;
go
------------------------------------------------------------------------------------------------------
create PROCEDURE TAO_PAY_PAL.sp_Cuentas_Clientes_Filtro
@nombre		varchar(255),
@apellido	varchar(255),
@tipoDocDesc	varchar(250),
@nroDoc		varchar(20),
@mail		varchar(255)
as
begin
	declare @tipoDoc numeric(18)
	select @tipoDoc = td_codigo from TAO_PAY_PAL.Tipo_Documento
	where @tipoDocDesc = td_descripcion
	if (@nombre='') set @nombre= null;
	if (@apellido='') set @apellido=null;
	if (@mail='') set @mail=null;	
	if (@nroDoc ='') set @nroDoc=null;
	
	select cli_id as Id, cli_nombre+' '+cli_apellido as Apellido, td_descripcion+' '+CONVERT(varchar(20),cli_nroDoc) as Documento, cli_mail as Mail
	from TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Tipo_Documento
	where (@nombre is null or (cli_nombre like @nombre+'%')) and (@apellido is null or (cli_apellido like @apellido+'%')) and
	  ((cli_tipoDoc=@tipoDoc and @nroDoc is null) or (cli_tipoDoc=@tipoDoc and cli_nroDoc like @nroDoc+'%')) and
	  (@mail is null or (cli_mail like @mail+'%')) and td_codigo=cli_tipoDoc
end;
go
--------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cuenta_Busqueda_X_Filtro
@id varchar(18),
@nom varchar(255),
@ape varchar(255),
@categoria varchar(50),
@estado varchar(50)
as begin
	if (@id='') set @id=null;
	if (@nom='') set @nom=null;
	if (@ape='') set @ape=null;
	declare @state numeric(5)=(select estado_codigo from TAO_PAY_PAL.Estado_Cuenta where @estado=estado_descricion);
		
	select x.Cuenta Cuenta, x.id ID, x.nom+' '+x.ape Cliente,x.cate Categoria, x.pais Pais, x.estado Estado from
	(select cta_numero Cuenta, cta_cli_id id, cli_nombre nom, cli_apellido ape, pais_descripcion pais, estado_codigo estado, cat_descripcion cate
	from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Pais, TAO_PAY_PAL.Estado_Cuenta, TAO_PAY_PAL.Categoria_Cuenta
	where cta_estado=estado_codigo and cta_paisCodigo=pais_codigo and cta_categoria=cat_codigo and cta_cli_id=cli_id) x
	where x.estado=@state and x.cate=@categoria and (@id is null or x.id like @id+'%') and (@nom is null or x.nom like @nom+'%') and
		  (@ape is null or x.ape like @ape+'%')
end;
go
--------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Saldo_10Transferencias
@cuenta numeric(18)
as
begin
	select top 10 transf_codigo Codigo, transf_fechaHora Fecha, transf_origenCuenta Cuenta_Origen, transf_destinoCuenta Cuenta_Destino, transf_importe Importe 
	from TAO_PAY_PAL.Transferencia
	where transf_origenCuenta=@cuenta or transf_destinoCuenta=@cuenta
	order by 1 desc
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Saldo_5Depositos
@cuenta numeric(18)
as
begin
	select top 5 dep_codigo Codigo, dep_fecha Fecha, dep_importe Importe from TAO_PAY_PAL.Deposito
	where dep_numeroCuenta=@cuenta
	order by 1 desc
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Saldo_5Retiros
@cuenta numeric(18)
as
begin
	select top 5 ret_codigo Codigo, ret_fecha Fecha, ret_importe Importe from TAO_PAY_PAL.Retiro
	where ret_nroCuenta=@cuenta
	order by 1 desc
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Saldo_BuscarCuentasXFiltro
@id	varchar(18), @nom varchar(255), @ape varchar(255), @mail varchar(255), @tipoDoc varchar(50), @nroDoc varchar(18),
@nroCta varchar(18), @moneda varchar(50)
as
begin
	select t.cta Cuenta, t.nom+' '+t.ape Cliente, t.id ID_Cliente, t.cat_descripcion Categoria, t.pais Pais,t.moneda Moneda
	from 
		(select cli_id id, cli_nombre nom, cli_apellido ape, cli_mail mail, td_descripcion tipoDoc, cli_nroDoc nroDoc, cta_numero cta, tm_descripcion moneda, pais_descripcion pais, cat_descripcion
		from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Tipo_Moneda, TAO_PAY_PAL.Tipo_Documento, TAO_PAY_PAL.Categoria_Cuenta, TAO_PAY_PAL.Pais
		where cli_id=cta_cli_id and cli_tipoDoc=td_codigo and cta_tipoMoneda=tm_codigo and cli_paisCodigo=pais_codigo and cat_codigo=cta_categoria
		group by cli_id, cli_nombre, cli_apellido, cli_mail, td_descripcion, cli_nroDoc, cta_numero, tm_descripcion, pais_descripcion, cat_descripcion) t
	where (t.id like @id+'%' or @id is null) and (t.nom like @nom+'%' or @nom is null) and (t.ape like @ape+'%' or @ape is null)
		  and (t.mail like @mail+'%' or @mail is null) and (t.nroDoc like @nroDoc+'%' or @nroDoc is null) and
		  (t.cta like @nroCta+'%' or @nroCta is null) and t.moneda=@moneda and t.tipoDoc=@tipoDoc
	group by t.cta, t.nom, t.ape, t.id, t.cat_descripcion, t.pais, t.moneda
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Saldo_BuscarCuentasGlobales
as
begin
	select cta_numero Cuenta, cli_nombre+' '+cli_apellido Cliente, cli_id ID_Cliente, cat_descripcion Categoria, pais_descripcion Pais, tm_descripcion Moneda
	from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Tipo_Moneda, TAO_PAY_PAL.Tipo_Documento, TAO_PAY_PAL.Categoria_Cuenta, TAO_PAY_PAL.Pais
	where cli_id=cta_cli_id and cli_tipoDoc=td_codigo and cta_tipoMoneda=tm_codigo and cli_paisCodigo=pais_codigo and cat_codigo=cta_categoria
	group by cta_numero, cli_nombre, cli_apellido, cli_id, cat_descripcion, pais_descripcion, tm_descripcion
	
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Factura_Deudores_Globales
as
begin
	select ID,Nombre,Apellido,SUM(Debe) as Monto from (
	select cli_id as ID, cli_nombre as Nombre, cli_apellido as Apellido, SUM(convert(numeric(10,2),ROUND(t.transf_importe*cc.cat_costoTransferencia,2))) as Debe
	from TAO_PAY_PAL.Transferencia t, TAO_PAY_PAL.Cliente c, TAO_PAY_PAL.Categoria_Cuenta cc, TAO_PAY_PAL.Cuenta cu
	where t.transf_origenCuenta=cu.cta_numero and cu.cta_cli_id=c.cli_id and transf_nroFactura is null and cc.cat_codigo=t.transf_Categoria
		  and not exists(select 1 from TAO_PAY_PAL.Cuenta where cta_cli_id=c.cli_id and t.transf_destinoCuenta=cta_numero)
	group by c.cli_id,c.cli_nombre,c.cli_apellido
	union
	select cli_id as ID,cli_nombre as Nombre,cli_apellido as Apellido, SUM(cat.cat_costoApertura*cc.cc_cantSuscrip) as Debe
	from TAO_PAY_PAL.Cambio_Categoria cc, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Categoria_Cuenta cat, TAO_PAY_PAL.Cuenta cu
	where cc.cc_nroCuenta=cu.cta_numero and cu.cta_cli_id=cli_id and cc.cc_nroFactura is null and cat.cat_codigo=cc.cc_nuevaCategoria
	group by cli_id,cli_nombre,cli_apellido
	union		
	select cli_id as ID,cli_nombre as Nombre,cli_apellido as Apellido, SUM(cc.cat_costoApertura*ac.ape_cantSuscrip) as Debe
	from TAO_PAY_PAL.Apertura_Cuentas ac, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Categoria_Cuenta cc, TAO_PAY_PAL.Cuenta cu
	where ac.ape_nroCuenta=cu.cta_numero and cu.cta_cli_id=cli_id and ape_nroFactura is null and cc.cat_codigo=ac.ape_nroCategoria
	group by cli_id,cli_nombre,cli_apellido) t group by ID,Nombre,Apellido order by 1
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Factura_Deudores_X_Filtro
@nom	varchar(255),
@ape	varchar(255),
@mail	varchar(255),
@tipoDoc	varchar(50),
@nroDoc	numeric(18)
as
begin	
	declare @td numeric(18)
	select @td = td_codigo from TAO_PAY_PAL.Tipo_Documento
	where @tipoDoc = td_descripcion
	if (@nroDoc =0) set @nroDoc=null;
	
	select ID,Nombre,Apellido,SUM(Debe) as Monto from (
	select cli_id as ID, cli_nombre as Nombre, cli_apellido as Apellido, SUM(convert(numeric(10,2),ROUND(t.transf_importe*cc.cat_costoTransferencia,2))) as Debe
	from TAO_PAY_PAL.Transferencia t, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Categoria_Cuenta cc, TAO_PAY_PAL.Cuenta c
	where (@nom is null or (cli_nombre like @nom+'%')) and (@ape is null or (cli_apellido like @ape+'%')) and
		(@mail is null or (cli_mail like @mail+'%')) and (@nroDoc is null or (cli_tipoDoc =@td and cli_nroDoc like cast(@nroDoc as varchar(50))+'%')) and
		t.transf_origenCuenta=c.cta_numero and c.cta_cli_id=cli_id and transf_nroFactura is null and cc.cat_codigo=t.transf_Categoria
	group by cli_id,cli_nombre,cli_apellido
	union		
	select cli_id as ID,cli_nombre as Nombre,cli_apellido as Apellido, SUM(cat.cat_costoApertura*cc.cc_cantSuscrip) as Debe
	from TAO_PAY_PAL.Cambio_Categoria cc, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Categoria_Cuenta cat, TAO_PAY_PAL.Cuenta cu
	where (@nom is null or (cli_nombre like @nom+'%')) and (@ape is null or (cli_apellido like @ape+'%')) and
		(@mail is null or (cli_mail like @mail+'%')) and (@nroDoc is null or (cli_tipoDoc =@td and cli_nroDoc like cast(@nroDoc as varchar(50))+'%')) and
		cc.cc_nroCuenta=cu.cta_numero and cu.cta_cli_id=cli_id and cc_nroFactura is null and cat.cat_codigo=cc.cc_nuevaCategoria
	group by cli_id,cli_nombre,cli_apellido
	union	
	select cli_id as ID,cli_nombre as Nombre,cli_apellido as Apellido, SUM(cc.cat_costoApertura*ac.ape_cantSuscrip) as Debe
	from TAO_PAY_PAL.Apertura_Cuentas ac, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Categoria_Cuenta cc, TAO_PAY_PAL.Cuenta cu
	where (@nom is null or (cli_nombre like @nom+'%')) and (@ape is null or (cli_apellido like @ape+'%')) and
		(@mail is null or (cli_mail like @mail+'%')) and (@nroDoc is null or (cli_tipoDoc =@td and cli_nroDoc like cast(@nroDoc as varchar(50))+'%')) and
		ac.ape_nroCuenta=cu.cta_numero and cu.cta_cli_id=cli_id and ape_nroFactura is null and cc.cat_codigo=ac.ape_nroCategoria
	group by cli_id,cli_nombre,cli_apellido) t  group by ID,Nombre,Apellido order by 1
end;
go
-------------------------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Factura_Mostrar_Transacciones
@id	numeric(18)
as
begin
	select * from (
	select c.cta_fechaCreacion as Fecha, 'Apertura de Cuenta' as Descripcion, a.ape_nroCuenta as Cuenta, cc.cat_costoApertura*a.ape_cantSuscrip as Costo
	from TAO_PAY_PAL.Apertura_Cuentas a, TAO_PAY_PAL.Cuenta c, TAO_PAY_PAL.Categoria_Cuenta cc
	where @id=c.cta_cli_id and a.ape_nroCuenta=c.cta_numero and a.ape_nroCategoria=cc.cat_codigo and a.ape_nroFactura is null
	union all
	select cc.cc_fecha as Fecha, 'Cambio de Categoria' as Descripcion, cc.cc_nroCuenta as Cuenta, cat.cat_costoApertura*cc.cc_cantSuscrip as Costo 
	from TAO_PAY_PAL.Cambio_Categoria cc, TAO_PAY_PAL.Categoria_Cuenta cat, TAO_PAY_PAL.Cuenta c
	where cc.cc_nuevaCategoria=cat.cat_codigo and cc.cc_nroFactura is null and @id=c.cta_cli_id and c.cta_numero=cc.cc_nroCuenta
	union all
	select t.transf_fechaHora as Fecha, 'Transferencia' as Descripcion, t.transf_origenCuenta as Cuenta, convert(numeric(10,2), cc.cat_costoTransferencia*t.transf_importe) as Costo
	from TAO_PAY_PAL.Transferencia t, TAO_PAY_PAL.Categoria_Cuenta cc
	where t.transf_nroFactura is null and t.transf_Categoria=cc.cat_codigo
		  and exists(select 1 from TAO_PAY_PAL.Cuenta where @id=cta_cli_id and cta_numero=t.transf_origenCuenta)) x order by 1
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Factura_Confirmar_OK
@id numeric(18),
@factura numeric(18),
@monto numeric(10,2),
@fecha datetime
as
begin
	insert into TAO_PAY_PAL.Factura values (@factura,@fecha,@id,@monto)
	update TAO_PAY_PAL.Cuenta set cta_contadorTrans=0, cta_estado=1 where cta_cli_id=@id and cta_estado<>3;
	update TAO_PAY_PAL.Cuenta set cta_contadorTrans=0, cta_estado=3 where cta_cli_id=@id and cta_estado=4 and cta_fechaCierre<@fecha; 
	update TAO_PAY_PAL.Cuenta set cta_estado=4 where cta_cli_id=@id and @fecha>cta_fechaCierre and cta_estado=2;
	update TAO_PAY_PAL.Deposito set nroFactura = @factura where nroFactura is null and dep_cli_id=@id;
	update TAO_PAY_PAL.Retiro set nroFactura = @factura 
		where nroFactura is null and exists(select 1 from TAO_PAY_PAL.Cuenta where cta_numero=ret_nroCuenta and cta_cli_id=@id);
	update TAO_PAY_PAL.Transferencia set transf_nroFactura=@factura 
		where transf_nroFactura is null and exists(select 1 from TAO_PAY_PAL.Cuenta where cta_numero=transf_origenCuenta and @id=cta_cli_id)
	update TAO_PAY_PAL.Cambio_Categoria set cc_nroFactura=@factura
		where exists(select 1 from TAO_PAY_PAL.Cuenta where cc_nroCuenta=cta_numero and cta_cli_id=@id) and cc_nroFactura is null
	update TAO_PAY_PAL.Apertura_Cuentas set ape_nroFactura=@factura
		where ape_nroFactura is null and exists(select 1 from TAO_PAY_PAL.Cuenta where cta_numero=ape_nroCuenta and cta_cli_id=@id)
end;
go
--------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Factura_Datos_Cliente
@id	numeric(18)
as
begin
	declare @nrofact numeric(18)
	select top 1 @nrofact =fact_numero from TAO_PAY_PAL.Factura order by fact_numero desc;
	
	select @nrofact+1,cli_nombre+' '+cli_apellido, cli_mail
	from TAO_PAY_PAL.Cliente
	where @id = cli_id
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Usuario_Verificar_Username
@username varchar(50)
as
begin
	if (exists(select * from TAO_PAY_PAL.Usuario where @username=usr_username))
	begin
		raiserror('Username usado por otro usuario',16,1)
	end 
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cliente_Alta
@username	varchar(50), @password varchar(100), @pre varchar(255), @res varchar(255),@creacion datetime,
@nom varchar(255), @ape varchar(255), @tipoDocDesc varchar(50), @nroDoc numeric(20),
@paisDesc varchar(100), @domCalle varchar(255), @nroCalle numeric(18), @piso numeric(18),
@depto varchar(10), @nacimiento datetime, @mail varchar(255)
as
begin try
	begin transaction	
		insert into TAO_PAY_PAL.Usuario values(@username,@password,@creacion,null,@pre,@res,'A'); --CAMBIOOOO!!!
		if (@piso = -1) begin set @piso = null end
		if (@depto = '') begin set @depto = null end
		insert into TAO_PAY_PAL.Usuario_x_Rol
			select MAX(usr_id),2  from TAO_PAY_PAL.Usuario;		
		insert into TAO_PAY_PAL.Cliente
			select MAX(usr_id) ,@nom, @ape, td_codigo, @nroDoc, pais_codigo,
				   @domCalle, @nroCalle, @piso, @depto, @nacimiento, @mail, 'A'  --CAMBIOOOO!!!
			from TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Usuario, TAO_PAY_PAL.Tipo_Documento,TAO_PAY_PAL.Pais
			where @tipoDocDesc=td_descripcion and @paisDesc=pais_descripcion 
			group by td_codigo, pais_codigo
	commit	
end try
begin catch
		raiserror('Existe un cliente con ese numero y tipo de documento o mail',16,1)
		rollback
end catch
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cliente_Editar
@id numeric(18), @nom varchar(255), @ape varchar(255), @tipoDocDesc varchar(100), @nroDoc numeric(18),
@paisDesc varchar(100), @calle varchar(255), @nroCalle numeric(10), @piso numeric(10), @depto varchar(5),
@nacimiento datetime, @mail varchar(255)
as
begin try
	begin transaction
		declare @tdoc numeric(10)
		declare @tpais numeric (10)
		select @tdoc=td_codigo from TAO_PAY_PAL.Tipo_Documento where @tipoDocDesc=td_descripcion;
		select @tpais=pais_codigo from TAO_PAY_PAL.Pais where @paisDesc=pais_descripcion;
		update TAO_PAY_PAL.Cliente
		set cli_nombre = @nom, cli_apellido=@ape, cli_tipoDoc=@tdoc, cli_nroDoc=@nroDoc, cli_paisCodigo=@tpais, cli_domCalle=@calle,
			cli_nroCalle=@nroCalle, cli_domPiso=@piso, cli_domDepto=@depto, cli_fechaNacimiento=@nacimiento, cli_mail=@mail
		where @id=cli_id;
		commit	
end try
begin catch
		raiserror('El mismo tipo y numero de documento o mail, estan siendo usados por otro cliente',16,1)
		rollback	
end catch;
go
--------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cliente_Informacion
@id numeric(18)
as
begin 
	select cli_nombre,cli_apellido,td_descripcion,cli_nroDoc,cli_mail,cli_fechaNacimiento,
		   pais_descripcion,cli_domCalle,cli_nroCalle,cli_domPiso,cli_domDepto
	from TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Tipo_Documento, TAO_PAY_PAL.Pais
	where cli_paisCodigo=pais_codigo and td_codigo=cli_tipoDoc and cli_id=@id
end;
go
----------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Cliente_Habilitar_Inhabilitar
@id numeric (18),
@accion varchar(20)
as
begin 
	if (@accion='Habilitar')
	begin
		update TAO_PAY_PAL.Cliente
		set cli_estado='A'
		where @id=cli_id;
	end
	else
		update TAO_PAY_PAL.Cliente
		set cli_estado='I'
		where @id=cli_id;
end;
go
----------------------------------------------------------------------------------------------------------
create PROCEDURE TAO_PAY_PAL.sp_Clientes_Listado
@nombre		varchar(255),
@apellido	varchar(255),
@tipoDocDesc	varchar(250),
@nroDoc		numeric(18),
@mail		varchar(255)
--@accion		varchar(20)
as
begin
	declare @tipoDoc numeric(18)
	select @tipoDoc = td_codigo from TAO_PAY_PAL.Tipo_Documento
	where @tipoDocDesc = td_descripcion
	if (@nombre='') set @nombre= null;
	if (@apellido='') set @apellido=null;
	if (@mail='') set @mail=null;	
	if (@nroDoc =0) set @nroDoc=null;
	
	select cli_id as Id, cli_nombre as Nombre, cli_apellido as Apellido, t.td_descripcion as Documento, cli_nroDoc as Numero,
		 p.pais_descripcion as Pais, cli_domCalle+' - '+CONVERT(varchar(10),cli_nroCalle) as Domicilio,
		 cli_domPiso as Piso, cli_domDepto as Dpto, cli_fechaNacimiento as Nacimiento, cli_mail as Mail, cli_estado
	from TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Pais p, TAO_PAY_PAL.Tipo_Documento t, TAO_PAY_PAL.Usuario_x_Rol r
	where (@nombre is null or (cli_nombre like @nombre+'%')) and
	  (@apellido is null or (cli_apellido like @apellido+'%')) and
	  (@tipoDoc is null or (cli_tipoDoc=@tipoDoc and @nroDoc is null) or (cli_tipoDoc=@tipoDoc and cli_nroDoc like cast(@nroDoc as varchar(50))+'%')) and
	  (@mail is null or (cli_mail like @mail+'%')) and
	  p.pais_codigo=cli_paisCodigo and td_codigo=cli_tipoDoc and cli_id = r.usr_id and r.rol_codigo = 2
end;
go
------------------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_Tarjeta_Actualizar_Estados_Por_Fecha
@fechaSistema datetime
as
begin
	update TAO_PAY_PAL.Tarjetas_Clientes set tar_estado='I' where tar_fechaVencimiento<@fechaSistema;
end;
go
------------------------------------------------------------------------------
-- Muestra las tarjetas que no fueron desasociadas
create procedure TAO_PAY_PAL.sp_Tarjeta_Listado
@id numeric(18)
as 
begin
	select SUBSTRING(tar_codigo,1,30)+'-'+SUBSTRING(tar_codigo,31,4)+' - '+ emi_descripcion as tarjetas
	from TAO_PAY_PAL.Tarjetas_Clientes, TAO_PAY_PAL.Emisor_Tarjeta
	where @id = cli_id and tar_emisor=emi_id and tar_fechaDesvinculacion is null
end;
go
------------------------------------------------------------------------------
-- Muestra la fecha de vencimiento y el estado de la tarjeta ingresada
create proc TAO_PAY_PAL.sp_Tarjeta_Informacion
@id int,
@tar varchar(100)
as
begin 
	select tar_fechaVencimiento as fechaVen, TAO_PAY_PAL.func_EstadoTarjeta(tar_estado) as estado
	from TAO_PAY_PAL.Tarjetas_Clientes, TAO_PAY_PAL.Emisor_Tarjeta
	where emi_id=tar_emisor and @id=cli_id and (SUBSTRING(@tar,1,30)+SUBSTRING(@tar,32,4)) = tar_codigo
	 and SUBSTRING(@tar,39,20)=emi_descripcion
end;
go
------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Tarjeta_Insertar
@id		numeric(18),
@tar	varchar(16),
@emisor	varchar(30),
@fechaEmision	datetime,
@fechaVencimiento datetime,
@codSeguridad char(3)
as
begin
	if not exists(select * from TAO_PAY_PAL.Tarjetas_Clientes, TAO_PAY_PAL.Emisor_Tarjeta 
				  where cli_id=@id and tar_codigo=CONVERT(char,HASHBYTES('SHA1',SUBSTRING(@tar,1,12)),2)+SUBSTRING(@tar,13,4)
				  and @emisor = emi_descripcion)
	begin
		declare @emi numeric(10)
		select @emi=emi_id from TAO_PAY_PAL.Emisor_Tarjeta where @emisor=emi_descripcion		
		insert into TAO_PAY_PAL.Tarjetas_Clientes 
		(tar_codigo,cli_id,tar_fechaEmision,tar_fechaVencimiento,tar_emisor,tar_codigoSeguridad,tar_estado)
		values
		(CONVERT(char,HASHBYTES('SHA1',SUBSTRING(@tar,1,12)),2)+SUBSTRING(@tar,13,4),@id,@fechaEmision,@fechaVencimiento,
		@emi, CONVERT(char,HASHBYTES('SHA1',@codSeguridad),2),'A')
	end
	else
		raiserror('codigo de tarjeta de la emision existente',16,1)
end;
go
------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Tarjeta_Editar
@id	numeric(18),
@tar varchar(100),
@fechaVencimiento	datetime,
@codSeguridad	char(3),
@codSeguridadNueva	char(3)
as
begin
	if (@codSeguridad =0)
	begin
		update TAO_PAY_PAL.Tarjetas_Clientes
		set tar_fechaVencimiento=@fechaVencimiento, tar_estado = 'A'	
		where cli_id=@id and tar_codigo=SUBSTRING(@tar,1,30)+SUBSTRING(@tar,32,4)
	end
	else if exists (select * from TAO_PAY_PAL.Tarjetas_Clientes 
					where CONVERT(char,HASHBYTES('SHA1',@codSeguridad),2)= tar_codigoSeguridad 
						  and @id=cli_id and SUBSTRING(@tar,1,30)+SUBSTRING(@tar,32,4)=tar_codigo)
	begin
		update TAO_PAY_PAL.Tarjetas_Clientes
		set tar_codigoSeguridad=CONVERT(char,HASHBYTES('SHA1',@codSeguridadNueva),2)
		where cli_id=@id and tar_codigo=SUBSTRING(@tar,1,30)+SUBSTRING(@tar,32,4)
	end
	else 
		raiserror('Incorrecto codigo de seguridad',16,1)
end;
go
-----------------------------------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Tarjeta_Desasociar
@id	numeric(18),
@tar varchar(100),
@codSeg char(3),
@fechaDesasociacion datetime
as
begin
	set @tar = SUBSTRING(@tar,1,30)+SUBSTRING(@tar,32,4)
	if exists(select * from TAO_PAY_PAL.Tarjetas_Clientes where tar_codigoSeguridad=CONVERT(char,HASHBYTES('SHA1',@codSeg),2)
				and @id = cli_id and tar_codigo=@tar)
	begin
		update TAO_PAY_PAL.Tarjetas_Clientes
		set tar_estado='I', tar_fechaDesvinculacion=@fechaDesasociacion
		where tar_codigo=@tar and @id=cli_id
	end
	else
		raiserror('codigo de seguridad incorrecto',16,1)
end;
go
-----------------------------------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Retiro_Registrar
@id	numeric(18),
@cta numeric(18),
@fecha datetime,
@monto decimal,
@banco	varchar(20),
@dni numeric(18)
as
begin
	declare @nroRetiro numeric(18) = (select max(ret_codigo)+1 from TAO_PAY_PAL.Retiro)
	declare @nroCheque numeric(18) = (select max(ret_nroCheque)+1 from TAO_PAY_PAL.Retiro)
	
	if (exists (select 1 from TAO_PAY_PAL.Cliente where cli_id=@id and cli_nroDoc=@dni))
	begin
		insert into TAO_PAY_PAL.Retiro (ret_codigo,ret_fecha,ret_nroCuenta,ret_nroCheque,ret_banco_id,ret_importe) values 
				(@nroRetiro,@fecha,@cta,@nroCheque,TAO_PAY_PAL.func_CodigoBanco (@banco),@monto)
	end
	else
		raiserror('numero de Documento incorrecto!!!',16,1)
end;
go
-----------------------------------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Retiro_Actualizar_y_Buscar_Cuentas_Por_UserID
@id	numeric(18),
@fecha	datetime
as
begin
	update TAO_PAY_PAL.Cuenta set cta_estado=2 where cta_fechaCierre<@fecha;	
	select cta_numero as Cuenta,p.pais_descripcion as Pais,t.tm_descripcion as Moneda,cta_saldo as Saldo
	from TAO_PAY_PAL.Cuenta c, TAO_PAY_PAL.Tipo_Moneda t, TAO_PAY_PAL.Pais p
	where cta_cli_id=@id and t.tm_codigo=c.cta_tipoMoneda and p.pais_codigo=c.cta_paisCodigo and cta_estado=1
end;
go
-----------------------------------------------------------------------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Retiro_Generar_Cheque
as
begin
	select t.ret_fecha,cli_nombre+' '+cli_apellido,banco_nombre,t.ret_nroCheque,t.ret_importe
	from (select top 1 * from TAO_PAY_PAL.Retiro order by 1 desc) t, TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Banco,TAO_PAY_PAL.Cuenta
	where t.ret_nroCuenta=cta_numero and cli_id=cta_cli_id and t.ret_banco_id=banco_codigo
end;
go
------------------------------------------------------------------------------
--ROL
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_AltaRol
@nombreRol varchar(50),
@estado char
AS
begin
	IF NOT EXISTS (SELECT * FROM TAO_PAY_PAL.ROL WHERE rol_descripcion=@nombreRol)
		INSERT INTO TAO_PAY_PAL.ROL (rol_descripcion, rol_estado) VALUES(@nombreRol, @estado)
select @@IDENTITY
end;
GO
-----------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_AgregarFuncionalidadRol
@rolId numeric(18,0),
@funcId numeric(18)
AS
BEGIN
	INSERT INTO TAO_PAY_PAL.Funcionalidad_x_Rol(rol_codigo, fun_id) VALUES(@rolId, @funcId)
END;
GO
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_QuitarFuncionalidadRol
@rolId numeric(18,0),
@funcId numeric(18)
AS
BEGIN
	DELETE FROM TAO_PAY_PAL.Funcionalidad_x_Rol WHERE @rolId=rol_codigo and @funcId=fun_id
END;
GO
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_BajaRol
@rolId numeric(18,0)
AS
BEGIN
	IF EXISTS (SELECT * FROM TAO_PAY_PAL.[ROL] WHERE rol_codigo=@rolId)
		UPDATE TAO_PAY_PAL.ROL SET rol_estado='N' WHERE rol_codigo=@rolId
END;
GO
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_ModificarRol
@rolId numeric(18,0),
@nombre varchar(50),
@estado char
AS
BEGIN
	IF EXISTS (SELECT * FROM TAO_PAY_PAL.[ROL] WHERE rol_codigo=@rolId)
		UPDATE TAO_PAY_PAL.ROL SET rol_descripcion=@nombre, rol_estado=@estado  
		WHERE rol_codigo=@rolId
END;
GO
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_GetRoles
as
begin
select rol_codigo as ID, rol_descripcion as Descripcion, rol_estado as Estado from TAO_PAY_PAL.Rol
end;
go
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_GetFuncionalidades
as
begin
select fun_id as ID, fun_descripcion as Descripcion from TAO_PAY_PAL.Funcionalidad
end;
go
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_BuscarRoles
@nombre varchar(50),
@estado char,
@codFunc numeric(18,0)
as
begin

(select rol_codigo as ID, rol_descripcion as Descripcion, rol_estado as Estado 
from TAO_PAY_PAL.Rol
where rol_estado = case when @estado=' ' then rol_estado else @estado end)

intersect

(select rol_codigo as ID, rol_descripcion as Descripcion, rol_estado as Estado 
from TAO_PAY_PAL.Rol
where rol_descripcion like @nombre+'%')

intersect

(select R.rol_codigo as ID, R.rol_descripcion as Descripcion, R.rol_estado as Estado 
from TAO_PAY_PAL.Rol R join TAO_PAY_PAL.Funcionalidad_x_Rol F on (R.rol_codigo=F.rol_codigo)
where F.fun_id = case when @codFunc=0 then F.fun_id else @codFunc end)

end;
go
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_BuscarFuncionalidadesRol
@id int
as
begin
select distinct f.fun_id as ID, fun_descripcion as Descripcion 
from TAO_PAY_PAL.Funcionalidad f, TAO_PAY_PAL.Funcionalidad_x_Rol fr
where fr.rol_codigo=@id and f.fun_id=fr.fun_id
end;
go
------------------------------------------------------------------------------
CREATE PROCEDURE TAO_PAY_PAL.sp_GetEstadoRol
@id int
as
begin
select rol_estado
from TAO_PAY_PAL.Rol
where rol_codigo=@id 
end;
go

------------------------------------------------------------------------------
-- TRANSFERENCIA
------------------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_BuscarCtaTransf
@numCta numeric(18,0)
as

begin
	if (not exists(select cta.cta_numero		   
	from TAO_PAY_PAL.Cuenta cta 
	where cta.cta_numero = @numCta))
	raiserror('Cuenta no encontrada',16,1)
	
	select cta.cta_numero, cli.cli_nombre +' '+ cli.cli_apellido, 
		   cat.cat_descripcion, ps.pais_descripcion, est.estado_descricion,
		   cta.cta_cli_id,cta.cta_contadorTrans,cta.cta_saldo		   
	from TAO_PAY_PAL.Cuenta cta inner join TAO_PAY_PAL.Categoria_Cuenta cat on cta.cta_categoria = cat.cat_codigo
	inner join TAO_PAY_PAL.Cliente cli on cli.cli_id = cta.cta_cli_id 
	inner join TAO_PAY_PAL.Tipo_Moneda mon on mon.tm_codigo = cta.cta_tipoMoneda
	inner join TAO_PAY_PAL.Pais ps on ps.pais_codigo = cta.cta_paisCodigo
	inner join TAO_PAY_PAL.Estado_Cuenta est on est.estado_codigo = cta.cta_estado
	where cta.cta_numero = @numCta
	
end;
go

create procedure TAO_PAY_PAL.sp_ListarCuentas
@cliente numeric(18,0)
as
begin
	select cta.cta_numero, cli.cli_nombre +' '+ cli.cli_apellido,
		   cat.cat_descripcion, mon.tm_descripcion,
		   ps.pais_descripcion, est.estado_descricion,
		   cta.cta_fechaCierre, cta.cta_contadorTrans, cta.cta_saldo
	from TAO_PAY_PAL.Cuenta cta inner join TAO_PAY_PAL.Categoria_Cuenta cat on cta.cta_categoria = cat.cat_codigo
	inner join TAO_PAY_PAL.Cliente cli on cli.cli_id = cta.cta_cli_id 
	inner join TAO_PAY_PAL.Tipo_Moneda mon on mon.tm_codigo = cta.cta_tipoMoneda
	inner join TAO_PAY_PAL.Pais ps on ps.pais_codigo = cta.cta_paisCodigo
	inner join TAO_PAY_PAL.Estado_Cuenta est on est.estado_codigo = cta.cta_estado
	where cta.cta_cli_id = @cliente
end
go

create procedure TAO_PAY_PAL.sp_ActulizarCamposTransferencia
@numCtaOrigen numeric(18,0), 
@numCtaDestino numeric(18,0),
@importe numeric(18,2),
@contador int,
@fecha datetime
as
begin

		if ((select cta.cta_contadorTrans from TAO_PAY_PAL.Cuenta cta where cta.cta_numero = @numCtaOrigen) >= 5 and @contador = 1)
		begin
			-- Inhabilitamos al Cliente Origen por superar las 5 transferencias
			update TAO_PAY_PAL.Cuenta set cta_estado = 2
			where cta_numero = @numCtaOrigen
			set @contador = 0
			 
			exec TAO_PAY_PAL.sp_Registra_Cuenta_Inhabilitadas @fecha, @numCtaOrigen
		end 
		update TAO_PAY_PAL.Cuenta set cta_contadorTrans = cta_contadorTrans+@contador
		where cta_numero = @numCtaOrigen
		update TAO_PAY_PAL.Cuenta set cta_saldo = cta_saldo - @importe
		where cta_numero = @numCtaOrigen		
		
		update TAO_PAY_PAL.Cuenta set cta_saldo = cta_saldo + @importe
		where cta_numero = @numCtaDestino
end
go

create procedure TAO_PAY_PAL.sp_Transferencia

@numCtaOrigen numeric(18,0), 
@numCtaDestino numeric(18,0),
@importe numeric(18,2),
@fecha datetime

AS
begin try
begin transaction
		
		declare @numCliOrigen numeric(18,0)
		
		set  @numCliOrigen = (select cta.cta_cli_id
		from  TAO_PAY_PAL.Cuenta cta inner join TAO_PAY_PAL.Cliente cli on cli.cli_id = cta.cta_cli_id
		where cta.cta_numero = @numCtaOrigen);

		declare @idCategoria numeric(5,0)
		
		set  @idCategoria = (select cta.cta_categoria
		from  TAO_PAY_PAL.Cuenta cta inner join TAO_PAY_PAL.Cliente cli on cli.cli_id = cta.cta_cli_id
		where cta.cta_numero = @numCtaOrigen);
		
		declare @numCliDestino numeric(18,0)
		
		set @numCliDestino = (select cta.cta_cli_id
		from TAO_PAY_PAL.Cuenta cta inner join TAO_PAY_PAL.Cliente cli on cli.cli_id = cta.cta_cli_id
		where cta.cta_numero = @numCtaDestino);

		if (@numCliOrigen != @numCliDestino)
		begin
			execute TAO_PAY_PAL.sp_ActulizarCamposTransferencia @numCtaOrigen, @numCtaDestino, @importe, 1, @fecha
		end
		else
		begin
			execute TAO_PAY_PAL.sp_ActulizarCamposTransferencia @numCtaOrigen, @numCtaDestino, @importe, 0, @fecha
		end
		
		insert into TAO_PAY_PAL.Transferencia(transf_fechaHora,transf_origenCuenta,transf_destinoCuenta,transf_importe,transf_Categoria)
								values(@fecha,@numCtaOrigen,@numCtaDestino,@importe,@idCategoria);
								
		commit transaction
	
end try
begin catch
		rollback transaction
		raiserror('Transferencia no realizada',16,1)
end catch

go
------------------------------------------------------------------------------
-- USUARIO
------------------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_ValidarUsuario
  @username varchar(100)=null,
  @password varchar(100)=null
as
begin
	if (not exists(select 1 from TAO_PAY_PAL.Usuario where usr_username=@username and usr_password=@password and usr_estado='A'))
	raiserror('Usuario y/o contraseña incorrecto/s',16,1)
 /*if((select COUNT(*) from TAO_PAY_PAL.Usuario
 where usr_username=@username and usr_password=@password and usr_estado='A')=0)
 raiserror('Usuario y/o contraseña incorrecto/s',16,1)*/
end;
go

create procedure TAO_PAY_PAL.sp_TieneMasDeUnRol
  @username varchar(50)=null
as
begin
 if((select COUNT(*) from TAO_PAY_PAL.Usuario u join TAO_PAY_PAL.Usuario_x_Rol ur on(u.usr_id=ur.usr_id)
  where usr_username=@username)>1)
  raiserror('Tiene mas de un Rol',16,1)
end;
go

create procedure TAO_PAY_PAL.sp_Log_Acceso
 @acceso varchar(10)=null,
 @username varchar(50)=null
as
begin
if((select u.usr_estado from TAO_PAY_PAL.Usuario u where @username=usr_username)<>'N')
begin
	if (exists(select 1 from TAO_PAY_PAL.Usuario where @username=usr_username))
	begin
		declare @id numeric(18,0) = (select usr_id from TAO_PAY_PAL.Usuario where @username=usr_username)
		if(@acceso='OK')
			begin
			insert into TAO_PAY_PAL.Historial_Auditoria values (GETDATE(),@id,'Acceso OK',0);
			update TAO_PAY_PAL.Historial_Auditoria set audi_bandera=1 where audi_concepto='Intento Fallido' and audi_usuario=@id and audi_bandera=0
			end
		if(@acceso='NO')
		begin
			if(2=(select count(audi_concepto) from TAO_PAY_PAL.Historial_Auditoria
				where audi_usuario=@id
				and audi_bandera=0
				and audi_concepto='Intento Fallido'))
			begin
				update TAO_PAY_PAL.Usuario set usr_estado='N' where usr_username=@username
				update TAO_PAY_PAL.Historial_Auditoria set audi_bandera=1 where audi_usuario=@id
				insert into TAO_PAY_PAL.Historial_Auditoria values (GETDATE(),@id,'Intento fallido',1)
			end
		else
			begin
				insert into TAO_PAY_PAL.Historial_Auditoria values (GETDATE(),@id,'Intento fallido',0)
			end
		end
	end	
end
else
raiserror('El usuario no esta habilitado',16,1)
end;
go

create proc TAO_PAY_PAL.sp_Rol_habilitado
 @username varchar(50)=null
as
begin
 if((select r.rol_estado from TAO_PAY_PAL.Usuario u join TAO_PAY_PAL.Usuario_x_Rol ur on(u.usr_id=ur.usr_id) --SALCHI
												join TAO_PAY_PAL.Rol r on(ur.rol_codigo=r.rol_codigo)
  where usr_username=@username)='H')
  raiserror('Su unico rol esta habilitado',16,1)
end;
go



------------------------------------------------------------------------------
-- TRIGGERS
------------------------------------------------------------------------------
--Actualiza el saldo cuando se realiza un retiro
create trigger TAO_PAY_PAL.tr_Retiro_Actualizar_Saldo on TAO_PAY_PAL.Retiro
after insert 
as
begin
	declare @monto numeric(10,2)
	declare @cta numeric(18)
	
	select @monto=ret_importe,@cta=ret_nroCuenta from inserted	
	update TAO_PAY_PAL.Cuenta set cta_saldo = cta_saldo - @monto where cta_numero=@cta	
end;
go

------------------------------------------------------------------------------
-- LISTADOS : 
------------------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_Listado1
  @trim int,
  @anio int
as
begin
select top 5 cli_id as ID, cli_nombre as Nombre, cli_apellido as Apellido, COUNT(cli_id) as CantInhabilitado
from TAO_PAY_PAL.HistorialInhabilitados
join TAO_PAY_PAL.Cuenta on (hi_cuenta=cta_numero)
join TAO_PAY_PAL.Cliente on (cta_cli_id=cli_id)
where YEAR(hi_fechaInhab)=@anio 
and DATEPART(QUARTER, hi_fechaInhab)=@trim
group by cli_id, cli_nombre, cli_apellido
order by COUNT(cli_id) desc
end;
go
----------------------------------------------------------------------
create proc TAO_PAY_PAL.sp_Listado2
  @trim int,
  @anio int -- 1,2,3,4
as begin
select top 5 cli_id ID, cli_nombre+' '+cli_apellido Cliente, SUM(t.comisiones) ComisionFacturada from
	(select ape_nroCuenta cuenta, COUNT(*) comisiones from TAO_PAY_PAL.Apertura_Cuentas, TAO_PAY_PAL.Factura
	where fact_numero=ape_nroFactura and YEAR(fact_fecha)=@anio and DATEPART(QUARTER, fact_fecha)=@trim 
	group by ape_nroCuenta
	union all
	select cc_nroCuenta cuenta,COUNT(*) comisiones from TAO_PAY_PAL.Cambio_Categoria, TAO_PAY_PAL.Factura
	where cc_nroFactura=fact_numero and YEAR(fact_fecha)=@anio and DATEPART(QUARTER, fact_fecha)=@trim
	group by cc_nroCuenta
	union all
	select transf_origenCuenta cuenta, COUNT(transf_origenCuenta) comisiones from TAO_PAY_PAL.Transferencia, TAO_PAY_PAL.Factura
	where transf_nroFactura=fact_numero and YEAR(fact_fecha)=@anio and DATEPART(QUARTER, fact_fecha)=@trim
	group by transf_origenCuenta) t, TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Cliente
where t.cuenta=cta_numero and cta_cli_id=cli_id
group by cli_id, cli_nombre, cli_apellido
order by 3 desc
end;
go
----------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_Listado3
  @trim int,
  @anio int
as
begin
select top 5 fact_cli_id as ID, cli_nombre as Nombre, cli_apellido as Apellido,COUNT(fact_cli_id) as CantTransacciones
from TAO_PAY_PAL.Transferencia 
join TAO_PAY_PAL.Factura on (transf_nroFactura=fact_numero),
Cliente
where transf_origenCuenta=transf_destinoCuenta 
and YEAR(transf_fechaHora)=@anio 
and DATEPART(QUARTER, transf_fechaHora)=@trim 
and fact_cli_id=cli_id
group by fact_cli_id, cli_nombre, cli_apellido
order by COUNT(fact_cli_id) desc
end;
go
----------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_Listado4
  @trim int,
  @anio int
as
begin

if OBJECT_ID('tempdb..#TransInterPaises') is not null 
DROP TABLE #TransInterPaises;

select * into #TransInterPaises
from 
(select C.cta_paisCodigo as PaisOrigen, T.transf_codigo as CodTrans1, T.transf_fechaHora as Fecha1
from TAO_PAY_PAL.Transferencia T
join TAO_PAY_PAL.Cuenta C on(T.transf_origenCuenta=C.cta_numero)) O
join
(select C2.cta_paisCodigo as PaisDestino, T2.transf_codigo as CodTrans2
from TAO_PAY_PAL.Transferencia T2
join TAO_PAY_PAL.Cuenta C2 on(T2.transf_destinoCuenta=C2.cta_numero)) D
on(O.CodTrans1 = D.CodTrans2)
where O.PaisOrigen != D.PaisDestino  
and YEAR(O.Fecha1)=@anio
and DATEPART(QUARTER, O.Fecha1)=@trim

select  top 5 CodPais, pais_descripcion as Pais, SUM(Mov) as CantMovimientos
from 
(select PaisOrigen as CodPais, COUNT(*) as Mov
from #TransInterPaises 
group by PaisOrigen
union all
select PaisDestino as CodPais, COUNT(*) as Mov
from #TransInterPaises
group by PaisDestino) t
join TAO_PAY_PAL.Pais on (CodPais=pais_codigo)
group by CodPais, pais_descripcion
order by SUM(Mov) desc

end;
go
----------------------------------------------------------------------
create procedure TAO_PAY_PAL.sp_Listado5
  @trim int,
  @anio int
as
begin
select top 5 Categoria,SUM(Costo) Total_Facturado
from
(select cc.cat_descripcion Categoria, cc.cat_costoApertura*a.ape_cantSuscrip as Costo
from TAO_PAY_PAL.Apertura_Cuentas a join TAO_PAY_PAL.Categoria_Cuenta cc on(a.ape_nroCategoria=cc.cat_codigo)
									join TAO_PAY_PAL.Factura f on(a.ape_nroFactura=f.fact_numero)
where YEAR(f.fact_fecha)=@anio
and DATEPART(QUARTER, f.fact_fecha)=@trim

union all
select cat.cat_descripcion Categoria, cat.cat_costoApertura*cc.cc_cantSuscrip as Costo 
from TAO_PAY_PAL.Cambio_Categoria cc join TAO_PAY_PAL.Categoria_Cuenta cat on (cc.cc_nuevaCategoria=cat.cat_codigo)
									join TAO_PAY_PAL.Factura f on(cc.cc_nroFactura=f.fact_numero)
where YEAR(f.fact_fecha)=@anio
and DATEPART(QUARTER, f.fact_fecha)=@trim
union all
select cc.cat_descripcion Categoria, cc.cat_costoTransferencia*t.transf_importe as Costo
from TAO_PAY_PAL.Transferencia t join TAO_PAY_PAL.Categoria_Cuenta cc on(t.transf_Categoria=cc.cat_codigo)
									join TAO_PAY_PAL.Factura f on(t.transf_nroFactura=f.fact_numero)
where YEAR(f.fact_fecha)=@anio
and DATEPART(QUARTER, f.fact_fecha)=@trim) a
group by a.Categoria
order by Total_Facturado desc
end;
go