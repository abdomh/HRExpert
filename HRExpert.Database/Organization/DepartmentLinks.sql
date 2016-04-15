CREATE TABLe [dbo].[DepartmentLinks]
(
	[LeftId] bigint not null,
	[RightId] bigint not null,
	CONSTRAINT PK_DepartmentLinks PRIMARY KEY (LeftId,RightId),
	CONSTRAINT FK_DepartmentLinks_Left FOREIGN KEY (LeftId) REFERENCES Departments(Id),
	CONSTRAINT FK_DepartmentLinks_Right FOREIGN KEY (RightId) REFERENCES Departments(Id)
)
