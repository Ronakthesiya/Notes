# MySQL Documentation: Cursor

## Table of Contents
1. [Introduction](#Cursor)
2. [Steps for Cursor](#Steps)
3. [Example](#example);

---
## Cursor

In MySQL, a cursor is a database object used for iterating the result of a SELECT statement.

Typically, you use cursors within stored procedures, triggers, and functions where you need to process individual rows returned by a query one at a time.

---
## Steps

### 1. Declare Variables

```sql
DECLARE finished INT DEFAULT 0;
DECLARE var_column1 VARCHAR(255);
DECLARE var_column2 INT;
```

### 2. Declare a Cursor

```sql
DECLARE cursor_name CURSOR FOR
SELECT column1, column2 FROM your_table WHERE condition;
```

### 3. Declare a NOT FOUND Handler

```sql
DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
```

### 4. Open the Cursor

```sql
OPEN cursor_name;
```

### 5. Fetch Data

```sql
read_loop: LOOP
    FETCH cursor_name INTO var_column1, var_column2;
    IF finished = 1 THEN
        LEAVE read_loop;
    END IF;
    -- Perform operations with var_column1, var_column2
END LOOP;
```

### 6. Close the Cursor

```sql
CLOSE cursor_name;
```

---
## Example

```sql
DELIMITER //

CREATE PROCEDURE process_employees()
BEGIN
    DECLARE finished INT DEFAULT 0;
    DECLARE emp_id INT;
    DECLARE emp_name VARCHAR(255);

    -- Declare cursor for employees
    DECLARE emp_cursor CURSOR FOR
    SELECT id, name FROM employees WHERE department = 'Sales';

    -- Declare NOT FOUND handler
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;

    OPEN emp_cursor;

    read_loop: LOOP
        FETCH emp_cursor INTO emp_id, emp_name;
        IF finished = 1 THEN
            LEAVE read_loop;
        END IF;
        -- Example: Print employee details
        SELECT CONCAT('Employee ID: ', emp_id, ', Name: ', emp_name);
    END LOOP;

    CLOSE emp_cursor;
END //

DELIMITER ;
```