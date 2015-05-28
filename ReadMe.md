# Little Event Bus

Little event bus is a lightweight event bus for .net applications. Its designed for when you want to incorporate eventing in your application but don't necessarily need CQRS and Event Sourcing. This isn't to say that Little Event Bus cannot be used in these scenarios, but its features and the terminology used are focused on event driven applications over anything else.

## Obtaining Little Event Bus

Little Event Bus is available on Nuget

```
PM> Install-Package LittleEventBus
PM> Install-Package LittleEventBus.StructureMap

```
Or via the [GitHub Releases](https://github.com/jimmason/LittleEventBus/releases)

## Getting Started

#### Events
Events should inherit from the Event base class and set the EventId to a new Guid or the Id of your Aggregate Root Object.

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

## Setup for various IoC Containers

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

A registry is provided for StructureMap. Ensure you include the following when configuring StructureMap.
If you are using this registry you will need to provide a type of one of your event handlers so it knows where to look

```chsharp
x.AddRegistry(new LittleEventBusRegistry(typeof([OneOfYourEventHandlers])));

```

## Testing

For testing a purely synchronous implementation of IEventBus is provided in the form of SynchronousEventBus. This can be swapped in to ensure that Asynchronous events are published in a Synchronous manner.
