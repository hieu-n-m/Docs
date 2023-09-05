# <p align="center"> Java OOP </p> 

## Basic components

***Objects*** represent entities in real life. They have attributes, which are their state, and actions, which demonstrate their behavior. For example, a BMW car has some attributes like color, model, ... and actions like start engine, stop engine, go faster or slow down, etc.

***Class*** is a logical entity, describe a group of objects, like a blueprint of objects. A class contains fields, methods, constructor, blocks and other classes or interfaces. 
* Field is a variable of any type that is declared directly in class. In above example, color and model are fields
* Method is a function that specifies how an object of that class does its action. In above example, start engine is a method.
* Constructor is a special method that initializes fields when an object is created.
* Block contains code that is always executed whenever an object is created, before the constructor.
```java
class Car {
    // fields
    int max_speed;
    int current_speed = 0;

    // constructor
    public Car(int max_speed) {
        System.out.println("Car is created");
        this.max_speed = max_speed;
    }

    //method
    public void go() {
        System.out.println("Start engine and go");
        current_speed = 10;
    }

    // block
    {
        System.out.println("Let's create a car");
    }

}

public class Main {
    public static void main(String[] args) {
        Car bmw = new Car(100);
        bmw.go();
        System.out.println(bmw.current_speed);
    }
}
```
A class can only be declared once and no memory is allocated, but objects can be created many times when necessary and the memory is allocated as soon as its creation.

***A constructor*** must have same name of its class and it is called only once when an object is created. Constructors dont have return type. It is not necessary to write a constructor for a class because java compiler creates a default constructor. There are 3 types if constructor in java: no-argument constructor, parameterized constructor, default constructor.

1. No-argument constructor: has no parameters (arguments)
2. Parameterized constructor: accept one or more parameters
3. Default constructor: if we *dont create any constructor*, the Java compiler automatically create a no-arg constructor during the execution of the program. It initializes any uninitialized instance variables with default values.

Constructors can be overloaded but not overriden. A constructor cannot be `abstract` or `static` or `final`.
```java
class B {
    int a, b;

    public B() { // no-arg constructor
        a = 1;
    }
    public B(int a, int b) { // parameterized constructor
        this.a = a;
        this.b = b;
    }

    public B(int a) { // constructor can be overloaded
        this.a = a;
    }
}
```

***Access Modifier*** is modifier for a class or its members to restrict the access of other classes. There are 4 access modifiers: `default`, `private`, `protected`, `public`
1. Default: when no access modifiers is specified. It allows access *only within the same package*
2. Private: when using keyword `private`, it allows access *only within the same class*
3. Protected: when using keyword `protected`, it allows access *only within the same package or child classes in different package*
4. Public: when using keyword `public`, it allows access *everywhere* 

## Four pillars of OOP
### Abstraction
Data Abstraction is the property by virtue of which only the essential details are displayed to the user. The trivial or the non-essential units are not displayed to the user. For example, when a man is driving a car, he only needs to know that pressing the accelerator will inscrease speed of the car. He does not need to know how it increases or inner mechanism of the car in detail.

Abstraction is achieved by `interface` and `abstract class`.
1. Abstract class: this cannot achieve 100% abtraction because the class can have both abstract and non-abstract methods. Abstract class does not support multiple inheritance. Using an abstract class when we want a superclass that defines a general entity, leaving the detail implementation to child class. It can have a few complete fuctions that still reuseable.
```java
abstract class Vehicle {
    static boolean available = true;
    int current_speed = 0;
    abstract void go ();
    void stop () {
        current_speed = 0;
    };
}

class Bike extends Vehicle {
    void go () {
        current_speed = 5;
    }
}
```

2. Interface: this achieves 100% abstraction. Before Java 8, it can only have abstract method. They add default and static method in Java 8, and private methods in Java 9. Interface only has static final variables. Using an interface when we want a blueprint of standard behavior which provides no implementation, leaving it to any implementing class to fullfil.
```java
interface Movable {
    void turnLeft (); // default access privilege is `public`
    void turnRight ();
}
class Bike implements Movable {
    public void turnLeft () { 
        System.out.println("Turned left");
    }
    public void turnRight () {
        System.out.println("Turned right");
    }
}
```


