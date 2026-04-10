
const orders = [
    { id: 1, statusId: 1 },
    { id: 2, statusId: 2 }
];

const statusList = [
    { id: 1, name: "Not Started" },
    { id: 2, name: "In Progress" }
];

$("#grid2").dxDataGrid({
    dataSource: orders,
    columns: [
        {
            dataField: "statusId",
            caption: "Status",
            lookup: {
                dataSource: statusList,
                valueExpr: "id",
                displayExpr: "name"
            }
        },
        {
            dataField: "id",
        }
    ]
})
