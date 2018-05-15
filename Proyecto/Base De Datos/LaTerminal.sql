/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     3/12/2018 11:14:32 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BUS') and o.name = 'FK_BUSES_EMPRESAS')
alter table BUS
   drop constraint FK_BUSES_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BUS') and o.name = 'FK_BUSES_CHOFERES')
alter table BUS
   drop constraint FK_BUSES_CHOFERES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DIAS_RUTAS') and o.name = 'FK_RUTAS_DIAS')
alter table DIAS_RUTAS
   drop constraint FK_RUTAS_DIAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DIAS_RUTAS') and o.name = 'FK_DIAS_RUTAS')
alter table DIAS_RUTAS
   drop constraint FK_DIAS_RUTAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESAS_RAMPAS') and o.name = 'FK_RAMPAS_EMPRESAS')
alter table EMPRESAS_RAMPAS
   drop constraint FK_RAMPAS_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESAS_RAMPAS') and o.name = 'FK_EMPRESAS_RAMPAS')
alter table EMPRESAS_RAMPAS
   drop constraint FK_EMPRESAS_RAMPAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESAS_TERMINALES') and o.name = 'FK_EMPRESAS_TERMINALES')
alter table EMPRESAS_TERMINALES
   drop constraint FK_EMPRESAS_TERMINALES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESAS_TERMINALES') and o.name = 'FK_TERMINALES_EMPRESAS')
alter table EMPRESAS_TERMINALES
   drop constraint FK_TERMINALES_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESA_BUS') and o.name = 'FK_EMPRESAS_ENCARGADOS')
alter table EMPRESA_BUS
   drop constraint FK_EMPRESAS_ENCARGADOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ESTACIONAMIENTO') and o.name = 'FK_ESTACIONAMIENTOS_TERMINALES')
alter table ESTACIONAMIENTO
   drop constraint FK_ESTACIONAMIENTOS_TERMINALES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_REFERENCE_TRANSACC')
alter table FACTURA
   drop constraint FK_FACTURA_REFERENCE_TRANSACC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_REFERENCE_COMPRADO')
alter table FACTURA
   drop constraint FK_FACTURA_REFERENCE_COMPRADO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HORARIO') and o.name = 'FK_HORARIOS_RUTAS')
alter table HORARIO
   drop constraint FK_HORARIOS_RUTAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HORARIO') and o.name = 'FK_HORARIOS_BUSES')
alter table HORARIO
   drop constraint FK_HORARIOS_BUSES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LINEA_DETALLE') and o.name = 'FK_LINEAS_FACTURAS')
alter table LINEA_DETALLE
   drop constraint FK_LINEAS_FACTURAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARADAS') and o.name = 'FK_PARADAS_EMPRESAS')
alter table PARADAS
   drop constraint FK_PARADAS_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARADAS_RUTAS') and o.name = 'FK_RUTAS_PARADAS')
alter table PARADAS_RUTAS
   drop constraint FK_RUTAS_PARADAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARADAS_RUTAS') and o.name = 'FK_PARADAS_RUTAS')
alter table PARADAS_RUTAS
   drop constraint FK_PARADAS_RUTAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERSONA_CLAVES') and o.name = 'FK_CLAVES_USUARIOS')
alter table PERSONA_CLAVES
   drop constraint FK_CLAVES_USUARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUEJA') and o.name = 'FK_QUEJAS_USUARIOS')
alter table QUEJA
   drop constraint FK_QUEJAS_USUARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUEJA') and o.name = 'FK_QUEJAS_VIAJES')
alter table QUEJA
   drop constraint FK_QUEJAS_VIAJES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RAMPA_SALIDA') and o.name = 'FK_RAMPAS_TERMINALES')
alter table RAMPA_SALIDA
   drop constraint FK_RAMPAS_TERMINALES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RAMPA_SALIDA') and o.name = 'FK_RAMPAS_SA_BUSES')
alter table RAMPA_SALIDA
   drop constraint FK_RAMPAS_SA_BUSES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REQUISITO') and o.name = 'FK_REQUISIT_REFERENCE_BUS')
