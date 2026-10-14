// ============================================================
// AcademicHub - Student Academic Record Management System
// MainForm.cs
// ============================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using StudentAcademicRecordSystem.Models;

namespace StudentAcademicRecordSystem.Forms
{
	public class MainForm : Form
	{
		// ============================================================
		// DATA
		// ============================================================

		private readonly List<Student> students =
			new List<Student>();

		private Panel mainContent;

		private Label totalStudentsLabel;
		private Label totalRecordsLabel;
		private Label averageGpaLabel;
		private Label atRiskLabel;

		// ============================================================
		// COLOURS
		// ============================================================

		private readonly Color SidebarColor =
			Color.FromArgb(15, 23, 42);

		private readonly Color PageBackground =
			Color.FromArgb(246, 248, 252);

		private readonly Color PrimaryBlue =
			Color.FromArgb(59, 130, 246);

		private readonly Color Green =
			Color.FromArgb(16, 185, 129);

		private readonly Color Purple =
			Color.FromArgb(139, 92, 246);

		private readonly Color Orange =
			Color.FromArgb(249, 115, 22);

		private readonly Color WarningOrange =
			Color.FromArgb(245, 158, 11);

		private readonly Color Red =
			Color.FromArgb(239, 68, 68);

		private readonly Color MainText =
			Color.FromArgb(15, 23, 42);

		private readonly Color SecondaryText =
			Color.FromArgb(100, 116, 139);

		// ============================================================
		// CONSTRUCTOR
		// Creates the main form, configures the interface, and loads
		// the initial student data used by the application.
		// ============================================================

		public MainForm()
		{
			CreateSampleData();

			ConfigureWindow();

			BuildInterface();

			// Refresh the dashboard after the student data changes.
			UpdateStatistics();
		}

		// ============================================================
		// WINDOW
		// ============================================================

		private void ConfigureWindow()
		{
			Text =
				"AcademicHub - Student Academic Record Management System";

			StartPosition =
				FormStartPosition.CenterScreen;

			ClientSize =
				new Size(1180, 720);

			MinimumSize =
				new Size(1180, 720);

			MaximumSize =
				new Size(1180, 720);

			BackColor =
				PageBackground;

			FormBorderStyle =
				FormBorderStyle.FixedSingle;

			MaximizeBox = false;

			Font =
				new Font(
					"Segoe UI",
					9);
		}

		// ============================================================
		// BUILD INTERFACE
		// ============================================================

		private void BuildInterface()
		{
			BuildSidebar();

			BuildMainContent();
		}

		// ============================================================
		// SIDEBAR
		// ============================================================

		private void BuildSidebar()
		{
			Panel sidebar =
				new Panel
				{
					Left = 0,
					Top = 0,
					Width = 235,
					Height = 720,
					BackColor = SidebarColor
				};

			Controls.Add(sidebar);

			Panel logo =
				new Panel
				{
					Left = 25,
					Top = 28,
					Width = 48,
					Height = 48,
					BackColor = PrimaryBlue
				};

			sidebar.Controls.Add(logo);

			Label logoText =
				new Label
				{
					Text = "A",
					Dock = DockStyle.Fill,
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							24,
							FontStyle.Bold),
					TextAlign =
						ContentAlignment.MiddleCenter
				};

			logo.Controls.Add(logoText);

			Label brand =
				new Label
				{
					Text = "AcademicHub",
					Left = 87,
					Top = 25,
					Width = 135,
					Height = 30,
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							15,
							FontStyle.Bold)
				};

			sidebar.Controls.Add(brand);

			Label brandSubtitle =
				new Label
				{
					Text = "STUDENT MANAGEMENT",
					Left = 89,
					Top = 54,
					Width = 135,
					Height = 18,
					ForeColor =
						Color.FromArgb(
							148,
							163,
							184),
					Font =
						new Font(
							"Segoe UI",
							7,
							FontStyle.Bold)
				};

			sidebar.Controls.Add(brandSubtitle);

			Label navigation =
				new Label
				{
					Text = "MAIN MENU",
					Left = 25,
					Top = 115,
					Width = 150,
					Height = 20,
					ForeColor =
						Color.FromArgb(
							100,
							116,
							139),
					Font =
						new Font(
							"Segoe UI",
							8,
							FontStyle.Bold)
				};

			sidebar.Controls.Add(navigation);

			CreateSideButton(
				sidebar,
				"Dashboard",
				"01",
				145,
				true,
				Dashboard_Click);

			CreateSideButton(
				sidebar,
				"Add Student",
				"02",
				198,
				false,
				AddStudent_Click);

			CreateSideButton(
				sidebar,
				"View Students",
				"03",
				251,
				false,
				ViewStudents_Click);

			CreateSideButton(
				sidebar,
				"Search Student",
				"04",
				304,
				false,
				SearchStudent_Click);

			CreateSideButton(
				sidebar,
				"GPA Calculator",
				"05",
				357,
				false,
				CalculateGpa_Click);

			Panel navigationSeparator =
				new Panel
				{
					Left = 25,
					Top = 430,
					Width = 185,
					Height = 1,
					BackColor =
						Color.FromArgb(
							51,
							65,
							85)
				};

			sidebar.Controls.Add(
				navigationSeparator);

			CreateSideButton(
				sidebar,
				"Exit",
				"X",
				455,
				false,
				Exit_Click);

			Label version =
				new Label
				{
					Text =
						"C#  •  .NET 8  •  WinForms",
					Left = 25,
					Top = 660,
					Width = 190,
					Height = 20,
					ForeColor =
						Color.FromArgb(
							71,
							85,
							105),
					Font =
						new Font(
							"Segoe UI",
							8)
				};

