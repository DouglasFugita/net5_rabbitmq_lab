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

## Basic Exchange Fanout Demo
Based in RabbitMQ Tutorial: https://www.rabbitmq.com/tutorials/tutorial-three-dotnet.html

2 Receivers Terminal:
```
dotnet run --project basic_exchange_fanout_demo/ReceiveLogs/
```
1 Emitter Terminal:
```
dotnet run --project basic_exchange_fanout_demo/EmitLog/
```


## Basic Exchange Direct Demo
Based in RabbitMQ Tutorial: https://www.rabbitmq.com/tutorials/tutorial-four-dotnet.html

First Receiver Terminal (Warning and Error Messages)
```
dotnet run warning error --project basic_exchange_direct_demo/ReceiveLogsDirect/
```
Second Receiver Terminal (Info messages)
```
dotnet run info --project basic_exchange_direct_demo/ReceiveLogsDirect/
```
Emitter Terminal
```
dotnet run error "Run. Run. Or it will explode." --project basic_exchange_direct_demo/EmitLogDirect/
dotnet run warning "Just a warning... But its a warning." --project basic_exchange_direct_demo/EmitLogDirect/
dotnet run info "Info! Info! Info!" --project basic_exchange_direct_demo/EmitLogDirect/
```
## Basic Exchange Topic Demo
Based in RabbitMQ Tutorial: https://www.rabbitmq.com/tutorials/tutorial-five-dotnet.html

Receiver Terminal to receive all messages:
```
dotnet run "#" --project basic_exchange_topic_demo/ReceiveLogsTopic/
```
Receiver Terminal to receive logs from 'kern'
```
dotnet run "kern.*" --project basic_exchange_topic_demo/ReceiveLogsTopic/
```
Receiver Terminal to receive 'critical' logs
```
dotnet run "*.critical" --project basic_exchange_topic_demo/ReceiveLogsTopic/
```
Receiver Terminal to multiple bindings
```
dotnet run "kern.critical" "*.info" --project basic_exchange_topic_demo/ReceiveLogsTopic/
```
Emitter Terminal
```
dotnet run "kern.critical" "Critical Kernel Error" --project basic_exchange_topic_demo/EmitLogTopic/
dotnet run "kern.warning" "Kernel Warning" --project basic_exchange_topic_demo/EmitLogTopic/
dotnet run "cron.critical" "Critical Cron Error" --project basic_exchange_topic_demo/EmitLogTopic/
dotnet run "cron.info" "Cron Info" --project basic_exchange_topic_demo/EmitLogTopic/
```

## Basic ReplyTo Demo
RPC Server
```
dotnet run --project basic_replyQueue_RPC_demo/RPCServer/
```
RPC Client
```
dotnet run --project basic_replyQueue_RPC_demo/RPCClient/
```

## Resources:
- https://www.rabbitmq.com/