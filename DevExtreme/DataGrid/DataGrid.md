## Data Binding

### Array

```js
$(function() {
    const employees = [
        { ID: 1, FirstName: "Sandra", LastName: "Johnson" },
        { ID: 2, FirstName: "James", LastName: "Scott" },
        { ID: 3, FirstName: "Nancy", LastName: "Smith" }
    ];
 
    $("#dataGridContainer").dxDataGrid({
        dataSource: employees,
        keyExpr: "ID"
    });
});
```

```js
$(function() {
    const employees = [
        { ID: 1, FirstName: "Sandra", LastName: "Johnson" },
        { ID: 2, FirstName: "James", LastName: "Scott" },
        { ID: 3, FirstName: "Nancy", LastName: "Smith" }
    ];

    const employeesStore = new DevExpress.data.ArrayStore({
        data: employees,
        key: "ID",
        onLoaded: function() {
            // ...
        }
    });
 
    const employeesDataSource = new DevExpress.data.DataSource({
        store: employeesStore,
        sort: "LastName"
    });
 
    $("#dataGridContainer").dxDataGrid({
        dataSource: employeesDataSource
    });
});
```

### Ajax

```js
let url = "https://69c214b97518bf8facbd35ad.mockapi.io/users"

let store = new DevExpress.data.CustomStore({
    key: "id",
    load: function () {
        return $.ajax({
            url: url,
            method: "get"
        })
    }
});

$("#grid").dxDataGrid({
    dataSource: store,
    key: "id"
})
```

```js
$("#grid").dxDataGrid({
    dataSource: {
        load: function () {
            return $.ajax({
                url: url,
                method: "GET"
            });
        }
    },
    columns: ["id", "name", "email"]
})
```

## Paging

| Option                        | Type               | Description                    |
| ----------------------------- | ------------------ | ------------------------------ |
| `paging.enabled`              | boolean            | Enable/disable paging          |
| `paging.pageSize`             | number             | Records per page               |
| `paging.pageIndex`            | number             | Current page (0-based)         |
| `pager.visible`               | boolean            | Show pager UI                  |
| `pager.showPageSizeSelector`  | boolean            | Allow user to change page size |
| `pager.allowedPageSizes`      | array              | Page size options              |
| `pager.showInfo`              | boolean            | Show "Page 1 of X"             |
| `pager.showNavigationButtons` | boolean            | Show next/prev buttons         |
| `pager.displayMode`           | "full" / "compact" | Pager UI style                 |


```js
paging: {
    pageSize: 5
},

pager: {
    visible: true,
    showPageSizeSelector: true,
    allowedPageSizes: [5, 10, 15],
    showInfo: true,
    showNavigationButtons: true,
    displayMode: "compact"
}
```

## Scroling

- how data is rendered and loaded when user scrolls.

| Mode       | Description      | Data Handling           | Best For       |
| ---------- | ---------------- | ----------------------- | -------------- |
| `standard` | Normal scrolling | Loads all data          | Small data     |
| `virtual`  | Lazy loading     | Loads visible rows only | 🔥 Large data  |
| `infinite` | Endless scroll   | Appends data            | Social/feed UI |


| Property              | Type             | Default      | Purpose                    |
| --------------------- | ---------------- | ------------ | -------------------------- |
| `mode`                | string           | `"standard"` | Scrolling type             |
| `rowRenderingMode`    | string           | `"standard"` | Row rendering optimization |
| `columnRenderingMode` | string           | `"standard"` | Column virtualization      |
| `preloadEnabled`      | boolean          | `false`      | Preload next data          |
| `useNative`           | boolean / "auto" | `"auto"`     | Native scroll              |
| `scrollByContent`     | boolean          | `true`       | Touch scroll               |
| `scrollByThumb`       | boolean          | `true`       | Scrollbar drag             |
| `showScrollbar`       | string           | `"onHover"`  | Scrollbar visibility       |