### Encapsulation
Encapsulation is a way of hiding the implementation details or data of a class from outside access and only exposing a public interface that can be used to interact with the class. It restricts access of data, increases flexibility, reusable and safety when implement the detail of system. To achieve this, 
1. Hide data members by using `private`
2. Provide public method that allow access and update data members 
```java
class Plane {
    private static int max_speed = 500;

    public static void setMax_speed(int max_speed) {
        Plane.max_speed = max_speed;
    }
}
```

### Inheritance
Inheritance means creating new classes based on existing ones. A class that inherits from another class can reuse the methods and fields of that class and also add new fields and methods to current class as well. This can be done by using `extends` keyword. There 3 type of inheritance:
* Single inheritance: when a class extends another one
* Multilevel inheritance: consecutive single inheritance, but note that a class cannot directly access grandparent's members
* Hierarchical inheritance: two or more classes extends a class
```java
abstract class Vehicle {
    static boolean available = true;
    int current_speed = 0;
    abstract void go ();
    void stop () {
        current_speed = 0;
    };
}
class Bike extends Vehicle {
    static int max_speed = 10;
    void go () {
        System.out.println("Cycling and go");
        current_speed = 1;
    }
}
class Car extends Vehicle {
    static int max_speed = 100;
    public void go() {
        System.out.println("Starting engine and go");
        current_speed = 10;
    }
}
```
Note that multiple inheritance is not supported in Java through class, which means a class cannot inherit more than one class. 

### Polymorphism 
Polymorphism allow an action be execute in many ways. There are 2 types: overloading (compile-time polymorphism) and overriding (runtime polymorphism). 
1. Overloading: there are multiple methods with the same name but accept different parameters within a class. This way increases readability. Note that these methods must have different parameter even when they had different return types.
2. Overriding: child class has the same method as one in parent class, which means it performs in two classes having inheritance relationship. The parameter of those methods are same, but return type can be same or covariant (a subtype of the parent's return type)

```java
abstract class Vehicle {
    static boolean available = true;
    int current_speed = 0;
    abstract void go ();
    void stop () {
        current_speed = 0;
    };
}
class Car extends Vehicle {
    static int max_speed = 100;
    public void go() { // override method from parrent class
        System.out.println("Starting engine and go");
        current_speed = 10;
    }
    public void go(int distance, int time) { // overload method of this class
        current_speed = distance / time;
    }
}
```

## `static` and `final`
### Static
We can use static keyword for variables, methods, blocks and nested class (a class declared inside a class). It is used to access data directly through class without any object creation, so it belongs to class, not to members of class.
* Static variable: can be used as shared data among objects of the class. This static variable is only allocated in the memory once when the class is loaded and exists from the begin till the end of program execution, thus saving memory.
* Static method: is a way to access static variable and change its value. Note that static method cannot use non-static variable or call non-static methods directly, also we cannot use `this` or `super` in the definition of it, because again, it does not belong to any object but a class. User cannot override static methods.
* Static block: is used to initialize or change value of static variables because it is executed before the main method
* Static class: is only used for nested class, which is accessible without any object of outer class.
```java
Bike mybike = new Bike();
mybike.go();
System.out.println(Bike.available);
```

### Final
Final is a concept that restrict user action, that means it is the final one, cannot be changed, overriden or inherited.
* Final variable: the value of this variable is constant. Initialization of final variable can be empty, but only in constructor. Also, a static final variable can only be initialized in static block.
* Final method: this method cannot be overriden.
* Final class: this class cannot be inherited.
```java
abstract class Vehicle {
    static boolean available = true;
    int current_speed = 0;
    abstract void go ();
    final void stop () { // this method cannot be overriden
        current_speed = 0;
    };
}
final class Car extends Vehicle { // this class cannot be inherited
    static final int max_speed = 100; // this variable has constant value
    public void go() {
        System.out.println("Starting engine and go");
        current_speed = 10;
    }
}
```