function SetUserName(username) {
    this.username = username
}


function createUser(username,email,password) {
    // SetUserName(username)
    SetUserName.call(this,username)

    this.email = email
    this.password = password
}

const user = new createUser("ronak", "ronak@gmail.com", "12345678");

console.log(user);

