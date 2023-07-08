# <p align="center"> Java Variables and Data Types </p> 

***The Java variables*** have mainly 3 types: *Local*, *Instance*, *Static*. To use a variable, you need to do 2 steps: *declare* and *initialize*.
* Local variables are declared inside body of a method
* Instance variables are declared without static keyword and outside a method declaration.
* Static variables are declared only once with static keyword and initialized before any instance variable at the start of the program execution.

***Data Types*** are defined as specifiers which allocate different sizes and types of values that can be stored in a variable. There are 2 parts of Data Type:
* Primitive: include 8 built-in data types. When a primitive data type is stored, it is the stack that the values will be assigned. When a variable is copied then another copy of the variable is created and changes made to the copied variable will not reflect changes in the original variable. Primitive datatypes do not have null as default value
* Non-primitive: created by the users in Java. When the reference variables will be stored, the variable will be stored in the stack and the original object will be stored in the heap. In Object data type, although two copies will be created, they both will point to the same variable in the heap, hence changes made to any variable will reflect the change in both the variables. The default value for the reference variable is null
If a reference of an object is an instance variable, that reference will be created in heap.

A variable of one type can receive the value of another type. 
* Variable of smaller capacity is be assigned to another variable of bigger capacity automatically
* Variable of larger capacity is be assigned to another variable of smaller capacity if and only if you explicitly do Type Casting