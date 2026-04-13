
const orders = [
    { id: 1, name: "order1", statusId: 1 },
    { id: 2, name: "order2", statusId: 2 },
    { id: 3, name: "order3", statusId: 1 },
    { id: 4, name: "order4", statusId: 1 },
    { id: 5, name: "order5", statusId: 2 },
    { id: 6, name: "order6", statusId: 2 }
];

const statusList = [
    { id: 1, name: "Not Started" },
    { id: 2, name: "In Progress" }
];

$("#grid2").dxDataGrid({
    dataSource: orders,
    columns: [
        {
            dataField: "id",
        },
        {
            dataField: "name",
        },
        {
            dataField: "statusId",
            caption: "Status",
            lookup: {
                dataSource: statusList,
                valueExpr: "id",
                displayExpr: "name"
            }
        }
        
    ]
})
