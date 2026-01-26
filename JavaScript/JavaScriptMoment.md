## Moment JS

- a javascript library for date and time.

| **Method**                    | **Description**                                                                                   | **Example**                                          |
| ----------------------------- | ------------------------------------------------------------------------------------------------- | ---------------------------------------------------- |
| **`moment()`**                | Creates a new moment object with the current date and time.                                       | `let now = moment();`                                |
| **`moment(date)`**            | Parses a date string or JavaScript Date object into a moment object.                              | `let date = moment('2026-01-01');`                   |
| **`moment.utc()`**            | Creates a new moment object in UTC (Coordinated Universal Time).                                  | `let utcDate = moment.utc('2026-01-01');`            |
| **`format()`**                | Formats the moment object into a string according to a specified format.                          | `console.log(moment().format('YYYY-MM-DD'));`        |
| **`add(amount, unit)`**       | Adds a time unit (e.g., days, months, years) to the moment object.                                | `moment().add(7, 'days');`                           |
| **`subtract(amount, unit)`**  | Subtracts a time unit from the moment object.                                                     | `moment().subtract(1, 'month');`                     |
| **`startOf(unit)`**           | Sets the moment to the start of the given unit (e.g., start of the month, start of the year).     | `moment().startOf('month');`                         |
| **`endOf(unit)`**             | Sets the moment to the end of the given unit (e.g., end of the month, end of the year).           | `moment().endOf('month');`                           |
| **`year()`**                  | Gets or sets the year of the moment object.                                                       | `moment().year();`                                   |
| **`month()`**                 | Gets or sets the month of the moment object (0-based index).                                      | `moment().month();`                                  |
| **`date()`**                  | Gets or sets the day of the month of the moment object.                                           | `moment().date();`                                   |
| **`day()`**                   | Gets or sets the day of the week (0 = Sunday, 6 = Saturday).                                      | `moment().day();`                                    |
| **`hour()`**                  | Gets or sets the hour of the moment object (0-23).                                                | `moment().hour();`                                   |
| **`minute()`**                | Gets or sets the minute of the moment object (0-59).                                              | `moment().minute();`                                 |
| **`second()`**                | Gets or sets the second of the moment object (0-59).                                              | `moment().second();`                                 |
| **`isBefore(otherMoment)`**   | Checks if the moment is before another moment.                                                    | `moment().isBefore('2026-01-01');`                   |
| **`isAfter(otherMoment)`**    | Checks if the moment is after another moment.                                                     | `moment().isAfter('2025-12-31');`                    |
| **`isSame(otherMoment)`**     | Checks if the moment is the same as another moment.                                               | `moment().isSame('2026-01-01');`                     |
| **`isBetween(start, end)`**   | Checks if the moment is between two other moments.                                                | `moment().isBetween('2025-12-01', '2026-02-01');`    |
| **`fromNow()`**               | Returns the time relative to the current time, in a human-readable format (e.g., "2 days ago").   | `moment().subtract(2, 'days').fromNow();`            |
| **`from(moment)`**            | Returns the time relative to the provided moment.                                                 | `moment().from('2026-01-01');`                       |
| **`calendar()`**              | Returns the date in a human-readable format like "today at 6:00 PM", "Tomorrow at 12:00 AM", etc. | `moment().calendar();`                               |
| **`clone()`**                 | Creates a copy of the current moment object.                                                      | `let newDate = moment().clone();`                    |
| **`parseZone()`**             | Parses a date string and keeps the original time zone offset.                                     | `moment.parseZone('2026-01-01T12:00:00-05:00');`     |
| **`tz()`**                    | Creates a moment object in a specific time zone (using Moment Timezone).                          | `moment.tz('2026-01-01 12:00', 'America/New_York');` |
| **`locale()`**                | Sets or gets the current locale (language setting).                                               | `moment.locale('fr');`                               |
| **`localeData()`**            | Gets information about the locale’s formatting and units.                                         | `moment().localeData().months();`                    |
| **`isLeapYear()`**            | Checks if the current year is a leap year.                                                        | `moment().isLeapYear();`                             |
| **`diff(otherMoment, unit)`** | Returns the difference between two moments in a specified time unit (e.g., days, months, years).  | `moment().diff('2025-12-31', 'days');`               |
| **`unix()`**                  | Returns the moment in Unix timestamp (milliseconds since 1970).                                   | `moment().unix();`                                   |
| **`toDate()`**                | Converts the moment object to a native JavaScript `Date` object.                                  | `moment().toDate();`                                 |
| **`toISOString()`**           | Converts the moment object to an ISO 8601 string.                                                 | `moment().toISOString();`                            |
| **`isValid()`**               | Checks if the moment object is valid (i.e., if the date is properly parsed).                      | `moment('invalid-date').isValid();`                  |

### Summary

| **Category**      | **Methods**                                                                               |
| ----------------- | ----------------------------------------------------------------------------------------- |
| **Creation**      | `moment()`, `moment(date)`, `moment.utc()`, `moment.tz()`                                 |
| **Formatting**    | `format()`                                                                                |
| **Manipulation**  | `add()`, `subtract()`, `startOf()`, `endOf()`                                             |
| **Getting Parts** | `year()`, `month()`, `date()`, `day()`, `hour()`, `minute()`, `second()`                  |
| **Comparison**    | `isBefore()`, `isAfter()`, `isSame()`, `isBetween()`                                      |
| **Relative Time** | `fromNow()`, `from()`, `calendar()`                                                       |
| **Utility**       | `clone()`, `parseZone()`, `tz()`, `locale()`, `localeData()`, `isLeapYear()`, `isValid()` |
| **Unix and ISO**  | `unix()`, `toDate()`, `toISOString()`                                                     |
