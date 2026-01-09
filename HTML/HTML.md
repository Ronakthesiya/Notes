## HTML Introduction

HTML stands for HyperText Markup Language. It is used to structure the content on the web by using various elements (commonly known as tags).


## Basic Structure

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>My First Web Page</title>
</head>
<body>
    <h1>Hello, World!</h1>
    <p>This is my first HTML page.</p>
</body>
</html>
```

---

## !DOCTYPE html

- this tells the browser: “This document is written in HTML5.”
- Must be the first line of the document
- Case-insensitive, but usually written in uppercase

---

## HTML tag

- The root element of the HTML document.
- Everything else goes inside this tag.

### Attributes

| **Attribute**     | **Description**                          | **Possible Values**       | **Example Usage**                 |
| ----------------- | ---------------------------------------- | ------------------------- | --------------------------------- |
| `lang`            | Defines the main language of the webpage | `en`, `fr`, `hi`, `en-US` | `<html lang="en">`                |
| `dir`             | Sets text direction                      | `ltr`, `rtl`, `auto`      | `<html dir="rtl">`                |
| `class`           | Assigns CSS class(es)                    | Any class name            | `<html class="dark-theme">`       |
| `id`              | Unique identifier for the element        | Unique name               | `<html id="mainPage">`            |
| `style`           | Applies inline CSS styles                | CSS rules                 | `<html style="background:#fff;">` |
| `title`           | Shows tooltip text on hover              | Any text                  | `<html title="HTML Document">`    |
| `hidden`          | Hides the entire element                 | `hidden`                  | `<html hidden>`                   |
| `data-*`          | Stores custom user data                  | Custom key-value          | `<html data-theme="dark">`        |
| `contenteditable` | Makes content editable                   | `true`, `false`           | `<html contenteditable="true">`   |
| `translate`       | Controls browser translation             | `yes`, `no`               | `<html translate="no">`           |
| `draggable`       | Enables drag behavior                    | `true`, `false`, `auto`   | `<html draggable="false">`        |
| `spellcheck`      | Enables/disables spell checking          | `true`, `false`           | `<html spellcheck="true">`        |
| `tabindex`        | Controls keyboard navigation order       | `-1`, `0`, `1`            | `<html tabindex="-1">`            |
| `accesskey`       | Keyboard shortcut for element            | Any key                   | `<html accesskey="h">`            |
| `role`            | Defines ARIA role for accessibility      | ARIA roles                | `<html role="document">`          |

---

## head tag

- Contains metadata (data about data)
- Not visible on the webpage

### Elements in head tag

<details>
<summary><h3>title tag</h3></summary>

Shows the page title in:
- Browser tab
- Search engine results
- Bookmarks

1. Only one `<title>` is allowed per page
2. Must contain text only
3. Cannot include HTML tags like `<b>`, `<i>`, or `<img>`
4. Should be short and meaningful

```html
<head>
    <title>My First Web Page</title>
</head>
```
</details>


<details>
<summary><h3>meta tag</h3></summary>

In HTML, the `<meta>` tag provides metadata about a web page
The `<meta>` tag is used to define:
- Character encoding
- Page description
- Keywords
- Author information
- Viewport settings (for responsive design)
- Page behavior (refresh, cache, etc.)


#### 1. Character Encoding

Defines how characters are encoded so text displays correctly.
- Prevents text corruption
- Supports almost all languages
- Recommended for all websites

```html
<meta charset="UTF-8">
```


#### 2. Meta Description
- Provides a short summary of the page content.
- Often shown in search engine results
- Important for SEO and click-through rate

```html
<meta name="description" content="Learn HTML meta tags with examples and explanations">
```


#### 3. Meta Keywords

Used to define keywords related to the page.

```html
<meta name="keywords" content="HTML, meta tag, web development">
```
- ❌ Most modern search engines ignore this tag
- ❌ Not recommended for SEO today


#### 4. Meta Author
Defines the author of the webpage.

```html
<meta name="author" content="John Doe">
```

#### 5. Viewport

Controls layout on mobile devices.
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```
- ✔ Essential for mobile-friendly websites
- ✔ Makes layouts scale correctly on different screen sizes


