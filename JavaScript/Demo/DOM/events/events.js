const code = document.getElementById("code");
const outputkeys = document.getElementById("keypressed");
let Track = false;
const btnstart = document.getElementById("btnstart");
const btnstop = document.getElementById("btnstop");

document.addEventListener("keydown",function(e){
    console.log("document");
    e.preventDefault();
});

btnstart.addEventListener("click",function (){
    Track = true;
});

// btnstop.onclick(function () {
//     console.log("onclick")
// });

btnstop.addEventListener("click",function (){
    console.log("click");
    Track = false;
});


code.addEventListener("keydown",function (e) {
    console.log("inner");
    if(Track){
        console.log(e);
        outputkeys.innerHTML += `<span class="p-2 m-2 bg-secondary text-light">${e.code}</span>`
    }
})


