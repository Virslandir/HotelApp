/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.RoomTypes)
begin
    insert into dbo.RoomTypes(Title, Description, PricePerNight)
    values ('King Size Bed', 'A room with a king size bed and a window', 100),
    ('Two Queen Size Beds', 'A room with two queen size bed and a balkony', 115),
    ('Executive Suite', 'A suite with twoo rooms with a king size bed and window each', 205);
end

declare @roomTypeId1 int
declare @roomTypeId2 int
declare @roomTypeId3 int

select @roomTypeId1 = Id from dbo.RoomTypes where Title = 'King Size Bed'
select @roomTypeId2 = Id from dbo.RoomTypes where Title = 'Two Queen Size Beds'
select @roomTypeId3 = Id from dbo.RoomTypes where Title = 'Executive Suite'

if not exists (select 1 from dbo.Rooms) 
begin
    insert into dbo.Rooms(RoomNumber, RoomTypeId)
    values ('101', @roomTypeId1),
    ('102', @roomTypeId1),
    ('103', @roomTypeId1),
    ('201', @roomTypeId2),
    ('202', @roomTypeId2),
    ('301', @roomTypeId3);
end
