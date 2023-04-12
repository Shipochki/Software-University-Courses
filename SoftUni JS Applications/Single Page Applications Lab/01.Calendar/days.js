import { getMonths } from "./months.js";

export function getDays(year, month){
    const sections = document.querySelectorAll('section');
    sections.forEach(s => s.style.display = 'none');

    document.getElementById(`year-${year}`).style.display = 'none';

    let monthNum = 1;
    if(month == 'Feb'){
        monthNum = 2;
    } else if(month == 'Mar'){
        monthNum = 3;
    } else if(month == 'Apr'){
        monthNum = 4;
    } else if(month == 'May'){
        monthNum = 5;
    } else if(month == 'Jun'){
        monthNum = 6;
    } else if(month == 'Jul'){
        monthNum = 7;
    } else if(month == 'Aug'){
        monthNum = 8;
    } else if(month == 'Sept'){
        monthNum = 9;
    } else if(month == 'Oct'){
        monthNum = 10;
    } else if(month == 'Nov'){
        monthNum = 11;
    } else if(month == 'Dec'){
        monthNum = 12;
    }

    const days = document.getElementById(`month-${year}-${monthNum}`);
    days.style.display = 'block';
    days.querySelector('caption').addEventListener('click', () => getMonths(year));
}