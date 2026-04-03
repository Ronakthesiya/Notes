## Create

```js
$(function() {
    $("#text-area").dxTextArea({ });
});
```

## Options

| #  | Option                | Type                | Default   | Possible Values                      | Description                                                                                           | Example                          |
| -- | --------------------- | ------------------- | --------- | ------------------------------------ | ----------------------------------------------------------------------------------------------------- | -------------------------------- |
| 1  | accessKey             | String              | undefined | Any character                        | Keyboard shortcut key that focuses the component (maps to HTML `accesskey`).  | `accessKey: "T"`                 |
| 2  | activeStateEnabled    | Boolean             | false     | true / false                         | Enables visual active state when user interacts (mouse press).                | `activeStateEnabled: true`       |
| 3  | autoResizeEnabled     | Boolean             | false     | true / false                         | Automatically adjusts height based on content; disables fixed height.         | `autoResizeEnabled: true`        |
| 4  | buttons[]             | Array               | undefined | predefined/custom buttons            | Adds built-in or custom buttons inside the TextArea.                                                  | `buttons: ["clear"]`             |
| 5  | disabled              | Boolean             | false     | true / false                         | Disables user interaction.                                                    | `disabled: true`                 |
| 6  | elementAttr           | Object              | {}        | HTML attributes                      | Adds attributes (id, class) to the container element.                         | `elementAttr:{ id:"txtArea" }`   |
| 7  | focusStateEnabled     | Boolean             | true      | true / false                         | Enables keyboard navigation (focus using Tab).                                | `focusStateEnabled: true`        |
| 8  | height                | Number / String     | undefined | px, %, vh, etc.                      | Sets height of the TextArea. Ignored when autoResize is enabled.              | `height: 120`                    |
| 9  | width                 | Number / String     | undefined | px, %, etc.                          | Sets width of the component.                                                  | `width: 300`                     |
| 10 | hint                  | String              | undefined | Any text                             | Tooltip text shown when hovering over component.                              | `hint: "Enter description"`      |
| 11 | hoverStateEnabled     | Boolean             | true      | true / false                         | Enables hover styling when mouse is over component.                           | `hoverStateEnabled: false`       |
| 12 | inputAttr             | Object              | {}        | HTML attributes                      | Adds attributes to underlying `<textarea>` element (e.g., aria-label).        | `inputAttr:{ id:"desc" }`        |
| 13 | isDirty               | Boolean (read-only) | false     | true / false                         | Indicates whether value changed from initial state.                           | `textArea.option("isDirty")`     |
| 14 | isValid               | Boolean             | true      | true / false                         | Indicates whether value passes validation rules.                              | `isValid: false`                 |
| 15 | label                 | String              | ""        | Any string                           | Label displayed for the TextArea.                                                                     | `label: "Description"`           |
| 16 | labelMode             | String              | static    | static / floating / hidden / outside | Controls how label appears relative to input.                                                         | `labelMode: "floating"`          |
| 17 | maxLength             | Number              | undefined | integer                              | Maximum number of characters allowed.                                                                 | `maxLength: 200`                 |
| 18 | minHeight             | Number              | undefined | numeric values                       | Minimum height when auto resizing is enabled.                                 | `minHeight: 80`                  |
| 19 | maxHeight             | Number              | undefined | numeric values                       | Maximum height for auto resize.                                               | `maxHeight: 300`                 |
| 20 | name                  | String              | ""        | Any string                           | Sets HTML `name` attribute (form submission).                                                         | `name: "description"`            |
| 21 | placeholder           | String              | ""        | Any text                             | Text shown when value is empty.                                               | `placeholder: "Enter text..."`   |
| 22 | readOnly              | Boolean             | false     | true / false                         | Makes component non-editable but visible.                                     | `readOnly: true`                 |
| 23 | rtlEnabled            | Boolean             | false     | true / false                         | Enables right-to-left layout (Arabic/Hebrew).                                 | `rtlEnabled: true`               |
| 24 | spellcheck            | Boolean             | true      | true / false                         | Enables browser spell checking.                                               | `spellcheck: false`              |
| 25 | stylingMode           | String              | outlined  | outlined / filled / underlined       | Defines visual appearance of TextArea.                                        | `stylingMode: "filled"`          |
| 26 | tabIndex              | Number              | 0         | integer                              | Controls keyboard tab order.                                                  | `tabIndex: 2`                    |
| 27 | text                  | String (read-only)  | –         | formatted string                     | Contains displayed text value (read-only).                                    | `textArea.option("text")`        |
| 28 | validationError       | Object              | null      | validation object                    | Stores first validation error.                                                | `validationError:{}`             |
| 29 | validationErrors      | Array               | null      | array                                | Stores all validation errors.                                                 | `validationErrors:[...]`         |
| 30 | validationMessageMode | String              | auto      | auto / always                        | Controls when validation messages appear.                                     | `validationMessageMode:"always"` |
| 31 | value                 | String              | ""        | any string                           | Current value of the TextArea.                                                | `value: "Hello"`                 |
| 32 | valueChangeEvent      | String              | change    | keyup, input, blur, etc.             | DOM events that trigger value update.                                         | `valueChangeEvent:"keyup"`       |
| 33 | visible               | Boolean             | true      | true / false                         | Determines whether component is visible.                                      | `visible:false`                  |


## Methods

