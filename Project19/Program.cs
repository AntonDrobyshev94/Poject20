using Microsoft.AspNetCore;

namespace Project19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //try
            //{
            //    Repository.Open("JsonCoolection");
            //    CurrentId();
            //}
            //catch
            //{

            //}

            //Repository.Add("Иванов", "Иван", "Иванович", "123456", "Москва",
            //    "Слесарь");
            //Repository.Add("Петров", "Пётр", "Петрович", "789012", "Санкт-Петербург",
            //    "Водитель");
            //Repository.Add("Александров", "Александр", "Александрович", "345678", "Новосибирск",
            //    "Знакомый");

            //Repository.Save("JsonCoolection");

            CreateWebHostBuilder(args).Build().Run(); //настройка сервера
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        ///// <summary>
        ///// Метод определения текущего ID
        ///// </summary>
        //static public void CurrentId()
        //{
        //    for (int i = Repository.db.Count - 1; i < Repository.db.Count; i++)
        //    {
        //        Repository.individualId = Repository.db[i].ID;
        //    }
        //}
    }
}