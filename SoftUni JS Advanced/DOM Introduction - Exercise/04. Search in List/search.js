function search() {
   let cities = document.querySelectorAll('ul li');
   let input = document.getElementById('searchText').value;
   let count = 0;

   for (let i = 0; i < cities.length; i++) {
      const city = cities[i];
      if( city.style.fontStyle === "italic" ||
      city.style.fontWeight === "bold" ||
      city.style.textDecoration === 'underline')
      {
         city.style.fontStyle = "";
         city.style.fontWeight = "";
         city.style.textDecoration = '';
      }

      if(city.innerHTML.includes(input)){
      city.style.fontStyle = "italic";
      city.style.fontWeight = "bold";
      city.style.textDecoration = 'underline';
      count++;
      }
   }

   document.getElementById('result').textContent = `${count} matches found`
}
