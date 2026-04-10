## CustomStore

```js
const store = new DevExpress.data.CustomStore({
    key: "id",
    load: function (loadOptions) {
        // ...
    },
    insert: function (values) {
        // ...
    },
    update: function (key, values) {
        // ...
    },
    remove: function (key) {
        // ...
    }
});
 
// ===== or inside the DataSource =====
const dataSource = new DevExpress.data.DataSource({
    // ...
    // a mix of CustomStore and DataSource properties
    // ...
});
```

## options

| Option               | Type           | When It Runs       | What It Does              | Return Type     | Detailed Notes                                                                                    | Example                                     |
| -------------------- | -------------- | ------------------ | ------------------------- | --------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| **key**              | String / Array | Always             | Defines unique identifier | —               | Required for update/delete. Can be composite key.                                                 | `"id"`                                      |
| **load**             | Function       | Data fetch         | Loads data (main method)  | Promise / Array | Receives `loadOptions` (paging, filter, sort). Most important function.                           | `load: (o) => fetch(...).then(r=>r.json())` |
| **loadMode**         | String         | Before load        | Defines processing mode   | —               | `"processed"` = server handles operations, `"raw"` = client handles. Use `"raw"` for simple APIs. byKey is not required when mode is row | `"raw"`                                     |
| **cacheRawData**     | Boolean        | After load         | Cache raw data            | —               | Works only with `loadMode: "raw"`. Improves performance but may show stale data.                  | `true`                                      |
| **byKey**            | Function       | When record needed | Fetch single record       | Promise         | Used in editing, lookup, etc.                                                                     | `byKey: (id)=>fetch(...).then(...)`         |
| **insert**           | Function       | On create          | Add new record            | Promise         | Must return inserted object or success response.                                                  | `POST API`                                  |
| **update**           | Function       | On edit            | Update record             | Promise         | Receives `(key, values)`                                                                          | `PUT / PATCH`                               |
| **remove**           | Function       | On delete          | Delete record             | Promise         | Should resolve after deletion                                                                     | `DELETE API`                                |
| **totalCount**       | Function       | Paging             | Get total rows            | Promise(Number) | Needed for server-side paging                                                                     | `return count`                              |
| **errorHandler**     | Function       | On error           | Handle errors globally    | —               | Centralized error logging                                                                         | `console.error()`                           |
| **useDefaultSearch** | Boolean        | During search      | Use built-in search       | —               | If false → you must handle search manually                                                        | `true`                                      |


## Options Events

| Event           | When It Fires     | Purpose             | Example           |
| --------------- | ----------------- | ------------------- | ----------------- |
| **onLoading**   | Before `load()`   | Modify request      | Add auth token    |
| **onLoaded**    | After `load()`    | Inspect data        | Logging           |
| **onInserting** | Before insert     | Modify values       | Add timestamps    |
| **onInserted**  | After insert      | Post-processing     | Show success      |
| **onUpdating**  | Before update     | Modify values       | Audit fields      |
| **onUpdated**   | After update      | Confirm update      | Logging           |
| **onRemoving**  | Before delete     | Validate            | Confirm dialog    |
| **onRemoved**   | After delete      | Cleanup             | UI refresh        |
| **onModifying** | Before any CRUD   | Global pre-hook     | Validation        |
| **onModified**  | After any CRUD    | Global post-hook    | Refresh           |
| **onPush**      | Real-time updates | Handle push changes | WebSocket updates |

## Methods

