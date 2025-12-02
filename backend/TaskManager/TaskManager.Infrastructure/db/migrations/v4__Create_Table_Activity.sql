CREATE TABLE `Activity` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(500) NOT NULL,
  `UserId` INT NOT NULL,
  `ProjectId` INT NOT NULL,
  `Status` INT Default 0,
  `Timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  FOREIGN KEY (`UserId`) REFERENCES `User`(`Id`),
  FOREIGN KEY (`ProjectId`) REFERENCES `Project`(`Id`)
);
