using System;

namespace StudentAcademicRecordSystem.Models
{
	/// =========================================================
	/// Represents an academic result for one university unit.
	/// =========================================================
	public class AcademicRecord
	{
		public string UnitCode { get; set; }

		public string UnitName { get; set; }

		public double Marks { get; set; }

		public AcademicRecord()
		{
			UnitCode = "";
			UnitName = "";
		}

		/// ======================================
		/// Converts marks into a letter grade.
		/// ======================================
		public string Grade
		{
			get
			{
				if (Marks >= 85)
					return "HD";

				if (Marks >= 75)
					return "D";

				if (Marks >= 65)
					return "C";

				if (Marks >= 50)
					return "P";

				return "F";
			}
		}

		/// =======================================
		/// Converts the grade into a GPA point.
		/// =======================================
		public double GradePoint
		{
			get
			{
				if (Marks >= 85)
					return 4.0;

				if (Marks >= 75)
					return 3.0;

				if (Marks >= 65)
					return 2.0;

				if (Marks >= 50)
					return 1.0;

				return 0.0;
			}
		}
	}
}