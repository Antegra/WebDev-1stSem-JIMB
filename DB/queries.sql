/*
Viser de faktiske værdier for alle cases 

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

*/

/* 
Viser hvilke uddannelser bruger har som faste

SELECT CONCAT(users.firstName, ' ', users.lastName) AS FuldeNavn, locations.name AS Uddannelsested, locations.location_id FROM users
INNER JOIN location_user ON users.user_id = location_user.user_id
INNER JOIN locations ON location_user.location_id = locations.location_id
WHERE users.user_id = 1 */

/* 
viser alle Uddannelser

SELECT edu_id AS Id, name AS Uddannelser FROM edu 

*/

/* 
viser alle emner og deres beskrivelser

SELECT subject_id AS Id, name AS Emne, subject.description AS Beskrivelse FROM subject */

/* 
viser typer af henvendelser

SELECT type_id, type.type FROM type */

/* 
vis køn

SELECT sex_id, sex.name AS Køn FROM sex */

/*
viser samtaletid

 SELECT duration_id,  duration.length AS Samtaletid FROM duration */

/* 
viser uddannelsesteder

SELECT location_id, name AS Uddannelsested FROM locations */

/* 
SELECT  CONCAT(users.firstName, ' ', users.lastName) AS Brugernavn,  edu.name AS Uddannelse  FROM users
INNER JOIN edu_user ON edu_user.user_id = users.user_id
INNER JOIN edu ON edu.edu_id = edu_user.edu_id 
*/



/*
Viser hvilken rolle brugerne

SELECT * FROM users
INNER JOIN role ON users.role_id = role.role_id 

*/

/* Vis hvor bruger befinder sig

SELECT CONCAT(users.firstName, ' ', users.lastName) AS Brugernavn, name AS Uddannelsested, locations.location_id FROM location_user
INNER JOIN users ON users.user_id = location_user.user_id
INNER JOIN locations ON locations.location_id = location_user.location_id

 */
/* 
Fjerner uddannelse fra bruger

DELETE FROM edu_user
WHERE user_id = @userId AND edu_id = @eduId */

/* 
Tilføjer uddannelse til bruger

INSERT INTO edu_user (user_id, edu_id)
VALUES (@userId, @eduId) */


/* 
opdater bruges lokation

UPDATE location_user 
SET location_id = @locationId
WHERE user_id = @usersId

*/

/* 
Opdater bruger password

UPDATE users
SET password = 'HannePW'
WHERE user_id = 1 
*/

/* 
Opret bruger

INSERT INTO users(firstName,lastName,email,role_id) VALUES(@firstName, @lastName, @email, @roleId) */

/* 
Slet bruger

DELETE FROM users
WHERE user_id = @userId
*/


/* 
Slet emne

DELETE FROM subject
WHERE subject_id = @subject_ID
*/

/* 
Lave nyt emne

INSERT INTO subject
VALUES ('Subject_Name', '@Subject_description') 
 */

/* UPDATE subject 
SET name = '@subject_Name', description = '@Subject_description'
WHERE subject_id = @Subject_ID */


/* Slet location

DELETE FROM locations
WHERE location_id = @location_ID
 */

/* Lave nyt location

INSERT INTO locations
VALUES ('@location_Name')  */


/* Slet edu

DELETE FROM edu
WHERE edu_id = 53
*/

/* UPDATE edu 
SET name = '@edu_Name'
WHERE edu_id = @edu_ID
 */

/* Lave nyt edu

INSERT INTO edu
VALUES ('test')  */



