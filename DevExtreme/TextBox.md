## create

```html
<div id="textBox">

</div>

<script>
    $(function () {
        $("#textBox").dxTextBox({
            label: "Name",
            labelMode: "floating",
            mask: "00099",
        })
    });
</script>
```

## options

| #  | Option                    | Type                | Default            | Possible Values             | Description                                                                     | Example                                |
| -- | ------------------------- | ------------------- | ------------------ | --------------------------- | ------------------------------------------------------------------------------- | -------------------------------------- |
| 1  | accessKey                 | String              | undefined          | Any character               | Shortcut key that focuses the TextBox (maps to HTML `accesskey`).               | `accessKey: "T"`                       |
| 2  | activeStateEnabled        | Boolean             | false              | true / false                | Enables visual active state when user presses the component.                    | `activeStateEnabled: true`             |
| 3  | buttons[]                 | Array               | undefined          | predefined/custom buttons   | Adds custom or built-in buttons inside the textbox (e.g., clear, custom icons). | `buttons: ["clear"]`                   |
| 4  | disabled                  | Boolean             | false              | true / false                | Disables user interaction when set to true.                                     | `disabled: true`                       |
| 5  | elementAttr               | Object              | {}                 | HTML attributes             | Adds attributes (id, class, etc.) to the container element.                     | `elementAttr:{ id:"txt1" }`            |
| 6  | focusStateEnabled         | Boolean             | true               | true / false                | Enables keyboard focus navigation.                                              | `focusStateEnabled: true`              |
| 7  | inputAttr                 | Object              | {}                 | HTML attributes             | Adds attributes to underlying `<input>` element (e.g., aria-label).             | `inputAttr:{ "aria-label":"Name" }`    |
| 8  | isDirty                   | Boolean (read-only) | false              | true / false                | Indicates whether the value has been changed from initial state.                | `textbox.option("isDirty")`            |
| 9  | isValid                   | Boolean             | true               | true / false                | Specifies whether current value is valid.                                       | `isValid: false`                       |
| 10 | mask                      | String              | ""                 | mask patterns               | Defines input mask (e.g., phone, time, etc.).                                   | `mask: "(000) 000-0000"`               |
| 11 | maskChar                  | String              | "_"                | any character               | Placeholder character for mask.                                                 | `maskChar: "*"`                        |
| 12 | maskInvalidMessage        | String              | "Value is invalid" | any string                  | Message shown when input doesn't match mask.                                    | `maskInvalidMessage: "Invalid format"` |
| 13 | maskRules                 | Object              | {}                 | custom rules                | Custom validation rules for mask characters.                                    | `maskRules:{ X:/[A-Z]/ }`              |
| 14 | placeholder               | String              | ""                 | any text                    | Text shown when input is empty.                                                 | `placeholder: "Enter name"`            |
| 15 | readOnly                  | Boolean             | false              | true / false                | Makes textbox non-editable but visible.                                         | `readOnly: true`                       |
| 16 | rtlEnabled                | Boolean             | false              | true / false                | Enables right-to-left layout (for Arabic/Hebrew).                               | `rtlEnabled: true`                     |
| 17 | showClearButton           | Boolean             | false              | true / false                | Displays a clear (reset) button inside textbox.                                 | `showClearButton: true`                |
| 18 | showMaskMode              | String              | "always"           | always / onFocus            | Controls when mask is visible.                                                  | `showMaskMode: "onFocus"`              |
| 19 | spellcheck                | Boolean             | false              | true / false                | Enables browser spell checking.                                                 | `spellcheck: true`                     |
| 20 | validationError           | Object              | null               | validation object           | Contains first validation error.                                                | `validationError:{}`                   |
| 21 | validationErrors          | Array               | null               | array of errors             | Stores all validation errors.                                                   | `validationErrors:[{message:"Error"}]` |
| 22 | validationMessageMode     | String              | auto               | auto / always               | Controls when validation messages appear.                                       | `validationMessageMode:"always"`       |
| 23 | validationMessagePosition | String              | bottom             | bottom / right / left / top | Position of validation message.                                                 | `validationMessagePosition:"right"`    |
| 24 | value                     | String              | ""                 | any string                  | Current value of the textbox.                                                   | `value: "John"`                        |
| 25 | valueChangeEvent          | String              | change             | keyup, blur, input, etc.    | DOM events that trigger value update.                                           | `valueChangeEvent:"keyup"`             |
| 26 | visible                   | Boolean             | true               | true / false                | Controls visibility of component.                                               | `visible:false`                        |
| 27 | width                     | Number / String     | undefined          | px, %, vw, etc.             | Width of the textbox.                                                           | `width:300`                            |


