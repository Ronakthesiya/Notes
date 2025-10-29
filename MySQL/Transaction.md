# MySQL Documentation: Transaction

## Table of Contents
1. [Introduction](#Transaction)
2. [Start Transaction](#Start)
2. [Commit Transaction](#Commit)
2. [Roleback Transaction](#Roleback)
2. [Savepoints](#Savepoints)

---
## Transaction

A database transaction is a series of operations executed as a single, all-or-nothing unit of work.

## Start

#### Syntax

```sql
START TRANSACTION;
```

The START TRANSACTION statement can be used to start a transaction. This statement marks the beginning of the new transaction.

## Commit

#### Syntax

```sql
COMMIT;
```

The COMMIT statement saves all the changes made during a transaction. It makes all of the changes permanent and terminates the transaction.

## Roleback

#### Syntax

```sql
ROLLBACK;
```

If something goes wrong and you want to "roll back" the changes made during the transaction, issue the ROLLBACK statement. This statement restores the database to its state before the transaction started.


## Example

```sql
START TRANSACTION;

UPDATE accounts SET balance = balance - 100 WHERE account_id = 1;
UPDATE accounts SET balance = balance + 100 WHERE account_id = 2;

COMMIT;
```

## Savepoints

You can establish named intermediate points within a transaction by using savepoints. The basic idea behind savepoints is to give a chance for partial transaction rollbacks, which means that parts of a transaction could be cancelled without interfering with the integrity of the whole transaction.

```sql
START TRANSACTION;

SAVEPOINT savepoint1;

UPDATE accounts SET balance = balance - 100 WHERE account_id = 1;

SAVEPOINT savepoint2;

UPDATE accounts SET balance = balance + 100 WHERE account_id = 2;

-- If an error occurs, roll back to a specific savepoint
ROLLBACK TO SAVEPOINT savepoint1;

-- Finally, commit the transaction
COMMIT;
```