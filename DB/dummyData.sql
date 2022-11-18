USE Studieservice5;
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

INSERT INTO type(type_id,name) VALUES(1,'Personlig')
INSERT INTO type(type_id,name) VALUES(2,'Telefon')
INSERT INTO type(type_id,name) VALUES(3,'Virtuel')

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
INSERT INTO subject(subject_id,name,description) VALUES(10,'Overflytning/genindskrivning','(internt/eksternt)')
INSERT INTO subject(subject_id,name,description) VALUES(11,'Personlige forhold','(fx alvorlige sociale begivenheder, familiære/nære forhold)')
INSERT INTO subject(subject_id,name,description) VALUES(12,'Praktik i DK/klinik/dialogmøder','Spørgsmål om praktik eller lign.')
INSERT INTO subject(subject_id,name,description) VALUES(13,'Ikke studierelevant','Ting der ikke er relevante')
INSERT INTO subject(subject_id,name,description) VALUES(14,'SPS','Spørgsmål om SPS')
INSERT INTO subject(subject_id,name,description) VALUES(15,'Studieophør','Udmeldelse')
INSERT INTO subject(subject_id,name,description) VALUES(16,'Studieplanlægning','individuel studieplan, omlagte forløb. Fx forsinkede studerende og UCL Eliteordning')
INSERT INTO subject(subject_id,name,description) VALUES(17,'Studietvivl / Studievalg','Spørgsmå om studievallg')
INSERT INTO subject(subject_id,name,description) VALUES(18,'Studieudfordringer','faglige, eksamensnervøsitet/-angst, studie- og eksamensteknik, forståelse for studiet, samarbejdsvanskeligheder, manglende gruppe mm.')
INSERT INTO subject(subject_id,name,description) VALUES(19,'Sygdom','egen fysisk eller psykisk sygdom mm.')
INSERT INTO subject(subject_id,name,description) VALUES(20,'Undervisningen','fx samarbejdsvanskeligheder med underviser, kritik af kvaliteten')
INSERT INTO subject(subject_id,name,description) VALUES(21,'Økonomi','fx SU, private forhold')

SET IDENTITY_INSERT subject OFF;

SET IDENTITY_INSERT edu ON;  

