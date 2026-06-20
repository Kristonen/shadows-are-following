public class Entity
{
    public int Id { get => _id;}

    private readonly int _id;

    public Entity(int id){
        _id = id;
    }
}