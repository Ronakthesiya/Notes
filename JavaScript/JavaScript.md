## Declaring variable

- starts with a letter, underscore (_), or dollar sign ($)
- Subsequent characters can also be digits (0 – 9)
- case sensitive

### var

- Declares a variable, optionally initializing it to a value.
- Scope :
  - Global scope: The default scope for all code running in script mode.
  - Module scope: The scope for code running in module mode.
  - Function scope: The scope created with a function. 

### let

- Declares a block-scoped, local variable, optionally initializing it to a value.
- Scope : 
  - Block scope: The scope created with a pair of curly braces

### const

- Declares a block-scoped, read-only named constant.
- Scope :
  - Block scope: The scope created with a pair of curly braces

- const only prevents re-assignments, but doesn't prevent mutations. The properties of objects assigned to constants are not protected, so the following statement is executed without problems.

```js
const MY_OBJECT = { key: "value" };
MY_OBJECT.key = "otherValue";
```

---

## Variable hoisting

- var-declared variables are hoisted, meaning you can refer to the variable anywhere in its scope, even if its declaration isn't reached yet. 
- You can see var declarations as being "lifted" to the top of its function or global scope. 
- However, if you access a variable before it's declared, the value is always undefined

```js
console.log(x === undefined); // true
var x = 3;

(function () {
  console.log(x); // undefined
  var x = "local value";
})();
```

- Whether let and const are hoisted is a matter of definition debate. Referencing the variable in the block before the variable declaration always results in a ReferenceError, because the variable is in a "temporal dead zone" from the start of the block until the declaration is processed.

```js
console.log(x); // ReferenceError
const x = 3;

console.log(y); // ReferenceError
let y = 3;
```

---

## Data types

### primitives

1. Boolean. true and false.
2. null. A special keyword denoting a null value. (Because JavaScript is case-sensitive, null is not the same as Null, NULL, or any other variant.)
3. undefined. A top-level property whose value is not defined.
4. Number. An integer or floating point number. For example: 42 or 3.14159.
5. BigInt. An integer with arbitrary precision. For example: 9007199254740992n.
6. String. A sequence of characters that represent a text value. For example: "Howdy".
7. Symbol. A data type whose instances are unique and immutable.

### non-primitives

8. Object

---

## Literals

Literals represent values in JavaScript. These are fixed values—not variables—that you literally provide in your script.

### Array literals

