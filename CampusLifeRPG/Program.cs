using System;

namespace CampusLifeRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Title = "Kampüs Hayatı RPG";

                Console.WriteLine("Kampüs Hayatı RPG'ye Hoş Geldiniz!");
                Console.Write("Lütfen karakterinizin adını girin: ");
                string playerName = Console.ReadLine() ?? "Öğrenci";


                var game = new GameManager(playerName);
                game.StartGame();

                Console.WriteLine("\nOyun bitti. Görüşmek üzere!");
                Console.Write("Çıkmak için bir tuşa basın...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu: {ex.Message}");
                Console.WriteLine("Çıkmak için bir tuşa basın...");
                Console.ReadKey(true);
            }
        }
    }
}
