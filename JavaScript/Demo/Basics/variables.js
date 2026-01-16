// var
// function scope
// can redeclare

function vardemo() {
    console.log(a);
    var a = 1

    function innerfunction() {
        console.log("can access a : ", a);
    }

    innerfunction();

    var a = "asdf";

    console.log(a);

    innerfunction();
}



function letdemo(){

    // console.log(a); // not allowed
    let a = 1

    // let a = 2; // not allowed

    function innerfunction() {
        console.log("can access a : ", a);
    }

    innerfunction();

    // var a = "asdf"; // not allowed
    a = "asdf";

    console.log(a);

    innerfunction();
}



function constdemo(){
    const a = 10;
    
    console.log(a);

    // a = 12;
}

// constdemo();
// letdemo();
// vardemo();