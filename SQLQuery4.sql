CREATE TABLE StudentInfo (
    Name VARCHAR(50) NOT NULL,
    Age INT,
    Program VARCHAR(50),
    FatherName VARCHAR(50),
    Mobile DECIMAL(10,2)
);

ALTER TABLE StudentInfo
ADD Mobile Numeric(18,0);

INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile)
VALUES ('Nihith',2,'InterMediate','Sasidhar',7323306686);

INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile)
VALUES ('Virat',3,'InterMediate','Bala',7323306686);

INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile)
VALUES ('Chaithra',6,'KinderGarden','Bala',7323306686);

INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile)
VALUES ('Niha',7,'1st Grade','Rama',7323306686);


select * from StudentInfo;