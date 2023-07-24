
using DAL;
using BOL;


List<student> student = DBmgr.getallstudents();

foreach(student stud in student)
{
    Console.WriteLine(stud.Name+" "+stud.bdate);
}




