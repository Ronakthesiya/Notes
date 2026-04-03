// throw statement

try {
    console.log("try started");

    throw "Exception occur";

    console.log("try ended");
} catch (error) {
    console.log("catch started");
    console.log(error);
} finally {
    console.log("finally");
}


class ValidationError extends Error {
    constructor(message) {
        super(message);
        this.name = "ValidationError";
    }
}

class DivideByZero extends Error{
    constructor(){
        super("divide by zero");
    }
}

try {
    var a = 1;
    var b = 0;
    if(b==0){
        throw new DivideByZero();
    }
} catch (e) {
    console.log(e instanceof ValidationError); // true
    console.log(e.message); // "Invalid input!"
    console.log(e.name);    // "ValidationError"
}
