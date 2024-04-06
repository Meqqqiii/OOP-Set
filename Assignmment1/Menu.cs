using System;

namespace Assignmment1
{
    class Menu
    {
        private Set set = new Set();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1:
                        PutIn();
                        Write();
                        break;
                    case 2:
                        RemoveElement();
                        Write();
                        break;
                    case 3:
                        GetMax();
                        Write();
                        break;
                    case 4:
                        CheckEmpty();
                        Write();
                        break;
                    case 5:
                        Write();
                        break;
                    case 6:
                        RandomNum();
                        Write();
                        break;
                    case 7:
                        Contains();
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nBye!");
                        break;

                }
            } while (v != 0);
        }
        private static int GetMenuPoint()
        {
            int v;
            Console.WriteLine("\n********************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add an element");
            Console.WriteLine("2. Remove Element");
            Console.WriteLine("3. GetMax");
            Console.WriteLine("4. IsEmpty");
            Console.WriteLine("5. Print");
            Console.WriteLine("6. Get a random number");
            Console.WriteLine("7. Check if set contains:");
            Console.WriteLine("****************************************");

            v = int.Parse(Console.ReadLine());

            return v;
        }
        private void PutIn()
        {
            try
            {
                Console.WriteLine("Number to add:");
                int num = int.Parse(Console.ReadLine());
                set.insert(num);
            }
            catch (Set.DuplicateException)
            {
                Console.WriteLine("Error:Number is already in Set");
            }
        }
        private void RemoveElement()
        {
            try
            {
                Console.WriteLine("Number to remove:");
                int num = int.Parse(Console.ReadLine());
                set.remove(num);
            }
            catch (Set.Empty)
            {
                Console.WriteLine("Error: Set is empty");
            }
            catch (Set.IsNotInTheSet)
            {
                Console.WriteLine("Error: Number is not in the set");
            }
        }
        private void GetMax()
        {
            try
            {
                Console.WriteLine(set.largest());
            }
            catch (Set.Empty)
            {
                Console.WriteLine("Error: Set is empty");
            }   
        }
        private void CheckEmpty()
        {
            if (set.isEmpty())
                Console.WriteLine("The set IS empty!\n");
            else
                Console.WriteLine("The set is NOT empty!\n");
        }
        private void RandomNum()
        {
            try
            {
                Console.WriteLine(set.random());
            }
            catch (Set.Empty)
            {
                Console.WriteLine("Error: Set is empty");
            }
        }
        private void Contains()
        {
            try
            {
                Console.WriteLine("Number to check");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(set.contains(num));
            }
            catch(Set.Empty)
            {
                Console.WriteLine("Error:The set is empty");
            }
        }
        private void Write()
        {
            Console.WriteLine(set.print());
        }
    }
}
