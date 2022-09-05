using Moq.AutoMock;

namespace ChickAndPaddy.Tests;

public abstract class UnitTestBase<T> where T : class
{
    protected T Sut { get; private set; }
    protected AutoMocker Mocker { get; private set; }

    protected UnitTestBase()
    {
        Mocker = new AutoMocker();

        // ReSharper disable once VirtualMemberCallInConstructor
        RegisterInstances();

        Sut = Mocker.CreateInstance<T>();
    }

    protected virtual void RegisterInstances()
    {
        //Mocker.Use(Mocker.CreateInstance<TodosService>());
    }
}
