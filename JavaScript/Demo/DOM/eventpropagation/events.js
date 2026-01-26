const outer = document.getElementById("outer");
const middle = document.getElementById("middle");
const inner = document.getElementById("inner");


outer.addEventListener("click",function () {
    console.log("outer start");
},true);

outer.addEventListener("click",function () {
    console.log("outer end");
},false);


middle.addEventListener("click",function (e) {
    console.log("middle start");
    
},true);

middle.addEventListener("click",function (e) {
    console.log("middle end");
},false);


inner.addEventListener("click",function () {
    console.log("inner start");
},true);

inner.addEventListener("click",function () {
    console.log("inner end");
},false);
