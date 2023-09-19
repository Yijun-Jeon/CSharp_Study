using System;
namespace Delegate_Event
{
    delegate void MyDelegate(int a);

    class Market
    {
        public event MyDelegate CustomerEvent;

        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo % 30 == 0)
                CustomerEvent(CustomerNo);
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(delegate (int num)
            {
                Console.WriteLine("축하합니다! "+ num + "번째 고객 이벤트에 당첨되셨습니다.");
            });

            for (int customerNo = 0; customerNo < 100; customerNo += 10)
                market.BuySomething(customerNo);
        }
    }
}