## jQuery

- jQuery is just a JavaScript library.
- just JavaScript inside.
- You → jQuery → JavaScript → Browser → DOM.

## Methods

### $( document ).ready()

- Code included inside $( document ).ready() will only run once the page Document Object Model (DOM) is ready for JavaScript code to execute.

- Code included inside $( window ).on( "load", function() { ... }) will run once the entire page (images or iframes), not just the DOM, is ready.

```js
$( document ).ready(function() {
    console.log( "ready!" );
});
```

- use the shorthand $() for $( document ).ready()

```js
$(function() {
    console.log( "ready!" );
});
```

```js
// Passing a named function instead of an anonymous function.
 
function readyFn( jQuery ) {
    // Code to run when the document is ready.
}
 
$( document ).ready( readyFn );
// or:
$( window ).on( "load", readyFn );
```

### jQuery Avoiding Conflicts with Other Libraries

- The jQuery.noConflict() method returns a reference to the jQuery function, so you can capture it in whatever variable you'd like:

```js
var $jq = jQuery.noConflict();
```

- Use the Argument That's Passed to the jQuery( document ).ready() Function

```js
jQuery(document).ready(function( $ ) {
    // Your jQuery code here, using $ to refer to jQuery.
});
```

### Attributes Manipulation

- The .attr() method acts as both a getter and a setter.
- As a setter, .attr() can accept either a key and a value, or an object containing one or more key/value pairs.
- .attr() as a setter:

```js
$( "a" ).attr( "href", "allMyHrefsAreTheSameNow.html" );
 
$( "a" ).attr({
    title: "all titles are the same too!",
    href: "somethingNew.html"
});
```

- .attr() as a getter:

```js
$( "a" ).attr( "href" ); // Returns the href for the first a element in the document
```

### Selectors

