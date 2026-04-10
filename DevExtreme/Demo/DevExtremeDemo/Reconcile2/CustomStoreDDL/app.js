let userURL = "https://69c214b97518bf8facbd35ad.mockapi.io/users/" 
let childuser = "https://69c214b97518bf8facbd35ad.mockapi.io/users/1/ChildUser"

const userStore = new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "raw", 
    load: function () {
        return fetch(userURL)
            .then(res => res.json());
    },
    //byKey: function (key) {
    //    return fetch(userURL+key)
    //        .then(res => res.json());
    //},
    insert: function (values){
        return fetch(userURL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(values)
        }).then(res => res.json());
    },
    update: function (id, values) {
        return fetch(userURL+id, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(values)
        }).then(res => res.json());
    },
    remove: function (id) {
        return fetch(userURL + id, {
            method: "Delete",
            headers: {
                "Content-Type": "application/json"
            }
        }).then(res => res.json());
    }
})

let selectedUserId = 0;

const subUserStore = new DevExpress.data.CustomStore({
    key: "id",
    load: function () {
        return fetch(userURL + selectedUserId +"/ChildUser")
            .then(res => res.json());
    },
})


const savedId = parseInt(sessionStorage.getItem("userId"))
const savedTitle = sessionStorage.getItem("name")

const user = $("#user").dxDropDownBox({
    label: "user",
    dataSource: userStore,
    valueExpr: "id",
    displayExpr: "name",
    value: savedId || null,
    onInitialized: function (e) {
        if (savedId && savedTitle) {
            e.component.option("displayValue", savedTitle)
        }
    },
    contentTemplate: function (e) {
        let $finaldiv = $("<div>");

        let selectedUser = null

        const $grid = $("<div>").dxDataGrid({
            dataSource: userStore,
            columns: [
                "name",
                {
                    dataField: "image",
                    cellTemplate: function (container, options) {
                        $("<img>").attr("src", options.value).attr("height","50px").appendTo(container);
                    }
                }],
            selection: { mode: "single" },
            selectedRowKeys: [e.component.option("value")],
            paging: {
                enabled: true,
                pageSize: 5, 
            },
            onSelectionChanged: function (s) {
                selectedUser = s.selectedRowsData[0] || null
                e.component.option("value", selectedUser?.id)

                selectedUserId = selectedUser.id;
                childUser.option("dataSource", null);
                childUser.option("dataSource", subUserStore);
                childUser.option("contentTemplate", function () {
                    const $grid = $("<div>").dxDataGrid({
                        dataSource: subUserStore,
                        columns: ["name"],
                        selection: { mode: "single" }
                    })

                    return $grid;
                })

                if (selectedUser) {
                    sessionStorage.setItem("userId", selectedUser.id)
                    sessionStorage.setItem("name", selectedUser.name)
                }
            }
        }).appendTo($finaldiv)

        $("<div>").dxButton({
            text: "Add",
            icon: "plus",
            onClick: function () {
                const newTitle = prompt("Enter new user Name:")

                userStore.insert({ name: newTitle })
                    .then(res => {
                        console.log(res)
                        $grid.dxDataGrid("instance").refresh();
                    });
                
            }
        }).appendTo($finaldiv)
        $("<div>").dxButton({
            text: "Update",
            icon: "edit",
            onClick: function () {
                const grid = $grid.dxDataGrid("instance")
                const keys = grid.getSelectedRowKeys()

                const newTitle = prompt("Update user name:", "Updated Name")

                userStore.update(keys[0], { name: newTitle })
                    .then(res => {
                        console.log(res)
                        $grid.dxDataGrid("instance").refresh();
                    });
            }
        }).appendTo($finaldiv)
        $("<div>").dxButton({
            text: "Delete",
            icon: "trash",
            onClick: function () {
                const grid = $grid.dxDataGrid("instance")
                const keys = grid.getSelectedRowKeys()
                    
                userStore.remove(keys[0])
                    .then(res => {
                        console.log(res)
                        $grid.dxDataGrid("instance").refresh();
                    });
            }
        }).appendTo($finaldiv) 

        return $finaldiv;
    },
}).dxDropDownBox("instance")

const childUser = $("#childUser").dxDropDownBox({
    label: "Sub User",
    dataSource: subUserStore,
    valueExpr: "id",
    displayExpr: "name",
    contentTemplate: function () {
        const $grid = $("<div>").dxDataGrid({
            dataSource: subUserStore,
            columns: ["name"],
            selection: { mode: "single" }
        })

        return $grid;
    }

}).dxDropDownBox("instance")

