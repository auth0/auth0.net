namespace Auth0.ManagementApi.Experimentation;

public partial interface IExperimentationClient
{
    public IExperimentsClient Experiments { get; }
}