| Method                        | Parameters             | Return Type     | When Used           | What It Does             | Deep Notes                                                                             | Example                                  |
| ----------------------------- | ---------------------- | --------------- | ------------------- | ------------------------ | -------------------------------------------------------------------------------------- | ---------------------------------------- |
| **load(options?)**            | `options: LoadOptions` | Promise         | Manual data fetch   | Loads data from store    | Calls your configured `load()` internally. Supports paging, sorting, filtering.        | `store.load({ skip:0, take:10 })`        |
| **byKey(key, extraOptions?)** | `key`, `extraOptions`  | Promise         | Fetch single record | Gets one item by key     | Supports single & composite keys. Used in editing & lookup.          | `store.byKey(1)`                         |
| **insert(values)**            | `values: Object`       | Promise         | Create record       | Adds new item            | Key must be unique, otherwise insert fails. Returns inserted object. | `store.insert({name:"Amit"})`            |
| **update(key, values)**       | `key`, `values`        | Promise         | Update record       | Updates existing item    | Works with composite keys also. Returns updated object.              | `store.update(1,{name:"Raj"})`           |
| **remove(key)**               | `key`                  | Promise         | Delete record       | Deletes item             | Resolves after deletion. Supports composite key.                     | `store.remove(1)`                        |
| **totalCount(options?)**      | `options`              | Promise(Number) | Paging              | Gets total records count | Used in server-side paging & virtual scrolling.                      | `store.totalCount()`                     |
| **key()**                     | —                      | String / Array  | Debugging           | Returns key field(s)     | Useful when working dynamically with store                                             | `store.key()`                            |
| **keyOf(obj)**                | `obj`                  | Any             | Utility             | Extracts key from object | Works based on defined `key` property                                                  | `store.keyOf({id:5})`                    |
| **push(changes)**             | `changes: Array`       | void            | Real-time updates   | Pushes changes to store  | Does NOT call API. Used with WebSocket/SignalR.                      | `store.push([{type:"insert",data:obj}])` |
| **on(eventName, handler)**    | `eventName`, `handler` | CustomStore     | Events              | Attach event handler     | Used for lifecycle events like loading, inserting                                      | `store.on("loaded", fn)`                 |
| **on(eventsObject)**          | `{event:handler}`      | CustomStore     | Events              | Attach multiple handlers | Cleaner way to bind multiple events                                                    | `store.on({loaded:fn})`                  |
| **off(eventName)**            | `eventName`            | CustomStore     | Events              | Remove all handlers      | Detaches all handlers for event                                                        | `store.off("loaded")`                    |
| **off(eventName, handler)**   | `eventName`, `handler` | CustomStore     | Events              | Remove specific handler  | Removes only given function                                                            | `store.off("loaded", fn)`                |
| **clearRawDataCache()**       | —                      | void            | Cache control       | Clears cached data       | Works only if `cacheRawData = true`                                  | `store.clearRawDataCache()`              |


## LOAD OPTIONS TABLE

| Option            | Type         | Purpose                |
| ----------------- | ------------ | ---------------------- |
| skip              | number       | Skip records (paging)  |
| take              | number       | Limit records (paging) |
| sort              | array        | Sorting rules          |
| filter            | array        | Filtering conditions   |
| group             | array        | Grouping               |
| searchExpr        | string/array | Fields to search       |
| searchOperation   | string       | Search operator        |
| searchValue       | any          | Search value           |
| select            | array        | Fields to return       |
| requireTotalCount | boolean      | Need total count       |
| totalSummary      | array        | Overall summary        |
| groupSummary      | array        | Group summary          |
| requireGroupCount | boolean      | Count groups           |


| Option                | Type         | When Sent       | Purpose                    | Value Structure                | Expected Server Handling | Example                             |
| --------------------- | ------------ | --------------- | -------------------------- | ------------------------------ | ------------------------ | ----------------------------------- |
| **skip**              | Number       | Paging          | Number of records to skip  | `0, 10, 20...`                 | Use for OFFSET           | `{ skip: 20 }`                      |
| **take**              | Number       | Paging          | Number of records to fetch | `10, 50, 100`                  | Use for LIMIT            | `{ take: 10 }`                      |
| **sort**              | Array        | Sorting         | Defines sort order         | `{ selector, desc }`           | Apply ORDER BY           | `[{ selector:"name", desc:false }]` |
| **filter**            | Array        | Filtering       | Conditions to filter data  | Nested array                   | Convert to WHERE clause  | `["age", ">", 18]`                  |
| **group**             | Array        | Grouping        | Group records              | `{ selector, desc }`           | GROUP BY logic           | `[{ selector:"country" }]`          |
| **searchExpr**        | String/Array | Search          | Fields to search           | `"name"` or `["name","email"]` | Combine with searchValue | `"name"`                            |
| **searchOperation**   | String       | Search          | Operator for search        | `"contains"`, `"="`, etc.      | Apply LIKE / match       | `"contains"`                        |
| **searchValue**       | Any          | Search          | Value to search            | `"john"`                       | Apply search filter      | `"john"`                            |
| **select**            | Array        | Field selection | Fields to return           | `["id","name"]`                | SELECT specific columns  | `["id","name"]`                     |
| **requireTotalCount** | Boolean      | Paging          | Request total count        | `true/false`                   | Return totalCount        | `true`                              |
| **totalSummary**      | Array        | Summary         | Total aggregation          | `{selector,summaryType}`       | Calculate aggregates     | `sum, avg`                          |
| **groupSummary**      | Array        | Group summary   | Aggregate per group        | Same as totalSummary           | Per-group aggregation    | `sum`                               |
| **requireGroupCount** | Boolean      | Grouping        | Count groups               | `true/false`                   | Return groupCount        | `true`                              |

