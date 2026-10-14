using System;
using System.Windows.Forms;
using StudentAcademicRecordSystem.Forms;

namespace StudentAcademicRecordSystem
{
	/// ========================================
	/// Main entry point of the application.
	/// ========================================
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			// Initialise Windows Forms.
			ApplicationConfiguration.Initialize();

			// Start the main AcademicHub dashboard.
			Application.Run(new MainForm());
		}
	}
}