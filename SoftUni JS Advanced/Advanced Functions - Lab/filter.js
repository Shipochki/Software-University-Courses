function filter(input, cirteria){
    let objects = JSON.parse(input);
    let correctKey = cirteria.split('-')[0];
    let correctValue = cirteria.split('-')[1];
    let count = 0;

    for (let i = 0; i < objects.length; i++) {
        let element = objects[i];
        
        let keys = Object.keys(element);
        let values = Object.values(element);
        for (let j = 0; j < keys.length; j++) {
            let key = keys[j];
            let value = values[j];

            if(correctKey === key && value === correctValue)
            {
                console.log(`${count++}. ${element.first_name} ${element.last_name} - ${element.email}`)
                break;
            }
        }
    }
}

filter(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female'
)

filter(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
 'last_name-Johnson'
)