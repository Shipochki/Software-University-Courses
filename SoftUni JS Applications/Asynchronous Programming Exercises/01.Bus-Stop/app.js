async function getInfo() {
    const id = document.getElementById('stopId').value;
    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');
    buses.textContent = '';
    const url = `http://localhost:3030/jsonstore/bus/businfo/${id}`;

    await fetch(url)
        .then(respone => {
            if(respone.ok == false){
                let error = new Error();
                error.status = respone.status;
                error.statusText = respone.statusText;
                throw error;
            }
            else{
                return respone.json();
            }
        })
        .then(data => {
            stopName.textContent = data.name;
            Object.entries(data.buses).forEach(([busId, time]) => {
                let li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${time} minutes`;
                buses.appendChild(li);
            });
        })
        .catch(error => {
			stopName.textContent = `Error`;
		})
}