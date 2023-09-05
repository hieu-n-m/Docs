# <p align="center"> Java IO </p> 

## Files and Directories
A Directory contains a group of files or other directories. A File stores information, has an extension behind its name (.mp4, .pptx, etc). To initialize a directory, we use Java IO or Java NIO. 

### Java IO
Using `file.mkdir()` to initialize new directory. Using `file.mkdirs()` to initialize a directory that includes parent directories if they don't already exist. Both return true if it works successfully.

### Java NIO
Java NIO is an upgraded version of Java IO. 

`Files.createDirectory` is used to initialize a directory
```java
Path path = Paths.get("C:\\Users\\ADMIN\\Desktop\\MyFolder\\MyFile");
Files.createDirectory(path);
```
* If path is not exist it will throw NoSuchFileException
* If directory already exists it will throw FileAlreadyExistsException
* If it has any IO error it will throw IOException

When path is not exist, using `Files.createDirectories` will create such path instead of throwing NoSuchFileException. Otherwise, it will ignore instead of throwing FileAlreadyExistsException if path already exists.

## Stream
A stream is flow of data. Data that go into Java application is called input stream, other go out is called output stream, by using Java IO package. These streams support all the types of objects, data-types, characters, files etc to fully execute the I/O operations.

Three standard default streams is
1. `System.in`: standard input stream
2. `System.out`: standard output stream
3. `System.err`: standard error stream (is also an output stream)

There are generally 2 type of streams:
1. Byte Stream: is used to process data byte by byte
2. Character Stream: is used to read/write data character by character

### Byte Stream
`FileInputStream` and `FileOutputStream` class are useful to read and write data from a file in the form of sequence of byte. These classes are meant for reading/writing streams of raw bytes such as image data. Using `read()` or `write()` do do such things.
```java
FileInputStream input_file = null;
try {
    input_file = new FileInputStream("C:\\Users\\ADMIN\\Desktop\\MyFolder\\MyFile.txt");
    int character;
    while ((character = input_file.read()) != -1) { // read() returns int between 0 and 255.
        System.out.print((char)character);
    }
}
catch (Exception e) {
    System.out.println(e);;
}
finally {
    input_file.close();
}
```
```java
FileOutputStream output_file = null;
try {
    output_file = new FileOutputStream("C:\\Users\\ADMIN\\Desktop\\MyFolder\\MyFile.txt");
    byte str[] = "Java IO".getBytes();
    output_file.write(str);
}
catch (Exception e) {
    System.out.println(e);;
}
finally {
    output_file.close();
}
```

### Character Stream 
`FileWriter` and `FileReader` classes are used to write and read data from text files. Note that `FileWriter` creates the output file if it is not present already.

## Serialization and Deserialization
*Serialization* is a mechanism of converting the state of an object into a byte stream. *Deserialization* is the reverse process where the byte stream is used to recreate the actual Java object in memory. This mechanism is used to persist the object. The byte stream created is platform independent, so the object serialized on one platform can be deserialized on a different platform. 

To make a Java object serializable we implement the `java.io.Serializable` interface. The `ObjectOutputStream` class contains `writeObject()` method for serializing an object. The `ObjectInputStream` class contains `readObject()` method for deserializing an object. 

If the parent class implements Serializable, the child classes don't need to implement it anymore. Constructor will not be called when an object is deserialization. When performing serialization of an object, all the properties inside it must be serializable.