alter table REQUISITO
   drop constraint FK_REQUISIT_REFERENCE_BUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROLES_PERMISOS') and o.name = 'FK_PERMISOS_ROLES')
alter table ROLES_PERMISOS
   drop constraint FK_PERMISOS_ROLES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROLES_PERMISOS') and o.name = 'FK_ROLES_PERMISOS')
alter table ROLES_PERMISOS
   drop constraint FK_ROLES_PERMISOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RUTA') and o.name = 'FK_RUTAS_EMPRESAS')
alter table RUTA
   drop constraint FK_RUTAS_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SANCION') and o.name = 'FK_SANCIONES_EMPRESAS')
alter table SANCION
   drop constraint FK_SANCIONES_EMPRESAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TARJETA') and o.name = 'FK_TARJETAS_USUARIOS')
alter table TARJETA
   drop constraint FK_TARJETAS_USUARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TARJETA') and o.name = 'FK_TARJETAS_TIPOS')
alter table TARJETA
   drop constraint FK_TARJETAS_TIPOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TARJETA') and o.name = 'FK_TARJETAS_TERMINALES')
alter table TARJETA
   drop constraint FK_TARJETAS_TERMINALES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TERMINAL') and o.name = 'FK_TERMINALES_USUARIOS')
alter table TERMINAL
   drop constraint FK_TERMINALES_USUARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACCIONES_TARJETAS')
alter table TRANSACCION
   drop constraint FK_TRANSACCIONES_TARJETAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACC_REFERENCE_USUARIO')
alter table TRANSACCION
   drop constraint FK_TRANSACC_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACC_REFERENCE_EMPRESA_')
alter table TRANSACCION
   drop constraint FK_TRANSACC_REFERENCE_EMPRESA_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACC_REFERENCE_SANCION')
alter table TRANSACCION
   drop constraint FK_TRANSACC_REFERENCE_SANCION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACC_REFERENCE_TARJETA')
alter table TRANSACCION
   drop constraint FK_TRANSACC_REFERENCE_TARJETA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRANSACCION') and o.name = 'FK_TRANSACC_REFERENCE_USO_ESTA')
alter table TRANSACCION
   drop constraint FK_TRANSACC_REFERENCE_USO_ESTA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USO_ESTACIONAMIENTO') and o.name = 'FK_USOS_ESTACIONAMIENTO')
alter table USO_ESTACIONAMIENTO
   drop constraint FK_USOS_ESTACIONAMIENTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USO_ESTACIONAMIENTO') and o.name = 'FK_USOS_TARJETA')
alter table USO_ESTACIONAMIENTO
   drop constraint FK_USOS_TARJETA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USO_ESTACIONAMIENTO') and o.name = 'FK_USO_ESTA_REFERENCE_EMPRESA_')
alter table USO_ESTACIONAMIENTO
   drop constraint FK_USO_ESTA_REFERENCE_EMPRESA_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USO_ESTACIONAMIENTO') and o.name = 'FK_USO_ESTA_REFERENCE_BUS')
alter table USO_ESTACIONAMIENTO
   drop constraint FK_USO_ESTA_REFERENCE_BUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIOS_ROLES')
alter table USUARIO
   drop constraint FK_USUARIOS_ROLES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO_LOGS') and o.name = 'FK_LOGS_USUARIOS')
alter table USUARIO_LOGS
   drop constraint FK_LOGS_USUARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VIAJE') and o.name = 'FK_VIAJES_HORARIOS')
alter table VIAJE
   drop constraint FK_VIAJES_HORARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VIAJES_TARJETAS') and o.name = 'FK_VIAJES_TARJETAS')
alter table VIAJES_TARJETAS
   drop constraint FK_VIAJES_TARJETAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VIAJES_TARJETAS') and o.name = 'FK_TARJETAS_VIAJES')
