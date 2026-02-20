## Create a CheckBox

```js
$(function() {
    $("#check-box").dxCheckBox({ });
});
```

### value 
- true = checked
- false = unchecked
- undefined / null = indeterminate

### enableThreeStateBehavior 
- true = three state
- false = two state

```js
$(function() {
    $("#check-box").dxCheckBox({
        value: null,
        enableThreeStateBehavior: true
    });
});
```

### Options

| #  | Option                      | Type          | Default     | Possible Values                          | Description                             | Example                                                   |
| -- | --------------------------- | ------------- | ----------- | ---------------------------------------- | --------------------------------------- | --------------------------------------------------------- |
| 1  | `accessKey`                 | String        | `undefined` | Any character                            | Keyboard shortcut to focus component    | `accessKey: "s"`                                          |
| 2  | `activeStateEnabled`        | Boolean       | `true`      | `true/false`                             | Enables pressed visual state            | `activeStateEnabled: false`                               |
| 3  | `disabled`                  | Boolean       | `false`     | `true/false`                             | Disables user interaction               | `disabled: true`                                          |
| 4  | `elementAttr`               | Object        | `{}`        | HTML attributes                          | Adds custom attributes                  | `elementAttr: { id: "myChk", class: "custom" }`           |
| 5  | `enableThreeStateBehavior`  | Boolean       | `false`     | `true/false`                             | Enables checked/unchecked/indeterminate | `enableThreeStateBehavior: true`                          |
| 6  | `focusStateEnabled`         | Boolean       | `true`      | `true/false`                             | Allows keyboard focus                   | `focusStateEnabled: false`                                |
| 7  | `height`                    | Number/String | `undefined` | px number or CSS string                  | Sets component height                   | `height: 40` or `height: "40px"`                          |
| 8  | `hint`                      | String        | `undefined` | Any string                               | Tooltip text                            | `hint: "Click to agree"`                                  |
| 9  | `hoverStateEnabled`         | Boolean       | `true`      | `true/false`                             | Enables hover effect                    | `hoverStateEnabled: false`                                |
| 10 | `iconSize`                  | Number/String | `undefined` | px number or CSS string                  | Sets checkbox icon size                 | `iconSize: 24`                                            |
| 11 | `isDirty` *(read-only)*     | Boolean       | `false`     | `true/false`                             | True if value changed from initial      | *(Read via instance)* `instance.option("isDirty")`        |
| 12 | `isValid`                   | Boolean       | `true`      | `true/false`                             | Validation state                        | `isValid: false`                                          |
| 13 | `name`                      | String        | `""`        | Any string                               | HTML name attribute (forms)             | `name: "terms"`                                           |
| 14 | `onContentReady`            | Function      | `null`      | Function(e)                              | Fires after rendering                   | `onContentReady: function(e){ console.log("Ready"); }`    |
| 15 | `onDisposing`               | Function      | `null`      | Function(e)                              | Fires before destroy                    | `onDisposing: function(e){ console.log("Disposed"); }`    |
| 16 | `onInitialized`             | Function      | `null`      | Function(e)                              | Fires after creation                    | `onInitialized: function(e){ window.chk = e.component; }` |
| 17 | `onOptionChanged`           | Function      | `null`      | Function(e)                              | Fires when any option changes           | `onOptionChanged: function(e){ console.log(e.name); }`    |
| 18 | `onValueChanged`            | Function      | `null`      | Function(e)                              | Fires when value changes                | `onValueChanged: function(e){ console.log(e.value); }`    |
| 19 | `readOnly`                  | Boolean       | `false`     | `true/false`                             | Prevents editing                        | `readOnly: true`                                          |
| 20 | `rtlEnabled`                | Boolean       | `false`     | `true/false`                             | Enables right-to-left layout            | `rtlEnabled: true`                                        |
| 21 | `tabIndex`                  | Number        | `0`         | Integer                                  | Tab navigation order                    | `tabIndex: 5`                                             |
| 22 | `text`                      | String        | `""`        | Any string                               | Label text                              | `text: "Accept Terms"`                                    |
| 23 | `validationError`           | Object/null   | `null`      | Error object                             | First validation error                  | `validationError: { message: "Required" }`                |
| 24 | `validationErrors`          | Array/null    | `null`      | Array of errors                          | All validation errors                   | `validationErrors: [{ message: "Required" }]`             |
| 25 | `validationMessageMode`     | String        | `"auto"`    | `"auto"`, `"always"`                     | When validation message shows           | `validationMessageMode: "always"`                         |
| 26 | `validationMessagePosition` | String        | `"bottom"`  | `"top"`, `"bottom"`, `"left"`, `"right"` | Position of error tooltip               | `validationMessagePosition: "top"`                        |
| 27 | `validationStatus`          | String        | `"valid"`   | `"valid"`, `"invalid"`, `"pending"`      | Validation status indicator             | `validationStatus: "invalid"`                             |
| 28 | `value`                     | Boolean/null  | `false`     | `true`, `false`, `null`                  | Checked state                           | `value: true`                                             |
| 29 | `visible`                   | Boolean       | `true`      | `true/false`                             | Shows or hides component                | `visible: false`                                          |
| 30 | `width`                     | Number/String | `undefined` | px number or CSS string                  | Sets component width                    | `width: 200`                                              |


