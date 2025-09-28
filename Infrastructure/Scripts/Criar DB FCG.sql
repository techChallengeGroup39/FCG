/* ===========================================================
   Script para criar a base de dados FCG (SQL Server)
   - Idempotente (verifica existência antes de criar)
   - Cria schemas Core
   =========================================================== */

SET NOCOUNT ON;
GO

/* 1) Criar banco se não existir */
IF DB_ID(N'FCG') IS NULL
BEGIN
    PRINT 'Criando base de dados FCG...';
    CREATE DATABASE [FCG]
    -- Você pode ajustar o FILEGROUP, tamanho, log etc conforme necessário
    ;
END
ELSE
BEGIN
    PRINT 'Base de dados FCG já existe.';
END
GO

USE [FCG];
GO

/* 2) Criar schemas */
IF SCHEMA_ID(N'Core') IS NULL EXEC('CREATE SCHEMA Core'); -- normalmente já existe