alter table VIAJES_TARJETAS
   drop constraint FK_TARJETAS_VIAJES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BUS')
            and   type = 'U')
   drop table BUS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMPRADOR')
            and   type = 'U')
   drop table COMPRADOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CONFIGURACION')
            and   type = 'U')
   drop table CONFIGURACION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DIAS_OPERATIVOS')
            and   type = 'U')
   drop table DIAS_OPERATIVOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DIAS_RUTAS')
            and   type = 'U')
   drop table DIAS_RUTAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRESAS_RAMPAS')
            and   type = 'U')
   drop table EMPRESAS_RAMPAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRESAS_TERMINALES')
            and   type = 'U')
   drop table EMPRESAS_TERMINALES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRESA_BUS')
            and   type = 'U')
   drop table EMPRESA_BUS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTACIONAMIENTO')
            and   type = 'U')
   drop table ESTACIONAMIENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EXCEPCION')
            and   type = 'U')
   drop table EXCEPCION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HORARIO')
            and   type = 'U')
   drop table HORARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LINEA_DETALLE')
            and   type = 'U')
   drop table LINEA_DETALLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LISTA_VALOR')
            and   type = 'U')
   drop table LISTA_VALOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MENSAJE')
            and   type = 'U')
   drop table MENSAJE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NOTIFICACION')
            and   type = 'U')
   drop table NOTIFICACION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PARADAS')
            and   type = 'U')
   drop table PARADAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PARADAS_RUTAS')
            and   type = 'U')
   drop table PARADAS_RUTAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERMISO')
            and   type = 'U')
   drop table PERMISO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERSONA_CLAVES')
            and   type = 'U')
   drop table PERSONA_CLAVES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUEJA')
            and   type = 'U')
   drop table QUEJA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RAMPA_SALIDA')
            and   type = 'U')
   drop table RAMPA_SALIDA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REQUISITO')
            and   type = 'U')
   drop table REQUISITO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROLES_PERMISOS')
            and   type = 'U')
   drop table ROLES_PERMISOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RUTA')
            and   type = 'U')
   drop table RUTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SANCION')
            and   type = 'U')
   drop table SANCION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TARJETA')
            and   type = 'U')
   drop table TARJETA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TERMINAL')
            and   type = 'U')
   drop table TERMINAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_TARJETA')
            and   type = 'U')
   drop table TIPO_TARJETA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TRANSACCION')
            and   type = 'U')
   drop table TRANSACCION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USO_ESTACIONAMIENTO')
            and   type = 'U')
   drop table USO_ESTACIONAMIENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO_LOGS')
            and   type = 'U')
   drop table USUARIO_LOGS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VIAJE')
            and   type = 'U')
   drop table VIAJE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VIAJES_TARJETAS')
            and   type = 'U')
   drop table VIAJES_TARJETAS
go

/*==============================================================*/
/* Table: BUS                                                   */
/*==============================================================*/
create table BUS (
   NUMERO_PLACA         varchar(50)          not null,
   ID_EMPRESA_BUS       varchar(50)          null,
   ID_CHOFER            varchar(50)          null,
   NUMERO_UNIDAD        varchar(50)          null,
   MARCA                varchar(50)          null,
   MODELO               varchar(50)          null,
   CAPACIDAD            int                  null,
   ESPACIOS_DISCAPACITADOS int                  null,
   ESTADO               int                  null,
   constraint PK_BUS primary key (NUMERO_PLACA)
)
go

/*==============================================================*/
/* Table: COMPRADOR                                             */
/*==============================================================*/
create table COMPRADOR (
   ID                   int                  not null,
   ID_FACTURA           int                  null,
   NOMBRE_COMPLETO      varchar(max)         null,
   TELEFONO             varchar(30)          null,
   CORREO               varchar(255)         null,
   constraint PK_COMPRADOR primary key (ID)
)
go

/*==============================================================*/
/* Table: CONFIGURACION                                         */
/*==============================================================*/
create table CONFIGURACION (
   ID                   int                  not null,
   CODIGO               varchar(50)          null,
   VALOR                varchar(50)          null,
   constraint PK_CONFIGURACION primary key (ID)
)
go

/*==============================================================*/
/* Table: DIAS_OPERATIVOS                                       */
/*==============================================================*/
create table DIAS_OPERATIVOS (
   ID                   int                  not null,
   DIA                  time                 null,
   constraint PK_DIAS_OPERATIVOS primary key (ID)
)
go

