# Little Event Bus

Little event bus is a lightweight event bus for .net applications

It takes a single dependency [NanoIoC](https://github.com/trullock/NanoIoC) which is used internally for dependency resolution.

## Getting Started

#### Setup and Configuration

If you are not Using NanoIoC as your applications IoC Container, you will need to run the Event Handler Type Processor in your applications startup like so

```csharp
Container.Global.RunAllTypeProcessors()
```

You will also need to register the event bus itself

```csharp
//Structuremap
this.For<IEventBus>().Use<SingleThreadedEventBus>();

//nano IoC
Container.Global.Register<IEventBus, SingleThreadedEventBus>(Lifecycle.Singleton);
```

#### Events
Events should inherit from the Event base class and set the EventId to a new Guid, or the Aggregate Root id of your Domain Object if used in this context.

```csharp
    public sealed class OrderPlaced : Event
    {
        public OrderPlaced(Guid id)
        {
            base.EventId = id;
        }
    }
```

Events can then be placed on the bus like so

```csharp
//Create an event
var @event = new OrderPlaced(Guid.NewGuid());

//publish the event
this.eventBus.PublishEvent(@event);
```

#### Event Handlers
Event Handlers handle events that are placed on to the bus. And should ideally (though it isn't required) be named in a DoSomethingOnEventName format.
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
