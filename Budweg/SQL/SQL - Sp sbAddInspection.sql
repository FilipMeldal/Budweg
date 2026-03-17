USE Budweg
GO

GO 
CREATE PROCEDURE  sbAddInspection @DateOfCreation datetime2, @Inspector Nvarchar(30), @Milestone float, @MilestoneReached bit
AS
BEGIN 
INSERT INTO INSPECTION (DateOfCreation, Inspector, Milestone, MilestoneReached)
VALUES (@DateOfCreation, @Inspector, @Milestone, @MilestoneReached)
END;