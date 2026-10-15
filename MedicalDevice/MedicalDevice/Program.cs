namespace MedicalDevice
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<MedicalDevice> devices = new List<MedicalDevice>();


            MRI mri = new MRI("MRI001", "Siemens", 2500, 3.0);
            XRay xray = new XRay("XR001", "Philips", 800, 6.0);
            Defibrillator defibrillator = new Defibrillator("DEF001", "Zoll", 500, 360);

            devices.Add(mri);
            devices.Add(xray);
            devices.Add(defibrillator);

            foreach (MedicalDevice device in devices)
            {
                Console.WriteLine(device);
                Console.WriteLine($" power hungry: {device.IsRowIsPowerHungry}");
                device.Operate();

                if (device is ISterilizable sterilizable)
                {
                    sterilizable.Sterilize();
                }
                else
                {
                    Console.WriteLine($"{device.Name} cannot be sterilized.");
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