/*==============================================================*/
/* Table: DIAS_RUTAS                                            */
/*==============================================================*/
create table DIAS_RUTAS (
   ID_DIA               int                  not null,
   ID_RUTA              varchar(50)          not null,
   constraint PK_DIAS_RUTAS primary key (ID_DIA, ID_RUTA)
)
go

/*==============================================================*/
/* Table: EMPRESAS_RAMPAS                                       */
/*==============================================================*/
create table EMPRESAS_RAMPAS (
   ID_EMPRESA_BUS       varchar(50)          not null,
   ID_RAMPA_SALIDA      int                  not null,
   constraint PK_EMPRESAS_RAMPAS primary key (ID_EMPRESA_BUS, ID_RAMPA_SALIDA)
)
go

/*==============================================================*/
/* Table: EMPRESAS_TERMINALES                                   */
/*==============================================================*/
create table EMPRESAS_TERMINALES (
   ID_EMPRESA_BUS       varchar(50)          not null,
   ID_TERMINAL          varchar(50)          not null,
   constraint PK_EMPRESAS_TERMINALES primary key (ID_EMPRESA_BUS, ID_TERMINAL)
)
go

/*==============================================================*/
/* Table: EMPRESA_BUS                                           */
/*==============================================================*/
create table EMPRESA_BUS (
   CEDULA_JUR           varchar(50)          not null,
   ID_ENCARGADO         varchar(50)          null,
   LOGO                 varchar(255)         null,
   CODIGO               varchar(50)          null,
   NOMBRE               varchar(50)          null,
   TELEFONO             varchar(30)          null,
   CORREO               varchar(255)         null,
   ESTADO               int                  null,
   constraint PK_EMPRESA_BUS primary key (CEDULA_JUR)
)
go

/*==============================================================*/
/* Table: ESTACIONAMIENTO                                       */
/*==============================================================*/
create table ESTACIONAMIENTO (
   ID                   int                  not null,
   ID_TERMINAL          varchar(50)          null,
   TIPO                 int                  null,
   NUMERO               varchar(50)          null,
   ESTADO               int                  null,
   constraint PK_ESTACIONAMIENTO primary key (ID)
)
go

/*==============================================================*/
/* Table: EXCEPCION                                             */
/*==============================================================*/
create table EXCEPCION (
   ID                   int                  not null,
   CODIGO               int                  null,
   MENSAJE              varchar(max)         null,
   STACKTRACE           varchar(max)         null,
   FECHA                datetime             null,
   constraint PK_EXCEPCION primary key (ID)
)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   ID                   int                  not null,
   FECHA                int                  null,
   DETALLE              varchar(max)         null,
   IV                   float                null,
   IVA                  float                null,
   SUBTOTAL             int                  null,
   TOTAL                int                  null,
   ID_TRANSACCION       int                  null,
   constraint PK_FACTURA primary key (ID)
)
go

/*==============================================================*/
/* Table: HORARIO                                               */
/*==============================================================*/
create table HORARIO (
   ID                   int                  not null,
   ID_RUTA              varchar(50)          null,
   ID_BUS               varchar(50)          null,
   SALIDA               time                 null,
   LLEGADA              time                 null,
   ESTADO               int                  null,
   constraint PK_HORARIO primary key (ID)
)
go

/*==============================================================*/
/* Table: LINEA_DETALLE                                         */
/*==============================================================*/
create table LINEA_DETALLE (
   ID                   int                  not null,
   ID_FACTURA           int                  null,
   NOMBRE               varchar(150)         null,
   CANTIDAD             float                null,
   VALOR_UNITARIO       float                null,
   constraint PK_LINEA_DETALLE primary key (ID)
)
go

/*==============================================================*/
/* Table: LISTA_VALOR                                           */
/*==============================================================*/
create table LISTA_VALOR (
   ID_LISTA             varchar(50)          not null,
   VALOR                varchar(50)          not null,
   DESCRIPCION          varchar(50)          null,
   constraint PK_LISTA_VALOR primary key (ID_LISTA, VALOR)
)
go

/*==============================================================*/
/* Table: MENSAJE                                               */
/*==============================================================*/
create table MENSAJE (
   ID                   int                  not null,
   MENSAJE              varchar(max)         null,
   constraint PK_MENSAJE primary key (ID)
)
go

