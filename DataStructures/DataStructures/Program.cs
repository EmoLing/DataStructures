using MyQueue;
using MyStack;
using System;

var testList = new List<string>()
{
    "Встать с кровати",
    "Почистить зубы",
    "Позавтракать",
    "Пойти на работу",
    "Лечь спать",
};

Console.WriteLine("1 - Queue, 2 - Stack");

if (!Int32.TryParse(Console.ReadLine(), out int choose))
    return;

switch (choose)
{
    case 1:
        Queue();
        break;

    case 2:
        Stack();
        break;

    case 0:
    default: return;
}

void Queue()
{
    var myQueue = new ArrayQueue<string>(5);

    AddElements(myQueue.Enqueue, testList);

    foreach (string item in myQueue)
        Console.WriteLine("Осталось: " + item);

    Console.WriteLine("\r\n\r\n");

    RemoveElements(myQueue.Dequeue, 2);

    Console.WriteLine("\r\n\r\n");

    foreach (string item in myQueue)
        Console.WriteLine("Осталось: " + item);
}

void Stack()
{
    var myStack = new ArrayStack<string>(5);

    AddElements(myStack.Push, testList);

    foreach (string item in myStack)
        Console.WriteLine("Осталось: " + item);

    Console.WriteLine("\r\n\r\n");

    RemoveElements(myStack.Pop);

    Console.WriteLine("\r\n\r\n");

    foreach (string item in myStack)
        Console.WriteLine("Осталось: " + item);
}

static void AddElements<T>(Action<T> action, List<T> values)
    => values.ForEach(v => action.Invoke(v));

static void RemoveElements<T>(Func<T> action, int count = 1)
{
    while (count-- > 0)
        Console.WriteLine("Удалено: " + action.Invoke());
}