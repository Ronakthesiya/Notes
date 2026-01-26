async function WaitASecond() {
    return new Promise(resolve => {
        setTimeout(() => {
            console.log("Hi");
            resolve();
        }, 2000);
    });
}

async function fetchdata() {
    console.log("start");
    await WaitASecond();
    console.log("end");
}

fetchdata();