#### 6. HTTP-Equiv Meta Tags

Simulate HTTP response headers.

- Page Refresh
```html
<meta http-equiv="refresh" content="5">
```
Refreshes the page every 5 seconds

- Redirect
```html
<meta http-equiv="refresh" content="3; url=https://example.com">
```
Redirects after 3 seconds


#### 7. Cache Control

Controls browser caching behavior.
```html
<meta http-equiv="cache-control" content="no-cache">
```

#### 8. Content Security Policy
```html
<meta http-equiv="Content-Security-Policy" content="default-src 'self'">
```


</details>

<details>
<summary><h3>link tag</h3></summary>

The `<link>` tag defines a relationship between the current HTML document and an external resource.

Attributes:

| **Attribute** | **Description**                                                                  | **Common Values**                                | **Required?** | **Example**                                                          |
| ------------- | -------------------------------------------------------------------------------- | ------------------------------------------------ | ------------- | -------------------------------------------------------------------- |
| `rel`         | Specifies the relationship between the current document and the linked resource. | stylesheet, icon, preconnect, preload, alternate | **Yes**       | `<link rel="stylesheet" href="style.css">`                           |
| `href`        | Specifies the path/URL to the external resource.                                 | (URL path)                                       | **Yes**       | `<link rel="stylesheet" href="style.css">`                           |
| `type`        | Specifies the MIME type of the linked resource.                                  | screen, print, all                               | **No**        | `<link rel="stylesheet" type="text/css" href="style.css">`           |
| `media`       | Specifies which devices or screen sizes the stylesheet applies to.               | (media queries like `print`, `screen`)           | **No**        | `<link rel="stylesheet" href="print.css" media="print">`             |
| `sizes`       | Specifies the size of the icon.                                                  | (icon sizes like `32x32`)                        | **No**        | `<link rel="icon" href="icon-32.png" sizes="32x32">`                 |
| `hreflang`    | Specifies the language of the linked document.                                   | (language codes like `fr` for French)            | **No**        | `<link rel="alternate" hreflang="fr" href="https://example.com/fr">` |


Common Uses : 

| **Use Case**                 | **Example**                                                                                                                                        | **Description**                                            | **Benefits**                                                                                |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| **1. Linking External CSS**  | `<link rel="stylesheet" href="styles.css">`                                                                                                        | Links an external CSS stylesheet to an HTML document.      | ✔ Keeps HTML and CSS separate <br> ✔ Improves maintainability <br> ✔ Allows reuse of styles |
| **2. Adding a Favicon**      | `<link rel="icon" href="favicon.ico" type="image/x-icon">`                                                                                         | Adds a small icon (favicon) in browser tabs and bookmarks. | ✔ Displays a small icon in browser tabs <br> ✔ Used in bookmarks                            |
| **3. Linking Google Fonts**  | `<link rel="preconnect" href="https://fonts.googleapis.com">` <br> `<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto">` | Links Google Fonts for use in the document.                | ✔ Loads fonts efficiently <br> ✔ Improves performance                                       |
| **4. Preloading Resources**  | `<link rel="preload" href="main.css" as="style">`                                                                                                  | Preloads critical resources for faster loading.            | ✔ Loads critical resources early <br> ✔ Improves page load speed                            |
| **5. Alternate Stylesheets** | `<link rel="alternate stylesheet" href="dark.css" title="Dark Mode">`                                                                              | Allows users to switch between different stylesheets.      | ✔ Allows multiple stylesheets <br> ✔ Useful for themes                                      |
| **6. RSS / Atom Feeds**      | `<link rel="alternate" type="application/rss+xml" href="feed.xml" title="RSS Feed">`                                                               | Links to an RSS/Atom feed.                                 | ✔ Helps browsers and readers discover feeds                                                 |




</details>

<details>
<summary><h3>style tag</h3></summary>

- Used for small or test projects
- Avoid large CSS here

```html
<style>
  body {
    font-family: Arial;
    background-color: #f5f5f5;
  }
</style>
```
</details>

<details>
<summary><h3>script tag</h3></summary>

