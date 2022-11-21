
/* Viser de faktiske værdier for alle cases  
CREATE PROCEDURE GetAllDataCases
AS
SELECT cases.case_id, month, CONCAT(users.firstName, ' ', users.lastName) AS Vejleder, duration.length, type.name, sex.name AS Køn, edu.name AS Uddannelse, locations.name AS Uddannelsested, subject.name AS Emne FROM cases
INNER JOIN users ON cases.user_id = users.user_id
INNER JOIN duration ON cases.duration_id = duration.duration_id
INNER JOIN sex ON cases.sex_id = sex.sex_id
INNER JOIN type ON cases.type_id = type.type_id
INNER JOIN subject_case ON cases.case_id = subject_case.case_id
INNER JOIN subject ON subject_case.subject_id = subject.subject_id
INNER JOIN location_case ON location_case.case_id = cases.case_id
INNER JOIN locations ON locations.location_id = location_case.location_id
INNER JOIN edu_case ON cases.case_id = edu_case.case_id
INNER JOIN edu ON edu_case.edu_id = edu.edu_id
GO

EXEC GetAllDataCases
*/

 
/* Viser hvilke uddannelser bruger har som faste 
CREATE PROCEDURE GetUser @User_ID INT
AS
SELECT CONCAT(users.firstName, ' ', users.lastName) AS FuldeNavn, locations.name AS Uddannelsested, locations.location_id, users.user_id FROM users
INNER JOIN location_user ON users.user_id = location_user.user_id
INNER JOIN locations ON location_user.location_id = locations.location_id
WHERE users.user_id = @User_ID 
GO

EXEC GetUser @User_ID = 2
*/

/* 
viser alle Uddannelser
CREATE PROCEDURE GetEdus 
AS
SELECT edu_id AS Id, name AS Uddannelser FROM edu 
GO

EXEC GetEdus
*/


/* 
viser alle emner og deres beskrivelser
CREATE PROCEDURE GetSubjects
AS
SELECT subject_id AS Id, name AS Emne, subject.description AS Beskrivelse FROM subject 
GO

EXEC GetSubjects
*/

/* 
viser typer af henvendelser
CREATE PROCEDURE GetTypes
AS
SELECT type_id, type.name FROM type 
GO

EXEC GetTypes
*/


/* 
vis køn 
CREATE PROCEDURE GetSex
AS
SELECT sex_id, sex.name AS Køn FROM sex 
GO

EXEC GetSex
*/


/*
viser samtaletid 

SELECT duration_id,  duration.length AS Samtaletid FROM duration 
GO

EXEC GetDuration
*/

/* 
viser uddannelsesteder
CREATE PROCEDURE GetLocation
AS
SELECT location_id, name AS Uddannelsested FROM locations 
GO 

EXEC GetLocation
*/


/* 

CREATE PROCEDURE GetUsersEdu
AS
SELECT  CONCAT(users.firstName, ' ', users.lastName) AS Brugernavn,  edu.name AS Uddannelse  FROM users
INNER JOIN edu_user ON edu_user.user_id = users.user_id
INNER JOIN edu ON edu.edu_id = edu_user.edu_id 
GO

EXEC GetUsersEdu

*/

/*
Viser hvilken rolle brugerne

SELECT * FROM users
INNER JOIN role ON users.role_id = role.role_id 
GO

EXEC GetUsers
*/


/* Vis hvor bruger befinder sig 
CREATE PROCEDURE GetUsersLocation
AS
SELECT CONCAT(users.firstName, ' ', users.lastName) AS Brugernavn, name AS Uddannelsested, locations.location_id FROM location_user
INNER JOIN users ON users.user_id = location_user.user_id
INNER JOIN locations ON locations.location_id = location_user.location_id
GO

EXEC GetUsersLocation
*/


/* 
Fjerner uddannelse fra bruger
CREATE PROCEDURE RemoveEduFromUser @userId int, @eduID int
AS
DELETE FROM edu_user
WHERE user_id = @userId AND edu_id = @eduId 
GO

EXEC RemoveEduFromUser @userId = @userID, @eduID = @eduID
*/