## Methods

| #  | Method                           | Parameters           | Return Type          | Description                                                                                                                              | Example                                          |
| -- | -------------------------------- | -------------------- | -------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------ |
| 1  | beginUpdate()                    | None                 | void                 | Stops UI rendering temporarily to improve performance when making multiple updates. Must be paired with `endUpdate()`. ([DevExtreme][1]) | `textBox.beginUpdate();`                         |
| 2  | endUpdate()                      | None                 | void                 | Resumes rendering and applies all changes made after `beginUpdate()`. ([DevExtreme][1])                                                  | `textBox.endUpdate();`                           |
| 3  | blur()                           | None                 | void                 | Removes focus from the textbox input field. ([DevExtreme][1])                                                                            | `$("#txt").dxTextBox("blur");`                   |
| 4  | focus()                          | None                 | void                 | Sets focus to the textbox input field. ([DevExtreme][1])                                                                                 | `$("#txt").dxTextBox("focus");`                  |
| 5  | clear()                          | None                 | void                 | Clears the value and resets it to default (empty string). ([DevExtreme][1])                                                              | `$("#txt").dxTextBox("clear");`                  |
| 6  | reset(value)                     | String value         | void                 | Resets the textbox value to a specified value and clears `isDirty` state. ([DevExtreme][2])                                              | `textBox.reset("Hello");`                        |
| 7  | defaultOptions(rule)             | Object               | void                 | Static method to define default options for all TextBox instances based on device type. ([DevExtreme][1])                                | `DevExpress.ui.dxTextBox.defaultOptions({...});` |
| 8  | dispose()                        | None                 | void                 | Disposes the component and removes all associated resources and event handlers. ([DevExtreme][1])                                        | `$("#txt").dxTextBox("dispose");`                |
| 9  | element()                        | None                 | HTMLElement / jQuery | Returns the root DOM element of the TextBox. ([DevExtreme][1])                                                                           | `var el = textBox.element();`                    |
| 10 | getButton(name)                  | String               | Button instance      | Returns a custom button instance added to the TextBox. ([DevExtreme][1])                                                                 | `textBox.getButton("clear").focus();`            |
| 11 | getInstance(element)             | DOM / jQuery element | TextBox instance     | Static method to retrieve component instance from DOM element. ([DevExtreme][1])                                                         | `DevExpress.ui.dxTextBox.getInstance(el);`       |
| 12 | instance()                       | None                 | TextBox instance     | Returns the current TextBox instance. Used to call other methods. ([DevExtreme][1])                                                      | `var inst = $("#txt").dxTextBox("instance");`    |
| 13 | on(eventName, handler)           | String, Function     | TextBox              | Attaches an event handler to a specific event. ([DevExtreme][2])                                                                         | `textBox.on("valueChanged", fn);`                |
| 14 | on(eventsObject)                 | Object               | TextBox              | Attaches multiple event handlers at once. ([DevExtreme][2])                                                                              | `textBox.on({ focusIn:fn, focusOut:fn });`       |
| 15 | off(eventName)                   | String               | TextBox              | Removes all handlers for a specific event. ([DevExtreme][2])                                                                             | `textBox.off("valueChanged");`                   |
| 16 | off(eventName, handler)          | String, Function     | TextBox              | Removes a specific event handler. ([DevExtreme][2])                                                                                      | `textBox.off("valueChanged", fn);`               |
| 17 | option()                         | None                 | Object               | Returns all configuration options of the component. ([DevExtreme][2])                                                                    | `var opts = textBox.option();`                   |
| 18 | option(name)                     | String               | Any                  | Gets the value of a specific option. ([DevExtreme][2])                                                                                   | `textBox.option("value");`                       |
| 19 | option(name,value)               | String, Any          | void                 | Updates a specific option dynamically. ([DevExtreme][2])                                                                                 | `textBox.option("value","New Text");`            |
| 20 | option(options)                  | Object               | void                 | Updates multiple options at once. ([DevExtreme][2])                                                                                      | `textBox.option({ value:"A", readOnly:true });`  |
| 21 | registerKeyHandler(key, handler) | String, Function     | void                 | Registers a custom handler for a specific keyboard key (e.g., Enter, Tab). ([DevExtreme][2])                                             | `textBox.registerKeyHandler("enter", fn);`       |
| 22 | repaint()                        | None                 | void                 | Re-renders the component UI without reloading data. Useful after layout changes. ([DevExtreme][2])                                       | `textBox.repaint();`                             |