| **Selector**               | **Example**                     | **Explanation**                                                                                   |
| -------------------------- | ------------------------------- | ------------------------------------------------------------------------------------------------- |
| **`*`**                    | `$('div *')`                    | Selects all elements inside the matched element(s) (descendants).                                 |
| **`#id`**                  | `$('#header')`                  | Selects an element with the given `id` attribute.                                                 |
| **`.class`**               | `$('.active')`                  | Selects all elements with the specified `class` attribute.                                        |
| **`element`**              | `$('div')`                      | Selects all `<div>` elements in the DOM.                                                          |
| **`element#id`**           | `$('div#header')`               | Selects a specific element with the specified tag and `id` attribute.                             |
| **`element.class`**        | `$('div.active')`               | Selects all `<div>` elements with the specified `class` attribute.                                |
| **`element:selector`**     | `$('div:first')`                | Selects the first `<div>` element. The `:first` is a filtering pseudo-class.                      |
| **`element:even`**         | `$('li:even')`                  | Selects even-indexed `<li>` elements (0-based index).                                             |
| **`element:odd`**          | `$('li:odd')`                   | Selects odd-indexed `<li>` elements (0-based index).                                              |
| **`:first`**               | `$('div:first')`                | Selects the first matched element in the set of matched elements.                                 |
| **`:last`**                | `$('div:last')`                 | Selects the last matched element in the set of matched elements.                                  |
| **`:eq(index)`**           | `$('li:eq(1)')`                 | Selects the element at the specified zero-based index.                                            |
| **`:gt(index)`**           | `$('li:gt(1)')`                 | Selects all elements after the specified zero-based index.                                        |
| **`:lt(index)`**           | `$('li:lt(1)')`                 | Selects all elements before the specified zero-based index.                                       |
| **`:not(selector)`**       | `$('div:not(.active)')`         | Selects all elements that do not match the specified selector.                                    |
| **`:has(selector)`**       | `$('div:has(.highlight)')`      | Selects elements that contain at least one element matching the specified selector.               |
| **`:contains(text)`**      | `$('p:contains("hello")')`      | Selects elements that contain the specified text.                                                 |
| **`:empty`**               | `$('div:empty')`                | Selects all elements that do not have any children (including text nodes).                        |
| **`:parent`**              | `$('div:parent')`               | Selects all elements that have one or more child elements.                                        |
| **`:checkbox`**            | `$('input:checkbox')`           | Selects all checkbox input elements (`<input type="checkbox">`).                                  |
| **`:radio`**               | `$('input:radio')`              | Selects all radio input elements (`<input type="radio">`).                                        |
| **`:selected`**            | `$('option:selected')`          | Selects all selected option elements in a `<select>` dropdown.                                    |
| **`:checked`**             | `$('input:checked')`            | Selects all checked input elements (checkboxes or radio buttons).                                 |
| **`:disabled`**            | `$('input:disabled')`           | Selects all disabled input elements.                                                              |
| **`:enabled`**             | `$('input:enabled')`            | Selects all enabled input elements.                                                               |
| **`:focus`                 | `$('input:focus')`              | Selects all input elements that have focus.                                                       |
| **`:visible`**             | `$('div:visible')`              | Selects all visible elements (excluding hidden elements).                                         |
| **`:hidden`**              | `$('div:hidden')`               | Selects all hidden elements (elements with `display: none` or `visibility: hidden`).              |
| **`:input`**               | `$('form :input')`              | Selects all input elements, including text, password, checkbox, and radio button elements.        |
| **`:button`**              | `$('button:button')`            | Selects all `<button>` elements.                                                                  |
| **`:text`**                | `$('input:text')`               | Selects all `<input>` elements of type "text".                                                    |
| **`:password`**            | `$('input:password')`           | Selects all `<input>` elements of type "password".                                                |
| **`:submit`**              | `$('input:submit')`             | Selects all `<input>` elements of type "submit".                                                  |
| **`:reset`**               | `$('input:reset')`              | Selects all `<input>` elements of type "reset".                                                   |
| **`:file`**                | `$('input:file')`               | Selects all `<input>` elements of type "file".                                                    |
| **`:image`**               | `$('input:image')`              | Selects all `<input>` elements of type "image".                                                   |
| **`:radio`**               | `$('input:radio')`              | Selects all radio button `<input>` elements.                                                      |
| **`:checked`**             | `$('input:checked')`            | Selects all checked `<input>` elements (checkboxes or radio buttons).                             |
| **`:not(selector)`**       | `$('div:not(.class)')`          | Selects all elements that do not match the specified selector.                                    |
| **`:nth-child(n)`**        | `$('li:nth-child(odd)')`        | Selects elements based on their position in a list of siblings (1-based index).                   |
| **`:nth-last-child(n)`**   | `$('li:nth-last-child(odd)')`   | Selects elements based on their position from the last child (1-based index).                     |
| **`:nth-of-type(n)`**      | `$('li:nth-of-type(odd)')`      | Selects elements based on their position among siblings of the same type.                         |
| **`:nth-last-of-type(n)`** | `$('li:nth-last-of-type(odd)')` | Selects elements based on their position among siblings of the same type, starting from the last. |
| **`:only-child`**          | `$('div:only-child')`           | Selects elements that are the only child of their parent.                                         |
| **`:only-of-type`**        | `$('div:only-of-type')`         | Selects elements that are the only element of their type in their parent.                         |
| **`:empty`**               | `$('div:empty')`                | Selects elements that do not have any child elements or text nodes.                               |
| **`:root`**                | `$('html:root')`                | Selects the root element of the document (e.g., `<html>` for HTML documents).                     |


### Chaining

- If you call a method on a selection and that method returns a jQuery object, you can continue to call jQuery methods on the object 

```js
$( "#content" ).find( "h3" ).eq( 2 ).html( "new text for the third h3!" );
```

- jQuery also provides the .end() method to get back to the original selection should you change the selection in the middle of a chain:

```js
$( "#content" )
    .find( "h3" )
    .eq( 2 )
        .html( "new text for the third h3!" )
        .end() // Restores the selection to all h3s in #content
    .eq( 0 )
        .html( "new text for the first h3!" );
```

