# MySQL Documentation: Trigger

## Table of Contents
1. [Create Trigger](#create_trigger)
2. [Drop Trigger](#drop_trigger)
3. [BEFORE INSERT Trigger](#before_insert_trigger)
4. [Multiple Triggers](#multiple_trigger)
5. [Call a Stored Procedure From a Triggers](#call_sp_from_trigger)
6. [SHOW TRIGGERS](#show_trigger)

---
## Create_Trigger

#### Syntax

```sql
CREATE TRIGGER trigger_name
{BEFORE | AFTER} {INSERT | UPDATE | DELETE}
ON table_name
FOR EACH ROW
BEGIN
    -- Trigger body (SQL statements)
END;
```

In this syntax:

1. trigger_name: Name of the trigger.
2. BEFORE or AFTER: Specifies when the trigger should be executed.
3. INSERT, UPDATE, or DELETE: Specifies the type of operation that activates the trigger.
4. table_name: Name of the table on which the trigger is defined.
5. FOR EACH ROW: Indicates that the trigger should be executed once for each row affected by the triggering event.
6. BEGIN and END: Delimit the trigger body, where you define the SQL statements to be executed.

- To distinguish between the value of the columns BEFORE and AFTER the event has fired, you use the NEW and OLD modifiers.

- For example, if you update the value in the description column, in the trigger body, you can access the value of the description column before the update OLD.description and the new value NEW.description.

![alt text](image.png)

```sql
CREATE TRIGGER update_items_trigger
AFTER UPDATE
ON items
FOR EACH ROW
BEGIN
    INSERT INTO item_changes (item_id, change_type)
    VALUES (NEW.id, 'UPDATE');
END;

```

---
## Drop_Trigger

#### Syntax

```sql
DROP TRIGGER [IF EXISTS] [schema_name.]trigger_name;

```

In this syntax:
- First, specify the name of the trigger that you want to drop after the DROP TRIGGER keywords.
- Second, specify the name of the schema to which the trigger belongs. If you skip the schema name, the statement will drop the trigger in the current database.
- Third, use IF EXISTS option to conditionally drop the trigger if the trigger exists. The IF EXISTS clause is optional.

- The DROP TRIGGER requires the TRIGGER privilege for the table associated with the trigger.

- Note that if you drop a table, MySQL will automatically drop all triggers associated with the table.

---
## Before_Insert_Trigger

```sql
DELIMITER $$

CREATE TRIGGER trigger_name
    BEFORE INSERT
    ON table_name FOR EACH ROW
BEGIN
    -- statements
END$$    

DELIMITER ;

```

Example : 

```sql
DELIMITER $$

CREATE TRIGGER before_workcenters_insert
BEFORE INSERT
ON WorkCenters FOR EACH ROW
BEGIN
    DECLARE rowcount INT;
    
    SELECT COUNT(*) 
    INTO rowcount
    FROM WorkCenterStats;
    
    IF rowcount > 0 THEN
        UPDATE WorkCenterStats
        SET totalCapacity = totalCapacity + new.capacity;
    ELSE
        INSERT INTO WorkCenterStats(totalCapacity)
        VALUES(new.capacity);
    END IF; 

END $$

DELIMITER ;

```

---

## Multiple_Trigger

Syntax :

```sql

CREATE TRIGGER trigger_name
{BEFORE|AFTER}{INSERT|UPDATE|DELETE} 
ON table_name FOR EACH ROW 
{FOLLOWS|PRECEDES} existing_trigger_name
BEGIN
    -- statements
END

```

In this syntax, the FOLLOWS or PRECEDES specifies whether the new trigger should be invoked before or after an existing trigger.

- The FOLLOWS allows the new trigger to activate after an existing trigger.
- The PRECEDES allows the new trigger to activate before an existing trigger.

Example : 

```sql
CREATE TRIGGER before_products_update_log_user
   BEFORE UPDATE ON products 
   FOR EACH ROW 
   FOLLOWS before_products_update
BEGIN
    IF OLD.msrp <> NEW.msrp THEN
	INSERT INTO 
            UserChangeLogs(productCode,updatedBy)
        VALUES
            (OLD.productCode,USER());
    END IF;
END
```

---

## Call_SP_From_Trigger

```sql

CREATE PROCEDURE CheckWithdrawal(
    fromAccountId INT,
    withdrawAmount DEC(10,2)
)
BEGIN
    DECLARE balance DEC(10,2);
    DECLARE withdrawableAmount DEC(10,2);
    DECLARE message VARCHAR(255);

    SELECT amount 
    INTO balance
    FROM accounts
    WHERE accountId = fromAccountId;

    SET withdrawableAmount = balance - 25;

    IF withdrawAmount > withdrawableAmount THEN
        SET message = CONCAT('Insufficient amount, the maximum withdrawable is ', withdrawableAmount);
        SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = message;
    END IF;
END

```


```sql

CREATE TRIGGER before_accounts_update
BEFORE UPDATE
ON accounts FOR EACH ROW
BEGIN
    CALL CheckWithdrawal (
        OLD.accountId, 
        OLD.amount - NEW.amount
    );
END

```

---

## Show_Trigger

Syntax :

```sql
SHOW TRIGGERS
[{FROM | IN} database_name]
[LIKE 'pattern' | WHERE search_condition];

```

1. The following example uses the SHOW TRIGGERS statement to get all the triggers in all databases in the current MySQL Server:

```sql
SHOW TRIGGERS;

```

2. The following example shows all triggers in the classicmodels database:

```sql
SHOW TRIGGERS
FROM classicmodels;

```

3. The following statement list all the triggers associated with the employees table:

```sql
SHOW TRIGGERS
FROM classicmodels
WHERE table = 'employees';
```

4. To list triggers according to a pattern, you use the LIKE clause:

```sql
SHOW TRIGGERS 
LIKE 'pattern';

SHOW TRIGGERS 
FROM database_name
LIKE 'pattern';

```
