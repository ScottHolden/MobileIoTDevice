using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileIoTDevice
{
    [Route("api/device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
		private static IoTDeviceService _ioTDeviceService;
		public DeviceController(IoTDeviceService ioTDeviceService)
		{
			_ioTDeviceService = ioTDeviceService;
		}
		[HttpPost("connect/{deviceId}")]
		public async Task<JsonResult> Post(string deviceId)
		{
			DeviceConnectionInfo deviceInfo = await _ioTDeviceService.ConnectDeviceAsync(deviceId);

			return new JsonResult(deviceInfo);
		}
	}
}