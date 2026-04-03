// simple function

function square(num) {
    return num*num;
}

// call function
square(4);

// function expression
const sqr = function temp(num) {
    return num*num
}


// Closures

function A(x) {
    function B(y) {
        function C(z) {
            console.log(x + y + z);
        }
        C(3);
    }
    B(2);
}
A(1); // Logs 6 (which is 1 + 2 + 3)


// arguments object

function myConcat(sep) {
    let result = ""; 

    for (let i = 1; i < arguments.length; i++) {
        result += arguments[i] + sep;
    }

    console.log(arguments);
    console.log(result);
}

myConcat(",","a","b","c","d","f");


// default Rest parameters

function multiply(a,...other) {
    ans = other.reduce((val,b)=>val*b)
    console.log(ans*a);
}

multiply(2,3,4);