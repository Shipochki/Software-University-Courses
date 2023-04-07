function solve() {
    let info = document.getElementById('info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');
    
    let nextStopId = 'depot';
    let stopName;

    async  function depart() {
        let url = `http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`;

        fetch(url)
        .then(response => {
            if(response.ok == false){
                let error = new Error();
                error.status = respone.status;
                error.statusText = respone.statusText;
                throw error;
            }else{
                return response.json();
            }
        })
        .then(data => {
            stopName = data.name;
            nextStopId = data.next;
            info.textContent = `Next stop ${stopName}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        })
        .catch(error => {
            info.textContent = `Error`;
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        });
    }

    function arrive() {
        info.textContent = `Arriving at ${stopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();