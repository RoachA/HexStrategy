public class Food : IMapResource
{
    private IMapResource _mapResourceImplementation;
    public float Value { get; set; }
    public MapResourceType ResourceType { get; set; }
}
