# Little Event Bus

Little event bus is a lightweight event bus for .net applications

### Getting Started

Little Event Bus Requires the usage of an IoC Container. Support for which is supplied via each containers own library. The long term goal is to support all major Containers, the following are currently supported.

- StructureMap
- NanoIoC


#### Setup for NanoIoC

Ensure you are calling the following in your applications startup

```csharp

Container.Global.RunAllRegistries();
Container.Global.RunAllTypeProcessors();

```

#### Setup for StructureMap

A registry is provided for StructureMap. Ensure you include the following when configuring StructureMap

```chsharp
x.AddRegistry(new LittleEventBusRegistry());

```



#### Events
Events should inherit from the Event base class and set the EventId to a new Guid.

```csharp
    public sealed class OrderPlaced : Event
    {
        public OrderPlaced(Guid id)
        {
            base.EventId = id;
        }
    }
```

#### The Event Bus

Events can be placed on the bus like so.

```csharp
//Create an event
var @event = new OrderPlaced(Guid.NewGuid());

//publish the event
this.eventBus.PublishEvent(@event);

//events can also be published asynchronously
this.eventBus.PublishEventAsync(@event);

```

#### Event Handlers
Event Handlers handle events that are placed on to the bus. Each time an event is published Handle will be called on each event handler.
These should ideally (though it isn't required) be named in a DoSomethingOnEventName format.
You can have as many Event Handlers as you like for each event.

```csharp
public sealed class EmailCustomerOnOrderPlaced : IEventHandler<OrderPlaced>
    {
        public void Handle(OrderPlaced @event)
        {
            Console.WriteLine("Handle Called EmailCustomerOnOrderPlaced Event Handler");
        }
    }
```

For more info see the example project.
