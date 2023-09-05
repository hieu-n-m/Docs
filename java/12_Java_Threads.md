# <p align="center"> Java Thread </p> 

Multi-thread programing is very useful nowaday. But there are some factorial that need covering such as
* Preserve data integrity
* Ensure that application works normally
* Ensure high performance which is higher throughput and lower latency

We can run threads by using `Thread` class, which provides constructors and methods for creating and performing operations on a thread, which extends a `Thread` class that can implement `Runnable` interface.
```java
class MyThread extends Thread {
    @Override
    public void run() {
        System.out.println("Running My Thread");
    }
}

class MyRunnable implements Runnable {
    @Override
    public void run() {
        System.out.println("Running My Runnable");
    }
}

// ...
MyThread thread1 = new MyThread();
thread1.start();
Thread thread2 = new Thread(new MyRunnable());
thread2.start();
Thread thread3 = new Thread(() -> System.out.println("Running"));
thread3.start();
```

Java Thread Pool is a group of threads that are waiting for the task and can be reused many times. A group of fixed-size threads is created, then a thread from the pool is pulled out and assigned a task. After completion of the task, the thread is contained in the thread pool again.

Synchronization is the process of allowing only one thread at a time to complete the particular task. It means when multiple threads executing simultaneously, and want to access the same resource at the same time, then the problem of inconsistency will occur. so synchronization is used to resolve inconsistency problem by allowing only one thread at a time. Synchronization uses a `synchronized` keyword. `synchronized` is the modifier that creates a block of code known as a critical section.

