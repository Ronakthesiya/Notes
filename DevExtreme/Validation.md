## validation

| # | Concept          | Description                     | Example                  |
| - | ---------------- | ------------------------------- | ------------------------ |
| 1 | Validator        | Used to validate input fields   | `dxValidator()`          |
| 2 | validationRules  | Array of rules applied to field | `[{ type: "required" }]` |
| 3 | validationGroup  | Groups multiple validators      | `"userForm"`             |
| 4 | validationEngine | Global validation handler       | `validateGroup()`        |
| 5 | isValid          | Validation result               | `true / false`           |


## validation rule

| # | Rule Type    | Description             | Key Properties                 | Example                   |
| - | ------------ | ----------------------- | ------------------------------ | ------------------------- |
| 1 | required     | Field must not be empty | —                              | `{ type: "required" }`    |
| 2 | email        | Valid email format      | —                              | `{ type: "email" }`       |
| 3 | stringLength | Limit text length       | `min, max`                     | `{ min: 5 }`              |
| 4 | range        | Numeric range           | `min, max`                     | `{ min: 18, max: 60 }`    |
| 5 | numeric      | Only numbers allowed    | —                              | `{ type: "numeric" }`     |
| 6 | pattern      | Regex validation        | `pattern`                      | `{ pattern: "^[A-Z]+$" }` |
| 7 | compare      | Compare two values      | `comparisonTarget`             | Password match            |
| 8 | custom       | Custom logic            | `validationCallback`           | `(e)=>true`               |
| 9 | async        | Server/API validation   | `validationCallback` (Promise) | Username check            |


## validator options

| # | Option          | Type     | Description                  | Example               |
| - | --------------- | -------- | ---------------------------- | --------------------- |
| 1 | validationRules | array    | List of rules                | `[{type:"required"}]` |
| 2 | validationGroup | string   | Group name                   | `"form1"`             |
| 3 | name            | string   | Field name (used in summary) | `"Email"`             |
| 4 | adapter         | object   | Custom validation logic      | custom value          |
| 5 | onValidated     | function | Event after validation       | `(e)=>{}`             |


## validation event

| # | Event       | Description            | Example                       |
| - | ----------- | ---------------------- | ----------------------------- |
| 1 | onValidated | Fires after validation | `(e)=>console.log(e.isValid)` |


## Validation Group

| # | Concept           | Description          | Example                 |
| - | ----------------- | -------------------- | ----------------------- |
| 1 | dxValidationGroup | Creates group        | `{ name: "form" }`      |
| 2 | validateGroup()   | Validates all fields | `validateGroup("form")` |
| 3 | result.isValid    | Final result         | `true/false`            |


## Validation Summary

| # | Option              | Description      | Example                 |
| - | ------------------- | ---------------- | ----------------------- |
| 1 | dxValidationSummary | Shows all errors | `dxValidationSummary()` |
| 2 | validationGroup     | Link to group    | `"form"`                |


## Validation Flow

| Step | Action               | Result                 |
| ---- | -------------------- | ---------------------- |
| 1    | User enters value    | Input captured         |
| 2    | Validator runs rules | Checks conditions      |
| 3    | Error message shown  | If invalid             |
| 4    | Result returned      | `isValid = true/false` |
| 5    | Group validation     | All fields checked     |

## Sync vs Async Validation

| Type  | Description           | Example         |
| ----- | --------------------- | --------------- |
| Sync  | Instant validation    | required, email |
| Async | API/server validation | username check  |

