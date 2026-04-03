let users;
const tbody = document.getElementsByTagName("tbody")[0];
const loader = document.getElementById("loader");

async function loadUsers(params) {
    setTimeout(()=>
        fetch('https://jsonplaceholder.typicode.com/todos')
            .then(res=> res.json())
            .then(json=>{
                loader.classList.add("d-none");

                users = json
                console.log(users);

                users.forEach(user => {
                    let tr = document.createElement("tr");
                    let usertId = document.createElement("td");
                    let id = document.createElement("td");
                    let title = document.createElement("td");
                    let complated = document.createElement("td");

                    usertId.innerText = user.userId;
                    id.innerText = user.id;
                    title.innerText = user.title;
                    complated.innerText = user.completed;

                    if(user.completed == false){
                        complated.classList.add("bg-danger-subtle")
                    }else{
                        complated.classList.add("bg-success-subtle") 
                    }

                    console.log(usertId);
                    
                    tr.appendChild(usertId)
                    tr.appendChild(id)
                    tr.appendChild(title)
                    tr.appendChild(complated)
                    tbody.appendChild(tr);
                });
            })
            .catch((err)=>{
                console.log(err);
            })
    ,2000);
}

loadUsers();
