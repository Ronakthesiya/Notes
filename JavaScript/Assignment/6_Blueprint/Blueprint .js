class BankAccount{
    accountHolder;
    #balance;

    constructor(name,amount){
        this.accountHolder = name;
        this.#balance=amount;
    }

    deposite(amount){
        this.#balance += amount;
    }

    withdraw(amount){
        this.#balance -= amount;
    }

    get balance(){
        return this.#balance;
    }

    static info(){
        return "Bank System v1.0";
    }
}


let p1 = new BankAccount("person1",10000);
let p2 = new BankAccount("person2",20000);

console.log(p1.balance);
console.log(p2.balance);

p1.withdraw(1111);
p2.withdraw(1111);

console.log(p1.balance);
console.log(p2.balance);

console.log(BankAccount.info());
