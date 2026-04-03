## create

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
    <!-- DevExtreme CSS -->
    <link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/24.2.3/css/dx.light.css">

    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- DevExtreme JS -->
    <script src="https://cdn3.devexpress.com/jslib/24.2.3/js/dx.all.js"></script>
</head>
<body>
    <div id="grid"></div>
    <script>
        let url = "https://69c214b97518bf8facbd35ad.mockapi.io/users"

        var data = new DevExpress.data.DataSource({
            // load data from api
            load: function () {
                return fetch(url).then(res => res.json())
            },
            // apply filter to data
            filter: [
                [["id", ">", 10],
                    "and",
                ["id", "<=", 15]],
                "and",
                ["!", ["name", "startswith", "A"]]
            ],
            // map data to new format 
            //map: function (item) {
            //    return { nid: item.name + " " + item.id, name: item.name, id: item.id }
            //},
            // group maped data based on column list
            //group: ["id"],
            // call when load, change, ddl close, ddl open
            onChanged: function (e) {
                console.log(e) // undefine, not available
                console.log("changed")
            },
            // call when load function faild and give error
            onLoadError: function (e) {
                console.log(e); // print the error message
                console.log("load error")
            },
            // call when loading status changed
            onLoadingChanged: function (e) {
                console.log(e) // true = loading, false = loded
                console.log("loading state changed")
            },
            pageSize: 3, // row count on one page
            paginate: true, // load data for current page only from database,
            requireTotalCount: true, // rewuire total data count
            //searchExpr: ["name"],
            //searchOperation: "contains",
            //searchValue: "john",
            //select: ["id"],
            sort: [{selector: "id",desc:true}]
        })

        $("#grid").dxDataGrid(
            { dataSource: data }
        );
    </script>
