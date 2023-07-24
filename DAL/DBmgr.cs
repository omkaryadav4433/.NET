using BOL;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace DAL

{
    public class DBmgr
    {
        public static string costring = @"server=localhost;port=3306;user=root;password=root123;database=yadav";
        public static List<student> getallstudents()
        {
            List<student> std = new List<student>();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = costring;
            try { conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string query = "select * from student";
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    /* private string id;
                     private string name;
                     private int age;
                     public DateOnly bdate;
                     public string course;
                     private double fees;*/

                    string id = reader["id"].ToString();
                    string name = reader["name"].ToString();
                    int age = int.Parse(reader["age"].ToString());
                    string course = reader["course"].ToString();
                    double fees = double.Parse(reader["fees"].ToString());
                    DateOnly bdate = DateOnly.Parse(reader["bDate"].ToString().Substring(0, 10));

                    student student = new student
                    {
                        Id = id,
                        Name = name,
                        Age = age,
                        bdate = bdate,
                        Course = course,
                        Fees = fees,
                    };

                    std.Add(student);
                }
                
            }
        catch(Exception exception)
        {

            Console.WriteLine(exception.Message);

        }
        finally{conn.Close();}

    return std;
        }
}

}