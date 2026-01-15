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


### Boolean

#### Falsy Values
- A falsy value is one that is considered false when evaluated in a boolean context
- There are only six falsy values in JavaScript:

1. false
2. 0 (zero)
3. -0 (negative zero)
4. "" (empty string)
5. null
6. undefined
7. NaN (Not-a-Number)

#### Truthy Values

- A truthy value is any value that is not falsy. Essentially, everything except the six falsy values mentioned above is truthy.

### Object literals

- An object literal is a list of zero or more pairs of property names and associated values of an object, enclosed in curly braces ({}).

```js
const car = { manyCars: { a: "Saab", b: "Jeep" }, 7: "Mazda" };

console.log(car.manyCars.b); // Jeep
console.log(car[7]); // Mazda
```

---

## Control flow 

### if...else statement

```js
if (condition) {
  statement1;
} else {
  statement2;
}

if (condition1) {
  statement1;
} else if (condition2) {
  statement2;
} else if (conditionN) {
  statementN;
} else {
  statementLast;
}
```

### switch statement

```js
switch (expression) {
  case label1:
    statements1;
    break;
  case label2:
    statements2;
    break;
  // …
  default:
    statementsDefault;
}
```
---

## Exception handling statements

### throw statement

- Use the throw statement to throw an exception. 

```js
throw "Error2"; // String type
throw 42; // Number type
throw true; // Boolean type
throw {
  toString() {
    return "I'm an object!";
  },
};
```

### try...catch statement

```js
openMyFile();
try {
  writeMyFile(theData); // This may throw an error
} catch (e) {
  handleError(e); // If an error occurred, handle it
} finally {
  closeMyFile(); // Always close the resource
}
```

- If the finally block returns a value, this value becomes the return value of the entire try...catch...finally production, regardless of any return statements in the try and catch blocks

```js
try {
  doSomethingErrorProne();
} catch (e) {
  // Now, we actually use `console.error()`
  console.error(e.name); // 'Error'
  console.error(e.message); // 'The message', or a JavaScript error message
}
```
---

## Loops and iteration

### for statement

```js
for (initialization; condition; afterthought)
  statement
```

### do...while statement

```js
do
  statement
while (condition);

let i = 0;
do {
  i += 1;
  console.log(i);
} while (i < 5);
```

### while statement

```js
while (condition)
  statement

let n = 0;
let x = 0;
while (n < 3) {
  n++;
  x += n;
}
```

### labeled statement+
- A label provides a statement with an identifier that lets you refer to it elsewhere in your program.

```js
let x = 0;
let z = 0;
labelCancelLoops: while (true) {
  console.log("Outer loops:", x);
  x += 1;
  z = 1;
  while (true) {
    console.log("Inner loops:", z);
    z += 1;
    if (z === 10 && x === 10) {
      break labelCancelLoops;
    } else if (z === 10) {
      break;
    }
  }
}
```

### break statement
-  break the loop

### continue statement
- direct next itration of loop

### for...in statement

- The for...in loop is used to iterate over the enumerable property keys (or indices) of an object or array. It will iterate over all properties, including inherited ones, unless they are non-enumerable.

- Key Characteristics:
  - Iterates over property keys (or indices in arrays).
  - Works on objects and arrays.
  - Iterates over enumerable properties of the object.

```js
for (variable in object)
  statement

for (const i in obj) {
  result += `${objName}.${i} = ${obj[i]}<br>`;
}
```

### for...of statement

- The for...of loop is used to iterate over iterable objects like arrays, strings, maps, sets, NodeLists, and any object with an [Symbol.iterator] property. It gives access to the values directly, not the keys (or indices).

- Key Characteristics:
  - Iterates over values in an iterable object (e.g., arrays, strings).
  - Does not work for objects (use for...in for that).
  - Iterates over elements directly (not property names).

```js
const arr = [3, 5, 7];
arr.foo = "hello";

for (const i in arr) {
  console.log(i);
}
// "0" "1" "2" "foo"

for (const i of arr) {
  console.log(i);
}
// Logs: 3 5 7
```

```js
const obj = { foo: 1, bar: 2 };

for (const [key, val] of Object.entries(obj)) {
  console.log(key, val);
}
// "foo" 1
// "bar" 2
```

