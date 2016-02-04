using Nsb.Messages;

namespace Nsb.PriceCalc.Service
{
    public static class PriceCalculator
    {
        public static int GetPrice(PriceRequestMessage request)
        {
            if (request.Count < 3)
            {
                return request.Count*request.Price;
            }

            return (request.Count - 1)*request.Price;
        }
    }
}
