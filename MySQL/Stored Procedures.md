# MySQL Documentation: Stored Procedures

## Table of Contents
1. [Create SP](#create_sp)
2. [SP Parameters](#sp_parameters)
3. [Drop SP](#drop_sp)
4. [ALTER SP](#alter_sp)
5. [SP Variables](#Variables)
6. [List SP](#List_SP)


---
## Create_SP

#### Syntax

```sql
CREATE PROCEDURE [IF NOT EXISTS] sp_name(parameter_list)
BEGIN
   statements;
END;


CALL sp_name(argument_list);

```

- First, define the name of the stored procedure sp_name after the CREATE PROCEDURE keywords.
- Second, specify the parameter list (parameter_list) inside the parentheses followed by the stored procedure’s name. If the stored procedure has no parameters, you can use an empty parentheses ().
- Third, write the stored procedure body that consists of one or more valid SQL statements between the BEGIN and END block.


- First, provide the name of the stored procedure that you want to execute after the CALL keyword.
- Second, if the stored procedure has parameters, you need to pass the arguments to it in parentheses () after the stored procedure’s name.


---
## SP_Parameters

### IN parameters
IN is the default mode. When defining an IN parameter in a stored procedure, the calling program must pass an argument to the stored procedure.

Additionally, the value of an IN parameter is protected. This means that even if you change the value of the IN parameter inside the stored procedure, its original value remains unchanged after the stored procedure ends. In other words, the stored procedure works only on the copy of the IN parameter.

### OUT parameters
The value of an OUT parameter can be modified within the stored procedure, and its updated value is then passed back to the calling program.

- Note that stored procedures cannot access the initial value of the OUT parameter when they begin.

### INOUT parameters
An INOUT  parameter is a combination of IN and OUT parameters. This means that the calling program may pass the argument, and the stored procedure can modify the INOUT parameter and pass the new value back to the calling program.

### Syntax

```sql
[IN | OUT | INOUT] parameter_name datatype[(length)]

```

- First, specify the parameter mode, which can be IN , OUT or INOUT depending on the purpose of the parameter in the stored procedure.
- Second, provide the name of the parameter. The parameter name must follow the naming rules of the column name in MySQL.
- Third, define the data type and maximum length of the parameter.


### Example

#### IN parameter : 

```sql
CREATE PROCEDURE GetOfficeByCountry(
	IN countryName VARCHAR(255)
)
BEGIN
	SELECT * 
 	FROM offices
	WHERE country = countryName;
END 


CALL GetOfficeByCountry('USA');

```


#### OUT parameter : 

```sql
CREATE PROCEDURE GetOrderCountByStatus (
	IN  orderStatus VARCHAR(25),
	OUT total INT
)
BEGIN
	SELECT COUNT(orderNumber)
	INTO total
	FROM orders
	WHERE status = orderStatus;
END


CALL GetOrderCountByStatus('Shipped',@total);
SELECT @total;

```


#### INOUT parameter : 

```sql
CREATE PROCEDURE SetCounter(
	INOUT counter INT,
    IN inc INT
)
BEGIN
	SET counter = counter + inc;
END$$


SET @counter = 1;
CALL SetCounter(@counter,1); -- 2
CALL SetCounter(@counter,1); -- 3
CALL SetCounter(@counter,5); -- 8
SELECT @counter; -- 8

```

---
## Drop_SP

#### Syntax

```sql
DROP PROCEDURE [IF EXISTS] sp_name;

DROP PROCEDURE abc;
DROP PROCEDURE IF EXISTS abc;

```

- First, specify the name of the stored procedure (sp_name) that you want to delete after the DROP PROCEDURE keywords.
- Second, use IF EXISTS option to conditionally drop the stored procedure if it exists.


---
## Alter_SP

#### Syntax

```sql
ALTER PROCEDURE sp_name [characteristic ...]


characteristic: {
    COMMENT 'string'
  | LANGUAGE SQL
  | { CONTAINS SQL | NO SQL | READS SQL DATA | MODIFIES SQL DATA }
  | SQL SECURITY { DEFINER | INVOKER }
}

```

- First, specify the stored procedure name that you want to modify after the ALTER PROCEDURE keywords. Notice that you don’t use parentheses () after the stored procedure name (sp_name).
- Second, specify the characteristics you want to change after the stored procedure name.

- However, it’s important to note that the ALTER PROCEDURE statement does not support this. To implement such modifications, you need to:

1. First, drop the stored procedure using the DROP PROCEDURE statement.
2. Second, recreate the stored procedure using the CREATE PROCEDURE statement.


---
## Variables

#### Declare

```sql
DECLARE variable_name datatype(size) [DEFAULT default_value];

```

- First, specify the name of the variable after the DECLARE keyword. Ensure the variable name adheres to MySQL table column naming rules.
- Second, define the data type and length of the variable. Variables can have any MySQL data type, such as INT, VARCHAR , and DATETIME.
- Third, assign a default value to the variable using the DEFAULT option. If you declare a variable without specifying a default value, its default value is NULL.

#### SET

```sql
SET variable_name = value;

```

#### Example

```sql
DECLARE total INT DEFAULT 0;
SET total = 10;


DECLARE productCount INT DEFAULT 0;
SELECT COUNT(*) 
INTO productCount
FROM products;

```

#### Variable scopes

A variable has its own scope, which determines its lifetime. If you declare a variable inside a stored procedure, it will be out of scope when the END statement of the stored procedure is reached.

When you declare a variable inside the BEGIN...END block, it goes out of scope once the END is reached.

MySQL allows you to declare two or more variables that share the same name in different scopes because a variable is only effective within its scope.

However, declaring variables with the same name in different scopes is not considered good programming practice.

A variable whose name begins with the @ sign is a session variable, available and accessible until the session ends.


---
## List_SP


#### Syntax

```sql
SHOW PROCEDURE STATUS [LIKE 'pattern' | WHERE search_condition]

```
- The SHOW PROCEDURE STATUS statement shows all characteristics of stored procedures including stored procedure names. It returns stored procedures that you have the privilege to access.

#### Example

```sql
SHOW PROCEDURE STATUS WHERE db = 'classicmodels';

SHOW PROCEDURE STATUS LIKE '%Order%'

```