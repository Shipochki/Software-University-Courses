using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using static UniversityCompetition.Utilities.Messages.ExceptionMessages;

namespace UniversityCompetition.Models
{
	public class Student : IStudent
	{
		public Student(int studentId, string firstName, string lastName)
		{
			Id = studentId;
			FirstName = firstName;
			LastName = lastName;
			this.coveredExams = new List<int>();
		}

		private int id;

		public int Id
		{
			get { return id; }
			private set { id = value; }
		}

		private string firstName;

		public string FirstName
		{
			get { return firstName; }
			private set 
			{ 
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(NameNullOrWhitespace);
				}
				firstName = value; 
			}
		}

		private string lastName;

		public string LastName
		{
			get { return lastName; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(NameNullOrWhitespace);
				}
				lastName = value; 
			}
		}

		private List<int> coveredExams;

		public IReadOnlyCollection<int> CoveredExams
		{
			get { return coveredExams; }
		}

		private IUniversity university;

		public IUniversity University
		{
			get { return university; }
			private set { university = value; }
		}

		public void CoverExam(ISubject subject)
		{
			this.coveredExams.Add(subject.Id);
		}

		public void JoinUniversity(IUniversity university)
		{
			this.University = university;
		}
	}
}
