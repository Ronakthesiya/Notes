## Create

```html
<div id="dd">
</div>

<script>
    $("#dd").dxDropDownBox();
</script>
```

## Options

| #  | Option                      | Type                             | Default      | Possible Values                         | Description                                                         | Example                                 |
| -- | --------------------------- | -------------------------------- | ------------ | --------------------------------------- | ------------------------------------------------------------------- | --------------------------------------- |
| 1  | `acceptCustomValue`         | Boolean                          | `false`      | `true`, `false`                         | Allows users to enter custom values not present in the data source. | `acceptCustomValue: true`               |
| 2  | `accessKey`                 | String                           | `undefined`  | Any character                           | Keyboard shortcut used to focus the component.                      | `accessKey: "D"`                        |
| 3  | `activeStateEnabled`        | Boolean                          | `true`       | `true`, `false`                         | Enables active visual state when the component is pressed.          | `activeStateEnabled: true`              |
| 4  | `buttons`                   | Array                            | `[]`         | Custom buttons, `"clear"`, `"dropDown"` | Adds buttons inside the editor field.                               | `buttons: ["clear","dropDown"]`         |
| 5  | `contentTemplate`           | Template / Function              | `null`       | Template function                       | Defines custom content inside dropdown (DataGrid, List, TreeView).  | `contentTemplate: function(e){...}`     |
| 6  | `dataSource`                | Array / DataSource / Store / URL | `null`       | Data array, API endpoint                | Binds component to data collection.                                 | `dataSource: employees`                 |
| 7  | `deferRendering`            | Boolean                          | `true`       | `true`, `false`                         | Delays rendering dropdown content until opened.                     | `deferRendering:false`                  |
| 8  | `disabled`                  | Boolean                          | `false`      | `true`, `false`                         | Disables the DropDownBox component.                                 | `disabled:true`                         |
| 9  | `displayExpr`               | String / Function                | `undefined`  | Field name or function                  | Defines which field displays text in input.                         | `displayExpr:"name"`                    |
| 10 | `dropDownButtonTemplate`    | Template                         | `null`       | Template                                | Custom template for dropdown button.                                | `dropDownButtonTemplate: myTemplate`    |
| 11 | `dropDownOptions`           | Object                           | `{}`         | Popup configuration                     | Configures dropdown popup properties (width, height, etc.).         | `dropDownOptions:{ width:500 }`         |
| 12 | `elementAttr`               | Object                           | `{}`         | HTML attributes                         | Adds custom attributes to root element.                             | `elementAttr:{ id:"empDropDown" }`      |
| 13 | `fieldTemplate`             | Template                         | `null`       | Template function                       | Custom template for the input field.                                | `fieldTemplate:function(){}`            |
| 14 | `focusStateEnabled`         | Boolean                          | `true`       | `true`, `false`                         | Enables focus styling.                                              | `focusStateEnabled:true`                |
| 15 | `height`                    | Number / String                  | `undefined`  | CSS values                              | Sets component height.                                              | `height:40`                             |
| 16 | `hint`                      | String                           | `undefined`  | Any text                                | Tooltip displayed on hover.                                         | `hint:"Select employee"`                |
| 17 | `hoverStateEnabled`         | Boolean                          | `true`       | `true`, `false`                         | Enables hover visual state.                                         | `hoverStateEnabled:false`               |
| 18 | `inputAttr`                 | Object                           | `{}`         | HTML attributes                         | Adds attributes to input element.                                   | `inputAttr:{ "aria-label":"Employee" }` |
| 19 | `isDirty`                   | Boolean                          | `false`      | Read-only                               | Indicates if value has changed from initial value.                  | `dropDown.option("isDirty")`            |
| 20 | `items`                     | Array                            | `null`       | List of values                          | Defines dropdown items if not using `dataSource`.                   | `items:["A","B","C"]`                   |
| 21 | `label`                     | String                           | `undefined`  | Any text                                | Label displayed with editor.                                        | `label:"Employee"`                      |
| 22 | `labelMode`                 | String                           | `"static"`   | `static`, `floating`, `hidden`          | Determines label behavior.                                          | `labelMode:"floating"`                  |
| 23 | `maxLength`                 | Number                           | `undefined`  | Numeric value                           | Maximum characters allowed in input.                                | `maxLength:50`                          |
| 24 | `name`                      | String                           | `""`         | Any string                              | Name attribute for form submission.                                 | `name:"employeeId"`                     |
| 25 | `openOnFieldClick`          | Boolean                          | `true`       | `true`, `false`                         | Opens dropdown when input field is clicked.                         | `openOnFieldClick:true`                 |
| 26 | `opened`                    | Boolean                          | `false`      | `true`, `false`                         | Controls dropdown visibility programmatically.                      | `opened:true`                           |
| 27 | `placeholder`               | String                           | `""`         | Any text                                | Placeholder text for input.                                         | `placeholder:"Select value"`            |
| 28 | `readOnly`                  | Boolean                          | `false`      | `true`, `false`                         | Prevents editing but keeps value visible.                           | `readOnly:true`                         |
| 29 | `rtlEnabled`                | Boolean                          | `false`      | `true`, `false`                         | Enables right-to-left layout.                                       | `rtlEnabled:true`                       |
| 30 | `showClearButton`           | Boolean                          | `false`      | `true`, `false`                         | Displays button to clear value.                                     | `showClearButton:true`                  |
| 31 | `stylingMode`               | String                           | `"outlined"` | `outlined`, `filled`, `underlined`      | Defines appearance style of input.                                  | `stylingMode:"filled"`                  |
| 32 | `tabIndex`                  | Number                           | `0`          | Any number                              | Sets tab navigation order.                                          | `tabIndex:1`                            |
| 33 | `text`                      | String                           | Read-only    | —                                       | Text displayed in input field.                                      | `dropDown.option("text")`               |
| 34 | `validationError`           | Object                           | `undefined`  | Error object                            | Contains validation error information.                              | `{message:"Invalid"}`                   |
| 35 | `validationErrors`          | Array                            | `null`       | Array of errors                         | Multiple validation errors.                                         | `[ {message:"Required"} ]`              |
| 36 | `validationMessageMode`     | String                           | `"auto"`     | `auto`, `always`                        | Determines when validation messages appear.                         | `validationMessageMode:"always"`        |
| 37 | `validationMessagePosition` | String                           | `"bottom"`   | `bottom`, `right`                       | Position of validation message.                                     | `validationMessagePosition:"right"`     |
| 38 | `value`                     | Any                              | `null`       | String, number, object                  | Selected value in the DropDownBox.                                  | `value:1`                               |
| 39 | `valueExpr`                 | String / Function                | `undefined`  | Data field                              | Defines which field is used as value.                               | `valueExpr:"id"`                        |
| 40 | `visible`                   | Boolean                          | `true`       | `true`, `false`                         | Shows or hides the component.                                       | `visible:false`                         |
| 41 | `width`                     | Number / String                  | `undefined`  | CSS values                              | Sets component width.                                               | `width:300`                             |



