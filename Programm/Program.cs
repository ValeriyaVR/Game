using System;

namespace ProgramGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] map =
            {
                {'_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_'},
                {'|',' ',' ','$','|',' ',' ',' ',' ',' ',' ','|','$','|',' ',' ',' ',' ',' ',' ',' ',' ','$','|'},
                {'|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ','|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ','|',' ',' ','|',' ','|',' ',' ','_','_','_',' ',' ',' ',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ',' ',' ','|'},
                {'|',' ','_','_','|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ','$','|',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|','_','_','_','_','_','_','_','_','_','_','_','_','_','|',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ','$','|',' ','$',' ',' ',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|',' ',' ','_','_','_','_','_','_','_','|',' ',' ',' ',' ',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ','|',' ','|'},
                {'|',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','_','_','_','_','_','_','_',' ','|'},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ','$','|',' ',' ',' ',' ','|'},
                {'|',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ','_','_','|',' ',' ',' ',' ','|'},
                {'|',' ','|',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ','|',' ',' ',' ','|',' ',' ',' ',' ','|'},
                {'|',' ','|',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ','|',' ',' ',' ','|',' ',' ',' ',' ','|'},
                {'|',' ','|',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ',' ',' ','|'},
                {'|','$','|',' ',' ',' ',' ','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
                {'|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','|'}
            };
            Random random = new Random();
            int userX = random.Next(1,18); 
            int userY = random.Next(1,23);

            Console.CursorVisible = false;
            char[] bag = new char[1];

            while(true){

                for(int i = 0; i < map.GetLength(0); i++)
                {   
                    for(int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i,j]);
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0,23);
                Console.Write("Bag: ");
                for(int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(userY,userX);
                Console.Write('@');
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch(keyInfo.Key){
                    case  ConsoleKey.UpArrow:
                    if(map[userX - 1, userY] != '|' && map[userX - 1, userY] != '-' && map[userX - 1, userY] != '_')
                    {
                        userX--;
                    }
                    break;
                    case ConsoleKey.DownArrow:
                    if(map[userX + 1, userY] != '|' && map[userX + 1, userY] != '-' && map[userX + 1, userY] != '_')
                    {
                        userX++;
                    }
                    break;
                    case ConsoleKey.LeftArrow:
                    if(map[userX, userY - 1] != '|' && map[userX, userY - 1] != '-' && map[userX, userY - 1] != '_')
                    {
                        userY--;
                    }
                    break;
                    case ConsoleKey.RightArrow:
                    if(map[userX, userY + 1] != '|' && map[userX, userY + 1] != '-' && map[userX, userY + 1] != '-')
                    {
                        userY++;
                    }
                    break;

                }

                if(map[userX,userY] == '$')
                {
                    map[userX,userY] = 'o';
                    char[] tempChar = new char[bag.Length + 1];
                    for(int i = 0; i < bag.Length; i++)
                    {
                        tempChar[i] = bag[i];
                    }
                    tempChar[tempChar.Length - 1] = '$';
                    bag = tempChar;
                } 

                if (bag.Length == 9)
                {
                    Console.SetCursorPosition(0,20);
                    Console.WriteLine("Congratulations! You won!");
                    map[0,1] = ' ';
                    map[0,2] = ' ';
                    map[0,3] = ' ';

                }

                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}