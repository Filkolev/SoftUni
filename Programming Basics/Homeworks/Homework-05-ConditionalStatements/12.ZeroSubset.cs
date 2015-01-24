using System;

// We are given 5 integer numbers. Write a program that finds all subsets of these 
// numbers whose sum is 0. Assume that repeating the same subset several times is not a problem.

class ZeroSubset
{
    static void Main()
    {
        int[] numbers = new int[5]; // array to enter all five numbers

        Console.WriteLine("Enter five numbers, each on a new line, to find all zero subsets.");

        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int counter = 0;

        Console.WriteLine("\nResult:\n");

        // check all subsets of two numbers
        for (int i = 0; i < 4; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                if (numbers[i] + numbers[j] == 0)
                {
                    Console.WriteLine("{0} + {1} = 0", numbers[i], numbers[j]);
                    counter++;
                }
            }
        }

        //check subsets of three numbers
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] == 0)
                    {
                        Console.WriteLine("{0} + {1} + {2} = 0", numbers[i], numbers[j], numbers[k]);
                        counter++;
                    }
                }
            }
        }

        // check subsets of four numbers
        for (int i = 0; i < 5; i++)
			 {
			 for (int j = i+1; j < 5; j++)
			 {
                for (int k = j+1; k < 5; k++)
			    {
                    for (int l = k+1; l < 5; l++)
			        {
			            if (numbers[i]+numbers[j] + numbers[k] + numbers[l] == 0)
	                    {
		                    Console.WriteLine("{0} + {1} + {2} + {3} = 0", numbers[i], numbers[j], numbers[k], numbers[l]);
                            counter++;
	                    }

                       
                        
			        }
			    }
			}
			}

        // check if the sum of all five is 0
        if (numbers[0]+numbers[1]+numbers[2]+numbers[3]+numbers[4]==0)
	    {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            counter++;
	    }


        if (counter==0)
        {
            Console.WriteLine("none");
        }

    }
}