## Methods

| #  | Method                             | Description                                                                                                                                 | Syntax Example                                      | Practical Use Case                                        |
| -- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------------- |
| 1  | `beginUpdate()`                    | Temporarily stops UI rendering to improve performance when multiple properties are updated. Rendering resumes when `endUpdate()` is called. | `dropDown.beginUpdate();`                           | Batch update several options without multiple re-renders. |
| 2  | `endUpdate()`                      | Resumes rendering after `beginUpdate()` is called.                                                                                          | `dropDown.endUpdate();`                             | Finalize batch UI updates.                                |
| 3  | `blur()`                           | Removes focus from the DropDownBox input element.                                                                                           | `dropDown.blur();`                                  | Programmatically remove cursor focus.                     |
| 4  | `focus()`                          | Sets focus to the DropDownBox input field.                                                                                                  | `dropDown.focus();`                                 | Automatically focus a field when form loads.              |
| 5  | `clear()`                          | Resets the `value` property to its default (`null`).                                                                                        | `dropDown.clear();`                                 | Clear selected item.                                      |
| 6  | `reset(value)`                     | Resets the value to a specified default value.                                                                                              | `dropDown.reset(null);`                             | Restore initial value.                                    |
| 7  | `close()`                          | Closes the dropdown popup.                                                                                                                  | `dropDown.close();`                                 | Close dropdown after selection.                           |
| 8  | `open()`                           | Opens the dropdown popup.                                                                                                                   | `dropDown.open();`                                  | Open dropdown programmatically.                           |
| 9  | `content()`                        | Returns the dropdown popup content container.                                                                                               | `dropDown.content();`                               | Access embedded components (DataGrid, List).              |
| 10 | `field()`                          | Returns the `<input>` element used in the editor.                                                                                           | `dropDown.field();`                                 | Modify input attributes or styles.                        |
| 11 | `element()`                        | Returns the root DOM element of the component.                                                                                              | `dropDown.element();`                               | Access component container.                               |
| 12 | `getButton(name)`                  | Returns an instance of a custom action button.                                                                                              | `dropDown.getButton("myButton")`                    | Modify custom button properties.                          |
| 13 | `getDataSource()`                  | Returns the `DataSource` instance bound to the DropDownBox.                                                                                 | `dropDown.getDataSource();`                         | Apply filtering, sorting, or reload data.                 |
| 14 | `instance()`                       | Returns the DropDownBox instance.                                                                                                           | `$("#box").dxDropDownBox("instance");`              | Required to call methods programmatically.                |
| 15 | `getInstance(element)`             | Static method to retrieve component instance from DOM element.                                                                              | `DevExpress.ui.dxDropDownBox.getInstance(el);`      | Access instance created elsewhere.                        |
| 16 | `option()`                         | Returns all component configuration options.                                                                                                | `dropDown.option();`                                | Inspect current configuration.                            |
| 17 | `option(name)`                     | Gets the value of a specific option.                                                                                                        | `dropDown.option("value");`                         | Retrieve selected value.                                  |
| 18 | `option(name,value)`               | Updates a specific option.                                                                                                                  | `dropDown.option("value", 3);`                      | Change value programmatically.                            |
| 19 | `option(options)`                  | Updates multiple options at once.                                                                                                           | `dropDown.option({ width:300 });`                   | Update multiple settings.                                 |
| 20 | `on(eventName, handler)`           | Attaches an event handler.                                                                                                                  | `dropDown.on("valueChanged", fn);`                  | Dynamically add event listeners.                          |
| 21 | `on(events)`                       | Attach multiple event handlers.                                                                                                             | `dropDown.on({ opened: fn });`                      | Register multiple events at once.                         |
| 22 | `off(eventName)`                   | Removes all handlers from an event.                                                                                                         | `dropDown.off("valueChanged");`                     | Stop listening to an event.                               |
| 23 | `off(eventName, handler)`          | Removes a specific event handler.                                                                                                           | `dropDown.off("valueChanged", handler);`            | Remove particular callback.                               |
| 24 | `registerKeyHandler(key, handler)` | Registers handler for a keyboard key press.                                                                                                 | `dropDown.registerKeyHandler("enter", fn);`         | Handle Enter or Escape key events.                        |
| 25 | `repaint()`                        | Re-renders the component UI without reloading data.                                                                                         | `dropDown.repaint();`                               | Refresh component after style change.                     |
| 26 | `dispose()`                        | Releases resources and removes event handlers when component is destroyed.                                                                  | `$("#box").dxDropDownBox("dispose");`               | Cleanup when removing component.                          |
| 27 | `defaultOptions(rule)`             | Sets global default configuration based on device type.                                                                                     | `DevExpress.ui.dxDropDownBox.defaultOptions({...})` | Apply default settings for all DropDownBox components.    |
| 28 | `resetOption(optionName)`          | Resets an option to its default value.                                                                                                      | `dropDown.resetOption("width");`                    | Restore default configuration.                            |


