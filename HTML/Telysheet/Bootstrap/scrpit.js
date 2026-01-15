function add(val) {

    if(val == "QA" || val == "Management"){
        var valName = document.getElementsByName(val+"Name")[0].value;
        var valnumber = document.getElementsByName(val+"number")[0].value;

        if(valName!=null && valName!="" && valnumber!=null && valnumber!=""){
            var valList = document.getElementsByClassName(val);

            valList[0].innerHTML+=
                `<div class="row">
                    <div class="col-8 border border-dark">${valName}</div>
                    <div class="col-4 border border-dark text-center">${valnumber}</div>
                </div>`;
        }
    }else{
        var DeveloperName = document.getElementsByName(val+"Name")[0].value;
        var Developernumber = document.getElementsByName(val+"number")[0].value;

        if(DeveloperName!=null && DeveloperName!="" && Developernumber!=null && Developernumber!=""){
            var DeveloperList1 = document.getElementsByClassName(val+"1");
            var DeveloperList2 = document.getElementsByClassName(val+"2");

            if(DeveloperList1[0].childNodes.length <= DeveloperList2[0].childNodes.length)
                DeveloperList1[0].innerHTML+=
                    `<div class="row">
                        <div class="col-8 border border-dark">${DeveloperName}</div>
                        <div class="col-4 border border-dark text-center">${Developernumber}</div>
                    </div>`;
            else
                DeveloperList2[0].innerHTML+=
                `<div class="row">
                    <div class="col-8 border border-dark">${DeveloperName}</div>
                    <div class="col-4 border border-dark text-center">${Developernumber}</div>
                </div>`;
        }
    }
}


function remove(val) {
    if(val == "QA" || val == "Management"){
        var QAName = document.getElementsByName(val+"Name")[0].value;
        var QAnumber = document.getElementsByName(val+"number")[0].value;

        if((QAName!=null && QAName!="") || (QAnumber!=null && QAnumber!="")){
            var QAList = document.getElementsByClassName(val)[0];

            for (let i = 5; i <= QAList.childNodes.length; i+=2) {
                const QA = QAList.childNodes[i];

                if(QA.innerHTML == "" || QA.innerHTML == null) continue;

                if(QA.childNodes[1].innerHTML.toUpperCase()==QAName.toUpperCase() || QA.childNodes[3].innerHTML==QAnumber){
                    QAList.childNodes[i].innerHTML = "";
                    break;
                }
            }
        }
    }else{
        var QAName = document.getElementsByName(val+"Name")[0].value;
        var QAnumber = document.getElementsByName(val+"number")[0].value;

        if((QAName!=null && QAName!="") || (QAnumber!=null && QAnumber!="")){
            var QAList1 = document.getElementsByClassName(val+"1")[0];
            var QAList2 = document.getElementsByClassName(val+"2")[0];

            for (let i = 1; i < QAList1.childNodes.length; i+=2) {
                const QA = QAList1.childNodes[i];

                if(QA.innerHTML == "" || QA.innerHTML == null) continue;

                if(QA.childNodes[1].innerHTML.toUpperCase()==QAName.toUpperCase() || QA.childNodes[3].innerHTML==QAnumber){
                    QAList1.childNodes[i].innerHTML = "";
                    return;
                }
            }

            for (let i = 1; i < QAList2.childNodes.length; i+=2) {
                const QA = QAList2.childNodes[i];

                if(QA.innerHTML == "" || QA.innerHTML == null) continue;

                if(QA.childNodes[1].innerHTML.toUpperCase()==QAName.toUpperCase() || QA.childNodes[3].innerHTML==QAnumber){
                    QAList2.childNodes[i].innerHTML = "";
                    return;
                }
            }

        }
    }
}

document.addEventListener('click', function (e) {
    const target = e.target.closest('.col-8');
    if (!target) return;
    target.classList.toggle('right');
});
