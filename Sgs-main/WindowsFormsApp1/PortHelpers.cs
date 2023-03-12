/*using System;
using System.IO.Ports;

namespace PortHelpers
{
    static void Main(string[] args)
    {
        SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        // Установите правильный порт COM и настройки последовательного порта для вашей системы

        try
        {
            serialPort.Open();

            // Включение источника питания
            serialPort.Write("OUTPut ON\n");
            Console.WriteLine("Источник питания включен");

            // Задержка для того, чтобы источник питания успел включиться
            System.Threading.Thread.Sleep(610000); // 10 минут 10 чекунд

            // Выключение источника питания
            serialPort.Write("OUTPut OFF\n");
            Console.WriteLine("Источник питания выключен");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            serialPort.Close();
        }
    }
}
*/