## Create

```js
let ld = new DevExpress.data.LocalStore({
    key: "id",
    data: data,

    // store in local storage with dx-data-localStore-myLocalData
    name: "myLocalData",

    // immediate update
    immediate: false,

    // time after change reflect
    flushInterval: 5000,
})
```

## options

| Option          | Type           | Default   | Description                     | Input Example         | Output / Behavior                        |
| --------------- | -------------- | --------- | ------------------------------- | --------------------- | ---------------------------------------- |
| `key`          | String / Array | undefined | Unique identifier for records   | `"id"`                | Used for update/delete operations        |
| `data`          | Array          | `[]`      | Initial data to load into store | `[{id:1,name:"A"}]`   | Stored in localStorage                   |
| `name`         | String         | required  | Name of storage key in browser  | `"usersStore"`        | Saved as `dx-data-localStore-usersStore` |
| `immediate`     | Boolean        | `true`    | Save instantly or delay         | `false`               | If false → uses `flushInterval`          |
| `flushInterval` | Number (ms)    | 10000     | Time delay to save data         | `5000`                | Saves every 5 seconds                    |
| `errorHandler`  | Function       | null      | Handles errors                  | `(e)=>console.log(e)` | Logs errors                              |


## EVENT OPTIONS

| Event         | Parameters      | Description   | Example             |
| ------------- | --------------- | ------------- | ------------------- |
| `onInserting` | `(values)`      | Before insert | Validate data       |
| `onInserted`  | `(values, key)` | After insert  | Log inserted record |

| Event        | Parameters      | Description   | Example        |
| ------------ | --------------- | ------------- | -------------- |
| `onUpdating` | `(key, values)` | Before update | Check changes  |
| `onUpdated`  | `(key, values)` | After update  | Confirm update |

| Event        | Parameters | Description   | Example          |
| ------------ | ---------- | ------------- | ---------------- |
| `onRemoving` | `(key)`    | Before delete | Confirm deletion |
| `onRemoved`  | `(key)`    | After delete  | Log removal      |

| Event       | Parameters      | Description | Example      |
| ----------- | --------------- | ----------- | ------------ |
| `onLoading` | `(loadOptions)` | Before load | Modify query |
| `onLoaded`  | `(result)`      | After load  | Access data  |

| Event         | Parameters | Description       |
| ------------- | ---------- | ----------------- |
| `onModifying` | `()`       | Before any change |
| `onModified`  | `()`       | After any change  |

| Event    | Parameters  | Description                       |
| -------- | ----------- | --------------------------------- |
| `onPush` | `(changes)` | Triggered when `push()` is called |

## Methods

| Method                    | Parameters (Input)              | Return Type      | Description                         | Example                                 | Output / Behavior            |
| ------------------------- | ------------------------------- | ---------------- | ----------------------------------- | --------------------------------------- | ---------------------------- |
| `byKey(key)`              | `key: String / Number / Object` | Promise          | Gets a single record by key         | `store.byKey(1)`                        | Returns matching object      |
| `clear()`                 | None                            | Promise / void   | Removes all data from localStorage  | `store.clear()`                         | Store becomes empty          |
| `createQuery()`         | None                            | Query Object     | Creates query for filtering/sorting | `store.createQuery()`                   | Used for chaining operations |
| `insert(values)`          | `values: Object`                | Promise          | Inserts new record                  | `store.insert({id:1,name:"A"})`         | Record added                 |
| `key()`                   | None                            | String / Array   | Returns key field name              | `store.key()`                           | `"id"`                       |
| `keyOf(obj)`              | `obj: Object`                   | Any              | Extracts key value from object      | `store.keyOf({id:1})`                   | `1`                          |
| `load()`                  | None                            | Promise → Array  | Loads all data                      | `store.load()`                          | Returns full dataset         |
| `load(options)`           | `options: LoadOptions`          | Promise → Array  | Loads with filtering/sorting        | `store.load({filter:["age",">",25]})`   | Filtered result              |
| `off(eventName)`          | `eventName: String`             | LocalStore       | Removes all handlers for event      | `store.off("loaded")`                   | Event unsubscribed           |
| `off(eventName, handler)` | `eventName, handler`            | LocalStore       | Removes specific handler            | `store.off("loaded", fn)`               | Specific handler removed     |
| `on(eventName, handler)`  | `eventName, handler`            | LocalStore       | Subscribes to event                 | `store.on("loaded", fn)`                | Event attached               |
| `on(events)`              | `{event: handler}`              | LocalStore       | Attach multiple events              | `store.on({loaded: fn})`                | Multiple events added        |
| `push(changes)`         | `changes: Array`                | void             | Applies batch changes               | `store.push([{type:"insert",data:{}}])` | Real-time update             |
| `remove(key)`             | `key: String / Number / Object` | Promise          | Deletes record by key               | `store.remove(1)`                       | Record removed               |
| `totalCount(options)`     | `options: Object`               | Promise → Number | Counts records                      | `store.totalCount()`                    | Returns count                |
| `update(key, values)`     | `key, values`                   | Promise          | Updates record                      | `store.update(1,{name:"B"})`            | Record updated               |


## Events

| Event Name      | Trigger Time      | Parameters      | Description                       | Example Usage            | Output / Behavior             |
| --------------- | ----------------- | --------------- | --------------------------------- | ------------------------ | ----------------------------- |
| `onInserting`   | Before insert     | `(values)`      | Fires before a record is added    | Validate or modify data  | Can cancel/validate insert    |
| `onInserted`    | After insert      | `(values, key)` | Fires after record is added       | Log success              | Record stored in localStorage |
| `onUpdating`    | Before update     | `(key, values)` | Fires before updating record      | Check changes            | Can validate update           |
| `onUpdated`     | After update      | `(key, values)` | Fires after update                | Confirm update           | Data updated                  |
| `onRemoving`    | Before delete     | `(key)`         | Fires before deletion             | Confirm delete           | Can prevent removal           |
| `onRemoved`     | After delete      | `(key)`         | Fires after deletion              | Log delete               | Record removed                |
| `onLoading`     | Before load       | `(loadOptions)` | Fires before data loading         | Modify filter/sort       | Customize query               |
| `onLoaded`      | After load        | `(result)`      | Fires after data loaded           | Access loaded data       | Returns dataset               |
| `onModifying`  | Before any change | `()`            | Fires before insert/update/delete | Global validation        | Runs for all changes          |
| `onModified`   | After any change  | `()`            | Fires after insert/update/delete  | Global logging           | Runs after all changes        |
| `onPush`        | Before push       | `(changes)`     | Fires before push updates         | Handle real-time updates | Triggered by `push()`         |
