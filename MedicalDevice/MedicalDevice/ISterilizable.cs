using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDevice
{
    /// <summary>
    /// интерфейс для медицинских устройств, которые можно стерилизовать
    /// </summary>
    public interface ISterilizable
    {
        /// <summary>
        ///  выполняет стерилизацию устройства
        /// </summary>
        void Sterilize();
    }
}
