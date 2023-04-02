using System;
using System.IO.Ports;

namespace Reles
{

    class Program
    {
        static void Rele(string[] args)
        {
            // Создаем новый объект SerialPort для работы с портом
            SerialPort port = new SerialPort("COM3", 9600);

            // Открываем порт
            port.Open();

            // Отправляем команду "on" для включения реле
            port.WriteLine("on");

            // Закрываем порт
            port.Close();
        }
    }
}