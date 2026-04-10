let url = "https://69c214b97518bf8facbd35ad.mockapi.io/users";

let columns = [
    {
        dataField: "id",
        width: "50px",
        alignment: "center",
        allowGrouping: false
    },
    {
        dataField: "name",
        alignment: "center",
        // customize form layout
        formItem: {
            rowSpan: 2,
            colSpan: 2,
            cssClass: "custom-class",
            editorType: 'dxTextBox',
            label: {
                location: "top"
            },
            editorOptions: {
                height: 100,
                label: "Name",
                labelMode: "floating",
            },
        },
        validationRules: [{ type: "required" }],

        // filter
        filterOperations: ["contains", "="], // filter options
        selectedFilterOperation: "contains", // selected
        filterValue: "a", //  value in filter by default
        filterType: "exclude", // or "include"
    },
    {
        dataField: "email",
        alignment: "center",
        validationRules: [{ type: "email" }, { type: "required" }],
        groupIndex: 1
    },
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
        groupIndex: 0 // to create group by this column

    },
    {
        dataField: "salary",
        alignment: "center",
        dataType: "number"
    }
]

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

        // ============================ Columns =============================
        columns: [
            {
                dataField: "id",
                width: "50px",
                alignment: "center",
                allowGrouping: false,
                // fixe to left side
                fixed: true
            },
            {
                dataField: "name",
                //allowReordering: false,
                alignment: "center",
                // customize form layout
                formItem: {
                    rowSpan: 2,
                    colSpan: 2,
                    cssClass: "custom-class",
                    editorType: 'dxTextBox',
                    label: {
                        location: "top"
                    },
                    editorOptions: {
                        height: 100,
                        label: "Name",
                        labelMode: "floating",
                    },
                },
                validationRules: [{ type: "required" }],

                // filter
                filterOperations: ["contains", "="], // filter options
                selectedFilterOperation: "contains", // selected
                filterValue: "a", //  value in filter by default
                filterType: "exclude", // or "include"

                // need to short base on lenght of the string
                sortingMethod: function (value1, value2) {
                    return value1.length - value2.length;
                }
            },
            {
                dataField: "email",
                alignment: "center",
                validationRules: [{ type: "email" }, { type: "required" }],
                groupIndex: 1
            },
            {
                dataField: "bod",
                alignment: "center",
                dataType: "date",
                // default show in Column selector
                visible: false
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
                groupIndex: 0, // to create group by this column

                // Apply Custom sorting
                sortOrder: "asc",
                sortIndex: 0,
                calculateSortValue: function (rowData) {
                    if (rowData.isActive == true) {
                        return "zzzzz"
                    } else {
                        return "aaaaa"
                    }
                }
            },
            {
                dataField: "salary",
                alignment: "center",
                dataType: "number",
                //width: 2000
            },

            // customize the config columns
            {
                type: "selection",
                //width: 50
            },
            {
                type: "buttons",
                buttons: [
                    {
                        text: "delete",
                        icon: "trash",
                    },
                    {
                        text: "Alert",
                        icon: "add",
                        hint: "Save Row",
                        onClick: function (e) {
                            alert("this is a custome button")
                        }
                    }],
                fixed: false,

            }
        ],

        // Reorder
        allowColumnReordering: true,
        // resize change width
        allowColumnResizing: true,
        // width based on inner content size
        columnAutoWidth: true,
        // Horizontal scrolling
        // not working
        //columnFixing: {enabled: true },

        columnChooser: { enabled: true },
        paging: {
            pageSize: 5
        },

        pager: {
            visible: true,
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 15, 30]
        },

        editing: {
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            confirmDelete: true,
            mode: "batch" // 'batch' | 'cell' | 'form' | 'popup'
        },

        // DEFAULT VALUE
        onInitNewRow: function (e) {
            console.log("init new row");
            e.data.bod = new Date();
        },

        // EVENTS
        onRowInserting: function (e) {
            console.log("before row insert", e);
        },

        onRowInserted: function (e) {
            console.log("after row insert", e);
        },

        onRowUpdating: function (e) {
            console.log("before row update", e);
        },

        onRowUpdated: function (e) {
            console.log("after row update", e);
        },

        onRowRemoving: function (e) {
            console.log("before row delete", e);
        },

        onRowRemoved: function (e) {
            console.log("after row delete", e);
        },


        // Form Editing

        onEditorPreparing: function (e) {
            if (e.dataField == "id")
                e.editorOptions.disabled = true;
        },


        // Grouping

        // add Grouping options on right click on column
        grouping: {
            contextMenuEnabled: true,
            expandMode: "rowClick",  // or "buttonClick"
            autoExpandAll: false,
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
                    name: "max",
                    alignByColumn: true
                },
                {
                    column: "salary",
                    summaryType: "min",
                    alignByColumn: true

                }
            ]
        },
        sortByGroupSummaryInfo: [{
            summaryItem: "max",  // or "count" | 0 | "OrderNumber"
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
        filterSyncEnabled: false, // change in filterpanel are sync to headerfilter and filter row


        // State Storing

        stateStoring: {
            enabled: true,
            type: "localStorage",
            storageKey: "myGrid",
            savingTimeout: 500
        },


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


        // toolbar customization
        toolbar: {
            items: [
                "searchPanel",

                "groupPanel",
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        text: "Collapse All",
                        width: 136,
                        onClick(e) {
                            const expanding = e.component.option("text") === "Expand All";
                            gridInstance.option("grouping.autoExpandAll", expanding);
                            e.component.option("text", expanding ? "Collapse All" : "Expand All");
                        },
                    },
                },
                {
                    name: "addRowButton",
                    showText: "always"
                },
                "exportButton",
                "columnChooserButton",
                "revertButton",
                "saveButton",
                {
                    location: "top",
                    widget: "dxButton",
                    options: {
                        icon: "refresh",
                        onClick(e) {
                            gridInstance.refresh()
                        }
                    }
                }
            ]
        }


    }).dxDataGrid("instance");

    // Add new row initially
    gridInstance.addRow();

    // Update button
    $("#btn").dxButton({
        text: "Update First Row",
        onClick: function () {
            gridInstance.cellValue(0, "name", "temp");
            gridInstance.saveEditData();
        }
    });

    // Delete button
    $("#btn2").dxButton({
        text: "Delete First Row",
        onClick: function () {
            gridInstance.deleteRow(0);
        }
    });


    // FilterBuilder
    $("#filterBuilder").dxFilterBuilder({
        fields: columns
    });

    // button to apply filter builder's filter to datagrid
    $("#applyFilter").dxButton({
        text: "Apply Filter",
        onClick: function () {
            var filter = $("#filterBuilder").dxFilterBuilder("instance").getFilterExpression();
            $("#grid").dxDataGrid("instance").filter(filter);
        },
    });

    // Clear Filter
    $("#clearFilter").dxButton({
        text: "Clear Filter",
        onClick: function () {
            $("#grid").dxDataGrid("instance").clearFilter();
        }
    })

    // Sorting
    $("#grid").dxDataGrid({
        sorting: {
            mode: "multiple",

            // give text to the menu open when right click on column header
            ascendingText: "Sort A → Z",
            descendingText: "Sort Z → A",
            clearText: "Remove Sorting"
        }
    })

    // Selection
    $("#grid").dxDataGrid({
        selection: {
            mode: "multiple", // or "single" | "none"
            selectAllMode: "page", // or "allPages"
            //allowSelectAll: false,
            showCheckBoxesMode: "onLongTap"    // or "onClick" | "onLongTap" | "always" | "none"
        },
        hoverStateEnabled: true,
        focusedRowEnabled: true,
        // alredy selected row
        keyExpr: "id",
        selectedRowKeys: [9, 12, 13]
    })

    $("#textbox").dxTextBox({
        label: "Enter Ids value to select",
        labelMode: "floating"
    })

    $("#select").dxButton({
        text: "Select",
        onClick: function () {
            let val = $("#textbox").dxTextBox("instance").option("value");

            let arr = val.split(",").map(val => Number(val))
            console.log(arr);

            gridInstance.selectRows(arr, true);
        }
    })

    $("#deselect").dxButton({
        text: "Remove Selection",
        onClick: function () {
            let val = $("#textbox").dxTextBox("instance").option("value");

            let arr = val.split(",").map(val => Number(val))
            console.log(arr);

            gridInstance.deselectRows(arr, true);
        }
    })


});
