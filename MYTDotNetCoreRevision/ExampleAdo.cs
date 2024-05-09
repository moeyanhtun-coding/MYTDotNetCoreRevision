using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MYTDotNetCoreRevision
{
    internal class ExampleAdo
    {
        private readonly SqlConnection _connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        public void Run()
        {
            //create("Title2", "Author2", "Content2");
            //read();
            //edit(8);
            //update(1,"Title2", "Author2", "Content2");
            delete(1);
        }
        public void read() 
        {
            _connection.Open();
            string query = "SELECT * FROM Tbl_BlogDotNetCore";
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BlogContent"]);
                Console.WriteLine("________________________________");
            }

        }

        public void edit(int id)
        {
            string query = "select * from Tbl_BlogDotNetCore where BlogId = @BlogId";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            _connection.Close();

            if(dt.Rows is null)
            {
                Console.WriteLine("Data not found");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog Id => " + dr["BlogId"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("________________________________");
        }
        
        public void create(string title, string author, string content)
        {
            string query = @"
INSERT INTO [dbo].[Tbl_BlogDotNetCore]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title); 
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();
            string message = result > 0 ? "Data Create Success" : "Fail";
            Console.WriteLine(message);
        }

        public void update(int id,  string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_BlogDotNetCore]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();

            string message = result > 0 ? "Data Insert Success" : "Error Occur";
            Console.WriteLine(message);
        }

        public void delete(int id)
        {
            string query = @"Delete From Tbl_BLogDotNetCore where BlogId = @BlogId";
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query,_connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();

            string message = result > 0 ? "Delete Success" : "Delete Fail";
            Console.WriteLine(message);
        }

    }
}
