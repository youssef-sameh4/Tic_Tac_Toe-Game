using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum EChoose { PlayOneToOne = 1, PlayAI = 2, Exit = 3 }

class MainMenueGame
{
    EChoose Choose;
    private void ReturnToMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n---------------------------------------");
        Console.WriteLine("🔁 Press Enter to return to Main Menu");
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        Console.ReadLine(); 
        Main_Menue_Game();  
    }
    private short _PrintMenue()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n---------------------------------------");
        Console.WriteLine("          🎮  TIC TAC TOE MENU          ");
        Console.WriteLine("---------------------------------------");

        Console.WriteLine("  [1] 👥  Play One To One");

        Console.WriteLine("  [2] 🤖  Play vs Computer (AI)");

        Console.WriteLine("  [3] 🚪  Exit Game");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n👉 Choose an option: ");

        short choose;

        while (!short.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("❌ Invalid choice! Please enter (1, 2, or 3): ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        return choose;
    }
    public void Main_Menue_Game()
    {
        Choose = (EChoose)_PrintMenue();
        switch (Choose)
        {
            case EChoose.PlayOneToOne:
                CreatAGame game=new CreatAGame();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("🎯 Starting Player vs Player mode...");
                Thread.Sleep(1000);
                Console.Clear();
                game.StartGameONeToOne();
                ReturnToMainMenu();
                break;
                case EChoose.PlayAI:
                Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("🧠 Starting Player vs Computer mode...");
                    Thread.Sleep(1000);
                    Console.Clear();
                CreatAGame game2 = new CreatAGame();
                game2.StartGamePlayerVsComputer();
                ReturnToMainMenu();
                break;
            case EChoose.Exit:
                break;
        }
    }
}


