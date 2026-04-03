## Create

```js
$(funciton(){
    $("#button").dxButton({
        // options..
    })
})
```


## Option

| #  | Option             | Type                       | Default          | Possible Values                            | Description                                                                        | Example                       |
| -- | ------------------ | -------------------------- | ---------------- | ------------------------------------------ | ---------------------------------------------------------------------------------- | ----------------------------- |
| 1  | accessKey          | String                     | null / undefined | Any character                              | Keyboard shortcut to focus the button (HTML `accesskey`). | `accessKey: "S"`              |
| 2  | activeStateEnabled | Boolean                    | true             | true / false                               | Enables active (pressed) visual state when clicking.      | `activeStateEnabled: true`    |
| 3  | disabled           | Boolean                    | false            | true / false                               | Disables button interaction.                              | `disabled: true`              |
| 4  | elementAttr        | Object                     | {}               | HTML attributes                            | Adds attributes (id, class) to root element.              | `elementAttr:{ id:"btn1" }`   |
| 5  | focusStateEnabled  | Boolean                    | true (desktop)   | true / false                               | Allows keyboard focus navigation.                         | `focusStateEnabled:true`      |
| 6  | height             | Number / String / Function | undefined        | px, %, function                            | Sets height of button.                                    | `height:40`                   |
| 7  | width              | Number / String            | undefined        | px, %, etc.                                | Sets width of button.                                     | `width:120`                   |
| 8  | rtlEnabled         | Boolean                    | false            | true / false                               | Enables right-to-left layout.                             | `rtlEnabled:true`             |
| 9  | stylingMode        | String                     | "contained"      | text / outlined / contained                | Defines button appearance.                                | `stylingMode:"outlined"`      |
| 10 | tabIndex           | Number                     | 0                | integer                                    | Controls tab navigation order.                            | `tabIndex:2`                  |
| 11 | template           | Template                   | "content"        | custom template                            | Custom rendering for button content.                      | `template: function(){}`      |
| 12 | text               | String                     | ""               | any string                                 | Text displayed on button.                                 | `text:"Submit"`               |
| 13 | type               | String                     | "normal"         | back / danger / default / normal / success | Defines button style type (semantic color).               | `type:"success"`              |
| 14 | useSubmitBehavior  | Boolean                    | false            | true / false                               | Submits HTML form when clicked.                           | `useSubmitBehavior:true`      |
| 15 | validationGroup    | String                     | undefined        | group name                                 | Links button to validation group.                         | `validationGroup:"formGroup"` |
| 16 | visible            | Boolean                    | true             | true / false                               | Controls visibility of button.                            | `visible:false`               |


## Methods

| #  | Method                           | Parameters           | Return Type          | Description                                                                                                    | Example                                   |
| -- | -------------------------------- | -------------------- | -------------------- | -------------------------------------------------------------------------------------------------------------- | ----------------------------------------- |
| 1  | beginUpdate()                    | —                    | void                 | Stops UI rendering temporarily to improve performance when multiple updates are made. | `button.beginUpdate();`                   |
| 2  | endUpdate()                      | —                    | void                 | Resumes rendering after `beginUpdate()` is called.                                    | `button.endUpdate();`                     |
| 3  | focus()                          | —                    | void                 | Sets focus on the button element.                                                     | `button.focus();`                         |
| 4  | dispose()                        | —                    | void                 | Destroys the component and releases resources.                                        | `button.dispose();`                       |
| 5  | repaint()                        | —                    | void                 | Re-renders the button UI without reloading data.                                      | `button.repaint();`                       |
| 6  | element()                        | —                    | HTMLElement / jQuery | Returns the root DOM element of the button.                                           | `button.element();`                       |
| 7  | instance()                       | —                    | Button instance      | Gets the current button instance.                                                     | `$("#btn").dxButton("instance");`         |
| 8  | getInstance(element)             | DOM / jQuery element | Button instance      | Static method to get instance from DOM element.                                       | `DevExpress.ui.dxButton.getInstance(el);` |
| 9  | option()                         | —                    | Object               | Gets all configuration options.                                                                                | `button.option();`                        |
| 10 | option(name)                     | String               | any                  | Gets value of a specific option.                                                                               | `button.option("text");`                  |
| 11 | option(name, value)              | String, any          | void                 | Sets a single option dynamically.                                                                              | `button.option("text", "Save");`          |
| 12 | option(options)                  | Object               | void                 | Sets multiple options at once.                                                                                 | `button.option({ disabled: true });`      |
| 13 | on(event, handler)               | String, Function     | instance             | Attaches an event handler dynamically.                                                                         | `button.on("click", fn);`                 |
| 14 | on(eventsObject)                 | Object               | instance             | Attaches multiple event handlers.                                                                              | `button.on({ click: fn });`               |
| 15 | off(event)                       | String               | instance             | Removes all handlers for a specific event.                                            | `button.off("click");`                    |
| 16 | off(event, handler)              | String, Function     | instance             | Removes a specific event handler.                                                                              | `button.off("click", fn);`                |
| 17 | registerKeyHandler(key, handler) | String, Function     | void                 | Registers custom handler for specific key press (e.g., Enter, Esc).                   | `button.registerKeyHandler("enter", fn);` |
| 18 | resetOption(optionName)          | String               | void                 | Resets a specific option to its default value.                                        | `button.resetOption("text");`             |
| 19 | defaultOptions(rule)             | Object               | void (static)        | Sets global default configuration for all buttons (device-based).                     | `dxButton.defaultOptions({...});`         |

## Events

| # | Event           | Type     | Trigger        | Description                                                                                                                             | Example                                      |
| - | --------------- | -------- | -------------- | --------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------- |
| 1 | onClick         | Function | Click / Tap    | Fired when the button is clicked or tapped. Provides event info like component, element, and validation group. | `onClick: e => console.log("Clicked")`       |
| 2 | onContentReady  | Function | After render   | Fired when the button is fully rendered and ready in DOM.                                                      | `onContentReady: () => console.log("Ready")` |
| 3 | onDisposing     | Function | Before destroy | Fired before the button instance is destroyed.                                                                 | `onDisposing: () => console.log("Disposed")` |
| 4 | onInitialized   | Function | Initialization | Fired once when the component is initialized.                                                                  | `onInitialized: e => instance = e.component` |
| 5 | onOptionChanged | Function | Option update  | Fired when any configuration option is changed dynamically.                                                    | `onOptionChanged: e => console.log(e.name)`  |
