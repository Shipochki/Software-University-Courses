using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using static UniversityCompetition.Utilities.Messages.ExceptionMessages;

namespace UniversityCompetition.Models
{
	public class University : IUniversity
	{
		public University(int universityId, string universityName, string category, 
			int capacity,
			List<int> requiredSubjects)
		{
			Id = universityId;
			Name = universityName;
			Category = category;
			Capacity = capacity;
			this.requiredSubjects = requiredSubjects;
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
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(NameNullOrWhitespace);
				}

				name = value; 
			}
		}

		private string category;

		public string Category
		{
			get { return category; }
			private set 
			{ 
				if(value.ToLower() != "technical" && 
					value.ToLower() != "economical" &&
					value.ToLower() != "humanity")
				{
					throw new ArgumentException(CategoryNotAllowed, value);
				}
				category = value; 
			}
		}

		private int capacity;

		public int Capacity
		{
			get { return capacity; }
			private set 
			{ 
				if(value < 0)
				{
					throw new ArgumentException(CapacityNegative);
				}
				capacity = value; 
			}
		}

		private IReadOnlyCollection<int> requiredSubjects;

		public IReadOnlyCollection<int> RequiredSubjects
		{
			get { return requiredSubjects; }
			private set { requiredSubjects = value; }
		}

	}
}
