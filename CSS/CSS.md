## CSS Types 

### 1. Inline

```html
<span style="color: purple; font-weight: bold">span element</span>
```

### 2. Internal style tag

```html
<style>
  p {
    color: purple;
  }
</style>
```

### 3. css file external

```html
<link rel="stylesheet" href="styles/style.css" />
```

## Selector

- Tag = direct tag name
- Class = . + class name
- div li h1 = h1 tag in li which is in div tag
- id = # + id
- based on state = 
- - a:link -> unvisited link
- - a:visited 
- - a:hover
- h1 + ul + p = all p tag just after ul which is just after h1
- tag.class = tag with class
- `*` = Universal selector select all
- `p *` = Select all in p tag not p tag it self
- `p` = select all in p ans p also selecte

### basic

| Selector           | Example   | Description                              |
| ------------------ | --------- | ---------------------------------------- |
| Tag selector       | `p`       | Selects all `<p>` elements               |
| Class selector     | `.box`    | Selects all elements with class `box`    |
| ID selector        | `#header` | Selects element with id `header`         |
| Universal selector | `*`       | Selects **all elements**                 |
| Tag + class        | `p.text`  | Selects `<p>` elements with class `text` |

### Combinators

| Selector         | Example   | Description                           |
| ---------------- | --------- | ------------------------------------- |
| Descendant       | `div p`   | `p` inside `div` (any depth)          |
| Child            | `div > p` | `p` that is **direct child** of `div` |
| Adjacent sibling | `h1 + p`  | `p` immediately after `h1`            |
| General sibling  | `h1 ~ p`  | All `p` after `h1` (same parent)      |


### Attribute selector
| Selector        | Example                         | What it Matches                                                                 |
| --------------- | ------------------------------- | ------------------------------------------------------------------------------- |
| `[attr]`        | `a[title]`                      | Elements that have the specified attribute, regardless of its value             |
| `[attr=value]`  | `a[href="https://example.com"]` | Elements whose attribute value is **exactly** `value`                           |
| `[attr~=value]` | `p[class~="special"]`           | Elements whose attribute value is a **space-separated list** containing `value` |
| `[attr^=value]` | `li[class^="box-"]`             | Elements whose attribute value **begins with** `value`                          |
| `[attr$=value]` | `li[class$="-box"]`             | Elements whose attribute value **ends with** `value`                            |
| `[attr*=value]` | `li[class*="box"]`              | Elements whose attribute value **contains** `value` anywhere                    |


### pseudo-classes

#### link

| Pseudo-class    | Description              | Example                                   |
| --------------- | ------------------------ | ----------------------------------------- |
| `:link`         | Unvisited link           | `a:link { color: blue; }`                 |
| `:visited`      | Visited link             | `a:visited { color: purple; }`            |
| `:hover`        | Mouse over element       | `button:hover { background: red; }`       |
| `:active`       | While clicking           | `a:active { color: green; }`              |
| `:focus`        | Focused element          | `input:focus { border: 2px solid blue; }` |
| `:focus-within` | Parent has focused child | `form:focus-within { background: #eee; }` |

#### Form & Input Related

| Pseudo-class         | Description         | Example                                    |
| -------------------- | ------------------- | ------------------------------------------ |
| `:checked`           | Checked input       | `input:checked { accent-color: green; }`   |
| `:disabled`          | Disabled input      | `input:disabled { background: #ccc; }`     |
| `:enabled`           | Enabled input       | `input:enabled { background: white; }`     |
| `:required`          | Required input      | `input:required { border: red; }`          |
| `:optional`          | Optional input      | `input:optional { border: gray; }`         |
| `:valid`             | Valid input         | `input:valid { border: green; }`           |
| `:invalid`           | Invalid input       | `input:invalid { border: red; }`           |
| `:read-only`         | Read-only input     | `input:read-only { background: #eee; }`    |
| `:read-write`        | Editable input      | `input:read-write { background: white; }`  |
| `:placeholder-shown` | Placeholder visible | `input:placeholder-shown { color: gray; }` |

#### Position Based

| Pseudo-class         | Description   | Example                                   |
| -------------------- | ------------- | ----------------------------------------- |
| `:first-child`       | First child   | `p:first-child { color: red; }`           |
| `:last-child`        | Last child    | `p:last-child { color: blue; }`           |
| `:nth-child(n)`      | Nth child     | `li:nth-child(2) { color: green; }`       |
| `:nth-last-child(n)` | Nth from last | `li:nth-last-child(1) { color: orange; }` |
| `:only-child`        | Only child    | `p:only-child { font-weight: bold; }`     |
| `:first-of-type`     | First of type | `p:first-of-type { color: red; }`         |
| `:last-of-type`      | Last of type  | `p:last-of-type { color: blue; }`         |
| `:nth-of-type(n)`    | Nth of type   | `p:nth-of-type(2) { color: green; }`      |
| `:only-of-type`      | Only of type  | `p:only-of-type { color: purple; }`       |

#### Logic

| Pseudo-class | Description       | Example                               |
| ------------ | ----------------- | ------------------------------------- |
| `:not()`     | Excludes selector | `p:not(.active) { color: gray; }`     |
| `:empty`     | No content        | `div:empty { display: none; }`        |
| `:root`      | Root element      | `:root { --main: blue; }`             |
| `:target`    | URL target        | `#box:target { background: yellow; }` |
| `:lang()`    | Language match    | `p:lang(en) { color: green; }`        |

### Pseudo-Elements

