# <p align="center"> Java Exception </p> 

## Errors
Error is an illegal operation performed by the user which results in the abnormal working of the program. Programming errors often remain undetected until the program is compiled or executed. Some of the errors inhibit the program from getting compiled or executed. Thus errors should be removed before compiling and executing.
1. ***Run Time Error***: Run Time errors occur/are detected during the execution of the program. During compilation, the compiler has no technique to detect these kinds of errors. It is the JVM that detects it while the program is running. To handle the error during the run time we can put our error code inside the try block and catch the error inside the catch block.
2. ***Compile Time Error***: Compile Time Errors are those errors which prevent the code from running because of an incorrect syntax. These errors are detected by the java compiler and an error message is displayed on the screen while compiling

## Exceptions
Exception is an unwanted or unexpected event, which occurs during the execution of a program. Exceptions can be caught and handled by the program. Built-in exceptions are the exceptions that are available in Java libraries
1. Runtime/unchecked exceptions: Java compiler does not require us to handle. If a program throws an unchecked exception, and even if we didn’t handle or declare it, the program would not give a compilation error.
2. Compile-time/checked exceptions: Java compiler require us to handle. These exceptions are checked at compile-time by the compiler.

When an exception occurs within a method, it creates an object (this action is called throwing an exception). This object is called the exception object. It contains information about the exception, such as the name and description of the exception and the state of the program when the exception occurred. It is put into the Runtime System. The Runtime System and then the JVM, will find suitable exception handling. If both of them cannot handle the exception, then the thread is interrupted. If it is the main thread, the program dies.

Exception Handling in Java is one of the effective means to handle the runtime errors so that the regular flow of the application can be preserved. Java exception handling is managed via five keywords: `try`, `catch`, `throw`, `throws`, and `finally`.
```java
int a = 1;
int b = 0;
try {
    System.out.println(a/b);
}
catch (ArithmeticException e) {
    System.out.println(e);
}
```
1. Try block: contains codes that can throw exceptions. It can be nested. After a try block you must declare a catch or finally block or both.
2. Catch block: contains exception and executes code when exception occurs. Only one exception occurs at a time and only one catch block is executed at a time. All catch blocks must be ordered from most specific to most general.
3. Finally block: contains codes that need to execute regardless of whether an exception occurs. The finally block will not be executed if the program exits.

For each try block, there can be zero or more catch blocks, but only one finally block.

`throw` keyword in java is used to throw a specific exception. We can throw either checked or unchecked exception.
```java
a = -11;
b = 0;
try {
    if (a < 0) {
        throw new Exception("Non negative"); // throw an exception in specified case
    }
    System.out.println(a/b);
}
catch (ArithmeticException e) {
    System.out.println(e);
}
catch (Exception e) { // catch the throwed exception but it must be from most specific to most general
    System.out.println(e.getMessage());
}
```
`throws` keyword in java is used to declare an exception (both checked or unchecked) when defining a method. It represents information to the programmer that an exception may occur, so it is better for the programmer to provide the exception handling code to maintain the normal flow of the program. If you are calling a method that declares throws an exception, you must catch or throws the exception.

Suppose, you have 2 methods that declares exceptions 
```java
public void method1() throws ArithmeticException{
    System.out.println("method 1");
    int a = -1;
    if (a < 0) {
        throw new ArithmeticException("Negative");
    }
}

public void method2() throws IOException{
    System.out.println("method 2");
    throw new IOException("device null");
}
```
Then, another method that calls these two must `catch`/handle those exception, 
```java
public void method3() {
    try {
        method1();
        method2();
    }
    catch (Exception e) { // handle the exceptions from others
        System.out.println(e.getMessage());
    }
}
```
or `thows` those exception (for other to handle later when it is called)
```java
public void method4() throws ArithmeticException, IOException {
    method1();
    method2();
}
```

*In inheritance relationship*, if parent class method declared an exception, child class method can only declare unchecked exception. On the other hand, if parent class method declared an exception, child class method can only declare the *same or child exceptions* of it, unchecked exception or no exception at all.

We can also *custom exception* by extending built-in exception class. To create a custom exception, we have to extend the `java.lang.Exception` class. To create a custom unchecked exception, we need to extend the `java.lang.RuntimeException` class.
```java
class MyCustomException extends Exception {
    public MyCustomException(String err_message) {
        super(err_message);
    }
}
// ...
a = 0;
try {
    if (a == 0) {
        throw new MyCustomException("My custom exception!");
    }
}
catch (MyCustomException e) {
    System.out.println(e);
}
```
We can add Throwable parameter to explicitly explain the cause
```java
class MyCustomException extends Exception {
    public MyCustomException(String err_message, Throwable cause) {
        super(err_message, cause);
    }
}
// ...
a = 0;
try {
    if (a == 0) {
        throw new MyCustomException("My exception!", new ArithmeticException());
    }
}
catch (MyCustomException e) {
    System.out.println(e);
    System.out.println("Cause: " + e.getCause());
}
// MyCustomException: My exception!
// Cause: java.lang.ArithmeticException
```
