using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademicRecordSystem.Models
{
	/// =================================================
	/// Represents a student and their academic records.
	/// =================================================
	public class Student
	{
		public int StudentId { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public DateTime DateOfBirth { get; set; }

		// Stores all academic records belonging to the student.
		public List<AcademicRecord> AcademicRecords { get; set; }

		// Encapsulation:
		// GPA can be read publicly but is modified internally.
		public double GPA { get; private set; }

		public Student()
		{
			Name = "";
			Email = "";
			AcademicRecords = new List<AcademicRecord>();
		}

		/// ===============================
		/// Calculates the student's GPA.
		/// ===============================
		public void CalculateGPA()
		{
			if (AcademicRecords.Count == 0)
			{
				GPA = 0;
				return;
			}

			double totalGradePoints =
				AcademicRecords.Sum(
					record => record.GradePoint);

			GPA =
				totalGradePoints /
				AcademicRecords.Count;
		}

		/// ==========================================
		/// Determines the student's academic status.
		/// ==========================================
		public string GetStatus()
		{
			if (GPA >= 3.5)
				return "Good";

			if (GPA >= 2.0)
				return "Satisfactory";

			return "At Risk";
		}
	}
}