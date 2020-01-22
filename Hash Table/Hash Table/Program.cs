using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ivans_Library;

namespace Hash_Table
{
    class Hash_Table
    { 
        private string[] hashTable;
        private int maxSize;
        private int size;

        public Hash_Table()
        {
            /*hash table constructor*/
            maxSize = 11;
            size = 0;
            hashTable = new string[maxSize];

            for (int x = 0; x < maxSize; x++)
            {
                hashTable[x] = "Empty";
            }
        }

        private int hashAlgo(string input)
        {            
            /*A hash algorithm that assigns each name an index
             (just mod maxsize)*/
            int total = 0;
            string holder = "";
            for (int i = 0; i < input.Length; i++)
            {
                holder = input.Substring(i, 1);
                total = total + Function.ConvertToAscii(holder);             
            }
            int index = total % maxSize;
            return (index);           
            
        }
       
        public void showTable()
        {
            /*For loop that displays all the values in the table*/
            for (int i = 0; i < maxSize; i++)
            {
                if (hashTable[i] == "Empty" || hashTable[i] == "Deleted")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                //Console.WriteLine(String.Format("{0,-15} | {1,-15} | {2,-15}", "Pile 1", "Pile 2", "Pile 3"));
                Console.Write(String.Format("{0,-5}", hashTable[i]));
                //Console.Write(hashTable[i] + " ");
                Console.ResetColor();
                Console.Write("|");
            }
        }

        public void inputInTable(string input)
        {
            int index = hashAlgo(input);

            bool spaceFound = false;
            while (spaceFound == false && size != maxSize)
            {
                if (hashTable[index] == "Empty" || hashTable[index] == "Deleted")
                {
                    hashTable[index] = input;
                    size = size + 1;
                    spaceFound = true;

                }
                else if (hashTable[index] != "Empty")
                {
                    index = (index + 1)%maxSize;
                    spaceFound = false;
                }
            }
            if (spaceFound == false && size == maxSize)
            {
                Console.WriteLine("This table has run out of space");
            }
            else if (spaceFound == true)
            {
                Console.WriteLine(input + " has been input into the table");
            }           
        }

        public void findInTable(string searchItem)
        {
            int index = hashAlgo(searchItem);
            bool found = false;
            int count=0;
            /*Searches the table starting from the index recieved by the hash table*/
            while (found == false && count != maxSize)
            {
                if (hashTable[index] == searchItem)
                {
                    Console.WriteLine(searchItem + " has been found in index " + index);
                    found = true;
                }
                else
                {
                    index = (index + 1) % maxSize;
                    count = count + 1;
                }
            }
            if (found == false)
            {
                Console.WriteLine("That item is not in the table");
            }
        }

        public void removeFromTable(string item)
        {
            int index = hashAlgo(item);
            bool found = false;
            int count = 0;

            while (found == false && count != maxSize)
            {
                if (hashTable[index] == item)
                {
                    Console.WriteLine(item + " has been removed from the list");
                    hashTable[index] = "Deleted";
                    found = true;
                }
                else
                {
                    index = (index + 1) % maxSize;
                    count = count + 1;
                }
            }
            if (found == false)
            {
                Console.WriteLine("That item is not in the table");
            }
        }

        public int findLoadFactor()
        {
            int loadFactor = size / maxSize;
            return (loadFactor);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Hash_Table h = new Hash_Table();
            int lf;
            string input;
            bool end = false;

            while (end == false)
            {
                lf = h.findLoadFactor();
                /*Displays the name and options for the user to use*/
                Console.Clear();
                Console.WriteLine(String.Format("{0,-15} {1,15}","Hash Table", "Load Factor:" + lf + "%"));
                Console.WriteLine("----------");
                //Function.Underline("Hash Table");
                Console.WriteLine("1. Add to table\n2. Find in table\n3. Remove from table\n4. Show table\n5. Exit");
                int selection = Function.Int_Check();
                selection = Function.Range_Check(selection, 1, 5);

                switch (selection)
                {
                    case 1:
                        /*Allows the user to input a name that will be input into the table*/
                        Console.Clear();
                        Console.WriteLine("Input name:");
                        input = Console.ReadLine();
                        h.inputInTable(input);
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        break;

                    case 2:
                        /*Allows the user to input a name which the program will try to find in the table
                         A suitable message will be displayed afterwords*/
                        Console.Clear();
                        Console.WriteLine("Find name:");
                        input = Console.ReadLine();
                        h.findInTable(input);
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        break;

                    case 3:
                        /*Replaces specified name with "deleted"*/
                        Console.Clear();
                        Console.WriteLine("Input name to remove:");
                        input = Console.ReadLine();
                        h.removeFromTable(input);
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        break;
                    
                    case 4:
                        /*Just displays the table for the user*/
                        Console.Clear();
                        Function.Underline("Table");
                        h.showTable();
                        Console.WriteLine();
                        Thread.Sleep(5000);
                        break;

                    case 5:
                        /*Exits the for loop so ends the program*/
                        end = true;
                        break;
                }              
            }            
        }
    }
}