| Feature               | `for...in`                                    | `for...of`                                          |
| --------------------- | --------------------------------------------- | --------------------------------------------------- |
| **Iteration over**    | Object keys or array indices                  | Values of iterable objects (e.g., arrays, strings)  |
| **Works with**        | Objects, arrays (keys/indices)                | Arrays, strings, maps, sets, etc. (values)          |
| **Accesses**          | Property keys or array indices (not values)   | Values directly                                     |
| **Suitable for**      | Objects (properties), checking all properties | Arrays, strings, iterables, direct access to values |
| **Works on Arrays?**  | Yes (but accesses indices as strings)         | Yes (accesses values directly)                      |
| **Works on Objects?** | Yes (accesses property names)                 | No (throws an error if used on a plain object)      |


---

## function

```js
function square(number) {
  return number * number;
}
```

### Function expressions

```js
const square = function (number) {
  return number * number;
};

console.log(square(4)); // 16

const factorial = function fac(n) {
  return n < 2 ? 1 : n * fac(n - 1);
};

console.log(factorial(3)); // 6
```

### Function hoisting

- Functions must be in scope when they are called, but the function declaration can be hoisted (appear below the call in the code). The scope of a function declaration is the function in which it is declared (or the entire program, if it is declared at the top level).

```js
console.log(square(5)); // 25

function square(n) {
  return n * n;
}
```

- Function hoisting only works with function declarations — not with function expressions. The following code will not work:

```js
console.log(square(5)); // ReferenceError: Cannot access 'square' before initialization
const square = function (n) {
  return n * n;
};
```

### Immediately Invoked Function Expressions (IIFE)

- An Immediately Invoked Function Expression (IIFE) is a code pattern that directly calls a function defined as an expression. It looks like this:

```js
(function () {
  // Do something
})();

const value = (function () {
  // Do something
  return someValue;
})();
```

### Function scopes 

- Functions form a scope for variables—this means variables defined inside a function cannot be accessed from anywhere outside the function. The function scope inherits from all the upper scopes.

- a function defined in the global scope can access all variables defined in the global scope. A function defined inside another function can also access all variables defined in its parent function, and any other variables to which the parent function has access. On the other hand, the parent function (and any other parent scope) does not have access to the variables and functions defined inside the inner function.

### Closures

- We also refer to the function body as a closure. A closure is any piece of source code (most commonly, a function) that refers to some variables, and the closure "remembers" these variables even when the scope in which these variables were declared has exited.

```js
function A(x) {
  function B(y) {
    function C(z) {
      console.log(x + y + z);
    }
    C(3);
  }
  B(2);
}
A(1); // Logs 6 (which is 1 + 2 + 3)
```

### Name conflicts

- When two arguments or variables in the scopes of a closure have the same name, there is a name conflict.
- More nested scopes take precedence. So, the innermost scope takes the highest precedence, while the outermost scope takes the lowest.

```js
function outside() {
  const x = 5;
  function inside(x) {
    return x * 2;
  }
  return inside;
}

console.log(outside()(10)); // 20 (instead of 10)
```

### Using the arguments object

- The arguments of a function are maintained in an array-like object. Within a function, you can address the arguments passed to it as follows:

```js
arguments[i];
```

```js
function myConcat(separator) {
  let result = ""; // initialize list
  // iterate through arguments
  for (let i = 1; i < arguments.length; i++) {
    result += arguments[i] + separator;
  }
  return result;
}


console.log(myConcat(", ", "red", "orange", "blue"));
// "red, orange, blue, "

console.log(myConcat("; ", "elephant", "giraffe", "lion", "cheetah"));
// "elephant; giraffe; lion; cheetah; "

console.log(myConcat(". ", "sage", "basil", "oregano", "pepper", "parsley"));
// "sage. basil. oregano. pepper. parsley. "
```

### Function parameters

- two special kinds of parameter syntax: default parameters and rest parameters.

#### 1. Default parameters

- parameters of functions default to undefined

```js
function multiply(a, b) {
  b = typeof b !== "undefined" ? b : 1;
  return a * b;
}

console.log(multiply(5)); // 5
```

```js

function multiply(a, b = 1) {
  return a * b;
}

console.log(multiply(5)); // 5
```

#### 2. Rest parameters

- The rest parameter syntax allows us to represent an indefinite number of arguments as an array.

