CREATE TABLE Tuotteet (
	id INTEGER IDENTITY(1,1) PRIMARY KEY,
	tuotenimi TEXT NOT NULL,
	tuotehinta INTEGER NOT NULL,
	saldo INTEGER NOT NULL
);