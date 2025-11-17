CREATE TABLE Client (
    Id BIGSERIAL PRIMARY KEY,
    Name VARCHAR(250) NOT NULL
);

CREATE TABLE CostsCentral (
    Id BIGSERIAL PRIMARY KEY,
    Name VARCHAR(250) NOT NULL,
    Code VARCHAR(100)
);

CREATE TABLE PaymentPlans (
    Id BIGSERIAL PRIMARY KEY,
    Client_id BIGINT NOT NULL,
    Costscentral_id BIGINT,
    Costscentral_enum VARCHAR(100),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_client
        FOREIGN KEY (Client_id) REFERENCES Client(id),

    CONSTRAINT fk_centrocusto
        FOREIGN KEY (Costscentral_id) REFERENCES Costscentral(id)
);

CREATE TABLE Charge (
    Id BIGSERIAL PRIMARY KEY,
    Paymentplans_Id BIGINT NOT NULL,
    Value NUMERIC(18,2) NOT NULL,
    Duedate DATE NOT NULL,
    Paymentmethod INT NOT NULL,
    Status INT NOT NULL,
    Paymentcode VARCHAR(200) NOT NULL UNIQUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_plano
        FOREIGN KEY (PaymentPlans_Id) REFERENCES PaymentPlans(id)
);

CREATE INDEX idx_cobrancas_plano ON Charge(Paymentplans_Id);
CREATE INDEX idx_planos_responsavel ON PaymentPlans(Client_Id);
