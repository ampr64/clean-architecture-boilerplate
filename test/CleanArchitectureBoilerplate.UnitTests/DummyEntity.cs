namespace CleanArchitectureBoilerplate.UnitTests
{
    public class DummyEntityIntId : Entity<int>
    {
        public DummyEntityIntId(int id) => Id = id;
    }

    public class DummyEntityStringId : Entity<string>
    {
        public DummyEntityStringId(string id) => Id = id;
    }

    public class DummyEntityStringId2 : Entity<string>
    {
        public DummyEntityStringId2(string id) => Id = id;
    }
}