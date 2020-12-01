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
	}
}