## DOM

- Document Object Model
- The DOM is an interface that browsers use to represent HTML or XML documents as a tree of nodes. It allows developers to manipulate the structure, style, and content of a web page programmatically using JavaScript.
- The DOM can be seen as a tree structure where each node represents a part of the page, like elements, text, attributes, etc.

---

## Selecting DOM Elements

### getElementById()

- Selects an element by its unique ID.
- if multiple ids than select only first

```js
const container = document.getElementById('container');
```

### getElementsByClassName()

- Selects all elements that have a certain class.
- This method returns a live HTMLCollection of all elements with the specified class name. The term "live" means that if the DOM changes (e.g., elements are added or removed), the HTMLCollection will automatically update.

```js
const elements = document.getElementsByClassName('class-name');
```

### getElementsByTagName()

- Selects all elements with a specific tag name.
- This method returns a live HTMLCollection of all elements with the specified class name. The term "live" means that if the DOM changes (e.g., elements are added or removed), the HTMLCollection will automatically update.

```js
const divs = document.getElementsByTagName('div');
```

### querySelector()

- Selects the first element that matches a CSS selector.

```js
const paragraph = document.querySelector('p');
```

### querySelectorAll()

- Returns all elements that match a CSS selector.

```js
const buttons = document.querySelectorAll('button');
```

---

## Getting and Setting Attributes

### getAttribute()

- Retrieves the value of an attribute.

```js
const src = document.querySelector('img').getAttribute('src');
```

### setAttribute()

- Sets the value of an attribute.

```js
document.querySelector('img').setAttribute('alt', 'New description');
```

---

## Edit Text

### innerHTML

- The innerHTML property is used to get or set the HTML content inside an element. This can be useful when you need to update the content of an element dynamically.

```js
const elem = document.querySelector('.content');
console.log(elem.innerHTML); // Get the HTML content
elem.innerHTML = '<p>New content</p>'; // Set new content
```

### textContent

- Similar to innerHTML, but it gets or sets just the text inside an element, not any HTML.

```js
const elem = document.querySelector('.message');
console.log(elem.textContent); // Get the text content
elem.textContent = 'Updated message'; // Set new text content
```

### innerText

- same as textcontent buit withou white space, line break, an d include css.

| Feature                       | `innerText`                                       | `textContent`                                    |
| ----------------------------- | ------------------------------------------------- | ------------------------------------------------ |
| **Text from hidden elements** | Does **not** include text from hidden elements    | Includes **all** text, even from hidden elements |
| **Line breaks**               | Respects line breaks (based on rendering)         | Does **not** add line breaks based on layout     |
| **Performance**               | Slower (because it triggers a reflow)             | Faster (no layout calculation required)          |
| **Whitespace**                | Ignores extra spaces, respects CSS formatting     | Does **not** ignore extra spaces or line breaks  |
| **Browser Behavior**          | Considered more **rendered and user-facing** text | Considered more **raw, unstyled** text           |


```html
<div id="example">
  This is a <span style="display:none;">hidden</span> text.
</div>

<script>
  const element = document.getElementById('example');
  console.log(element.innerText); // Output: "This is a text."
</script>

<script>
  const element = document.getElementById('example');
  console.log(element.textContent); // Output: "This is a hidden text."
</script>
```

## Attributes

### classList

- Manages classes of an element.

1. Add class: element.classList.add('className')
2. Remove class: element.classList.remove('className')
3. Toggle class: element.classList.toggle('className')
4. Check if class exists: element.classList.contains('className')
5. element.classList.replace(oldToken, newToken)

```js
const div = document.querySelector('div');
div.classList.add('new-class');
div.classList.remove('old-class');
div.classList.toggle('active');
div.classList.toggle('dark','light');

```

### style

- Modifies inline CSS styles.

```js
const div = document.querySelector('div');
div.style.backgroundColor = 'blue';
```

### Form elements

- To get or set values of form controls (e.g., input, select).

```js
const input = document.querySelector('input');
input.value = 'New value';
```


## Creating, Appending, and Removing Elements

### Creating New Elements

```js
const newDiv = document.createElement('div');
newDiv.textContent = 'This is a new div';
```

### Insert Element

#### 1. appendChild() 
- adds the element as the last child of the parent element.

```js
const newDiv = document.createElement('div');
newDiv.textContent = 'This is a new div!';

const parentElement = document.getElementById('parent'); // Get an existing element
parentElement.appendChild(newDiv); // Append the new div as a child of the parent
```

#### 2. append()
- It can accept multiple nodes or strings
- add at last

