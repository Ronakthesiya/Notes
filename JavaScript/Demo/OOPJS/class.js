class Person{
    Name;
    Age;

    constructor(name,age){
        Name = name;
        this.Age = age;
    }
}


class Student extends Person{
    Id;
    Course;

    constructor(id,name,age,course){
        super(name,age);

        this.Id = id;
        this.Course = course;
    }

    showStudent(){
        console.log(this.Id,this.Name,this.Age,this.Course);
    }
}

let std1 = new Student(1,"Ronak",22,".NET");
let std2 = new Student(2,"Ronak1",21,"ML");
let std3 = new Student(3,"Ronak2",20,"C#");

std1.showStudent();
std2.showStudent();
std3.showStudent();



