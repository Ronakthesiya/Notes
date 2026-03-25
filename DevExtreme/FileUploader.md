## Create

```js
$(function() {
    $("#file-uploader").dxFileUploader({ });
});
```

## Options

| #  | Option                | Type             | Default               | Possible Values                | Description                             | Example               |
| -- | --------------------- | ---------------- | --------------------- | ------------------------------ | --------------------------------------- | --------------------- |
| 1  | accept                | string           | `""`                  | MIME types / extensions        | Filters selectable file types in dialog | `"image/*"`           |
| 2  | accessKey             | string           | undefined             | any key                        | Keyboard shortcut to focus component    | `"u"`                 |
| 3  | activeStateEnabled    | boolean          | false                 | true / false                   | Enables pressed visual state            | `true`                |
| 4  | allowCanceling        | boolean          | true                  | true / false                   | Allows canceling upload                 | `true`                |
| 5  | allowedFileExtensions | array            | []                    | [".jpg", ".png"]               | Restricts upload file types             | `[".pdf"]`            |
| 6  | chunkSize             | number           | 0                     | any number                     | Enables chunk upload (bytes)            | `2000000`             |
| 7  | dialogTrigger         | string / element | null                  | selector                       | Custom button to open dialog            | `"#btn"`              |
| 8  | disabled              | boolean          | false                 | true / false                   | Disables component                      | `true`                |
| 9  | elementAttr           | object           | {}                    | HTML attrs                     | Adds attributes to container            | `{ class:"myClass" }` |
| 10 | height                | number/string    | undefined             | px, %, etc.                    | Component height                        | `"200px"`             |
| 11 | hint                  | string           | ""                    | any text                       | Tooltip text                            | `"Upload file"`       |
| 12 | hoverStateEnabled     | boolean          | true                  | true / false                   | Enables hover UI effect                 | `false`               |
| 13 | inputAttr             | object           | {}                    | HTML attrs                     | Attributes for input element            | `{ id:"fileInput" }`  |
| 14 | isValid               | boolean          | true                  | true / false                   | Validation state                        | `false`               |
| 15 | labelText             | string           | `"or Drop file here"` | text                           | Drop zone text                          | `"Drop here"`         |
| 16 | maxFileSize           | number           | 0                     | bytes                          | Max allowed file size                   | `5000000`             |
| 17 | minFileSize           | number           | 0                     | bytes                          | Min allowed file size                   | `1000`                |
| 18 | multiple              | boolean          | false                 | true / false                   | Allows multiple files                   | `true`                |
| 19 | name                  | string           | `"files[]"`           | any string                     | Field name for upload                   | `"myFiles"`           |
| 20 | onBeforeSend          | function         | null                  | function                       | Modify request before send              | `(e)=>{}`             |
| 21 | onContentReady        | function         | null                  | function                       | Fires when UI ready                     | `(e)=>{}`             |
| 22 | onDisposing           | function         | null                  | function                       | Fires on destroy                        | `(e)=>{}`             |
| 23 | onDropZoneEnter       | function         | null                  | function                       | Drag enter event                        | `(e)=>{}`             |
| 24 | onDropZoneLeave       | function         | null                  | function                       | Drag leave event                        | `(e)=>{}`             |
| 25 | onFilesUploaded       | function         | null                  | function                       | All files uploaded                      | `(e)=>{}`             |
| 26 | onInitialized         | function         | null                  | function                       | Component init                          | `(e)=>{}`             |
| 27 | onOptionChanged       | function         | null                  | function                       | Option changed event                    | `(e)=>{}`             |
| 28 | onProgress            | function         | null                  | function                       | Upload progress                         | `(e)=>{}`             |
| 29 | onUploadAborted       | function         | null                  | function                       | Upload canceled                         | `(e)=>{}`             |
| 30 | onUploadError         | function         | null                  | function                       | Upload failed                           | `(e)=>{}`             |
| 31 | onUploadStarted       | function         | null                  | function                       | Upload started                          | `(e)=>{}`             |
| 32 | onValueChanged        | function         | null                  | function                       | File selection changed                  | `(e)=>{}`             |
| 33 | progress              | number           | 0                     | 0–100                          | Upload progress value                   | `50`                  |
| 34 | readOnly              | boolean          | false                 | true / false                   | Prevents editing                        | `true`                |
| 35 | rtlEnabled            | boolean          | false                 | true / false                   | Right-to-left UI                        | `true`                |
| 36 | selectButtonText      | string           | `"Select File"`       | text                           | File dialog button text                 | `"Choose"`            |
| 37 | showFileList          | boolean          | true                  | true / false                   | Shows selected files                    | `false`               |
| 38 | tabIndex              | number           | 0                     | any number                     | Tab navigation index                    | `1`                   |
| 39 | uploadAbortedMessage  | string           | `"Upload cancelled"`  | text                           | Cancel message                          | `"Stopped"`           |
| 40 | uploadButtonText      | string           | `"Upload"`            | text                           | Upload button label                     | `"Start"`             |
| 41 | uploadChunk           | function         | null                  | function                       | Custom chunk upload                     | `(file)=>{}`          |
| 42 | uploadCustomData      | object           | {}                    | any object                     | Extra data in request                   | `{ userId:1 }`        |
| 43 | uploadFailedMessage   | string           | `"Upload failed"`     | text                           | Failure message                         | `"Error!"`            |
| 44 | uploadFile            | function         | null                  | function                       | Custom upload logic                     | `(file)=>{}`          |
| 45 | uploadHeaders         | object           | {}                    | key-value                      | Request headers                         | `{Auth:"token"}`      |
| 46 | uploadMethod          | string           | `"POST"`              | POST, PUT                      | HTTP method                             | `"PUT"`               |
| 47 | uploadMode            | string           | `"instantly"`         | instantly, useButtons, useForm | Upload behavior                         | `"useButtons"`        |
| 48 | uploadUrl             | string           | ""                    | URL                            | Server endpoint                         | `"/api/upload"`       |
| 49 | uploadedMessage       | string           | `"Uploaded"`          | text                           | Success message                         | `"Done"`              |
| 50 | uploadingMessage      | string           | `"Uploading..."`      | text                           | Progress message                        | `"Sending..."`        |
| 51 | value                 | array            | []                    | File[]                         | Selected files                          | `[]`                  |
| 52 | visible               | boolean          | true                  | true / false                   | Show/hide component                     | `false`               |
| 53 | width                 | number/string    | undefined             | px, %, etc.                    | Component width                         | `"100%"`              |


