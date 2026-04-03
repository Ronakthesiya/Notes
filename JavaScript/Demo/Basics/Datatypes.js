let number = 10;
let string = "asdf";
let boolean = false;
let nothing = undefined;
let novalue = null;

let obj = {
    1: "asdf",
    2: "asdf"
}

console.log(typeof number); // number
console.log(typeof string); // string
console.log(typeof boolean); // boolean
console.log(typeof nothing); // undefine
console.log(typeof novalue); // object
console.log(typeof obj); // object


let mySymbol = Symbol('description');
let anotherSymbol = Symbol('description');
console.log(mySymbol === anotherSymbol); // false

let symbol1 = Symbol.for('app');
let symbol2 = Symbol.for('app');
console.log(symbol1 === symbol2); // true

console.log(Symbol.keyFor(symbol1)); // app
