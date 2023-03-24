function calculator() {
    let section1;
    let section2;
    let section3;
    return {
        init(input1, input2, input3){
            section1 = document.querySelector(input1);
            section2 = document.querySelector(input2);
            section3 = document.querySelector(input3);
        },
        add(){
            section3.value = Number(section1.value) + Number(section2.value);
        },
        subtract(){
            section3.value = Number(section1.value) - Number(section2.value);
        }
    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 