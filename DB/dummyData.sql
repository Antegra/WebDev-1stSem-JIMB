USE Studieservice;
GO

/* Add dummy data into tables */

SET IDENTITY_INSERT role ON;  

INSERT INTO role(role_id,title) VALUES(1,'Admin')
INSERT INTO role(role_id,title) VALUES(2,'Bruger')


SET IDENTITY_INSERT role OFF;

SET IDENTITY_INSERT sex ON;  

INSERT INTO sex(sex_id,name) VALUES(1,'Mand')
INSERT INTO sex(sex_id,name) VALUES(2,'Kvinde')
INSERT INTO sex(sex_id,name) VALUES(3,'Gruppe')
INSERT INTO sex(sex_id,name) VALUES(4,'Andet')

SET IDENTITY_INSERT sex OFF;

SET IDENTITY_INSERT duration ON;  

INSERT INTO duration(duration_id,length) VALUES(1,'1-15 Min')
INSERT INTO duration(duration_id,length) VALUES(2,'15-30 Min')
INSERT INTO duration(duration_id,length) VALUES(3,'30-45 Min')
INSERT INTO duration(duration_id,length) VALUES(4,'45-60 Min')
INSERT INTO duration(duration_id,length) VALUES(5,'over 60 Min')

SET IDENTITY_INSERT duration OFF;

SET IDENTITY_INSERT type ON;  

INSERT INTO type(type_id,type) VALUES(1,'Personlig')
INSERT INTO type(type_id,type) VALUES(2,'Telefon')
INSERT INTO type(type_id,type) VALUES(3,'Virtuel')

SET IDENTITY_INSERT type OFF;

SET IDENTITY_INSERT locations ON;

INSERT INTO locations(location_id,name) VALUES(1,'Odense')
INSERT INTO locations(location_id,name) VALUES(2,'Svendborg')
INSERT INTO locations(location_id,name) VALUES(3,'Jelling')
INSERT INTO locations(location_id,name) VALUES(4,'Vejle')
INSERT INTO locations(location_id,name) VALUES(5,'Fredericia')

SET IDENTITY_INSERT locations OFF;

SET IDENTITY_INSERT subject ON;  

INSERT INTO subject(subject_id,name,description) VALUES(1,'Administrative forhold','Vejledning om at søge dispensation, merit, kompetencevurdering mm.')
INSERT INTO subject(subject_id,name,description) VALUES(2,'Barsel','Barsel')
INSERT INTO subject(subject_id,name,description) VALUES(3,'Eksamen','fx regler, klage, snyd, omprøver, særlige prøvevilkår')
INSERT INTO subject(subject_id,name,description) VALUES(4,'Fastholde trivsel','statussamtaler og opfølgning på studerende mm.')
INSERT INTO subject(subject_id,name,description) VALUES(5,'Internationale muligheder','studieophold og/eller praktik')
INSERT INTO subject(subject_id,name,description) VALUES(6,'Mistrivsel','fx i forhold til studiet, hverdagen')
INSERT INTO subject(subject_id,name,description) VALUES(7,'Optagelsesvejledning','fx indhold, adgangskrav, videreuddannelse, struktur')
INSERT INTO subject(subject_id,name,description) VALUES(8,'Ordensreglement','fx krænkelser, overskridelser af regler')
INSERT INTO subject(subject_id,name,description) VALUES(9,'Orlov','Orlov')
INSERT INTO subject(subject_id,name,description) VALUES(10,'Overflytning/genindskrivning','')
INSERT INTO subject(subject_id,name,description) VALUES(11,'Personlige forhold','')
INSERT INTO subject(subject_id,name,description) VALUES(12,'Praktik i DK/klinik/dialogmøder','')
INSERT INTO subject(subject_id,name,description) VALUES(13,'Ikke studierelevant','')
INSERT INTO subject(subject_id,name,description) VALUES(14,'','')
INSERT INTO subject(subject_id,name,description) VALUES(15,'','')
INSERT INTO subject(subject_id,name,description) VALUES(16,'','')
INSERT INTO subject(subject_id,name,description) VALUES(17,'','')
INSERT INTO subject(subject_id,name,description) VALUES(18,'','')

SET IDENTITY_INSERT subject OFF;

SET IDENTITY_INSERT edu ON;  

INSERT INTO edu(edu_id,name,location_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT edu OFF;

SET IDENTITY_INSERT users ON;  

INSERT INTO users(users_id,firstName,lastName,email,role_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT users OFF;

SET IDENTITY_INSERT cases ON;  

INSERT INTO cases(case_id,month,niveau,nationality,user_id,sex_id,duration_id,type_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT cases OFF;

SET IDENTITY_INSERT edu_user ON;  

INSERT INTO edu_user(edu_id,user_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT edu_user OFF;

SET IDENTITY_INSERT edu_case ON;  

INSERT INTO edu_case(edu_id,case_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT edu_case OFF;

SET IDENTITY_INSERT edu_location ON;  

INSERT INTO edu_location(edu_id,location_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT edu_location OFF;

SET IDENTITY_INSERT subject_case ON;  

INSERT INTO subject_case(subject_id,case_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT subject_case OFF;

SET IDENTITY_INSERT location_case ON;  

INSERT INTO location_case(location_id,case_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT location_case OFF;

SET IDENTITY_INSERT location_user ON;  

INSERT INTO location_user(location_id,user_id) VALUES(1,'Electra')
INSERT INTO production.brands(brand_id,brand_name) VALUES(2,'Haro')
INSERT INTO production.brands(brand_id,brand_name) VALUES(3,'Heller')
INSERT INTO production.brands(brand_id,brand_name) VALUES(4,'Pure Cycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(5,'Ritchey')
INSERT INTO production.brands(brand_id,brand_name) VALUES(6,'Strider')
INSERT INTO production.brands(brand_id,brand_name) VALUES(7,'Sun Bicycles')
INSERT INTO production.brands(brand_id,brand_name) VALUES(8,'Surly')
INSERT INTO production.brands(brand_id,brand_name) VALUES(9,'Trek')

SET IDENTITY_INSERT location_user OFF;