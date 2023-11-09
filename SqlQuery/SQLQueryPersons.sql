CREATE OR REPLACE FUNCTION FindPersons()
RETURNS TABLE (
    Id int,
    FirstName varchar(50),
    LastName varchar(50),
    IdentificationNumber varchar(50),
    Email varchar(50),
    IdentificationType varchar(50),
    CreatedDate TIMESTAMP,
    IdentificationAndType varchar(53),
    FullName varchar(100),
    UserId int
)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY SELECT *
    FROM Persons;
END;
$$;

SELECT * FROM FindPersons();