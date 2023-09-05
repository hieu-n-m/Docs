# <p align="center"> Java8 </p> 

Java8 provides convenient features such as default method, lambda expression,...

## Default method
Before Java8, interface contains only abstract methods. If we add a method in an interface, we have to add implementation of that method for every class implement that interface. Default method provides default implementation of an method in the interface, so classes implement that interface do not have to provide their own implementation. 
```java
interface SampleInterface {
    void normalMethod(); 
    default void defaultMethod() { // default method does not need overridding
        System.out.println("My default method");
    }
}

class MySampleClass implements SampleInterface {
    @Override
    public void normalMethod () {
        System.out.println("Overridden normalMethod");
    }
}
```
If the class implements 2 or more interfaces that have the same name default methods, it must be overridden by specifying which one is used
```java
interface SampleInterface1 {
    default void defaultMethod() {
        System.out.println("My first default method");
    }
}
interface SampleInterface2 {
    default void defaultMethod() {
        System.out.println("My second default method");
    }
}

class MySampleClass implements SampleInterface1, SampleInterface2 {
    @Override
    public void defaultMethod() { // specify using the defaultMethod of SampleInterface1
        SampleInterface1.super.defaultMethod();
    }
}
```
Static method is also new feature in this version. It is the same as default method except it cannot be overridden.

## Functional interface
A functional interface is an interface that has only 1 abstract method. It can have multiple default or static method. The main benefit of functional interfaces is that we can use Lambda Expression (mention later) to create an instance of that interface.

## Lambda Expression

Lambda Expression is a function with no name and no class, no scope (private, public or protected), no return type declaration. It enable to treat functionality as a method argument, or code as data; can be created without belonging to any class; and can be passed around as if it was an object and executed on demand. Lambda expression basically express instances of functional interfaces.
```
(argument-list) -> {body}
```
For example,
```java
@FunctionalInterface
interface Adding {
    int add(int x, int y);
}

// ...
Adding add_obj = (x, y) ->  x + y; // define add is normal plus operator
System.out.println(add_obj.add(1, 2));

Adding add_obj1 = (x, y) -> (x + y) % 5; // define add is plus operator in modulo 5
System.out.println(add_obj1.add(7, 10));
```

## Method Reference
Method Reference is a special kind of lambda expression. Sometimes, lambda expression calls an existing method, then we prefer refering to the existing method by name. There are four type method references that are as follows:
1. Static Method Reference: `Class::staticMethod`
2. Instance Method Reference of a particular object: `object::method`
3. Instance Method Reference of an arbitrary object of a particular type: `ObjectType::method`
4. Constructor Reference: `Class::new`
```java
@FunctionalInterface
interface DoSth {
    void doSth();
}

class SampleClass {
    static void staticMethod () {
        System.out.println("static method");
    }
    void instanceMethod () {
        System.out.println("instance method");
    }
}

// ...
DoSth doSth_obj = SampleClass::staticMethod;
doSth_obj.doSth(); // static method

SampleClass sample = new SampleClass();
doSth_obj = sample::instanceMethod;
doSth_obj.doSth(); // instance method
```

## Collection forEach
`forEach` loop is a new way to iterate over collection
```java
void forEach(Consumer <? super T> action)
```
The Consumer interface is a functional interface (an interface with a single abstract method). It accepts an input and returns no result. Therefore, any implementation, for instance, a consumer that simply prints a String, can be passed to forEach as an argument.

With this, instead of 
```java
for (int element : array) {
    System.out.println(element);
}
```
we can write 
```java
array.forEach(element -> System.out.println(element));
```
or
```java
array.forEach(System.out::println);
```

## Java Stream
Java Stream is a sequence of objects that support various of methods to be applied in order to process the data. Note that:
* Stream just performs aggregate operations, it do not contain data. In other words, it is not a data structure
* Stream is an immutable object. Whenever performing new operation, it creates new stream.
* Stream is lazy (this will be explained later)
* Stream supports parallel manipulation of elements in Collection or Array.

Creating a stream 
* Empty stream
```java
Stream<Integer> empty_stream = Stream.empty();
```
* Stream of collection
```java
Collection<Integer> collection = new ArrayList<>();
Stream<Integer> stream_collection = collection.stream();
```
* Stream of array
```java
Integer[] arr = new Integer[] {1, 2, 3};
Stream<Integer> stream_array = Arrays.stream(arr);
```
Stream pipline is a sequence of operations from source data to final results. It has 3 parts: source, intermediate operations and terminal operations.
1. Source: the data can be an array, collection, I/O channel, etc, then create stream instance.
2. Intermediate operations: it consists of `filter()`, `skip()`, `limit()`, `map()`.
3. Terminal operations: it consists of `forEach()`, `collect()`.

Why we said stream, or specifically intermediate operation, is lazy? Because they are not evaluated unless terminal operation is invoked. Each intermediate operation creates a new stream, stores the provided operation/function and return the new stream. The pipeline accumulates these newly created streams. The time when terminal operation is called, traversal of streams begins and the associated function is performed one by one. Traversal of the pipeline source does not begin until the terminal operation of the pipeline is executed.

## Java Optional
Java Optional is used to contain a single value of either a primitive type or an object type, that may or may not be present. It help in writing a neat code without using too many null checks.

Creating Optional object
* `empty()` initializes an empty Optional object
* `of()`  creates an Optional object.
* `isNullable()` creates an Empty Optional object with null value
`isPresent()` returns if the wrapped object has a value or null. Before using an object, programer should use `ifPresent()` to check it null or not
```java
Optional<Integer> val = Optional.empty();
val.ifPresent(System.out::println);
val = Optional.of(1);
val.ifPresent(System.out::println); // 1
```

Other methods:
* `orElse()` returns value of the instance if present, or else return its parameter
```java
Optional<Integer> myvalue = Optional.empty();
System.out.println(myvalue.orElse(100)); // 100
myvalue = Optional.of(2);
System.out.println(myvalue.orElse(100)); // 2
```
* `orElseGet()` is similar to `orElse()`. But `orElseGet()` only call its parameter if the instance is present, on the otherhand, `orElse()` always call its parameter no matter what.
* `orElseThrow()` is similar to `orElseGet()` except it will throw exception instead.