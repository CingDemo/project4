using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFour
{
    class Program
    {   //name and arry has to be in class because we will access it in multiple methods 
        static string[] names; //intilziae the array for names and avg 
        static double[] avgs;
        static void Main(string[] args)
        {  //user entry for the number of students. 
            Console.WriteLine("Enter the number of students: ");
            int numStudents = Convert.ToInt32(Console.ReadLine());
            //finish the array with the number of student that the user entered 
            names = new string[numStudents];
            avgs = new double [numStudents];
       
            //loop for the name and their class avg that will be true to the number of students that the user inputted 
            for (int i= 0; i<names.Length; i++ )
            {
                Console.Write("Enter the Student Name: ");
                names[i] = Console.ReadLine(); //use the names array for the name loop. This will keep looping till it reaches the number of students input
                while (names[i].Trim ().Length == 0)
                {
                    Console.Write("Enter Student Name: "); //this will keep asking the names of the student till it reaches the max number of student input. for example, four students. 
                    names[i] = Console.ReadLine();
                }

                Console.WriteLine("Enter the student's course average:"); //use the grade arry to create the grade avg loop .
                avgs[i] = Convert.ToDouble(Console.ReadLine());
                while (avgs [i] <0 || avgs [i] >100)
                {
                    Console.Write("Enter the student's course average:"); //this will keep asking the grade of students till it reaches the maximum mumber of student input
                    avgs[i] = Convert.ToDouble(Console.ReadLine());
                }

            }


            //ouput display for the following: highest scored student, lowest scored student, standard dev and class avg 
            string highestStudents = FindHighestScoringStudents();  //pull the information from a method that find max score 
            Console.WriteLine($"{highestStudents} and scored { avgs.Max()}");

            string lowestStudents = FindLowestScoringStudents();
            Console.WriteLine($"{lowestStudents} and scored {avgs.Min()}"); //print the information from a method that calculate the min score 

            double standDev = CalcStdDev();
            Console.WriteLine($"The class standard deviation is {standDev:f2}"); //print the information from a method that calculate the standev 

            double classAvg = FindTheAvg();
            Console.WriteLine($"The class average is {classAvg:f2}"); //print the info from a method that calcuate the avg 


            Console.ReadKey();

        }

        static private string FindHighestScoringStudents () //create a method for highest scoring students 
        {
            double max = avgs.Max();  //declare var for maximum score 
            string outputString = "The Name of the Highest Scoring Student(s) are: ";//declare second var for the output method
            for (int i=0; i<avgs.Length; i++) //loop the arry to find maximum score 
            {
                if (avgs [i] == max ) //if the arry matches the maximum score, add the name of the highest scored student 
                {
                    outputString += "  " + names[i]; 
                }
            }
            return outputString; //return the name of the highest scoring student 
        }

        static private string FindLowestScoringStudents () //create a method for lowest scoring students 
        {
            double min = avgs.Min(); //declar a var for min score 
            string outputString = "The Name of the Lowest Scoring Student(s) are: ";//declar second var for output method 
            for (int i=0; i< avgs.Length; i++ ) //loop the arry to find min score 
            {
                if (avgs [i] == min) //if the arry matches the min score, add the name of the lowest scored student 
                {
                    outputString += " " + names[i];
                }
            }
            return outputString; //return the name of the lowest scoring student 
        }

        static private double FindTheAvg () //create a method to find class avg 
        {
            double sumofAvgs = avgs.Sum();
            double average = sumofAvgs / avgs.Length;


            return average;

        }

        static private double CalcStdDev() //create a method to find standard dev 
        {
            double sum = 0;
            for (int i = 0; i < avgs.Length; i++) //loop through the arry to calulate the standard dev 
            {
                sum += Math.Pow((avgs[i] - avgs.Average()), 2); //calulate the variance using variance formula 
            }

            double stdDev = Math.Sqrt(sum / avgs.Length); //then, square root the variance to find standarddev 
            return stdDev;
            //return standard dev 
        }




    }
}
