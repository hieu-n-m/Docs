# <p align="center"> Java Basics </p> 

## Wrapper class
Primitive type variables are not objects. *A Wrapper class* in Java is a class whose object wraps or contains primitive data types. When we create an object to a wrapper class, it contains a field and in this field, we can store primitive data types. In other words, we can wrap a primitive value into a wrapper class object.

Why we need wrapper class? Here is some reasons:
* Objects are needed in some case: if we wish to modify the arguments passed into a method but primitive types are pass by value, or if we are using data structures such as ArrayList or Vector. which are not supported primitive types
* We need to use null variables

To convert a primitive type variable to an object of the corresponding wrapper class and vice versa, we can call the method of the class
```java
int a = 1;
Integer i = Integer.valueOf(a);
int b = i.intValue();
```

***Autoboxing*** is the automatic conversion of primitive types to the object of their corresponding wrapper classes, and it is ***Unboxing*** in reverse.
```java
int a = 1;
Integer j = a;
int c = j;
```

## Array
Array is a special set of object which all values are stored in heap. To create an array, you perform 2 steps: declare and allocate memory
```java
int array[];
array = new int[10];
```
or 
```java
int[] array1 = new int[10];
```

## `instanceof` operator
This operator is used to check if an object is an instance of a data type (class, subclass or interface). Its return type is boolean, which returns True if that object is an instance of that class, its subclass or class implementing interface. If object is null, it returns false.
```java
Integer i = null;
System.out.println(i instanceof Integer); // false
```
***Upcasting*** is the typecasting of a child object to a parent object. Upcasting can be done implicitly. Upcasting gives us the flexibility to access the parent class members but it is not possible to access all the child class members using this feature. Instead of all the members, we can access some specified members of the child class. For instance, we can access the overridden methods. On the other hand, ***Downcasting*** means the typecasting of a parent object to a child object, which cannot be implicit.

To downcast an object, you must check it valid or not by using `instanceof`
```java
class Bicycle extends Bike {
    public void uniqueMethodBicycleHas () {}
}
.
.
.
Bike bicycle = new Bicycle();
// bicycle.uniqueMethodBicycleHas(); // error
if (bicycle instanceof Bicycle) {
    Bicycle my_bicycle = (Bicycle) bicycle;
    System.out.println("Downcast succeed");
    my_bicycle.uniqueMethodBicycleHas();  
} else {
    System.out.println("Cannot downcast");
}
```

## `this` keyword
`this` is used as a reference variable that refers to current object. You use this keyword when: refer or return current class instance variable, invoke current class method or constructor, pass as argument in method or constructor call.
```java
class Plane {
    private static int max_speed = 500;
    int flight_num;
    public Plane(int flight_num) {
        this.flight_num = flight_num;
    }
    public static void setMax_speed(int max_speed) {
        Plane.max_speed = max_speed;
    }
}
```

## `super` keyword
`super` is used as a reference variable to refer immediate parent class object that confuse compiler between the same name parent class or child class method. You use this keyword when: refer an immediate parent class instance variable, invoke immediate parent class method or constructor.
```java
class Bike {
    static final int max_speed = 10;
    int current_speed;
    void go () {
        System.out.println("Go");
        current_speed = 5;
    }
}

class Bicycle extends Bike {
    void go() {
        super.go();
        System.out.println("Tired! Slow down");
        current_speed = 2;
    }
}
```

## Passing parameter in Java
When use a parameterized method, we pass argument to it to execute. The inner process is mainly divided in 2 case:
1. Pass-by-value: the argument is primitive variable, which is stored in stack. The method will create a copy of this variable and execute the code with this copy. So, when this copy is changed, the original one is not changed.
2. Pass-by-reference: the argument is an object, which is stored in heap. The method will create a copy of this reference variable and execute the code with this copy. But the reference variable contained address of the object in heap, so the copy one also contains that address. In result, When operate this copy, you actually operate the object in heap memory too. This means object outside method also be changed. 