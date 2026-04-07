using System;
using System.Globalization;

namespace Activity01_CSharp
{
    class Activity01_Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Activity-01: Logical & Conceptual Programming in C#");
            Console.WriteLine("Solve all questions by implementing logic inside each function.");
            Console.WriteLine("--------------------------------------------------------------");

            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
            Question7();
            Question8();
            Question9();
            Question10();
        }

        // --------------------------------------------------------
        // Question 1
        // Write logic to calculate retirement date and experience
        // --------------------------------------------------------
        static void Question1()
        {
            Console.WriteLine("Question 1: Calculate retirement date and experience");
        
            Console.Write("Enter your Date of Birth  (yyyy-mm-dd): 1995-04-12:");
            string dobinput= Console.ReadLine();
            if(!DateTime.TryParse(dobinput, out DateTime dob))
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-mm-dd format.");
                return;
            }
            if(dob > DateTime.Today)
            {
                Console.WriteLine("Date of Birth cannot be in the future.");
                return;
            }
            
            Console.Write("Enter your Date of Joining  (yyyy-mm-dd): 1995-04-12:");
            string jobinput= Console.ReadLine();
            if(!DateTime.TryParse(jobinput, out DateTime job))
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-mm-dd format.");
                return;
            }
            if(job > DateTime.Today)
            {
                Console.WriteLine("Date of Joining cannot be in the future.");
                return;
            }
            if(job < dob)
            {
                Console.WriteLine("Date of Joining cannot be before Date of Birth.");
                return;
            }
            DateTime tod = DateTime.Today;
            DateTime retirement=dob.AddYears(60);
            DateTime start = job; 
            DateTime end = tod;   

            int years = 0;
            int months = 0;
            int days = 0;

           
            while (start.AddYears(1) <= end)
            {
                start = start.AddYears(1);
                years++;
            }

            
            while (start.AddMonths(1) <= end)
            {
                start = start.AddMonths(1);
                months++;
            }

            
            days = (end - start).Days;
            Console.WriteLine($"Retirement Date: {retirement:yyyy-MM-dd}");

            Console.WriteLine($"Experience: {years} years {months} month {days} days");


        }

        // --------------------------------------------------------
        // Question 2
        // Count occurrences of a word in a paragraph and show indexes
        // --------------------------------------------------------
        static void Question2()

        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 2: Word Search");
            Console.WriteLine("Enter The Paragraph : ");
            string para = Console.ReadLine();
            Console.WriteLine("Enter The Word to Search :  ");
            string word = Console.ReadLine();
            int count = 0;
            int index = 0;
            Console.WriteLine("Searching...");
            while ((index=para.IndexOf(word,index))!=-1)
            {
                count++;
                Console.WriteLine("Found at index: " + index);
                index += word.Length;
            }
            if (index == -1)
            {
                Console.WriteLine("Either All The Words are Found or No Words Are Found");
            }
        
        }

        // --------------------------------------------------------
        // Question 3
        // Check whether a number is a Strong Number
        // --------------------------------------------------------
        static void Question3()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 3: Strong Number ");
            Console.Write("Enter your number : ");
            int num =int.Parse((Console.ReadLine()));
            int temp = num;
            int sum = 0;
            while (temp > 0)
            {
                int digit = temp % 10;
                int fact = 1;
                for(int i = 1; i <= digit; i++)
                {
                    fact *= i;
                }
                sum += fact;
                temp = temp / 10;

            }
            if (sum == num)
            {
                Console.WriteLine("The number " + num + " is a strong number because sum of Fact is "+ sum);
            }
            else
            {
                Console.WriteLine("The number " + num + " is not a strong number because sum of Fact is " + sum);
            }
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
        }

        // --------------------------------------------------------
        // Question 4
        // Generate Fibonacci series and sum of even numbers
        // --------------------------------------------------------
        static void Question4()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 4: Fabinoci Series & Even numbers Sum  ");
            Console.Write("Enter Yout Number : ");
            int num = int.Parse(Console.ReadLine());
            int first = 0;
            int second = 1;
            int evensum = 0;
            for (int i = 0; i < num; i++)
            {
                Console.Write(first + " ");
                if (first % 2 == 0)
                {
                    evensum += first;
                }
                int next = first + second;
                first = second;
                second = next;

            }
            Console.WriteLine("\nSum of even numbers in the series: " + evensum);

        }

        // --------------------------------------------------------
        // Question 5
        // Count vowels, consonants, digits, special characters
        // --------------------------------------------------------
        static void Question5()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 5: Vowels, Consonants , Digits , Special Characters  ");
            Console.WriteLine("Enter Your String : ");
            string para = Console.ReadLine();
            int vowels = 0;
            int consonants = 0;
            int digits = 0;
            int special = 0;
            foreach(char c in para)
            {
                if (char.IsLetter(c))
                {
                    char low = char.ToLower(c);
                    if(low=='a'|| low=='e' || low=='u'|| low=='i'|| low == 'o')
                    {
                        vowels++;

                    }
                    else
                    {
                        consonants++;
                    }
                }
                else if(char.IsDigit(c))
                {
                    digits++;
                }
               else  if (char.IsWhiteSpace(c))
                {

                }
                else
                {
                    special++;
                }
            }
            Console.WriteLine("Vowels: " + vowels+ "->  Consonants "+ consonants+ "->  Digits : "+ digits+ " -> Special Characters : "+ special);
            
        }

        // --------------------------------------------------------
        // Question 6
        // Reverse and add process to find palindrome
        // --------------------------------------------------------
        static void Question6()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 6: Palindrome Iterations  ");
            Console.Write("Enter Your Number : ");
            long num = long.Parse(Console.ReadLine());
            int iterations = 0;
            bool found = false;
            while(iterations<10 && !found)
            {
              iterations++;
                long temp = num;
                long rev = 0;
                while (temp > 0)
                {
                    rev = rev * 10 + temp % 10;
                    temp /= 10;
                }
                long sum = num + rev;
                Console.WriteLine($"Iteration {iterations}: {num} + {rev} = {sum}");
                long checktemp= sum;
                long checkrev = 0;
                while(checktemp > 0)
                {
                    checkrev = checkrev * 10 + checktemp % 10;
                    checktemp /= 10;
                }
                if(sum == checkrev)
                {
                    Console.WriteLine($"Palindrome found: {sum} in {iterations} iterations.");
                    found = true;
                }
                else
                {
                    num = sum;
                }
            }
            if(!found)
            {
                Console.WriteLine("Palindrome not found within 10 iterations.");
            }


        }

        // --------------------------------------------------------
        // Question 7
        // Find maximum, minimum, and average of 10 numbers
        // --------------------------------------------------------
        static void Question7()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 7: Maximum, Minimum and Averagge Value  ");
            Console.WriteLine("Enter 10 integer Values ....");

            int[] numbers = new int[10];
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Number {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
                sum += numbers[i];
            }

            int max = numbers[0];
            int min = numbers[0];

            foreach (int n in numbers)
            {
                if (n > max) max = n;
                if (n < min) min = n;
            }

            double average = sum / 10.0; 

            Console.WriteLine($"\nMaximum: {max}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Average: {average}");
        }

        // --------------------------------------------------------
        // Question 8
        // Find day of week and remaining days in year
        // --------------------------------------------------------
        static void Question8()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 8: Day of the Week  ");
            Console.Write("Enter Date   (yyyy-mm-dd): 1995-04-12:");
            string dobinput = Console.ReadLine();
            if (!DateTime.TryParse(dobinput, out DateTime dob))
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-mm-dd format.");
                return;
            }
            Console.WriteLine("Day of Week: " + dob.DayOfWeek);
            DateTime end=new DateTime(dob.Year , 12,31);
            TimeSpan diff = end - dob;
            Console.WriteLine("Days Remianing in Year : " + diff.Days);
        }

        // --------------------------------------------------------
        // Question 9
        // Detect datatype and perform type conversions
        // --------------------------------------------------------
        static void Question9()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 9: Data Type   ");
            Console.WriteLine("Enter Any Value : ");
            string inp = Console.ReadLine();
            object val = inp;
            Console.WriteLine("Detected Type " + val.GetType());
            try
            {
                int intVal = Convert.ToInt32(val);
                Console.WriteLine("Converted to INT : "+ intVal);
                double doubVal = Convert.ToDouble(val);
                Console.WriteLine("Converted to INT : " + intVal);
                string strval= Convert.ToString(val);
                Console.WriteLine("Converted to String : " + strval);

            }
            catch(FormatException)
            {
                Console.WriteLine("Cannot convert to int or double.");
            }


        }

        // --------------------------------------------------------
        // Question 10
        // Number guessing game with random number
        // --------------------------------------------------------
        static void Question10()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Question 10: Programming Game  ");
            Random obj = new Random();
            int secret = obj.Next(1, 101);
            int maxAttempts = 7;
            bool win = false;
            Console.WriteLine("Welcome to the Number Guessing Game , Guess a Number from (1-101). You have 7 Attempts!");
            for(int i=1;i<=maxAttempts; i++)
            {
                Console.Write($"Attempt {i}: ");
                int guess = int.Parse(Console.ReadLine());
                if (guess == secret)
                {
                    Console.WriteLine("Congratulations! You guessed the number!");
                    win = true;
                    break;
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                }
            }
        }

       

       
    }
}