## Editing

```js
editing: {
    allowUpdating: true, 
    allowAdding: true, 
    allowDeleting: true,
    mode: 'row' // 'batch' | 'cell' | 'form' | 'popup'
},
```

### APIs

#### 1. Add

- Use the ***addRow()*** method to add an empty row.

```js
$("#dataGridContainer").dxDataGrid("addRow");
```

- You can specify initial values for a newly added row in the ***onInitNewRow*** event handler.

```js
 $("#dataGridContainer").dxDataGrid({
    // ...
    columns: [{
        dataField: "Hire_Date",
        dataType: "date"
    },
        // ...
    ],
    onInitNewRow: function(e) {
        e.data.Hire_Date = new Date();
    }
});
```

#### 2. Update

- The ***cellValue(rowIndex, visibleColumnIndex, value)*** method updates a cell's value.
- After a value is updated, save it to the data source by calling the ***saveEditData()*** method.

```js
$("#updateCellButton").dxButton({
    text: "Update Cell",
    onClick: function() {
        $("#dataGridContainer").dxDataGrid("cellValue", 1, "Position", "CTO");
        $("#dataGridContainer").dxDataGrid("saveEditData");
    }
});
```

- You can check if there are any unsaved changes by calling the ***hasEditData()*** method. Use the ***saveEditData()*** or ***cancelEditData()*** method to save or cancel them

```js
$("#saveChangesButton").dxButton({
    text: "Save changes",
    onClick: function() {
        var dataGrid = $("#dataGridContainer").dxDataGrid("instance");
        if(dataGrid.hasEditData()) {
            dataGrid.saveEditData().then(() => {
                if(!dataGrid.hasEditData()) {
                    // Saved successfully
                } else {
                    // Saving failed
                }
            });
        }
    }
});
```

#### 3. Delete

-  ***deleteRow(rowIndex)*** method to delete a specific row from the data source.
- This method invokes a confirmation dialog that allows a user to cancel deletion.
- The ***confirmDelete*** property allows you to hide this dialog instantly deleting the selected row from the data source.

```js
$(function() {
    var dataGrid = $("#dataGridContainer").dxDataGrid({
        // ...
        editing: {
            mode: "row", 
            allowDeleting: true,
            confirmDelete: false
        }
    }).dxDataGrid("instance");
 
    $("#deleteRowButton").dxButton({
        text: "Delete Row",
        onClick: function() {
            // Deletes the second row
            dataGrid.deleteRow(1);
        }
    });
});
```

- Note that in batch mode a row is only marked as deleted.
- To save changes, call the ***saveEditData()*** method.
- Calling the ***undeleteRow(rowIndex)*** method cancels row deletion.

```js
$("#dataGridContainer").dxDataGrid("undeleteRow", 1);
```

#### 4. Get Current Cell Values

- To get current cell values (saved or unsaved), call ***cellValue(rowIndex, dataField)***.
- To get row indexes, you can utilize ***getRowIndexByKey(key)***.

### Events

1. onRowInserting
2. onRowInserted
3. onRowUpdating
4. onRowUpdated
5. onRowRemoving
6. onRowRemoved

- In addition, the DataGrid raises the ***initNewRow*** event when a new row is added and the ***editingStart*** event when a row enters the editing state. 

### Customize Editor

#### 1. editorOptions

```js
$("#grid").dxDataGrid({
    columns: [
        {
            dataField: "Note",
            editorOptions: {
                height: 150,
                placeholder: "Enter note..."
            }
        }
    ]
});
```

#### 2. onEditorPreparing

```js
onEditorPreparing: function(e) {
    // e contains full editor context
}
```

| Property          | Description                               |
| ----------------- | ----------------------------------------- |
| `e.dataField`     | Column name                               |
| `e.editorName`    | Editor type (can change)                  |
| `e.editorOptions` | Editor configuration                      |
| `e.parentType`    | Where editor is used (dataRow, filterRow) |
| `e.row`           | Row data                                  |
| `e.setValue()`    | Set value manually                        |