/*==============================================================*/
/* Table: NOTIFICACION                                          */
/*==============================================================*/
create table NOTIFICACION (
   ID                   int                  not null,
   MENSAJE              varchar(max)         null,
   FECHA                datetime             null,
   TIPO                 int                  null,
   constraint PK_NOTIFICACION primary key (ID)
)
go

/*==============================================================*/
/* Table: PARADAS                                               */
/*==============================================================*/
create table PARADAS (
   ID                   int                  not null,
   ID_EMPRESA_BUS       varchar(50)          null,
   NOMBRE               varchar(50)          null,
   DIRECCION            int                  null,
   LAT                  time                 null,
   LONG                 time                 null,
   ESTADO               int                  null,
   constraint PK_PARADAS primary key (ID)
)
go

/*==============================================================*/
/* Table: PARADAS_RUTAS                                         */
/*==============================================================*/
create table PARADAS_RUTAS (
   ID_PARADA            int                  not null,
   ID_RUTA              varchar(50)          not null,
   constraint PK_PARADAS_RUTAS primary key (ID_PARADA, ID_RUTA)
)
go

/*==============================================================*/
/* Table: PERMISO                                               */
/*==============================================================*/
create table PERMISO (
   ID                   INT                  not null,
   NOMBRE               varchar(50)          null,
   constraint PK_PERMISO primary key (ID)
)
go

/*==============================================================*/
/* Table: PERSONA_CLAVES                                        */
/*==============================================================*/
create table PERSONA_CLAVES (
   ID                   int                  not null,
   ID_USUARIO           varchar(50)          null,
   FECHA                datetime             null,
   CLAVE                varchar(50)          null,
   constraint PK_PERSONA_CLAVES primary key (ID)
)
go

/*==============================================================*/
/* Table: QUEJA                                                 */
/*==============================================================*/
create table QUEJA (
   ID                   int                  not null,
   ID_VIAJE             int                  null,
   ID_USUARIO           varchar(50)          null,
   DETALLE              varchar(max)         null,
   ESTADO               int                  null,
   constraint PK_QUEJA primary key (ID)
)
go

/*==============================================================*/
/* Table: RAMPA_SALIDA                                          */
/*==============================================================*/
create table RAMPA_SALIDA (
   ID                   int                  not null,
   ID_TERMINAL          varchar(50)          null,
   ID_BUS               varchar(50)          null,
   NOMBRE               varchar(50)          null,
   ESTADO               int                  null,
   constraint PK_RAMPA_SALIDA primary key (ID)
)
go

/*==============================================================*/
/* Table: REQUISITO                                             */
/*==============================================================*/
create table REQUISITO (
   ID                   int                  not null,
   ID_BUS               varchar(50)          null,
   NOMBRE               varchar(50)          not null,
   ESTADO               int                  not null,
   constraint PK_REQUISITO primary key (ID)
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID                   int                  not null,
   NOMBRE               varchar(50)          null,
   DESCRIPCION          varchar(200)         null,
   constraint PK_ROL primary key (ID)
)
go

/*==============================================================*/
/* Table: ROLES_PERMISOS                                        */
/*==============================================================*/
create table ROLES_PERMISOS (
   ID_ROL               int                  not null,
   ID_PERMISO           int                  not null,
   constraint PK_ROLES_PERMISOS primary key (ID_ROL, ID_PERMISO)
)
go

/*==============================================================*/
/* Table: RUTA                                                  */
/*==============================================================*/
create table RUTA (
   NUMERO_RUTA          varchar(50)          not null,
   ID_EMPRESA_BUS       varchar(50)          null,
   DESCRIPCION          varchar(150)         null,
   DESTINO_LAT          float                null,
   DESTINO_LONG         float                null,
   TARIFA_POR_KILOMETRO float                null,
   TARIFA               float                null,
   DISTANCIA            float                null,
   ESTADO               int                  null,
   constraint PK_RUTA primary key (NUMERO_RUTA)
)
go

