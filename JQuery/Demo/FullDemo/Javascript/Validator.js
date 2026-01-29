
// validate input to prevent only white spaces
// if all white space return false
// otherwise return true
$.validator.addMethod("noWhitespace", function(value, element) {
    return !/^\s*$/.test(value);  
}, "Input cannot be empty or just spaces");

