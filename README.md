# SignalRApp
Signalr library environment


## Description

Study about SignalR library. <br>
Using remote procedure call (rpc).<br>



## Source Material.

 https://www.gencayyildiz.com/blog/asp-net-core-signalr-yazi-serisi/
 <br>
https://learn.microsoft.com/tr-tr/aspnet/signalr/

## SignalR Library Review Project ##

This project is a study that aims to examine the SignalR library in detail from both the client and server side. SignalR is a library used to develop real-time web applications and this project contains subprojects developed to understand and use all aspects of SignalR.

## Project Structure ##

This project consists of two main subprojects: client and server side. Both subprojects are designed to comprehensively examine the SignalR library.

### 1. Client Side Project ###

The client side project was developed to understand and examine client side implementations of the SignalR library. 
This subproject creates a user interface using the SignalR client-side library and communicates with the SignalR server. 
Here are the main features of the client side project

User Interface: There is a user interface created using the SignalR library. This interface communicates with the SignalR server, exchanging data in real time.

Event Listeners: There are listeners that listen for and respond to SignalR client-side events. For example, there may be a message receiving listener that processes new messages coming from the server.

Server Connection Management: SignalR client side enables establishing and managing a secure and persistent connection with the server.

### 2. Server Side Project ###

The server side project was developed to understand and examine server side implementations of the SignalR library.
This subproject creates the SignalR server and communicates with clients. Here are the main features of the server side project

Server Configuration: The SignalR server application manages server-side connections and processes incoming requests. The server accepts, manages and keeps clients' connections up to date.
Client Connection Acceptance: The SignalR server accepts and responds to client-initiated connections. This acts as a bridge for real-time communication.
Group Chat Management: SignalR server manages group chats between multiple clients. It assigns clients to groups, routes messages within the group, and enables interaction between group members. 
