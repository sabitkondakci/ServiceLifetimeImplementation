using System;
public class ServiceTwo : IServiceMarkerTwo
{
    public ServiceTwo(
        ISingleton singleton,
        ISingletonObject singObject,
        IScoped scoped,
        ITransient transient)
    {
        Singleton = singleton;
        SingObject = singObject;
        Scoped = scoped;
        Transient = transient;
    }

    private ISingleton Singleton { get; }
    private ISingletonObject SingObject { get; }
    private IScoped Scoped { get; }
    private ITransient Transient { get; }

    public void PrintConsole()
    {
        Console.WriteLine("Service Lifetime Test , ServiceTwo");
        Console.WriteLine($"Singleton - {Singleton.Id}");
        Console.WriteLine($"Singleton Object - {SingObject.Id}");
        Console.WriteLine($"Scoped - {Scoped.Id}");
        Console.WriteLine($"Transient - {Transient.Id}\n");
        Console.WriteLine(new String('-',60)+"\n");
    }
}
