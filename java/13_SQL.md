# <p align="center"> SQL </p> 

## Relational Database Management System (RDBMS)
SQL - Structured Query Language is a standard language used for managing and manipulating data in relational databases. MySQL is a RDBMS. MySQL architecture contains 3 layer: utility layer, SQL layer and storage layer. 

Utility layer or client layer handles tasks that related to communication between client and MySQL server. When a query is sent to server, this layer will receive. Then the query will be parsed to create a parser tree. Next it will check permissions of accessing to database. 

SQL layer is the next layer. After obtaining parser tree from utility layer, a rewriter will rewrite the parser tree if it needs. Then, a optimizer will estimate cost of executing every steps from parser tree. After optimize parser tree and make a plan for it, a executor will implement it. Final step in executing a query is reply to the clients even the queries that don’t return a result set 

Storage engine layer is where data stored in hard disk. Each storage engine has advantages and disadvantages, and we should choose the suitable one based on dataset characteristics.

### Utility layer
Utility layer (client layer) provides some important services such as:
* Connection Handling: reponsible for connecting client and server. After successful connected, a given thread executes all the queries from that client.
* Authentication: performs on server with the help of username, password and client host.
* Security: after authentication, the server will check a particular client has the privileges to issue in certain queries against MySQL server.

### SQL server layer
SQL layer is the next layer reponsible for logical process. It contains some component such as
* Thread handler: a thread is provided by thread handler of server layer. The queries of client side which is executed by this thread is also handled by thread handling module.
* Parser: the queries is sent in SQL format, then it needs parsing. Firstly, lexical analysis break each one into tokens. Then, syntactic analysis will generate a parser tree from them.
* Optimizer: various types of optimization techniques are applied, such as rewriting the query, order of scanning of tables and choosing the right indexes to use, etc.

## Entity relationship
An entity is defined as a thing that can be uniquely identified, either physically or logically, and stored data. It can be represented as a noun. Entity has attributes, which describe the entity.

A relationship captures how entities are related to one another. It can be represented as a verb linking one or more nouns.

ER model is a model defines a data or information structure which can be implemented in a database, typically a relational database. In a relational database, entities may be characterized not only by relationships, but also by attributes, which is called "primary keys". A relationship between entities is implemented by storing the primary key of one entity as a pointer or "foreign key" in the table of another entity. 

In database management, cardinality represents the number of times an entity of a set participates in a relationship set. Types of cardinality in between tables are: one-to-one, one-to-many, many-to-one, and many-to-many.