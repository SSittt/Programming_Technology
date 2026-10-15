namespace MedicalDevice
{
    public class Program
    {
        /// <summary>
        /// запускает программу и проверяет работу медицинских устройств
        /// </summary>
        /// <param name="args">аргумент командной строки</param>
        static void Main(string[] args)
        {
            // создаем спсиок для хранения медицинских устройств 
            List<MedicalDevice> devices = new List<MedicalDevice>();

            // создаем томограф, ренген и дефибриллятор
            MRI mri = new MRI("MRI001", "Siemens", 2500, 3.0);
            XRay xray = new XRay("XR001", "Philips", 800, 6.0);
            Defibrillator defibrillator = new Defibrillator("DEF001", "Zoll", 500, 360);

            // добавляем устройства в общий список 
            devices.Add(mri);
            devices.Add(xray);
            devices.Add(defibrillator);

            // перебираем все устройства из списка 
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
                // разделение 
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