```js
const newDiv = document.createElement('div');
newDiv.textContent = 'Hello from append!';

const parentElement = document.getElementById('parent');
parentElement.append(newDiv, ' Some text here');  // Append both an element and text
```

#### 3. insertBefore()
- Inserts a new element as a sibling before a reference element in the DOM.

```js
const newDiv = document.createElement('div');
newDiv.textContent = 'New div before this one!';

const parentElement = document.getElementById('parent');
const referenceElement = document.getElementById('existingDiv'); // Reference to an existing element
parentElement.insertBefore(newDiv, referenceElement); // Insert before the existing element
```

- This will insert newDiv before existingDiv within parentElement.

### Remove Element

#### 1. removeChild()
- Removes a child element from its parent. The parent element must be explicitly referenced.

```js
const parentElement = document.getElementById('parent');
const childElement = document.getElementById('child');
parentElement.removeChild(childElement);  // Removes 'child' from 'parent'
```

#### 2. remove()
- Removes the element itself from the DOM without needing to reference its parent.

```js
const elementToRemove = document.getElementById('child');
elementToRemove.remove();  // Removes the element directly
```

### Replacing Elements

#### 1. replaceChild()
- Replaces one child element with another inside a parent element.

```js
const parentElement = document.getElementById('parent');
const oldChild = document.getElementById('oldChild');
const newChild = document.createElement('div');
newChild.textContent = 'This is the new child!';

parentElement.replaceChild(newChild, oldChild);
```

#### 2. replaceWith()

- Replaces the element with one or more new nodes or text. Unlike replaceChild(), it doesn’t require the parent reference.

```js
const oldElement = document.getElementById('oldChild');
const newElement = document.createElement('p');
newElement.textContent = 'Replaced content!';

oldElement.replaceWith(newElement);  // Replace the old element with the new one
```

### cloneNode()

- Creates a copy of an element, optionally including its children.

```js
const elementToClone = document.getElementById('item');
const clonedElement = elementToClone.cloneNode(true);  // 'true' clones with children
document.body.appendChild(clonedElement);
```


## DOM Traversal Methods

| Method                     | Description                                              | Example Usage                                 |
| -------------------------- | -------------------------------------------------------- | --------------------------------------------- |
| `parentNode`               | Gets the parent node of an element                       | `element.parentNode`                          |
| `parentElement`            | Gets the parent element (ignores non-element nodes)      | `element.parentElement`                       |
| `childNodes`               | Gets a NodeList of all child nodes (includes text nodes) | `element.childNodes`                          |
| `children`                 | Gets a live HTMLCollection of child elements             | `element.children`                            |
| `firstChild`               | Gets the first child node of an element                  | `element.firstChild`                          |
| `firstElementChild`        | Gets the first child element node                        | `element.firstElementChild`                   |
| `lastChild`                | Gets the last child node of an element                   | `element.lastChild`                           |
| `lastElementChild`         | Gets the last child element node                         | `element.lastElementChild`                    |
| `previousSibling`          | Gets the previous sibling node                           | `element.previousSibling`                     |
| `previousElementSibling`   | Gets the previous sibling element node                   | `element.previousElementSibling`              |
| `nextSibling`              | Gets the next sibling node                               | `element.nextSibling`                         |
| `nextElementSibling`       | Gets the next sibling element node                       | `element.nextElementSibling`                  |

---

## Event

- An event is an action that occurs on the web page, such as:
- A user clicking a button, Hovering over an image, Submitting a form, Pressing a key, Resizing the browser window

- Each event is associated with a target element in the DOM (e.g., a button, a form input, or a link) and can trigger specific JavaScript functions to respond to the event.

### Event Listeners

- An event listener is a function that waits for a specific event to occur on a particular element and then executes a piece of code in response.

```js
element.addEventListener(event, function, useCapture);
```

  - event: The type of event you want to listen for (e.g., click, mouseover, keydown, etc.).
  - function: The callback function that is executed when the event occurs.
  - useCapture (optional): A boolean value indicating whether to use event capturing. Defaults to false (event bubbling).

### Event Object

- When an event occurs, the browser automatically passes an event object to the event handler function.
- Common Properties of the Event Object:

  - type: The type of event (e.g., click, keydown).
  - target: The DOM element that triggered the event.
  - currentTarget: The DOM element to which the event listener is attached.
  - event.target: The element where the event originated.
  - keyCode/code: The key code for keyboard events (use code for modern browsers).
  - preventDefault(): Prevents the default action associated with the event (e.g., form submission).
  - stopPropagation(): Stops the event from bubbling up or capturing down the DOM tree.

### Event Types

