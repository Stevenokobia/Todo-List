using System;
using System.Collections.Generic;

namespace Todolist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todos = new List<string>();

            bool Exit = false;

            while (!Exit)
            {
                Console.WriteLine();
                Console.WriteLine("Hello!");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

                var userChoice = Console.ReadLine();

                switch (userChoice.ToUpper())
                {
                    case "S":
                        SeeAllTodos();
                        break;

                    case "A":
                        AddTodo();
                        break;

                    case "R":
                        RemoveTodo();
                        break;

                    case "E":
                        Exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                if (!Exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            void AddTodo()
            {
                bool isValidDescription = false;

                while (!isValidDescription)
                {
                    Console.WriteLine("Input the TODO description:");
                    var description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine("The description cannot be empty");
                    }
                    else if (todos.Contains(description))
                    {
                        Console.WriteLine("The description must be unique");
                    }
                    else
                    {
                        isValidDescription = true;
                        todos.Add(description);
                        Console.WriteLine("TODO added successfully!");
                    }
                }
            }

            void SeeAllTodos()
            {
                if (todos.Count == 0)
                {
                    Console.WriteLine("No TODO has been added yet.");
                }
                else
                {
                    for (int i = 0; i < todos.Count; i++)
                    {
                        var todo = todos[i];
                        Console.WriteLine($"{i + 1}. {todo}");
                    }
                }
            }

            void RemoveTodo()
            {
                if (todos.Count == 0)
                {
                    Console.WriteLine("No TODO has been added yet.");
                    return;
                }

                bool isInputValid = false;

                while (!isInputValid)
                {
                    Console.WriteLine("Select the index of the TODO you want to remove:");
                    SeeAllTodos();

                    var userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Selected index cannot be empty.");
                        continue;
                    }

                    if (int.TryParse(userInput, out int index))
                    {
                        if (index < 1 || index > todos.Count)
                        {
                            Console.WriteLine("Invalid index. Please select a valid index.");
                        }
                        else
                        {
                            isInputValid = true;

                            var removedTodo = todos[index - 1];
                            todos.RemoveAt(index - 1);

                            Console.WriteLine($"TODO '{removedTodo}' removed successfully!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }
        }
    }
}
