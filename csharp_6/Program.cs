using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

class Programm
{
    static int lines = 1;

    static void Main(string[] args)
    {
        char main_key;
        
        Console.Write("1 - показать данные. 2 - заполнить таблицу."); main_key = Console.ReadKey(true).KeyChar;


        if (char.ToLower(main_key) == '1')
        {
            ReadEmp();
        }
        else if(char.ToLower(main_key) == '2')
        {
            ReadEmpLines();

            WriteEmp();
        }
    }

    /// <summary>
    /// Преобразование файла в текст без знака "#"
    /// </summary>
    static void ReadEmp()
    {
        if (File.Exists("emp.csv"))
        {
            using (StreamReader sd = new StreamReader("emp.csv", Encoding.Unicode))
            {
                string[] words = sd.ReadToEnd().Split(new char[] { '#' });
                string joinedwords = string.Join(" ", words);

                Console.WriteLine($"\n{joinedwords}");
            }
        }
    }

    /// <summary>
    /// Подсчет количества строк в файле
    /// </summary>
    static void ReadEmpLines()
    {
        if (File.Exists("emp.csv"))
        {
            using (StreamReader sd = new StreamReader("emp.csv", Encoding.Unicode))
            {
                while ((sd.ReadLine()) != null)
                {
                    lines += 1;
                }
            }
        }
    }

    /// <summary>
    /// Запись данных в таблицу
    /// </summary>
    static void WriteEmp()
    {
        using (StreamWriter sw = new StreamWriter("emp.csv", true, Encoding.Unicode))
        {
            char key = 'd';

            do
            {
                string note = string.Empty;

                note += $"{lines}.#";

                string nowTime = DateTime.Now.ToShortDateString();
                note += $"{nowTime} ";
                string nowDay = DateTime.Now.ToShortTimeString();
                note += $"{nowDay}#";

                Console.Write("\nВведите Ф.И.О. сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("\nВведите возраст сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("\nВведите рост сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("\nВведите Дату Рождения сотрудника: ");
                note += $"{Console.ReadLine()}#";

                Console.Write("\nВведите Место рождения сотрудника: ");
                note += $"{Console.ReadLine()}";

                sw.WriteLine(note);
                Console.Write("Продолжить д/н"); key = Console.ReadKey(true).KeyChar;

                if (char.ToLower(key) == 'д')
                {
                    lines += 1;
                }

            } while (char.ToLower(key) == 'д');
        }
    }
}