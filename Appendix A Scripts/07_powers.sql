USE SuperheroesDb;

INSERT INTO [Power]
VALUES
	('Flight', 'Gives the hero the ability to fly'),
	('Wall-Crawling', 'Gives the hero the ability to crawl up walls and other surfaces'),
	('Spider-Sense', 'Gives the hero a heightened sense of danger, allowing them to react quickly to threats'),
	('Martial Arts', 'The hero masters various martial arts and combat styles');


INSERT INTO Superhero_Power_Link
VALUES
	(1, 1),
	(2, 2),
	(2, 3),
	(3, 1),
	(3, 4);