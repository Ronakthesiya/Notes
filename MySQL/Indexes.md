# MySQL Documentation: Index

## Table of Contents
1. [Introduction](#introduction)
2. [Create Index](#create_index)
3. [Show Index](#show_index)
4. [Drop Index](#drop_index)
5. [Prefix Index](#prefix_index)
6. [Unique Index](#unique_index)
7. [Invisible Index](#invisible_index)
8. [Descending Index](#descending_index)
9. [Functional Index](#functional_index)
10. [Index Cardinality](#index_cardinality)
11. [Use Index](#use_index)
12. [Force Index](#force_index)
---
## Introduction 

- An index is a data structure such as a B-Tree that improves the speed of data retrieval on a table at the cost of additional writes and storage to maintain it.

- The query optimizer may use indexes to quickly locate data without having to scan every row in a table for a given query.

- When you create a table with a primary key or unique key, MySQL automatically creates a special index named PRIMARY. This index is called the clustered index.

- The PRIMARY index is special because the index itself is stored together with the data in the same table. The clustered index enforces the order of rows in the table.

- Other indexes other than the PRIMARY index are called secondary indexes or non-clustered indexes.

---
## Create_index

#### Syntax

```sql
CREATE TABLE t(
   c1 INT PRIMARY KEY,
   c2 INT NOT NULL,
   c3 INT NOT NULL,
   c4 VARCHAR(10),
   INDEX (c2,c3) 
);


CREATE INDEX index_name 
ON table_name (column_list)
```

---
## Show_Index

```sql
SHOW INDEXES 
FROM tabel_name 
IN database_name;

```

---
## Drop_Index

#### Syntax

```sql
DROP INDEX index_name 
ON table_name

```

#### Example
```sql
DROP INDEX email ON leads

DROP INDEX `PRIMARY` ON table_name;

```

- Notice that the PRIMARY is a reversed word in MySQL. However, the index name is PRIMARY. Therefore, you need to place the PRIMARY inside the quotes to specify the primary index.

---

## Prefix_Index

- In case the columns are string columns, the index will consume a lot of disk space and potentially slow down the INSERT operations.

- To address this issue, MySQL allows you to create an index for the leading part of the column values of the string columns using the following syntax:

```sql
CREATE TABLE table_name(
    column_list,
    INDEX(column_name(length))
);


CREATE INDEX index_name
ON table_name(column_name(length));


CREATE INDEX idx_productname 
ON products(productName(20));
```


---

## Unique_Index

- To enforce the uniqueness value of one or more columns, you often use the PRIMARY KEY constraint. However, each table can have only one primary key. So if you want to have more than one column or a set of columns with unique values, you cannot use the primary key constraint.

- Luckily, MySQL provides another kind of index called UNIQUE index that allows you to enforce the uniqueness of values in one or more columns. Unlike the PRIMARY KEY index, you can have more than one UNIQUE index per table.

- To create a UNIQUE index, you use the CREATE UNIQUE INDEX statement as follows:

```sql
CREATE TABLE table_name(
    ...
   UNIQUE KEY(index_column_,index_column_2,...) 
);


CREATE UNIQUE INDEX index_name
ON table_name(index_column_1,index_column_2,...);


ALTER TABLE table_name
ADD CONSTRAINT constraint_name UNIQUE KEY(column_1,column_2,...);

```


---

## Invisible_Index

- The invisible indexes allow you to mark indexes as unavailable for the query optimizer. MySQL maintains the invisible indexes and keeps them up to date when the data in the columns associated with the indexes changes.

- By default, indexes are visible. To make them invisible, you have to explicitly declare its visibility at the time of creation, or by using the ALTER TABLE command. MySQL provides us with the VISIBLE and INVISIBLE keywords to maintain index visibility.

- To create an invisible index, you the following statement:

```sql
CREATE INDEX index_name
ON table_name( c1, c2, ...) INVISIBLE;


ALTER TABLE table_name
ALTER INDEX index_name [VISIBLE | INVISIBLE];
```

---
## Descending_Index

- A descending index is an index that stores key values in the descending order. Before MySQL 8.0, you can specify the DESC in an index definition. However, MySQL ignored it. In the meantime, MySQL could scan the index in reverse order but it comes at a high cost.

```sql
CREATE TABLE t(
    a INT NOT NULL,
    b INT NOT NULL,
    INDEX a_asc_b_asc (a ASC , b ASC),
    INDEX a_asc_b_desc (a ASC , b DESC),
    INDEX a_desc_b_asc (a DESC , b ASC),
    INDEX a_desc_b_desc (a DESC , b DESC)
);


EXPLAIN SELECT 
    *
FROM
    t
ORDER BY a , b; -- use index a_asc_b_asc


EXPLAIN SELECT 
    *
FROM
    t
ORDER BY a , b DESC; -- use index a_asc_b_desc


EXPLAIN SELECT 
    *
FROM
    t
ORDER BY a DESC , b; -- use index a_desc_b_asc


EXPLAIN SELECT 
    *
FROM
    t
ORDER BY a DESC , b DESC; -- use index a_desc_b_desc

```

---
## Functional_Index

- A functional index is created based on the result of an expression or function applied to one or more columns in a table.

- A functional index allows you to optimize queries by indexing computed values of specific columns. It can be useful when you have queries that involve functions applied to your data.

- To create a functional index, you use the CREATE INDEX statement:

```sql
CREATE INDEX index_name
ON table_name ((fn));


ALTER TABLE table_name
ADD INDEX index_name((fn));
```
In this syntax:

- index_name: This is the name of the index.
- fn: This is a function or expression involving the table’s columns.

#### Example

```sql
CREATE INDEX idx_year 
ON orders((YEAR(orderDate)));

```

---

## Index_Cardinality

- To view the index cardinality, you use the SHOW INDEXES command.

```sql
mysql> SHOW INDEXES FROM orders;
+--------+------------+----------------+--------------+----------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+
| Table  | Non_unique | Key_name       | Seq_in_index | Column_name    | Collation | Cardinality | Sub_part | Packed | Null | Index_type | Comment | Index_comment | Visible |
+--------+------------+----------------+--------------+----------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+
| orders |          0 | PRIMARY        |            1 | orderNumber    | A         |         326 |     NULL |   NULL |      | BTREE      |         |               | YES     |
| orders |          1 | customerNumber |            1 | customerNumber | A         |          98 |     NULL |   NULL |      | BTREE      |         |               | YES     |
+--------+------------+----------------+--------------+----------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+
2 rows in set (0.01 sec)

```

The orders table has two indexes PRIMARY and customerNumber.

The  orderNumber column has index cardinality of 326 which is high because the number of rows in the orders table is 326.

The  customerNumer column has an index cardinality of 98, meaning that there may be 98 unique values in the customerNumber column.

- If a column has high cardinality, it’s likely to be a good candidate for indexing.

- Summary
    1. Index cardinality measures the uniqueness of values in a specific index column.
    2. MySQL uses index cardinality to optimize database performance and query efficiency.


---


## Use_Index

MySQL allows you to recommend the indexes that the query optimizer should consider using an index hint.

Use the MySQL USE INDEX hint to instruct the query optimizer to use the only list of specified indexes.

Here’s the basic syntax for using the USE INDEX hint:

```sql
SELECT select_list
FROM table_name USE INDEX(index_list)
WHERE condition;


SELECT *
FROM
    customers
USE INDEX (idx_name_fl, idx_name_lf)
WHERE
    contactFirstName LIKE 'A%'
        OR contactLastName LIKE 'A%'\G
```

---

## Force_Index

In case the query optimizer ignores the index, you can use the FORCE INDEX hint to instruct it to use the index instead.

force the query optimizer to use a list of named indexes.

The following illustrates the FORCE INDEX hint syntax:

```sql
SELECT * 
FROM table_name 
FORCE INDEX (index_list)
WHERE condition;


SELECT 
    productName, buyPrice
FROM
    products 
FORCE INDEX (idx_buyPrice)
WHERE
    buyPrice BETWEEN 10 AND 80
ORDER BY buyPrice;
```