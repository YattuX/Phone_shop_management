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

CREATE TABLE Caracteristique
(
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Marque BIT DEFAULT 0,
    Modele BIT DEFAULT 0,
    Stockage BIT DEFAULT 0,
    Couleur BIT DEFAULT 0,
    NombreDeSim BIT DEFAULT 0,
    Imei BIT DEFAULT 0,
    Particularite BIT DEFAULT 0,
    Etat BIT DEFAULT 0,
    Processeurs BIT DEFAULT 0,
    TailleEcran BIT DEFAULT 0,
    Ram BIT DEFAULT 0,
    Nom BIT DEFAULT 0,
    Qualite BIT DEFAULT 0,
    Position BIT DEFAULT 0,
    Type BIT DEFAULT 0,
    Capacite BIT DEFAULT 0,
    Caracteristic BIT DEFAULT 0,
    Puissance BIT DEFAULT 0,
    PRIMARY KEY (Id)
);

CREATE TABLE Article (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    StockageId UNIQUEIDENTIFIER,
    CouleurId UNIQUEIDENTIFIER,
    NombreDeSim BIT,
    Imei BIT,
    ParticulariteId UNIQUEIDENTIFIER,
    EtatId UNIQUEIDENTIFIER,
    Processeurs NVARCHAR(255),
    TailleEcran NVARCHAR(255),
    Ram NVARCHAR(255),
    Nom NVARCHAR(255),
    Qualite NVARCHAR(255),
    Position NVARCHAR(255),
    TypeId UNIQUEIDENTIFIER,
    Capacite NVARCHAR(255),
    Caracteristique NVARCHAR(MAX),
    Puissance NVARCHAR(255),
    PRIMARY KEY (Id),
    FOREIGN KEY (StockageId) REFERENCES Stockage(Id),
    FOREIGN KEY (CouleurId) REFERENCES Couleur(Id),
    FOREIGN KEY (ParticulariteId) REFERENCES Particularite(Content),
    FOREIGN KEY (EtatId) REFERENCES Etat(Id),
    FOREIGN KEY (TypeId) REFERENCES Type(Id)
);


CREATE TABLE Couleur (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Etat (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Marque (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    TypeArticleId UNIQUEIDENTIFIER,
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    FOREIGN KEY (TypeArticleId) REFERENCES TypeArticle(Id),
    PRIMARY KEY (Id)
);

CREATE TABLE Modele (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    MarqueId UNIQUEIDENTIFIER,
    FOREIGN KEY (MarqueId) REFERENCES Marque(Id),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);

CREATE TABLE Particularite (
Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Processeurs (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(MAX),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Stockage (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Name] NVARCHAR(255),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id),
);

CREATE TABLE Type_ (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Content NVARCHAR(255),
    PRIMARY KEY (Id),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);

CREATE TABLE TypeArticle (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name NVARCHAR(255),
    DateCreated DateTime,
    CreatedBy VARCHAR(255),
    DateModified DateTime,
    ModifiedBy VARCHAR(255),
    PRIMARY KEY (Id)
);

