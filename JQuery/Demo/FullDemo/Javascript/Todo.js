import {addTasks, editTask, getTasks, removeTask, tasklistView} from "./Tasks.js";

if(!localStorage.getItem("ids") || localStorage.getItem("ids").length<=0)
    localStorage.setItem("ids",1);

tasklistView();

// delete btn click handle to remove task
$(document).on("click", ".delete-btn", function () {
    let index = $(this).data("index");
    
    removeTask(index);
});
  
// edit button click hadle to file the form data
$(document).on("click", ".edit-btn", function () {
    let index = $(this).data("index");
    let tasks = getTasks();
    let task = tasks[index];

    $("#taskForm").find("input[name='id']").val(index);
    $("#taskForm").find("input[name='title']").val(task[1]);
    $("#taskForm").find("textarea[name='description'").val(task[2]);
    if(task[3]=="pending"){
        $('#pending').prop("checked", true);
    }else{
        $('#complated').prop("checked", true)
    }
    
});

// form validation and submission handling
$('#taskForm').validate({
    rules:{
        title:{
            required: true,
            noWhitespace: true,
            minlength: 3
        },
        description:{
            required: true,
            noWhitespace: true,
            minlength: 1
        }
    },
    highlight: function(element){
        $(element).css({
            "border": "2px solid red"
        })
    },
    unhighlight: function (element) {
        $(element).css({
            "border": "2px solid black"
        })
    },
    submitHandler: function(form,event){
        event.preventDefault();

        let id = $(form).find("input[name='id']").val();
        let title = $(form).find("input[name='title']").val();
        let description = $(form).find("textarea[name='description']").val();
        let status = $(form).find("input[name='status']:checked").val();

        if(id>0){
            editTask([id,title,description,status]);
        }else{
            addTasks([title,description,status]);
        }

        $(form).find("input[name='id']").val("");
        $(form).find("input[name='title']").val("");
        $(form).find("textarea[name='description']").val("");

        console.log(getTasks());
    }
})



