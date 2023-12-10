CREATE DATABASE db_ProvaSetis
go

USE db_ProvaSetis
go

-- Tabela ADM_Sistema

CREATE TABLE ADM_Sistema (
  SIS_Id tinyint NOT NULL IDENTITY,
  SIS_Nome varchar(50) NOT NULL,
  SIS_Link varchar(50) NOT NULL,
  CONSTRAINT PK_ADM_Sistema PRIMARY KEY (SIS_Id)
);


-- Tabela ADM_Perfil

CREATE TABLE ADM_Perfil (
  PER_Id smallint NOT NULL IDENTITY,
  PER_SIS_Id TINYINT NOT NULL,
  PER_Nome varchar(50) NOT NULL,
  CONSTRAINT PK_ADM_Perfil PRIMARY KEY (PER_Id),
  CONSTRAINT FK_ADM_SISTEMA FOREIGN KEY (PER_SIS_Id) REFERENCES ADM_Sistema (SIS_Id)
);


-- Tabela ADM_Entidade

CREATE TABLE ADM_Entidade (
  ENT_Id smallint NOT NULL IDENTITY,
  ENT_Nome varchar(50) NOT NULL,
  ENT_Responsavel varchar(50) NOT NULL,
  ENT_TerminalPrefixo smallint NOT NULL,
  CONSTRAINT PK_ADM_Entidade PRIMARY KEY (ENT_Id)
);



-- Tabela ADM_Usuario

CREATE TABLE ADM_Usuario (
  USU_Id smallint NOT NULL IDENTITY,
  USU_ENT_Id smallint NOT NULL,
  USU_Nome varchar(50) NOT NULL,
  USU_Login varchar(16) NOT NULL,
  USU_Senha varchar(100) NOT NULL,
  USU_Bloqueado bit NOT NULL,
  USU_DataAcesso datetime NOT NULL,
  CONSTRAINT PK_ADM_Usuario PRIMARY KEY (USU_Id),
  CONSTRAINT FK_ADM_Usuario_Entidade FOREIGN KEY (USU_ENT_Id) REFERENCES ADM_Entidade (ENT_Id)
);



-- Tabela ADM_UsuarioXPerfil

CREATE TABLE ADM_UsuarioXPerfil (
  USP_USU_Id smallint NOT NULL,
  USP_PER_Id smallint NOT NULL,
  CONSTRAINT FK_ADM_UsuarioXPerfil_Usuario FOREIGN KEY (USP_USU_Id) REFERENCES ADM_Usuario (USU_Id),
  CONSTRAINT FK_ADM_UsuarioXPerfil_Perfil FOREIGN KEY (USP_PER_Id) REFERENCES ADM_Perfil (PER_Id)
);



---- Tabela ADM_Sistema

--INSERT INTO ADM_Sistema (SIS_Nome, SIS_Link)
--VALUES
--('Sistema A', 'https://sistemaa.com.br'),
--('Sistema B', 'https://sistemab.com.br'),
--('Sistema C', 'https://sistemac.com.br');

---- Tabela ADM_Perfil

--INSERT INTO ADM_Perfil (PER_SIS_Id, PER_Nome)
--VALUES
--(1, 'Administrador'),
--(1, 'Editor'),
--(2, 'Visualizador');

---- Tabela ADM_Entidade

--INSERT INTO ADM_Entidade (ENT_Nome, ENT_Responsavel, ENT_TerminalPrefixo)
--VALUES
--('Empresa X', 'José da Silva', 1234),
--('Empresa Y', 'Ana Santos', 5678);

---- Tabela ADM_Usuario

--INSERT INTO ADM_Usuario (USU_ENT_Id, USU_Nome, USU_Login, USU_Senha, USU_Bloqueado, USU_DataAcesso)
--VALUES
--(1, 'João da Silva', 'joao.silva', '123456', 0, '2023-12-08T15:39:00'),
--(1, 'Maria da Silva', 'maria.silva', '789456', 1, '2023-12-07T17:24:00'),
--(2, 'Pedro da Silva', 'pedro.silva', '098765', 0, '2023-12-06T19:12:00');

---- Tabela ADM_UsuarioXPerfil

--INSERT INTO ADM_UsuarioXPerfil (USP_USU_Id, USP_PER_Id)
--VALUES
--(1, 1),
--(1, 2),
--(2, 3);


SELECT
  u.USU_Nome AS Nome,
  e.ENT_Nome AS Entidade,
  p.PER_Nome AS Perfil,
  p.PER_SIS_Id AS Sistema
FROM ADM_Usuario u
INNER JOIN ADM_Entidade e ON e.ENT_Id = u.USU_ENT_Id
INNER JOIN ADM_UsuarioXPerfil up ON up.USP_USU_Id = u.USU_Id
INNER JOIN ADM_Perfil p ON p.PER_Id = up.USP_PER_Id
