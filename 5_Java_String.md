# <p align="center"> Java String </p> 

## Immutable vs Mutable
Immutable is a concept of object and class that its value cannot be changed after initialization. On the other hand, mutable is changable object after initialization.

String class and all primitive wrapper classes in Java (Boolean, Character, Byte, Short, Integer, Long, Float, and Double) are immutable.

## Immutable class
1. This class cannot be inherited, so it is final class
2. Every fields is unchangable. This means every fields is private and final. Also there is no method that change the state of the fields.
3. if there is any object field, it must be immutable or make a copy when initializing or retrieving

## String
A Java string is an object representing a concatenation of characters. String class is used to create this object. To create a string, you create object of this class like usual, or use string literal. 
1. String literal: When a string is created, if it already exists in string constant pool (an area specify for storing string), the reference of it is returned. If not, a new srting is create and place in the pool.
```java
String str1 = "Hello World";
``` 
2. String by `new`: When a string is created, JVM will create object in heap area normally even if its content already exists
```java
String str2 = new String("Hi World");
```

***Why Java Strings and Primitive wrapper classes are Immutable?*** Here is some reasons:
* String constant pool cannot be posible if String is mutatble. SCP is an area in heap memory which contains strings only. It helps save a lot of memory because every string is reuseable by referring by more than one variables.
* These classes is used widely for multithreading and really need to made consistent. Because many threads can access a single instance, it is not safe and asynchronous if they are mutable.
* String is especially used in application to store information, i.e. database informations, usernames, etc, or even by JVM class loaders while loading classes.

When creating a string object by using `new`, that string is not create in SCP but still in heap memory. So we can add this object to the pool or get the reference of the same string existed in the pool by using method `intern()`
``` java
// S0 refers to Object in SCP Area
String s0 = "Java";
// S1 refers to Object in the Heap Area
String s1 = new String("Java");
// get the Object in SCP Area
String s2 = s1.intern();
// Comparing memory locations
// s1 is in Heap
// s2, s0 is the same string in SCP
System.out.println(s1 == s2); // false
System.out.println(s0 == s2); // true
// Comparing only values
System.out.println(s1.equals(s2)); // true
```

## StringBuilder and StringBuffer
These two class is nearly the same that support creating and manipulating string object, but they are mutable. The only difference between them is that StringBuffer provides synchronous mechanism for multithreading while StringBuilder does it asynchronously. So use StringBuffer when working with multithreads and StringBuilder when you only work on a single thread.

We should use StringBuilder or StringBuffer instead String if we need to do a lot of work on strings. Because when we "changes" a string we also create another one, but if one of them is not referred, it is considered as garbage in the heap. It will be removed later by GC but before that, it may waste a lot of space in heap memory.

