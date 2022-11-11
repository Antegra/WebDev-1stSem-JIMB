
CREATE DATABASE Studieservice5;
GO

USE Studieservice5;
GO

-- create tables
CREATE TABLE role (
	role_id INT IDENTITY (1, 1) PRIMARY KEY,
	title VARCHAR (50) NOT NULL
);
GO

CREATE TABLE sex (
	sex_id INT IDENTITY (1, 1) PRIMARY KEY,
	name VARCHAR (50) NOT NULL
);
GO

CREATE TABLE duration (
	duration_id INT IDENTITY (1, 1) PRIMARY KEY,
	length VARCHAR (50) NOT NULL
);
GO

CREATE TABLE type (
	type_id INT IDENTITY (1, 1) PRIMARY KEY,
	type VARCHAR (50) NOT NULL
);
GO

CREATE TABLE locations (
	location_id INT IDENTITY (1, 1) PRIMARY KEY,
	name VARCHAR (50) NOT NULL
);
GO

CREATE TABLE subject (
	subject_id INT IDENTITY (1, 1) PRIMARY KEY,
	name VARCHAR (50) NOT NULL,
    description VARCHAR (300) NOT NULL
);
GO

CREATE TABLE edu (
	edu_id INT IDENTITY (1, 1) PRIMARY KEY,
	name VARCHAR (50) NOT NULL,
);
GO

CREATE TABLE users (
	user_id INT IDENTITY (1, 1) PRIMARY KEY,
	firstName VARCHAR (50) NOT NULL,
    lastName VARCHAR (50) NOT NULL,
    email VARCHAR (100) NOT NULL,
	role_id INT,
    FOREIGN KEY (role_id) REFERENCES role (role_id)
);
GO

CREATE TABLE cases (
	case_id INT IDENTITY (1, 1) PRIMARY KEY,
	month DATE NOT NULL,
    niveau BIT NOT NULL,
	nationality BIT NOT NULL,
	user_id INT,
	sex_id INT,
	duration_id INT,
	type_id INT,
	primeEdu BIT,
	FOREIGN KEY (user_id) REFERENCES users (user_id),
    FOREIGN KEY (sex_id) REFERENCES sex (sex_id),
    FOREIGN KEY (duration_id) REFERENCES duration (duration_id),
    FOREIGN KEY (type_id) REFERENCES type (type_id)
);
GO

CREATE TABLE edu_user (
	edu_id INT,
    user_id INT,
	PRIMARY KEY (edu_id, user_id),
    FOREIGN KEY (edu_id) REFERENCES edu (edu_id),
    FOREIGN KEY (user_id) REFERENCES users (user_id)
);
GO

CREATE TABLE edu_case (
	edu_id INT,
    case_id INT,
	PRIMARY KEY (edu_id, case_id),
    FOREIGN KEY (edu_id) REFERENCES edu (edu_id),
    FOREIGN KEY (case_id) REFERENCES cases (case_id)
);
GO

CREATE TABLE edu_location (
	edu_id INT,
    location_id INT,
	PRIMARY KEY (edu_id, location_id),
    FOREIGN KEY (edu_id) REFERENCES edu (edu_id),
    FOREIGN KEY (location_id) REFERENCES locations (location_id)
);
GO

CREATE TABLE subject_case (
	subject_id INT,
    case_id INT,
	PRIMARY KEY (subject_id, case_id),
    FOREIGN KEY (subject_id) REFERENCES subject (subject_id),
    FOREIGN KEY (case_id) REFERENCES cases (case_id)
);
GO

CREATE TABLE location_case (
	location_id INT,
    case_id INT,
	PRIMARY KEY (location_id, case_id),
    FOREIGN KEY (location_id) REFERENCES locations (location_id),
    FOREIGN KEY (case_id) REFERENCES cases (case_id)
);
GO

CREATE TABLE location_user (
	location_id INT,
    user_id INT,
	PRIMARY KEY (location_id, user_id),
    FOREIGN KEY (location_id) REFERENCES locations (location_id),
    FOREIGN KEY (user_id) REFERENCES users (user_id)
);
GO