## Events

| #  | Event           | Description                                                                            | Example Usage                    |
| -- | --------------- | -------------------------------------------------------------------------------------- | -------------------------------- |
| 1  | `change`        | Triggered when the component loses focus **after text is changed using the keyboard**. | `onChange: function(e){}`        |
| 2  | `closed`        | Fired **after the dropdown popup closes**.                                             | `onClosed: function(e){}`        |
| 3  | `copy`          | Triggered when the input text is **copied**.                                           | `onCopy: function(e){}`          |
| 4  | `cut`           | Triggered when the input text is **cut**.                                              | `onCut: function(e){}`           |
| 5  | `disposing`     | Fired **before the component is destroyed**.                                           | `onDisposing: function(e){}`     |
| 6  | `enterKey`      | Fired when the **Enter key is pressed** while focused.                                 | `onEnterKey: function(e){}`      |
| 7  | `focusIn`       | Triggered when the component **receives focus**.                                       | `onFocusIn: function(e){}`       |
| 8  | `focusOut`      | Triggered when the component **loses focus**.                                          | `onFocusOut: function(e){}`      |
| 9  | `initialized`   | Fired **once when the component is initialized**.                                      | `onInitialized: function(e){}`   |
| 10 | `input`         | Triggered whenever the **input value changes while typing**.                           | `onInput: function(e){}`         |
| 11 | `keyDown`       | Fired when a **keyboard key is pressed down**.                                         | `onKeyDown: function(e){}`       |
| 12 | `keyUp`         | Fired when a **keyboard key is released**.                                             | `onKeyUp: function(e){}`         |
| 13 | `opened`        | Fired **after the dropdown popup opens**.                                              | `onOpened: function(e){}`        |
| 14 | `optionChanged` | Triggered when a **component option/property changes**.                                | `onOptionChanged: function(e){}` |
| 15 | `paste`         | Triggered when text is **pasted into the input**.                                      | `onPaste: function(e){}`         |
| 16 | `valueChanged`  | Fired when the **selected value changes**.                                             | `onValueChanged: function(e){}`  |


