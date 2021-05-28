CREATE TABLE IF NOT EXISTS accounts(
id VARCHAR(255) NOT NULL primary key COMMENT 'primary key';
name VARCHAR(255) COMMENT 'Username';
email VARCHAR(255) COMMENT 'email';
picture VARCHAR(255) COMMENT 'Profile Picture';
)default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key';
  CreatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account';
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created';
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Last Updated';
  name VARCHAR(255) COMMENT 'Title';
  description VARCHAR(255) COMMENT 'Description';
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE

)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key';
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created';
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Last Updated';
CreatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account';
name VARCHAR(255) COMMENT 'Title';
description VARCHAR(255) COMMENT 'Description';
picture VARCHAR(255) COMMENT 'Image';
views INT COMMENT 'Views';
shares INT COMMENT 'Shares';
keeps INT COMMENT 'Keeps';
FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE

)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaultkeeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key';
  CreatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account';
   FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
)