1. External JavaScript 

```html
<script src="app.js"></script>
```

2. Internal JavaScript

```html
<script>
  console.log("Hello World");
</script>
```

Inside `<head>`
HTML loads top to bottom
Script may run before HTML elements exist
Can cause errors like:
Cannot read property 'addEventListener' of null



3. With defer

- ✔ HTML loads first
- ✔ Script loads in background
- ✔ Runs after DOM is ready
- Best modern approach

```html
<script src="app.js" defer></script>
```

4. With async

- Loads script asynchronously
- Executes as soon as it loads
- Execution order is NOT guaranteed

- Best for:
Analytics, 
Ads, 
Tracking scripts

</details>


<details>
<summary><h3>base tag</h3></summary>

```html
<base href="https://example.com/" target="_blank">
```

- `<base>` → HTML element that sets a base URL and/or default target
- href → Specifies the base URL for all relative links
- target → Specifies the default browsing context (where links open)

- Only one `<base>` tag is allowed per document.
- Must be in the `<head>` section.


```html
<!DOCTYPE html>
<html>
<head>
  <base href="https://example.com/folder/">
  <title>Base Tag Example</title>
</head>
<body>
  <a href="page.html">Visit Page</a> → Resolves to https://example.com/folder/page.html
  <img src="image.jpg" alt="Sample Image"> → Resolves to https://example.com/folder/image.jpg
  <a href="https://google.com">Google</a> → Resolves to https://google.com
</body>
</html>
```

