//importing all the required packages
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_F19
{
    class Program
    {
        public static int None { get; private set; }
        static void Main(string[] args)
        {

            int a = 1, b = 22;
            Console.WriteLine("The self dividing numbers are:");
            //Calling the function which will find the self dividing numbers between a and b
            printSelfDividingNumbers(a, b);
            Console.WriteLine();


            Console.WriteLine("Printing the series:");
            int n2 = 5;
            //Calling the function which will print the series of length n2
            printSeries(n2);

            Console.WriteLine("Printing the  inverted triangle:");
            int n3 = 5;
            //Calling the function which will print the inverted triangle of height n3 
            printTriangle(n3);

            Console.WriteLine("Number of stones you have that are also a jewel:");
            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            //Calling the function which will print the number of stones which are also a jewel
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);


            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            //Calling the function which will find the largest common sub array between arr1 and arr2
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            Console.WriteLine(r5);

            solvePuzzle();
        }

        //Defining the function that prints the self dividing numbers between a and b. a and b are accepted as parameters
        //referenced https://leetcode.com/articles/self-dividing-numbers/ On 9/5/19 7:15 pm to get the logic on self dividing numbers
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                //Check if each number between x and y are self dividing, each number is passed to the function Checkalldigits to check if it is self divided by its digits
                for (int num = x; num <= y; num++)
                {
                    Program.Checkalldigits(num);
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        //Defining the function which checks whether the number passed is divided by all of its digits
        public static bool Checkalldigits(int n)
        {
            //extract the digits in the number by converting the number to string, then extract each character of it
            foreach (char alpha in (n.ToString()))
            {
                int k;
                //get the numeric vaclue of each character taken from the number that was conver to string in the above step
                k = (int)char.GetNumericValue(alpha);
                //if the digit is 0 or remainder of number divided by that digit is not 0, then the number is not self dividing. Returns false
                if ((alpha == '0') || (n % k > 0))
                {
                    return false;
                }
            }
            //else if the digit is non zero and if the remainder of the number divided by that digit is 0, then print the number.
            //Prints the number which is self dividing 
            Console.WriteLine("{0}", n);
            return true;

        }

        //Defining the funtion that prints the series upto the length of the number that is passed to the function
        //referenced https://stackoverflow.com/a/982649/11846746  On 9/5/19 7:16 pm to get idea on breaking the loop when the length of the series reaches the length given
        public static void printSeries(int n)
        {
            try
            {   //Defining a list to keep appending the numbers of the series and to check the length of the list
                List<int> intList = new List<int>();

                //for loop to print the series
                for (int i = 1; i >= 1; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        //Appending the number to the List
                        intList.Add(i);
                        //if the length of the series = n, break the loop 
                        if (intList.Count == n)
                        { goto End; }
                    }

                }
            //print the elements in the list
            End:
                intList.ForEach(item => Console.WriteLine(item));

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        //defining function to print inverted triangle
        public static void printTriangle(int n)
        {
            try
            {
                //print * until the height of the tree reaches the number specified
                for (int height = n; height > 0; height--)
                {
                    //inner loop to print the space both towards the left and right
                    for (int space = n - height; space > 0; space--)
                    {
                        Console.Write(" ");
                    }
                    //print * ((2*height) - 1) times, and as the height decreases, the count of * reduces by 2 with space in the left and right 
                    //referenced http://alltypecoding.blogspot.com/2015/05/how-to-printing-reverse-triangle-in-c.html Friday, 22 May 2015.
                    for (int i = (2 * height) - 1; i > 0; i--)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        //Defining the function which prints the number of stones which is also a jewel 
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                //defining a variable to keep a count of stones which are also a jewel
                int count = 0;
                int item;
                //gets each element which are jewels
                for (int j = 0; j < J.Length; j++)
                {
                    item = J[j];
                    //iterate through the stones and check if the stone is a jewel. 
                    for (int i = 0; i < S.Length; i++)
                    {
                        //if the stone is a jewel, increment the count by 1
                        if (item == S[i])
                        {
                            count++;
                        }
                    }
                }
                return count;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        //Defining the function to print the largest common sub array in two arrays a and b
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                //defining 2 lists for the two arrays.
                //Each to store different sub arrays that can be generated out the arrays
                List<int[]> List1 = new List<int[]> { };
                List<int[]> List2 = new List<int[]> { };
                //Sort array a
                Array.Sort(a);
                //generate different sub arrays of array a
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = i; j < a.Length; j++)
                    {
                        //append the elements of subarray to a list
                        List<int> list = new List<int>();
                        for (int k = i; k <= j; k++)
                        {
                            list.Add(a[k]);

                        }
                        //convert the list to an array
                        int[] array = list.ToArray();
                        //if the array is non empty add the array to the list of sub arrays
                        if (array.Length > 1)
                        {
                            List1.Add(array);
                        }

                    }
                }
                //Similarly the array b
                Array.Sort(b);
                //generate different sub arrays of array b
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = i; j < b.Length; j++)
                    {
                        //append the elements of subarray to a list
                        List<int> list = new List<int>();
                        for (int k = i; k <= j; k++)
                        {
                            list.Add(b[k]);

                        }
                        //convert the list to an array
                        int[] array = list.ToArray();
                        //if the array is non empty add the array to the list of sub arrays
                        if (array.Length > 1)
                        {
                            List2.Add(array);
                        }

                    }
                }

                //Find arrays that are common in both the Lists  - List1 and List2 and store in a new List called "fin"   
                //iterate through the list1 and List2.
                //if the element of List matches with the element of List2 then append the element to the List "fin"
                List<int[]> fin = new List<int[]>();
                foreach (int[] line in List1)
                {
                    List<int> list = new List<int>();
                    foreach (int[] l2 in List2)
                    {
                        if (line.SequenceEqual(l2))
                        {
                            foreach (int item in line)
                            {
                                list.Add(item);
                            }
                            int[] array = list.ToArray();
                            if (array.Length > 1)
                            {
                                fin.Add(array);
                            }

                        }

                    }

                }
                // defining a list to store the array whose elements are contiguous
                List<int[]> largest = new List<int[]>();

                //check each array in the list if its elements are contiguous
                foreach (int[] line in fin)
                {
                    //call Checkifcontiguous function to check if array elements are contiguous
                    if (Checkifcontiguous(line))
                    {
                        largest.Add(line);
                    }
                }
                //define an array to store the array from list which is largest
                int[] large = new int[1];
                //intiializing the array with the first first array of the list as the largest array
                large = largest[0];

                //iterate through each of the arrays in the List
                for (int i = 1; i < largest.Count; i++)
                {
                    //if the length of the largest[i] array is larger or equal to the lenth of the intialised array then change the largest array to the new arrat
                    if (large.Length < largest[i].Length || large.Length == largest[i].Length)
                    {
                        large = largest[i];
                    }

                }
                //print the largest common sub array
                Console.WriteLine("Largest Common Sub array :");
                for (int i = 0; i < large.Length; i++)
                {
                    Console.Write(large[i]);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
        }

        //defining the function that checks if the elements of the array are contiguous
        private static bool Checkifcontiguous(int[] line)
        {
            // iterate through the array
            for (int i = 1; i < line.Length; i++)
            {
                //if the difference between the two consecutive elements are greater than 1, then return false
                if (line[i] - line[i - 1] > 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static void solvePuzzle()
        {
            try
            {

                string f, s, o;
                //        Console.WriteLine("Enter the first word");
                f = "UBER";
                //          Console.WriteLine("Enter the first word");
                s = "COOL";
                //            Console.WriteLine("Enter the output word");
                o = "UNCLE";
                //Converting the string inputs to char array
                char[] first = f.ToCharArray();
                char[] second = s.ToCharArray();
                char[] output = o.ToCharArray();
                //merging all the char arrays to a single char array
                var sb = new StringBuilder(f.Length + s.Length + o.Length);
                //adding all the arrays to a list
                List<char> list = new List<char>();
                list.AddRange(first);
                list.AddRange(second);
                list.AddRange(output);
                //converting the list with all the arrays to a single array
                char[] z = list.ToArray();
                //finding the unique alphabets in the array
                char[] un = z.Distinct().ToArray();
                //finding the 10 to the power number of unique alphabets 
                double dd = Math.Pow(10, un.Length);
                //checking all the numbers from  0 to the largest 8 digit number
                for (int i = 12345678; i <= dd; i++)
                {
                    if (i.ToString().Length <= z.Length)
                    {
                        //pad an the number with leading zeros to a length of 8
                        string ddd = String.Format("{0:D8}", i);
                        //declaring a dictionary in which the keys are the unique alphabets and value as none.
                        Dictionary<char, int> dictionary = un.ToDictionary(v => v, v => None);
                        //assign each digit of the number to the alphabets after converting it to interger and store in dictionary
                        for (int j = 0; j < un.Length; j++)
                        {
                            dictionary[un[j]] = ddd[j] - '0';
                        }
                        //declaring an int array to store the digits of the first word
                        //this extracts the corresponding value of the alphabets from the dcitionary
                        int[] firstnum = new int[first.Length];
                        for (int k = 0; k < first.Length; k++)
                        {
                            char key = first[k];
                            firstnum[k] = dictionary[key];
                        }
                        //declaring an int array to store the digits of the second word
                        //this extracts the corresponding value of the alphabets from the dcitionary
                        int[] secondnum = new int[second.Length];
                        for (int k = 0; k < second.Length; k++)
                        {
                            char key = second[k];
                            secondnum[k] = dictionary[key];
                        }
                        //declaring an int array to store the digits of the output word
                        //this extracts the corresponding value of the alphabets from the dcitionary
                        int[] outputnum = new int[output.Length];
                        for (int k = 0; k < output.Length; k++)
                        {
                            char key = output[k];
                            outputnum[k] = dictionary[key];
                        }
                        //Referenced https://stackoverflow.com/a/9564827/11846746 for logic to convert int array to a number
                        int fnum = 0;
                        for (int l = 0; l < firstnum.Length; l++)
                        {
                            fnum += firstnum[l] * Convert.ToInt32(Math.Pow(10, firstnum.Length - l - 1));
                        }
                        //Console.WriteLine("first number{0}",fnum);
                        int snum = 0;
                        for (int l = 0; l < secondnum.Length; l++)
                        {
                            snum += secondnum[l] * Convert.ToInt32(Math.Pow(10, secondnum.Length - l - 1));
                        }
                        //Console.WriteLine("second number{0}", snum);
                        int onum = 0;
                        for (int l = 0; l < outputnum.Length; l++)
                        {
                            onum += outputnum[l] * Convert.ToInt32(Math.Pow(10, outputnum.Length - l - 1));
                        }
                        //Console.WriteLine("output number{0}",onum);
                        int added;
                        added = (fnum + snum);
                        //if the sum of the first number and second number equals to the number of output, then print the corresponding values of the digits
                        if (added == onum)
                        {
                            Console.WriteLine("The final answer:");
                            Console.WriteLine("the sum of the two numbers: {0}", added);
                            Console.WriteLine("Number equivalent to first word : {0}", fnum);
                            Console.WriteLine("Number equivalent to second word : {0}", snum);
                            Console.WriteLine("Number equivalent to output word: {0}", onum);
                            foreach (KeyValuePair<char, int> pair in dictionary)
                            {
                                Console.WriteLine(pair);
                            }
                        }
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }


    }
}

