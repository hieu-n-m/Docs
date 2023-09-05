# <p align="center"> Java Collection </p> 

## Map Interface
These below collection which implemented Map interface is not truly collection. However, these interfaces contain collection-view operations, which enable them to be manipulated as collections. There are 4 class to be considered: `HashMap`, `LinkedHashMap`, `TreeMap` and `HashTable`.

### HashMap
`HashMap` class provides key-value data structure, in which every node has 4 component: the hash code, a pair of key and value, and the next node. It means that internally HashMap uses LinkedList data structure. Also, HashMap uses an array to store items, which are indexed by using hash fuction and stores them in hash code variable. There are rules for the key-value pairs: Every key is unique; Key and value can be null. HashMaps have *capacity*, which is the number of elements that it can hold, and *load factor*, which is the measure of how full the hashmap can be before it is resized.

HashMap has characteristics that:
* Retrieval and insertion of elements are very fast
* Not ordered (which means that the order in which elements are added to the map is not preserved)
* Asynchronized

HashMap has 4 constructors:
1. `HashMap()` creates empty HashMap object
2. `HashMap(int capacity)` creates a HashMap object with specified capacity
3. `HashMap(int capacity, float load)` creates a HashMap object with specified capacity and load factor
4. `HashMap(Map m)` creates a HashMap from other Map object

Note that default capacity and load factor of HashMap is 16 and 0.75. It means that default HashMap can hold 16 nodes and when there is 16*0.75 = 12 nodes is inserted, it will double the capacity.
```java
HashMap map = new HashMap();
map.put("K", 35);
map.put("E", 5);
map.put(null, 0);
System.out.println(map.get("E")); // 5
System.out.println(map); // {null=0, E=5, K=35}
```

Inserting a key-value pair to HashMap can briefly described in steps:
1. Calculate hash code of the key.
2. Calculate index by using index method `index = hashcode(key) & (n-1)`, where `n` is number of elements or the size of the array, `&` is bitwise AND operator
3. If there is no other object is present in calculated `index`, place the new object there.
4. Otherwise, other object found in the position is called *collision*, check if the keys are the same. If true, replace the value with the new one. Otherwise, connect this node object to the previous node object via linked list and both are stored at `index`.

Getting a key-value pair from HashMap is similar to inserting,
1. Calculate hash code of the key.
2. Calculate index by using index method `index = hashcode(key) & (n-1)`, where `n` is number of elements or the size of the array, `&` is bitwise AND operator
3. Go to `index` of the array and compare the first element’s key with the given key. If both are equals then return the value, otherwise, check for the next element if it exists
4. Repeat step 3, the linked list is traversed until the key matches or null is found on the next field

Why `hash & (n - 1)` instead of `hash % n`? Because `&` runs faster, in exchange for working only for powers of two. Specifically, x & (n - 1) == x % n if x is nonnegative and n is a power of 2.

Note that, in Java 8, in case we have too many element in the same index that grow beyond certain threshold (8), content of that bucket switches from using a linked list of Entry objects to a balanced tree, which improves searching complexity to O(log(n)).

### LinkedHashMap
`LinkedHashMap` class inherits `HashMap` class and implements Map interface. Differences from a HashMap node is that LinkedHashMap node has 2 more attribute: one points to the next added node, another points to the previous added node. Thus, adding or getting node to LinkedHashMap needs additional step.

A LinkedHashMap is useful whenever you need the ordering of keys to match the ordering of insertion.

### TreeMap
`TreeMap` is a red-black tree (a kind of self-balance tree) based implementation, in which every node is sorted according their natural order (i.e. alphabetical order of String) or specified comparator. More specifically, left child is less than parent, right child is greater or equal to parent in logic. This data structure provides better insert/remove and search operations. Also note that, different from HashMap, null key is not allowed.

### HashTable
A hashtable is an array of buckets. HashTable is similar to HashMap except it's synchronous and doesn't allow null key or value. Also, initial default capacity is 11 and load factor is 0.75.


## Set Interface
`HashSet`, `LinkedHashSet` and `TreeSet` implement Set interface. They do not allow duplicate element, asynchronized and implement Cloneable and Serializable interfaces.

These class has similar properties and purpose like HashMap, LinkedHashMap and TreeMap.

## Collection Summary
`Collections` is utility class provides tools to manipulate collections. This class support polymorphic algorithms  that operate on collections. The Collections class throws a NullPointerException if the collections or the class objects that provide them are null.

### Iterator and ListIterator
There are many ways to traverse the elements of a collection in Java, including using Iterator and ListIterator
1. Iterator is used to *traverse collections* in *only one direction*. When using Iterator, it is *unable to add or replace*.
2. ListIterator is only used tô *traverse List* but can do in *all direction*. It provides *more tools than Iterator*.

### Comparable and Comparator
Some objects need initializing with comparator (e.g. TreeMap), which defines how things are compared to each other. There are 2 ways
1. Implement `Comparable<T>` and override `compareTo(T obj)` method. This is an interface provides only one way comparison and changes the class implemented it. Any list can be sorted using `Collections.sort(list)`.
2. Implement `Comparator<T>` and override `compare(T obj1, T obj2)` method. Unlike Comparable, it is a separate class which provides many ways of comparison. This means the original class is not changed. Any list can be sorted using `Collections.sort(list, Comparator)`.

Comparable interface is meant for objects with natural ordering which means the object itself must know how it is to be ordered. Whereas, Comparator class sorting is done through a separate class. To summarize, if sorting of objects needs to be based on natural order then use Comparable, whereas if you sorting needs to be done on attributes of different objects, then use Comparator in Java.


 