/* 
Tilføjer uddannelse til bruger

CREATE PROCEDURE AddEduTOUser @userId int, @eduID int
AS
INSERT INTO edu_user (user_id, edu_id)
VALUES (@userId, @eduId) 
GO

EXEC AddEduTOUser @userId = @userID, @eduID = @eduID
*/

/* 
opdater bruges lokation
CREATE PROCEDURE UpdateUserLocation @userId int, @locationId int
AS
UPDATE location_user 
SET location_id = @locationId
WHERE user_id = @userId
GO

EXEC UpdateUserLocation @userId = @userId, @locationId = @locationId
*/

/* 
Opdater bruger password
CREATE PROCEDURE UpdataUserPassword @userId int, @password VARCHAR(50)
AS
UPDATE users
SET password = @password
WHERE user_id = @userId

EXEC UpdataUserPassword @userId = @userId, @password = @password
*/

/* 
Opret bruger
CREATE PROCEDURE CreateUser @firstname VARCHAR(50), @lastname VARCHAR(50), @email VARCHAR(50), @password VARCHAR(50), @roleId int
AS
INSERT INTO users(firstName,lastName,email, password, role_id) VALUES(@firstName, @lastName, @email, @password, @roleId) 
GO 

EXEC CreateUser @firstname = "jacob", @lastname = "welander", @email = "test@gmail.com", @password = "123test", @roleId = 2
*/

/* 
Slet bruger
CREATE PROCEDURE DeleteUser @userId int
AS
DELETE FROM users
WHERE user_id = @userId
GO

EXEC DeleteUser @userId = @userId
*/

/* 
Slet emne
CREATE PROCEDURE DeleteSubject @subjectId int
AS
DELETE FROM subject
WHERE subject_id = @subjectId
GO

EXEC DeleteSubject @subjectId = @subjectId
*/

/* 
Lave nyt emne 
CREATE PROCEDURE CreateSubject @subjectName VARCHAR(50), @SubjectDescription VARCHAR(255)
AS
INSERT INTO subject
VALUES (@subjectName, @SubjectDescription) 
GO

EXEC CreateSubject @subjectName = "test", @SubjectDescription = "test 2"
*/

/* SELECT * FROM subject */


/* CREATE PROCEDURE UpdateSubject @subjectId int, @subjectName VARCHAR(50), @SubjectDescription VARCHAR(255)
AS
UPDATE subject
SET name = @subjectName, description = @SubjectDescription
WHERE subject_id = @subjectId 
GO

EXEC UpdateSubject @subjectId = 24, @subjectName = @subjectName, @SubjectDescription = @SubjectDescription  */


/* SELECT * FROM locations */

/* Slet location 
CREATE PROCEDURE DeleteLocation @locationId int
AS
DELETE FROM locations
WHERE location_id = @locationId
GO

EXEC DeleteLocation @locationId = 7
*/

/* Lave nyt location 
CREATE PROCEDURE CreateLocation @locationName VARCHAR(255)
AS
INSERT INTO locations
VALUES (@locationName) 
GO

EXEC CreateLocation @locationName = "test"
*/

/* Slet edu 
CREATE PROCEDURE DeleteEdu @eduId int
AS
DELETE FROM edu
WHERE edu_id = @eduId
GO

EXEC DeleteEdu @eduId = 57  */


/* CREATE PROCEDURE UpdateEdu @eduId int, @eduName VARCHAR(255)
AS
UPDATE edu 
SET name = @eduName
WHERE edu_id = @eduId
GO

EXEC UpdateEdu @eduId = 56, @eduName = eduName  */

/* Lave nyt edu 
CREATE PROCEDURE CreateEdu @eduName VARCHAR(255)
AS
INSERT INTO edu
VALUES (@eduName)  
GO

EXEC CreateEdu @eduName = 'test'
*/
