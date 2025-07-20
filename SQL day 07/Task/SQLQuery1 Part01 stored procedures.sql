-------------1
use ITI

CREATE PROCEDURE SP_GetStudentCountPerDepartment
AS
BEGIN
    SELECT 
        d.Dept_Name,
        COUNT(s.St_Id) AS StudentCount
    FROM 
        Department d
    LEFT JOIN 
        Student s ON d.Dept_Id = s.Dept_Id
    GROUP BY 
        d.Dept_Name
END

--------------2
use MyCompany

CREATE PROCEDURE SP_CheckEmployeesInProject @ProjectNumber int
AS
BEGIN
    DECLARE @EmpCount int
    SELECT @EmpCount = COUNT(DISTINCT ESSn)
    FROM works_for
    WHERE Pno = @ProjectNumber
    IF @EmpCount >= 3
    BEGIN
        select 'The number of employees in the project is 3 or more'
    END
    ELSE
    BEGIN
        select 'The following employees work for the project'
        select e.Fname, e.Lname
        FROM works_for w
        JOIN Employee e ON w.ESSn = e.SSN
        WHERE w.Pno = @ProjectNumber
    END
END

------------3
use MyCompany

CREATE PROCEDURE SP_ReplaceEmployeeInProject @OldEmpSsn int, @NewEmpSsn int, @ProjectNumber int
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Works_for
        WHERE ESSn = @OldEmpSsn AND Pno = @ProjectNumber
    )
    BEGIN
        DECLARE @Hours int
        SELECT @Hours = Hours
        FROM works_for
        WHERE ESSn = @OldEmpSsn AND Pno = @ProjectNumber
        DELETE FROM works_for
        WHERE ESSn = @OldEmpSsn AND Pno = @ProjectNumber
        INSERT INTO Works_for(ESSn, Pno,Hours)
        VALUES (@NewEmpSsn, @ProjectNumber, @Hours);
        select 'Employee replaced successfully.'
    END
    ELSE
    BEGIN
        select 'Old employee is not assigned to this project.';
    END
END