// clock

const clock = document.getElementById("clock");

setInterval(()=>{
    let date = new Date(); 
    clock.innerText = date.getHours()+" : "+date.getMinutes()+" : "+date.getSeconds();
},1000);


// Number

const number = document.getElementById("number");
const btnrandom = document.getElementById("btnrandom");

function setRandomNumber() {
    number.innerText =  Math.floor(Math.random()*1001);
}

setRandomNumber();
btnrandom.addEventListener("click",setRandomNumber);


// String 

const input = document.getElementById("str");
const output = document.getElementById("output");
const btnstr = document.getElementById("btnstr");

btnstr.addEventListener("click",()=>{
    let words = input.value.trim().split(" ");
    output.innerText = ""

    words.forEach(element => {
        output.textContent += element.charAt(0).toUpperCase() + element.slice(1).toLowerCase() +" ";
    });

    console.log("Asdf");
    console.log(output.innerText);
    console.log(words);
})