### Methods

| #  | Method                             | Type     | Parameters                               | Returns             | Description                                                                                   | Example                                                                                              |
| -- | ---------------------------------- | -------- | ---------------------------------------- | ------------------- | --------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- |
| 1  | `beginUpdate()`                    | Instance | —                                        | void                | Postpones rendering until `endUpdate()` is called. Improves performance for multiple updates. | `$("#checkBox").dxCheckBox("beginUpdate");`                                                          |
| 2  | `endUpdate()`                      | Instance | —                                        | void                | Resumes rendering after `beginUpdate()`.                                                      | `$("#checkBox").dxCheckBox("endUpdate");`                                                            |
| 3  | `blur()`                           | Instance | —                                        | void                | Removes keyboard focus from the component.                                                    | `$("#checkBox").dxCheckBox("blur");`                                                                 |
| 4  | `clear()`                          | Instance | —                                        | void                | Resets value to its initial default value.                                                    | `$("#checkBox").dxCheckBox("clear");`                                                                |
| 5  | `defaultOptions(rule)`             | Static   | `rule: Object`                           | void                | Sets default options globally based on device rules.                                          | `DevExpress.ui.dxCheckBox.defaultOptions({ device:{deviceType:"desktop"}, options:{iconSize:20} });` |
| 6  | `dispose()`                        | Instance | —                                        | void                | Destroys the component and frees resources.                                                   | `$("#checkBox").dxCheckBox("dispose");`                                                              |
| 7  | `element()`                        | Instance | —                                        | jQuery/HTMLElement  | Returns the root DOM element.                                                                 | `$("#checkBox").dxCheckBox("element");`                                                              |
| 8  | `focus()`                          | Instance | —                                        | void                | Sets keyboard focus to the component.                                                         | `$("#checkBox").dxCheckBox("focus");`                                                                |
| 9  | `getInstance(element)`             | Static   | `element: DOMElement`                    | dxCheckBox instance | Gets instance associated with DOM element.                                                    | `DevExpress.ui.dxCheckBox.getInstance(document.getElementById("checkBox"));`                         |
| 10 | `instance()`                       | Instance | —                                        | dxCheckBox instance | Returns the widget instance.                                                                  | `const inst = $("#checkBox").dxCheckBox("instance");`                                                |
| 11 | `off(eventName)`                   | Instance | `eventName: String`                      | void                | Unsubscribes all handlers from an event.                                                      | `$("#checkBox").dxCheckBox("off","valueChanged");`                                                   |
| 12 | `off(eventName, handler)`          | Instance | `eventName: String`, `handler: Function` | void                | Removes specific event handler.                                                               | `$("#checkBox").dxCheckBox("off","valueChanged", handler);`                                          |
| 13 | `on(eventName, handler)`           | Instance | `eventName: String`, `handler: Function` | void                | Subscribes to an event.                                                                       | `$("#checkBox").dxCheckBox("on","valueChanged", function(e){ console.log(e.value); });`              |
| 14 | `option()`                         | Instance | —                                        | Object              | Gets all component options.                                                                   | `$("#checkBox").dxCheckBox("option");`                                                               |
| 15 | `option(optionName)`               | Instance | `optionName: String`                     | Any                 | Gets specific option value.                                                                   | `$("#checkBox").dxCheckBox("option","value");`                                                       |
| 16 | `option(optionName, value)`        | Instance | `optionName: String`, `value: Any`       | void                | Sets a single option.                                                                         | `$("#checkBox").dxCheckBox("option","value",true);`                                                  |
| 17 | `option(optionsObject)`            | Instance | `optionsObject: Object`                  | void                | Sets multiple options at once.                                                                | `$("#checkBox").dxCheckBox("option",{ value:true, text:"Updated" });`                                |
| 18 | `registerKeyHandler(key, handler)` | Instance | `key: String`, `handler: Function`       | void                | Registers custom keyboard handler.                                                            | `$("#checkBox").dxCheckBox("registerKeyHandler","space",function(){ alert("Pressed"); });`           |
| 19 | `repaint()`                        | Instance | —                                        | void                | Forces component redraw.                                                                      | `$("#checkBox").dxCheckBox("repaint");`                                                              |
| 20 | `reset(value)`                     | Instance | `value: Boolean/null`                    | void                | Resets value and clears dirty state.                                                          | `$("#checkBox").dxCheckBox("reset", false);`                                                         |
| 21 | `resetOption(optionName)`          | Instance | `optionName: String`                     | void                | Resets specific option to its default value.                                                  | `$("#checkBox").dxCheckBox("resetOption","text");`                                                   |


