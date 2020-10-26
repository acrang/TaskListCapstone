using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;

namespace TaskListCapstone
{
    class Program
    {
        static void Main(string[] args)
        {

            int indexOffset = 1;

            List<Tasks> listOfTasks = new List<Tasks>
            {

                new Tasks("Bill", "Clean exhaust fans", "10/27", "Incomplete"),
                new Tasks("Phil", "Clean coffee pot", "10/24", "Incomplete"),
                new Tasks("Will", "Paint over graffiti", "11/1", "Incomplete"),
                new Tasks("Sam", "Update all computers", "11/5", "Incomplete"),
                new Tasks("Monica", "Contact clients regarding overdue payment", "10/26", "Incomplete")

            };

            Console.WriteLine($"Welcome to the Task List Organizer!"); // welcome text
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine();

            while (true)
            {
                DisplayMainMenu();

                string menuSelect = Console.ReadLine().Trim();

                if (menuSelect == "1")
                {
                    ListTasks(listOfTasks);
                }

                if (menuSelect == "2")
                {
                    AddTask(listOfTasks);
                }

                if (menuSelect == "3")
                {
                    DeleteTask(listOfTasks);
                }

                if (menuSelect == "4")
                {
                    TaskComplete(listOfTasks);
                }

                if (menuSelect == "5")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
            }

        }

        public static void DisplayMainMenu()
        {

            Console.WriteLine("Please select a number from the list below:"); // main menu
            Console.WriteLine();
            Console.WriteLine($"1)  List all tasks");
            Console.WriteLine($"2)  Add a task");
            Console.WriteLine($"3)  Delete a task");
            Console.WriteLine($"4)  Mark a task as complete");
            Console.WriteLine($"5)  Quit");
            Console.WriteLine();
        }

        public static void ListTasks(List<Tasks> listOfTasks)
        {
            Console.WriteLine();

            for (int i = 0; i < listOfTasks.Count; i++)
            {

                Console.Write($"{ i + 1}) ");
                listOfTasks[i].DisplayInformation();
                Console.WriteLine($"Status: {listOfTasks[i].CompletionStatus}");
                Console.WriteLine();

            }
        }

        public static void AddTask(List<Tasks> listOfTasks)
        {
            Console.WriteLine();
            Console.WriteLine("Enter who the task is assigned to: ");
            string newName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Describe the task in great detail: ");
            string newDescription = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the deadline for the task: ");
            Console.WriteLine();

            string newDueDate = Console.ReadLine();
            string completionStatus = "Incomplete";

            Tasks task = new Tasks(newName, newDescription, newDueDate, completionStatus);
            task.Name = newName;
            task.Description = newDescription;
            task.DueDate = newDueDate;
            task.CompletionStatus = completionStatus;

            Console.WriteLine();
            Console.WriteLine("Task has been added to the list. Returning to main menu.");
            Console.WriteLine();

            listOfTasks.Add(task);

        }

        public static void DeleteTask(List<Tasks> listOfTasks)
        {
            int answer = 0;

            Console.WriteLine("Please enter the number of the task you would like to delete: ");
            Console.WriteLine();
            while (true)
            {
                ListTasks(listOfTasks);

                try
                {
                    string input = Console.ReadLine();
                    answer = (int.Parse(input) - 1);
                    listOfTasks[answer].DisplayInformation();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error. Please select a number from the list:");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Are you sure? (y/n)");
            Console.WriteLine();

            {
                while (true)
                {

                    string yesOrNO = Console.ReadLine();

                    if (yesOrNO == "y")
                    {
                        listOfTasks.RemoveAt(answer);

                        Console.WriteLine();
                        Console.WriteLine("Task deleted.");
                        Console.WriteLine();
                        break;
                    }
                    else if (yesOrNO == "n")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Task not deleted. Returning to main menu.");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter either 'y' or 'n'.");
                    }
                }
            }

        }

        public static void TaskComplete(List<Tasks> listOfTasks)
        {
            int answer = 0;

            Console.WriteLine("Please enter the number of the task you would like to mark complete:");
            while (true)
            {
                ListTasks(listOfTasks);

                try
                {
                    string input = Console.ReadLine();
                    answer = (int.Parse(input) - 1);
                    listOfTasks[answer].DisplayInformation();
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error. Please select a number from the list:");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Are you sure? (y/n)");

            {
                while (true)
                {

                    string yesOrNo = Console.ReadLine();

                    if (yesOrNo == "y")
                    {
                        listOfTasks[answer].CompletionStatus = "Complete";
                        Console.WriteLine();
                        Console.WriteLine("Task marked as complete.");
                        Console.WriteLine();
                        break;
                    }
                    else if (yesOrNo == "n")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Task not marked complete. Returning to main menu.");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input. Please enter either 'y' or 'n'.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