- Relative links (page.html) → https://example.com/folder/page.html in a new tab
- Absolute links (https://google.com) → Open as specified (ignores base URL)

#### Common target values

| Value       | Behavior                                 |
| ----------- | ---------------------------------------- |
| `_self`     | Open in same window/tab (default)        |
| `_blank`    | Open in a new window/tab                 |
| `_parent`   | Open in parent frame                     |
| `_top`      | Open in full body, replacing all frames  |
| `framename` | Open in a specific iframe with that name |



</details>


<details>
<summary><h3>noscript tag</h3></summary>

```html
<noscript>
  Your browser does not support JavaScript!
</noscript>
```

- Displays content only if JavaScript is disabled or not supported.
- Content inside `<noscript>` is ignored by browsers that have JavaScript enabled.
- `<noscript>` can be placed in body and head tags

- `<noscript>` is ignored if JS is enabled, even partially
- Cannot execute JavaScript inside `<noscript>`

</details>


<details>
<summary><h3>template tag</h3></summary>

- The content inside `<template>` is not displayed in the browser by default.
- The content is inactive until accessed via JavaScript.
- `<template>` helps you store HTML snippets for later use.


```html
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Template Example</title>
</head>
<body>
  <template id="card-template">
    <div class="card">
      <h2></h2>
      <p></p>
    </div>
  </template>

  <div id="cards-container"></div>

  <script>
    const data = [
      { title: "Card 1", description: "Description 1" },
      { title: "Card 2", description: "Description 2" },
      { title: "Card 3", description: "Description 3" }
    ];

    const template = document.getElementById("card-template");
    const container = document.getElementById("cards-container");

    data.forEach(item => {
      const clone = template.content.cloneNode(true);
      clone.querySelector("h2").textContent = item.title;
      clone.querySelector("p").textContent = item.description;
      container.appendChild(clone);
    });
  </script>
</body>
</html>

```


| Feature                 | `<template>` | `<div style="display:none">` |
| ----------------------- | ------------ | ---------------------------- |
| Rendered in DOM         | No           | Yes (hidden but rendered)    |
| Scripts execution       | No           | Yes (executes if any)        |
| Best for dynamic clones | ✅            | ❌                            |
| Memory-efficient        | ✅            | ❌                            |

</details>


---

## Body tag

contains all visible content of the webpage.

### Global Attributes

| **Attribute** | **Type / Category** | **Description**                                                 | **Example**                                                 |
| ------------- | ------------------- | --------------------------------------------------------------- | ----------------------------------------------------------- |
| `id`          | Global              | Unique identifier for the `<body>` element, useful for CSS/JS.  | `<body id="mainBody">`                                      |
| `class`       | Global              | One or more class names for styling with CSS.                   | `<body class="dark-theme page-home">`                       |
| `style`       | Global              | Inline CSS styles.                                              | `<body style="background-color: lightblue; color: black;">` |
| `title`       | Global              | Provides extra info, often shown as a tooltip.                  | `<body title="Main content of the page">`                   |
| `data-*`      | Global              | Custom data attributes for JS.                                  | `<body data-user="admin">`                                  |
| `lang`        | Global              | Specifies the language of the content.                          | `<body lang="en">`                                          |
| `dir`         | Global              | Text direction: `ltr` (left-to-right) or `rtl` (right-to-left). | `<body dir="rtl">`                                          |


### Event Attributes

| **Attribute**  | **Description**                                        | **Example**                                             |
| -------------- | ------------------------------------------------------ | ------------------------------------------------------- |
| `onload`       | Executes JS when the page fully loads.                 | `<body onload="alert('Welcome!')">`                     |
| `onunload`     | Executes JS when the page is closed or navigated away. | `<body onunload="alert('Goodbye!')">`                   |
| `onresize`     | Executes JS when the window is resized.                | `<body onresize="console.log('Window resized')">`       |
| `onscroll`     | Executes JS when the page is scrolled.                 | `<body onscroll="console.log('Scrolling')">`            |
| `onkeydown`    | Executes JS when a key is pressed down.                | `<body onkeydown="console.log('Key pressed')">`         |
| `onkeyup`      | Executes JS when a key is released.                    | `<body onkeyup="console.log('Key released')">`          |
| `onkeypress`   | Executes JS when a key is pressed.                     | `<body onkeypress="console.log('Key press detected')">` |
| `onclick`      | Executes JS when the body is clicked.                  | `<body onclick="alert('Body clicked!')">`               |
| `ondblclick`   | Executes JS on double-click.                           | `<body ondblclick="alert('Double click!')">`            |
| `onmousedown`  | Executes JS when a mouse button is pressed down.       | `<body onmousedown="console.log('Mouse down')">`        |
| `onmouseup`    | Executes JS when a mouse button is released.           | `<body onmouseup="console.log('Mouse up')">`            |
| `onmousemove`  | Executes JS when the mouse is moved.                   | `<body onmousemove="console.log('Mouse moving')">`      |
| `onmouseenter` | Executes JS when the mouse enters the body.            | `<body onmouseenter="console.log('Mouse entered')">`    |
| `onmouseleave` | Executes JS when the mouse leaves the body.            | `<body onmouseleave="console.log('Mouse left')">`       |


### Deprecated Attributes

| **Attribute** | **Description**                 | **Example**                  |
| ------------- | ------------------------------- | ---------------------------- |
| `background`  | Sets a background image.        | `<body background="bg.jpg">` |
| `bgcolor`     | Sets background color.          | `<body bgcolor="yellow">`    |
| `text`        | Sets default text color.        | `<body text="blue">`         |
| `link`        | Sets color for unvisited links. | `<body link="green">`        |
| `vlink`       | Sets color for visited links.   | `<body vlink="purple">`      |
| `alink`       | Sets color for active links.    | `<body alink="red">`         |

---

## HTML Formatting Tags

| **Tag**    | **Purpose**                   | **Example Code**             | **Output (Browser View)** |
| ---------- | ----------------------------- | ---------------------------- | ------------------------- |
| `<b>`      | Makes text bold (visual only) | `<b>Bold Text</b>`           | **Bold Text**             |
| `<strong>` | Shows strong importance       | `<strong>Important</strong>` | **Important**             |
| `<i>`      | Makes text italic             | `<i>Italic Text</i>`         | *Italic Text*             |
| `<em>`     | Emphasizes text               | `<em>Emphasized</em>`        | *Emphasized*              |
| `<u>`      | Underlines text               | `<u>Underlined</u>`          | <u>Underlined</u>         |
| `<mark>`   | Highlights text               | `<mark>Highlighted</mark>`   | <mark>Highlighted</mark>  |
| `<small>`  | Displays smaller text         | `<small>Small Text</small>`  | Small Text                |
| `<sup>`    | Superscript text              | `10<sup>2</sup>`             | 10²                       |
| `<sub>`    | Subscript text                | `H<sub>2</sub>O`             | H₂O                       |
| `<del>`    | Deleted text (strike)         | `<del>₹500</del>`            | ~~₹500~~                  |
| `<ins>`    | Inserted text                 | `<ins>New Text</ins>`        | <u>New Text</u>           |
| `<code>`   | Programming code              | `<code>print()</code>`       | `print()`                 |
| `<pre>`    | Preformatted text             | `<pre>Hello   World</pre>`   | Preserves spacing         |
| `<kbd>`    | Keyboard input                | `<kbd>Ctrl</kbd>`            | Ctrl                      |
| `<samp>`   | Sample output                 | `<samp>Error</samp>`         | Error                     |
| `<var>`    | Variable name                 | `<var>x</var> = 5`           | *x* = 5                   |
| `<cite>`   | Title of work                 | `<cite>HTML Book</cite>`     | *HTML Book*               |
| `<dfn>`    | Definition term               | `<dfn>HTML</dfn>`            | *HTML*                    |
| `<bdo>`    | Text direction                | `<bdo dir="rtl">Hello</bdo>` | olleH                     |
| `<bdi>`    | Isolate direction             | `<bdi>محمد</bdi>`            | محمد                      |


---

## img tag

```html
<img src="image_path" alt="Alternate text for the image" width="200px" height="150px" />
```

- src: The src attribute defines the path of the image (image URL).
- alt: The alt attribute defines the alternate text; if there is a broken link to the image path, the alternate text displays on the webpage.
- width and height: The width and height attribute define the height and width for the image.


### Attributes

| **Attribute**   | **Possible Values**   | **Effect / Meaning**                      | **Example**                                   |
| --------------- | --------------------- | ----------------------------------------- | --------------------------------------------- |
| `src`           | URL / path to image   | Specifies image source                    | `<img src="cat.jpg">`                         |
| `alt`           | Any text              | Shows text if image fails; accessibility  | `<img alt="White cat">`                       |
| `width`         | Number (px)           | Sets image width                          | `<img width="300">`                           |
| `height`        | Number (px)           | Sets image height                         | `<img height="200">`                          |
| `loading`       | `lazy`                | Loads image when needed                   | `<img loading="lazy">`                        |
|                 | `eager`               | Loads immediately                         | `<img loading="eager">`                       |
| `decoding`      | `sync`                | Decode immediately                        | `<img decoding="sync">`                       |
|                 | `async`               | Decode asynchronously                     | `<img decoding="async">`                      |
|                 | `auto`                | Browser decides                           | `<img decoding="auto">`                       |
| `fetchpriority` | `high`                | Load first                                | `<img fetchpriority="high">`                  |
|                 | `low`                 | Load later                                | `<img fetchpriority="low">`                   |
|                 | `auto`                | Default behavior                          | `<img fetchpriority="auto">`                  |
| `srcset`        | `URL widthDescriptor` | Loads image based on screen               | `<img srcset="a.jpg 480w, b.jpg 800w">`       |
| `sizes`         | Media conditions      | Defines layout size                       | `<img sizes="(max-width:600px) 100vw, 50vw">` |
| `usemap`        | `#mapname`            | Links image to map                        | `<img usemap="#mymap">`                       |
| `ismap`         | Boolean               | Sends click coordinates                   | `<img ismap>`                                 |
| `align`         | `left`, `right`       | Align image                               | CSS                                           |
| `border`        | Number                | Image border                              | CSS                                           |
| `hspace`        | Number                | Horizontal spacing                        | CSS                                           |
| `vspace`        | Number                | Vertical spacing                          | CSS                                           |
| `longdesc`      | URL                   | Image description                         | `<figure>`                                    |

---

## Image Maps

HTML image maps are defined by the `<map>` tag. An image map enables specific areas of an image to be clickable, acting as links to different destinations.

The `<map>` tag is used to create a client-side image map, turning specific regions of an image into interactive elements. This allows users to click on different areas of the image, triggering various actions. The `<map>` element serves as a container for `<area>` elements, each defining a clickable region with specific attributes.

```html
<img src="/images/logo.png" usemap="#image_map">

<map name="world map">
   <!-- Define your clickable areas here -->
   <area shape="shape_values" coords="coordinates" href="url" alt="Description">
</map>
```

### 1. Rectangular Area

```html
<area shape="rect" coords="x1,y1,x2,y2" href="url" alt="Description">
```
- x1, y1 − Coordinates of the top-left corner.
- x2, y2 − Coordinates of the bottom-right corner

### 2. Circular Area
```html
<area shape="circle" coords="x,y,r" href="url" alt="Description">
```
- x, y − Coordinates of the circle's center.
- r − Radius of the circle.

### 3. Polygon Area
```html
<area shape="poly" coords="x1,y1,x2,y2,..,xn,yn" href="url" alt="Description">
```
- Where x1, y1,..., xn, yn coordinates form the polygon.

---


## Table 

- The `<table>` tag is used in HTML to display data in rows and columns, like a spreadsheet.
- `<tr>` – Table Row
- `<td>` – Table Data
- `<th>` – Table Header
- `<caption>` – Table Title
- `<thead>` – Table Head
- `<tbody>` – Table Body
- `<tfoot>` – Table Footer

### Attributes of `<table>` Tag

| **Attribute**    | **Explanation**                                     | **Example**                               |
| ---------------- | --------------------------------------------------- | ----------------------------------------- |
| `border`         | Specifies the thickness of the table border         | `<table border="1">`                      |
| `width`          | Sets the width of the table (px or %)               | `<table width="80%">`                     |
| `height`         | Sets the height of the table                        | `<table height="300">`                    |
| `align`          | Aligns the table horizontally (left, center, right) | `<table align="center">`                  |
| `cellpadding`    | Space between cell border and content               | `<table cellpadding="10">`                |
| `cellspacing`    | Space between table cells                           | `<table cellspacing="5">`                 |
| `bgcolor` ⚠️     | Sets background color of table (deprecated)         | `<table bgcolor="lightblue">`             |
| `bordercolor` ⚠️ | Sets border color (deprecated)                      | `<table bordercolor="red">`               |
| `rules` ⚠️       | Controls inner borders (rows, cols, all, none)      | `<table rules="all">`                     |
| `frame` ⚠️       | Controls outer border sides                         | `<table frame="box">`                     |
| `summary`        | Describes table for screen readers                  | `<table summary="Student marks">`         |
| `style`          | Applies CSS styles                                  | `<table style="border:2px solid black;">` |
| `class`          | Assigns CSS class                                   | `<table class="data-table">`              |
| `id`             | Gives unique identification                         | `<table id="marksTable">`                 |
| `title`          | Shows tooltip text                                  | `<table title="Student Info">`            |


### Attributes of `<tr>` (Table Row)

| **Attribute** | **Explanation**           | **Example**               |
| ------------- | ------------------------- | ------------------------- |
| `align`       | Aligns content in row     | `<tr align="center">`     |
| `valign`      | Vertical alignment of row | `<tr valign="top">`       |
| `bgcolor` ⚠️  | Row background color      | `<tr bgcolor="yellow">`   |
| `style`       | CSS styling               | `<tr style="color:red;">` |


### Attributes of `<td>` and `<th>` (Table Cells)

| **Attribute** | **Explanation**           | **Example**                      |
| ------------- | ------------------------- | -------------------------------- |
| `rowspan`     | Merges cells vertically   | `<td rowspan="2">Total</td>`     |
| `colspan`     | Merges cells horizontally | `<td colspan="3">Marks</td>`     |
| `align`       | Aligns text horizontally  | `<td align="right">90</td>`      |
| `valign`      | Aligns text vertically    | `<td valign="middle">Data</td>`  |
| `width`       | Sets cell width           | `<td width="100">`               |
| `height`      | Sets cell height          | `<td height="50">`               |
| `bgcolor` ⚠️  | Cell background color     | `<td bgcolor="pink">`            |
| `style`       | CSS styling               | `<td style="font-weight:bold;">` |


## Form 

The `<form>` tag is a container for all form-related elements.

### Attributes 

1. action
- where the form data sent

- URL (/submit, login.php, https://example.com)
- Empty (action="") → submits to same page
- Omitted → same page



2. method
```html
<form method="get">
<form method="post">
```
| Method | Description                         |
| ------ | ----------------------------------- |
| `get`  | Appends data to URL (visible)       |
| `post` | Sends data in request body (hidden) |



3. enctype
```html
<form enctype="application/x-www-form-urlencoded">
``` 
| Value                               | Use                         |
| ----------------------------------- | --------------              |
| `application/x-www-form-urlencoded` | Default                     |
| `multipart/form-data`               | File uploads                |
| `text/plain`                        | Debugging only, Plain text  |


4. accept-charset
```html
<form accept-charset="UTF-8 ISO-8859-1">
```
- It specifies how characters are encoded before being sent.
- This is important for handling non-ASCII characters (like accented letters, emojis, or non-English scripts).
- The browser will choose the first supported encoding from the list.



5. autocapitalize

- The autocapitalize attribute controls whether and how text is automatically capitalized when a user types, mainly on mobile devices (phones and tablets).

```html
<form>
  <input type="text" name="username" autocapitalize="none">
</form>
```

| Value        | Behavior                                       |
| ------------ | ---------------------------------------------- |
| `none`       | No automatic capitalization                    |
| `sentences`  | Capitalize first letter of sentences (default) |
| `words`      | Capitalize first letter of each word           |
| `characters` | Capitalize every character                     |


6. autocomplete
Indicates whether input elements can by default have their values automatically completed by the browser.


7. target
Indicates where to display the response after submitting the form


## Input

### Attributes

#### type

1. button
- value = text inside btn
- accesskey = to fast access btn
- disabled = to disable btn

2. checkbox
- id, name = same if required
- checked
- value = pass to server when checked

3. color

4. date
- value = "yyyy-mm-dd", may be not in step date
- max,min = "yyyy-mm-dd"
- step = days(1,2..) , count from min -> value -> 01-01-1970

5. datetime-local
- value,max,min = "yyyy-mm-ddThh:mm:ss:milis"
- step = sec , count from min -> value -> 01-01-1970T00:00

6. email
- list = id of `<datalist>` for suggestions
- maxlength,minlength = int
- multiple = allow to take comma(,) seprated list of email
- pattern = RegExp
- placeholder, readonly, value

7. file
- value = path of file
- accept = list of file type (".doc,.docx,.xml")
- capture = user,environment -> to open camera, audio of mobile devices
- multiple

8. hidden

9. image

10. month
- value,max,min = "yyyy-mm"
- step = months

11. number
- value,min,max,step

12. password
- maxlength,minlength,value

13. radio
- name = same for group
- value = send to server
- checked = default checked

14. range
- min,max,value
- list

15. reset
- value = display in btn
- accesskey = shortcut key

16. search

17. submit
- value, accesskey

18. tel

19. text
- list, maxlength, minlength, spellcheck, size, placeholder

20. time
- min,max,value = hh:mm
- step = sec

21. url

22. week
- value,min,max = yyyy-Wnn (2017-W01)
- step = weeks

## label

When a user clicks or touches/taps a label, the browser passes the focus to its associated input

### two ways

- you first need to add the id attribute to the `<input>` element. Next, you add the for attribute to the `<label>` element, where the value of for is the same as the id in the `<input>` element.

```html
<label for="peas">I like peas.</label>
<input type="checkbox" name="peas" id="peas" />
```

- you can nest the `<input>` directly inside the `<label>`, in which case the for and id attributes are not needed because the association is implicit:
```html
<label>
  I like peas.
  <input type="checkbox" name="peas" />
</label>
```

## button

```html
<button class="favorite styled" type="button">Add to favorites</button>
```

### Attributes

1. autofocus = This Boolean attribute specifies that the button should have input focus when the page loads. Only one element in a document can have this attribute.

2. value, type, disabled

## datalist

give suggestion when focus on input tag

```html
<label for="ice-cream-choice">Choose a flavor:</label>
<input list="ice-cream-flavors" id="ice-cream-choice" name="ice-cream-choice" />

<datalist id="ice-cream-flavors">
  <option value="Chocolate"></option>
  <option value="Coconut"></option>
  <option value="Mint"></option>
  <option value="Strawberry"></option>
  <option value="Vanilla"></option>
</datalist>
```

## feildset

to group some part of form

```html
<fieldset>
  <legend>Choose your favorite monster</legend>

  <!-- .... form data -->
</fieldset>
```

## select

create a dropdown list

```html
<select name="pets" id="pet-select">
  <option value="">--Please choose an option--</option>
  <option value="dog" selected>Dog</option>
  <option value="cat">Cat</option>
  <option value="hamster">Hamster</option>
  <option value="parrot">Parrot</option>
  <option value="spider">Spider</option>
  <option value="goldfish">Goldfish</option>
</select>
```

### Attributes
1. multiple, size, name, required, disable  
2. selected = for default select

### optgroup

used to part the selection list of dropdown

```html
<select name="foods" id="hr-select">
  <option value="">Choose a food</option>
  <hr />
  <optgroup label="Fruit">
    <option value="apple">Apples</option>
    <option value="banana">Bananas</option>
    <option value="cherry">Cherries</option>
    <option value="damson">Damsons</option>
  </optgroup>
  <hr />
  <optgroup label="Vegetables">
    <option value="artichoke">Artichokes</option>
    <option value="broccoli">Broccoli</option>
    <option value="cabbage">Cabbages</option>
  </optgroup>
</select>
```

## textarea

```html
<textarea id="story" name="story" rows="5" cols="33">
It was a dark and stormy night...
</textarea>
```

---

## Semantic vs Non-Semantic

| Semantic         | Non-Semantic     |
| ---------------- | ---------------- |
| Has meaning      | No meaning       |
| SEO friendly     | Not SEO friendly |
| Accessible       | Less accessible  |
| Self-descriptive | Generic          |

---

## video tag

```html
  <video src="Assets/flower.webm" autoplay loop controls width="300"></video>
```

### Attributes

1. src = The URL of the video to embed
2. height, width
3. autoplay = the video automatically begins to play back as soon as it can without stopping to finish loading the data.
4. controls = allow the user to control video playback, including volume, seeking, and pause/resume playback.
5. controlslist = to add or remove spcific controls

```html
  <video controls controlslist="nofullscreen nodownload noremoteplayback noplaybackrate"></video>
```

6. loop = browser will automatically seek back to the start upon reaching the end of the video.
7. muted = default audio mute setting contained in the video

#### Browsers don't all support the same video formats; you can provide multiple sources

```html
<video controls>
  <source src="myVideo.webm" type="video/webm" />
  <source src="myVideo.mp4" type="video/mp4" />
  <p>
    Your browser doesn't support HTML video. Here is a
    <a href="myVideo.mp4" download="myVideo.mp4">link to the video</a> instead.
  </p>
</video>
```

---

## audio

```html
<audio src="Assets/t-rex-roar.mp3" controls autoplay loop></audio>

<a href="Assets/t-rex-roar.mp3"> Download audio </a>
```

### Attributes

1. src = The URL of the video to embed
2. autoplay = the video automatically begins to play back as soon as it can without stopping to finish loading the data.
3. controls = allow the user to control video playback, including volume, seeking, and pause/resume playback.
4. controlslist = to add or remove spcific controls
```html
  <video controls controlslist="nofullscreen nodownload noremoteplayback"></video>
```
5. loop = browser will automatically seek back to the start upon reaching the end of the video.
6. muted = default audio mute setting contained in the video

#### Browsers don't all support the same audio formats; you can provide multiple sources


```html
<audio controls>
  <source src="myAudio.mp3" type="audio/mpeg" />
  <source src="myAudio.ogg" type="audio/ogg" />
  <p>
    Download <a href="myAudio.mp3" download="myAudio.mp3">MP3</a> or
    <a href="myAudio.ogg" download="myAudio.ogg">OGG</a> audio.
  </p>
</audio>
```