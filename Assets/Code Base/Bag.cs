using System;

namespace RudnTest
{
    [Serializable]
    public class Bag
    {
        public int ResourceAmount { get; private set; }

        public void AddResource()
        {
            ResourceAmount += 1;
        }

        public void RemoveAllResources()
        {
            ResourceAmount = 0;
        }
    }
}
