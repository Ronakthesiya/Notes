## Redis

- open-source, in-memory data structure store

## Key Features of Redis:

### 1. In-Memory: 
- Redis stores data in RAM, making data access incredibly fast.

### 2. Data Structures:
- Unlike other key-value stores, Redis supports various data structures:
    - Strings: Simple key-value pairs.
    - Hashes: Maps or dictionaries, allowing you to store key-value pairs within a key.
    - Lists: Ordered collections of elements (similar to queues).
    - Sets: Unordered collections of unique elements.
    - Sorted Sets: Like sets, but each element has a score, allowing for sorting.
    - Bitmaps, HyperLogLogs, Geospatial Indexes: Specialized data types.

### 3. Persistence:
- Redis can persist data to disk, providing durability and recovery in case of crashes.

- RDB (Snapshotting): Periodically saves the data to disk.
- AOF (Append-Only File): Logs every write operation for data recovery.

### 4. Replication:
- Redis supports master-slave replication for high availability.

### 5. Atomic Operations:
- Redis supports atomic operations for better consistency.

### 6. Pub/Sub:
- Redis supports Publish/Subscribe messaging for real-time messaging systems.

### 7. High Availability and Partitioning:
- Redis supports clustering and sharding, allowing for horizontal scaling.

## Redis Data Types:

### 1. Strings

```c#
StringSet(key, value);
StringGet(key);
```

### 2. Hashes

- A hash is a collection of key-value pairs, and each key is mapped to a value within the hash. It’s great for representing objects or dictionaries.

```c#
HashSet(hashKey, field, value);
HashGet(hashKey, field); // Getting a field value from a Hash
HashGetAll(hashKey); // Getting all fields and values of a Hash
```

### 3. Lists

- A list is an ordered collection of strings. You can push elements to the front or the back, and pop them from either side.

```c#
ListLeftPush(listKey, value);
ListRightPush(listKey, value);
ListLeftPop(listKey);
ListRightPop(listKey);
```

### 4. Sets

- A set is an unordered collection of unique elements. Redis automatically ensures that no duplicates are allowed.

```c#
SetAdd(setKey, value);
SetContains(setKey, value); // Checking if an element exists in a Set
SetMembers(setKey); // Getting all members of a Set
```

### 5. Sorted Sets

- A sorted set is similar to a set but with a score that allows elements to be ordered by their score.

```c#
SortedSetAdd(sortedSetKey, value, score);
SortedSetRangeByRank(sortedSetKey, start, stop); // Getting elements from a Sorted Set by rank
SortedSetRangeByScore(sortedSetKey, minScore, maxScore); // Getting elements from a Sorted Set by score
```

### 6. Bitmaps

- A Redis bitmap allows you to store binary data efficiently and perform bit-level operations on it (useful for counting, tracking, etc.).

```c#
StringSetBit(bitmapKey, offset, value); // Setting a bit at a specific offset
StringGetBit(bitmapKey, offset); // Getting the value of a bit at a specific offset
```

| **Data Type**   | **Redis Command**                | **C# Function**                                                                            |
| --------------- | -------------------------------- | ------------------------------------------------------------------------------------------ |
| **Strings**     | `SET`, `GET`, `INCR`             | `SetString()`, `GetString()`, `IncrementString()`                                          |
| **Hashes**      | `HSET`, `HGET`, `HGETALL`        | `SetHashField()`, `GetHashField()`, `GetAllHashFields()`                                   |
| **Lists**       | `LPUSH`, `RPUSH`, `LPOP`, `RPOP` | `PushToFrontOfList()`, `PushToBackOfList()`, `PopFromFrontOfList()`, `PopFromBackOfList()` |
| **Sets**        | `SADD`, `SISMEMBER`, `SMEMBERS`  | `AddToSet()`, `IsMemberOfSet()`, `GetAllMembersOfSet()`                                    |
| **Sorted Sets** | `ZADD`, `ZRANGE`, `ZREVRANGE`    | `AddToSortedSet()`, `GetSortedSetByRank()`, `GetSortedSetByScore()`                        |
| **Bitmaps**     | `SETBIT`, `GETBIT`               | `SetBit()`, `GetBit()`                                                                     |
