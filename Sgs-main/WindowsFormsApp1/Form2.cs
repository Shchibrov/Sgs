﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Automation;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Получаем название папки для скриншотов из TextBox
            string folderName = textBox1.Text.Trim();

            // Создаем папку для скриншотов, если она не существует
            string folderPath = Path.Combine(@"D:\Screenshots", folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            for (int i = 0; i < 3; i++)
            {
                string tarEmuPath = @"D:\TarEmu\TarEmu.exe";
                string args = @"=BINS_U.ini";
                Process.Start(tarEmuPath, args);

                // Создаем новый объект SerialPort для работы с портом
                SerialPort port = new SerialPort("COM1", 9600);

                // Открываем порт
                port.Open();

                // Отправляем команду "on" для включения реле
                port.WriteLine("on");

                Thread.Sleep(6000); // Ждем, пока процесс загрузится

                SendKeys.Send("{F9}"); // имитируем нажатие клавиши F9

                Thread.Sleep(1000); // пауза перез нажатием F2

                SendKeys.Send("{F2}");// имитируем нажатие клавиши F2

                Thread.Sleep(600000); // запуск 10 минут
                
                SendKeys.Send("{F2}"); // отжатие кнопки записи 

                // Делаем скриншот и сохраняем его в файл в папке для скриншотов
                SendKeys.Send("{PRTSC}");

                // Закрываем порт
                port.Close();

                Image screenshot = Clipboard.GetImage();
                string filePath = Path.Combine(folderPath, "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Закрываем приложение Taremu
                Process[] processes = Process.GetProcessesByName("TarEmu");
                for (int i1 = 0; i1 < processes.Length; i1++)
                {
                    processes[i1].Kill();
                }

                // Ждем 5 секунд перед повторным запуском
                Thread.Sleep(5000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем название папки для скриншотов из TextBox
            string folderName = textBox1.Text.Trim();

            // Создаем папку для скриншотов, если она не существует
            string folderPath = Path.Combine(@"D:\Screenshots", folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            for (int i = 0; i < 7; i++)
            {
                // Запускаем приложение Блокнот
                Process.Start("notepad.exe");

                // Ждем 10 минуту
                Thread.Sleep(6000);

                // Делаем скриншот и сохраняем его в файл в папке для скриншотов
                SendKeys.Send("{PRTSC}");
                Image screenshot = Clipboard.GetImage();
                string filePath = Path.Combine(folderPath, "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Закрываем приложение Блокнот
                Process[] processes = Process.GetProcessesByName("notepad");
                foreach (Process process in processes)
                {
                    process.Kill();
                }

                // Ждем 5 секунд перед повторным запуском
                Thread.Sleep(5000);
            }
            Application.Exit();
        }
        
    }
}