### Manipulating Elements

- .html() – Get or set the HTML contents.
- .text() – Get or set the text contents; HTML will be stripped.
- .attr() – Get or set the value of the provided attribute.
- .width() – Get or set the width in pixels of the first element in the selection as an integer.
- .height() – Get or set the height in pixels of the first element in the selection as an integer.
- .position() – Get an object with position information for the first element in the selection, relative to its first positioned ancestor. This is a getter only.
- .val() – Get or set the value of form elements.


| **Method**                        | **Example**                                         | **Explanation**                                                                                      |
| --------------------------------- | --------------------------------------------------- | ---------------------------------------------------------------------------------------------------- |
| **`append(content)`**             | `$('#div').append('<p>Hello</p>');`                 | Adds specified content inside each element in the set of matched elements, as the last child.        |
| **`appendTo(target)`**            | `$('#div').appendTo('#container');`                 | Appends each element in the set of matched elements to the target.                                   |
| **`before(content)`**             | `$('#div').before('<p>Hello</p>');`                 | Inserts content before each element in the set of matched elements.                                  |
| **`insertBefore(target)`**        | `$('#div').insertBefore('#header');`                | Inserts each element in the set of matched elements before the specified target.                     |
| **`after(content)`**              | `$('#div').after('<p>Hello</p>');`                  | Inserts content after each element in the set of matched elements.                                   |
| **`insertAfter(target)`**         | `$('#div').insertAfter('#header');`                 | Inserts each element in the set of matched elements after the specified target.                      |
| **`prepend(content)`**            | `$('#div').prepend('<p>Hello</p>');`                | Adds specified content inside each element in the set of matched elements, as the first child.       |
| **`prependTo(target)`**           | `$('#div').prependTo('#container');`                | Prepends each element in the set of matched elements to the target.                                  |
| **`replaceWith(content)`**        | `$('#div').replaceWith('<p>Hello</p>');`            | Replaces each element in the set of matched elements with the specified content.                     |
| **`replaceAll(target)`**          | `$('#div').replaceAll('#header');`                  | Replaces each element in the set of matched elements with the target element.                        |
| **`wrap(content)`**               | `$('#div').wrap('<div class="wrapper"></div>');`    | Wraps each element in the set of matched elements with the specified content.                        |
| **`wrapAll(content)`**            | `$('#div').wrapAll('<div class="wrapper"></div>');` | Wraps all elements in the set of matched elements with the specified content.                        |
| **`wrapInner(content)`**          | `$('#div').wrapInner('<span></span>');`             | Wraps the inner content of each element in the set of matched elements with the specified content.   |
| **`unwrap()`**                    | `$('#div').unwrap();`                               | Removes the parents of each element in the set of matched elements, leaving the elements themselves. |
| **`remove()`**                    | `$('#div').remove();`                               | Removes the selected elements from the DOM, along with their data and events.                        |
| **`empty()`**                     | `$('#div').empty();`                                | Removes all child nodes of each element in the set of matched elements.                              |
| **`clone([withDataAndEvents])`**  | `$('#div').clone(true);`                            | Creates a deep copy of the selected element(s), including their event handlers and data.             |
| **`detach([withDataAndEvents])`** | `$('#div').detach(true);`                           | Removes the selected elements from the DOM but keeps all associated data and events.                 |
| **`insert()`**                    | `$('#div').insert('<p>Hello</p>');`                 | Insert the specified content inside each of the selected elements at a specific location in the DOM. |


### Traversing DOM

#### Parents

```js
<div class="grandparent">
    <div class="parent">
        <div class="child">
            <span class="subchild"></span>
        </div>
    </div>
    <div class="surrogateParent1"></div>
    <div class="surrogateParent2"></div>
</div>
```