| **Method**            | **Explanation**                                                                                                              | **Example**                                     | **Result**        | **Parameters**                                                                                                                                                                 |
| --------------------- | ---------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------- | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **`length`**          | The number of elements in an array.                                                                                          | `const arr = [1, 2, 3]; arr.length;`            | `3`               | N/A (this is a property, not a method)                                                                                                                                         |
| **`Array.from()`**    | Creates a new array from an iterable or array-like object.                                                                   | `Array.from("abc");`                            | `['a', 'b', 'c']` | 1. `arrayLike`: Object to convert to an array.<br>2. `mapFn` (optional): Function to apply to each element.                                                                    |
| **`Array.isArray()`** | Checks if the given value is an array.                                                                                       | `Array.isArray([1, 2]);`                        | `true`            | 1. `value`: The value to check if it is an array.                                                                                                                              |
| **`Array.of()`**      | Creates a new array from any number of arguments.                                                                            | `Array.of(1, 2, 3);`                            | `[1, 2, 3]`       | `...elements`: Values to be added to the array.                                                                                                                                |
| **`push()`**          | Adds one or more elements to the end of an array. Returns the new length of the array.                                       | `const arr = [1]; arr.push(2, 3);`              | `3`               | `...elements`: Elements to add to the end of the array.                                                                                                                        |
| **`pop()`**           | Removes the last element from an array and returns it.                                                                       | `const arr = [1, 2, 3]; arr.pop();`             | `3`               | N/A (removes the last element).                                                                                                                                                |
| **`shift()`**         | Removes the first element from an array and returns it.                                                                      | `const arr = [1, 2, 3]; arr.shift();`           | `1`               | N/A (removes the first element).                                                                                                                                               |
| **`unshift()`**       | Adds one or more elements to the beginning of an array. Returns the new length of the array.                                 | `const arr = [2]; arr.unshift(1);`              | `2`               | `...elements`: Elements to add to the start of the array.                                                                                                                      |
| **`splice()`**        | Adds/removes elements at a specific index. Returns the removed elements.                                                     | `const arr = [1, 2, 3]; arr.splice(1, 1, "x");` | `[2]`             | 1. `start`: The index at which to begin changing the array.<br>2. `deleteCount`: Number of elements to remove.<br>3. `...items`: Items to add.                                 |
| **`sort()`**          | Sorts the elements of the array in place and returns the sorted array. By default, sorts as strings.                         | `[10, 2].sort();`                               | `[10, 2]`         | 1. `compareFunction` (optional): Function to define sorting logic.                                                                                                             |
| **`reverse()`**       | Reverses the order of the elements in the array in place.                                                                    | `[1, 2, 3].reverse();`                          | `[3, 2, 1]`       | N/A (reverses the array in place).                                                                                                                                             |
| **`fill()`**          | Changes all elements in the array to a static value in a specified range and returns the modified array.                     | `[1, 2, 3].fill(0);`                            | `[0, 0, 0]`       | 1. `value`: The value to fill the array with.<br>2. `start` (optional): The start index (default is `0`).<br>3. `end` (optional): The end index (default is the array length). |
| **`copyWithin()`**    | Shallow copies part of the array to another part of the array without changing the array length.                             | `[1, 2, 3, 4].copyWithin(0, 2);`                | `[3, 4, 3, 4]`    | 1. `target`: The index to copy to.<br>2. `start`: The index to start copying from.<br>3. `end` (optional): The index to stop copying at (defaults to array length).            |
| **`concat()`**        | Combines two or more arrays.                                                                                                 | `[1].concat([2, 3]);`                           | `[1, 2, 3]`       | `...arrays`: Arrays or values to concatenate.                                                                                                                                  |
| **`slice()`**         | Returns a shallow copy of a portion of the array into a new array, without modifying the original array.                     | `[1, 2, 3].slice(1, 3);`                        | `[2, 3]`          | 1. `start`: The start index.<br>2. `end` (optional): The end index (not included).                                                                                             |
| **`join()`**          | Joins all elements of the array into a string with a specified separator.                                                    | `[1, 2, 3].join("-");`                          | `"1-2-3"`         | 1. `separator` (optional): The string to separate the elements.                                                                                                                |
| **`toString()`**      | Converts the array to a string, separating each element with commas.                                                         | `[1, 2].toString();`                            | `"1,2"`           | N/A (converts to a string).                                                                                                                                                    |
| **`at()`**            | Returns the element at the specified index, supports negative indices.                                                       | `[1, 2, 3].at(-1);`                             | `3`               | 1. `index`: The index to access, negative values count from the end.                                                                                                           |
| **`forEach()`**       | Executes a provided function once for each array element.                                                                    | `[1, 2].forEach(x => console.log(x));`          | `1` `2`           | 1. `callback`: Function to execute for each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                   |
| **`map()`**           | Creates a new array with the results of calling a provided function on every element.                                        | `[1, 2].map(x => x * 2);`                       | `[2, 4]`          | 1. `callback`: Function to execute on each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                    |
| **`filter()`**        | Creates a new array with all elements that pass a test.                                                                      | `[1, 2, 3].filter(x => x > 1);`                 | `[2, 3]`          | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`reduce()`**        | Applies a function against an accumulator and each element in the array (from left to right) to reduce it to a single value. | `[1, 2, 3].reduce((a, b) => a + b, 0);`         | `6`               | 1. `callback`: Function to apply on each element.<br>2. `initialValue`: The initial accumulator value (optional).                                                              |
| **`reduceRight()`**   | Like `reduce()`, but processes the array from right to left.                                                                 | `[1, 2, 3].reduceRight((a, b) => a + b, 0);`    | `6`               | 1. `callback`: Function to apply on each element.<br>2. `initialValue`: The initial accumulator value (optional).                                                              |
| **`some()`**          | Tests if at least one element in the array satisfies the provided function.                                                  | `[1, 2].some(x => x > 1);`                      | `true`            | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`every()`**         | Tests if every element in the array satisfies the provided function.                                                         | `[1, 2].every(x => x > 0);`                     | `true`            | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`find()`**          | Returns the first element in the array that satisfies the provided function.                                                 | `[1, 2, 3].find(x => x > 1);`                   | `2`               | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`findIndex()`**     | Returns the index of the first element that satisfies the provided function.                                                 | `[1, 2, 3].findIndex(x => x === 2);`            | `1`               | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`findLast()`**      | Returns the last element that satisfies the provided function (ES2022+).                                                     | `[1, 2, 3, 2].findLast(x => x === 2);`          | `2`               | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`findLastIndex()`** | Returns the index of the last element that satisfies the provided function (ES2022+).                                        | `[1, 2, 3, 2].findLastIndex(x => x === 2);`     | `3`               | 1. `callback`: Function to test each element.<br>2. `thisArg` (optional): Value to use as `this` inside the callback.                                                          |
| **`includes()`**      | Determines if an array contains a specific element.                                                                          | `[1, 2, 3].includes(2);`                        | `true`            | 1. `searchElement`: The element to search for.<br>2. `fromIndex` (optional): The index to start searching from.                                                                |
| **`indexOf()`**       | Returns the first index of the specified element, or `-1` if not found.                                                      | `[1, 2, 3].indexOf(2);`                         | `1`               | 1. `searchElement`: The element to search for.<br>2. `fromIndex` (optional): The index to start searching from.                                                                |
| **`lastIndexOf()`**   | Returns the last index of the specified element, or `-1` if not found.                                                       | `[1, 2, 3].lastIndexOf(2);`                     | `1`               | 1. `searchElement`: The element to search for.<br>2. `fromIndex` (optional): The index to start searching from (backwards).                                                    |