```js
onEditorPreparing: function(e) {
    if (e.dataField === "Note") {
        e.editorName = "dxTextArea"; // change TextBox → TextArea
    }
}


onEditorPreparing: function(e) {
    if (e.dataField === "Note") {

        const defaultHandler = e.editorOptions.onValueChanged;

        e.editorOptions.onValueChanged = function(args) {

            console.log("New Value:", args.value);

            // Update grid value
            e.setValue(args.value);

            // OR call default behavior
            defaultHandler(args);
        };
    }
}


onEditorPreparing: function(e) {
    if (e.dataField === "LastName" && e.parentType === "dataRow") {

        e.editorOptions.disabled =
            e.row.data.FirstName === "";
    }
}
```

#### 3. editCellTemplate

```js
columns: [{
    dataField: "isActive",
    editCellTemplate: function(cellElement, cellInfo) {

        $("<input type='checkbox'>")
            .prop("checked", cellInfo.value)
            .on("change", function(e) {
                cellInfo.setValue(e.target.checked);
            })
            .appendTo(cellElement);
    }
}]
```

### Form Layout

```js
columns: [
    {
        dataField: "ID",
        formItem: {
            visible: false
        }
    }, 
    {
        dataField: "Notes",
        formItem: {
            colSpan: 2, 
            cssClass: "custom-class",
            editorType: 'dxTextArea',
            label: {
                location: "top"
            },
            editorOptions: {    
                height: 100,
                labelMode: "floating"
            },
        }
    }
]
```

## Validation

- add ValidationRules in Columns

```js
columns: [
    {
        dataField: "id",
        width: "50px",
        alignment: "center",
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
        validationRules: [{ type: "required" }]
    },
    {
        dataField: "email",
        alignment: "center",
        validationRules: [{ type: "email" }, {type: "required"}]
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
        }
    }
]
```

## Grouping

```js
// add Grouping options on right click on column
grouping: {
    contextMenuEnabled: true,
    expandMode: "rowClick",  // or "buttonClick"
    autoExpandAll: false, // by default expanded all true or false
    allowCollapsing: true // false
},
// allow group panel with drag and drop feature
groupPanel: {
    visible: true,   // or "auto"
    allowColumnDragging: true, // false
},

// default grouping when app start/load
columns: [
    { dataField: 'Country', groupIndex: 1 },
    { dataField: 'Continent', groupIndex: 0 },
]
```

### Methods
```js
// Exapnd all groups from 0 to groupIndex
dataGrid.expandAll(groupIndex);

// collapse all group from 0 to groupIndex
dataGrid.collapseAll(groupIndex);

// to clear all grouping
dataGrid.clearGrouping();
```

### Events

```js
$("#dataGridContainer").dxDataGrid({
    onRowExpanding: function (e) {
        // Handler of the "rowExpanding" event
    },
    onRowExpanded: function (e) {
        // Handler of the "rowExpanded" event
    },
    onRowCollapsing: function (e) {
        // Handler of the "rowCollapsing" event
    },
    onRowCollapsed: function (e) {
        // Handler of the "rowCollapsed" event
    }
});
```

### Summary

```js
summary: {
    recalculateWhileEditing: true,
    groupItems: [
        {
            column: "id",
            summaryType: "count", // min, max, sum, avg, custom
        },
        {
            column: "salary",
            summaryType: "sum",
            showInGroupFooter: true
        },
        {
            column: "salary",
            summaryType: "max",
            alignByColumn: true
        },
        {
            column: "salary",
            summaryType: "min",
            alignByColumn: true
        }
    ]
} 
```

- custom summaryType

