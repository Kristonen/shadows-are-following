using System.Runtime.CompilerServices;

namespace Tests;

[TestFixture]
public class EcsRegistryTest
{
    [SetUp]
    public void Setup()
    {
    }

    private class TestComponent : IComponent{}
    private class ComponentValue : IComponent
    {
        public int Value { get => _value; set => _value = value; }
        private int _value;
    }

    [Test]
    public void GetComponent_ByEntity_ReturnComponentAndTrue()
    {
        ECS ecs = new();
        var entity = ecs.CreateEntity();
        var expectedComponent = new TestComponent();
        ecs.AddComponent(entity, expectedComponent);
        var (component, ok) = ecs.GetComponent<TestComponent>(entity);

        Assert.That(ok, Is.True);
        Assert.That(component, Is.Not.Null);
        Assert.That(component, Is.EqualTo(expectedComponent));
    }

    [Test]
    public void GetComponent_ByEntity_ReturnComponentWithRightValue()
    {
        ECS ecs = new();
        ComponentValue expectedComponent = new();
        int expectedValue = 5;
        expectedComponent.Value = expectedValue;
        var entity = ecs.CreateEntity();
        ecs.AddComponent(entity, expectedComponent);
        var (component, ok) = ecs.GetComponent<ComponentValue>(entity);

        Assert.That(ok, Is.True);
        Assert.That(component.Value, Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetComponent_WhenComponentNotExist_ReturnDefaultAndFalse()
    {
        ECS ecs = new();
        var entity = ecs.CreateEntity();
        ecs.AddComponent(entity, new TestComponent());
        ComponentValue other = new();
        var (component, ok) = ecs.GetComponent<ComponentValue>(entity);
        Assert.That(ok, Is.False);
        Assert.That(component, Is.Null);
    }

    [Test]
    public void CheckCurrentEntityId_WhenEntitiesAreCreated_IncreaseCorrectly()
    {
        ECS ecs = new();
        Assert.That(ecs.CurrentEntityId, Is.EqualTo(1));

        ecs.CreateEntity();
        ecs.CreateEntity();
        ecs.CreateEntity();

        Assert.That(ecs.CurrentEntityId, Is.EqualTo(4));
    }
}
