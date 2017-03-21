declare @startTImeA datetime, @endTimeA datetime
set @startTImeA = '2017-03-23 08:00:00.000'
set @endTimeA = '2017-03-23 09:00:00.000'
SELECT * FROM AspNetUsers
--JOIN BookingModels ON AspNetUsers.Id = BookingModels.ApplicationUserId
--JOIN BookingTimeSlotModels ON BookingModels.BookingTimeSlotModelsId = BookingTimeSlotModels.Id
WHERE AspNetUsers.Id not in (SELECT AspNetUsers.Id FROM AspNetUsers
 JOIN BookingModels ON AspNetUsers.Id = BookingModels.ApplicationUserId
JOIN BookingTimeSlotModels ON BookingModels.BookingTimeSlotModelsId = BookingTimeSlotModels.Id 
WHERE @startTImeA <= endTime AND  startTime <= @endTimeA)


declare @startTImeA datetime, @endTimeA datetime
set @startTImeA = '2017-03-22 08:00:00.000'
set @endTimeA = '2017-03-22 12:00:00.000'
SELECT UserName FROM AspNetUsers
JOIN BookingModels ON AspNetUsers.Id = BookingModels.ApplicationUserId
JOIN BookingTimeSlotModels ON BookingModels.BookingTimeSlotModelsId = BookingTimeSlotModels.Id
WHERE @startTImeA <= endTime AND startTime <= @endTimeA