- In the following example, the function multiply uses rest parameters to collect arguments from the second one to the end. The function then multiplies these by the first argument.

```js
function multiply(multiplier, ...theArgs) {
  return theArgs.map((x) => multiplier * x);
}

const arr = multiply(2, 1, 2, 3);
console.log(arr); // [2, 4, 6]
```

### Arrow functions

```js
const a = ["Hydrogen", "Helium", "Lithium", "Beryllium"];

const a2 = a.map(function (s) {
  return s.length;
});

console.log(a2); // [8, 6, 7, 9]

const a3 = a.map((s) => s.length);

console.log(a3); // [8, 6, 7, 9]
```
---

## Expressions and operators

<details>
  <summary>
    <h3>Assignment operators</h3>
  </summary>

| **Operator** | **Description**                          | **Equivalent**         |
| ------------ | ---------------------------------------- | ---------------------- |
| `=`          | Assigns value                            | `x = f()`              |
| `+=`         | Adds and assigns                         | `x = x + f()`          |
| `-=`         | Subtracts and assigns                    | `x = x - f()`          |
| `*=`         | Multiplies and assigns                   | `x = x * f()`          |
| `/=`         | Divides and assigns                      | `x = x / f()`          |
| `%=`         | Modulo (remainder) and assigns           | `x = x % f()`          |
| `**=`        | Exponentiation and assigns               | `x = x ** f()`         |
| `<<=`        | Left bitwise shift and assigns           | `x = x << f()`         |
| `>>=`        | Right bitwise shift and assigns          | `x = x >> f()`         |
| `>>>`        | Unsigned right bitwise shift and assigns | `x = x >>> f()`        |
| `&=`         | Bitwise AND and assigns                  | `x = x & f()`          |
| `^=`         | Bitwise XOR and assigns                  | `x = x ^ f()`          |
| `\|=`        | Bitwise OR and assigns                   | `x = x \| f()`         |
| `&&=`        | Logical AND and assigns                  | `x && (x = f())`       |
| `\|\|=`      | Logical OR and assigns                   | `x \|\| (x = f())`     |
| `??=`        | Nullish coalescing and assigns           | `x ?? (x = f())`       |
</details>


<details>
  <summary>
    <h3>Comparison operators</h3>
  </summary>

| **Operator**  | **Description**                                      | **Example**        | **Result** |
| ------------- | ---------------------------------------------------- | ------------------ | ---------- |
| `==`          | Equality (with type coercion)                        | `5 == '5'`         | `true`     |
| `===`         | Strict equality (without type coercion)              | `5 === '5'`        | `false`    |
| `!=`          | Inequality (with type coercion)                      | `5 != '5'`         | `false`    |
| `!==`         | Strict inequality (without type coercion)            | `5 !== '5'`        | `true`     |
| `>`           | Greater than                                         | `10 > 5`           | `true`     |
| `>=`          | Greater than or equal                                | `5 >= 5`           | `true`     |
| `<`           | Less than                                            | `5 < 10`           | `true`     |
| `<=`          | Less than or equal                                   | `5 <= 10`          | `true`     |
| `Object.is()` | Strict equality, special handling for `NaN` and `-0` | `Object.is(0, -0)` | `false`    |

- When to Use Which Operator:

  - Use == for loose equality (when you want type coercion).
  - Use === for strict equality (when you want to avoid type coercion).
  - Use != for loose inequality (when type coercion is acceptable).
  - Use !== for strict inequality (when type coercion should be avoided).
  - Use >, >=, <, <= for numerical or lexicographical comparisons.
  - Use Object.is() when you need to compare values strictly, with special handling for NaN and -0.
</details>


<details>
  <summary>
    <h3>Arithmetic operators</h3>
  </summary>

| **Operator** | **Description**                  | **Example** | **Result** |
| ------------ | -------------------------------- | ----------- | ---------- |
| `+`          | Addition or string concatenation | `5 + 3`     | `8`        |
| `-`          | Subtraction                      | `10 - 5`    | `5`        |
| `*`          | Multiplication                   | `4 * 3`     | `12`       |
| `/`          | Division                         | `10 / 2`    | `5`        |
| `%`          | Remainder (modulo)               | `10 % 3`    | `1`        |
| `**`         | Exponentiation                   | `2 ** 3`    | `8`        |

