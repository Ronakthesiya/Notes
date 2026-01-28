import { getId } from "./Id.js";



// get tasks from local storage
export function getTasks() {
    if (!localStorage.getItem("tasks")) {
        return [];
      }
      
    let arr = localStorage.getItem("tasks").split("$$");
    let lists = arr.map(element => element.split(","));
    let finallist = [];
    lists.forEach(element =>{
        let temp = element.filter(val => val!="");
        if(temp.length > 1)
            finallist.push(temp);
    })

    return finallist;
}

// add task to local storage
export function addTasks(task){

    let finaltask = [getId(), ...task ];

    let tasks = getTasks();
    tasks.push(finaltask);
    let finallist = []
    tasks.forEach(element =>{
        finallist.push([...element,"$$"]);
    })

    localStorage.setItem("tasks",finallist);

    tasklistView()
}

// remove task from local storage
export function removeTask(id){
    let tasks = getTasks();
    tasks.splice(id,1);

    let finallist = []

    tasks.forEach(element =>{
        finallist.push([...element,"$$"]);
    })

    localStorage.setItem("tasks",finallist);

    tasklistView()
}

// edit task in local storage
export function editTask(task) {
    let tasks = getTasks();
    tasks[task[0]][1] = task[1];
    tasks[task[0]][2] = task[2];
    tasks[task[0]][3] = task[3];
    let finallist = []
    tasks.forEach(element =>{
        finallist.push([...element,"$$"]);
    })

    localStorage.setItem("tasks",finallist);
    tasklistView()
}

// display task in html table format
export function tasklistView(){
    let tasks = getTasks();
    let val = "";
    let pendingcnt = 0;

    fetch("http://127.0.0.1:5506/Notes/JQuery/Demo/FullDemo/Javascript/tableRow.html")
    .then(res => res.text())
    .then(html => {
        $.each(tasks,function(index,element){
            if(element[3]=="pending"){
                pendingcnt++;
            }
    
            val += html
            .replace("element[1]", element[1])
            .replace("element[2]", element[2])
            .replace("element[3]", element[3])
            .replace(/\$\{index\}/g, index);
        })

        console.log(val);
        
        $("#pendingcnt").text(pendingcnt);
        $("#complatedcnt").text(tasks.length-pendingcnt);
        $(taskslist).html(val);
    });

    
}