## Methods

| #  | Method                           | Parameters       | Return Type        | Description                                               | Example                                    |
| -- | -------------------------------- | ---------------- | ------------------ | --------------------------------------------------------- | ------------------------------------------ |
| 1  | abortUpload()                    | —                | void               | Cancels all uploads                                       | `uploader.abortUpload()`                   |
| 2  | abortUpload(file)                | File             | void               | Cancels specific file upload                              | `uploader.abortUpload(file)`               |
| 3  | abortUpload(index)               | Number           | void               | Cancels upload by index                                   | `uploader.abortUpload(1)`                  |
| 4  | beginUpdate()                    | —                | void               | Stops UI rendering temporarily (performance optimization) | `uploader.beginUpdate()`                   |
| 5  | clear()                          | —                | void               | Clears selected files (resets value)                      | `uploader.clear()`                         |
| 6  | defaultOptions(rule)             | Object           | void (static)      | Sets global default config                                | `dxFileUploader.defaultOptions({...})`     |
| 7  | dispose()                        | —                | void               | Destroys component instance                               | `uploader.dispose()`                       |
| 8  | element()                        | —                | HTMLElement/jQuery | Gets root element                                         | `uploader.element()`                       |
| 9  | endUpdate()                      | —                | void               | Resumes rendering after beginUpdate                       | `uploader.endUpdate()`                     |
| 10 | focus()                          | —                | void               | Focuses component                                         | `uploader.focus()`                         |
| 11 | getInstance(element)             | Element          | instance           | Gets instance from DOM (static)                           | `dxFileUploader.getInstance(el)`           |
| 12 | instance()                       | —                | instance           | Returns current instance                                  | `$("#id").dxFileUploader("instance")`      |
| 13 | off(eventName)                   | string           | instance           | Removes all handlers of event                             | `uploader.off("upload")`                   |
| 14 | off(eventName, handler)          | string, function | instance           | Removes specific handler                                  | `uploader.off("upload", fn)`               |
| 15 | option()                         | —                | Object             | Gets all options                                          | `uploader.option()`                        |
| 16 | option(name)                     | string           | any                | Gets one option value                                     | `uploader.option("multiple")`              |
| 17 | option(name, value)              | string, any      | void               | Sets one option                                           | `uploader.option("multiple", true)`        |
| 18 | option(object)                   | Object           | void               | Sets multiple options                                     | `uploader.option({multiple:true})`         |
| 19 | registerKeyHandler(key, handler) | string, function | void               | Handles keyboard events                                   | `uploader.registerKeyHandler("enter", fn)` |
| 20 | removeFile(file)                 | File             | void               | Removes file                                              | `uploader.removeFile(file)`                |
| 21 | removeFile(index)                | Number           | void               | Removes file by index                                     | `uploader.removeFile(0)`                   |
| 22 | repaint()                        | —                | void               | Re-renders component UI                                   | `uploader.repaint()`                       |
| 23 | reset(value)                     | File[]           | void               | Resets value to given files                               | `uploader.reset([])`                       |
| 24 | resetOption(name)                | string           | void               | Resets option to default                                  | `uploader.resetOption("multiple")`         |
| 25 | upload()                         | —                | void               | Uploads all files                                         | `uploader.upload()`                        |
| 26 | upload(file)                     | File             | void               | Upload specific file                                      | `uploader.upload(file)`                    |
| 27 | upload(index)                    | Number           | void               | Upload file by index                                      | `uploader.upload(1)`                       |


