using System;

class Program
{
    static void Main(string[] args)
    {
        Snake snk = new Snake(3, "@@@", "nowhere");
        snk.eEating += snk.Eat;
        snk.eChangeDirection += snk.changeDirection;
        snk.eGameOver += snk.GameOver;
        Console.WriteLine("Hello! I'm your Snake ");
        Console.WriteLine(snk.SnakeS);
        
        while (snk.Length < Snake.maxLenght)
        {
            Console.WriteLine("Where I'll go? Choose direction from W-A-S-D");
            string direction = Console.ReadLine();
            snk.newDirection(direction);
            snk.ifEat();           
            Console.WriteLine(snk.SnakeS);
        }
        snk.ifGameOver();
    }

    class Snake
    {
        public delegate void SnakeMove();
        public event SnakeMove? eEating;
        public event SnakeMove? eChangeDirection;
        public event SnakeMove? eGameOver;

        public static int maxLenght = 10;
        public int Length { get; set; }
        public string SnakeS { get; set; }
        public string Direction { get; set; }

        public Snake(int length, string snake, string direction)
        {
            Length = length; 
            SnakeS = snake; 
            Direction = direction; 
        }    
        
        public void ifEat()
        {
            var rand = new Random();
            if (rand.Next(2) == 1 && Direction != "nowhere") eEating?.Invoke();                          
           
        }

        public void Eat()
        {
            SnakeS += "@";
            Length++;
            Console.WriteLine("I'm eat somethng! My lenght now " + Length);
        }

        public void newDirection(string direction)
        {
            switch (direction)
            {
                case "W":
                case "w":
                    Direction = "north";                    
                    break;

                case "A":
                case "a":
                    Direction = "west";
                    break;

                case "D":
                case "d":
                    Direction = "east";
                    break;

                case "S":
                case "s":
                    Direction = "south";
                    break;

                default:
                    Direction = "nowhere"; ;
                    break;
            }

            eChangeDirection?.Invoke();
        }

        public void changeDirection()
        {
            Console.WriteLine("I go to " + Direction + "!");
        }

        public void ifGameOver()
        {
            if (Length >= maxLenght) eGameOver?.Invoke();
        }
        public void GameOver()
        {
            Console.WriteLine("I'm too fat, my lenght already " + maxLenght + "! Thanks and good bye!");
        }

    }
}
