namespace AdventOfCode.Models
{
    public class DepthData
    {
        private List<int> _depthValues;
        public int DepthId { get; private set; }

        public DepthData(int depthId)
        {
            DepthId = depthId;
            _depthValues = new List<int>();
        }

        public List<int> GetDepthValues() => _depthValues.ToList();
        public bool IsFull => _depthValues.Count > 2;

        public void AddDepthValue(int depthValue)
        {
            if (IsFull)
            {
                throw new Exception("Not allowed to have more than 3 depth values in a depth data");
            }

            _depthValues.Add(depthValue);
        }
    }
}
