using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupProject
{

    abstract class Storage
    {
        public string Device { get; set; } = "Device";
        public string Model { get; set; }

        public const int File = 565;
        public Storage(string device, string model)
        {
            Device = device;
            Model = model;
        }


        public abstract void Volume(Storage device);
        public abstract void Copy(Storage device);
        public abstract void FreeMemory(Storage device);
        public abstract void DeviceInfo(Storage device);


    }


    class FlashDrive : Storage
    {
        private double Speed { get; set; } = default;
        double Memory { get; set; } = default;

        public FlashDrive(double speed, double memory, string device, string model) : base(device, model)
        {
            Speed = speed;
            Memory = memory;
        }

        public override void Volume(Storage device)
        {
            Console.WriteLine($"\n Storage : {Memory} GB");
        }
        public override void Copy(Storage device)
        {
            int value;
            double hour;
            Console.Write(" Total Storage of Files : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(File);
            Console.ResetColor();
            Console.WriteLine(" GB");

            Console.Write(" Storage of Flash Drive : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Memory);
            Console.ResetColor();
            Console.WriteLine(" GB");

            value = ((int)(File / Memory));
            Console.Write(" Required : ");
            hour = ((double)(File / Speed));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.ResetColor();
            Console.WriteLine(" pieces");
            Console.Write(" It will take : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{hour} Hours");
            Console.ResetColor();
            Console.Write(" to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Copy ");
            Console.ResetColor();
            Console.Write(" other device");
            Console.WriteLine();
            // Console.WriteLine(hour);

        }
        public override void FreeMemory(Storage device)
        {
            if (Memory > File)
            {
                double result;
                result = (double)Memory - File;
                Console.Write("\n Free Memory : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(result);
                Console.ResetColor();
                Console.WriteLine(" GB");
                Console.WriteLine();
            }
            else
            {

                try
                {
                    if (Memory < File)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n ERROR : ");
                        Console.ResetColor();
                        Console.WriteLine(" Not enough space ");
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
        public override void DeviceInfo(Storage device)
        {
            Console.WriteLine();
            Console.Write("\n Device : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Device);
            Console.ResetColor();
            Console.Write("\n Model : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Model);
            Console.ResetColor();
            Console.Write("\n Speed : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Speed);

            Console.WriteLine(".0");
            Console.ResetColor();
            Console.Write("\n Storage : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Memory);
            Console.ResetColor();
            Console.WriteLine(" GB");
            Console.WriteLine();

        }
    }
    class Dvd : Storage
    {
        private int ReadSpeed { get; set; } = default;
        private int WriteSpeed { get; set; } = default;
        private double DvdStorage { get; set; } = 0;
        private string Type { get; set; }

        public Dvd(int read_speed, int write_speed, double storage, string type, string device, string model) : base(device, model)
        {
            ReadSpeed = read_speed;
            WriteSpeed = write_speed;
            DvdStorage = storage;
            Type = type;
        }

        public override void Volume(Storage device)
        {

            Console.Write("\n Memory : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DvdStorage);
            Console.ResetColor();
            Console.WriteLine(" GB");
            Console.ResetColor();

        }

        public override void Copy(Storage device)
        {
            Console.WriteLine();
            int value2;
            double hour2;
            Console.Write(" Total Storage of Files : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(File);
            Console.ResetColor();
            Console.WriteLine(" GB");

            Console.Write(" Storage of Flash Drive : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DvdStorage);
            Console.ResetColor();
            Console.WriteLine(" GB");

            value2 = ((int)(File / DvdStorage));
            Console.Write(" Required : ");
            hour2 = ((double)(File / (ReadSpeed + WriteSpeed)));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value2);
            Console.ResetColor();
            Console.WriteLine(" pieces");
            Console.Write(" It will take : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{hour2} Hours");
            Console.ResetColor();
            Console.Write(" to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Copy ");
            Console.ResetColor();
            Console.Write(" other device");
            Console.WriteLine();
        }

        public override void FreeMemory(Storage device)
        {
            if (DvdStorage > File)
            {
                double result;
                result = (double)DvdStorage - File;
                Console.Write("\n Free Memory : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(result);
                Console.ResetColor();
                Console.WriteLine(" GB");
                Console.WriteLine();
            }
            else
            {

                try
                {
                    if (DvdStorage < File)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n ERROR : ");
                        Console.ResetColor();
                        Console.WriteLine(" Not enough space ");
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }

        public override void DeviceInfo(Storage device)
        {
            Console.WriteLine();
            Console.Write("\n Device : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Device);
            Console.ResetColor();
            Console.Write("\n Model : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Model);
            Console.ResetColor();
            Console.Write("\n Read Speed : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ReadSpeed);
            Console.WriteLine("x");
            Console.ResetColor();
            Console.Write("\n Write Speed : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(WriteSpeed);
            Console.WriteLine("x");
            Console.ResetColor();
            Console.Write("\n Storage : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DvdStorage);
            Console.ResetColor();
            Console.WriteLine(" GB");
            Console.WriteLine();
        }

    }
    class Hdd : Storage
    {
        private double ReadSpeed { get; set; } = default;
        private string Interface { get; set; }
        private string Brand { get; set; }
        private double HddVolume { get; set; } = 0;

        public Hdd(double read_speed, string interf, string brand, double volume, string device, string model) : base(device, model)
        {
            ReadSpeed = read_speed;
            Interface = interf;
            Brand = brand;
            HddVolume = volume;
        }

        public override void Volume(Storage device)
        {
            Console.WriteLine();
            Console.Write("\n Memory : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(HddVolume);
            Console.ResetColor();
            Console.WriteLine(" TB");
            Console.ResetColor();
            Console.WriteLine();
        }
        public override void Copy(Storage device)
        {
            Console.WriteLine();
            int value2;
            double hour2;
            Console.Write(" Total Storage of Files : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(File);
            Console.ResetColor();
            Console.WriteLine(" GB");

            Console.Write(" Storage of Flash Drive : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(HddVolume);
            Console.ResetColor();
            Console.WriteLine(" TB");

            value2 = ((int)(File / (HddVolume * 1000)));
            Console.Write(" Required : ");
            hour2 = ((double)(File / (HddVolume * 1000)));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value2);
            Console.ResetColor();
            Console.WriteLine(" pieces");
            Console.Write(" It will take : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{hour2} Hours");
            Console.ResetColor();
            Console.Write(" to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Copy ");
            Console.ResetColor();
            Console.Write(" other device");
            Console.WriteLine();
            Console.WriteLine();
        }
        public override void FreeMemory(Storage device)
        {
            if (HddVolume * 1000 > File)
            {
                double result;
                result = (double)(HddVolume * 1000) - File;
                Console.Write("\n Free Memory : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(result);
                Console.ResetColor();
                Console.WriteLine(" GB");
                Console.WriteLine();
            }
        }
        public override void DeviceInfo(Storage device)
        {
            Console.WriteLine();
            Console.Write("\n Device : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Device);
            Console.ResetColor();
            Console.Write("\n Model : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Model);
            Console.ResetColor();
            Console.Write("\n Read Speed : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ReadSpeed);
            Console.WriteLine(".0");
            Console.ResetColor();
            Console.Write("\n Hardware Interface : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Interface);
            Console.ResetColor();
            Console.Write("\n Brand : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Brand);
            Console.ResetColor();
            Console.Write("\n Storage : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(HddVolume);
            Console.ResetColor();
            Console.WriteLine(" TB");
            Console.WriteLine();

        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Storage flash = new FlashDrive(5, 16, "Flash Drive", "San-Disk");
            //flash.Volume(flash);
            //flash.Copy(flash);
            //flash.DeviceInfo(flash);
            // flash.FreeMemory(flash);
            //////////////////////////////////////////////////////////////////////////////
            Storage dvd = new Dvd(64, 64, 4.97, "CD-ROM", "DVD - Drive", "Panasonic");
            //dvd.Volume(dvd);
            //dvd.Copy(dvd);
            //dvd.DeviceInfo(dvd);
            //dvd.FreeMemory(dvd);
            //////////////////////////////////////////////////////////////////////////////
            Storage hdd = new Hdd(6, "SATA", "Seagate", 1, "HDD", "X300");
            //hdd.Volume(hdd);
            //hdd.Copy(hdd);
            //hdd.DeviceInfo(hdd);
            // hdd.FreeMemory(hdd);


        }
    }
}
