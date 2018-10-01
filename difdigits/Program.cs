using System;
using System.Diagnostics;

namespace difdigits
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            string numberString = number.ToString();
            int firstNumber;
            int secondNumber;
            string newNumber= "";
            double lastNumber;

            Stopwatch start = new Stopwatch();
            start.Start();
            
            for (int i = 0; i <= numberString.Length - 2; i++)
            {
                firstNumber = (int)Char.GetNumericValue(numberString[i]);
                secondNumber = (int)Char.GetNumericValue(numberString[i+1]);

                if (firstNumber == secondNumber && i <= numberString.Length-2)
                {
                    if (secondNumber == 9)
                    {
                        if (i > 0)
                        {
                            lastNumber = Char.GetNumericValue(newNumber[newNumber.Length - 1]);

                            newNumber = newNumber.Remove(newNumber.Length - 1);
                            lastNumber++;
                            newNumber += lastNumber;
                            if (lastNumber >= 1)
                            {
                                newNumber += "01";
                            }
                            else
                            {
                                newNumber += "10";
                            }
                        }
                        else
                        {
                            firstNumber++;
                            secondNumber = 1;
                            newNumber += firstNumber.ToString() + secondNumber;
                        }
                    }
                    else
                    {
                        secondNumber++;
                        newNumber += firstNumber.ToString() + secondNumber;
                    }          

                    for (int g = i+2; g <= numberString.Length - 1; g++)
                    {
                        if(Char.GetNumericValue(newNumber[newNumber.Length - 1])>=1)
                        {
                            newNumber += 0;
                            secondNumber = 0;
                        }
                        else
                        {
                            newNumber += 1;
                            secondNumber = 1;
                        }                       
                    }    
                    break;
                }
                else
                if (firstNumber == secondNumber && i == numberString.Length - 2)
                {
                    Console.WriteLine(firstNumber.ToString() + secondNumber);
                    secondNumber++;
                    newNumber += firstNumber.ToString() + secondNumber ;
                }
                else 
                {
                    newNumber += firstNumber;        
                }      
            }
            Console.WriteLine("Input: " + number);
            Console.WriteLine("Output: " + newNumber);
            start.Stop();
            Console.WriteLine(start.ElapsedMilliseconds + " mS");
        }
    }
}
