let url = "https://69c214b97518bf8facbd35ad.mockapi.io/users";

let dataSource = new DevExpress.data.CustomStore({
    key: "id",

    load: function () {
        return $.ajax({
            url: url,
            method: "GET"
        });
    },

    insert: function (vals) {
        return $.ajax({
            url: url,
            method: "POST",
            data: vals
        });
    },

    update: function (id, vals) {
        return $.ajax({
            url: url + "/" + id,
            method: "PUT",
            data: vals
        });
    },

    remove: function (id) {
        return $.ajax({
            url: url + "/" + id,
            method: "DELETE"
        });
    }
})


$(function () {
    let gridInstance = $("#grid").dxDataGrid({
        dataSource: dataSource,
        editing: {
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            confirmDelete: true,
            mode: "batch" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
            //mode: "row" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
            //mode: "cell" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
            //mode: "form" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
            //mode: "popup" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
        },
    });
})