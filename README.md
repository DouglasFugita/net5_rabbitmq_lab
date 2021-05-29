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

## Basic Worker Demo
Based in RabbitMQ Tutorial: https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html

First and Second Terminal:
```
dotnet run --project basic_worker_demo/Worker/
```
Third Terminal:
```
dotnet run --project basic_worker_demo/NewTask/
```

The result should be...
First Worker Terminal:
```
$ dotnet run --project basic_worker_demo/Worker/
 [*] Waiting for messages.
 Press [enter] to exit
 [x] Received Message 1.
 [x] Done after 1000 ms
 [x] Received Message 3...
 [x] Done after 3000 ms
 [x] Received Message 5.....
 [x] Done after 5000 ms
 [x] Received Message 7.......
 [x] Done after 7000 ms
 [x] Received Message 9.........
 [x] Done after 9000 ms
```
Second Worker Terminal:
```
dotnet run --project basic_worker_demo/Worker/
 [*] Waiting for messages.
 Press [enter] to exit
 [x] Received Message 2..
 [x] Done after 2000 ms
 [x] Received Message 4....
 [x] Done after 4000 ms
 [x] Received Message 6......
 [x] Done after 6000 ms
 [x] Received Message 8........
 [x] Done after 8000 ms
 [x] Received Message 10..........
 [x] Done after 10000 ms
```



## Resources:
- https://www.rabbitmq.com/