```js
summary: {
    totalItems: [
        { name: "customSummary1", summaryType: "custom" },
        { name: "customSummary2", summaryType: "custom" }
    ],
    calculateCustomSummary: function(options) {
        // Calculating "customSummary1"
        if(options.name == "customSummary1") {
            switch(options.summaryProcess) {
                case "start":
                    // Initializing "totalValue" here
                    break;
                case "calculate":
                    // Modifying "totalValue" here
                    break;
                case "finalize":
                    // Assigning the final value to "totalValue" here
                    break;
            }
        }

        // Calculating "customSummary2"
        if(options.name == "customSummary2") {
            // ...
            // Same "switch" statement here
        }
    }
}
```

- Sort by Group Summary

```js
$("#dataGridContainer").dxDataGrid({
    summary: {
        groupItems: [{
            column: "OrderNumber",
            summaryType: "count",
            name: "Total Count"
        }
        ]
    },
    sortByGroupSummaryInfo: [{
        summaryItem: "Total Count",  // or "count" | 0 | "OrderNumber"
        sortOrder: "desc"            // or "asc"
    }]
});
```

## Filter


```js
filterRow: { 
    visible: true,
    applyFilter: "onClick" //  
},
columns: [{
    allowFiltering: false
}]
```

- in column

```js
columns: [
    {
        dataField: "id",
        // filter
        filterOperations: ["contains", "="], // filter options display when click on search
        selectedFilterOperation: "contains", // selected 
        filterValue: "Pending" //  value in filter by default
    }
 ]
```

### Header Filtering

```js
("#dataGridContainer").dxDataGrid({
    // ...
    headerFilter: { visible: true },
    columns: [{
        // ...
        allowHeaderFiltering: false
    }]
});

// columnvise

$("#dataGridContainer").dxDataGrid({
    // ...
    columns: [{
        // ...
        dataField: "OrderDate",
        filterType: "exclude", // or "include"
        filterValues: [2014],
        filterValues: [2014]
    }]
});
```

### Search Panel

- allow to serach in multiple column 

```js
searchPanel: { visible: true },

columns: [{
            // ...
            allowSearch: false
        }]
```

### filterPanel

```js
var dataGrid = $("#dataGridContainer").dxDataGrid({
    // ...
    filterPanel: { visible: false },
    filterSyncEnabled: true,
    filterBuilder: {
        customOperations: [{
            name: "isZero",
            caption: "Is Zero",
            dataTypes: ["number"],
            hasValue: false,
            calculateFilterExpression: function(filterValue, field) {
                return [field.dataField, "=", 0];
            }
        }]
    }, 
    filterBuilderPopup: {
        width: 400,
        title: "Synchronized Filter"
    }
}).dxDataGrid("instance");

$("#button").dxButton({
    text: "Show Filter Builder",
    onClick: function () {
        dataGrid.option("filterBuilderPopup", { visible: true });
    }
});
```

### Standalone Filter Builder

```js
// FilterBuilder
// create filter expresson builder
$("#filterBuilder").dxFilterBuilder({
    fields: columns
});

// button to apply filter builder filter to datagrid
$("#applyFilter").dxButton({
    text: "Apply Filter",
    onClick: function () {
        var filter = $("#filterBuilder").dxFilterBuilder("instance").getFilterExpression();
        $("#grid").dxDataGrid("instance").filter(filter);
    },
});
```

### Clear all Filters

```js
// Clear Filter
$("#clearFilter").dxButton({
    text: "Clear Filter",
    onClick: function () {
        $("#grid").dxDataGrid("instance").clearFilter();
    }
})
```

## Sorting

### Sorting Mode

```js
 $("#dataGridContainer").dxDataGrid({
    sorting: {
        mode: "single" // or "multiple" | "none"
    }
});
```

- In single mode, the user can click a column header to sort by the column. Subsequent clicks on the same header reverse the sort order. When the user sorts by a column, the sorting settings of other columns are canceled.

- In multiple mode, the user clicks a column header while pressing the Shift key to sort by the column. Sorting settings of other columns remain intact.

