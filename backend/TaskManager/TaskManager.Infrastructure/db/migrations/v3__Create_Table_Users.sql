CREATE TABLE `Users` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Username` VARCHAR(50) NOT NULL,
    `Email` VARCHAR(100) NOT NULL,
    `PasswordHash` VARCHAR(255) NOT NULL,
    `CreatedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`Id`),
    UNIQUE KEY `UQ_Username` (`Username`),
    UNIQUE KEY `UQ_Email` (`Email`)
);