			sidebar.Controls.Add(version);
		}

		// ============================================================
		// SIDEBAR BUTTON
		// ============================================================

		private void CreateSideButton(
			Panel parent,
			string title,
			string number,
			int top,
			bool active,
			EventHandler action)
		{
			Panel button =
				new Panel
				{
					Left = 16,
					Top = top,
					Width = 203,
					Height = 43,
					BackColor =
						active
							? Color.FromArgb(
								37,
								99,
								235)
							: SidebarColor,
					Cursor = Cursors.Hand
				};

			parent.Controls.Add(button);

			Label numberLabel =
				new Label
				{
					Text = number,
					Left = 14,
					Top = 11,
					Width = 30,
					Height = 20,
					ForeColor =
						active
							? Color.White
							: Color.FromArgb(
								100,
								116,
								139),
					Font =
						new Font(
							"Segoe UI",
							8,
							FontStyle.Bold)
				};

			button.Controls.Add(numberLabel);

			Label titleLabel =
				new Label
				{
					Text = title,
					Left = 50,
					Top = 10,
					Width = 140,
					Height = 22,
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							9,
							FontStyle.Bold)
				};

			button.Controls.Add(titleLabel);

			button.Click += action;
			numberLabel.Click += action;
			titleLabel.Click += action;

			button.MouseEnter +=
				(s, e) =>
				{
					if (!active)
					{
						button.BackColor =
							Color.FromArgb(
								30,
								41,
								59);
					}
				};

			button.MouseLeave +=
				(s, e) =>
				{
					if (!active)
					{
						button.BackColor =
							SidebarColor;
					}
				};
		}

		// ============================================================
		// MAIN CONTENT
		// ============================================================

		private void BuildMainContent()
		{
			mainContent =
				new Panel
				{
					Left = 235,
					Top = 0,
					Width = 945,
					Height = 720,
					BackColor =
						PageBackground
				};

			Controls.Add(mainContent);

			CreateDashboard();
		}

		// ============================================================
		// DASHBOARD
		// Displays the main AcademicHub dashboard and navigation cards.
		// ============================================================

		private void CreateDashboard()
		{
			mainContent.Controls.Clear();

			Label smallTitle =
				new Label
				{
					Text = "OVERVIEW",
					Left = 35,
					Top = 25,
					Width = 200,
					Height = 18,
					ForeColor = PrimaryBlue,
					Font =
						new Font(
							"Segoe UI",
							8,
							FontStyle.Bold)
				};

			mainContent.Controls.Add(smallTitle);

			Label title =
				new Label
				{
					Text =
						"Student Academic Record",
					Left = 35,
					Top = 45,
					Width = 600,
					Height = 45,
					ForeColor = MainText,
					Font =
						new Font(
							"Segoe UI",
							24,
							FontStyle.Bold)
				};

			mainContent.Controls.Add(title);

			Label description =
				new Label
				{
					Text =
						"A simple workspace for managing students, results and GPA.",
					Left = 38,
					Top = 89,
					Width = 600,
					Height = 25,
					ForeColor = SecondaryText,
					Font =
						new Font(
							"Segoe UI",
							9)
				};

			mainContent.Controls.Add(description);

			CreateMetricCard(
				"Students",
				"0",
				"TOTAL",
				PrimaryBlue,
				35,
				135,
				out totalStudentsLabel);

			CreateMetricCard(
				"Records",
				"0",
				"UNITS",
				Green,
				250,
				135,
				out totalRecordsLabel);

			CreateMetricCard(
				"Average GPA",
				"0.00",
				"GPA",
				Purple,
				465,
				135,
				out averageGpaLabel);

			CreateMetricCard(
				"At Risk",
				"0",
				"ALERT",
				Red,
				680,
				135,
				out atRiskLabel);

			Label actionTitle =
				new Label
				{
					Text = "Quick Actions",
					Left = 35,
					Top = 270,
					Width = 400,
					Height = 32,
					ForeColor = MainText,
					Font =
						new Font(
							"Segoe UI",
							16,
							FontStyle.Bold)
				};

			mainContent.Controls.Add(actionTitle);

			Label actionSubtitle =
				new Label
				{
					Text =
						"Choose what you would like to do.",
					Left = 37,
					Top = 299,
					Width = 400,
					Height = 22,
					ForeColor = SecondaryText,
					Font =
						new Font(
							"Segoe UI",
							9)
				};

			mainContent.Controls.Add(actionSubtitle);

			CreateActionCard(
				"Add Student",
				"Register a new student",
				"ADD",
				"+",
				PrimaryBlue,
				35,
				335,
				AddStudent_Click);

			CreateActionCard(
				"View Students",
				"Browse all records",
				"VIEW",
				"≡",
				Green,
				250,
				335,
				ViewStudents_Click);

			CreateActionCard(
				"Search Student",
				"Find a student by ID",
				"SEARCH",
				"⌕",
				Orange,
				465,
				335,
				SearchStudent_Click);

			CreateActionCard(
				"Calculate GPA",
				"Check academic performance",
				"GPA",
				"★",
				Purple,
				680,
				335,
				CalculateGpa_Click);

			Panel welcome =
				CreateRoundedPanel(
					35,
					535,
					820,
					110,
					Color.FromArgb(
						30,
						64,
						175));

			mainContent.Controls.Add(welcome);

			Label welcomeSmall =
				new Label
				{
					Text = "ACADEMICHUB",
					Left = 25,
					Top = 17,
					Width = 150,
					Height = 20,
					ForeColor =
						Color.FromArgb(
							191,
							219,
							254),
					Font =
						new Font(
							"Segoe UI",
							8,
							FontStyle.Bold)
				};

			welcome.Controls.Add(welcomeSmall);

			Label welcomeTitle =
				new Label
				{
					Text =
						"Learn. Record. Succeed.",
					Left = 25,
					Top = 39,
					Width = 430,
					Height = 35,
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							18,
							FontStyle.Bold)
				};

			welcome.Controls.Add(welcomeTitle);

			Label welcomeText =
				new Label
				{
					Text =
						"Keep academic information organised and easy to access.",
					Left = 475,
					Top = 35,
					Width = 310,
					Height = 40,
					ForeColor =
						Color.FromArgb(
							219,
							234,
							254),
					Font =
						new Font(
							"Segoe UI",
							9)
				};

			welcome.Controls.Add(welcomeText);
		}

		// ============================================================
		// METRIC CARD
		// ============================================================

		private void CreateMetricCard(
			string title,
			string value,
			string small,
			Color accent,
			int left,
			int top,
			out Label valueLabel)
		{
			Panel card =
				CreateRoundedPanel(
					left,
					top,
					195,
					110,
					Color.White);

			mainContent.Controls.Add(card);

			Panel accentLine =
				new Panel
				{
					Left = 0,
					Top = 0,
					Width = 5,
					Height = 110,
					BackColor = accent
				};

			card.Controls.Add(accentLine);

			Label smallLabel =
				new Label
				{
					Text = small,
					Left = 20,
					Top = 16,
					Width = 150,
					Height = 18,
					ForeColor = SecondaryText,
					Font =
						new Font(
							"Segoe UI",
							7,
							FontStyle.Bold)
				};

			card.Controls.Add(smallLabel);

			Label titleLabel =
				new Label
				{
					Text = title,
					Left = 20,
					Top = 34,
					Width = 155,
					Height = 22,
					ForeColor = MainText,
					Font =
						new Font(
							"Segoe UI",
							9,
							FontStyle.Bold)
				};

			card.Controls.Add(titleLabel);

			valueLabel =
				new Label
				{
					Text = value,
					Left = 20,
					Top = 57,
					Width = 155,
					Height = 40,
					ForeColor = accent,
					Font =
						new Font(
							"Segoe UI",
							20,
							FontStyle.Bold)
				};

			card.Controls.Add(valueLabel);
		}

		// ============================================================
		// ACTION CARD
		// ============================================================

		private void CreateActionCard(
			string title,
			string description,
			string tag,
			string icon,
			Color accent,
			int left,
			int top,
			EventHandler action)
		{
			Panel card =
				CreateRoundedPanel(
					left,
					top,
					195,
					175,
					Color.White);

			mainContent.Controls.Add(card);

			Panel iconPanel =
				new Panel
				{
					Left = 20,
					Top = 20,
					Width = 48,
					Height = 48,
					BackColor = accent
				};

			card.Controls.Add(iconPanel);

			Label iconLabel =
				new Label
				{
					Text = icon,
					Dock = DockStyle.Fill,
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							19,
							FontStyle.Bold),
					TextAlign =
						ContentAlignment.MiddleCenter
				};

			iconPanel.Controls.Add(iconLabel);

			Label tagLabel =
				new Label
				{
					Text = tag,
					Left = 82,
					Top = 27,
					Width = 85,
					Height = 20,
					ForeColor = accent,
					Font =
						new Font(
							"Segoe UI",
							7,
							FontStyle.Bold),
					TextAlign =
						ContentAlignment.MiddleRight
				};

			card.Controls.Add(tagLabel);

			Label titleLabel =
				new Label
				{
					Text = title,
					Left = 20,
					Top = 82,
					Width = 165,
					Height = 25,
					ForeColor = MainText,
					Font =
						new Font(
							"Segoe UI",
							10,
							FontStyle.Bold)
				};

			card.Controls.Add(titleLabel);

			Label descriptionLabel =
				new Label
				{
					Text = description,
					Left = 20,
					Top = 108,
					Width = 165,
					Height = 30,
					ForeColor = SecondaryText,
					Font =
						new Font(
							"Segoe UI",
							8)
				};

			card.Controls.Add(descriptionLabel);

			RoundButton button =
				new RoundButton
				{
					Text = "OPEN",
					Left = 20,
					Top = 142,
					Width = 155,
					Height = 27,
					ButtonColor = accent,
					HoverColor =
						ControlPaint.Dark(
							accent,
							0.10f),
					ForeColor = Color.White,
					Font =
						new Font(
							"Segoe UI",
							7,
							FontStyle.Bold)
				};

			button.Click += action;

			card.Controls.Add(button);
		}

		// ============================================================
		// ROUNDED PANEL
		// ============================================================

		private Panel CreateRoundedPanel(
			int left,
			int top,
			int width,
			int height,
			Color color)
		{
			Panel panel =
				new Panel
				{
					Left = left,
					Top = top,
					Width = width,
					Height = height,
					BackColor = color
				};

			panel.Paint +=
				(sender, e) =>
				{
					e.Graphics.SmoothingMode =
						SmoothingMode.AntiAlias;

					using (
						GraphicsPath path =
							CreateRoundedPath(
								new Rectangle(
									0,
									0,
									panel.Width - 1,
									panel.Height - 1),
								14))
					{
						using (
							Pen pen =
								new Pen(
									Color.FromArgb(
										226,
										232,
										240)))
						{
							e.Graphics.DrawPath(
								pen,
								path);
						}
					}
				};

			return panel;
		}

		private GraphicsPath CreateRoundedPath(
			Rectangle rectangle,
			int radius)
		{
			GraphicsPath path =
				new GraphicsPath();

			int diameter =
				radius * 2;

			path.AddArc(
				rectangle.X,
				rectangle.Y,
				diameter,
				diameter,
				180,
				90);

			path.AddArc(
				rectangle.Right - diameter,
				rectangle.Y,
				diameter,
				diameter,
				270,
				90);

			path.AddArc(
				rectangle.Right - diameter,
				rectangle.Bottom - diameter,
				diameter,
				diameter,
				0,
				90);

			path.AddArc(
				rectangle.X,
				rectangle.Bottom - diameter,
				diameter,
				diameter,
				90,
				90);

			path.CloseFigure();

			return path;
		}

		// ============================================================
		// STATISTICS
		// Updates dashboard statistics such as student count and
		// average GPA using LINQ.
		// ============================================================

		private void UpdateStatistics()
		{
			if (totalStudentsLabel == null)
				return;

			totalStudentsLabel.Text =
				students.Count.ToString();

			totalRecordsLabel.Text =
				students.Sum(
					s =>
						s.AcademicRecords.Count)
				.ToString();

			averageGpaLabel.Text =
				students.Count == 0
					? "0.00"
					: students.Average(
						s => s.GPA)
					.ToString("0.00");

			atRiskLabel.Text =
				students.Count(
					s =>
						s.GetStatus() ==
						"At Risk")
				.ToString();
		}

		// ============================================================
		// ADD STUDENT
		// Collects user input, validates the values, creates a Student
		// object, and adds the record to the student collection.
		// ============================================================

		private void AddStudent_Click(
			object sender,
			EventArgs e)
		{
			using (Form form =
				   new Form())
			{
				form.Text =
					"AcademicHub | Add Student";

				form.StartPosition =
					FormStartPosition.CenterParent;

				form.ClientSize =
					new Size(
						620,
						585);

				form.BackColor =
					PageBackground;

				form.FormBorderStyle =
					FormBorderStyle.FixedDialog;

				form.MaximizeBox = false;

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 620,
						Height = 115,
						BackColor =
							Color.FromArgb(
								30,
								64,
								175)
					};

				form.Controls.Add(header);

				Label headerTitle =
					new Label
					{
						Text =
							"Add New Student",

						Left = 30,
						Top = 20,

						Width = 550,
						Height = 38,

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								20,
								FontStyle.Bold)
					};

				header.Controls.Add(headerTitle);

				Label headerText =
					new Label
					{
						Text =
							"Create a student profile and add an academic result.",

						Left = 32,
						Top = 65,

						Width = 550,
						Height = 25,

						ForeColor =
							Color.FromArgb(
								219,
								234,
								254),

						Font =
							new Font(
								"Segoe UI",
								9)
					};

				header.Controls.Add(headerText);

				AddFormLabel(
					form,
					"Student ID",
					45,
					145);

				TextBox id =
					AddFormTextBox(
						form,
						190,
						140);

				AddFormLabel(
					form,
					"Full Name",
					45,
					195);

				TextBox name =
					AddFormTextBox(
						form,
						190,
						190);

				AddFormLabel(
					form,
					"Email",
					45,
					245);

				TextBox email =
					AddFormTextBox(
						form,
						190,
						240);

				AddFormLabel(
					form,
					"Date of Birth",
					45,
					295);

				DateTimePicker dob =
					new DateTimePicker
					{
						Left = 190,
						Top = 290,
						Width = 320,
						Height = 30,

						Font =
							new Font(
								"Segoe UI",
								9),

						Format =
							DateTimePickerFormat.Short
					};

				form.Controls.Add(dob);

				Label academic =
					new Label
					{
						Text =
							"ACADEMIC RESULT",

						Left = 45,
						Top = 340,

						Width = 250,
						Height = 22,

						ForeColor =
							PrimaryBlue,

						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				form.Controls.Add(academic);

				AddFormLabel(
					form,
					"Unit Code",
					45,
					375);

				TextBox unitCode =
					AddFormTextBox(
						form,
						190,
						370);

				AddFormLabel(
					form,
					"Unit Name",
					45,
					425);

				TextBox unitName =
					AddFormTextBox(
						form,
						190,
						420);

				AddFormLabel(
					form,
					"Marks",
					45,
					475);

				TextBox marks =
					AddFormTextBox(
						form,
						190,
						470);

				RoundButton cancel =
					new RoundButton
					{
						Text = "CANCEL",

						Left = 325,
						Top = 520,

						Width = 90,
						Height = 36,

						ButtonColor =
							Color.FromArgb(
								226,
								232,
								240),

						HoverColor =
							Color.FromArgb(
								203,
								213,
								225),

						ForeColor =
							Color.FromArgb(
								30,
								41,
								59),

						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				cancel.Click +=
					(s, args) =>
						form.Close();

				form.Controls.Add(cancel);

				RoundButton save =
					new RoundButton
					{
						Text =
							"SAVE STUDENT",

						Left = 425,
						Top = 520,

						Width = 125,
						Height = 36,

						ButtonColor =
							PrimaryBlue,

						HoverColor =
							Color.FromArgb(
								37,
								99,
								235),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				save.Click +=
					(s, args) =>
						SaveStudent(
							form,
							id,
							name,
							email,
							dob,
							unitCode,
							unitName,
							marks);

				form.Controls.Add(save);

				form.ShowDialog(this);
			}

			UpdateStatistics();
		}

		// ============================================================
		// SAVE STUDENT
		// ============================================================

		private void SaveStudent(
			Form form,
			TextBox id,
			TextBox name,
			TextBox email,
			DateTimePicker dob,
			TextBox unitCode,
			TextBox unitName,
			TextBox marks)
		{
			int studentId;

			double markValue;

			if (!int.TryParse(
				id.Text,
				out studentId))
			{
				ShowValidationMessage(
					"Please enter a valid Student ID.");

				return;
			}

			if (string.IsNullOrWhiteSpace(
				name.Text))
			{
				ShowValidationMessage(
					"Please enter the student's name.");

				return;
			}

			if (string.IsNullOrWhiteSpace(
				email.Text) ||
				!email.Text.Contains("@"))
			{
				ShowValidationMessage(
					"Please enter a valid email address.");

				return;
			}

			if (string.IsNullOrWhiteSpace(
				unitCode.Text))
			{
				ShowValidationMessage(
					"Please enter the unit code.");

				return;
			}

			if (string.IsNullOrWhiteSpace(
				unitName.Text))
			{
				ShowValidationMessage(
					"Please enter the unit name.");

				return;
			}

			if (!double.TryParse(
				marks.Text,
				out markValue))
			{
				ShowValidationMessage(
					"Please enter valid marks.");

				return;
			}

			if (markValue < 0 ||
				markValue > 100)
			{
				ShowValidationMessage(
					"Marks must be between 0 and 100.");

				return;
			}

			if (students.Any(
				s =>
					s.StudentId ==
					studentId))
			{
				ShowValidationMessage(
					"This Student ID already exists.");

				return;
			}

			Student student =
				new Student
				{
					StudentId =
						studentId,

					Name =
						name.Text.Trim(),

					Email =
						email.Text.Trim(),

					DateOfBirth =
						dob.Value
				};

			AcademicRecord record =
				new AcademicRecord
				{
					UnitCode =
						unitCode.Text.Trim(),

					UnitName =
						unitName.Text.Trim(),

					Marks =
						markValue
				};

			student.AcademicRecords.Add(
				record);

			student.CalculateGPA();

			// Add the validated student object to the in-memory collection.
			students.Add(student);

			UpdateStatistics();

			ShowMessage(
				"Student: " +
				student.Name +
				"\n\n" +

				"GPA: " +
				student.GPA.ToString("0.00") +
				"\n\n" +

				"Grade: " +
				record.Grade,

				"Student Added");

			form.Close();
		}

		// ============================================================
		// VIEW STUDENTS
		// Opens the Student Records window and displays the current
		// collection of students in a DataGridView.
		// ============================================================

		private void ViewStudents_Click(
			object sender,
			EventArgs e)
		{
			using (Form form =
				   new Form())
			{
				form.Text =
					"AcademicHub | Student Records";

				form.StartPosition =
					FormStartPosition.CenterParent;

				form.ClientSize =
					new Size(
						900,
						520);

				form.BackColor =
					PageBackground;

				form.FormBorderStyle =
					FormBorderStyle.FixedDialog;

				form.MaximizeBox = false;

				// ====================================================
				// MODERN HEADER
				// ====================================================

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 900,
						Height = 125,
						BackColor =
							Color.FromArgb(
								37,
								70,
								180)
					};

				form.Controls.Add(header);

				Label title =
					new Label
					{
						// Page title for the Student Records screen.
						Text =
							"Student Records",

						Left = 32,
						Top = 25,

						Width = 700,
						Height = 38,

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								21,
								FontStyle.Bold),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(title);

				Label subtitle =
					new Label
					{
						Text =
							"Review students, GPA and academic status.",

						Left = 34,
						Top = 66,

						Width = 700,
						Height = 25,

						ForeColor =
							Color.FromArgb(
								225,
								235,
								255),

						Font =
							new Font(
								"Segoe UI",
								10,
								FontStyle.Regular),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(subtitle);

				// ====================================================
				// STUDENT TABLE CARD
				// ====================================================

				Panel tableCard =
					new Panel
					{
						Left = 25,
						Top = 140,
						Width = 850,
						Height = 310,
						BackColor = Color.White,
						BorderStyle =
							BorderStyle.FixedSingle
					};

				form.Controls.Add(tableCard);

				Label tableTitle =
					new Label
					{
						Text =
							"ALL STUDENTS",

						Left = 18,
						Top = 12,

						Width = 300,
						Height = 24,

						ForeColor =
							Color.FromArgb(
								31,
								41,
								55),

						Font =
							new Font(
								"Segoe UI",
								9,
								FontStyle.Bold),

						AutoSize = false
					};

				tableCard.Controls.Add(tableTitle);

				Label tableSubtitle =
					new Label
					{
						Text =
							"Student academic records and current GPA status",

						Left = 18,
						Top = 35,

						Width = 600,
						Height = 20,

						ForeColor =
							Color.FromArgb(
								107,
								114,
								128),

						Font =
							new Font(
								"Segoe UI",
								8),

						AutoSize = false
					};

				tableCard.Controls.Add(tableSubtitle);

				DataGridView grid =
					new DataGridView
					{
						Left = 15,
						Top = 62,
						Width = 818,
						Height = 230,

						ReadOnly = true,

						AllowUserToAddRows =
							false,

						AllowUserToDeleteRows =
							false,

						SelectionMode =
							DataGridViewSelectionMode
							.FullRowSelect,

						MultiSelect = false,

						AutoSizeColumnsMode =
							DataGridViewAutoSizeColumnsMode
							.Fill,

						RowHeadersVisible = false,

						BackgroundColor =
							Color.White,

						BorderStyle =
							BorderStyle.None,

						CellBorderStyle =
							DataGridViewCellBorderStyle
							.SingleHorizontal,

						GridColor =
							Color.FromArgb(
								229,
								231,
								235)
					};

				grid.EnableHeadersVisualStyles =
					false;

				grid.ColumnHeadersDefaultCellStyle
					.BackColor =
					Color.FromArgb(
						37,
						70,
						180);

				grid.ColumnHeadersDefaultCellStyle
					.ForeColor =
					Color.White;

				grid.ColumnHeadersDefaultCellStyle
					.Font =
					new Font(
						"Segoe UI",
						8,
						FontStyle.Bold);

				grid.ColumnHeadersDefaultCellStyle
					.Alignment =
					DataGridViewContentAlignment
					.MiddleLeft;

				grid.ColumnHeadersHeight = 32;

				grid.DefaultCellStyle =
					new DataGridViewCellStyle
					{
						Font =
							new Font(
								"Segoe UI",
								8),

						ForeColor =
							Color.FromArgb(
								31,
								41,
								55),

						BackColor =
							Color.White,

						SelectionBackColor =
							Color.FromArgb(
								219,
								234,
								254),

						SelectionForeColor =
							Color.FromArgb(
								30,
								64,
								175),

						Padding =
							new Padding(
								5,
								0,
								5,
								0)
					};

				grid.Columns.Add(
					"StudentId",
					"STUDENT ID");

				grid.Columns.Add(
					"Name",
					"NAME");

				grid.Columns.Add(
					"Email",
					"EMAIL");

				grid.Columns.Add(
					"GPA",
					"GPA");

				grid.Columns.Add(
					"Status",
					"STATUS");

				foreach (
					Student student
					in students)
				{
					grid.Rows.Add(
						student.StudentId,
						student.Name,
						student.Email,
						student.GPA
							.ToString("0.00"),
						student.GetStatus());
				}

				tableCard.Controls.Add(grid);

				// ====================================================
				// DELETE BUTTON
				// ====================================================

				RoundButton delete =
					new RoundButton
					{
						Text =
							"DELETE SELECTED",

						Left = 350,
						Top = 465,

						Width = 200,
						Height = 35,

						ButtonColor = Red,

						HoverColor =
							Color.FromArgb(
								220,
								38,
								38),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								7,
								FontStyle.Bold)
					};

				delete.Click +=
					(s, args) =>
						DeleteStudent(grid);

				form.Controls.Add(delete);

				form.ShowDialog(this);
			}

			UpdateStatistics();
		}

		// ============================================================
		// DELETE STUDENT
		// Removes the selected student after the user confirms the action.
		// ============================================================

		private void DeleteStudent(
			DataGridView grid)
		{
			if (grid.SelectedRows.Count == 0)
			{
				ShowValidationMessage(
					"Please select a student first.",
					"Select a Student");

				return;
			}

			int id =
				Convert.ToInt32(
					grid.SelectedRows[0]
						.Cells[0]
						.Value);

			Student student =
				students.FirstOrDefault(
					s =>
						s.StudentId == id);

			if (student == null)
				return;

			DialogResult result =
				MessageBox.Show(
					"Delete " +
					student.Name +
					"?",
					"Confirm Delete",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

			if (result ==
				DialogResult.Yes)
			{
				// Remove the selected student from the collection.
				students.Remove(student);

				grid.Rows.Remove(
					grid.SelectedRows[0]);

				UpdateStatistics();
			}
		}

		// ============================================================
		// SEARCH STUDENT
		// Opens the search interface used to locate a student by ID.
		// ============================================================

		private void SearchStudent_Click(
			object sender,
			EventArgs e)
		{
			using (Form form =
				   new Form())
			{
				form.Text =
					"AcademicHub | Search Student";

				form.StartPosition =
					FormStartPosition.CenterParent;

				form.ClientSize =
					new Size(
						650,
						430);

				form.BackColor =
					PageBackground;

				form.FormBorderStyle =
					FormBorderStyle.FixedDialog;

				form.MaximizeBox = false;

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 650,
						Height = 125,
						BackColor =
							Color.FromArgb(
								194,
								65,
								12)
					};

				form.Controls.Add(header);

				Label title =
					new Label
					{
						// Page title for the Search Student screen.
						Text =
							"Search Student",

						Left = 32,
						Top = 25,

						Width = 700,
						Height = 38,

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								21,
								FontStyle.Bold),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(title);

				Label subtitle =
					new Label
					{
						Text =
							"Enter a Student ID to find academic information.",

						Left = 34,
						Top = 66,

						Width = 700,
						Height = 25,

						ForeColor =
							Color.FromArgb(
								255,
								237,
								213),

						Font =
							new Font(
								"Segoe UI",
								10,
								FontStyle.Regular),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(subtitle);

				AddFormLabel(
					form,
					"Student ID",
					40,
					160);

				TextBox id =
					AddFormTextBox(
						form,
						170,
						155);

				RoundButton search =
					new RoundButton
					{
						Text = "SEARCH",

						Left = 490,
						Top = 155,

						Width = 105,
						Height = 34,

						ButtonColor = Orange,

						HoverColor =
							Color.FromArgb(
								234,
								88,
								12),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								7,
								FontStyle.Bold)
					};

				form.Controls.Add(search);

				Label result =
					new Label
					{
						Text =
							"Search results will appear here.",

						Left = 40,
						Top = 215,

						Width = 555,
						Height = 190,

						BackColor =
							Color.White,

						ForeColor = MainText,

						BorderStyle =
							BorderStyle.FixedSingle,

						Padding =
							new Padding(15),

						Font =
							new Font(
								"Segoe UI",
								9),

						AutoSize = false
					};

				form.Controls.Add(result);

				search.Click +=
					(s, args) =>
						SearchStudentRecord(
							id,
							result);

				form.ShowDialog(this);
			}
		}

		// ============================================================
		// SEARCH LOGIC
		// Uses LINQ to locate a student and displays the academic details.
		// ============================================================

		private void SearchStudentRecord(
			TextBox idBox,
			Label result)
		{
			int id;

			if (!int.TryParse(
				idBox.Text,
				out id))
			{
				ShowValidationMessage(
					"Please enter a valid Student ID.",
					"Invalid Student ID");

				return;
			}

			Student student =
				students.FirstOrDefault(
					s =>
						s.StudentId == id);

			if (student == null)
			{
				ShowValidationMessage(
					"No student was found with ID " +
					id +
					".",
					"Student Not Found");

				return;
			}

			string records = "";

			foreach (
				AcademicRecord record
				in student.AcademicRecords)
			{
				records +=
					record.UnitCode +
					"  •  " +
					record.UnitName +
					"  •  " +
					record.Marks
						.ToString("0") +
					"  •  " +
					record.Grade +
					Environment.NewLine;
			}

			result.Text =
				"STUDENT PROFILE" +
				Environment.NewLine +
				Environment.NewLine +
				"Student ID: " +
				student.StudentId +
				Environment.NewLine +
				"Name: " +
				student.Name +
				Environment.NewLine +
				"Email: " +
				student.Email +
				Environment.NewLine +
				"GPA: " +
				student.GPA
					.ToString("0.00") +
				Environment.NewLine +
				"Status: " +
				student.GetStatus() +
				Environment.NewLine +
				Environment.NewLine +
				"ACADEMIC RECORDS" +
				Environment.NewLine +
				records;
		}

		// ============================================================
		// GPA CALCULATOR
		// Opens the GPA calculation interface and allows the user to
		// calculate the GPA and academic classification for a student.
		// ============================================================

		private void CalculateGpa_Click(
			object sender,
			EventArgs e)
		{
			using (Form form =
				   new Form())
			{
				form.Text =
					"AcademicHub | GPA Calculator";

				form.StartPosition =
					FormStartPosition.CenterParent;

				form.ClientSize =
					new Size(
						650,
						500);

				form.BackColor =
					PageBackground;

				form.FormBorderStyle =
					FormBorderStyle.FixedDialog;

				form.MaximizeBox = false;

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 650,
						Height = 125,
						BackColor =
							Color.FromArgb(
								109,
								40,
								217)
					};

				form.Controls.Add(header);

				Label title =
					new Label
					{
						// Page title for the GPA Calculator screen.
						Text =
							"GPA Calculator",

						Left = 32,
						Top = 25,

						Width = 700,
						Height = 38,

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								21,
								FontStyle.Bold),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(title);

				Label subtitle =
					new Label
					{
						Text =
							"Calculate GPA and view academic classification.",

						Left = 34,
						Top = 66,

						Width = 700,
						Height = 25,

						ForeColor =
							Color.FromArgb(
								237,
								233,
								254),

						Font =
							new Font(
								"Segoe UI",
								10,
								FontStyle.Regular),

						AutoSize = false,

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				header.Controls.Add(subtitle);

				AddFormLabel(
					form,
					"Student ID",
					40,
					160);

				TextBox id =
					AddFormTextBox(
						form,
						170,
						155);

				id.Text = "1000";

				RoundButton calculate =
					new RoundButton
					{
						Text =
							"CALCULATE",

						Left = 490,
						Top = 155,

						Width = 105,
						Height = 34,

						ButtonColor = Purple,

						HoverColor =
							Color.FromArgb(
								124,
								58,
								237),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								7,
								FontStyle.Bold)
					};

				form.Controls.Add(calculate);

				Label result =
					new Label
					{
						Text =
							"GPA results will appear here.",

						Left = 40,
						Top = 215,

						Width = 555,
						Height = 190,

						BackColor =
							Color.White,

						ForeColor = MainText,

						BorderStyle =
							BorderStyle.FixedSingle,

						Padding =
							new Padding(22),

						Font =
							new Font(
								"Segoe UI",
								11,
								FontStyle.Bold),

						AutoSize = false
					};

				form.Controls.Add(result);

				calculate.Click +=
					(s, args) =>
						CalculateStudentGpa(
							id,
							result);

				form.ShowDialog(this);
			}
		}

		// ============================================================
		// GPA CALCULATION
		// Calculates the GPA from the student's academic records and
		// determines the corresponding academic status.
		// ============================================================

		private void CalculateStudentGpa(
			TextBox idBox,
			Label result)
		{
			int id;

			if (!int.TryParse(
				idBox.Text,
				out id))
			{
				ShowValidationMessage(
					"Please enter a valid Student ID.",
					"Invalid Student ID");

				return;
			}

			Student student =
				students.FirstOrDefault(
					s =>
						s.StudentId == id);

			if (student == null)
			{
				ShowValidationMessage(
					"Student not found.",
					"Student Not Found");

				return;
			}

			student.CalculateGPA();

			string classification;

			if (student.GPA >= 3.5)
				classification =
					"High Distinction";
			else if (student.GPA >= 3.0)
				classification =
					"Distinction";
			else if (student.GPA >= 2.0)
				classification =
					"Pass";
			else
				classification =
					"At Risk";

			result.Text =
				"STUDENT:  " +
				student.Name +
				Environment.NewLine +
				Environment.NewLine +

				"GPA:      " +
				student.GPA.ToString("0.00") +
				Environment.NewLine +
				Environment.NewLine +

				"CLASSIFICATION:  " +
				classification;
		}

		// ============================================================
		// DASHBOARD
		// ============================================================

		private void Dashboard_Click(
			object sender,
			EventArgs e)
		{
			CreateDashboard();

			UpdateStatistics();
		}

		// ============================================================
		// EXIT
		// ============================================================

		private void Exit_Click(
			object sender,
			EventArgs e)
		{
			DialogResult result =
				MessageBox.Show(
					"Do you want to close AcademicHub?",
					"Exit",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

			if (result ==
				DialogResult.Yes)
			{
				Close();
			}
		}

		// ============================================================
		// FORM LABEL
		// ============================================================

		private void AddFormLabel(
			Form form,
			string text,
			int left,
			int top)
		{
			Label label =
				new Label
				{
					Text = text,

					Left = left,
					Top = top,

					Width = 130,
					Height = 25,

					ForeColor = MainText,

					Font =
						new Font(
							"Segoe UI",
							8,
							FontStyle.Bold)
				};

			form.Controls.Add(label);
		}

		// ============================================================
		// FORM TEXTBOX
		// ============================================================

		private TextBox AddFormTextBox(
			Form form,
			int left,
			int top)
		{
			TextBox box =
				new TextBox
				{
					Left = left,
					Top = top,

					Width = 320,
					Height = 32,

					Font =
						new Font(
							"Segoe UI",
							9),

					BorderStyle =
						BorderStyle.FixedSingle
				};

			form.Controls.Add(box);

			return box;
		}

		// ============================================================
		// SUCCESS POPUP
		// ============================================================

		private void ShowMessage(
			string message,
			string title)
		{
			using (Form dialog =
				   new Form())
			{
				dialog.Text = title;

				dialog.StartPosition =
					FormStartPosition.CenterParent;

				dialog.ClientSize =
					new Size(
						520,
						410);

				dialog.BackColor =
					Color.White;

				dialog.FormBorderStyle =
					FormBorderStyle.None;

				dialog.MaximizeBox = false;
				dialog.MinimizeBox = false;
				dialog.ShowInTaskbar = false;

				Panel background =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 520,
						Height = 410,
						BackColor = Color.White
					};

				dialog.Controls.Add(background);

				// ====================================================
				// GREEN HEADER
				// ====================================================

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 520,
						Height = 95,
						BackColor =
							Color.FromArgb(
								16,
								185,
								129)
					};

				background.Controls.Add(header);

				Panel checkBox =
					new Panel
					{
						Left = 28,
						Top = 22,
						Width = 50,
						Height = 50,
						BackColor = Color.White
					};

				header.Controls.Add(checkBox);

				Label checkIcon =
					new Label
					{
						Text = "✓",
						Dock = DockStyle.Fill,
						ForeColor =
							Color.FromArgb(
								16,
								185,
								129),
						Font =
							new Font(
								"Segoe UI",
								25,
								FontStyle.Bold),
						TextAlign =
							ContentAlignment.MiddleCenter
					};

				checkBox.Controls.Add(checkIcon);

				Label headerTitle =
					new Label
					{
						Text =
							"Student Added!",
						Left = 95,
						Top = 18,
						Width = 390,
						Height = 35,
						ForeColor = Color.White,
						Font =
							new Font(
								"Segoe UI",
								17,
								FontStyle.Bold)
					};

				header.Controls.Add(headerTitle);

				Label headerSubtitle =
					new Label
					{
						Text =
							"The academic record has been saved successfully.",
						Left = 97,
						Top = 54,
						Width = 390,
						Height = 22,
						ForeColor =
							Color.FromArgb(
								220,
								252,
								231),
						Font =
							new Font(
								"Segoe UI",
								8)
					};

				header.Controls.Add(headerSubtitle);

				// ====================================================
				// ACADEMIC RECORD CARD
				// ====================================================

				Panel detailsCard =
					new Panel
					{
						Left = 28,
						Top = 115,
						Width = 464,
						Height = 190,
						BackColor =
							Color.FromArgb(
								248,
								250,
								252)
					};

				background.Controls.Add(
					detailsCard);

				Label detailsTitle =
					new Label
					{
						Text =
							"ACADEMIC RECORD",
						Left = 20,
						Top = 14,
						Width = 250,
						Height = 22,
						ForeColor =
							Color.FromArgb(
								16,
								185,
								129),
						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					detailsTitle);

				// ====================================================
				// EXTRACT POPUP VALUES
				// ====================================================

				string studentName = "";
				string gpaValueText = "";
				string gradeValueText = "";

				string[] lines =
					message.Split(
						new[]
						{
							'\n'
						},
						StringSplitOptions.RemoveEmptyEntries);

				foreach (string messageLine in lines)
				{
					if (messageLine.StartsWith(
						"Student:"))
					{
						studentName =
							messageLine.Substring(
								"Student:".Length)
							.Trim();
					}

					if (messageLine.StartsWith(
						"GPA:"))
					{
						gpaValueText =
							messageLine.Substring(
								"GPA:".Length)
							.Trim();
					}

					if (messageLine.StartsWith(
						"Grade:"))
					{
						gradeValueText =
							messageLine.Substring(
								"Grade:".Length)
							.Trim();
					}
				}

				// ====================================================
				// STUDENT
				// ====================================================

				Label studentLabel =
					new Label
					{
						Text = "Student:",
						Left = 20,
						Top = 52,
						Width = 75,
						Height = 25,
						ForeColor =
							Color.FromArgb(
								100,
								116,
								139),
						Font =
							new Font(
								"Segoe UI",
								9,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					studentLabel);

				Label studentValue =
					new Label
					{
						Text = studentName,
						Left = 95,
						Top = 52,
						Width = 330,
						Height = 25,
						ForeColor =
							Color.FromArgb(
								15,
								23,
								42),
						Font =
							new Font(
								"Segoe UI",
								10,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					studentValue);

				// ====================================================
				// GPA
				// ====================================================

				Label gpaLabel =
					new Label
					{
						Text = "GPA:",
						Left = 20,
						Top = 92,
						Width = 75,
						Height = 25,
						ForeColor =
							Color.FromArgb(
								100,
								116,
								139),
						Font =
							new Font(
								"Segoe UI",
								9,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					gpaLabel);

				Label gpaValue =
					new Label
					{
						Text = gpaValueText,
						Left = 95,
						Top = 88,
						Width = 330,
						Height = 35,
						ForeColor =
							Color.FromArgb(
								109,
								40,
								217),
						Font =
							new Font(
								"Segoe UI",
								14,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					gpaValue);

				// ====================================================
				// GRADE
				// ====================================================

				Label gradeLabel =
					new Label
					{
						Text = "Grade:",
						Left = 20,
						Top = 138,
						Width = 75,
						Height = 25,
						ForeColor =
							Color.FromArgb(
								100,
								116,
								139),
						Font =
							new Font(
								"Segoe UI",
								9,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					gradeLabel);

				Label gradeValue =
					new Label
					{
						Text = gradeValueText,
						Left = 95,
						Top = 134,
						Width = 330,
						Height = 35,
						ForeColor =
							Color.FromArgb(
								16,
								185,
								129),
						Font =
							new Font(
								"Segoe UI",
								14,
								FontStyle.Bold)
					};

				detailsCard.Controls.Add(
					gradeValue);

				// ====================================================
				// FOOTER SEPARATOR
				// ====================================================

				Panel footerSeparator =
					new Panel
					{
						Left = 28,
						Top = 325,
						Width = 464,
						Height = 1,
						BackColor =
							Color.FromArgb(
								226,
								232,
								240)
					};

				background.Controls.Add(
					footerSeparator);

				Label footer =
					new Label
					{
						Text =
							"AcademicHub  •  Student Record Management",
						Left = 28,
						Top = 345,
						Width = 320,
						Height = 25,
						ForeColor =
							Color.FromArgb(
								148,
								163,
								184),
						Font =
							new Font(
								"Segoe UI",
								7)
					};

				background.Controls.Add(footer);

				// ====================================================
				// DONE BUTTON
				// ====================================================

				RoundButton doneButton =
					new RoundButton
					{
						Text = "DONE",

						Left = 382,
						Top = 338,

						Width = 110,
						Height = 42,

						ButtonColor =
							Color.FromArgb(
								16,
								185,
								129),

						HoverColor =
							Color.FromArgb(
								5,
								150,
								105),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				doneButton.Click +=
					(s, e) =>
					{
						dialog.Close();
					};

				background.Controls.Add(
					doneButton);

				dialog.ShowDialog(this);
			}
		}

		// ============================================================
		// VALIDATION POPUP
		// ============================================================

		private void ShowValidationMessage(
			string message,
			string title =
				"Check Your Information")
		{
			using (Form dialog =
				   new Form())
			{
				dialog.Text = title;

				dialog.StartPosition =
					FormStartPosition.CenterParent;

				dialog.ClientSize =
					new Size(
						520,
						320);

				dialog.BackColor =
					Color.White;

				dialog.FormBorderStyle =
					FormBorderStyle.None;

				dialog.MaximizeBox = false;
				dialog.MinimizeBox = false;
				dialog.ShowInTaskbar = false;

				Panel background =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 520,
						Height = 320,
						BackColor = Color.White
					};

				dialog.Controls.Add(background);

				// ====================================================
				// WARNING HEADER
				// ====================================================

				Panel header =
					new Panel
					{
						Left = 0,
						Top = 0,
						Width = 520,
						Height = 92,
						BackColor =
							WarningOrange
					};

				background.Controls.Add(header);

				Panel warningCircle =
					new Panel
					{
						Left = 28,
						Top = 20,
						Width = 52,
						Height = 52,
						BackColor = Color.White
					};

				header.Controls.Add(
					warningCircle);

				Label warningIcon =
					new Label
					{
						Text = "!",

						Dock = DockStyle.Fill,

						ForeColor =
							WarningOrange,

						Font =
							new Font(
								"Segoe UI",
								25,
								FontStyle.Bold),

						TextAlign =
							ContentAlignment.MiddleCenter
					};

				warningCircle.Controls.Add(
					warningIcon);

				Label headerTitle =
					new Label
					{
						Text =
							title,

						Left = 96,
						Top = 19,

						Width = 390,
						Height = 32,

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								16,
								FontStyle.Bold)
					};

				header.Controls.Add(
					headerTitle);

				Label headerSubtitle =
					new Label
					{
						Text =
							"Please correct the information below.",

						Left = 98,
						Top = 53,

						Width = 390,
						Height = 22,

						ForeColor =
							Color.FromArgb(
								255,
								251,
								235),

						Font =
							new Font(
								"Segoe UI",
								8)
					};

				header.Controls.Add(
					headerSubtitle);

				// ====================================================
				// MESSAGE CARD
				// ====================================================

				Panel messageCard =
					new Panel
					{
						Left = 28,
						Top = 112,
						Width = 464,
						Height = 92,

						BackColor =
							Color.FromArgb(
								255,
								251,
								235)
					};

				background.Controls.Add(
					messageCard);

				Label smallWarning =
					new Label
					{
						Text = "!",

						Left = 18,
						Top = 25,

						Width = 35,
						Height = 35,

						ForeColor =
							Color.FromArgb(
								217,
								119,
								6),

						Font =
							new Font(
								"Segoe UI",
								17,
								FontStyle.Bold),

						TextAlign =
							ContentAlignment.MiddleCenter
					};

				messageCard.Controls.Add(
					smallWarning);

				Label messageLabel =
					new Label
					{
						Text = message,

						Left = 60,
						Top = 20,

						Width = 375,
						Height = 55,

						ForeColor =
							Color.FromArgb(
								120,
								53,
								15),

						Font =
							new Font(
								"Segoe UI",
								10),

						TextAlign =
							ContentAlignment.MiddleLeft
					};

				messageCard.Controls.Add(
					messageLabel);

				// ====================================================
				// VALIDATION SEPARATOR
				// ====================================================

				Panel validationSeparator =
					new Panel
					{
						Left = 28,
						Top = 225,
						Width = 464,
						Height = 1,

						BackColor =
							Color.FromArgb(
								226,
								232,
								240)
					};

				background.Controls.Add(
					validationSeparator);

				Label footer =
					new Label
					{
						Text =
							"AcademicHub  •  Student Record Management",

						Left = 28,
						Top = 250,

						Width = 300,
						Height = 25,

						ForeColor =
							Color.FromArgb(
								148,
								163,
								184),

						Font =
							new Font(
								"Segoe UI",
								7)
					};

				background.Controls.Add(footer);

				// ====================================================
				// OK BUTTON
				// ====================================================

				RoundButton okButton =
					new RoundButton
					{
						Text = "OK",

						Left = 392,
						Top = 242,

						Width = 100,
						Height = 40,

						ButtonColor =
							WarningOrange,

						HoverColor =
							Color.FromArgb(
								217,
								119,
								6),

						ForeColor = Color.White,

						Font =
							new Font(
								"Segoe UI",
								8,
								FontStyle.Bold)
					};

				okButton.Click +=
					(s, e) =>
					{
						dialog.Close();
					};

				background.Controls.Add(
					okButton);

				dialog.ShowDialog(this);
			}
		}

		// ============================================================
		// SAMPLE DATA
		// ============================================================

		private void CreateSampleData()
		{
			Student student1 =
				new Student
				{
					StudentId = 1000,

					Name =
						"Methule",

					Email =
						"methule@example.com",

					DateOfBirth =
						new DateTime(
							2002,
							5,
							15)
				};

			student1.AcademicRecords.Add(
				new AcademicRecord
				{
					UnitCode = "CSP3341",

					UnitName =
						"Programming Languages",

					Marks = 85
				});

			student1.AcademicRecords.Add(
				new AcademicRecord
				{
					UnitCode = "CSI3106",

					UnitName =
						"Distributed Systems",

					Marks = 78
				});

			student1.AcademicRecords.Add(
				new AcademicRecord
				{
					UnitCode = "CSP3001",

					UnitName =
						"Software Engineering",

					Marks = 72
				});

			student1.CalculateGPA();

			students.Add(student1);

			Student student2 =
				new Student
				{
					StudentId = 1002,

					Name =
						"Sahan Fernando",

					Email =
						"sahan@example.com",

					DateOfBirth =
						new DateTime(
							2003,
							8,
							20)
				};

			student2.AcademicRecords.Add(
				new AcademicRecord
				{
					UnitCode = "CSP3341",

					UnitName =
						"Programming Languages",

					Marks = 75
				});

			student2.AcademicRecords.Add(
				new AcademicRecord
				{
					UnitCode = "CSI3106",

					UnitName =
						"Distributed Systems",

					Marks = 70
				});

			student2.CalculateGPA();

			students.Add(student2);
		}
	}

	// ================================================================
	// CUSTOM ROUNDED BUTTON
	// ================================================================

	public // Custom rounded button used throughout the application.
		   // It demonstrates inheritance from the Windows Forms Button
		   // control and provides a reusable visual component.
class RoundButton : Control
	{
		public Color ButtonColor { get; set; }

		public Color HoverColor { get; set; }

		private bool isHovering;

		public RoundButton()
		{
			ButtonColor =
				Color.FromArgb(
					59,
					130,
					246);

			HoverColor =
				Color.FromArgb(
					37,
					99,
					235);

			ForeColor =
				Color.White;

			Font =
				new Font(
					"Segoe UI",
					8,
					FontStyle.Bold);

			Cursor =
				Cursors.Hand;

			Size =
				new Size(
					120,
					36);

			SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw,
				true);

			TabStop = false;

			isHovering = false;
		}

		protected override void OnMouseEnter(
			EventArgs e)
		{
			isHovering = true;

			Invalidate();

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(
			EventArgs e)
		{
			isHovering = false;

			Invalidate();

			base.OnMouseLeave(e);
		}

		protected override void OnPaint(
			PaintEventArgs e)
		{
			e.Graphics.SmoothingMode =
				SmoothingMode.AntiAlias;

			Color currentColor =
				isHovering
					? HoverColor
					: ButtonColor;

			Rectangle rectangle =
				new Rectangle(
					0,
					0,
					Width - 1,
					Height - 1);

			using (
				GraphicsPath path =
					CreateRoundedPath(
						rectangle,
						10))
			{
				using (
					SolidBrush brush =
						new SolidBrush(
							currentColor))
				{
					e.Graphics.FillPath(
						brush,
						path);
				}
			}

			using (
				StringFormat format =
					new StringFormat())
			{
				format.Alignment =
					StringAlignment.Center;

				format.LineAlignment =
					StringAlignment.Center;

				format.FormatFlags =
					StringFormatFlags.NoWrap;

				using (
					SolidBrush textBrush =
						new SolidBrush(
							ForeColor))
				{
					e.Graphics.DrawString(
						Text,
						Font,
						textBrush,
						ClientRectangle,
						format);
				}
			}
		}

		private GraphicsPath CreateRoundedPath(
			Rectangle rectangle,
			int radius)
		{
			GraphicsPath path =
				new GraphicsPath();

			int diameter =
				radius * 2;

			path.AddArc(
				rectangle.X,
				rectangle.Y,
				diameter,
				diameter,
				180,
				90);

			path.AddArc(
				rectangle.Right - diameter,
				rectangle.Y,
				diameter,
				diameter,
				270,
				90);

			path.AddArc(
				rectangle.Right - diameter,
				rectangle.Bottom - diameter,
				diameter,
				diameter,
				0,
				90);

			path.AddArc(
				rectangle.X,
				rectangle.Bottom - diameter,
				diameter,
				diameter,
				90,
				90);

			path.CloseFigure();

			return path;
		}
	}
}