### Events

#### 1. onContentReady

- When it fires: After the component has finished rendering — including after repaints (e.g., after calling option(), resize, or update).

- Handler arguments (e):
    - component: the dxCheckBox instance
    - element: the root DOM/jQuery element

- Use case: Trigger logic right after rendering (like adding custom markup).

- Example:

```html
<div id="chkContentReady"></div>
<script>
$("#chkContentReady").dxCheckBox({
    onContentReady: function(e) {
        console.log("CheckBox rendered:", e.element);
        // Add a tooltip or custom class
        $(e.element).addClass("custom-ready");
    }
});
</script>
```

#### 2. onDisposing

- When it fires: Right before the checkbox instance is removed or disposed. Useful for cleanup.

- Handler arguments (e):
    - component: the dxCheckBox instance
    - element: the root DOM/jQuery element

- Example:

```html
<div id="chkDispose"></div>
<script>
$("#chkDispose").dxCheckBox({
    onDisposing: function(e) {
        console.log("About to dispose:", e.element);
    }
});

// Later in code
$("#chkDispose").dxCheckBox("dispose");
</script>
```

#### 3. onInitialized

- When it fires: Once when the widget instance is created (before actual DOM rendering).

- Handler arguments (e):
    - component: widget instance
    - element: widget container element

- Use case: Save instance for later use.

```html
<div id="chkInit"></div>
<script>
$("#chkInit").dxCheckBox({
    onInitialized: function(e) {
        window.savedCheckBox = e.component;
        console.log("Instance stored:", window.savedCheckBox);
    }
});
</script>
```

#### 4. onOptionChanged

- When it fires: Every time any configuration option is updated — either user-triggered or via code.

- Handler arguments (e):
    - name: changed option name
    - fullName: full path of the option
    - value: new option value
    - previousValue: old value
    - component: widget instance
    - element: widget element

- Use case: Track dynamic option changes (e.g., react only when value changes).

- Example:

```html
<div id="chkOptionChange"></div>
<script>
$("#chkOptionChange").dxCheckBox({
    onOptionChanged: function(e) {
        console.log(`Option '${e.name}' changed from`, e.previousValue, "to", e.value);
    }
});

// Change value after initialization
setTimeout(function(){
    $("#chkOptionChange").dxCheckBox("option", "value", true);
}, 1000);
</script>
```

#### 5. onValueChanged

- When it fires: When the checkbox value changes (checked, unchecked, indeterminate) — due to user action or programmatic update.

- Handler arguments (e):
    - value: new value (true, false, or null)
    - previousValue: previous value
    - event: underlying DOM/jQuery event (undefined if set programmatically)
    - component: widget instance
    - element: widget element

- Use case: Main event for reacting to user checking/unchecking.

- Example :

```html
<div id="chkValue"></div>
<script>
$("#chkValue").dxCheckBox({
    onValueChanged: function(e) {
        console.log("Old:", e.previousValue, "New:", e.value);
    }
});
</script>
```

| Event Name          | Description                                                        | Event Handler Argument (e)                                     | Example                                             |
| ------------------- | ------------------------------------------------------------------ | -------------------------------------------------------------- | --------------------------------------------------- |
| **onContentReady**  | Fired when the widget is rendered or re-rendered.                  | `{ component, element }`                                       | Trigger logic once initialization & layout finish.  |
| **onDisposing**     | Fired just before the widget is removed/destroyed.                 | `{ component, element }`                                       | Clean up resources or detach listeners.             |
| **onInitialized**   | Fired once when the widget instance is created (before rendering). | `{ component, element }`                                       | Save a reference to the widget instance.            |
| **onOptionChanged** | Fired after *any* option changes.                                  | `{ name, fullName, value, previousValue, component, element }` | React to changes in options like `value`.           |
| **onValueChanged**  | Fired when the checkbox value changes (user or programmatically).  | `{ value, previousValue, event, component, element }`          | Respond to checked/unchecked/indeterminate changes. |



