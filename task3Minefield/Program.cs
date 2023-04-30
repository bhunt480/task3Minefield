namespace Minefield
{
    class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            Minefield mf = new Minefield(ReadInput());

            try
            {
                mf.Solve();
            }
            catch (Exception e)
            {
                mf.Display();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n{0}", e.Message);
                Console.ResetColor();
            }
        }
    
        //Input Method
        static Field[][] ReadInput()
        {
            List<Field[]> minefield = new List<Field[]>();

            Console.WriteLine("Please enter minefield dimension nxm Eg.: 6 6");
            string? line = Console.ReadLine();
            string[] dimension = line!.Split(' ');
            int n = Convert.ToInt32(dimension[0]);
            int m = Convert.ToInt32(dimension[1]);
            Console.WriteLine("Please fill up your minefield with 'B' for Bomb and 'E' for Empty. B B E B B B");
      
            while (n-- > 0)
            {
                List<Field> fields = new List<Field>();
                line = Console.ReadLine();
                foreach (var c in line!.Split(' '))
                {
                    switch (c)
                    {
                        case "E":
                            fields.Add(Field.Empty);
                            break;
                        case "S":
                            throw new Exception("You can only fill with 'Bomb' field and 'Empty' field");
                        case "B":
                            fields.Add(Field.Bomb);
                            break;
                        default:
                            throw new Exception("You can only fill with 'B' field and 'E' field");
                    }
                }
                minefield.Add(fields.ToArray());
            }

            return minefield.ToArray();
        }
    }
}