## Get a Single Property

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
var dataSource = dataGridInstance.option("dataSource");
var editMode = dataGridInstance.option("editing.mode");
 
// ---------- or ----------
var dataSource = $("#dataGridContainer").dxDataGrid("option", "dataSource");
var editMode = $("#dataGridContainer").dxDataGrid("option", "editing.mode");
```

## Get All Properties

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
var dataGridOptions = dataGridInstance.option();
 
// ---------- or ----------
var dataGridOptions = $("#dataGridContainer").dxDataGrid("option");
```

## Set a Single Property

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
dataGridInstance.option("dataSource", []);
dataGridInstance.option("editing.mode", "batch");
 
// ---------- or ----------
$("#dataGridContainer").dxDataGrid("option", "dataSource", []);
$("#dataGridContainer").dxDataGrid("option", "editing.mode", "batch");
```

## Set Several Properties

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
dataGridInstance.option({
    dataSource: [],
    editing: {
        mode: "cell"
    }
});
 
// ---------- or ----------
$("#dataGridContainer").dxDataGrid({
    dataSource: [],
    editing: {
        mode: "cell"
    }
});
```


## Call Methods

- To call a UI component method, pass its name to the jQuery plugin.

```js
var allSeries = $("#chartContainer").dxChart("getAllSeries");
```

- If a method accepts arguments, pass them right after the method's name.

```js
var fruitsSeries = $("#chartContainer").dxChart("getSeriesByName", "fruits");
```

```js
var chartInstance = $("#chartContainer").dxChart("instance");
var allSeries = chartInstance.getAllSeries();
var fruitsSeries = chartInstance.getSeriesByName("fruits");
```

## Get a UI Component Instance

```js
var chartInstance = $("#chartContainer").dxChart("instance");
```

- If the UI component is not yet instantiated, this code throws an E0009 exception that you can handle with a try...catch block:

```js
try {
    var chartInstance = $("#chartContainer").dxChart("instance");
}
catch (err) {
    alert("Exception handled: " + err.message);
}
```

## Handle Events

### Subscribe to an Event

- You can subscribe to an event using a configuration property. All event handling properties are given names that begin with on.

```js
$("#dataGridContainer").dxDataGrid({
    onCellClick: function (e) {
        // Handles the "cellClick" event
    },
    onSelectionChanged: function (e) {
        // Handles the "selectionChanged" event
    }
});
```

- As a more flexible solution, you can use the on() method. It allows you to subscribe to events at runtime and attach several handlers to a single event.

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
// Subscribes to the "cellClick" and "selectionChanged" events
dataGridInstance
    .on({
        "cellClick": cellClickHandler,
        "selectionChanged": selectionChangedHandler
    });

var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
// Attaches several handlers to the "cellClick" event
dataGridInstance
    .on("cellClick", cellClickHandler1)
    .on("cellClick", cellClickHandler2);
```

### Unsubscribe from an Event

```js
var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
// Detaches the "cellClickHandler1" from the "cellClick" event leaving other handlers (if any) intact
dataGridInstance.off("cellClick", cellClickHandler1)


var dataGridInstance = $("#dataGridContainer").dxDataGrid("instance");
// Detaches all handlers from the "cellClick" event
dataGridInstance.off("cellClick")
```

## Dispose of a UI Component

```js
$("#dataGridContainer").dxDataGrid("dispose");
$("#dataGridContainer").remove();
```

