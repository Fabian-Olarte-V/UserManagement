CREATE TABLE Users(
  Id serial PRIMARY KEY,
  Username varchar(50) NOT NULL,
  Pass varchar(50) NOT NULL,
  CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Persons(
  Id serial PRIMARY KEY,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  IdentificationNumber varchar(50) NOT NULL,
  Email varchar(50) NOT NULL,
  IdentificationType varchar(50),
  CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  IdentificationAndType varchar(53) GENERATED ALWAYS AS (IdentificationNumber || ' ' || IdentificationType) STORED,
  FullName varchar(100) GENERATED ALWAYS AS (FirstName || ' ' || LastName) STORED,
  UserId int,
  CONSTRAINT fk_person_user FOREIGN KEY (UserId) REFERENCES Users(Id)
);