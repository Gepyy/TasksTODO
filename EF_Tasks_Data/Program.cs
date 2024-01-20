using EF_Tasks_Data;
using EF_Tasks_Data.DataModels;

//Create several test for check work of database
CRUD_Task a = new CRUD_Task();
//a.CreateTask("TestNow", "TestNow", DateTime.Now);
//a.ReadTask();
//a.UpdateTask(2, "TestUpdate", "TestUpdate", DateTime.Now);
//a.ReadTask();
//a.DeleteTask(3);
a.ReadTask();
Console.WriteLine("----------------");
a.CheckComplete(1);
a.ReadTask();
Console.ReadKey();