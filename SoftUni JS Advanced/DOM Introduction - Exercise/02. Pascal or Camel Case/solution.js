function solve() {
  let input = document.getElementById('text').value;
  let currentCase = document.getElementById('naming-convention').value;
  let textArr = input.split(' ');
  let res = '';

  if (currentCase === 'Camel Case') {
    textArr.forEach((e, i) => {
      if (i === 0) {
        return res += e.toLowerCase();
      }

      return res += e[0].toUpperCase() + e.substring(1).toLowerCase();
    });
  }
  else if (currentCase === 'Pascal Case') {
    textArr.forEach((e, i) => {
      e = e.toLowerCase();
      res += e[0].toUpperCase() + e.substring(1);
    })
  }
  else {
    res = 'Error!';
  }

  return document.getElementById('result').textContent = res;
}