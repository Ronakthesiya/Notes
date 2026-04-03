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

export default BankAccount;