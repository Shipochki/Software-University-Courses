function sorting(array, criteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }  

    let tickets = [];

    array.forEach(element => {
        let data = element.split('|');
        let destination = data[0];
        let price = Number(data[1]);
        let status = data[2];

        tickets.push(new Ticket(destination, price, status));
    });

    if(criteria === 'destination'){
        tickets = tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    }else if(criteria === 'price'){
        tickets.sort((a, b) => a.price - b.price)
    }else if(criteria === 'status'){
        tickets.sort((a, b) => a.status - b.status)
    }

    return tickets;
}

console.log(sorting(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));

console.log(sorting(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
));