[1]: https://js.devexpress.com/Vue/Documentation/ApiReference/UI_Components/dxTextbox/Methods/?utm_source=chatgpt.com "Vue TextBox Methods | Vue Documentation v24.2"
[2]: https://js.devexpress.com/Angular/Documentation/ApiReference/UI_Components/dxTextBox/Methods/?utm_source=chatgpt.com "Angular TextBox Methods | Angular Documentation"


## Events

| #  | Event           | Type     | Default | Trigger Condition                         | Description                                                                         | Example                                       |
| -- | --------------- | -------- | ------- | ----------------------------------------- | ----------------------------------------------------------------------------------- | --------------------------------------------- |
| 1  | onChange        | Function | null    | When input loses focus after value change | Triggered when the user changes text and the textbox loses focus. ([DevExtreme][1]) | `onChange: e => console.log("Changed")`       |
| 2  | onContentReady  | Function | null    | After component rendering                 | Fires when the TextBox is rendered or repainted.                                    | `onContentReady: () => console.log("Ready")`  |
| 3  | onCopy          | Function | null    | When text is copied                       | Executes when user copies text from the input field. ([DevExtreme][1])              | `onCopy: () => console.log("Copied")`         |
| 4  | onCut           | Function | null    | When text is cut                          | Executes when user cuts text from the input field. ([DevExtreme][1])                | `onCut: () => console.log("Cut")`             |
| 5  | onDisposing     | Function | null    | Before component destruction              | Triggered before the component instance is destroyed. ([DevExtreme][1])             | `onDisposing: () => console.log("Disposed")`  |
| 6  | onEnterKey      | Function | null    | When Enter key is pressed                 | Fired when user presses Enter while textbox is focused. ([DevExtreme][1])           | `onEnterKey: () => alert("Enter pressed")`    |
| 7  | onFocusIn       | Function | null    | When input gains focus                    | Executes when textbox receives focus. ([DevExtreme][1])                             | `onFocusIn: () => console.log("Focus In")`    |
| 8  | onFocusOut      | Function | null    | When input loses focus                    | Executes when textbox loses focus. ([DevExtreme][1])                                | `onFocusOut: () => console.log("Focus Out")`  |
| 9  | onInitialized   | Function | null    | When component is initialized             | Allows access to the component instance at creation time. ([DevExtreme][1])         | `onInitialized: e => window.tb = e.component` |
| 10 | onInput         | Function | null    | On every input change while typing        | Fires each time the user types or modifies input while focused. ([DevExtreme][1])   | `onInput: () => console.log("Typing")`        |
| 11 | onKeyDown       | Function | null    | When key is pressed                       | Triggered when a keyboard key is pressed. ([DevExtreme][1])                         | `onKeyDown: e => console.log(e.event.key)`    |
| 12 | onKeyUp         | Function | null    | When key is released                      | Triggered when a keyboard key is released. ([DevExtreme][1])                        | `onKeyUp: e => console.log("Key Up")`         |
| 13 | onOptionChanged | Function | null    | When any option changes                   | Fired when component configuration changes dynamically. ([DevExtreme][1])           | `onOptionChanged: e => console.log(e.name)`   |
| 14 | onPaste         | Function | null    | When content is pasted                    | Executes when user pastes text into textbox. ([DevExtreme][1])                      | `onPaste: () => console.log("Pasted")`        |
| 15 | onValueChanged  | Function | null    | When value changes                        | Fired when textbox value changes (user or programmatic). ([DevExtreme][1])          | `onValueChanged: e => console.log(e.value)`   |

[1]: https://js.devexpress.com/React/Documentation/ApiReference/UI_Components/dxTextBox/Configuration/?utm_source=chatgpt.com "React TextBox Props | React Documentation"
