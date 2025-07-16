namespace RudnTest
{
    public class Bag
    {
        public int ResourceAmount { get; private set; }

        public void AddResource()
        {
            ResourceAmount += 1;
        }

        public void RemoveResource()
        {
            ResourceAmount = 0;
        }
    }
}
