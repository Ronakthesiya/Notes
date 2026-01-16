
let arr = [45, 78, 92, 30, 65, "asdf",-12];

function calculateStatus(score){
    if(score > 50) return "Pass";
    return "Fail";
}


for (let i = 0; i < arr.length; i++) {
    const score = arr[i];
    
    if (typeof(score) === "number") {
        console.log(i+1 , calculateStatus(score));
    }else{
        console.log(i+1, "not a number");
    }
}