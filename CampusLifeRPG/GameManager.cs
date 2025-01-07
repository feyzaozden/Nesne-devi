using System;
using System.Collections.Generic;
using CampusLifeRPG.Locations;

namespace CampusLifeRPG
{
    public class GameManager
    {
        private readonly Player _player;
        private readonly TimeManager _timeManager;
        private readonly GameMap _gameMap;
        private bool _hasAttendedClass;
        private bool _hasVisitedLibrary;
        private BaseLocation _lastLocation;

        public GameManager(string playerName)
        {
            _player = new Player(playerName);
            _timeManager = new TimeManager();
            _gameMap = new GameMap();
            _hasAttendedClass = false;
            _hasVisitedLibrary = false;
            _lastLocation = null;
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine($" ");
            Console.WriteLine($"HOŞGELDİNİZ {_player.Name}!");
            Console.WriteLine($"Kampüs Hayatına Hoş Geldiniz!");
            Console.WriteLine($"\n");

            Console.WriteLine("Güne yurtta başlıyorsunuz. Şimdi nereye gitmek istiyorsunuz?");
            Console.WriteLine("(W,A,S,D tuşlarıyla hareket edebilir, E tuşu ile bulunduğunuz yerde kalabilirsiniz)\n");

            _player.ResetStats();
            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                try
                {
                    _gameMap.DrawMap();
                    DisplayStatus();

                    if (_timeManager.IsEvening())
                    {
                        Console.WriteLine("\nAkşam oldu! Yurda dönmen gerekiyor.");
                        ForceReturnToDormitory();
                        break;
                    }

                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Q)
                        break;

                    ProcessMovement(key);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                    Console.WriteLine("Devam etmek için bir tuşa basın...");
                    Console.ReadKey(true);
                }
            }
        }

        private void DisplayStatus()
        {
            Console.WriteLine($"\n═══════════ ZAMAN: {_timeManager.CurrentTime} ═══════════");
            _player.DisplayStatus();
            Console.WriteLine("════════════════════════════════════");
        }

        private void ProcessMovement(ConsoleKey key)
        {
            var currentLocation = _gameMap.GetCurrentLocation();

            if (key == ConsoleKey.E)
            {
                if (currentLocation != null)
                {
                    Console.WriteLine($"\nŞu an {currentLocation.Name}'da kalmaya devam ediyorsunuz.");
                    if (_timeManager.CurrentTime == DayTime.Morning && currentLocation is Dormitory)
                    {
                        Console.WriteLine("Sabah vaktini yurtta geçirmeyi tercih ettiniz. Mutluluk seviyeniz sıfırlandı!");
                        _player.UpdateStats(0, 0, -100, 0);
                    }
                    currentLocation.Visit(_player);
                    _timeManager.AdvanceTime();
                }
                return;
            }

            if (_timeManager.IsEvening() && !(currentLocation is Dormitory))
            {
                Console.WriteLine("Akşam oldu! Sadece yurda gidebilirsin!");
                return;
            }

            if (_gameMap.MovePlayer(key))
            {
                var newLocation = _gameMap.GetCurrentLocation();
                if (newLocation != null && newLocation != _lastLocation)
                {
                    Console.WriteLine($"\nŞu an {newLocation.Name}'dasınız.");

                    if (_timeManager.CurrentTime == DayTime.Morning &&
                        !(newLocation is Classroom) &&
                        !(newLocation is Library) &&
                        !(newLocation is Dormitory))
                    {
                        Console.WriteLine("Sabah vaktini ders dışı aktivitelere harcadınız! Akademik başarınız sıfırlandı!");
                        _player.UpdateStats(0, -100, 0, 0);
                    }

                    newLocation.Visit(_player);
                    _timeManager.AdvanceTime();
                    _lastLocation = newLocation;

                    if (newLocation is Classroom)
                        _hasAttendedClass = true;
                    else if (newLocation is Library)
                        _hasVisitedLibrary = true;
                }
            }
        }

        private void ForceReturnToDormitory()
        {
            Console.WriteLine("\nYurda dönüyorsunuz ve uyumaya hazırlanıyorsunuz...");
            var dormitory = new Dormitory();
            dormitory.Sleep(_player);
            _timeManager.ResetDay();
            _hasAttendedClass = false;
            _hasVisitedLibrary = false;
            _lastLocation = null;
            Console.WriteLine("\nYeni güne başlamak için bir tuşa basın...");
            Console.ReadKey(true);
        }
    }
}
