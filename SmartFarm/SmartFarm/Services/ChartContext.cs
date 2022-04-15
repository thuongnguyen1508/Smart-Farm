namespace SmartFarm.Services
{
    public class ChartContext : IChartContext
    {
        private IChartStrategy _strategy;

        public ChartContext()
        { }

        public ChartContext(IChartStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IChartStrategy strategy)
        {
            this._strategy = strategy;
        }

        public string ExecuteStrategy()
        {
            return this._strategy.NameOfFunctionWillExecute();
        }
    }
}
