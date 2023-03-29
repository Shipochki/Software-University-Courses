using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void CreatMethodTests()
    {
        HeroRepository repository = new HeroRepository();

        Hero hero = new Hero("Hero", 1);
        string result = repository.Create(hero);
        string expected = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.That(result.Equals(expected));

        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Create(null);
        });

        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(hero);
        });
	}

	[Test]
	public void RemoveMethodTests()
	{
		HeroRepository repository = new HeroRepository();

		Hero hero = new Hero("Hero", 1);
		repository.Create(hero);

        bool result = repository.Remove("Hero");
        bool expected = true;

        Assert.That(result.Equals(expected));

		Assert.Throws<ArgumentNullException>(() =>
		{
			repository.Remove(null);
		});
	}

	[Test]
	public void GetHeroWithHighestLevelMethodTest()
	{
		HeroRepository repository = new HeroRepository();

		Hero hero = new Hero("Hero", 1);
		Hero hero1 = new Hero("Hero1", 10);
		repository.Create(hero);
		repository.Create(hero1);

		Hero result = repository.GetHeroWithHighestLevel();

		Assert.That(result.Equals(hero1));
	}

	[Test]
	public void GetHeroMethodTest()
	{
		HeroRepository repository = new HeroRepository();

		Hero hero = new Hero("Hero", 1);
		Hero hero1 = new Hero("Hero1", 10);
		repository.Create(hero);
		repository.Create(hero1);

		Hero result = repository.GetHero("Hero1");

		Assert.That(result.Equals(hero1));
	}

	[Test]
	public void HeroesPropertyTest()
	{
		HeroRepository repository = new HeroRepository();

		Hero hero = new Hero("Hero", 1);
		Hero hero1 = new Hero("Hero1", 10);
		repository.Create(hero);
		repository.Create(hero1);

		Assert.That(repository.Heroes.Count.Equals(2));
	}
}