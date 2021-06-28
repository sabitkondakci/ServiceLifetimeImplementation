using System;
public class ServiceOne:IServiceMarkerOne
{
    public ServiceOne(
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
        Console.WriteLine(new String('-',60)+"\n");
        Console.WriteLine("Service Lifetime Test, ServiceOne");
        Console.WriteLine($"Singleton - {Singleton.Id}");
        Console.WriteLine($"Singleton Object - {SingObject.Id}");
        Console.WriteLine($"Scoped - {Scoped.Id}");
        Console.WriteLine($"Transient - {Transient.Id}\n");
    }
}
