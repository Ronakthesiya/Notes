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















