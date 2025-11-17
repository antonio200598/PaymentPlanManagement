 USE kedu
 GO

 CREATE TABLE Client (
 Id BIGINT IDENTITY(1,1) PRIMARY KEY,
 [Name] NVARCHAR(250) NOT NULL
 );

 CREATE TABLE CostsCentral (
 Id BIGINT IDENTITY(1,1) PRIMARY KEY,
 [Name] NVARCHAR(250) NOT NULL,
 Code NVARCHAR(100) NULL
 );

 CREATE TABLE PaymentPlans (
 Id BIGINT IDENTITY(1,1) PRIMARY KEY,
 Client_Id BIGINT NOT NULL,
 CostsCentral_Id BIGINT NULL,
 CostsCentral_enum NVARCHAR(100) NULL,
 created_at datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
 CONSTRAINT fk_Client FOREIGN KEY (Client_id) REFERENCES
 Client(id),
 CONSTRAINT fk_centrocusto FOREIGN KEY (CostsCentral_Id) REFERENCES
 CostsCentral(id)
 );

 CREATE TABLE Charge (
 Id BIGINT IDENTITY(1,1) PRIMARY KEY,
 PaymentPlans_Id BIGINT NOT NULL,
 [Value] DECIMAL(18,2) NOT NULL,
 DueDate DATE NOT NULL,
 PaymentMethod INT NOT NULL,
 [Status] INT NOT NULL,
 PaymentCode NVARCHAR(200) NOT NULL UNIQUE,
 created_at datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
 CONSTRAINT fk_plano FOREIGN KEY (PaymentPlans_Id) REFERENCES
 PaymentPlans(id)
 );

 CREATE INDEX idx_cobrancas_plano ON Charge(PaymentPlans_Id);
 CREATE INDEX idx_planos_responsavel ON PaymentPlans(Client_Id);
