using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using MYTDotNetCoreRevision.AdoDotNet;
using System.Data.Common;

namespace MYTDotNetCoreRevision.Dapper
{
    internal class DapperExample
    {
        private readonly IDbConnection _db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        public void Run()
        {
            //create("Title2", "Author2", "Content2");
            //edit(2);
            //update(12,"TitleUpdate", "AuthorUpdate", "ContentUpdate");
            delete(12);
            Read();
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_BlogDotNetCore";
            List<BlogDto> lst = _db.Query<BlogDto>(query).ToList();
            foreach (BlogDto blog in lst)
            {
                Console.WriteLine("Blog Id => " + blog.BlogId);
                Console.WriteLine("Blog Title => " + blog.BlogTitle);
                Console.WriteLine("Blog Author => " + blog.BlogAuthor);
                Console.WriteLine("Blog Content => " + blog.BlogContent);
                Console.WriteLine("________________________________");
            }
        }

        public void edit(int id)
        {
            string query = "select * from Tbl_BlogDotNetCore where BlogId = @BlogId";
            var item = _db.Query(query, new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("Data Not Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void create(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"
INSERT INTO [dbo].[Tbl_BlogDotNetCore]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            int result = _db.Execute(query, blog);
            string message = result > 0 ? "Create Blog Success" : "Create Blog Fail";
            Console.WriteLine(message); 
        }

        public void update(int id, string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_BlogDotNetCore]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            int result = _db.Execute(query,blog);
            string message = result > 0 ? "Data Insert Success" : "Error Occur";
            Console.WriteLine(message);
        }

        public void delete(int id)
        {
            string query = @"Delete From Tbl_BLogDotNetCore where BlogId = @BlogId";
           int result = _db.Execute(query,new BlogDto { BlogId = id });
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            Console.WriteLine(message);
        }

    }
}
