// async function method1() {
//     await method2();
//     console.log("method1");
// }

// async function method2() {
//     return new Promise((resolve,reject)=>{
//         setTimeout(()=>{
//             console.log("method2");
//             resolve();
//         },5000)
//     })
// }

// method1();

let str = "<div class='container' id='1'>1</div>"
const dom = Document.parseHTMLUnsafe(str);

let container = dom.getElementById("1");

console.log(container);




