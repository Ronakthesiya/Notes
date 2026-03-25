## Create

```js

$("#radioGroup").dxRadioGroup({
    dataSource: [
        { text: "Low", color: "grey" },
        { text: "Normal", color: "green" },
        { text: "Urgent", color: "yellow" },
        { text: "High", color: "red" }
    ],
    itemTemplate: function (itemData, itemIndex, itemElement) {
        itemElement.append(
            $("<div />").attr("style", "color:" + itemData.color)
                .text(itemData.text)
        );
    }
});
            
```

## options

| #  | Option                    | Type                   | Default    | Possible Values               | Description                            | Example               |
| -- | ------------------------- | ---------------------- | ---------- | ----------------------------- | -------------------------------------- | --------------------- |
| 1  | accessKey                 | string                 | undefined  | any string                    | Shortcut key to focus component        | `"A"`                 |
| 2  | activeStateEnabled        | boolean                | true       | true / false                  | Enables active (pressed) state styling | `true`                |
| 3  | dataSource                | array / object / store | null       | array, DataSource, URL        | Binds component to data                | `["A","B"]`           |
| 4  | displayExpr               | string / function      | undefined  | field name / function         | Field used for display text            | `"name"`              |
| 5  | elementAttr               | object                 | {}         | HTML attributes               | Adds custom HTML attributes            | `{ id: "rg1" }`       |
| 6  | focusStateEnabled         | boolean                | true       | true / false                  | Enables keyboard focus                 | `true`                |
| 7  | height                    | number / string        | undefined  | px, %, vh, etc.               | Component height                       | `100`                 |
| 8  | hint                      | string                 | undefined  | any string                    | Tooltip text                           | `"Select option"`     |
| 9  | hoverStateEnabled         | boolean                | true       | true / false                  | Enables hover effect                   | `true`                |
| 10 | isDirty                   | boolean (readonly)     | false      | true / false                  | Indicates value changed                | —                     |
| 11 | isValid                   | boolean                | true       | true / false                  | Validation state                       | `false`               |
| 12 | items                     | array                  | —          | array of items                | Static list of items                   | `["A","B"]`           |
| 13 | itemTemplate              | template               | —          | template                      | Custom item rendering                  | `function(item){}`    |
| 14 | layout                    | string                 | "vertical" | "vertical", "horizontal"      | Layout direction                       | `"horizontal"`        |
| 15 | name                      | string                 | ""         | any string                    | HTML name attribute                    | `"gender"`            |
| 16 | onContentReady            | function               | null       | function                      | Fires after render                     | `(e)=>{}`             |
| 17 | onDisposing               | function               | null       | function                      | Fires before dispose                   | `(e)=>{}`             |
| 18 | onInitialized             | function               | null       | function                      | Fires on init                          | `(e)=>{}`             |
| 19 | onOptionChanged           | function               | null       | function                      | Fires on option change                 | `(e)=>{}`             |
| 20 | onValueChanged            | function               | null       | function                      | Fires when value changes               | `(e)=>{}`             |
| 21 | validationError           | any                    | null       | object                        | First validation error                 | `{message:"Error"}`   |
| 22 | validationErrors          | array                  | null       | array                         | All validation errors                  | `[{message:"Error"}]` |
| 23 | validationMessageMode     | string                 | "auto"     | "auto", "always"              | Validation message display mode        | `"always"`            |
| 24 | validationMessagePosition | string                 | "bottom"   | "top","bottom","left","right" | Position of validation message         | `"right"`             |
| 25 | value                     | any                    | null       | any                           | Selected value                         | `"A"`                 |
| 26 | valueExpr                 | string / function      | "this"     | field / function              | Field used as value                    | `"id"`                |
| 27 | visible                   | boolean                | true       | true / false                  | Controls visibility                    | `false`               |
| 28 | width                     | number / string        | undefined  | px, %, auto                   | Component width                        | `300`                 |


## Methods

