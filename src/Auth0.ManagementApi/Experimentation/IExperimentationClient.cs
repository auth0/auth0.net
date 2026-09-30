namespace Auth0.ManagementApi.Experimentation;

public partial interface IExperimentationClient
{
    public IExperimentsClient Experiments { get; }
    public IFeatureFlagsClient FeatureFlags { get; }
    public ISegmentsClient Segments { get; }
}
