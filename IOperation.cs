using System;

public interface IOperation
{
    Guid Id {get;}
}

public interface ITransient:IOperation { }
public interface ISingleton:IOperation { }
public interface IScoped:IOperation { }
public interface ISingletonObject:IOperation { }