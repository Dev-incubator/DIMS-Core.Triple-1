﻿CREATE TABLE [dbo].[TaskTrack]
(
	[TaskTrackId] INT IDENTITY(1,1) NOT NULL,
	[UserTaskId] INT NOT NULL,
	[TrackDate] DATE NOT NULL,
	[TrackNote] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_TaskTrack] PRIMARY KEY CLUSTERED([TaskTrackId] ASC)
)