using System;
using System.Threading.Tasks;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace DriverTest1
{
    class Program
    {
        protected short AxisX = 0;
        protected short AxisY = 0;
        static void Main()
        {
            Program a = new();
            IXbox360Controller controller = new ViGEmClient().CreateXbox360Controller();
            controller.Connect();
            controller.SetButtonState(Xbox360Button.A, true);

            while(true)
            {
                if (a.AxisX > 30760 || a.AxisX < -30760) { a.AxisX = 0; }
                if (a.AxisY > 30760 || a.AxisY < -30760) { a.AxisY = 0; }

                Console.WriteLine("\nAxisX" + a.AxisX);
                Console.WriteLine("\nAxisY" + a.AxisY);
                string[] x = (InputData()).Split(" ");
                controller.SetAxisValue(Xbox360Axis.LeftThumbX, Convert.ToInt16(x[0]));
                controller.SetAxisValue(Xbox360Axis.LeftThumbY, Convert.ToInt16(x[1]));
            }
        }

        static String InputData()
        {
            Console.WriteLine("\nEnter X/Y Axis Value -32760 to 32760");
            string data = Console.ReadLine();
            return data;
        }
    }
}