</details>


<details>
  <summary>
    <h3>Bitwise operators</h3>
  </summary>

| **Operator** | **Description**      | **Example** | **Result** |
| ------------ | -------------------- | ----------- | ---------- |
| `&`          | Bitwise AND          | `5 & 3`     | `1`        |
| `\| `        | Bitwise OR           | `5\| 3`     | `7`        |
| `^`          | Bitwise XOR          | `5 ^ 3`     | `6`        |
| `~`          | Bitwise NOT          | `~5`        | `-6`       |
| `<<`         | Left Shift           | `5 << 1`    | `10`       |
| `>>`         | Signed Right Shift   | `5 >> 1`    | `2`        |
| `>>>`        | Unsigned Right Shift | `5 >>> 1`   | `2`        |
</details>


<details>
  <summary>
    <h3>Logical operators</h3>
  </summary>

| **Operator** | **Description**                                                    | **Result**                                          |
| ------------ | ------------------------------------------------------------       | --------------------------------------------------- |
| `&&`         | **Logical AND**: Returns `true` if both operands are truthy.       | `true` if both are truthy, else `false`.            |
| `\|\| `      | **Logical OR**: Returns `true` if at least one operand is truthy.  | `true` if either is truthy, else `false`.           |
| `!`          | **Logical NOT**: Inverts the truthiness of the operand.            | `true` for falsy values, `false` for truthy values. |
| `??`         | **Nullish coalescing**: Returns expr1 if neither null/undefined; otherwise, returns expr2.                               |

</details>


<details>
  <summary>
    <h3>Conditional (ternary) operators</h3>
  </summary>

```js
condition ? val1 : val2

const status = age >= 18 ? "adult" : "minor";
```

- If condition is true, the operator has the value of val1. Otherwise it has the value of val2. You can use the conditional operator anywhere you would use a standard operator.

</details>

<details>
  <summary>
    <h3>Unary operators</h3>
  </summary>

#### 1. delete

- The delete operator deletes an object's property.

```js
delete object.property;
delete object[propertyKey];
delete objectName[index];
```

#### 2. typeof

- The typeof operator returns a string indicating the type of the unevaluated operand.

```js
const myFun = () => 5 + 2;
const shape = "round";
const size = 1;
const foo = ["Apple", "Mango", "Orange"];
const today = new Date();

typeof myFun; // returns "function"
typeof shape; // returns "string"
typeof size; // returns "number"
typeof foo; // returns "object"
typeof today; // returns "object"
typeof doesntExist; // returns "undefined"

typeof true; // returns "boolean"
typeof null; // returns "object"

typeof 62; // returns "number"
typeof "Hello world"; // returns "string"
```

#### 3. void

- The void operator specifies an expression to be evaluated without returning a value.

</details>



<details>
  <summary>
    <h3>Relational operators</h3>
  </summary>

#### 1. in

- The in operator returns true if the specified property is in the specified object.

```js
propNameOrNumber in objectName


// Arrays
const trees = ["redwood", "bay", "cedar", "oak", "maple"];
0 in trees; // returns true
3 in trees; // returns true
6 in trees; // returns false
"bay" in trees; // returns false
// (you must specify the index number, not the value at that index)
"length" in trees; // returns true (length is an Array property)

// built-in objects
"PI" in Math; // returns true
const myString = new String("coral");
"length" in myString; // returns true

// Custom objects
const myCar = { make: "Honda", model: "Accord", year: 1998 };
"make" in myCar; // returns true
"model" in myCar; // returns true

```

#### 2. instanceof

- The instanceof operator returns true if the specified object is of the specified object type.

```js
object instanceof objectType

const obj = new Map();
if (obj instanceof Map) {
  // statements to execute
}
```
</details>

---

## Destructuring

- The destructuring syntax is a JavaScript syntax that makes it possible to unpack values from arrays, or properties from objects, into distinct variables.

