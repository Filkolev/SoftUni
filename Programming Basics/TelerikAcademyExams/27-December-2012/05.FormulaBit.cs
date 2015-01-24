using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/265

class FormulaBit
{
    static void Main()
    {
        int[] track = new int[8];

        for (int i = 0; i < 8; i++)
        {
            track[i] = int.Parse(Console.ReadLine());
        }

        string direction = "south";
        
        bool deadEnd = false;
        int lengthOfTrack = 0;
        int numberOfTurns = 0;

        int currentRow = 0;
        int currentColumn = 0;

        bool south = true;
        bool turnedLastTime = false;        

        while (!deadEnd)
        {
            int bit = (track[currentRow] >> currentColumn) & 1;

            if (bit == 0)
            {
                lengthOfTrack++;

                if (currentRow == 7 && currentColumn == 7)
                {
                    break;
                }

                ChangePosition(ref direction, ref currentRow, ref currentColumn, ref numberOfTurns, ref south, ref turnedLastTime, ref deadEnd);
                turnedLastTime = false;
            }

            else
            {
                if (currentRow == 0 && currentColumn == 0)
                {
                    deadEnd = true;
                    break;
                }

                if (currentRow == 7 && currentColumn == 7)
                {
                    break;
                }

                MakeATurn(ref direction, ref currentRow, ref currentColumn, ref numberOfTurns, ref south, ref turnedLastTime, ref deadEnd);                
            }            
        }

        if (deadEnd)
        {
            Console.WriteLine("No {0}", lengthOfTrack);
        }

        else
        {
            Console.WriteLine("{0} {1}", lengthOfTrack, numberOfTurns);
        }
    }

    public static void ChangePosition(ref string direction, ref int row, ref int column, ref int numberOfTurns, ref bool south, ref bool turnedLastTime, ref bool deadEnd)
    {
        if (direction == "south")
        {
            row++;
            if (row > 7)
            {
                MakeATurn(ref direction, ref row, ref column, ref numberOfTurns, ref south, ref turnedLastTime, ref deadEnd);
                if (column > 7)
                {
                    deadEnd = true;
                }
            }
        }

        else if (direction == "west")
        {
            column++;
            if (column > 7)
            {               
                MakeATurn(ref direction, ref row, ref column, ref numberOfTurns, ref south, ref turnedLastTime, ref deadEnd);
                if (row > 7 || row < 0)
                {
                    deadEnd = true;
                }
            }
        }

        else if (direction == "north")
        {
            row--;
            if (row < 0)
            {               
                MakeATurn(ref direction, ref row, ref column, ref numberOfTurns, ref south, ref turnedLastTime, ref deadEnd);
                if (column > 7)
                {
                    deadEnd = true;
                }
            }
        }
    }

    public static void MakeATurn(ref string direction, ref int row, ref int column, ref int numberOfTurns, ref bool south, ref bool turnedLastTime, ref bool deadEnd)
    {
        if (turnedLastTime)
        {
            numberOfTurns--;
            deadEnd = true;
            return;
        }

        numberOfTurns++;

        if (direction == "south")
        {
            direction = "west";
            column++;
            row--;
        }
        
        else if (direction == "north")	
        {
            direction = "west";
            column++;
            row++;
        }

        else
        {
            if (south)
            {
                direction = "north";
                row--;
                column--;
                south = false;
            }

            else
            {
                direction = "south";
                row++;
                column--;
                south = true;
            }
        }

        turnedLastTime = true;
    }
}
