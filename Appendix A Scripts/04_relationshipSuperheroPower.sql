USE SuperheroesDb;

CREATE TABLE Superhero_Power_Link (
	SuperheroID int,
	PowerID int,
	
	PRIMARY KEY (SuperheroID, PowerID)
)

ALTER TABLE Superhero_Power_Link 
	ADD CONSTRAINT FK_SuperheroPowerLink_Superhero FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID)

ALTER TABLE Superhero_Power_Link 
	ADD CONSTRAINT FK_SuperheroPowerLink_Power FOREIGN KEY (PowerID) REFERENCES [Power](ID)