INSERT INTO edu(edu_id,name) VALUES(1,'Administrationsbachelor')
INSERT INTO edu(edu_id,name) VALUES(2,'Autoteknolog')
INSERT INTO edu(edu_id,name) VALUES(3,'Automationsteknolog')
INSERT INTO edu(edu_id,name) VALUES(4,'Bygningskonstruktør')
INSERT INTO edu(edu_id,name) VALUES(5,'Bioanalytiker')
INSERT INTO edu(edu_id,name) VALUES(6,'Byggekoordinator')
INSERT INTO edu(edu_id,name) VALUES(7,'Datamatiker')
INSERT INTO edu(edu_id,name) VALUES(8,'Digital konceptudvikling')
INSERT INTO edu(edu_id,name) VALUES(9,'Energiteknolog')
INSERT INTO edu(edu_id,name) VALUES(10,'Ergoterapeut')
INSERT INTO edu(edu_id,name) VALUES(11,'El-installatør')
INSERT INTO edu(edu_id,name) VALUES(12,'E-handel')
INSERT INTO edu(edu_id,name) VALUES(13,'Fysioterapeut')
INSERT INTO edu(edu_id,name) VALUES(14,'Finans')
INSERT INTO edu(edu_id,name) VALUES(15,'Finansøkonom')
INSERT INTO edu(edu_id,name) VALUES(16,'Financial controller')
INSERT INTO edu(edu_id,name) VALUES(17,'Handelsøkonom')
INSERT INTO edu(edu_id,name) VALUES(18,'IT-teknolog')
INSERT INTO edu(edu_id,name) VALUES(19,'IT-sikkerhed')
INSERT INTO edu(edu_id,name) VALUES(20,'Innovation og entrepreneurship')
INSERT INTO edu(edu_id,name) VALUES(21,'International handel og markedsføring')
INSERT INTO edu(edu_id,name) VALUES(22,'International hospitality management')
INSERT INTO edu(edu_id,name) VALUES(23,'Jordbrug')
INSERT INTO edu(edu_id,name) VALUES(24,'Jordbrugsteknolog')
INSERT INTO edu(edu_id,name) VALUES(25,'Lærer')
INSERT INTO edu(edu_id,name) VALUES(26,'Laborant')
INSERT INTO edu(edu_id,name) VALUES(27,'Logistikøkonom')
INSERT INTO edu(edu_id,name) VALUES(28,'Lærer - enkeltfag')
INSERT INTO edu(edu_id,name) VALUES(29,'Lærer med naturfaglig profil')
INSERT INTO edu(edu_id,name) VALUES(30,'Lærer - trainee')
INSERT INTO edu(edu_id,name) VALUES(31,'Markedsføringsøkonom')
INSERT INTO edu(edu_id,name) VALUES(32,'Meritpædagog')
INSERT INTO edu(edu_id,name) VALUES(33,'Meritlærer')
INSERT INTO edu(edu_id,name) VALUES(34,'Multimediedesigner')
INSERT INTO edu(edu_id,name) VALUES(35,'Meritpædagog som sporskifte')
INSERT INTO edu(edu_id,name) VALUES(36,'Pædagog')
INSERT INTO edu(edu_id,name) VALUES(37,'Produktionsteknolog')
INSERT INTO edu(edu_id,name) VALUES(38,'Procesteknolog')
INSERT INTO edu(edu_id,name) VALUES(39,'Pædagog med bevægelsesprofil')
INSERT INTO edu(edu_id,name) VALUES(40,'Produktudvikling og teknisk integration')
INSERT INTO edu(edu_id,name) VALUES(41,'Radiograf')
INSERT INTO edu(edu_id,name) VALUES(42,'Socialrådgiver')
INSERT INTO edu(edu_id,name) VALUES(43,'Serviceøkonom')
INSERT INTO edu(edu_id,name) VALUES(44,'Sygeplejerske')
INSERT INTO edu(edu_id,name) VALUES(45,'Softwareudvikling')
INSERT INTO edu(edu_id,name) VALUES(46,'Sundhedsadministrativ koordinator')
INSERT INTO edu(edu_id,name) VALUES(47,'Sport management')
INSERT INTO edu(edu_id,name) VALUES(48,'Sygeplejerske - merit')
INSERT INTO edu(edu_id,name) VALUES(49,'VVS-installatør')
INSERT INTO edu(edu_id,name) VALUES(50,'Webudvikling')
INSERT INTO edu(edu_id,name) VALUES(51,'Økonomi og IT')

SET IDENTITY_INSERT edu OFF;

SET IDENTITY_INSERT users ON;  

INSERT INTO users(user_id,firstName,lastName,email,role_id,password) VALUES(1,'Hanne','Nielsen','hani@ucl.dk',2,HannePW)
INSERT INTO users(user_id,firstName,lastName,email,role_id,password) VALUES(2,'Lars','Piet','lapi@ucl.dk',2,LarsPW)
INSERT INTO users(user_id,firstName,lastName,email,role_id,password) VALUES(3,'Pierre','Gallet','piga@ucl.dk',1,PierrePW)

SET IDENTITY_INSERT users OFF;

SET IDENTITY_INSERT cases ON;  

INSERT INTO cases(case_id,month,niveau,nationality,user_id,sex_id,duration_id,type_id,primeEdu) VALUES(1,'2022-11-01',1,1,1,2,3,1,1)
INSERT INTO cases(case_id,month,niveau,nationality,user_id,sex_id,duration_id,type_id,primeEdu) VALUES(2,'2022-11-01',1,1,2,1,2,2,1)
INSERT INTO cases(case_id,month,niveau,nationality,user_id,sex_id,duration_id,type_id,primeEdu) VALUES(3,'2022-10-01',1,1,3,3,1,3,1)

