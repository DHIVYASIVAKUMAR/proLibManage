using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proLibManageSys.Data
{
	public class DummyData
	{
		public static List<Books> GetBooks()
		{
			List<Books> book = new List<Books>()
			{
				new Books(){
					bookName = "Harry Potter",
					authorName= "J.K Rowling",
					serialNumber= "1001",
					branch= "Stories",
					publications= "Bloomsbury",
					isAvailable = false
				},
				new Books(){
					bookName = "HTML & CSS",
					authorName= "John",
					serialNumber= "1002",
					branch= "Web Development",
					publications= "John Wiley",
					isAvailable = true
				},
				new Books(){
					bookName = "Introduction to algorithm",
					authorName= "TCRC",
					serialNumber= "1003",
					branch= "Algorithms",
					publications= "MIT Press",
					isAvailable = true
				}
			};

			return book;
		}

		public static List<Students> GetStudentDetails()
		{
			List<Students> student = new List<Students>()
			{
				new Students(){ 
					studentName = "Dhivya",
					studentBranch = "CSE",
					gender = "Female", 
					phoneNumber = "9988776655",
					address = "123,new street",
					city = "chennai",
					email = "abcdef@gmail.com",
					password  = "abcdef"
				},
				new Students(){
					studentName = "Mike",
					studentBranch = "IT",
					gender = "Male", 
					phoneNumber = "9888765432",
					address = "456,old street",
					city = "chennai",
					email = "ghijkl@gmail.com",
					password  = "ghijkl"
				}
			};

			return student;
		}
		public static List<IssuedBooks> GetIssuedBooks()
		{
			List<IssuedBooks> issuedBook = new List<IssuedBooks>()
			{
				new IssuedBooks(){
					issuedBookName ="Harry Potter",
					issuedAuthorName ="J.K Rowling",
					issuedBookBranch ="Stories",
					issuedBookPublications ="Bloomsbury",
					issuedStudentName ="Dhivya",
					issuedStudentEmail  ="abcdef@gmail.com", 
					fromDate="01-11-2020",
					toDate="15-11-2020"
				}
			};

			return issuedBook;
		}
	}
}