1. Mouse Events:
  - `click`: Triggered when the user clicks an element.
  - `dblclick`: Triggered when the user double-clicks an element.
  - `mouseenter`: Triggered when the mouse pointer enters the element.
  - `mouseleave`: Triggered when the mouse pointer leaves the element.
  - `mousemove`: Triggered when the mouse moves within the element.
  - `mousedown`: Triggered when the mouse button is pressed down.
  - `mouseup`: Triggered when the mouse button is released.

2. Keyboard Events:
  - `keydown`: Triggered when a key is pressed down.
  - `keyup`: Triggered when a key is released.
  - `keypress`: Triggered when a key is pressed (deprecated in modern browsers).

3. Form Events:
  - `submit`: Triggered when a form is submitted.
  - `input`: Triggered when the value of an input element changes.
  - `change`: Triggered when the value of an input element is committed (e.g., after losing focus).

4. Focus Events:
  - `focus`: Triggered when an element gains focus.
  - `blur`: Triggered when an element loses focus.

5. Window/Document Events:
  - `resize`: Triggered when the browser window is resized.
  - `scroll`: Triggered when the user scrolls the page.
  - `load`: Triggered when the page has fully loaded.
  - `unload`: Triggered when the page is being unloaded (e.g., navigating away).

### Event propagation

- event propagation refers to the way events travel through the DOM
- Event propagation involves three primary stages:

1. Capturing Phase (or Trickle Down Phase)
  - event propagated from top of the DOM tree down to target element
2. Target Phase
  - when the event reaches the actual target element
3. Bubbling Phase
  - event propagated from the target element to the root of the document

### Stopping Event Propagation

#### 1. stopPropagation()

- This method prevents further propagation of the current event in both the capturing and bubbling phases.
- If called during the capturing phase, it will stop the event from reaching the target.
- If called during the bubbling phase, it will stop the event from bubbling up to the parent elements.

```js
document.getElementById('child').addEventListener('click', function(event) {
    console.log('Child clicked!');
    event.stopPropagation(); // Prevents bubbling to parent
});

```

#### 2. stopImmediatePropagation()

- The event will not propagate to any other elements, and any further event listeners on the same target element will not be called.

```js
document.getElementById('parent').addEventListener('click', function() {
    console.log('Parent clicked');
});

document.getElementById('child').addEventListener('click', function(event) {
    console.log('Child clicked (first listener)');
});

document.getElementById('child').addEventListener('click', function(event) {
    console.log('Child clicked (second listener)');
    event.stopImmediatePropagation();  // Stops other listeners from firing
});

document.getElementById('child').addEventListener('click', function() {
    console.log('Child clicked (third listener)');
});
```

- What Happens:
- If you click the button:

  - First listener on the child element logs: "Child clicked (first listener)".
  - Second listener logs: "Child clicked (second listener)", then calls stopImmediatePropagation().
  - Since stopImmediatePropagation() is called, the third listener on the same target element does not fire, even though it's registered.
  - The parent's click handler is still triggered as long as the event is bubbling.


### Event Delegation

- Event delegation is a powerful pattern that leverages event propagation (bubbling) to handle events at a higher level in the DOM, usually on a parent element, rather than attaching individual listeners to multiple child elements.

- This is useful when:
  - You have a large number of child elements.
  - You dynamically add/remove child elements.

```html
<ul id="list">
  <li>Item 1</li>
  <li>Item 2</li>
  <li>Item 3</li>
</ul>
```

```js
document.getElementById('list').addEventListener('click', function(event) {
    if (event.target.tagName === 'LI') {
        console.log('List item clicked:', event.target.textContent);
    }
});
```


### Removing Event Listeners

- You can remove an event listener using the removeEventListener method, which stops the event from propagating further.
- If you don’t specify the capture argument when adding the listener, you must match it when removing the event listener.

```js
const parentListener = function() {
    console.log('Parent clicked!');
};
document.getElementById('parent').addEventListener('click', parentListener);
document.getElementById('parent').removeEventListener('click', parentListener);
```
---

## Performance Considerations

### 1. Minimizing Reflows and Repaints

- Reflow happens when layout changes; repaint happens when appearance changes. To improve performance, batch DOM manipulations together.

### 2. Using DocumentFragment

- For large DOM updates, use DocumentFragment to avoid multiple reflows/repaints.

```js
const fragment = document.createDocumentFragment();
const newDiv = document.createElement('div');
fragment.appendChild(newDiv);
document.body.appendChild(fragment); // Single reflow
```

### 3. Using cloneNode

- You can clone nodes to make modifications before adding them to the DOM.

```js
const divClone = div.cloneNode(true); // Deep clone (including children)
document.body.appendChild(divClone);
```




