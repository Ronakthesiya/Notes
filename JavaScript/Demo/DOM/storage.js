let local = document.getElementsByClassName("local")[0];
let session = document.getElementsByClassName("session")[0];

console.log(local);
console.log(session);


if(localStorage.getItem("value")){
    local.value = localStorage.getItem("value");
}

local.addEventListener("change",function() {
    console.log(local.value);
    localStorage.setItem("value",local.value);
});


if(sessionStorage.getItem("value")){
    session.value = sessionStorage.getItem("value");
}

session.addEventListener("change",function() {
    console.log(session.value);
    sessionStorage.setItem("value",session.value);
});