/*==============================================================*/
/* Table: SANCION                                               */
/*==============================================================*/
create table SANCION (
   ID                   int                  not null,
   ID_EMPRESA_BUS       varchar(50)          null,
   DETALLE              varchar(max)         null,
   FECHA                datetime             null,
   MONTO                money                null,
   TIPO                 int                  null,
   ESTADO               int                  null,
   constraint PK_SANCION primary key (ID)
)
go

/*==============================================================*/
/* Table: TARJETA                                               */
/*==============================================================*/
create table TARJETA (
   CODIGO               varchar(50)          not null,
   ID_USUARIO           varchar(50)          null,
   ID_TERMINAL          varchar(50)          null,
   ID_TIPO              int                  null,
   SALDO                float                null,
   FECHA_EMISION        datetime             null,
   FECHA_VENCIMIENTO    datetime             null,
   ESTADO               int                  null,
   constraint PK_TARJETA primary key (CODIGO)
)
go

/*==============================================================*/
/* Table: TERMINAL                                              */
/*==============================================================*/
create table TERMINAL (
   CEDULA_JUR           varchar(50)          not null,
   ID_ENCARGADO         varchar(50)          null,
   NOMBRE               varchar(50)          null,
   DIRECCION            varchar(500)         null,
   LAT                  float                null,
   LONG                 float                null,
   TELEFONO             varchar(30)          null,
   CORREO               varchar(255)         null,
   ESTADO               int                  null,
   constraint PK_TERMINAL primary key (CEDULA_JUR)
)
go

/*==============================================================*/
/* Table: TIPO_TARJETA                                          */
/*==============================================================*/
create table TIPO_TARJETA (
   ID                   int                  not null,
   NOMBRE               varchar(50)          null,
   BENEFICIO            float                null,
   constraint PK_TIPO_TARJETA primary key (ID)
)
go

/*==============================================================*/
/* Table: TRANSACCION                                           */
/*==============================================================*/
create table TRANSACCION (
   ID                   int                  not null,
   ID_USUARIO           varchar(50)          null,
   ID_EMPRESA_BUS       varchar(50)          null,
   ID_TARJETA_RECARGA   varchar(50)          null,
   ID_USO_ESTACIONAMIENTO int                  null,
   ID_USO_TARJETA       int                  null,
   ID_SANCION           int                  null,
   TIPO                 int                  null,
   MONTO                float                null,
   FECHA                datetime             null,
   constraint PK_TRANSACCION primary key (ID)
)
go

/*==============================================================*/
/* Table: USO_ESTACIONAMIENTO                                   */
/*==============================================================*/
create table USO_ESTACIONAMIENTO (
   ID                   int                  not null,
   ID_ESTACIONAMIENTO   int                  not null,
   ID_TARJETA           varchar(50)          null,
   ID_EMPRESA_BUS       varchar(50)          null,
   ID_BUS               varchar(50)          null,
   FECHA_INGRESO        datetime             null,
   FECHA_SALIDA         datetime             null,
   TOTAL                float                null,
   ESTADO               int                  null,
   TIPO                 int                  null,
   constraint PK_USO_ESTACIONAMIENTO primary key (ID)
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   IDENTIFICACION       varchar(50)          not null,
   ID_ROL               int                  null,
   FOTO                 varchar(255)         null,
   PNOMBRE              varchar(50)          null,
   SNOMBRE              varchar(50)          null,
   PAPELLIDO            varchar(50)          null,
   SAPELLIDO            varchar(50)          null,
   GENERO               int                  null,
   FECHA_NAC            datetime             null,
   TELEFONO             varchar(30)          null,
   CORREO               varchar(255)         null,
   DIRECCION            varchar(500)         null,
   CLAVE                varchar(50)          null,
   CLAVE_SALT           varchar(50)          null,
   constraint PK_USUARIO primary key (IDENTIFICACION)
)
go

/*==============================================================*/
/* Table: USUARIO_LOGS                                          */
/*==============================================================*/
create table USUARIO_LOGS (
   ID                   int                  not null,
   ID_USUARIO           varchar(50)          null,
   FECHA                datetime             null,
   EVENTO               varchar(50)          null,
   constraint PK_USUARIO_LOGS primary key (ID)
)
go