```js
// Selecting an element's direct parent:
 
// returns [ div.child ]
$( "span.subchild" ).parent();
 
// Selecting all the parents of an element that match a given selector:
 
// returns [ div.parent ]
$( "span.subchild" ).parents( "div.parent" );
 
// returns [ div.child, div.parent, div.grandparent ]
$( "span.subchild" ).parents();
 
// Selecting all the parents of an element up to, but *not including* the selector:
 
// returns [ div.child, div.parent ]
$( "span.subchild" ).parentsUntil( "div.grandparent" );
 
// Selecting the closest parent, note that only one parent will be selected
// and that the initial element itself is included in the search:
 
// returns [ div.child ]
$( "span.subchild" ).closest( "div" );
 
// returns [ div.child ] as the selector is also included in the search:
$( "div.child" ).closest( "div" );
```

#### Children

```js
// Selecting an element's direct children:
 
// returns [ div.parent, div.surrogateParent1, div.surrogateParent2 ]
$( "div.grandparent" ).children( "div" );
 
// Finding all elements within a selection that match the selector:
 
// returns [ div.child, div.parent, div.surrogateParent1, div.surrogateParent2 ]
$( "div.grandparent" ).find( "div" );
```

#### Siblings

```js
// Selecting a next sibling of the selectors:
 
// returns [ div.surrogateParent1 ]
$( "div.parent" ).next();
 
// Selecting a prev sibling of the selectors:
 
// returns [] as No sibling exists before div.parent
$( "div.parent" ).prev();
 
// Selecting all the next siblings of the selector:
 
// returns [ div.surrogateParent1, div.surrogateParent2 ]
$( "div.parent" ).nextAll();
 
// returns [ div.surrogateParent1 ]
$( "div.parent" ).nextAll().first();
 
// returns [ div.surrogateParent2 ]
$( "div.parent" ).nextAll().last();
 
// Selecting all the previous siblings of the selector:
 
// returns [ div.surrogateParent1, div.parent ]
$( "div.surrogateParent2" ).prevAll();
 
// returns [ div.surrogateParent1 ]
$( "div.surrogateParent2" ).prevAll().first();
 
// returns [ div.parent ]
$( "div.surrogateParent2" ).prevAll().last();

// Selecting an element's siblings in both directions that matches the given selector:
 
// returns [ div.surrogateParent1, div.surrogateParent2 ]
$( "div.parent" ).siblings();
 
// returns [ div.parent, div.surrogateParent2 ]
$( "div.surrogateParent1" ).siblings();
```

## CSS, Styling, & Dimensions 

### Getting CSS properties.

```js
$( "h1" ).css( "fontSize" ); // Returns a string such as "19px".
 
$( "h1" ).css( "font-size" ); // Also works.
```

### Setting CSS properties.

```js
$( "h1" ).css( "fontSize", "100px" ); // Setting an individual property.
 
// Setting multiple properties.
$( "h1" ).css({
    fontSize: "100px",
    color: "red"
});
```

### Height & Width

- .height() / .width()
Get the current computed height for the first element in the set of matched elements or set the height of every matched element.

- .innerHeight() / .innerWidth()
Get the current computed inner height (including padding but not border) for the first element in the set of matched elements or set the inner height of every matched element.

- .outerHeight() / .outerWidth()
Get the current computed outer height (including padding, border, and optionally margin) for the first element in the set of matched elements or set the outer height of every matched element.

## Utility Methods

