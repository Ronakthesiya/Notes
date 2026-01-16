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

try {
    throw new ValidationError("Invalid input!");
} catch (e) {
    console.log(e instanceof ValidationError); // true
    console.log(e.message); // "Invalid input!"
    console.log(e.name);    // "ValidationError"
}
