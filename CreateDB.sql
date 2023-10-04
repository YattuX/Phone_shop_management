CREATE TABLE Client (
  Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
  Name VARCHAR(255) NOT NULL,
  LastName VARCHAR(255) NOT NULL,
  PhoneNumber VARCHAR(255) NULL,
  WhatsappNumber VARCHAR(255) NULL,
  Identifiant VARCHAR(255) NULL,
  Adress VARCHAR(255) NULL,
  IsClientEnGros BIT NULL,
  DateCreated DATETIME2 NULL,
  CreatedBy VARCHAR(255) NULL,
  DateModified DATETIME2 NULL,
  ModifiedBy VARCHAR(255) NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE Fournisseur (
  Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
  Name VARCHAR(255) NOT NULL,
  Identifiant VARCHAR(225) NULL,
  LastName VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NULL,
  WhatsappNumber VARCHAR(255) NULL,
  DateCreated DATETIME NULL,
  CreatedBy VARCHAR(255) NULL,
  DateModified DATETIME NULL,
  ModifiedBy VARCHAR(255) NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE [Type_] (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(255),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);

CREATE TABLE [dbo].[Couleur] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]         NVARCHAR (255)   NULL,
    [CodeCouleur]  NVARCHAR (255)   NULL,
    [DateCreated]  DateTime2         NULL,
    [CreatedBy]    VARCHAR (255)    NULL,
    [DateModified] DateTime2         NULL,
    [ModifiedBy]   VARCHAR (255)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE Etat (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Particularite (
Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Processeurs (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Stockage (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE TypeArticle (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(255),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);

CREATE TABLE Marque (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    TypeArticleId UNIQUEIDENTIFIER,
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    FOREIGN KEY (TypeArticleId) REFERENCES TypeArticle(Id),
    PRIMARY KEY (Id)
);

CREATE TABLE Modele (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    MarqueId UNIQUEIDENTIFIER,
    FOREIGN KEY (MarqueId) REFERENCES Marque(Id),
    DateCreated DateTime2,
    CreatedBy VARCHAR(255),
    DateModified DateTime2,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);


CREATE TABLE Caracteristique
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    DateCreated DateTime2,
    CreatedBy NVARCHAR(MAX),
    DateModified DateTime2,
    ModifiedBy NVARCHAR(MAX),
    HasStockage BIT,
    HasCouleur BIT,
    HasNombreDeSim BIT,
    HasImei BIT,
    HasParticularite BIT,
    HasEtat BIT,
    HasProcesseurs BIT,
    HasTailleEcran BIT,
    HasRam BIT,
    HasQualite BIT,
    HasType BIT,
    HasCapacite BIT,
    HasCaracteristic BIT,
    HasPuissance BIT,
    HasPosition BIT,
    HasDescription BIT,
    ModelId UNIQUEIDENTIFIER,
    FOREIGN KEY (ModelId) REFERENCES Modele(Id)
);

CREATE TABLE [dbo].[Article] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [DateCreated]       DATETIME         NULL,
    [CreatedBy]         NVARCHAR (255)   NULL,
    [DateModified]      DATETIME         NULL,
    [ModifiedBy]        NVARCHAR (255)   NULL,
    [StockageId]        UNIQUEIDENTIFIER NULL,
    [CouleurId]         UNIQUEIDENTIFIER NULL,
    [NombreDeSim]       INT              NULL,
    [Imei]              NVARCHAR (255)   NULL,
    [ParticulariteId]   UNIQUEIDENTIFIER NULL,
    [EtatId]            UNIQUEIDENTIFIER NULL,
    [Processeurs]       NVARCHAR (255)   NULL,
    [TailleEcran]       NVARCHAR (255)   NULL,
    [Ram]               NVARCHAR (255)   NULL,
    [Qualite]           NVARCHAR (255)   NULL,
    [Position]          NVARCHAR (255)   NULL,
    [TypeId]            UNIQUEIDENTIFIER NULL,
    [Capacite]          NVARCHAR (255)   NULL,
    [CaracteristiqueId] UNIQUEIDENTIFIER NULL,
    [Puissance]         NVARCHAR (255)   NULL,
    [Description]       NVARCHAR (Max)   NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StockageId]) REFERENCES [dbo].[Stockage] ([Id]),
    FOREIGN KEY ([CouleurId]) REFERENCES [dbo].[Couleur] ([Id]),
    FOREIGN KEY ([ParticulariteId]) REFERENCES [dbo].[Particularite] ([Id]),
    FOREIGN KEY ([EtatId]) REFERENCES [dbo].[Etat] ([Id]),
    FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Type_] ([Id]),
    FOREIGN KEY ([CaracteristiqueId]) REFERENCES [dbo].[Caracteristique] ([Id])
);