| #  | Method                           | Parameters          | Return Type          | Description                                                                    | Example                                     |
| -- | -------------------------------- | ------------------- | -------------------- | ------------------------------------------------------------------------------ | ------------------------------------------- |
| 1  | beginUpdate()                    | —                   | void                 | Temporarily stops rendering updates (use for batch changes). | `textArea.beginUpdate();`                   |
| 2  | endUpdate()                      | —                   | void                 | Resumes rendering after `beginUpdate()`.                     | `textArea.endUpdate();`                     |
| 3  | blur()                           | —                   | void                 | Removes focus from the TextArea.                             | `textArea.blur();`                          |
| 4  | focus()                          | —                   | void                 | Sets focus to the TextArea input.                            | `textArea.focus();`                         |
| 5  | clear()                          | —                   | void                 | Clears value (resets to default).                            | `textArea.clear();`                         |
| 6  | reset(value)                     | value: String       | void                 | Resets value and sets `isDirty = false`.                     | `textArea.reset("New Value");`              |
| 7  | repaint()                        | —                   | void                 | Re-renders component UI without reloading data.              | `textArea.repaint();`                       |
| 8  | dispose()                        | —                   | void                 | Destroys component and frees resources.                      | `textArea.dispose();`                       |
| 9  | element()                        | —                   | HTMLElement / jQuery | Returns root DOM element.                                    | `textArea.element();`                       |
| 10 | instance()                       | —                   | TextArea instance    | Gets current component instance.                             | `$("#ta").dxTextArea("instance");`          |
| 11 | getInstance(element)             | element: DOM/jQuery | instance             | Static method to get instance from DOM.                      | `DevExpress.ui.dxTextArea.getInstance(el);` |
| 12 | option()                         | —                   | Object               | Gets all options.                                            | `textArea.option();`                        |
| 13 | option(name)                     | name: String        | any                  | Gets specific option value.                                  | `textArea.option("value");`                 |
| 14 | option(name, value)              | name, value         | void                 | Sets a single option.                                        | `textArea.option("value", "Hello");`        |
| 15 | option(options)                  | options: Object     | void                 | Sets multiple options.                                       | `textArea.option({ disabled: true });`      |
| 16 | on(event, handler)               | event, function     | instance             | Attaches event handler.                                      | `textArea.on("valueChanged", fn);`          |
| 17 | on(eventsObject)                 | object              | instance             | Attach multiple events at once.                              | `textArea.on({ focusIn: fn });`             |
| 18 | off(event)                       | event: String       | instance             | Removes all handlers for event.                              | `textArea.off("valueChanged");`             |
| 19 | off(event, handler)              | event, function     | instance             | Removes specific handler.                                    | `textArea.off("valueChanged", fn);`         |
| 20 | registerKeyHandler(key, handler) | key, function       | void                 | Custom handler for keyboard key press.                       | `textArea.registerKeyHandler("enter", fn);` |
| 21 | defaultOptions(rule)             | object              | void (static)        | Set global default config for devices.                       | `dxTextArea.defaultOptions({...});`         |


## Events

| #  | Event           | Type     | Trigger               | Description                                                                        | Example                                      |
| -- | --------------- | -------- | --------------------- | ---------------------------------------------------------------------------------- | -------------------------------------------- |
| 1  | onInitialized   | Function | On component creation | Fired when TextArea instance is created (use to store instance). | `onInitialized: e => instance = e.component` |
| 2  | onContentReady  | Function | After render          | Fired when component is rendered or repainted.                   | `onContentReady: () => console.log("Ready")` |
| 3  | onDisposing     | Function | Before destroy        | Fired before component is destroyed.                             | `onDisposing: () => console.log("Disposed")` |
| 4  | onValueChanged  | Function | Value change          | Fired when value changes (user or programmatically).             | `onValueChanged: e => console.log(e.value)`  |
| 5  | onInput         | Function | Typing                | Fired on every input change while focused.                       | `onInput: e => console.log("Typing")`        |
| 6  | onChange        | Function | Blur after change     | Fired when user changes value and leaves field.                  | `onChange: () => console.log("Changed")`     |
| 7  | onFocusIn       | Function | Focus                 | Fired when TextArea gains focus.                                 | `onFocusIn: () => console.log("Focus In")`   |
| 8  | onFocusOut      | Function | Blur                  | Fired when TextArea loses focus.                                 | `onFocusOut: () => console.log("Focus Out")` |
| 9  | onKeyDown       | Function | Key press             | Fired when key is pressed.                                       | `onKeyDown: e => console.log(e.event.key)`   |
| 10 | onKeyUp         | Function | Key release           | Fired when key is released.                                      | `onKeyUp: e => console.log(e.event.key)`     |
| 11 | onEnterKey      | Function | Enter key             | Fired when Enter key is pressed.                                 | `onEnterKey: () => alert("Enter")`           |
| 12 | onCopy          | Function | Copy                  | Fired when text is copied.                                       | `onCopy: () => console.log("Copied")`        |
| 13 | onCut           | Function | Cut                   | Fired when text is cut.                                          | `onCut: () => console.log("Cut")`            |
| 14 | onPaste         | Function | Paste                 | Fired when text is pasted.                                       | `onPaste: () => console.log("Pasted")`       |
| 15 | onOptionChanged | Function | Option update         | Fired when any option is changed dynamically.                    | `onOptionChanged: e => console.log(e.name)`  |

