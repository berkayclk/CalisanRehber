INSERT INTO Department (name,location) VALUES ('Bilgi Ýþlem Departmaný','Beþiktaþ / ÝSTANBUL')
INSERT INTO Department (name,location) VALUES ('Satýþ Departmanný','Beyoðlu / ÝSTANBUL')
INSERT INTO Department (name,location) VALUES ('Üretim Departmaný','Avcýlar / ÝSTANBUL')
INSERT INTO Department (name,location) VALUES ('Satýþ Departmaný','Konak / ÝZMÝR')



INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Berkay','Çelik','05379795452',1, null)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Erkut','Yazýcý','05345421325',1,1)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Toygar','Solak','05041236547',1,2)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Berkay','Ergüven','05426987456',1,1)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Serkan','Uzun','05478965412',1,4)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Övünç','Deniz','05879654123',1,2)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Deniz','Karakaya','05231234578',1,4)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Hazal','Erorhan','05421478961',2, null)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Hellin','Avþar','05896325655',2,8)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Sýdýka','Ünver','05395421265',2,8)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Emre','Baþýkara','05065896541',3, null)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Erdem','Mutlu','05068745231',3,11)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Muhammet','Ünal','05047896542',3,11)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Iþýlay','Kadýoðlu','05093214569',4, null)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Nurcan','Karakaþ','05045231263',4,14)
INSERT INTO Employee (name,surname,phoneNumber,departmentID,managerID) VALUES ('Yasin','Aksu','05021235478',4,14)


INSERT INTO Admins (username,password,employeeID) VALUES ('admin','admin',1)
