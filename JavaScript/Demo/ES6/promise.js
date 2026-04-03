
var myPromise = new Promise((resolve,reject)=>{
    setTimeout(()=>{
        resolve("success");
    },500)
})

console.log("started");

myPromise
    .then((resolve,reject)=>resolve)
    .then((resolve,reject)=>console.log(resolve));

console.log("ended");
