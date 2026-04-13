let url = "http://localhost:5268/user";

let dataSource = new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "processed", 

    load: function (loadOptions) {
        const params = {};

        // These are the keys DataSourceLoader expects: 
        // filter, sort, group, skip, take, totalSummary, groupSummary, select
        [
            "skip", "take", "requireTotalCount", "requireGroupCount",
            "sort", "filter", "totalSummary", "groupSummary", "group", "select"
        ].forEach(i => {
            if (i in loadOptions && loadOptions[i] !== undefined && loadOptions[i] !== null) {
                // DataSourceLoader expects objects (filter/sort) to be JSON strings
                params[i] = JSON.stringify(loadOptions[i]);
            }
        });

        return fetch(url + "?" + new URLSearchParams(params))
            .then(res => {
                if (!res.ok) throw new Error("Network response was not ok");
                return res.json();
            })
            .then(result => {
                return {
                    data: result.data,
                    totalCount: result.totalCount,
                    summary: result.summary,
                    groupCount: result.groupCount
                };
            });
    },

    insert: function (values) {
        return fetch(url, {
            method: "POST",
            body: JSON.stringify(values),
            headers: { 'Content-Type': 'application/json' }
        }).then(res => res.json());
    },

    update: function (key, values) {
        return fetch(`${url}/${key}`, {
            method: "PATCH",
            body: JSON.stringify(values),
            headers: { 'Content-Type': 'application/json' }
        }).then(res => res.json());
    },

    remove: function (key) {
        return fetch(`${url}/${key}`, {
            method: "DELETE"
        });
    }
});



let columns = [
    {
        dataField: "id",
        width: "50px",
        alignment: "center",
        allowGrouping: false,
    },
    {
        dataField: "name",
        alignment: "center",
    },
    {
        dataField: "email",
        alignment: "center",
        validationRules: [{ type: "email" }, { type: "required" }],
    },
    //{
    //    caption: "dates",
    //    columns: [
    //        {
    //            caption:"StartDate",
    //            dataField: "bod",
    //            alignment: "center",
    //            dataType: "date",
    //        },
    //        {
    //            caption:"EndDate",
    //            dataField: "bod",
    //            alignment: "center",
    //            dataType: "date",
    //        }
    //    ]

    //},
    {
        dataField: "bod",
        alignment: "center",
        dataType: "date",
    },
    {
        dataField: "isActive",
        alignment: "center",
        width: "50px",
        dataType: "boolean",
        editCellTemplate: function (cellElement, cellInfo) {

            $("<input type='checkbox'>")
                .prop("checked", cellInfo.value)
                .on("change", function (e) {
                    cellInfo.setValue(e.target.checked);
                })
                .appendTo(cellElement);
        },
    },
    {
        dataField: "salary",
        alignment: "center",
        dataType: "number",
    },
];

$(function () {

    let gridInstance = $("#grid").dxDataGrid({
        dataSource: dataSource,

        // ============================ Columns =============================
        columns: columns,

        remoteOperations: {
            filtering: true,
            paging: true,
            sorting: true,
            groupPaging: true,
            grouping: true,
            summary: true
        },

        height: 500,

        scrolling: {
            mode: "infinite",
            //mode: "virtual",
            rowRenderingMode: "virtual",
            preloadEnabled: false
        },

        // Reorder
        allowColumnReordering: true,
        // resize change width
        allowColumnResizing: true,
        // width based on inner content size
        columnAutoWidth: true,

        columnChooser: { enabled: true },

        paging: {
            pageSize: 10
        },

        pager: {
            visible: true,
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 15, 30]
        },

        // Editing
        editing: {
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            confirmDelete: true,
            mode: "batch" // 'row' | 'cell' | 'batch' | 'form' | 'popup'
        },
        // Form Editing

        onEditorPreparing: function (e) {
            console.log("Editor preparing")
            if (e.dataField == "id")
                e.editorOptions.disabled = true;
        },


        // Grouping

        // add Grouping options on right click on column
        grouping: {
            contextMenuEnabled: true,
            expandMode: "rowClick",  // or "buttonClick"
            autoExpandAll: true,
            allowCollapsing: true
        },
        // allow group panel with drag and drop feature
        groupPanel: {
            visible: true,   // or "auto"
            allowColumnDragging: true, // false
        },

        // Group Summary
        summary: {
            recalculateWhileEditing: true,
            groupItems: [
                {
                    column: "id",
                    summaryType: "count" // min, max, sum, avg, custom
                },
                {
                    column: "salary",
                    summaryType: "sum",
                    showInGroupFooter: true
                },
                {
                    column: "salary",
                    summaryType: "max",
                    name: "NameForSorting",
                    alignByColumn: true
                },
                {
                    column: "salary",
                    summaryType: "min",
                    alignByColumn: true

                }
            ],
            totalItems: [
                {
                    column: "salary",
                    summaryType: "sum",
                    alignByColumn: true,
                }
            ]
        },
        sortByGroupSummaryInfo: [{
            summaryItem: "NameForSorting",  // or "count" | 0 | "OrderNumber"
            sortOrder: "asc"            // or "asc"
        }],

        // filter

        filterRow: {
            visible: true,
            //applyFilter: "onClick"
        },
        headerFilter: {
            visible: true,
            allowSearch: true, // search the value to filter
        },
        searchPanel: { visible: true },
        filterPanel: { visible: true },
        filterSyncEnabled: true, // change in filterpanel are sync to headerfilter and filter row


        // Cell Appeareince

        onCellPrepared: function (e) {
            if (e.rowType === "data") {
                if (e.column.dataField === "salary") {
                    if (e.data.salary < 200) {
                        e.cellElement.addClass("LowSalary");
                    } else if (e.data.salary > 500) {
                        e.cellElement.addClass("HighSalary");
                    }
                }
            }
        },

        // row 
        onRowPrepared: function (e) {
            if (e.rowType === "data") {
                if (e.data.isActive == false) {
                    e.rowElement.addClass("notActive");
                }
            }
        },



    }).dxDataGrid("instance");

});
