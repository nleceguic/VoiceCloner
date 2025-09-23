CREATE DATABASE VoiceClonerDB;
GO

USE VoiceClonerDB;
GO

-- ========================
-- Tabla de usuarios
-- ========================
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255) NULL,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME()
);
GO

-- ========================
-- Tabla de voces disponibles
-- ========================
CREATE TABLE Voices (
    VoiceId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Provider NVARCHAR(50) NOT NULL DEFAULT 'ElevenLabs',
    ExternalId NVARCHAR(100) NULL,
    Language NVARCHAR(50) NULL,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME()
);
GO

-- ========================
-- Peticiones de generación de voz
-- ========================
CREATE TABLE VoiceRequests (
    RequestId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL,
    VoiceId INT NULL,
    InputText NVARCHAR(MAX) NOT NULL,
    Success BIT NOT NULL,
    Message NVARCHAR(255) NULL,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_VoiceRequests_Users FOREIGN KEY (UserId) 
        REFERENCES Users(UserId) ON DELETE SET NULL ON UPDATE CASCADE,

    CONSTRAINT FK_VoiceRequests_Voices FOREIGN KEY (VoiceId) 
        REFERENCES Voices(VoiceId) ON DELETE SET NULL ON UPDATE CASCADE
);
GO

-- ========================
-- Respuestas con audios generados
-- ========================
CREATE TABLE VoiceResponses (
    ResponseId INT IDENTITY(1,1) PRIMARY KEY,
    RequestId INT NOT NULL,
    AudioBase64 NVARCHAR(MAX) NULL, -- Mejor usar VARBINARY(MAX) si es binario real
    AudioFormat NVARCHAR(10) DEFAULT 'wav', 
    DurationSeconds DECIMAL(5,2) NULL,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_VoiceResponses_Requests FOREIGN KEY (RequestId) 
        REFERENCES VoiceRequests(RequestId) ON DELETE CASCADE
);
GO

-- ========================
-- Índices para mejorar consultas
-- ========================
CREATE INDEX IX_VoiceResponses_RequestId ON VoiceResponses(RequestId);
CREATE INDEX IX_VoiceRequests_CreatedAt ON VoiceRequests(CreatedAt);
CREATE INDEX IX_VoiceRequests_UserId ON VoiceRequests(UserId);
CREATE INDEX IX_VoiceRequests_VoiceId ON VoiceRequests(VoiceId);
GO

-- ========================
-- Datos iniciales
-- ========================
INSERT INTO Users (Username, Email) VALUES ('noah', 'noah@email.com');

INSERT INTO Voices (Name, Provider, ExternalId, Language)
VALUES ('MiVozClonada', 'ElevenLabs', 'voice_12345', 'es-ES');

INSERT INTO VoiceRequests (UserId, VoiceId, InputText, Success, Message)
VALUES (1, 1, 'Hola, estoy probando mi clonador de voz.', 1, 'Generado correctamente');
GO