public class ECS
{
    public CustomList<ISystem> Systems { get => _systems; set => _systems = value; }
    public Dictionary<int, CustomList<IComponent>> Storage { get => _storage; set => _storage = value; }
    private CustomList<ISystem> _systems;
    private Dictionary<int, CustomList<IComponent>> _storage;
    private int _currentEntityId;

    public ECS(){
        _storage = new();
        _systems = new();
        _currentEntityId = 0;
    }
}