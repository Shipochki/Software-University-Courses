function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let match = document.getElementById('searchField').value;

      let studentsAll = document.querySelectorAll('table tbody tr');

      for (let i = 0; i < studentsAll.length; i++) {
         let isInclude = false
         let students = studentsAll[i].children;
         if (studentsAll[i].className === 'select' ||
            match === '') {
               studentsAll[i].className = ''
         }

         if (students[0].innerHTML.includes(match) ||
            students[1].innerHTML.includes(match) ||
            students[2].innerHTML.includes(match)) {
            isInclude = true;
         }

         if (isInclude) {
            studentsAll[i].className = 'select';
         }

      }

   }
}