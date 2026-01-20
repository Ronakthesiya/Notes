function logName(name) {
    console.log(name);
}

function logName2(name){
    console.log(name,name);
}

export default function logName3(name){
    console.log(name,name,name)
}

function log4(name){
    console.log(name,name,name,name)
}

export {logName,logName2,log4 as logName4};