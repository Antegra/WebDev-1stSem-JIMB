CREATE PROCEDURE sp_get_edu_location
AS
BEGIN
SELECT edu.name AS eduname, locations.name AS locationname
FROM edu_location
INNER JOIN locations ON locations.location_id =  edu_location.location_id
INNER JOIN edu ON edu.edu_id = edu_location.edu_id;
END;
EXEC sp_get_edu_location


ALTER PROCEDURE sp_get_edu_location_by_city
@city VARCHAR(30)
AS
BEGIN
SELECT edu.name AS eduname, locations.name AS locationname
FROM edu_location
INNER JOIN locations ON locations.location_id =  edu_location.location_id
INNER JOIN edu ON edu.edu_id = edu_location.edu_id
WHERE locations.name = @city;
END;

EXEC sp_get_edu_location_by_city @city = 'odense', @city = 'vejle';