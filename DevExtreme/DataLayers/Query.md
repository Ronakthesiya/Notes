## Create

```js
var data = [
  { name: "A", age: 25, gender: "M", salary: 5000 },
  { name: "B", age: 30, gender: "F", salary: 7000 },
  { name: "C", age: 20, gender: "M", salary: 3000 }
];

DevExpress.data.query(data)
    .filter(["age", ">", 20])
    .sortBy("salary", true)
    .select(["name", "salary"])
    .slice(0, 2)
    .toArray();
```

## Methods

| Method                              | Category  | Syntax                     | Returns | Description                          | Example                              | Output           |
| ----------------------------------- | --------- | -------------------------- | ------- | ------------------------------------ | ------------------------------------ | ---------------- |
| **aggregate(seed, step, finalize)** | Aggregate | `aggregate(0, fn, fn)`     | Promise | Custom aggregation with full control | `query.aggregate(0,(t,i)=>t+i)`      | Computed value   |
| **aggregate(step)**                 | Aggregate | `aggregate(fn)`            | Promise | Uses first item as seed              | `query.aggregate((t,i)=>t+i)`        | Computed value   |
| **sum() / sum(getter)**             | Aggregate | `sum("price")`             | Promise | Total sum of values                  | `query.sum("price")`                 | `100`            |
| **avg() / avg(getter)**             | Aggregate | `avg("price")`             | Promise | Average value                        | `query.avg("price")`                 | `25`             |
| **min() / min(getter)**             | Aggregate | `min("price")`             | Promise | Smallest value                       | `query.min("price")`                 | `10`             |
| **max() / max(getter)**             | Aggregate | `max("price")`             | Promise | Largest value                        | `query.max("price")`                 | `50`             |
| **count()**                         | Aggregate | `count()`                  | Promise | Number of items                      | `query.count()`                      | `5`              |
| **toArray()**                       | Execution | `toArray()`                | Array   | Executes query (sync)                | `query.toArray()`                    | `[{}, {}]`       |
| **enumerate()**                     | Execution | `enumerate()`              | Promise | Executes query (async)               | `query.enumerate()`                  | `[{}, {}]`       |
| **filter(criteria)**                | Filtering | `filter(["age", ">", 18])` | Query   | Filter using DevExtreme expression   | `query.filter(["age",">",18])`       | Filtered data    |
| **filter(predicate)**               | Filtering | `filter(fn)`               | Query   | Filter using JS function             | `query.filter(x=>x.age>18)`          | Filtered data    |
| **select(getter)**                  | Transform | `select("name")`           | Query   | Select specific fields               | `query.select("name")`               | `[{"name":"A"}]` |
| **sortBy(getter)**                  | Sorting   | `sortBy("age")`            | Query   | Sort ascending                       | `query.sortBy("age")`                | Sorted data      |
| **sortBy(getter, desc)**            | Sorting   | `sortBy("age", true)`      | Query   | Sort descending                      | `query.sortBy("age",true)`           | Sorted data      |
| **thenBy(getter)**                  | Sorting   | `thenBy("name")`           | Query   | Secondary sorting                    | `query.sortBy("age").thenBy("name")` | Multi-sorted     |
| **thenBy(getter, desc)**            | Sorting   | `thenBy("age", true)`      | Query   | Secondary descending sort            | `query.thenBy("age",true)`           | Multi-sorted     |
| **slice(skip, take)**               | Paging    | `slice(0,5)`               | Query   | Skip & take records                  | `query.slice(0,5)`                   | Subset           |
| **groupBy(getter)**                 | Grouping  | `groupBy("category")`      | Query   | Group data by field                  | `query.groupBy("category")`          | `{key, items}`   |