| **Method**                   | **Syntax**                                             | **Description**                                                                                        | **Example**                                                                                                                                                                        | **Output**                          |
| ---------------------------- | ------------------------------------------------------ | ------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| **`jQuery.each()`**          | `jQuery.each(object, function(index, value) { ... });` | Iterates over an array, object, or array-like object and applies a function to each item.              | var colors = ["red", "blue", "green"];<br>jQuery.each(colors, function(index, value) {<br>console.log(index + ": " + value);<br>});                                | `0: red`<br>`1: blue`<br>`2: green` |
| **`jQuery.extend()`**        | `jQuery.extend(target, object1, object2, ...);`        | Extends one object with properties from other objects. Merges multiple objects into the target object. | var defaults = {color: "red", size: "medium"};<br>var options = {size: "large"};<br>var settings = jQuery.extend({}, defaults, options);<br>console.log(settings); | `{ color: "red", size: "large" }`   |
| **`jQuery.inArray()`**       | `jQuery.inArray(value, array);`                        | Searches for a specific value in an array and returns the index if found, or `-1` if not found.        | var fruits = ["apple", "banana", "cherry"];<br>var index = jQuery.inArray("banana", fruits);<br>console.log(index);                                                | `1`                                 |
| **`jQuery.isArray()`**       | `jQuery.isArray(obj);`                                 | Checks if the passed argument is an array.                                                             | var arr = [1, 2, 3];<br>console.log(jQuery.isArray(arr));                                                                                                          | `true`                              |
| **`jQuery.isEmptyObject()`** | `jQuery.isEmptyObject(obj);`                           | Checks if an object has no enumerable properties.                                                      | var obj = {};<br>console.log(jQuery.isEmptyObject(obj));                                                                                                           | `true`                              |
| **`jQuery.isFunction()`**    | `jQuery.isFunction(obj);`                              | Determines if a given object is a function.                                                            | function test() {}<br>console.log(jQuery.isFunction(test));                                                                                                        | `true`                              |
| **`jQuery.isNumeric()`**     | `jQuery.isNumeric(value);`                             | Determines if the value is numeric or can be converted to a number.                                    | console.log(jQuery.isNumeric("123"));<br>console.log(jQuery.isNumeric("abc"));                                                                                     | `true`<br>`false`                   |
| **`jQuery.isPlainObject()`** | `jQuery.isPlainObject(obj);`                           | Checks if an object is a plain object (created by `{}` or `new Object()`).                             | var obj = {name: "John"};<br>console.log(jQuery.isPlainObject(obj));                                                                                               | `true`                              |
| **`jQuery.isWindow()`**      | `jQuery.isWindow(obj);`                                | Checks if the object is a `window` object.                                                             | console.log(jQuery.isWindow(window));                                                                                                                              | `true`                              |
| **`jQuery.map()`**           | `jQuery.map(array, function(value, index) { ... });`   | Transforms an array or object into a new array by applying a function to each item.                    | var numbers = [1, 2, 3];<br>var doubled = jQuery.map(numbers, function(num) {<br>return num * 2;<br>});<br>console.log(doubled);                                   | `[2, 4, 6]`                         |
| **`jQuery.merge()`**         | `jQuery.merge(array1, array2);`                        | Merges two arrays into one.                                                                            | var array1 = [1, 2];<br>var array2 = [3, 4];<br>var merged = jQuery.merge(array1, array2);<br>console.log(merged);                                                 | `[1, 2, 3, 4]`                      |
| **`jQuery.noConflict()`**    | `jQuery.noConflict();`                                 | Releases control of the `$` variable so that it can be used by other libraries.                        | jQuery.noConflict();<br>var jq = jQuery.noConflict();<br>jq('p').text('Hello, jQuery!');                                                                           | `<p>Hello, jQuery!</p>`             |
| **`jQuery.trim()`**          | `jQuery.trim(string);`                                 | Removes whitespace from the beginning and end of a string.                                             | var str = "   Hello, world!   ";<br>console.log(jQuery.trim(str));                                                                                                 | `"Hello, world!"`                   |
| **`jQuery.type()`**          | `jQuery.type(obj);`                                    | Returns the type of an object.                                                                         | console.log(jQuery.type([1, 2, 3]));<br>console.log(jQuery.type(42));                                                                                              | `"array"`<br>`"number"`             |
| **`jQuery.unique()`**        | `jQuery.unique(array);`                                | Removes duplicate elements from an array.                                                              | var nums = [1, 2, 2, 3, 4, 4];<br>var uniqueNums = jQuery.unique(nums);<br>console.log(uniqueNums);                                                                | `[1, 2, 3, 4]`                      |
| **`jQuery.grep()`**        | `jQuery.grep(array, function(elementOfArray, indexInArray));`                                | returns elements from an array whose return true from function like reduce.                                                              | var nums = [1, 2, 2, 3, 4, 4];<br>var Nums = jQuery.grep(nums, function(val,index){return (n>2)});<br>console.log(Nums);                                                                | `[3, 4, 4]`                      |