/*==============================================================*/
/* Table: VIAJE                                                 */
/*==============================================================*/
create table VIAJE (
   ID                   int                  not null,
   ID_HORARIO           int                  null,
   SALIDA               datetime             null,
   LLEGADA              datetime             null,
   DISTANCIA            float                null,
   TIEMPO               time                 null,
   ESTADO               int                  null,
   constraint PK_VIAJE primary key (ID)
)
go

/*==============================================================*/
/* Table: VIAJES_TARJETAS                                       */
/*==============================================================*/
create table VIAJES_TARJETAS (
   ID                   int                  not null,
   ID_VIAJE             int                  not null,
   ID_TARJETA           varchar(50)          null,
   PASAJE               float                null,
   FECHA                datetime             null,
   ESTADO               int                  null,
   constraint PK_VIAJES_TARJETAS primary key (ID)
)
go

alter table BUS
   add constraint FK_BUSES_EMPRESAS foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table BUS
   add constraint FK_BUSES_CHOFERES foreign key (ID_CHOFER)
      references USUARIO (IDENTIFICACION)
go

alter table DIAS_RUTAS
   add constraint FK_RUTAS_DIAS foreign key (ID_RUTA)
      references RUTA (NUMERO_RUTA)
go

alter table DIAS_RUTAS
   add constraint FK_DIAS_RUTAS foreign key (ID_DIA)
      references DIAS_OPERATIVOS (ID)
go

alter table EMPRESAS_RAMPAS
   add constraint FK_RAMPAS_EMPRESAS foreign key (ID_RAMPA_SALIDA)
      references RAMPA_SALIDA (ID)
go

alter table EMPRESAS_RAMPAS
   add constraint FK_EMPRESAS_RAMPAS foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table EMPRESAS_TERMINALES
   add constraint FK_EMPRESAS_TERMINALES foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table EMPRESAS_TERMINALES
   add constraint FK_TERMINALES_EMPRESAS foreign key (ID_TERMINAL)
      references TERMINAL (CEDULA_JUR)
go

alter table EMPRESA_BUS
   add constraint FK_EMPRESAS_ENCARGADOS foreign key (ID_ENCARGADO)
      references USUARIO (IDENTIFICACION)
go

alter table ESTACIONAMIENTO
   add constraint FK_ESTACIONAMIENTOS_TERMINALES foreign key (ID_TERMINAL)
      references TERMINAL (CEDULA_JUR)
go

alter table FACTURA
   add constraint FK_FACTURA_REFERENCE_TRANSACC foreign key (ID_TRANSACCION)
      references TRANSACCION (ID)
go

alter table FACTURA
   add constraint FK_FACTURA_REFERENCE_COMPRADO foreign key (ID)
      references COMPRADOR (ID)
go

alter table HORARIO
   add constraint FK_HORARIOS_RUTAS foreign key (ID_RUTA)
      references RUTA (NUMERO_RUTA)
go

alter table HORARIO
   add constraint FK_HORARIOS_BUSES foreign key (ID_BUS)
      references BUS (NUMERO_PLACA)
go

alter table LINEA_DETALLE
   add constraint FK_LINEAS_FACTURAS foreign key (ID_FACTURA)
      references FACTURA (ID)
go

alter table PARADAS
   add constraint FK_PARADAS_EMPRESAS foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table PARADAS_RUTAS
   add constraint FK_RUTAS_PARADAS foreign key (ID_RUTA)
      references RUTA (NUMERO_RUTA)
go

alter table PARADAS_RUTAS
   add constraint FK_PARADAS_RUTAS foreign key (ID_PARADA)
      references PARADAS (ID)
go

alter table PERSONA_CLAVES
   add constraint FK_CLAVES_USUARIOS foreign key (ID_USUARIO)
      references USUARIO (IDENTIFICACION)
go

alter table QUEJA
   add constraint FK_QUEJAS_USUARIOS foreign key (ID_USUARIO)
      references USUARIO (IDENTIFICACION)
go

alter table QUEJA
   add constraint FK_QUEJAS_VIAJES foreign key (ID_VIAJE)
      references VIAJE (ID)
go

