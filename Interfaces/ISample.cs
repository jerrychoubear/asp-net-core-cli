namespace asp_net_core_cli.Interfaces
{
    public interface ISample
    {
        int Id { get; }
    }

    public interface ISampleTransient : ISample { }

    public interface ISampleScoped : ISample { }

    public interface ISampleSingleton : ISample { }
}