## Events

### Common Methods for Binding Events

#### 1. .on()

- This method is used for attaching event handlers to elements.
- It allows binding multiple events, including custom events, and supports event delegation.

```js
$(selector).on(event, childSelector, data, function)
```

#### 2. Shorthand Methods

- shorthand methods for commonly used events such as .click(), .hover(), .focus(), .blur(), and others.
- These are convenient, but less flexible than .on().

```js
$("button").click(function() {
    alert("Button clicked!");
});
```

### Event Object

- jQuery automatically passes an event object to the event handler.

    - event.target: The element that triggered the event.
    - event.type: The type of event (e.g., click, keydown).
    - event.pageX, event.pageY: The mouse coordinates when the event was triggered.
    - event.which: The keycode for keyboard events (e.g., keyPress).
    - event.preventDefault(): Prevents the default action associated with the event (e.g., prevents a form submission or link navigation).
    - event.stopPropagation(): Stops the event from bubbling up the DOM tree or being passed to other handlers.

### Event Delegation

- Event delegation is a technique where you bind an event to a parent element rather than directly to a child element
- This is particularly useful when dealing with dynamically added elements
- This technique is used in .on(), where you specify a child element to handle the event.

```js
$("#parent").on("click", ".child", function() {
    alert("Child element clicked!");
});
```

### Removing Event Handlers

- You can remove event handlers from elements using the .off() method. This method detaches an event handler from an element.

```js
$(selector).off(event, handler);
$("#myButton").off("click");  // Removes the click event handler
```

### Events

