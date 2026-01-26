import BankAccount from "./Account.js";

let p1 = new BankAccount("person1",10000);
let p2 = new BankAccount("person2",20000);

console.log(p1.balance);
console.log(p2.balance);

p1.withdraw(1111);
p2.withdraw(1111);

console.log(p1.balance);
console.log(p2.balance);

console.log(BankAccount.info());