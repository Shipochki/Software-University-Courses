using System;
using UniversityCompetition.Models.Contracts;
using static UniversityCompetition.Utilities.Messages.ExceptionMessages;

namespace UniversityCompetition.Models
{
	public class Subject : ISubject
	{
		public Subject(int subjectId, string subjectName, double subjectRate)
		{
			Id = subjectId;
			Name = subjectName;
			Rate = subjectRate;
		}

		private int id;

		public int Id
		{
			get { return id; }
			private set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{ 
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(NameNullOrWhitespace);
				}
				name = value; 
			}
		}

		private double rate;

		public double Rate
		{
			get { return rate; }
			private set { rate = value; }
		}
	}
}
