using System;
using System.Collections.Generic;
using System.Text;

namespace TaskListCapstone
{
    class Tasks
    {
        private string name;
        private string description;
        private string dueDate;
        private string completionStatus;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public string CompletionStatus
        {
            get { return completionStatus; }
            set { completionStatus = value; }
        }

        public Tasks (string Name, string Description, string DueDate, string CompletionStatus)
        {
            name = Name;
            description = Description;
            dueDate = DueDate;
            completionStatus = CompletionStatus;
        }

        public void DisplayInformation()
        {

            //if (completionStatus == true)
            //{
                Console.WriteLine($"{ description }");
            //    Console.WriteLine($"{CompletionStatus}");
            //    Console.WriteLine("Complete");
            //}
            //else
            //{
            //    Console.WriteLine($"{ description }");
            //    Console.WriteLine($"{CompletionStatus}");
            //    Console.WriteLine("Incomplete");
            //}

        }
    }
}
