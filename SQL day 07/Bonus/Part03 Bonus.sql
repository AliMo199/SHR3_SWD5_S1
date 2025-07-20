use ITI

-----------------1
CREATE PROCEDURE dbo.SP_GetMonthNameByDate
    @Date DATE,
    @MonthName VARCHAR(20) OUTPUT
AS
BEGIN
    DECLARE @Result VARCHAR(20)
    SET @Result = DATENAME(MONTH, @Date)
    SET @MonthName = @Result
END

-----------------2
CREATE PROCEDURE dbo.SP_GetNumbersBtwTwoInt
    @StartInt INT,
    @EndInt INT
AS
BEGIN
    DECLARE @Current INT
    CREATE TABLE Result (Value INT)

    IF @StartInt <= @EndInt
    BEGIN
        SET @Current = @StartInt
        WHILE @Current <= @EndInt
        BEGIN
            INSERT INTO Result (Value) VALUES (@Current)
            SET @Current = @Current + 1
        END
    END
    ELSE
    BEGIN
        SET @Current = @StartInt
        WHILE @Current >= @EndInt
        BEGIN
            INSERT INTO Result (Value) VALUES (@Current)
            SET @Current = @Current - 1
        END
    END
    SELECT * FROM Result
END

-----------------3
CREATE PROCEDURE dbo.SP_GetStudentInfoById
    @StudentID INT
AS
BEGIN
    CREATE TABLE Result
    (
        FullName VARCHAR(101),
        DepartmentName VARCHAR(100)
    )

    INSERT INTO Result (FullName, DepartmentName)
    SELECT 
        CONCAT(St_Fname, ' ', St_Lname),
        D.Dept_Name
    FROM Student S
    INNER JOIN Department D ON S.Dept_Id = D.Dept_Id
    WHERE S.St_Id = @StudentID
    SELECT * FROM Result
END

-----------------4
CREATE PROCEDURE dbo.SP_CheckStudentNameStatus
    @StudentID INT,
    @Message VARCHAR(100) OUTPUT
AS
BEGIN
    DECLARE @FirstName VARCHAR(50)
    DECLARE @LastName VARCHAR(50)

    SELECT 
        @FirstName = St_Fname,
        @LastName = St_Lname
    FROM Student
    WHERE St_Id = @StudentID

    IF @FirstName IS NULL AND @LastName IS NULL
        SELECT @Message = 'First name & last name are null'
    ELSE IF @FirstName IS NULL
        SELECT @Message = 'First name is null'
    ELSE IF @LastName IS NULL
        SELECT @Message = 'Last name is null'
    ELSE
        SELECT @Message = 'First name & last name are not null'
END

-----------------5
use MyCompany

CREATE PROCEDURE dbo.SP_GetManagerInfoByHiringDate
    @date INT
AS
BEGIN
    CREATE TABLE Result
    (
        DepartmentName VARCHAR(100),
        ManagerName VARCHAR(101),
        FormattedHireDate VARCHAR(50)
    )

    INSERT INTO Result (DepartmentName, ManagerName, FormattedHireDate)
    SELECT 
        d.Dname,
        CONCAT(M.Fname, ' ', M.Lname),
        CONVERT(VARCHAR(50), d.[MGRStart Date], @date)
    FROM Departments d
    INNER JOIN Employee M ON M.SSN = d.MGRSSN

    SELECT * FROM Result
END

-------------------6
use ITI

CREATE PROCEDURE dbo.SP_GetStudentNameByType
    @NameType VARCHAR(20)
AS
BEGIN
    CREATE TABLE Result
    (
        StudentID INT,
        NameOutput VARCHAR(101)
    )

    IF @NameType = 'first name'
    BEGIN
        INSERT INTO Result (StudentID, NameOutput)
        SELECT 
            St_Id,
            ISNULL(St_Fname, NULL)
        FROM Student
    END
    ELSE IF @NameType = 'last name'
    BEGIN
        INSERT INTO Result (StudentID, NameOutput)
        SELECT 
            St_Id,
            ISNULL(St_Lname, NULL)
        FROM Student
    END
    ELSE IF @NameType = 'full name'
    BEGIN
        INSERT INTO Result (StudentID, NameOutput)
        SELECT 
            St_Id,
            ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '')
        FROM Student
    END

    SELECT * FROM Result
END

 ----------------------7
 use MyCompany

CREATE PROCEDURE dbo.SP_GetEmployeesByProject
    @Pnumber INT
AS
BEGIN
    CREATE TABLE Result
    (
        SSN INT,
        FullName NVARCHAR(101),
        DepartmentName NVARCHAR(50)
    )

    INSERT INTO Result (SSN, FullName, DepartmentName)
    SELECT 
        E.SSN,
        ISNULL(E.Fname, '') + ' ' + ISNULL(E.Lname, ''),
        D.Dname
    FROM Project P
    INNER JOIN Departments D ON P.Dnum = D.Dnum
    INNER JOIN Employee E ON E.Dno = D.Dnum
    WHERE P.Pnumber = @Pnumber

    SELECT * FROM Result
END
