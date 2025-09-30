using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_generate_random_shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            print_device_info();
            read_who_many_questions();
        }

        static void print_device_info()
        {
            Console.WriteLine("Windows version: {0}", Environment.OSVersion);
            Console.WriteLine("64 Bit operating system? : {0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
            Console.WriteLine("PC Name : {0}", Environment.MachineName);
            Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
            Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
        }
        static int read_who_many_questions()
        {
            int question = 0;
            Console.WriteLine("Please enter the maximum of questions: ");
            question = Convert.ToInt32(Console.ReadLine());

            while (question <= 0)
            {
                Console.WriteLine("The number of questions should be integer > 0, please enter it again: ");
                question = Convert.ToInt32(Console.ReadLine());
            }
            return question;
        }
    }
}
