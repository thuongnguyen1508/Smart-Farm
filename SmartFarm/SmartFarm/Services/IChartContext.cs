namespace SmartFarm.Services
{
    public interface IChartContext
    {
        void SetStrategy(IChartStrategy strategy);

        string ExecuteStrategy();
    }
}
