function solve(inputArr) {
    let horses = inputArr[0].split("|");
  
    for (let i = 1; i < inputArr.length; i++) {
      const command = inputArr[i].split(" ");
      if (command[0] == "Finish") {
        console.log(horses.join("->"));
        console.log(`The winner is: ${horses[horses.length - 1]}`);
        return;
      } else if (command[0] == "Retake") {
        const overtakingHorse = command[1];
        const overtakenHorse = command[2];
        const indexOvertakingHorse = horses.findIndex(
          (h) => h == overtakingHorse
        );
        const indexOvertakenHorse = horses.findIndex((h) => h == overtakenHorse);
        if (indexOvertakingHorse < indexOvertakenHorse) {
          horses[indexOvertakingHorse] = overtakenHorse;
          horses[indexOvertakenHorse] = overtakingHorse;
          console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
        }
      } else if (command[0] == "Trouble") {
        const horse = command[1];
        const indexHorse = horses.findIndex((h) => h == horse);
        if (indexHorse == 0) continue;
        else {
          const currentHorse = horses[indexHorse - 1];
          horses[indexHorse] = currentHorse;
          horses[indexHorse - 1] = horse;
          console.log(`Trouble for ${horse} - drops one position.`);
        }
      } else if (command[0] == "Rage") {
        const horse = command[1];
        const indexHorse = horses.findIndex((h) => h == horse);
        if (indexHorse == horses.length - 1);
        else if (indexHorse == horses.length - 2) {
          const currentHorse = horses[horses.length - 1];
          horses[indexHorse] = currentHorse;
          horses[horses.length - 1] = horse;
        } else {
          const firstHorse = horses[indexHorse + 2];
          const secondHorse = horses[indexHorse + 1];
          horses[indexHorse] = secondHorse;
          horses[indexHorse + 1] = firstHorse;
          horses[indexHorse + 2] = horse;
      
        }
        console.log(`${horse} rages 2 positions ahead.`);
      } else if (command[0] == "Miracle") {
        const horse = horses[0];
        for (let i = 0; i < horses.length - 1; i++) {
          horses[i] = horses[i + 1];
        }
        horses[horses.length - 1] = horse
        console.log(`What a miracle - ${horse} becomes first.`);
      }
    }
  }

/*solve([
  "Bella|Alexia|Sugar",
  "Retake Alexia Sugar",
  "Rage Bella",
  "Trouble Bella",
  "Finish",
]);*/

/*solve(['Onyx|Domino|Sugar|Fiona',
'Trouble Onyx',
'Retake Onyx Sugar',
'Rage Domino',
'Miracle',
'Finish']
)*/

solve(['Fancy|Lilly',
'Retake Lilly Fancy',
'Trouble Lilly',
'Trouble Lilly',
'Finish',
'Rage Lilly']
)
