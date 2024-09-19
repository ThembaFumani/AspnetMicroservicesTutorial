# QuickMart

Welcome to the backend documentation for QuickMart—your go-to platform for a seamless and dynamic e-commerce experience. Our backend is designed to handle high traffic, real-time updates, and complex data interactions with a robust and scalable architecture.

Technology Stack
----------------

*   **.NET 6**: The backbone of our backend services, providing a high-performance framework for building scalable and efficient microservices and APIs.
    
*   **MongoDB**: A NoSQL database used for flexible schema design and scalable data storage, managing dynamic product information and user data.
    
*   **gRPC**: A high-performance RPC framework that enables efficient communication between microservices, offering strong typing and low latency.
    
*   **Redis**: An in-memory data structure store used for caching and improving performance by reducing database load and latency.
    
*   **.NET 6 Web API**: Powers RESTful APIs for client interactions, enabling CRUD operations and business logic implementation.
    
*   **SQL Server**: A relational database used for structured data storage, including transactional data and complex queries.
    
*   **Docker**: Containerizes applications, ensuring consistent environments across development, testing, and production stages.
    
*   **PostgreSQL**: An advanced relational database for handling complex queries and transactions with strong data integrity and extensibility.
    
*   **RabbitMQ**: A message broker used for asynchronous communication between services, ensuring reliable and scalable message handling.
    

Key Features
------------

*   **Scalable Microservices**: Built with .NET 6 and gRPC, allowing each service to scale independently to meet varying demands.
    
*   **Flexible Data Storage**: MongoDB and SQL Server provide diverse data storage solutions, managing both unstructured and structured data efficiently.
    
*   **Real-Time Performance**: Redis accelerates data access with in-memory caching, while RabbitMQ facilitates robust, asynchronous messaging.
    
*   **Containerization**: Docker ensures consistent deployment and scaling across different environments, streamlining the CI/CD pipeline.
    

Services Overview
-----------------

*   **Product Service**: Manages product catalog, including dynamic attributes, inventory levels, and product details stored in MongoDB.
    
*   **Order Service**: Handles order processing, from creation to fulfillment, using SQL Server for transactional data and RabbitMQ for inter-service communication.
    
*   **Customer Service**: Manages customer profiles, authentication, and order history with data stored in PostgreSQL.
    
*   **Cache Service**: Utilizes Redis for caching frequently accessed data, reducing response times and improving system performance.
    
*   **API Gateway**: Exposes .NET 6 Web APIs to clients, providing endpoints for various operations and integrating with gRPC services.

Getting Started
---------------

To start working with the backend:

1.  Clone the repository.
    
2.  Install **.NET 6 SDK**.
    
3.  Set up MongoDB, SQL Server, and PostgreSQL instances. Update connection strings in appsettings.json.
    
4.  Configure Redis and RabbitMQ.
    
5.  Run the services locally using Docker Compose or deploy them using Docker.