| **Category**                     | **Event**        | **Description**                                                                           |
| -------------------------------- | ---------------- | ----------------------------------------------------------------------------------------- |
| **Mouse Events**                 | `click`          | Triggered when an element is clicked.                                                     |
|                                  | `dblclick`       | Triggered when an element is double-clicked.                                              |
|                                  | `mouseenter`     | Triggered when the mouse pointer enters an element.                                       |
|                                  | `mouseleave`     | Triggered when the mouse pointer leaves an element.                                       |
|                                  | `mousemove`      | Triggered when the mouse pointer moves over an element.                                   |
|                                  | `mouseover`      | Triggered when the mouse pointer enters an element or one of its child elements.          |
|                                  | `mouseout`       | Triggered when the mouse pointer leaves an element or one of its child elements.          |
|                                  | `mousedown`      | Triggered when the mouse button is pressed on an element.                                 |
|                                  | `mouseup`        | Triggered when the mouse button is released on an element.                                |
| **Keyboard Events**              | `keydown`        | Triggered when a key is pressed down.                                                     |
|                                  | `keypress`       | Triggered when a character key is pressed down (does not trigger for non-character keys). |
|                                  | `keyup`          | Triggered when a key is released.                                                         |
| **Form Events**                  | `submit`         | Triggered when a form is submitted.                                                       |
|                                  | `change`         | Triggered when the value of an input, select, or textarea changes.                        |
|                                  | `focus`          | Triggered when an element gains focus (e.g., input field is selected).                    |
|                                  | `blur`           | Triggered when an element loses focus (e.g., input field is deselected).                  |
|                                  | `input`          | Triggered when the user types into an `<input>` or `<textarea>` element.                  |
|                                  | `select`         | Triggered when text is selected inside an input or textarea element.                      |
|                                  | `reset`          | Triggered when a form is reset.                                                           |
|                                  | `focusin`        | Triggered when an element is focused (bubbling version of `focus`).                       |
|                                  | `focusout`       | Triggered when an element loses focus (bubbling version of `blur`).                       |
| **Window and Document Events**   | `resize`         | Triggered when the browser window is resized.                                             |
|                                  | `scroll`         | Triggered when the document or an element is scrolled.                                    |
|                                  | `load`           | Triggered when a document, image, script, or other resource finishes loading.             |
|                                  | `unload`         | Triggered when the document is unloaded (e.g., when the user leaves the page).            |
|                                  | `beforeunload`   | Triggered before the page is unloaded, used for warnings.                                 |
| **Touch Events**                 | `touchstart`     | Triggered when the user touches the screen.                                               |
|                                  | `touchend`       | Triggered when the user removes their finger from the screen.                             |
|                                  | `touchmove`      | Triggered when the user moves their finger along the screen.                              |
|                                  | `touchcancel`    | Triggered when the touch event is interrupted (e.g., a call or an alert).                 |
| **Drag and Drop Events**         | `drag`           | Triggered during a drag operation.                                                        |
|                                  | `dragstart`      | Triggered when the user starts dragging an element.                                       |
|                                  | `dragend`        | Triggered when the drag operation is completed or canceled.                               |
|                                  | `dragenter`      | Triggered when the dragged element enters a drop target.                                  |
|                                  | `dragover`       | Triggered while the dragged element is over a drop target.                                |
|                                  | `dragleave`      | Triggered when the dragged element leaves a drop target.                                  |
|                                  | `drop`           | Triggered when the dragged element is dropped on a drop target.                           |
| **Media Events**                 | `play`           | Triggered when media starts playing.                                                      |
|                                  | `pause`          | Triggered when media is paused.                                                           |
|                                  | `ended`          | Triggered when media playback has finished.                                               |
|                                  | `timeupdate`     | Triggered when the playback position of the media changes.                                |
|                                  | `volumechange`   | Triggered when the volume of the media changes.                                           |
|                                  | `seeking`        | Triggered when the user starts seeking through the media.                                 |
|                                  | `seeked`         | Triggered when the user completes seeking through the media.                              |
|                                  | `canplay`        | Triggered when the browser can start playing the media.                                   |
|                                  | `canplaythrough` | Triggered when the browser can play the media to the end without buffering.               |
| **Custom Events**                | `customEvent`    | Custom events triggered programmatically with `.trigger()`.                               |
| **Clipboard Events**             | `copy`           | Triggered when a copy action occurs (e.g., `Ctrl+C`).                                     |
|                                  | `cut`            | Triggered when a cut action occurs (e.g., `Ctrl+X`).                                      |
|                                  | `paste`          | Triggered when a paste action occurs (e.g., `Ctrl+V`).                                    |
| **Animation and Effects Events** | `animate`        | Triggered when an element is animated using jQuery.                                       |
|                                  | `finish`         | Triggered when an animation finishes.                                                     |
|                                  | `start`          | Triggered when an animation starts.                                                       |
|                                  | `stop`           | Triggered when an animation is stopped.                                                   |
| **Form Validation Events**       | `invalid`        | Triggered when an invalid form element is submitted.                                      |
|                                  | `valid`          | Triggered when a valid form element has been successfully validated.                      |


## validation

### menual 

- check when the form submit and add span tag message after all input based on conditions in function validation

### plugin

- use jQuery validation plugin
- script or file download and add with jQuery script

#### how to do validation

- validate method is used to assign rules, message and other things

```js
// form

<form action="" id="form1">
    <input class="form-control" type="text" name="title" placeholder="Enter Title">
    
    <input class="form-control" type="text" name="discreption" placeholder="Enter descreption">
    
    <input type="submit" value="Save" class="btn btn-info">
</form>
```

- validation method

```js
$("#form1").validate({
    rules:{
        title: {
            required: true,
            minlength: 3
        },
        discreption:{
            required:true,
            minlength: 2
        }
    },
    messages:{
        title: {
            required: "title is required",
            minlength: "enter 3 or more character"
        },
        discreption:{
            required: "discreption is required",
            minlength: "enter 2 or more character"
        }
    },
    highlight: function(element){
        $(element).css({
            "border": "2px solid red"
        })
    },
    unhighlight: function (element) {
        $(element).css({
            "border": "2px solid black"
        })
    }
})

```

#### Rules 

