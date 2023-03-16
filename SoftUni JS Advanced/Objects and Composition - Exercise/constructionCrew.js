function modifiedCrew(crew)
{
    if(crew.dizziness === true)
    {
        crew.levelOfHydrated 
        += Number(crew.weight) * 0.1 * Number(crew.experience)

        crew.dizziness = false;
    }

    return crew;
}

console.log(modifiedCrew({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
));

console.log(modifiedCrew({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  ));

console.log(modifiedCrew({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  ));