# <p align="center"> Java Generics </p> 

## What is Generics?
Generics is the way to parameterize types, which is allow type to be a parameter in methods, classes, interfaces. A logical entity such as class, interface, or method that operates on a parameterized type is a generic entity.

The core idea begin generics is when using data structure like list, it cause type-related runtime errors if programmer did not explicit type casting while retrieve data.

The program that use generics has a lot benefits like
1. Code reusable: classes, interfaces, methods with generics can be use for any type.
2. Type safety: it makes errors appear compile time than at runtime and type casting is not needed

To increase readability, there are common conventions for generic type
* E - Element (used in Collection)
* K - Key
* V - Value
* N - Numberic type: Integer, Double, Float
* T - Type from wrapper class

*Generics work only with Reference Types*. When we declare an instance of a generic type, the type argument passed to the type parameter must be a reference type. We cannot use primitive data types
```java
Test<int> obj = new Test<int>(20); // error 
```
But primitive arráy can be passed to type parameter because it is reference type.
```java
ArrayList<int[]> a = new ArrayList<>();
```

Since generics types dont exist at runtime, that means when initialization, it need to know what exactly type in order to compile the code. So it is not possible to initialize with generics.
```java
T[] array = new T[10]; // error
```

## Types of Java Generics
### Generics class
A generic class is implemented almost like a non-generic class. The only difference is that it contains a type parameter section. There can be more than one type of parameter, separated by a comma. The classes, which accept one or more parameters, are known as parameterized classes or parameterized types.
```java
class GenericClass <K, V> {
    public K key;
    public V val;
    public GenericClass(K key, V val) {
        this.key = key;
        this.val = val;
    }
}
```
Any class inherits this class can keep generics types, specify any parameterized types or add more generics parameter
```java
class GenericChildClass1 <K, V> extends GenericClass <K, V> {
    public GenericChildClass1(K key, V val) {
        super(key, val);
    }
}

class GenericChildClass2 <V> extends GenericClass <String, V> {
    public GenericChildClass2(String key, V val) {
        super(key, val);
    }
}

class GenericChildClass3 <K, V, N> extends GenericClass <K, V> {
    public N num;
    public GenericChildClass3(K key, V val, N num) {
        super(key, val);
        this.num = num;
    }
}
```

### Generics Interface
Writing and implementing a generics interface is the same as generics class. It also contain type parameter section and any class implement it can keep, change or add generics type.
```java
interface GenericInterface <T, V> {
    void method1();
    void method2();
}

class GenericClass1<T> implements GenericInterface <T, Integer> {
    public void method1() {
        //
    }
    public void method2() {
        //
    }
}
```
### Generics Method
The generics method has type parameter section before return type to declare generics types that the method dealing with. Anything else is just like normal method.
```java
public <K, V> void genericsMethod(K key, V value) {
        System.out.println(key);
        System.out.println(value);
    }
```

## Generics Bound
Using generics bound when you want to restrict the types that can be used as type arguments in a parameterized type. 

***Upper bounds*** is used when a method/class/interface only deals with generics type of ClassA or its child classes,
```java
<T extends ClassA>
```
Also you can have multiple boundaries, but it is not allow to have more than one class in multiple bounds.
```java
<T extends ClassA  & InterfaceB>
```
***Lower bounds*** is used when a method/class/interface only deals with generics type of ClassA or its parent classes,
```java
<T super ClassA>
```

## Generics Wildcards
Wildcard, with notation of questionmark `?`, represent an unknown type. Wildcard is a special generic type, used as type of parameters, fields or local variables, even return types; but never used as argument to generic method call, generic class object instantiation or supertype.
```java
List<? super Integer> mylist1 = new ArrayList<>();
mylist1.add(Integer.valueOf(3));
```


