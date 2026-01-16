let div1 = document.getElementById("1");

console.log(div1);


let selectBySelectors = document.querySelectorAll(".container");
let selectByClass = document.getElementsByClassName("container");
let selectByTag = document.getElementsByTagName("div");

console.log(selectBySelectors);
console.log(selectByClass);
console.log(selectByTag);

div1.remove();

console.log(selectBySelectors); // div1 is as it is not removed
console.log(selectByClass); // div1 is removed
console.log(selectByTag); // div1 is removed

