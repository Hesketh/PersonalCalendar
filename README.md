# PersonalCalendar
Created for my Application Development module during my second year at the University of Derby. Features a database designed specifically for the assignment, a server which employs a REST API to act as a middle man between the clients and the database and a desktop and web client.

The application allows users to create a calendar entry on a specified date and time. Similar to Google Calendar.

## Database
The database creation script is included in "Database.sql" and was written for PostgreSQL 9.4 - https://www.postgresql.org/.

### Entities and Relations
![ERDiagram](https://raw.githubusercontent.com/Hesketh/PersonalCalendar/master/EntityRelationshipDiagram.png)

## Server (RESTful)
- To make any request other than a login request (or account creation) the user must succeed a login request. 
- Requests are made asynchronously so that the server does not hang when asked to process requests from x amount of clients.
- MVC (Model View Controller) structure.
- SQL Injection attacks are prevented.

