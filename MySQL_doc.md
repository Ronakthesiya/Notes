# MySQL Documentation: From Beginner to Advanced

## Table of Contents
0. [Notes](#notes)
1. [DDL (Data Definition Language)](#ddl-data-definition-language)
2. [DML (Data Manipulation Language)](#dml-data-manipulation-language)
3. [DQL (Data Query Language)](#dql-data-query-language)
4. [Aggregate Functions](#aggregate-functions)
5. [JOINs](#joins)

---
## Notes

### Constraints

#### NOT NULL
```sql
CREATE TABLE temp (
    col1 INT NOT NULL
);
```

#### UNIQUE
```sql
CREATE TABLE temp (
    col1 INT UNIQUE
);
```

#### PRIMARY KEY
```sql
CREATE TABLE temp (
    col1 INT PRIMARY KEY
    -- OR
    PRIMARY KEY (col1, col2, ...)
);
```

#### FOREIGN KEY
```sql
CREATE TABLE temp (
    col1 INT,
    FOREIGN KEY (col1) REFERENCES temp2(col2)
);
```

#### DEFAULT
```sql
CREATE TABLE temp (
    col1 INT DEFAULT 123
);
```

#### CHECK
```sql
CREATE TABLE temp (
    col1 INT CHECK (col1 >= 18)
    -- OR
    CONSTRAINT col1_check CHECK (col1 >= 18 AND col1 <= 100)
);
```
---
### OPERATORS

Arithmetic : +,-,*,/,%
Comparison : =, !=, >, >=, <, <=
Logical : AND, OR, NOT, IN, BETWEEN, ALL, LIKE, ANY
Bitwise : &, |

---
### Limit Clause
```sql
-- first 3 rows
SELECT * FROM table LIMIT 3;
```

---
### Order By Clause
```sql
SELECT * FROM table
Order by col1;

SELECT * FROM table
Order by col1 DESC;
```

---
### Aggregate Functions
COUNT(), MAX(), MIN(), SUM(), AVG() 

---
### Cascading for FK
#### On Delete/Update Cascade :
referencing rows are updated/deleted in the child table when the referenced row is updated/deleted in the parent table which has a primary key.

```sql
CREATE TABLE temp(
    col1 INT,
    FOREIGN KEY (col1) REFERENCES temp2(col2)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
```

---

### ALTER Table
```sql
ALTER TABLE table_name

ADD COLUMN col_name datatype constraint
DROP COLUMN col_name
RENAME TO new_tbl_name
CHANGE COLUMN old_name new_name new_datatype new_constraint
MODIFY col_name new_datatype new_constraint

```

### FIELD(value, val1, val2, val3...)
value : The value for which you want to find position
val1, val2,... : A list of values against which you want to compare the specified value.

```sql
SELECT FIELD('A', 'A', 'B','C');

// output 
+--------------------------+
| FIELD('A', 'A', 'B','C') |
+--------------------------+
|                        1 |
+--------------------------+
1 row in set (0.00 sec)
```

FIELD with ORDER BY

```sql
SELECT 
  orderNumber, 
  status 
FROM 
  orders 
ORDER BY 
  FIELD(
    status, 
    'In Process', 
    'On Hold', 
    'Cancelled', 
    'Resolved', 
    'Disputed', 
    'Shipped'
  );


// output
+-------------+------------+
| orderNumber | status     |
+-------------+------------+
|       10425 | In Process |
|       10421 | In Process |
|       10422 | In Process |
|       10420 | In Process |
|       10424 | In Process |
|       10423 | In Process |
|       10414 | On Hold    |
|       10401 | On Hold    |
|       10334 | On Hold    |
|       10407 | On Hold    |

```





---

## DDL (Data Definition Language)

DDL commands are used to define and modify database structure.

### CREATE - Creating Database Objects

#### Beginner Level

```sql
-- Create Database
CREATE DATABASE company_db;
USE company_db;

-- Basic Table Creation
CREATE TABLE employees (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    age INT,
    salary DECIMAL(10,2)
);

-- Create Table with AUTO_INCREMENT
CREATE TABLE departments (
    dept_id INT AUTO_INCREMENT PRIMARY KEY,
    dept_name VARCHAR(50) NOT NULL,
    location VARCHAR(100)
);
```

#### Intermediate Level

```sql
-- Table with Constraints
CREATE TABLE employees_advanced (
    emp_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,
    phone VARCHAR(15),
    hire_date DATE DEFAULT (CURRENT_DATE),
    salary DECIMAL(10,2) CHECK (salary > 0),
    dept_id INT,
    manager_id INT,
    FOREIGN KEY (dept_id) REFERENCES departments(dept_id),
    FOREIGN KEY (manager_id) REFERENCES employees_advanced(emp_id)
);

-- Create Index
CREATE INDEX idx_employee_name ON employees_advanced(last_name, first_name);
CREATE UNIQUE INDEX idx_employee_email ON employees_advanced(email);
```

#### Advanced Level

```sql
-- Partitioned Table
CREATE TABLE sales_data (
    id INT AUTO_INCREMENT,
    sale_date DATE,
    amount DECIMAL(10,2),
    region VARCHAR(50),
    PRIMARY KEY (id, sale_date)
) PARTITION BY RANGE (YEAR(sale_date)) (
    PARTITION p2020 VALUES LESS THAN (2021),
    PARTITION p2021 VALUES LESS THAN (2022),
    PARTITION p2022 VALUES LESS THAN (2023),
    PARTITION p_future VALUES LESS THAN MAXVALUE
);

-- Create View
CREATE VIEW employee_summary AS
SELECT 
    e.emp_id,
    CONCAT(e.first_name, ' ', e.last_name) AS full_name,
    d.dept_name,
    e.salary,
    CASE 
        WHEN e.salary > 80000 THEN 'High'
        WHEN e.salary > 50000 THEN 'Medium'
        ELSE 'Low'
    END AS salary_grade
FROM employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id;

-- Create Stored Procedure
DELIMITER //
CREATE PROCEDURE GetEmployeesByDepartment(IN dept_name VARCHAR(50))
BEGIN
    SELECT e.*, d.dept_name 
    FROM employees_advanced e
    JOIN departments d ON e.dept_id = d.dept_id
    WHERE d.dept_name = dept_name;
END //
DELIMITER ;
```

### ALTER - Modifying Database Objects

#### Beginner Level

```sql
-- Add Column
ALTER TABLE employees ADD COLUMN department VARCHAR(50);

-- Modify Column
ALTER TABLE employees MODIFY COLUMN name VARCHAR(100);

-- Drop Column
ALTER TABLE employees DROP COLUMN age;
```

#### Intermediate Level

```sql
-- Add Foreign Key
ALTER TABLE employees_advanced 
ADD CONSTRAINT fk_dept 
FOREIGN KEY (dept_id) REFERENCES departments(dept_id);

-- Add Check Constraint
ALTER TABLE employees_advanced 
ADD CONSTRAINT chk_salary CHECK (salary BETWEEN 20000 AND 200000);

-- Rename Table
ALTER TABLE employees RENAME TO staff;
```

#### Advanced Level

```sql
-- Add Partition
ALTER TABLE sales_data 
ADD PARTITION (PARTITION p2024 VALUES LESS THAN (2025));

-- Modify Table Engine
ALTER TABLE employees_advanced ENGINE = InnoDB;

-- Add Generated Column
ALTER TABLE employees_advanced 
ADD COLUMN full_name VARCHAR(101) 
GENERATED ALWAYS AS (CONCAT(first_name, ' ', last_name)) STORED;
```

### DROP - Removing Database Objects

```sql
-- Drop Table
DROP TABLE IF EXISTS temp_table;

-- Drop Database
DROP DATABASE IF EXISTS old_database;

-- Drop Index
DROP INDEX idx_employee_name ON employees_advanced;

-- Drop View
DROP VIEW IF EXISTS employee_summary;
```

---

## DML (Data Manipulation Language)

DML commands are used to manipulate data within tables.

### INSERT - Adding Data

#### Beginner Level

```sql
-- Basic Insert
INSERT INTO departments (dept_name, location) 
VALUES ('IT', 'New York');

-- Multiple Row Insert
INSERT INTO departments (dept_name, location) VALUES
('HR', 'Chicago'),
('Finance', 'Boston'),
('Marketing', 'Los Angeles');
```

#### Intermediate Level

```sql
-- Insert with SELECT
INSERT INTO employees_advanced (first_name, last_name, email, dept_id, salary)
SELECT 'John', 'Doe', 'john.doe@company.com', dept_id, 55000
FROM departments WHERE dept_name = 'IT';

-- Insert with ON DUPLICATE KEY UPDATE
INSERT INTO employees_advanced (emp_id, first_name, last_name, email, salary)
VALUES (1, 'Jane', 'Smith', 'jane.smith@company.com', 60000)
ON DUPLICATE KEY UPDATE 
    salary = VALUES(salary),
    email = VALUES(email);
```

#### Advanced Level

```sql
-- Insert with CTE
WITH new_employees AS (
    SELECT 'Alice' as fname, 'Johnson' as lname, 'alice@company.com' as email, 65000 as sal
    UNION ALL
    SELECT 'Bob', 'Wilson', 'bob@company.com', 58000
)
INSERT INTO employees_advanced (first_name, last_name, email, salary, dept_id)
SELECT fname, lname, email, sal, 
       (SELECT dept_id FROM departments WHERE dept_name = 'IT')
FROM new_employees;
```

### UPDATE - Modifying Data

#### Beginner Level

```sql
-- Basic Update
UPDATE employees_advanced 
SET salary = 65000 
WHERE emp_id = 1;

-- Update Multiple Columns
UPDATE employees_advanced 
SET salary = salary * 1.1, 
    email = 'new.email@company.com'
WHERE dept_id = 1;
```

#### Intermediate Level

```sql
-- Update with JOIN
UPDATE employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id
SET e.salary = e.salary * 1.15
WHERE d.dept_name = 'IT';

-- Conditional Update
UPDATE employees_advanced 
SET salary = CASE 
    WHEN salary < 50000 THEN salary * 1.2
    WHEN salary < 80000 THEN salary * 1.1
    ELSE salary * 1.05
END;
```

#### Advanced Level

```sql
-- Update with Subquery
UPDATE employees_advanced 
SET salary = (
    SELECT AVG(salary) * 1.1 
    FROM (SELECT salary FROM employees_advanced WHERE dept_id = employees_advanced.dept_id) AS dept_avg
)
WHERE emp_id IN (
    SELECT emp_id FROM (
        SELECT emp_id FROM employees_advanced 
        WHERE salary < (SELECT AVG(salary) FROM employees_advanced)
    ) AS low_earners
);
```

### DELETE - Removing Data

#### Beginner Level

```sql
-- Basic Delete
DELETE FROM employees_advanced WHERE emp_id = 1;

-- Delete with Condition
DELETE FROM employees_advanced WHERE salary < 30000;
```

#### Intermediate Level

```sql
-- Delete with JOIN
DELETE e FROM employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id
WHERE d.dept_name = 'Temp';

-- Delete with Subquery
DELETE FROM employees_advanced 
WHERE dept_id IN (
    SELECT dept_id FROM departments WHERE location = 'Closed Office'
);
```

---

## DQL (Data Query Language)

DQL is used to query and retrieve data from the database.

### SELECT - Basic Queries

#### Beginner Level

```sql
-- Basic SELECT
SELECT * FROM employees_advanced;

-- Select Specific Columns
SELECT first_name, last_name, salary FROM employees_advanced;

-- WHERE Clause
SELECT * FROM employees_advanced WHERE salary > 50000;

-- ORDER BY
SELECT * FROM employees_advanced ORDER BY salary DESC;

-- LIMIT
SELECT * FROM employees_advanced ORDER BY salary DESC LIMIT 5;
```

#### Intermediate Level

```sql
-- LIKE and Wildcards
SELECT * FROM employees_advanced WHERE first_name LIKE 'J%';

-- IN Operator
SELECT * FROM employees_advanced WHERE dept_id IN (1, 2, 3);

-- BETWEEN
SELECT * FROM employees_advanced WHERE salary BETWEEN 40000 AND 80000;

-- IS NULL / IS NOT NULL
SELECT * FROM employees_advanced WHERE manager_id IS NULL;

-- DISTINCT
SELECT DISTINCT dept_id FROM employees_advanced;

-- GROUP BY with HAVING
SELECT dept_id, COUNT(*) as employee_count, AVG(salary) as avg_salary
FROM employees_advanced 
GROUP BY dept_id
HAVING COUNT(*) > 2;
```

#### Advanced Level

```sql
-- Window Functions
SELECT 
    first_name, 
    last_name, 
    salary,
    ROW_NUMBER() OVER (PARTITION BY dept_id ORDER BY salary DESC) as rank_in_dept,
    LAG(salary) OVER (ORDER BY hire_date) as prev_hire_salary,
    LEAD(salary) OVER (ORDER BY hire_date) as next_hire_salary
FROM employees_advanced;

-- CTE (Common Table Expression)
WITH dept_stats AS (
    SELECT 
        dept_id,
        COUNT(*) as emp_count,
        AVG(salary) as avg_salary,
        MAX(salary) as max_salary
    FROM employees_advanced
    GROUP BY dept_id
),
high_paying_depts AS (
    SELECT dept_id FROM dept_stats WHERE avg_salary > 60000
)
SELECT e.*, ds.avg_salary as dept_avg_salary
FROM employees_advanced e
JOIN dept_stats ds ON e.dept_id = ds.dept_id
WHERE e.dept_id IN (SELECT dept_id FROM high_paying_depts);

-- Recursive CTE (Employee Hierarchy)
WITH RECURSIVE employee_hierarchy AS (
    -- Base case: top-level managers
    SELECT emp_id, first_name, last_name, manager_id, 0 as level
    FROM employees_advanced 
    WHERE manager_id IS NULL
    
    UNION ALL
    
    -- Recursive case: employees with managers
    SELECT e.emp_id, e.first_name, e.last_name, e.manager_id, eh.level + 1
    FROM employees_advanced e
    JOIN employee_hierarchy eh ON e.manager_id = eh.emp_id
)
SELECT * FROM employee_hierarchy ORDER BY level, last_name;
```

---

## Aggregate Functions

Aggregate functions perform calculations on multiple rows and return a single result.

### Basic Aggregate Functions

#### Beginner Level

```sql
-- COUNT
SELECT COUNT(*) as total_employees FROM employees_advanced;
SELECT COUNT(manager_id) as employees_with_managers FROM employees_advanced;

-- SUM
SELECT SUM(salary) as total_payroll FROM employees_advanced;

-- AVG
SELECT AVG(salary) as average_salary FROM employees_advanced;

-- MIN and MAX
SELECT MIN(salary) as lowest_salary, MAX(salary) as highest_salary 
FROM employees_advanced;
```

#### Intermediate Level

```sql
-- GROUP BY with Aggregates
SELECT 
    dept_id,
    COUNT(*) as employee_count,
    AVG(salary) as avg_salary,
    MIN(salary) as min_salary,
    MAX(salary) as max_salary,
    SUM(salary) as total_dept_payroll
FROM employees_advanced 
GROUP BY dept_id;

-- HAVING Clause
SELECT dept_id, AVG(salary) as avg_salary
FROM employees_advanced 
GROUP BY dept_id
HAVING AVG(salary) > 55000;

-- Multiple Grouping
SELECT 
    dept_id,
    YEAR(hire_date) as hire_year,
    COUNT(*) as hires_count,
    AVG(salary) as avg_starting_salary
FROM employees_advanced 
GROUP BY dept_id, YEAR(hire_date)
ORDER BY dept_id, hire_year;
```

#### Advanced Level

```sql
-- GROUP BY with ROLLUP
SELECT 
    dept_id,
    YEAR(hire_date) as hire_year,
    COUNT(*) as employee_count,
    AVG(salary) as avg_salary
FROM employees_advanced 
GROUP BY dept_id, YEAR(hire_date) WITH ROLLUP;

-- Statistical Functions
SELECT 
    dept_id,
    COUNT(*) as count,
    AVG(salary) as mean_salary,
    STDDEV(salary) as salary_stddev,
    VARIANCE(salary) as salary_variance
FROM employees_advanced 
GROUP BY dept_id;

-- Conditional Aggregation
SELECT 
    dept_id,
    COUNT(*) as total_employees,
    COUNT(CASE WHEN salary > 60000 THEN 1 END) as high_earners,
    COUNT(CASE WHEN salary <= 60000 THEN 1 END) as regular_earners,
    AVG(CASE WHEN salary > 60000 THEN salary END) as avg_high_salary
FROM employees_advanced 
GROUP BY dept_id;
```

---

## JOINs

JOINs are used to combine rows from multiple tables based on related columns.

### Types of JOINs

#### Beginner Level

```sql
-- Sample Data Setup
INSERT INTO departments VALUES 
(1, 'IT', 'New York'),
(2, 'HR', 'Chicago'),
(3, 'Finance', 'Boston'),
(4, 'Marketing', 'Los Angeles');

INSERT INTO employees_advanced (first_name, last_name, email, dept_id, salary) VALUES
('John', 'Doe', 'john@company.com', 1, 65000),
('Jane', 'Smith', 'jane@company.com', 2, 55000),
('Bob', 'Johnson', 'bob@company.com', 1, 70000),
('Alice', 'Brown', 'alice@company.com', 3, 60000);

-- INNER JOIN
SELECT 
    e.first_name, 
    e.last_name, 
    d.dept_name, 
    e.salary
FROM employees_advanced e
INNER JOIN departments d ON e.dept_id = d.dept_id;

-- LEFT JOIN
SELECT 
    e.first_name, 
    e.last_name, 
    d.dept_name
FROM employees_advanced e
LEFT JOIN departments d ON e.dept_id = d.dept_id;

-- RIGHT JOIN
SELECT 
    e.first_name, 
    e.last_name, 
    d.dept_name
FROM employees_advanced e
RIGHT JOIN departments d ON e.dept_id = d.dept_id;
```

#### Intermediate Level

```sql
-- Multiple JOINs
CREATE TABLE projects (
    project_id INT AUTO_INCREMENT PRIMARY KEY,
    project_name VARCHAR(100),
    dept_id INT,
    budget DECIMAL(12,2),
    FOREIGN KEY (dept_id) REFERENCES departments(dept_id)
);

CREATE TABLE employee_projects (
    emp_id INT,
    project_id INT,
    role VARCHAR(50),
    hours_allocated INT,
    PRIMARY KEY (emp_id, project_id),
    FOREIGN KEY (emp_id) REFERENCES employees_advanced(emp_id),
    FOREIGN KEY (project_id) REFERENCES projects(project_id)
);

-- Three-way JOIN
SELECT 
    e.first_name,
    e.last_name,
    d.dept_name,
    p.project_name,
    ep.role,
    ep.hours_allocated
FROM employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id
JOIN employee_projects ep ON e.emp_id = ep.emp_id
JOIN projects p ON ep.project_id = p.project_id;

-- FULL OUTER JOIN (MySQL doesn't support FULL OUTER JOIN directly)
SELECT 
    e.first_name,
    e.last_name,
    d.dept_name
FROM employees_advanced e
LEFT JOIN departments d ON e.dept_id = d.dept_id
UNION
SELECT 
    e.first_name,
    e.last_name,
    d.dept_name
FROM employees_advanced e
RIGHT JOIN departments d ON e.dept_id = d.dept_id;
```

#### Advanced Level

```sql
-- Self JOIN (Employee-Manager Relationship)
SELECT 
    e.first_name as employee_name,
    e.last_name as employee_lastname,
    m.first_name as manager_name,
    m.last_name as manager_lastname
FROM employees_advanced e
LEFT JOIN employees_advanced m ON e.manager_id = m.emp_id;

-- Complex JOIN with Aggregation
SELECT 
    d.dept_name,
    COUNT(DISTINCT e.emp_id) as employee_count,
    COUNT(DISTINCT p.project_id) as project_count,
    AVG(e.salary) as avg_salary,
    SUM(p.budget) as total_budget
FROM departments d
LEFT JOIN employees_advanced e ON d.dept_id = e.dept_id
LEFT JOIN projects p ON d.dept_id = p.dept_id
GROUP BY d.dept_id, d.dept_name;

-- JOIN with Window Functions
SELECT 
    e.first_name,
    e.last_name,
    d.dept_name,
    e.salary,
    AVG(e.salary) OVER (PARTITION BY d.dept_id) as dept_avg_salary,
    RANK() OVER (PARTITION BY d.dept_id ORDER BY e.salary DESC) as salary_rank_in_dept
FROM employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id;

-- Conditional JOINs
SELECT 
    e1.first_name as emp1_name,
    e2.first_name as emp2_name,
    e1.salary,
    e2.salary
FROM employees_advanced e1
JOIN employees_advanced e2 ON e1.dept_id = e2.dept_id 
    AND e1.emp_id < e2.emp_id 
    AND ABS(e1.salary - e2.salary) < 5000;

-- EXISTS vs JOIN
-- Using EXISTS (often more efficient for checking existence)
SELECT e.first_name, e.last_name
FROM employees_advanced e
WHERE EXISTS (
    SELECT 1 FROM employee_projects ep 
    WHERE ep.emp_id = e.emp_id
);

-- Equivalent using JOIN
SELECT DISTINCT e.first_name, e.last_name
FROM employees_advanced e
JOIN employee_projects ep ON e.emp_id = ep.emp_id;
```

### Performance Tips for JOINs

```sql
-- Use proper indexing
CREATE INDEX idx_emp_dept ON employees_advanced(dept_id);
CREATE INDEX idx_proj_dept ON projects(dept_id);
CREATE INDEX idx_emp_proj_emp ON employee_projects(emp_id);
CREATE INDEX idx_emp_proj_proj ON employee_projects(project_id);

-- Analyze query performance
EXPLAIN SELECT 
    e.first_name, d.dept_name, p.project_name
FROM employees_advanced e
JOIN departments d ON e.dept_id = d.dept_id
JOIN employee_projects ep ON e.emp_id = ep.emp_id
JOIN projects p ON ep.project_id = p.project_id;
```

---

## Advanced Concepts and Best Practices

### Subqueries vs JOINs

```sql
-- Correlated Subquery
SELECT first_name, last_name, salary
FROM employees_advanced e1
WHERE salary > (
    SELECT AVG(salary) 
    FROM employees_advanced e2 
    WHERE e2.dept_id = e1.dept_id
);

-- Equivalent using Window Function (often more efficient)
SELECT first_name, last_name, salary
FROM (
    SELECT 
        first_name, 
        last_name, 
        salary,
        AVG(salary) OVER (PARTITION BY dept_id) as dept_avg
    FROM employees_advanced
) t
WHERE salary > dept_avg;
```

### Query Optimization Tips

```sql
-- Use LIMIT when appropriate
SELECT * FROM employees_advanced ORDER BY salary DESC LIMIT 10;

-- Use covering indexes
CREATE INDEX idx_covering ON employees_advanced(dept_id, salary, first_name, last_name);

-- Avoid SELECT * in production
SELECT emp_id, first_name, last_name FROM employees_advanced;

-- Use appropriate data types
-- DECIMAL for money, DATE for dates, VARCHAR with appropriate length
```

This documentation covers MySQL from beginner to advanced level, providing practical examples for each concept. Practice these queries with sample data to master MySQL database operations.