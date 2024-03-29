﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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
                string programPath = @"C:\\Users\\1\\Desktop\\TarEmu1\\TarEmu1\\TarEmu.exe";
                string programArgument = "";
                // Запускаем приложение Блокнот
                ProcessStartInfo startInfo = new ProcessStartInfo(programPath, programArgument);
                Process process = new Process();
                process.StartInfo = startInfo;

                // Ждем 10 минуту
                Thread.Sleep(600000);

                // Делаем скриншот и сохраняем его в файл в папке для скриншотов
                SendKeys.Send("{PRTSC}");
                Image screenshot = Clipboard.GetImage();
                string filePath = Path.Combine(folderPath, "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Закрываем приложение Блокнот
                Process[] processes = Process.GetProcessesByName("notepad");
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