| #  | Method                           | Parameters          | Return Type          | Description                                | Example                                    |
| -- | -------------------------------- | ------------------- | -------------------- | ------------------------------------------ | ------------------------------------------ |
| 1  | beginUpdate()                    | —                   | void                 | Postpones rendering to improve performance | `instance.beginUpdate()`                   |
| 2  | clear()                          | —                   | void                 | Resets value to default                    | `instance.clear()`                         |
| 3  | defaultOptions(rule) *(static)*  | rule: object        | void                 | Sets default options by device             | `dxRadioGroup.defaultOptions({...})`       |
| 4  | dispose()                        | —                   | void                 | Disposes component and frees resources     | `instance.dispose()`                       |
| 5  | element()                        | —                   | HTMLElement / jQuery | Gets root element                          | `instance.element()`                       |
| 6  | endUpdate()                      | —                   | void                 | Resumes rendering after beginUpdate        | `instance.endUpdate()`                     |
| 7  | focus()                          | —                   | void                 | Sets focus on component                    | `instance.focus()`                         |
| 8  | getDataSource()                  | —                   | DataSource           | Gets bound data source                     | `instance.getDataSource()`                 |
| 9  | getInstance(element) *(static)*  | element: DOM/jQuery | instance             | Gets component instance from DOM           | `dxRadioGroup.getInstance(el)`             |
| 10 | instance()                       | —                   | dxRadioGroup         | Returns current instance                   | `$("#rg").dxRadioGroup("instance")`        |
| 11 | off(eventName)                   | string              | instance             | Removes all handlers for event             | `instance.off("click")`                    |
| 12 | off(eventName, handler)          | string, function    | instance             | Removes specific handler                   | `instance.off("click", fn)`                |
| 13 | on(eventName, handler)           | string, function    | instance             | Attaches event handler                     | `instance.on("valueChanged", fn)`          |
| 14 | on(events)                       | object              | instance             | Attaches multiple handlers                 | `instance.on({event: fn})`                 |
| 15 | option()                         | —                   | object               | Gets all options                           | `instance.option()`                        |
| 16 | option(name)                     | string              | any                  | Gets option value                          | `instance.option("value")`                 |
| 17 | option(name, value)              | string, any         | void                 | Sets single option                         | `instance.option("value", 1)`              |
| 18 | option(options)                  | object              | void                 | Sets multiple options                      | `instance.option({value:1})`               |
| 19 | registerKeyHandler(key, handler) | string, function    | void                 | Handles key press events                   | `instance.registerKeyHandler("enter", fn)` |
| 20 | repaint()                        | —                   | void                 | Re-renders component UI                    | `instance.repaint()`                       |
| 21 | reset(value)                     | any                 | void                 | Resets value to given value                | `instance.reset("A")`                      |
| 22 | resetOption(optionName)          | string              | void                 | Resets option to default                   | `instance.resetOption("value")`            |


## Events

| # | Event           | Type     | Trigger                                 | Event Object Properties                                   | Description                                        | Example                           |
| - | --------------- | -------- | --------------------------------------- | --------------------------------------------------------- | -------------------------------------------------- | --------------------------------- |
| 1 | onContentReady  | function | After component is rendered / repainted | `element`, `component`                                    | Fires when the UI is initialized and every repaint | `(e) => console.log("ready")`     |
| 2 | onDisposing     | function | Before component is destroyed           | `element`, `component`                                    | Fires before the component is disposed             | `(e) => console.log("disposing")` |
| 3 | onInitialized   | function | When component is initialized           | `element`, `component`                                    | Gives access to component instance                 | `(e) => instance = e.component`   |
| 4 | onOptionChanged | function | When any option changes                 | `name`, `value`, `previousValue`, `component`, `element`  | Detects runtime option updates                     | `(e) => console.log(e.name)`      |
| 5 | onValueChanged  | function | When selected value changes             | `value`, `previousValue`, `event`, `component`, `element` | Fires after user or programmatic value change      | `(e) => console.log(e.value)`     |

