public class ECS
{
    public int CurrentEntityId { get => _currentEntityId; }
    public CustomList<ISystem> Systems { get => _systems; set => _systems = value; }
    public Dictionary<int, CustomList<IComponent>> Storage { get => _storage; set => _storage = value; }
    private CustomList<ISystem> _systems;
    private Dictionary<int, CustomList<IComponent>> _storage;
    private int _currentEntityId;

    public ECS(){
        _storage = new();
        _systems = new();
        _currentEntityId = 1;
    }

    public Entity CreateEntity()
    {
        Entity entity = new(_currentEntityId);
        _currentEntityId += 1;
        return entity;
    }

    public void AddComponent(int entityId, IComponent component)
    {
        if(!_storage.ContainsKey(entityId))
        {
            _storage[entityId] = new();
        }
        _storage[entityId].Add(component);    
    }

    public void AddComponent(Entity entity, IComponent component)
    {
        AddComponent(entity.Id, component);
    }

    public bool HasComponent<T>(int entityId) where T : class, IComponent
    {
        if(!_storage.ContainsKey(entityId)) return false;
        for(int i = 0; i < _storage[entityId].Count; i++)
        {
            IComponent component = _storage[entityId][i];
            if(component is T)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasComponent<T>(Entity entity) where T : class, IComponent
    {
        return HasComponent<T>(entity.Id);
    }

    public (T component, bool ok)GetComponent<T>(int entityId) where T : class, IComponent
    {
        if(!_storage.ContainsKey(entityId)) return (default!, false);
        for(int i = 0; i < _storage[entityId].Count; i++)
        {
            IComponent component = _storage[entityId][i];
            if(component is T foundedComponent)
            {
                return (foundedComponent, true);
            }
        }
        return (default!, false);
    }

    public (T component, bool ok)GetComponent<T>(Entity entity) where T : class, IComponent
    {
        return GetComponent<T>(entity.Id);
    }
}