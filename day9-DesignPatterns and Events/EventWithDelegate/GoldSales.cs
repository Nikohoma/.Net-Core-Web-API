using System;
using System.Collections.Generic;
using System.Text;

namespace EventWithDelegate
{
    public class GoldSales
    {
        public static void Main(string[] args)
        {
            BuyGold buy = new BuyGold();
            EvaluateWeight eval = new EvaluateWeight();
            Payment pay = new Payment();

            // Subscriptions

            buy.OnBuying += eval.Weight;
            buy.OnBuying += pay.Pay;

            buy.SelectJewelery("Chain");

            Console.WriteLine();
            
            // For Necklace
            buy.OnBuying1 += eval.Weight;
            buy.OnBuying1 += pay.Pay;
            buy.SelectJewelery1("Necklace",10);

        }
    }

    public class Payment
    {
        public void Pay(string jewel)
        {
            Console.WriteLine($"Payment Received for {jewel}.");
        }

        public decimal Pay(string jewel, int w)
        {
            Console.WriteLine($"Payment Received for {w}g {jewel}.");
            return w * 10000;
        }
    }


    public class EvaluateWeight()
    {
        public void Weight(string jewel)
        {
            Console.WriteLine($"{jewel} Weight done.");
        }

        public decimal Weight(string jewel,int w)
        {
            Console.WriteLine($"Weight done for {w}g of {jewel}");
            return w;
        }
    }


    public class BuyGold
    {
        public event Action<string> OnBuying;
        public event Func<string,int,decimal> OnBuying1;

        public void SelectJewelery(string jewel)
        {
            Console.WriteLine($"Order Placed for {jewel}.");
            OnBuying?.Invoke(jewel);
        }
        public decimal SelectJewelery1(string jewel,int w)
        {
            Console.WriteLine($"Order Placed for {w}g {jewel}.");
            OnBuying1?.Invoke(jewel,10);
            return default;

        }

    }
}
