﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace ADO_NET_Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("COnnectionStr1", "SomeConnectionString"));
            config.Save();

            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (section.SectionInformation.IsProtected)
            {
                // Расшифровать секцию
                section.SectionInformation.UnprotectSection();
            }
            else
            {
                // Зашифровать секцию.
                section.SectionInformation.ProtectSection(
                    "DataProtectionConfigurationProvider");
            }

            // Сохранить файл конфигурации.
            config.Save();

            Console.WriteLine("Protected={0}", section.SectionInformation.IsProtected);

            Console.WriteLine(ConfigurationManager.ConnectionStrings["COnnectionStr1"].ConnectionString);

            Console.ReadKey();
        }
    }
}
