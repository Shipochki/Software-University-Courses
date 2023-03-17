using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using static UniversityCompetition.Utilities.Messages.OutputMessages;

namespace UniversityCompetition.Core
{
	public class Controller : IController
	{
		private SubjectRepository subjects = new SubjectRepository();
		private StudentRepository students = new StudentRepository();
		private UniversityRepository universities = new UniversityRepository();


		public string AddStudent(string firstName, string lastName)
		{
			if (this.students.FindByName($"{firstName} {lastName}") != null)
			{
				return string.Format(AlreadyAddedStudent, firstName, lastName);
			}

			this.students.AddModel(new Student(this.students.Models.Count() + 1, firstName, lastName));

			return string.Format(StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
		}

		public string AddSubject(string subjectName, string subjectType)
		{
			if (nameof(HumanitySubject) != subjectType && nameof(EconomicalSubject) != subjectType &&
				nameof(TechnicalSubject) != subjectType)
			{
				return string.Format(SubjectTypeNotSupported, subjectType);
			}

			if (this.subjects.FindByName(subjectName) != null)
			{
				return string.Format(AlreadyAddedSubject, subjectName);
			}

			if (nameof(TechnicalSubject) == subjectType)
			{
				this.subjects.AddModel(new TechnicalSubject(this.subjects.Models.Count() + 1, subjectName));
			}
			else if (nameof(HumanitySubject) == subjectType)
			{
				this.subjects.AddModel(new HumanitySubject(this.subjects.Models.Count() + 1, subjectName));
			}
			else if (nameof(EconomicalSubject) == subjectType)
			{
				this.subjects.AddModel(new EconomicalSubject(this.subjects.Models.Count() + 1, subjectName));
			}

			return string.Format(SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
		}

		public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
		{
			if (this.universities.FindByName(universityName) != null)
			{
				return string.Format(AlreadyAddedUniversity, universityName);
			}

			var subjects = new List<int>();

			foreach (var subject in requiredSubjects)
			{
				var id = this.subjects.FindByName(subject).Id;
				subjects.Add(id);
			}

			this.universities.AddModel(new University(this.universities.Models.Count() + 1, universityName, category, capacity, subjects));

			return string.Format(UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
		}

		public string ApplyToUniversity(string studentName, string universityName)
		{
			var student = this.students.FindByName(studentName);
			if(student == null)
			{
				return string.Format(StudentNotRegitered, studentName.Split()[0], studentName.Split()[1]);
			}

			var university = this.universities.FindByName(universityName);
			if(university == null)
			{
				return string.Format(UniversityNotRegitered, universityName);
			}

			var isCovered = true;

			foreach (var exam in university.RequiredSubjects)
			{
				if(!student.CoveredExams.Contains(exam))
				{
					isCovered = false;
					break;
				}
			}

			if(!isCovered)
			{
				return string.Format(StudentHasToCoverExams, studentName, universityName);
			}

			if(student.University != null)
			{
				return string.Format(StudentAlreadyJoined, studentName.Split()[0], studentName.Split()[1], universityName);
			}

			student.JoinUniversity(university);

			return string.Format(StudentSuccessfullyJoined, studentName.Split()[0], studentName.Split()[1], universityName);
		}

		public string TakeExam(int studentId, int subjectId)
		{
			if (this.students.FindById(studentId) == null)
			{
				return string.Format(InvalidStudentId, studentId);
			}

			if (this.subjects.FindById(subjectId) == null)
			{
				return string.Format(InvalidSubjectId, subjectId);
			}

			var student = this.students.FindById(studentId);
			var subject = this.subjects.FindById(subjectId);

			if (student.CoveredExams.Contains(subjectId))
			{
				return string.Format(StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
			}

			student.CoverExam(subject);

			return string.Format(StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
		}

		public string UniversityReport(int universityId)
		{
			var university = this.universities.FindById(universityId);
			var uniStudents = this.students
				.Models
				.Where(s => s.University == university)
				.ToList();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"*** {university.Name} ***");
			sb.AppendLine($"Profile: {university.Category}");
			sb.AppendLine($"Students admitted: {uniStudents.Count()}");
			sb.AppendLine($"University vacancy: {university.Capacity - uniStudents.Count()}");

			return sb.ToString().TrimEnd();
		}
	}
}
