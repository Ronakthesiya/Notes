## Module Export

- two different types of export, 
    - named export 
    - default export

### Named exports

```js
// export features declared elsewhere
export { myFunction2, myVariable2 };

// export individual features (can export var, let,
// const, function, class)
export let myVariable = Math.sqrt(2);
export function myFunction() {
  // …
}
```

### Default exports

```js
// export feature declared elsewhere as default
export { myFunction as default };
// This is equivalent to:
export default myFunction;

// export individual features as default
export default function () { /* … */ }
export default class { /* … */ }
```

## Module Import

```js
import defaultExport from "module-name";
import * as name from "module-name";
import { export1 } from "module-name";
import { export1 as alias1 } from "module-name";
import { default as alias } from "module-name";
import { export1, export2 } from "module-name";
import { export1, export2 as alias2, /* … */ } from "module-name";
import { "string name" as alias } from "module-name";
import defaultExport, { export1, /* … */ } from "module-name";
import defaultExport, * as name from "module-name";
import "module-name";
```

## Promise

- instead of immediately returning the final value, the asynchronous method returns a promise to supply the value at some point in the future.

### states

- pending: initial state, neither fulfilled nor rejected.
- fulfilled: meaning that the operation was completed successfully.
- rejected: meaning that the operation failed.

```js
const myPromise = new Promise((resolve, reject) => {
  setTimeout(() => {
    resolve("foo");
  }, 300);
});

myPromise
  .then(handleFulfilledA, handleRejectedA)
  .then(handleFulfilledB, handleRejectedB)
  .then(handleFulfilledC, handleRejectedC);
```

- The then() method takes up to two arguments; the first argument is a callback function for the fulfilled case of the promise, and the second argument is a callback function for the rejected case. 
- The catch() and finally() methods call then() internally and make error handling less verbose. 
- For example, a catch() is really just a then() without passing the fulfillment handler.

### static methods of promise

#### 1. all()

- static method takes an iterable of promises as input and returns a single Promise.
- This returned promise fulfills when all of the input's promises fulfill (including when an empty iterable is passed), with an array of the fulfillment values.

```js
const promise1 = Promise.resolve(3);
const promise2 = 42;
const promise3 = new Promise((resolve, reject) => {
  setTimeout(resolve, 100, "foo");
});

Promise.all([promise1, promise2, promise3]).then((values) => {
  console.log(values);
});
// Expected output: Array [3, 42, "foo"]
```

- Return value
- A Promise that is:
    - Already fulfilled, if the iterable passed is empty.
    - Asynchronously fulfilled, when all the promises in the given iterable fulfill. The fulfillment value is an array of fulfillment values, in the order of the promises passed, regardless of completion order. If the iterable passed is non-empty but contains no pending promises, the returned promise is still asynchronously (instead of synchronously) fulfilled.
    - Asynchronously rejected, when any of the promises in the given iterable rejects. The rejection reason is the rejection reason of the first promise that was rejected.

#### 2. allSettled()

- static method takes an iterable of promises as input and returns a single Promise. This returned promise fulfills when all of the input's promises settle (including when an empty iterable is passed), with an array of objects that describe the outcome of each promise.

```js
const promise1 = Promise.resolve(3);
const promise2 = new Promise((resolve, reject) =>
  setTimeout(reject, 100, "foo"),
);
const promises = [promise1, promise2];

Promise.allSettled(promises).then((results) =>
  results.forEach((result) => console.log(result.status)),
);

// Expected output:
// "fulfilled"
// "rejected"

```

- Return value
- A Promise that is :
    - Already fulfilled, if the iterable passed is empty.
    - Asynchronously fulfilled, when all promises in the given iterable have settled (either fulfilled or rejected). The fulfillment value is an array of objects, each describing the outcome of one promise in the iterable, in the order of the promises passed, regardless of completion order. Each outcome object has the following properties:
        - status : A string, either "fulfilled" or "rejected", indicating the eventual state of the promise.
        - value : Only present if status is "fulfilled". The value that the promise was fulfilled with.
        - reason : Only present if status is "rejected". The reason that the promise was rejected with.

#### 3. any()

- static method takes an iterable of promises as input and returns a single Promise.
- This returned promise fulfills when any of the input's promises fulfills, with this first fulfillment value.
- It rejects when all of the input's promises reject (including when an empty iterable is passed), with an AggregateError containing an array of rejection reasons.

```js
const promise1 = Promise.reject(new Error("error"));
const promise2 = new Promise((resolve) => setTimeout(resolve, 100, "quick"));
const promise3 = new Promise((resolve) => setTimeout(resolve, 500, "slow"));

const promises = [promise1, promise2, promise3];

Promise.any(promises).then((value) => console.log(value));

// Expected output: "quick"
```

- Return value
- A Promise that is:

    - Already rejected, if the iterable passed is empty.
    - Asynchronously fulfilled, when any of the promises in the given iterable fulfills. The fulfillment value is the fulfillment value of the first promise that was fulfilled.
    - Asynchronously rejected, when all of the promises in the given iterable reject. The rejection reason is an AggregateError containing an array of rejection reasons in its errors property. The errors are in the order of the promises passed, regardless of completion order. If the iterable passed is non-empty but contains no pending promises, the returned promise is still asynchronously (instead of synchronously) rejected.

```js
const pErr = new Promise((resolve, reject) => {
  reject(new Error("Always fails"));
});

const pSlow = new Promise((resolve, reject) => {
  setTimeout(resolve, 500, "Done eventually");
});

const pFast = new Promise((resolve, reject) => {
  setTimeout(resolve, 100, "Done quick");
});

Promise.any([pErr, pSlow, pFast]).then((value) => {
  console.log(value);
  // pFast fulfills first
});
// Logs:
// Done quick
```

#### 4. race()

- static method takes an iterable of promises as input and returns a single Promise. This returned promise settles with the eventual state of the first promise that settles.

```js
const promise1 = new Promise((resolve, reject) => {
  setTimeout(resolve, 500, "one");
});

const promise2 = new Promise((resolve, reject) => {
  setTimeout(resolve, 100, "two");
});

Promise.race([promise1, promise2]).then((value) => {
  console.log(value);
  // Both resolve, but promise2 is faster
});
// Expected output: "two"
```

#### 5. reject()

- static method returns a Promise object that is rejected with a given reason.

```js
Promise.reject(reason)
```

#### 6. resolve()

- static method "resolves" a given value to a Promise

```js
const promise1 = Promise.resolve(123);

promise1.then((value) => {
  console.log(value);
  // Expected output: 123
});

```

### Instance methods

#### catch()

- The catch() method of Promise instances schedules a function to be called when the promise is rejected. 
- It immediately returns another Promise object, allowing you to chain calls to other promise methods.
- It is a shortcut for then(undefined, onRejected).

#### finally()

- The finally() method of Promise instances schedules a function to be called when the promise is settled (either fulfilled or rejected).
- It immediately returns another Promise object, allowing you to chain calls to other promise methods.

#### then()

- The then() method of Promise instances takes up to two arguments: callback functions for the fulfilled and rejected cases of the Promise.
- It stores the callbacks within the promise it is called on and immediately returns another Promise object, allowing you to chain calls to other promise methods.


## Async Await



