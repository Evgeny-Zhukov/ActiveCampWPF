USE [HikingAppDB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[AddEquipment]
		@equipmentName = N'Testt',
		@equipmentWeight = 1.61

SELECT	@return_value as 'Return Value'

GO
