using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class CreatAGame
{
    char[,] _matrix = {
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
};
    private Random rand = new Random();
    private char _player = 'X';
    private char _computer = 'O';
    private void _PrintMatrix()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\t╔═══════╦═══════╦═══════╗");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("\t║");
            for (int j = 0; j < 3; j++)
            {

                if (_matrix[i, j] == 'X')
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else if (_matrix[i, j] == 'O')
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"   {_matrix[i, j]}   ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("║");
            }

            Console.WriteLine();
            if (i < 2)
                Console.WriteLine("\t╠═══════╬═══════╬═══════╣");
            else
                Console.WriteLine("\t╚═══════╩═══════╩═══════╝");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

    }
    private void Play(char currentTurn)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"🧍 Player ({currentTurn}), choose your position (1-9): ");

        char position;
        if (!char.TryParse(Console.ReadLine(), out position))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Invalid input. Try again!");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (_matrix[i, j] == position)
                {
                    _matrix[i, j] = currentTurn;


                    return;
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ That position is already taken or invalid. Try again!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    private char _WhoWin()
    {
        short countx = 0, counto = 0;
        short counter = 0;
        //row
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (_matrix[i, j] != 'X' && _matrix[i, j] != 'O') counter++;
                if (_matrix[i, j] == 'X') countx++;
                else if (_matrix[i, j] == 'O') counto++;
                if (countx == 3 || counto == 3)
                {
                    return counto > countx ? 'O' : 'X';
                }

            }
            countx = counto = 0;
        }
        //colm
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (_matrix[j, i] == 'X') countx++;
                else if (_matrix[j, i] == 'O') counto++;
                if (countx == 3 || counto == 3)
                {
                    return counto > countx ? 'O' : 'X';
                }

            }
            countx = counto = 0;
        }

        if (_matrix[0, 0] == 'X' && _matrix[1, 1] == 'X' && _matrix[2, 2] == 'X') return 'X';
        else if (_matrix[0, 0] == 'O' && _matrix[1, 1] == 'O' && _matrix[2, 2] == 'O') return 'O';
        else if (_matrix[0, 2] == 'O' && _matrix[1, 1] == 'O' && _matrix[2, 0] == 'O') return 'O';
        else if (_matrix[0, 2] == 'X' && _matrix[1, 1] == 'X' && _matrix[2, 0] == 'X') return 'X';

        if (counter == 0) return 'Z';

        return '.';

    }
    private void _PlayComputer()
    {
        List<(int, int)> freeCells = new List<(int, int)>();

        // جمع كل الخانات الفارغة
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_matrix[i, j] != 'X' && _matrix[i, j] != 'O')
                {
                    freeCells.Add((i, j));
                }
            }
        }

        if (freeCells.Count == 0) return; // لو ما فيش خانات فاضية

        // اختيار خانة عشوائية من الخانات الفارغة
        var (iChosen, jChosen) = freeCells[rand.Next(freeCells.Count)];
        char chosen = _matrix[iChosen, jChosen];
        _matrix[iChosen, jChosen] = _computer;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\n💻 Computer chose position {chosen}");
        Console.ForegroundColor = ConsoleColor.White;
        _PrintMatrix();
    }

    private void _ShowWinner()
    {
        char winner = _WhoWin();
        if (winner != 'Z')
        {
            Console.ForegroundColor = winner == 'X' ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;
            Console.WriteLine($"\n🏆 The Player ({winner}) Wins!");

        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🤝 It's a Draw!");
        }
    }
    public void StartGamePlayerVsComputer()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("     🎮 TIC TAC TOE - Player vs AI 🎮   ");
        Console.WriteLine("=======================================\n");

        bool computerStarts = rand.Next(0, 2) == 0;

        _computer = computerStarts ? 'X' : 'O';
        _player = _computer == 'X' ? 'O' : 'X';

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"💻 Computer will play as '{_computer}'");
        Console.WriteLine($"🧍 You will play as '{_player}'");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPress any key to start...");
        Console.ReadKey();

        while (_WhoWin() == '.')
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("     🎮 TIC TAC TOE - Player vs AI 🎮   ");
            Console.WriteLine("=======================================\n");


            if (computerStarts)
            {
                Thread.Sleep(300);
                _PlayComputer();
                if (_WhoWin() != '.') break;
                Play(_player);
            }
            else
            {
                _PrintMatrix();

                Play(_player);
                if (_WhoWin() != '.') break;
                Thread.Sleep(500);
                _PlayComputer();
            }
        }

        Console.Clear();
        _PrintMatrix();
        _ShowWinner();
    }

    public void StartGameONeToOne()
    {
        char currentTurn = 'X';
        while (_WhoWin() == '.')
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("         🎮 TIC TAC TOE GAME 🎮        ");
            Console.WriteLine("=======================================");
            _PrintMatrix();
            Play(currentTurn);
            currentTurn = currentTurn == 'X' ? 'O' : 'X';
        }
        Console.Clear();
        _PrintMatrix();

        _ShowWinner();
    }
}

