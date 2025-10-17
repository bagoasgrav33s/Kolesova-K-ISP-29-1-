using System;
using System.Collections.Generic;


namespace калькулятор
{
    internal class Program
    {
        static void Main(string[] args)
        {
                bool continueCalculations = true;
                List<string> history = new List<string>();

                Console.WriteLine("Калькулятор с историей операций");
                Console.WriteLine("================================");

                while (continueCalculations)
                {
                    try
                    { 
                        Console.Write("Введите первое целое число: ");
                        int num1 = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите второе целое число: ");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                       
                        bool continueWithSameNumbers = true;

                        while (continueWithSameNumbers)
                        {
                            ShowMenu();

                            Console.Write("Выберите операцию (1-5): ");
                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    int sum = num1 + num2;
                                    string additionOperation = $"{num1} + {num2} = {sum}";
                                    Console.WriteLine($"Результат: {additionOperation}");
                                    AddToHistory(history, additionOperation);
                                    break;

                                case "2": 
                                    int difference = num1 - num2;
                                    string subtractionOperation = $"{num1} - {num2} = {difference}";
                                    Console.WriteLine($"Результат: {subtractionOperation}");
                                    AddToHistory(history, subtractionOperation);
                                    break;

                                case "3": 
                                    int product = num1 * num2;
                                    string multiplicationOperation = $"{num1} * {num2} = {product}";
                                    Console.WriteLine($"Результат: {multiplicationOperation}");
                                    AddToHistory(history, multiplicationOperation);
                                    break;

                                case "4": 
                                    if (num2 == 0)
                                    {
                                        Console.WriteLine("Ошибка: Деление на ноль невозможно!");
                                    }
                                    else
                                    {
                                        int quotient = num1 / num2; 
                                        string divisionOperation = $"{num1} / {num2} = {quotient}";
                                        Console.WriteLine($"Результат: {divisionOperation}");
                                        AddToHistory(history, divisionOperation);
                                    }
                                    break;

                                case "5": 
                                    continueWithSameNumbers = false;
                                    continueCalculations = false;
                                    Console.WriteLine("Выход из программы...");
                                    break;

                                case "6": 
                                    continueWithSameNumbers = false;
                                    Console.WriteLine("Ввод новых чисел...");
                                    break;

                                case "7": 
                                    ShowHistory(history);
                                    break;

                                default:
                                    Console.WriteLine("Неверный выбор! Пожалуйста, выберите операцию от 1 до 7.");
                                    break;
                            }

                            if (continueWithSameNumbers && choice != "7")
                            {
                                Console.WriteLine("\n" + new string('-', 40));
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: Введите корректное целое число!");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ошибка: Введенное число слишком большое!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла ошибка: {ex.Message}");
                    }
                }

                if (history.Count > 0)
                {
                    Console.WriteLine("\nФинальная история операций:");
                    ShowHistory(history);
                }

                Console.WriteLine("Программа завершена. Нажмите любую клавишу...");
                Console.ReadKey();
            }

            static void ShowMenu()
            {
                Console.WriteLine("\nМеню операций:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("5. Выход");
                Console.WriteLine("6. Ввести новые числа");
                Console.WriteLine("7. Показать историю операций");
            }

            static void AddToHistory(List<string> history, string operation)
            {
                history.Add(operation);

                if (history.Count > 5)
                {
                    history.RemoveAt(0);
                }
            }

            static void ShowHistory(List<string> history)
            {
                if (history.Count == 0)
                {
                    Console.WriteLine("История операций пуста.");
                    return;
                }

                Console.WriteLine("\nИстория последних операций:");
                Console.WriteLine(new string('-', 30));

                for (int i = history.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(history[i]);
                }

                Console.WriteLine(new string('-', 30));
            }
        }
    }
