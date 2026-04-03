//for

for (let i = 0; i < 10; i++) {
    console.log(i);   
    if(i==3) break; 
}


// while

let n = 0;
while (n<10) {
    console.log(n);
    if(n==3) break;
    n++;
}


// dowhile

n=0;
do {
    n++;
    if(n%2==0) continue;
    console.log(n);
} while (n<10);


// for...in

let student = {
    name: "ronak",
    age: 22,
    course: "cse",
    collage: "darshan"
}


for (const key in student) {
   console.log(key,student[key]);
}

// for...of

// not allow to traverse object with this loop
// for (const val of student) {
//     console.log(val);
// }


let arr = [7,8,9,10];

for (const val of arr) {
    console.log(val);
}
