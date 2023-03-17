using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
	public class SubjectRepository : IRepository<ISubject>
	{
		private List<ISubject> models;

		public SubjectRepository()
		{
			this.models = new List<ISubject>();
		}

		public IReadOnlyCollection<ISubject> Models => this.models;

		public void AddModel(ISubject model)
		{
			this.models.Add(model);
		}

		public ISubject FindById(int id)
		{
			return this.models.FirstOrDefault(m => m.Id == id);
		}

		public ISubject FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.Name == name);
		}
	}
}
