﻿using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entites
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; } = null!;

		public List<Book> Books { get; set; } = new List<Book>();
	}
}