| Pseudo-element           | Description       | Example                                             |
| ------------------------ | ----------------- | --------------------------------------------------- |
| `::before`               | Content before    | `p::before { content: "→ "; }`                      |
| `::after`                | Content after     | `p::after { content: "!"; }`                        |
| `::first-letter`         | First letter      | `p::first-letter { font-size: 2em; }`               |
| `::first-line`           | First line        | `p::first-line { color: blue; }`                    |
| `::selection`            | Selected text     | `::selection { background: yellow; }`               |
| `::placeholder`          | Placeholder text  | `input::placeholder { color: gray; }`               |
| `::marker`               | List marker       | `li::marker { color: red; }`                        |
| `::file-selector-button` | File input button | `input::file-selector-button { background: blue; }` |


## box-sizing

### content-box

w,h = content w/h

```css
.box {
  box-sizing: content-box;
}
```

### border-box

w,h = content w/h + padding w/h + border w/h

```css
.box {
  box-sizing: border-box;
}
```
 

## display

display : inner outer;

- inner =  defines the type of formatting context that its contents are laid out in (assuming it is a non-replaced element).

- - flow = default layout behavior of elements in CSS.

- - table = These elements behave like HTML `<table>` elements.
```html
<div class="table">
  <div class="row">
    <div class="cell">A</div>
    <div class="cell">B</div>
  </div>
</div>
```
```css
.table {
  display: table;
  width: 100%;
}
.row {
  display: table-row;
}
.cell {
  display: table-cell;
  border: 1px solid black;
}
```
- - flex = creates a flex formatting context, optimized for one-dimensional layouts.
| Axis       | Description             |
| ---------- | ----------------------- |
| Main axis  | Direction items flow    |
| Cross axis | Perpendicular direction |

- - grid = creates a grid formatting context, designed for two-dimensional layouts (rows and columns).

 
- outer = These keywords specify the element's outer display type

- - block = The element generates a block box, generating line breaks both before and after the element when in the normal flow.

- - inline = The element generates one or more inline boxes that do not generate line breaks before or after themselves. In normal flow, the next element will be on the same line if there is space.

## flexbox

### flex-direction 
- Main axis
- values :
- - row
- - row-reverse
- - column
- - column-reverse

### flex-wrap
- - nowrap = The flex items are laid out in a single line which may cause the flex container to overflow.
- - wrap = The flex items break into multiple lines.
- - wrap-reverse = Behaves the same as wrap, but cross-start and cross-end are inverted.

### flex-flow
- flex-direction + flex-wrap
- flex-direction : flex-direction flex-wrap

### flex-grow
- flex-grow defines how much a flex item can grow relative to other items when there is free space in the container.
```css
.item {
  flex-grow: 1;
}
```

### flex-shrink
- flex-shrink defines how much a flex item can shrink relative to others when there is not enough space.
```css
.item {
  flex-shrink: 1;
}
```

| Property      | Handles     | Default |
| ------------- | ----------- | ------- |
| `flex-grow`   | Extra space | `0`     |
| `flex-shrink` | Overflow    | `1`     |

- They never work at the same time.

## Alignment in flexbox

### cross-axis
- `align-items` = align the item on the `cross axis`
- `align-self` 
- - The align-items property sets the align-self property on all of the flex items as a group.
- - This means you can explicitly declare the align-self property to target a single item. 
- `align-content`
- - When flex items are allowed to wrap across multiple lines, the align-content property can be used to control the distribution of space between the lines, also known as packing flex lines.

### main-axis
- `justify-content` = align the item on the `main axis`


| Value              | What it does                          | Detailed explanation                                                                                                                                      | Typical use case                        |
| ------------------ | ------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------- |
| **stretch**        | Stretches items to fill cross-axis    | Default value. Items stretch to fill the container’s cross size **unless they have an explicit size** (`height` in row layout, `width` in column layout). | Equal-height columns, full-height cards |
| **flex-start**     | Aligns items to start of cross-axis   | Items are aligned to the **start edge of the flex container** according to the flex direction. Uses the **flexbox axis**, not writing mode.               | Top-aligned rows, left-aligned columns  |
| **flex-end**       | Aligns items to end of cross-axis     | Items align to the **end edge of the cross-axis**, based on flexbox flow.                                                                                 | Bottom-aligned content                  |
| **start**          | Aligns items to start of writing mode | Similar to `flex-start`, but respects **writing mode & text direction** (LTR, RTL, vertical text).                                                        | Internationalized layouts               |
| **end**            | Aligns items to end of writing mode   | Like `flex-end`, but depends on **writing mode**, not flex direction.                                                                                     | Multilingual designs                    |
| **center**         | Centers items on cross-axis           | Items are centered between cross-axis edges.                                                                                                              | Centering vertically or horizontally    |
| **baseline**       | Aligns items by their text baselines  | Items line up based on their **first text baseline** instead of edges. Font size differences remain visible.                                              | Text alignment in navbars               |
| **first baseline** | Aligns items using first baseline     | Explicit version of `baseline`. Uses the **first baseline** of each item.                                                                                 | Precise typographic alignment           |
| **last baseline**  | Aligns items using last baseline      | Items align using the **last baseline** (useful for multi-line text).                                                                                     | Complex text layouts                    |


## gaps in flexbox

- gap = sets the gaps between rows and columns.
- column-gap = gap between an element's columns.
- row-gap = gap between an element's rows.


## grid



<!-- ### 

## functions

### 1. calc()

- basic math

```css
.box {
  width: calc(90% - 30px);
}
```

### 2. rotate() -->




