using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
	public class StudentRepository : IRepository<IStudent>
	{
		private List<IStudent> models;

		public StudentRepository()
		{
			models= new List<IStudent>();
		}

		public IReadOnlyCollection<IStudent> Models => this.models;

		public void AddModel(IStudent model)
		{
			this.models.Add(model);
		}

		public IStudent FindById(int id)
		{
			return this.models.FirstOrDefault(x => x.Id == id);
		}

		public IStudent FindByName(string name)
		{
			return this.models.FirstOrDefault(
				m => m.FirstName == name.Split()[0] 
			&& m.LastName == name.Split()[1]);
		}
	}
}