SET IDENTITY_INSERT cases OFF; 

INSERT INTO edu_user(edu_id,user_id) VALUES(24,1)
INSERT INTO edu_user(edu_id,user_id) VALUES(25,1)
INSERT INTO edu_user(edu_id,user_id) VALUES(3,1)
INSERT INTO edu_user(edu_id,user_id) VALUES(4,1)
INSERT INTO edu_user(edu_id,user_id) VALUES(44,1)
INSERT INTO edu_user(edu_id,user_id) VALUES(44,2)



INSERT INTO edu_case(edu_id,case_id) VALUES(44,1)
INSERT INTO edu_case(edu_id,case_id) VALUES(48,1)
INSERT INTO edu_case(edu_id,case_id) VALUES(50,3)
INSERT INTO edu_case(edu_id,case_id) VALUES(3,2)




 

INSERT INTO edu_location(edu_id,location_id) VALUES(1,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(2,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(3,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(3,5)
INSERT INTO edu_location(edu_id,location_id) VALUES(4,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(5,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(6,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(7,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(7,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(8,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(9,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(10,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(11,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(11,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(12,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(13,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(14,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(15,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(16,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(17,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(17,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(18,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(19,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(20,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(20,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(21,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(22,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(23,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(24,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(25,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(25,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(26,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(27,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(28,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(28,3)
INSERT INTO edu_location(edu_id,location_id) VALUES(29,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(30,3)
INSERT INTO edu_location(edu_id,location_id) VALUES(30,5)
INSERT INTO edu_location(edu_id,location_id) VALUES(31,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(32,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(32,3)
INSERT INTO edu_location(edu_id,location_id) VALUES(33,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(33,3)
INSERT INTO edu_location(edu_id,location_id) VALUES(34,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(35,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(36,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(36,2)
INSERT INTO edu_location(edu_id,location_id) VALUES(36,3)
INSERT INTO edu_location(edu_id,location_id) VALUES(37,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(38,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(38,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(39,2)
INSERT INTO edu_location(edu_id,location_id) VALUES(40,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(41,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(42,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(42,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(43,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(43,2)
INSERT INTO edu_location(edu_id,location_id) VALUES(43,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(44,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(44,2)
INSERT INTO edu_location(edu_id,location_id) VALUES(44,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(45,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(45,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(46,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(46,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(47,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(48,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(48,2)
INSERT INTO edu_location(edu_id,location_id) VALUES(48,4)
INSERT INTO edu_location(edu_id,location_id) VALUES(49,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(50,1)
INSERT INTO edu_location(edu_id,location_id) VALUES(51,1)




INSERT INTO subject_case(subject_id,case_id) VALUES(10,1)
INSERT INTO subject_case(subject_id,case_id) VALUES(12,1)
INSERT INTO subject_case(subject_id,case_id) VALUES(17,1)
INSERT INTO subject_case(subject_id,case_id) VALUES(17,2)
INSERT INTO subject_case(subject_id,case_id) VALUES(1,2)
INSERT INTO subject_case(subject_id,case_id) VALUES(20,3)

 

INSERT INTO location_case(location_id,case_id) VALUES(1,1)
INSERT INTO location_case(location_id,case_id) VALUES(1,2)
INSERT INTO location_case(location_id,case_id) VALUES(5,2)
INSERT INTO location_case(location_id,case_id) VALUES(1,3)

 

INSERT INTO location_user(location_id,user_id) VALUES(1,1)
INSERT INTO location_user(location_id,user_id) VALUES(1,2)
INSERT INTO location_user(location_id,user_id) VALUES(2,2)
INSERT INTO location_user(location_id,user_id) VALUES(1,3)
INSERT INTO location_user(location_id,user_id) VALUES(2,3)
INSERT INTO location_user(location_id,user_id) VALUES(3,3)
INSERT INTO location_user(location_id,user_id) VALUES(4,3)
INSERT INTO location_user(location_id,user_id) VALUES(5,3)