- To disable sorting in the whole UI component, set the sorting.mode property to "none"
- to disable sorting only in a specific column, use its allowSorting property.

```js
columns: [{
    // ...
    allowSorting: false
}]
```

### Initial and Runtime Sorting

- give sort order and sort index to all columns

```js
columns: [
    { dataField: "City",    sortIndex: 1, sortOrder: "asc" },
    { dataField: "Country", sortIndex: 0, sortOrder: "desc" },
    // ...
]
```

### Custom Sorting

#### calculateSortValue

```js
const dataGrid = $("#dataGridContainer").dxDataGrid({
    columns: [{
        dataField: "Position",
        sortOrder: "asc",
        calculateSortValue: function (rowData) {
            if (rowData.Position == "CEO")
                return dataGrid.columnOption('Position', 'sortOrder') == 'asc' ? "aaa" : "zzz"; // CEOs are always displayed at the top  
            else
                return rowData.Position; // Others are sorted as usual
        }
    }]
}).dxDataGrid("instance");
```

#### sortingMethod

```js
columns: [{
    dataField: 'State',
    sortingMethod: function (value1, value2) {
        return value1.length - value2.length;
    }
}]
```

### Clear Sorting 

```js
dataGrid.columnOption("Name", "sortIndex", undefined);
dataGrid.clearSorting();
```

## Selection

```js
selection: {
    mode: "single", // or "multiple" | "none"
    selectAllMode: "page", // or "allPages"
    allowSelectAll: false,
    showCheckBoxesMode: "onLongTap"    // or "onClick" | "onLongTap" | "always" | "none"
}
```

- ***showCheckBoxesMode*** the property specifies when the UI component renders checkboxes in the selection column.

### Methods to select row

- ***selectRows(keys, preserve)*** and ***selectRowsByIndexes(indexes)***.
- both clear the previous selection by default,
- although with the selectRows(keys, preserve) method you can keep it if you pass true as the preserve parameter

- Before selecting a row, you can call the ***isRowSelected(key)*** method to check if this row is not already selected.

- To select all rows at once, call the ***selectAll()*** method

```js
if (!dataGridInstance.isRowSelected(key)) {
    dataGridInstance.selectRows([key], preserve);
}

$("#dataGridContainer").dxDataGrid({
    // ...
    onContentReady: function (e) {
        // Selects the first visible row
        e.component.selectRowsByIndexes([0]);
    }
})

dataGrid.selectAll()
```

- Call the ***getSelectedRowKeys()*** or ***getSelectedRowsData()*** method to get the selected row's keys or data.

```js
var dataGrid = $("#dataGridContainer").dxDataGrid("instance");
var selectedKeys = dataGrid.getSelectedRowKeys();
var selectedData = dataGrid.getSelectedRowsData();
```

- Call the deselectRows(keys) method to clear the selection of specific rows

```js
$("#dataGridContainer").dxDataGrid("deselectRows", [1, 4, 10]);
```

- Call the clearSelection() method to clear selection of all rows. If you apply a filter and want to keep the selection of invisible rows that do not meet the filtering conditions, use the deselectAll() method. 

```js
var dataGrid = $("#dataGridContainer").dxDataGrid("instance");
dataGrid.deselectAll();
dataGrid.clearSelection();
```

### Events

- The DataGrid UI component raises the ***selectionChanged*** event when a row is selected, or the selection is cleared. If the function that handles this event is going to remain unchanged, assign it to the ***onSelectionChanged*** property when you configure the UI component.

```js

$("#dataGridContainer").dxDataGrid({
    onSelectionChanged: function(e) { // Handler of the "selectionChanged" event
        var currentSelectedRowKeys = e.currentSelectedRowKeys;
        var currentDeselectedRowKeys = e.currentDeselectedRowKeys;
        var allSelectedRowKeys = e.selectedRowKeys;
        var allSelectedRowsData = e.selectedRowsData;
        // ...
    }
});
```