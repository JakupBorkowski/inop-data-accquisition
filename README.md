# USB-205_DataAccquisition
Windows Forms App (.NET Framework 4.7.2) created to present data from USB-205 device (https://www.google.com/url?sa=t&amp;rct=j&amp;q=&amp;esrc=s&amp;source=web&amp;cd=&amp;cad=rja&amp;uact=8&amp;ved=2ahUKEwigx7PsqtX5AhURmYsKHZGYBGAQqa4BegQIIBAA&amp;url=https%3A%2F%2Fwww.mccdaq.com%2Fusb-data-acquisition%2FUSB-205.aspx&amp;usg=AOvVaw1wgRFa2z7AQVojUguIAJ4Y) on chart and log data to csv file
![image](https://user-images.githubusercontent.com/50780955/185744473-546e3ca8-ed0b-41e3-ac39-86cc0bcd818b.png)


20.08.2022 [19:28] UPDATE
Added btnSave, which allows to save data to csv file by pressing it
![image](https://user-images.githubusercontent.com/50780955/185759271-11bce41f-513f-445f-af34-4e96cb5de59e.png)

22.08.2022 [18:07] UPDATE
Created database in MySQL consisting of 6 tables to present device and data given/sent by it (picture below). Made DbDevice.cs, Device.cs, DbSample.cs, Sample.cs classes to handle CRUD request to database, using MySQL.Data NuGet.
![image](https://user-images.githubusercontent.com/50780955/185967694-1756e2cb-c865-43b9-bf92-b7622ebea376.png)

23.08.2022 [14:30] UPDATE
Added labels to show actual reads from 2 channles and button, which allows user to start logging samples to database.

![image](https://user-images.githubusercontent.com/50780955/186158409-fa7a84cc-c06d-4bee-ab73-e8e3b29e815c.png)
