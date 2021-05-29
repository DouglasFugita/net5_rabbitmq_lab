# RabbitMQ Lab

## Docker
```
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
## Basic Demo
Based in RabbitMQ Tutorial: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html

First Terminal:
```
dotnet run --project basic_demo/Receive/
```
Second Terminal:
```
dotnet run --project basic_demo/Send/
```


## Resources:
- https://www.rabbitmq.com/