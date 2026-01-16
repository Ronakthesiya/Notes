let container = document.querySelector(".container");
let bulb = document.querySelector(".bulb > img");
let button = document.querySelector(".button");
let body = document.querySelector("body");
let cnt = document.querySelector(".cnt");
let counter = 0;

button.addEventListener("click",function(e){
    console.log("button clicked !");
    // e.stopPropagation(); // use to stop event propogation 

    if(!container.classList.contains("bglight")){
        bulb.setAttribute("src","onbulb.png");
        // container.classList.remove("bgdark");
        container.classList.add("bglight");
        button.innerText = "Turn Off";
    }else{
        container.classList.remove("bglight");
        // container.classList.add("bgdark");
        bulb.setAttribute("src","offbulb.jpg");
        button.innerText = "Turn On";
    }
});


body.addEventListener("click",function(){
    counter++;
    cnt.innerText = counter;
    console.log("body clicked !");
});