alter table RAMPA_SALIDA
   add constraint FK_RAMPAS_TERMINALES foreign key (ID_TERMINAL)
      references TERMINAL (CEDULA_JUR)
go

alter table RAMPA_SALIDA
   add constraint FK_RAMPAS_SA_BUSES foreign key (ID_BUS)
      references BUS (NUMERO_PLACA)
go

alter table REQUISITO
   add constraint FK_REQUISIT_REFERENCE_BUS foreign key (ID_BUS)
      references BUS (NUMERO_PLACA)
go

alter table ROLES_PERMISOS
   add constraint FK_PERMISOS_ROLES foreign key (ID_PERMISO)
      references PERMISO (ID)
go

alter table ROLES_PERMISOS
   add constraint FK_ROLES_PERMISOS foreign key (ID_ROL)
      references ROL (ID)
go

alter table RUTA
   add constraint FK_RUTAS_EMPRESAS foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table SANCION
   add constraint FK_SANCIONES_EMPRESAS foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table TARJETA
   add constraint FK_TARJETAS_USUARIOS foreign key (ID_USUARIO)
      references USUARIO (IDENTIFICACION)
go

alter table TARJETA
   add constraint FK_TARJETAS_TIPOS foreign key (ID_TIPO)
      references TIPO_TARJETA (ID)
go

alter table TARJETA
   add constraint FK_TARJETAS_TERMINALES foreign key (ID_TERMINAL)
      references TERMINAL (CEDULA_JUR)
go

alter table TERMINAL
   add constraint FK_TERMINALES_USUARIOS foreign key (ID_ENCARGADO)
      references USUARIO (IDENTIFICACION)
go

alter table TRANSACCION
   add constraint FK_TRANSACCIONES_TARJETAS foreign key (ID_USO_TARJETA)
      references VIAJES_TARJETAS (ID)
go

alter table TRANSACCION
   add constraint FK_TRANSACC_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (IDENTIFICACION)
go

alter table TRANSACCION
   add constraint FK_TRANSACC_REFERENCE_EMPRESA_ foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table TRANSACCION
   add constraint FK_TRANSACC_REFERENCE_SANCION foreign key (ID_SANCION)
      references SANCION (ID)
go

alter table TRANSACCION
   add constraint FK_TRANSACC_REFERENCE_TARJETA foreign key (ID_TARJETA_RECARGA)
      references TARJETA (CODIGO)
go

alter table TRANSACCION
   add constraint FK_TRANSACC_REFERENCE_USO_ESTA foreign key (ID_USO_ESTACIONAMIENTO)
      references USO_ESTACIONAMIENTO (ID)
go

alter table USO_ESTACIONAMIENTO
   add constraint FK_USOS_ESTACIONAMIENTO foreign key (ID_ESTACIONAMIENTO)
      references ESTACIONAMIENTO (ID)
go

alter table USO_ESTACIONAMIENTO
   add constraint FK_USOS_TARJETA foreign key (ID_TARJETA)
      references TARJETA (CODIGO)
go

alter table USO_ESTACIONAMIENTO
   add constraint FK_USO_ESTA_REFERENCE_EMPRESA_ foreign key (ID_EMPRESA_BUS)
      references EMPRESA_BUS (CEDULA_JUR)
go

alter table USO_ESTACIONAMIENTO
   add constraint FK_USO_ESTA_REFERENCE_BUS foreign key (ID_BUS)
      references BUS (NUMERO_PLACA)
go

alter table USUARIO
   add constraint FK_USUARIOS_ROLES foreign key (ID_ROL)
      references ROL (ID)
go

alter table USUARIO_LOGS
   add constraint FK_LOGS_USUARIOS foreign key (ID_USUARIO)
      references USUARIO (IDENTIFICACION)
go

alter table VIAJE
   add constraint FK_VIAJES_HORARIOS foreign key (ID_HORARIO)
      references HORARIO (ID)
go

alter table VIAJES_TARJETAS
   add constraint FK_VIAJES_TARJETAS foreign key (ID_VIAJE)
      references VIAJE (ID)
go

alter table VIAJES_TARJETAS
   add constraint FK_TARJETAS_VIAJES foreign key (ID_TARJETA)
      references TARJETA (CODIGO)
go

