USE SuperheroesDb;

CREATE TABLE Superhero (
	ID int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	Alias nvarchar(50),
	Origin nvarchar(50)
)

CREATE TABLE Assistant (
	ID int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL
)

CREATE TABLE [Power] (
	ID int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(100)
)