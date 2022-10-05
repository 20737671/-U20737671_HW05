using System;
using Homework_05.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace Homework_05.Models
{
    public class DataServices
    {
        
        private static DataServices instance;
        

        public static DataServices getInstance()
        {
            if (instance == null)
            {
                instance = new DataServices();
            }
            return instance;
        }


        private string connectionString = "Data source=MEMELPC\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=true";



        public List<BooksVM> getAllBooks()
        {
            List<BooksVM> bookWerk = new List<BooksVM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books ", connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int BookID = Convert.ToInt32(rdr["bookId"]);
                            int AuthorID = Convert.ToInt32(rdr["authorId"]);
                            int TypeID = Convert.ToInt32(rdr["typeId"]);
                            

                            BooksVM books = new BooksVM
                            {
                                book = FetchBookById(BookID),
                                author = FetchAuthByID(AuthorID),
                                type = FetchTypeByID(TypeID),
                               

                            };
                            bookWerk.Add(books);
                        }
                    }
                }
                connection.Close();
            }
            return bookWerk;
        }





        public Books FetchBookById(int ID)
        {
            Books book = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("select * from books where bookId = " + ID, connection))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                book = new Books
                                {
                                    BookID = Convert.ToInt32(rdr["bookId"]),
                                    Name = Convert.ToString(rdr["name"]),
                                    Point = Convert.ToInt32(rdr["point"]),
                                    AuthorID = Convert.ToInt32(rdr["authorId"]),
                                    TypeID = Convert.ToInt32(rdr["typeId"]),
                                    Pagecount = Convert.ToInt32(rdr["pagecount"])
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return book;
            }
        }

        public Authors FetchAuthByID(int ID)
        {
            Authors author = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("select * from authors where authorId =" + ID, connection))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                author = new Authors
                                {
                                    

                                    Name = Convert.ToString(rdr["name"]),
                                    
                                    AuthorID = Convert.ToInt32(rdr["authorId"]),
                                   
                                    Surname = Convert.ToString(rdr["surname"])
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return author;
            }
        }

                public Types FetchTypeByID(int ID)
                {
                    Types type = null;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from types where typeId =" + ID, connection))
                            {
                                using (SqlDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                         type = new Types
                                        {

                                            Name = Convert.ToString(rdr["name"]),
                                            TypeID = Convert.ToInt32(rdr["typeId"])

                                        };
                                    }
                                }
                            }
                            connection.Close();
                        }
                        return type;
                    }

                }



        

        public List<BorrowsVM> getAllBorrows(int borID)
        {
            List<BorrowsVM> leen = new List<BorrowsVM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from borrows where bookId = " + borID, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int BorrowID = Convert.ToInt32(rdr["borrowId"]);
                            int StudentID = Convert.ToInt32(rdr["studentId"]);
                            
                            BorrowsVM borrows = new BorrowsVM
                            {
                                borrow = FetchBorrowByID(BorrowID),
                                student = FetchStudentByID(StudentID),
                               
                            };
                            leen.Add(borrows);
                        }
                    }
                }
                connection.Close();
            }
            return leen;
        }

        public Borrows FetchBorrowByID(int ID)
        {
            Borrows borrow = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("select * from borrows where borrowId =" + ID, connection))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                borrow = new Borrows
                                {

                                    BorrowID = Convert.ToInt32(rdr["borrowId"]),
                                    StudentID = Convert.ToInt32(rdr["studentId"]),
                                    BookID = Convert.ToInt32(rdr["bookId"]),
                                    TakenDate = Convert.ToDateTime(rdr["takenDate"]),
                                    BroughtDate = Convert.ToDateTime(rdr["broughtDate"])

                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return borrow;
            }

        }

        public Students FetchStudentByID(int ID)
        {
            Students students = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("select * from students where studentId =" + ID, connection))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                students = new Students
                                {
                                    StudentID = Convert.ToInt32(rdr["studentId"]),
                                    Name = Convert.ToString(rdr["name"]),
                                    Surname = Convert.ToString(rdr["surname"]),
                                    Birthdate = Convert.ToDateTime(rdr["birthdate"]),
                                    Gender = Convert.ToString(rdr["gender"]),
                                    Class = Convert.ToString(rdr["class"]),
                                    Point = Convert.ToInt32(rdr["point"])
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return students;
            }

        }

        public List<Students> getAllStudents()
        {
            List<Students> studente = new List<Students>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from students  ", connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            
                            int StudentID = Convert.ToInt32(rdr["studentId"]);
                            string Name = Convert.ToString(rdr["name"]);
                            string Surname = Convert.ToString(rdr["surname"]);
                            DateTime Birthdate = Convert.ToDateTime(rdr["birthdate"]);
                            string Gender = Convert.ToString(rdr["gender"]);
                            string Class = Convert.ToString(rdr["class"]);
                            int Point = Convert.ToInt32(rdr["point"]);


                            Students students = new Students
                            {
                                StudentID = Convert.ToInt32(rdr["studentId"]),
                                Name = Convert.ToString(rdr["name"]),
                                Surname = Convert.ToString(rdr["surname"]),
                                Birthdate = Convert.ToDateTime(rdr["birthdate"]),
                                Gender = Convert.ToString(rdr["gender"]),
                                Class = Convert.ToString(rdr["class"]),
                                Point = Convert.ToInt32(rdr["point"])

                            };
                            studente.Add(students);
                        }
                    }
                }
                connection.Close();
            }
            return studente;
        }
    }
        }
    

