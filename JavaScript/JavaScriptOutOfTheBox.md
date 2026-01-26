## Document.parseHTML() || Document.parseHTMLUnsafe()

- static method of the Document object is used to parse HTML input
- parseHTML is not working now(20/1/2026).
- parseHTMLUnsafe is used for that

```js
let str = "<div class='container' id='1'>1</div>"
const dom = Document.parseHTMLUnsafe(str);

let container = dom.getElementById("1");

console.log(container); // <div class='container' id='1'>1</div>
```

## 



