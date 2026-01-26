const btn = document.getElementById("btn");
btn.addEventListener("click",function () {
    console.log("eventlistner");
})
btn.addEventListener("click",function () {
    console.log("eventlistner2");
})

btn.onclick = function(){
    console.log("onclick");
}

btn.onclick = function(){
    console.log("onclick2");
}

document.getElementById('myButton').onclick = function() {
    console.log('JavaScript onclick property');
};

document.getElementById('myButton').addEventListener('click', function() {
    console.log('JavaScript addEventListener');
});


