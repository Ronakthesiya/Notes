
// return new id every time 
export function getId(){
    let id = Number(localStorage.getItem("ids"));
    localStorage.setItem("ids" , id+1);
    return id;
}