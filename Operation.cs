using System;

public class Operation : ISingleton,ITransient,IScoped,ISingletonObject
{
    public Operation(Guid id) {Id = id;}
    public Operation():this(Guid.NewGuid()) { }
    public Guid Id {get;}
}