</body>
</html>
```

## options

| Option  | Type          | Purpose               | How It Works                  | Example               | Important Notes                                     |
| ------- | ------------- | --------------------- | ----------------------------- | --------------------- | --------------------------------------------------- |
| `store` | Array / Store | Defines data source   | Connects to local data or API | `store: data`         | Core property (mandatory)         |
| `load`  | Function      | Custom data loading   | Fetches data manually         | `load: () => fetch()` | Used for APIs (CustomStore style) |
| `byKey` | Function      | Get single item by ID | Fetch specific record         | `byKey: (id) => {}`   | Used in edit/view operations      |




| Option            | Type                | Purpose           | Example            | Notes                                    |
| ----------------- | ------------------- | ----------------- | ------------------ | ---------------------------------------- |
| `filter`          | Array               | Complex filtering | `["age", ">", 18]` | Advanced conditions                      |
| `searchExpr`      | String/Array        | Fields to search  | `["name"]`         | Works with searchValue |
| `searchOperation` | String              | Search condition  | `"contains"`       | Default = contains     |
| `searchValue`     | Any                 | Value to search   | `"john"`           | Required for search                      |
| `group`           | String/Object       | Group data        | `"country"`        | Groups records                           |
| `sort`            | String/Object/Array | Sorting           | `"name"`           | Can be multiple        |
| `select`          | Array               | Select fields     | `["id","name"]`    | Limits output fields   |



| Option                   | Type    | Purpose                       | Example | Notes                                         |
| ------------------------ | ------- | ----------------------------- | ------- | --------------------------------------------- |
| `paginate`               | Boolean | Enable paging                 | `true`  | Default depends on grouping |
| `pageSize`               | Number  | Items per page                | `10`    | Default = 20                |
| `requireTotalCount`      | Boolean | Total records count           | `true`  | Needed for pagination UI                      |
| `reshapeOnPush`          | Boolean | Reapply operations on updates | `true`  | For realtime updates                          |
| `pushAggregationTimeout` | Number  | Delay updates                 | `500`   | Performance optimization                      |




| Option        | Type     | Purpose             | Example                      | Notes                             |
| ------------- | -------- | ------------------- | ---------------------------- | --------------------------------- |
| `map`         | Function | Modify each item    | `map: item => {...}`         | Runs before UI  |
| `postProcess` | Function | Modify final result | `postProcess: data => {...}` | Runs after load |



| Option             | Type     | Trigger            | Example                  | Notes                            |
| ------------------ | -------- | ------------------ | ------------------------ | -------------------------------- |
| `onChanged`        | Function | After data load    | `onChanged: () => {}`    | Data updated   |
| `onLoadError`      | Function | On error           | `onLoadError: err => {}` | Error handling |
| `onLoadingChanged` | Function | Loading start/stop | `(isLoading)=>{}`        | For loaders    |


## Methods

### Loading Methods

| Method                | Type     | Purpose               | How It Works                                  | Example                      | Important Notes                                      |
| --------------------- | -------- | --------------------- | --------------------------------------------- | ---------------------------- | ---------------------------------------------------- |
| `load()`              | Function | Load data manually    | Calls store/load function and returns Promise | `ds.load().then(data => {})` | Returns Promise with `operationId` |
| `reload()`            | Function | Reload data           | Clears data and calls `load()` again          | `ds.reload()`                | Keeps same page index              |
| `cancel(operationId)` | Function | Cancel load operation | Cancels processing of load                    | `ds.cancel(p.operationId)`   | Does NOT stop HTTP request         |



### State Methods

| Method         | Type   | Purpose              | Returns | Example           | Notes                                    |
| -------------- | ------ | -------------------- | ------- | ----------------- | ---------------------------------------- |
| `isLoaded()`   | Getter | Check if data loaded | Boolean | `ds.isLoaded()`   | True after load                          |
| `isLoading()`  | Getter | Check loading status | Boolean | `ds.isLoading()`  | Useful for loaders                       |
| `isLastPage()` | Getter | Check last page      | Boolean | `ds.isLastPage()` | Works only with paging |



### Data Access Methods

| Method         | Type   | Purpose          | Returns | Example           | Notes                                               |
| -------------- | ------ | ---------------- | ------- | ----------------- | --------------------------------------------------- |
| `items()`      | Getter | Get current data | Array   | `ds.items()`      | Only current page data            |
| `totalCount()` | Getter | Total records    | Number  | `ds.totalCount()` | Works if `requireTotalCount=true` |
| `key()`        | Getter | Get primary key  | String  | `ds.key()`        | Comes from store                  |


### Paging Methods

| Method             | Type   | Purpose               | Example                          | Notes                             |
| ------------------ | ------ | --------------------- | -------------------------------- | --------------------------------- |
| `pageIndex()`      | Getter | Get current page      | `ds.pageIndex()`                 | 0-based index                     |
| `pageIndex(value)` | Setter | Set page index        | `ds.pageIndex(1); ds.load();`    | Must call `load()`                |
| `pageSize()`       | Getter | Get page size         | `ds.pageSize()`                  | Default ~20                       |
| `pageSize(value)`  | Setter | Set page size         | `ds.pageSize(10); ds.load();`    | Reload required                   |
| `paginate()`       | Getter | Check paging enabled  | `ds.paginate()`                  | Boolean                           |
| `paginate(value)`  | Setter | Enable/disable paging | `ds.paginate(false); ds.load();` | Reload required |

### Filtering Methods

| Method         | Type   | Purpose               | Example                                 | Notes                                  |
| -------------- | ------ | --------------------- | --------------------------------------- | -------------------------------------- |
| `filter()`     | Getter | Get filter expression | `ds.filter()`                           | Returns array                          |
| `filter(expr)` | Setter | Set filter            | `ds.filter(["age",">",18]); ds.load();` | Pass `null` to clear |


### Search Methods

| Method                   | Type   | Purpose           | Example                              | Notes                                         |
| ------------------------ | ------ | ----------------- | ------------------------------------ | --------------------------------------------- |
| `searchExpr()`           | Getter | Get search fields | `ds.searchExpr()`                    | String/Array                                  |
| `searchExpr(value)`      | Setter | Set fields        | `ds.searchExpr("name")`              |                                               |
| `searchOperation()`      | Getter | Get operation     | `ds.searchOperation()`               |                                               |
| `searchOperation(value)` | Setter | Set operation     | `ds.searchOperation("contains")`     | Supports =, >, contains etc |
| `searchValue()`          | Getter | Get value         | `ds.searchValue()`                   |                                               |
| `searchValue(value)`     | Setter | Set value         | `ds.searchValue("john"); ds.load();` | Must reload                 |


### Sorting & Grouping Methods

| Method         | Type   | Purpose      | Example                                  | Notes |
| -------------- | ------ | ------------ | ---------------------------------------- | ----- |
| `sort()`       | Getter | Get sorting  | `ds.sort()`                              |       |
| `sort(value)`  | Setter | Set sorting  | `ds.sort({selector:"name"}); ds.load();` |       |
| `group()`      | Getter | Get grouping | `ds.group()`                             |       |
| `group(value)` | Setter | Set grouping | `ds.group("country"); ds.load();`        |       |


### Selection Method

| Method          | Type   | Purpose             | Example                                | Notes         |
| --------------- | ------ | ------------------- | -------------------------------------- | ------------- |
| `select()`      | Getter | Get selected fields | `ds.select()`                          |               |
| `select(value)` | Setter | Set selected fields | `ds.select(["id","name"]); ds.load();` | Limits fields |


### Configuration Methods

| Method                     | Type   | Purpose            | Example                                  | Notes                                      |
| -------------------------- | ------ | ------------------ | ---------------------------------------- | ------------------------------------------ |
| `requireTotalCount()`      | Getter | Get setting        | `ds.requireTotalCount()`                 |                                            |
| `requireTotalCount(value)` | Setter | Enable total count | `ds.requireTotalCount(true); ds.load();` | Needed for pagination UI |
| `store()`                  | Getter | Get store instance | `ds.store()`                             | Direct access                              |


### Event Methods

| Method                | Type     | Purpose                 | Example                 | Notes |
| --------------------- | -------- | ----------------------- | ----------------------- | ----- |
| `on(event, handler)`  | Setter   | Attach event            | `ds.on("changed", fn)`  |       |
| `on(eventsObj)`       | Setter   | Attach multiple events  | `ds.on({changed:fn})`   |       |
| `off(event)`          | Function | Remove all handlers     | `ds.off("changed")`     |       |
| `off(event, handler)` | Function | Remove specific handler | `ds.off("changed", fn)` |       |


### Utility Methods

| Method          | Type     | Purpose            | Example            | Notes                                           |
| --------------- | -------- | ------------------ | ------------------ | ----------------------------------------------- |
| `loadOptions()` | Getter   | Get current config | `ds.loadOptions()` | Includes filter, sort, paging |
| `dispose()`     | Function | Destroy DataSource | `ds.dispose()`     | Avoid if used by UI           |


## Events

| Event              | Type     | Trigger                       | Parameter             | What It Does                                 | Example                                    | Real Use Cases                              | Important Notes                                     |
| ------------------ | -------- | ----------------------------- | --------------------- | -------------------------------------------- | ------------------------------------------ | ------------------------------------------- | --------------------------------------------------- |
| `onChanged`        | Function | After data loads successfully | `e` (optional)        | Executes after data is fetched and processed | `onChanged: () => console.log(ds.items())` | Access loaded data, update UI, calculations | Fires after **filter, search, sort, group** applied |
| `onLoadError`      | Function | When loading fails            | `error` object        | Handles API or data errors                   | `onLoadError: (e) => alert(e.message)`     | Show error messages, logging, retry logic   | Triggered on **network/API failure**                |
| `onLoadingChanged` | Function | When loading starts & ends    | `isLoading` (boolean) | Tracks loading state                         | `onLoadingChanged: l => console.log(l)`    | Show/hide loader, disable UI                | Fires **twice**: `true` → start, `false` → end      |
