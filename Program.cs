using System.Text;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MainMenueGame mainMenu=new MainMenueGame();
            mainMenu.Main_Menue_Game();
        }
    }
}
