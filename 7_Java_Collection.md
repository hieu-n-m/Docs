# <p align="center"> Java Collection </p> 

## What is Collection?
Array is the most basic set in Java, but working with it is inconvenient because it did not support complicate manipulation. The Java platform includes Collection framework. A collection is an object that represents a set of objects. The collections framework is a set of classes and interfaces which provide a ready-made architecture for representing and manipulating collections. 

![Hierarchy of Collection Framework](https://static.javatpoint.com/images/java-collection-hierarchy.png)

Collection interfaces are divided into 2 group: the basic interface java.util.Collection and other collection interfaces base on java.util.Map. The second one is not truly collections but contains collection-view operation.

## List Interface
In this section, we considers 3 classes in list interface: `ArrayList`, `LinkedList` and `Vector`.

### ArrayList
The `ArrayList` class is an index-base data structure, which used dynamic array to store element, because its size is automatically changed if elements are added or removed. Below are some properties of an ArrayList object:
* Size is dymanic, so adding or removing elements is slow
* May contain duplicate elements
* Allow random access, the accessing is fast because it stores by index
* Can not be used for primitive types. We need a wrapper class for such cases
* Asynchronous

There are 3 constructors of ArrayList class
1. `ArrayList()`: create an empty ArrayList object
2. `ArrayList(Collection c)`: create an ArrayList object from other collection object
3. `ArrayList(int capacity)`: create an ArrayList object with specified capacity, default is 10. When exceeding this capacity, it will automatically extend the size by 50% of current size.
```java
ArrayList arr1 = new ArrayList();
System.out.println(arr1.isEmpty()); // True
arr1.add(1);
arr1.add(1);
arr1.add(2);
System.out.println(arr1.size()); // 3
System.out.println(arr1); // [1, 1, 2]

ArrayList arr2 = new ArrayList(4);
arr2.add(arr1);
System.out.println(arr1.size()); // 3
arr2.addAll(arr1);
arr2.add(3);
arr2.add(4);
System.out.println(arr2); // [[1, 1, 2], 1, 1, 2, 3, 4]
```

### LinkedList
The `LinkedList` class is a linear data structure where the elements are not stored in contiguous locations and every element is a separate object with a data part and address part. The elements are linked using pointers and addresses. Each element is known as a node. 
* Elements are isolated, which means they are not contigous in memory, thus adding or removing is fast
* May contain duplicate element
* Can be used as list, stack or queue because it implements both List and Deque (double-end queue)
* Retrieving data is slow because accessing a certain node requires to iterate from the beginning of the list
* Asynchronous

There are 2 constructors:
1. `LinkedList()`: create empty LinkedList object
2. `LinkedList(Collection c)`: create LinkedList object from other collection object
```java
LinkedList linkedList = new LinkedList();
linkedList.add(1);
linkedList.add(2);
linkedList.add(3);
System.out.println(linkedList); // [1, 2, 3]

LinkedList linkedList1 = new LinkedList(linkedList);
linkedList1.addFirst(0);
linkedList1.addLast(0);
linkedList1.addAll(linkedList);
System.out.println(linkedList1); // [0, 1, 2, 3, 0, 1, 2, 3]
```

### Vector
The `Vector` class behaves very similar to ArrayList, but Vector is synchronized and has some legacy methods that the collection framework does not contain.

## Queue Interface
Queue is the data structure that follow First-In-First-Out (FIFO) algorithm. There are 2 class implement Queue interface: `LinkedList` and `PriorityQueue`.

### LinkedList 
This class is already discussed above.

### PriorityQueue
A PriorityQueue is used when the objects are supposed to be processed based on the priority. The elements of the priority queue are ordered according to the natural ordering, or by a Comparator provided at queue construction time, depending on which constructor is used. We can’t create a PriorityQueue of Objects that are non-comparable.

For example, String is class that implements Comparable interface, so they are comparable and sorted alphabetically
```java
PriorityQueue priorityQueue = new PriorityQueue();
priorityQueue.add("K");
priorityQueue.add("A");
priorityQueue.add("T");
priorityQueue.add("E");
System.out.println(priorityQueue); // [A, E, T, K]
```

## Deque Interface
Deque is short for Double-end Queue, which have the properties of a queue at both ends. There are 2 class implement Deque interface: `LinkedList` and `ArrayDeque`.
* Can have null element or duplicate element
* Cannot random access (there are no index-based `add`, `get`, `remove` or `set` methods)

`ArrayDeque` is likely to be faster than Stack when used as a stack, and faster than LinkedList when used as a queue.