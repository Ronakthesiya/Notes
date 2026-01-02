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



### 

## functions

### 1. calc()

- basic math

```css
.box {
  width: calc(90% - 30px);
}
```

### 2. rotate()