## Events

| #  | Event           | Type     | Default | Event Argument (e) | Description                                        | Example                                                |
| -- | --------------- | -------- | ------- | ------------------ | -------------------------------------------------- | ------------------------------------------------------ |
| 1  | onBeforeSend    | function | null    | BeforeSendEvent    | Fires before request is sent (modify headers/data) | `(e)=>{ e.request.setRequestHeader("Auth","token"); }` |
| 2  | onContentReady  | function | null    | EventObject        | Fires when component UI is ready                   | `(e)=>{ console.log("ready"); }`                       |
| 3  | onDisposing     | function | null    | EventObject        | Fires before component is destroyed                | `(e)=>{}`                                              |
| 4  | onDropZoneEnter | function | null    | DropZoneEnterEvent | Fires when file dragged into drop zone             | `(e)=>{}`                                              |
| 5  | onDropZoneLeave | function | null    | DropZoneLeaveEvent | Fires when file leaves drop zone                   | `(e)=>{}`                                              |
| 6  | onFilesUploaded | function | null    | FilesUploadedEvent | Fires when all files are uploaded                  | `(e)=>{ console.log("done"); }`                        |
| 7  | onInitialized   | function | null    | InitializedEvent   | Fires when component is initialized                | `(e)=>{}`                                              |
| 8  | onOptionChanged | function | null    | OptionChangedEvent | Fires when any option changes                      | `(e)=>{ console.log(e.name); }`                        |
| 9  | onProgress      | function | null    | ProgressEvent      | Fires during upload progress                       | `(e)=>{ console.log(e.bytesLoaded); }`                 |
| 10 | onUploadAborted | function | null    | UploadAbortedEvent | Fires when upload is canceled                      | `(e)=>{}`                                              |
| 11 | onUploadError   | function | null    | UploadErrorEvent   | Fires when upload fails                            | `(e)=>{ console.error(e.error); }`                     |
| 12 | onUploadStarted | function | null    | UploadStartedEvent | Fires when upload starts                           | `(e)=>{}`                                              |
| 13 | onValueChanged  | function | null    | ValueChangedEvent  | Fires when selected files change                   | `(e)=>{ console.log(e.value); }`                       |



