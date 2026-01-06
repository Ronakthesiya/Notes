## Container

| Container Class    | Extra small <576px | Small ≥576px | Medium ≥768px | Large ≥992px | X-Large ≥1200px | XX-Large ≥1400px |
| ------------------ | ------------------ | ------------ | ------------- | ------------ | --------------- | ---------------- |
| `.container`       | 100%               | 540px        | 720px         | 960px        | 1140px          | 1320px           |
| `.container-sm`    | 100%               | 540px        | 720px         | 960px        | 1140px          | 1320px           |
| `.container-md`    | 100%               | 100%         | 720px         | 960px        | 1140px          | 1320px           |
| `.container-lg`    | 100%               | 100%         | 100%          | 960px        | 1140px          | 1320px           |
| `.container-xl`    | 100%               | 100%         | 100%          | 100%         | 1140px          | 1320px           |
| `.container-xxl`   | 100%               | 100%         | 100%          | 100%         | 100%            | 1320px           |
| `.container-fluid` | 100%               | 100%         | 100%          | 100%         | 100%            | 100%             |


```html
<div class="container-sm">100% wide until small breakpoint</div>
<div class="container-md">100% wide until medium breakpoint</div>
<div class="container-lg">100% wide until large breakpoint</div>
<div class="container-xl">100% wide until extra large breakpoint</div>
<div class="container-xxl">100% wide until extra extra large breakpoint</div>
```

## grid

- 12 columns
- col and row classes

```html
<div class="container text-center">
  <div class="row">
    <div class="col">col</div>
    <div class="col">col</div>
    <div class="col">col</div>
    <div class="col">col</div>
  </div>
  <div class="row">
    <div class="col-8">col-8</div>
    <div class="col-4">col-4</div>
  </div>
</div>
```

| Breakpoint Name | Class Prefix | Screen Width |
| --------------- | ------------ | ------------ |
| Extra Small     | `.col-`      | `<576px`     |
| Small           | `.col-sm-`   | `≥576px`     |
| Medium          | `.col-md-`   | `≥768px`     |
| Large           | `.col-lg-`   | `≥992px`     |
| X-Large         | `.col-xl-`   | `≥1200px`    |
| XX-Large        | `.col-xxl-`  | `≥1400px`    |

| Class Example | Behavior                            |
| ------------- | ----------------------------------- |
| `.col-12`     | Full width on all screen sizes      |
| `.col-sm-6`   | Half width on small screens and up  |
| `.col-md-4`   | 4/12 width on medium screens and up |
| `.col-lg-3`   | 3/12 width on large screens and up  |


## Vertical Alignment

### align-items

| Class / Property       | Effect                                               |
| ---------------------- | ---------------------------------------------------- |
| `align-items-start`    | Align items to the **top** of the container          |
| `align-items-end`      | Align items to the **bottom** of the container       |
| `align-items-center`   | Align items to the **center (vertically)**           |
| `align-items-baseline` | Align items along the **text baseline**              |
| `align-items-stretch`  | Stretch items to **fill container height** (default) |

### align-self

| Class / Property      | Effect                               |
| --------------------- | ------------------------------------ |
| `align-self-start`    | Align this item to the **top**       |
| `align-self-end`      | Align this item to the **bottom**    |
| `align-self-center`   | Align this item to the **center**    |
| `align-self-baseline` | Align this item to the **baseline**  |
| `align-self-stretch`  | Stretch this item to **fill height** |

## Horizontal alignment

### justify-content

| Class / Property          | Effect                                           |
| ------------------------- | ------------------------------------------------ |
| `justify-content-start`   | Align items to the **start**                     |
| `justify-content-end`     | Align items to the **end**                       |
| `justify-content-center`  | Align items to the **center**                    |
| `justify-content-between` | Space items with **equal space between**         |
| `justify-content-around`  | Space items with **equal space around**          |
| `justify-content-evenly`  | Space items with **equal space between & edges** |

## Order 

- controls the visual order of flex items

| Class / Property | Order Value | Effect                               |
| ---------------- | ----------- | ------------------------------------ |
| `order-first`    | `-1`        | Moves item to the **first position** |
| `order-0`        | `0`         | Default order                        |
| `order-1`        | `1`         | Position after `order-0`             |
| `order-2`        | `2`         | Position after `order-1`             |
| `order-3`        | `3`         | Position after `order-2`             |
| `order-4`        | `4`         | Position after `order-3`             |
| `order-5`        | `5`         | Position after `order-4`             |
| `order-last`     | `6`         | Moves item to the **last position**  |


## offset

| Class       | Effect                               |
| ----------- | ------------------------------------ |
| `offset-n`  | Moves column right by **n(1 to 11) column**   |


## Gutters

- Gutters are the padding between your columns, used to responsively space and align content in the Bootstrap grid system.

| Class | Gutter Size           |
| ----- | --------------------- |
| `g-0` | No gutter (0 spacing) |
| `g-1` | `0.25rem`             |
| `g-2` | `0.5rem`              |
| `g-3` | `1rem` (default)      |
| `g-4` | `1.5rem`              |
| `g-5` | `3rem`                |

| Class  | Effect                           |
| ------ | -------------------------------- |
| `gx-*` | Horizontal gutter (left & right) |
| `gy-*` | Vertical gutter (top & bottom)   |


## Z-index

- n1, 0, 1, 2, 3
- --------------> increase level prority

## table

table, table-color, table-striped, table-striped-columns, table-hover, table-active, table-bordered, table-borderless, table-responsive

## display

