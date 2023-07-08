# <p align="center"> Java OOP </p> 

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
