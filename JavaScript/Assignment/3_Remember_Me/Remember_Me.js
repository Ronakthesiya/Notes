const save = document.getElementById("save");
const user = document.getElementById("username");
const counter = document.getElementById("counter");

counter.innerText = sessionStorage.getItem("cnt");
if(localStorage.getItem("username")){
    user.value = localStorage.getItem("username");
}

save.addEventListener("click",function(){
    localStorage.setItem("username",user.value);
})

document.addEventListener("click",function () {
    sessionStorage.setItem("cnt", Number(sessionStorage.getItem("cnt"))+1);
    counter.innerText = sessionStorage.getItem("cnt");
})


const banner = document.getElementById("banner");
const accept = document.getElementById("accept");
const reject = document.getElementById("reject");

if(document.cookie){
    banner.classList.add("d-none");
}else{
    banner.classList.remove("d-none");
}

accept.addEventListener("click",function(){
    document.cookie = `name=${user.value}; max-age=604800;`;
    console.log(document.cookie);
    banner.classList.add("d-none");
})

reject.addEventListener("click",function(){
    banner.classList.add("d-none");
})

let values = document.cookie;
console.log(values);


