
CREATE TABLE Student (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(70),
);

CREATE TABLE Note (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	StudentId INT,
	Subject nvarchar(70),
	Note INT,

	CONSTRAINT FK__NOTE__ID FOREIGN KEY (StudentId) REFERENCES Student(Id),
);


INSERT INTO Student (Name) VALUES
	('Aleksandra Komkova'),
	('Daria Ziziko'), 
	('Daria Astrouskaya');

INSERT INTO Note (StudentId, Subject, Note) VALUES 
	(1, 'OOP', 7),
	(1, 'Internet', 7),
	(1, 'DB', 8),
	(2, 'OOP', 5),
	(2, 'Internet', 7),
	(2, 'Java', 8),
	(3, 'DB', 7),
	(3, 'OOP', 5),
	(3, 'Java', 6);
