using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proLibManageSys.ViewModels
{
	public class StudentViewModel
	{
		public Students students { get; set; }
		public List<StudentBranchs> studentBranches { get; set; }
	}
}