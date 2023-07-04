<p align="justify"> Your Text 

# <p align="center"> Java Introduction </p> 
 
## JDK structure
***The Java Development Kit (JDK)*** is a cross-platformed software development environment that offers a collection of tools and libraries necessary for developing Java-based software applications and applets. It is a core package used in Java, along with the JVM (Java Virtual Machine) and the JRE (Java Runtime Environment). 

***Java Runtime Environment (JRE)*** is an open-access software distribution that has a Java class library, specific tools, and a separate JVM. JRE acts as a software layer on top of the operating system.

***ClassLoader*** Java ClassLoader dynamically loads all the classes necessary to run a Java program. Because classes are only loaded into memory whenever they are needed, the JRE uses ClassLoader will automate this process when needed. 
1. Loading: During the initialization of the JVM, three ClassLoaders are loaded:
   * Bootstrap class loader: also called as the Primordial ClassLoader, mainly responsible for loading JDK internal classes. Because ClassLoaders is classes themself, Bootstrap class loader is not a java class and its job is to load the first pure Java ClassLoader.
   * Extensions class loader: a child of Bootstrap ClassLoader and loads the extensions of core java classes from the Extension library
   * System class loader: a child class of Extension ClassLoader that loads the files present on the classpath.
2. Linking: 
   * First, checks the structural correctness of the class file by checking it against a set of constraints or rules.
   * Then the JVM allocates memory for the static fields of a class or interface, and initializes them with default values.
   * Symbolic references are replaced with direct references present in the runtime constant pool.
3. Initialization: involves executing the initialization method of the class or interface. This can include calling the class's constructor, executing the static block, and assigning values to all the static variables. This is the final stage of class loading.

***Runtime Data Area*** a part of JVM responsible to provide memory to store bytecode, objects, parameters, local variables, return values and intermediate results of computations.
1.	Method Area: store all the class level data such as the run-time constant pool, field, and method data, and the code for methods and constructors. This area is shared among all threads.
2.	Heap Area: store objects and their corresponding instance variables. The heap is created on the virtual machine start-up, and there is only one heap area per JVM. This area is shared among all threads.
3.	Stack Area: store all local variables, method calls, and partial results. A separate runtime stack is also created at the same time a new thread is created in the JVM.

***Program Counter Register (PC register)*** is owned by each thread to hold address of the currently executing JVM instruction. Once the instruction is executed, the PC register is updated with the next instruction.

***Native Method Stacks*** The JVM contains stacks that support native methods, which are written in a language other than the Java, such as C and C++. For every new thread, a separate native method stack is also allocated.

***Execution Engine*** execute the code present in each class
1.	Interpreter: reads and executes the bytecode instructions line by line
2.	JIT compiler: uses interpreter to execute the bytecode, but when code is repeated, it uses JIT compiler. JIT compiler converts bytecode to machine code, which is used for method calls
3.	Garbage Collector: remove unreferenced objects from heap area. First, the GC identifies the unused objects in memory, then remove them. This process is done automatically at regular intervals.

***Java Native Interface (JNI)*** support execution of native code, i.e when interact with hardware. JNI acts as a bridge for permitting the supporting packages for other programming languages.

***Native Method Libraries*** libraries that are written in other programming language are loaded through JNI.

## Question
***Question 1: Why are Java applications called “write once run everywhere”?***

Usually with other programming languages, the program is compiled into machine code, depending on the hardware and operating system. At that time, if you switch to another machine, you will have to recompile from scratch if you don't want to get errors. In Java, the program is not compiled directly to machine code, instead it is bytecode. This bytecode is then converted to machine code by the JVM. That means that a program that needs to be compiled only once to bytecode can run on any machine as long as they have a JVM installed.

***Question 1.1: Is Java an independent platform?***

Yes, because Java programs only need to compile once but can run anywhere, regardless of platform, as long as they have JVM installed. A Java program is not compiled directly to machine code, but it is compiled to bytecode, which is then converted to machine code by the JVM. Therefore, when using another machine, only JVM converts the bytecode to that other machine code to get the desired output.

</p>
