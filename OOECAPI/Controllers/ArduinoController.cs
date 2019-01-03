using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArduinoController : Controller
    {
        SerialPort arduino;

        public ArduinoController()
        {
            arduino = new SerialPort();
            arduino.PortName = "COM4";
            arduino.BaudRate = 9600;
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("temperature/{degree}")]
        public void Temperature(int degree)
        {
            try
            {
                for (int i = 0; i < degree; i++)
                {
                    arduino.Open();
                    arduino.Write(degree.ToString());
                    Thread.Sleep(1000);
                    arduino.Close();
                }
            }
            catch(Exception ex) { }
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("ready/{temp}")]
        public void ReadyToMatch(bool temp)
        {
            try
            {
                arduino.Open();
                arduino.Write("1");
                arduino.Close();
                if(!temp)
                {
                    arduino.Open();
                    Thread.Sleep(2000);
                    arduino.Write("2");
                    arduino.Close();
                }
            }
            catch (Exception ex) { }
        }
    }
}