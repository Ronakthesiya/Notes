// multiple inheritance not supported in js

class WorkerRole {
    work(name) {
        console.log(`${name} is working.`);
    }
}

class SingerRole {
    sing(name) {
        console.log(`${name} is singing.`);
    }
}

class Person {
    constructor(name) {
        this.name = name;
        this.worker = new WorkerRole();
        this.singer = new SingerRole();
    }
    work() {
        this.worker.work(this.name);
    }
    sing() {
        this.singer.sing(this.name);
    }
}

const person = new Person('Ronak');
person.work(); // Ronak is working.
person.sing(); // Ronak is singing.