```js
const [a, b, c] = arr;
const { a, b, c } = obj;

const obj = { a: 1, b: { c: 2 } };
const {
  a,
  b: { c: d },
} = obj;
// Two variables are bound: `a` and `d`


const { a, ...others } = { a: 1, b: 2, c: 3 };
console.log(others); // { b: 2, c: 3 }

const [first, ...others2] = [1, 2, 3];
console.log(others2); // [2, 3]


const foo = ["one", "two"];

const [red, yellow, green, blue] = foo;
console.log(red); // "one"
console.log(yellow); // "two"
console.log(green); // undefined
console.log(blue); // undefined


let a = 1;
let b = 3;

[a, b] = [b, a];
console.log(a); // 3
console.log(b); // 1

const arr = [1, 2, 3];
[arr[2], arr[1]] = [arr[1], arr[2]];
console.log(arr); // [1, 3, 2]
```

---

## Math

| **Math Function**          | **Description**                                                          | **Example**             | **Result**          |
| -------------------------- | ------------------------------------------------------------------------ | ----------------------- | ------------------- |
| `Math.abs(x)`              | Returns the absolute value of `x`.                                       | `Math.abs(-5)`          | `5`                 |
| `Math.ceil(x)`             | Returns the smallest integer greater than or equal to `x`.               | `Math.ceil(5.3)`        | `6`                 |
| `Math.floor(x)`            | Returns the largest integer less than or equal to `x`.                   | `Math.floor(5.7)`       | `5`                 |
| `Math.round(x)`            | Returns the value of `x` rounded to the nearest integer.                 | `Math.round(5.5)`       | `6`                 |
| `Math.pow(base, exponent)` | Returns the base raised to the power of the exponent.                    | `Math.pow(2, 3)`        | `8`                 |
| `Math.sqrt(x)`             | Returns the square root of `x`.                                          | `Math.sqrt(16)`         | `4`                 |
| `Math.min(x, y, ...)`      | Returns the smallest of the arguments.                                   | `Math.min(5, 1, 9, 0)`  | `0`                 |
| `Math.max(x, y, ...)`      | Returns the largest of the arguments.                                    | `Math.max(5, 1, 9, 0)`  | `9`                 |
| `Math.random()`            | Returns a random number between 0 (inclusive) and 1 (exclusive).         | `Math.random()`         | `0.54321` (example) |
| `Math.log(x)`              | Returns the natural logarithm (base `e`) of `x`.                         | `Math.log(10)`          | `2.302585`          |
| `Math.log10(x)`            | Returns the base 10 logarithm of `x`.                                    | `Math.log10(100)`       | `2`                 |
| `Math.log2(x)`             | Returns the base 2 logarithm of `x`.                                     | `Math.log2(8)`          | `3`                 |
| `Math.sin(x)`              | Returns the sine of `x` (x in radians).                                  | `Math.sin(Math.PI / 2)` | `1`                 |
| `Math.cos(x)`              | Returns the cosine of `x` (x in radians).                                | `Math.cos(Math.PI)`     | `-1`                |
| `Math.tan(x)`              | Returns the tangent of `x` (x in radians).                               | `Math.tan(Math.PI / 4)` | `1`                 |
| `Math.abs(x)`              | Returns the absolute value of `x`.                                       | `Math.abs(-10)`         | `10`                |
| `Math.trunc(x)`            | Returns the integer part of `x`, removing any fractional digits.         | `Math.trunc(5.99)`      | `5`                 |
| `Math.sign(x)`             | Returns the sign of `x`: `-1` (negative), `0` (zero), or `1` (positive). | `Math.sign(-4)`         | `-1`                |
| `Math.imul(a, b)`          | Returns the result of a 32-bit integer multiplication.                   | `Math.imul(2, 3)`       | `6`                 |
| `Math.cbrt(x)`             | Returns the cube root of `x`.                                            | `Math.cbrt(27)`         | `3`                 |
| `Math.expm1(x)`            | Returns `e^x - 1` (i.e., exponential function minus 1).                  | `Math.expm1(1)`         | `1.71828`           |
| `Math.hypot(x, y)`         | Returns the square root of the sum of squares of its arguments.          | `Math.hypot(3, 4)`      | `5`                 |
| `Math.sinh(x)`             | Returns the hyperbolic sine of `x`.                                      | `Math.sinh(1)`          | `1.175201`          |
| `Math.cosh(x)`             | Returns the hyperbolic cosine of `x`.                                    | `Math.cosh(1)`          | `1.543081`          |
| `Math.tanh(x)`             | Returns the hyperbolic tangent of `x`.                                   | `Math.tanh(1)`          | `0.761594`          |


---

## 