- required – Makes the element required.

- minlength – Makes the element require a given minimum length.
- maxlength – Makes the element require a given maximum length.
- rangelength – Makes the element require a given value range.

```js
field: {
    required: true,
    rangelength: [2, 6]
}
```

- min – Makes the element require a given minimum.
- max – Makes the element require a given maximum.
- range – Makes the element require a given value range.

- email – Makes the element require a valid email
- url – Makes the element require a valid url
- date – Makes the element require a date.
- dateISO – Makes the element require an ISO date.

- number – Makes the element require a decimal number.
- digits – Makes the element require digits only.

- equalTo – Requires the element to be the same as another one

```js
rules: {
    password: "required",
    password_again: {
        equalTo: "#password"
    }
}
```

## Regular Expression

| **Pattern** | **Description**                                                        |
| ----------- | ---------------------------------------------------------------------- |
| `.`         | Matches any single character except newline.                           |
| `\d`        | Matches any digit (equivalent to `[0-9]`).                             |
| `\D`        | Matches any non-digit.                                                 |
| `\w`        | Matches any alphanumeric character (letters, numbers, and underscore). |
| `\W`        | Matches any non-alphanumeric character.                                |
| `\s`        | Matches any whitespace character (spaces, tabs, line breaks).          |
| `\S`        | Matches any non-whitespace character.                                  |
| `^`         | Matches the beginning of a string.                                     |
| `$`         | Matches the end of a string.                                           |
| `[abc]`     | Matches any one of the characters `a`, `b`, or `c`.                    |
| `[^abc]`    | Matches any character except `a`, `b`, or `c`.                         |
| `(a\|b)`    | Matches either `a` or `b`.                                             |
| `*`         | Matches 0 or more occurrences of the preceding element.                |
| `+`         | Matches 1 or more occurrences of the preceding element.                |
| `?`         | Matches 0 or 1 occurrence of the preceding element.                    |
| `{n,m}`     | Matches between `n` and `m` occurrences of the preceding element.      |
| `()`        | Groups characters together for applying quantifiers.                   |
| `[]`        | Defines a character class.                                             |
| `\|`        | Defines an OR condition between two patterns.                          |


### 1. test() Method

- It returns true if the pattern is found, otherwise false.

```js
let regex = /pattern/;
let result = regex.test(string);
```

- email is in a valid format

```js
$(document).ready(function() {
    $('#submit').on('click', function() {
        let email = $('#email').val();
        let emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        if (emailPattern.test(email)) {
            alert("Valid Email");
        } else {
            alert("Invalid Email");
        }
    });
});
```

### 2. match() Method

- The match() method retrieves the result of matching a string against a regular expression. It returns an array of matches or null if no match is found.

```js
let result = string.match(regex);
```

- Extracting all email addresses from a string

```js
$(document).ready(function() {
    let text = "Please contact john.doe@example.com or jane_doe@domain.org for more info.";
    let emailPattern = /[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}/g;
    let emails = text.match(emailPattern);
    console.log(emails);  // Output: ["john.doe@example.com", "jane_doe@domain.org"]
});
```

### 3. replace() Method

- The replace() method is used to search for a pattern and replace it with a new string.

```js
let result = string.replace(regex, replacement);
```

- Replacing all digits in a string with #

```js
$(document).ready(function() {
    let text = "My phone number is 123-456-7890.";
    let result = text.replace(/\d/g, '#');
    console.log(result);  // Output: "My phone number is ###-###-####."
});
```

### 4. split() Method

- The split() method splits a string into an array of substrings based on the specified pattern

```js
let result = string.split(regex);
```

- Splitting a string into an array of words

```js
$(document).ready(function() {
    let text = "The quick brown fox jumps over the lazy dog.";
    let words = text.split(/\s+/);  // Split by one or more spaces
    console.log(words);  // Output: ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog."]
});
```


## Deferred & Promise

### Deferred

### Promise

## Ajax

- The functions and methods therein allow us to load data from the server without a browser page refresh.

 