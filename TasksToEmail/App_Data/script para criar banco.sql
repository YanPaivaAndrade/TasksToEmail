CREATE DATABASE BancoDeTarefas
CREATE TABLE Tarefa(
	idTarefa INT NOT NULL IDENTITY(1,1),
	Title       VARCHAR(50),
	Type		VARCHAR(30),
	Status		VARCHAR(30),
	Priority	INT,
	Severity	INT,
	ChangeDate	DATETIME,
	ChangeBy	VARCHAR(50)
);