
// validate input to prevent only white spaces
$.validator.addMethod("noWhitespace", function(value, element) {
    return !/^\s*$/.test(value);  
}, "Input cannot be empty or just spaces");


