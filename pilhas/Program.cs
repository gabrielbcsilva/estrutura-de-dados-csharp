using System;

public class Stack<T>
{// A pilha tem o conceito de LIFO Last in, First out. O ultimo a entrar é o primeiro a sair
    private T[] _elementos;
    private int _tamanho;
    private const int _capacidade = 4;

    public Stack()
    {
        _elementos = new T[_capacidade];
        _tamanho = 0;
    }

    public int Contador
    {
        get { return _tamanho; }
    }

    public void Push(T item)
    {
        if (_tamanho == _elementos.Length)
        {
            Resize(_tamanho * 2);
        }
        _elementos[_tamanho++] = item;
    }

    public T Pop()
    {
        if (_tamanho == 0)
        {
            throw new InvalidOperationException("A pilha está vazia");
        }

        T item = _elementos[--_tamanho];
        _elementos[_tamanho] = default(T); // Clear the reference
        return item;
    }

    public T Peek()
    {
        if (_tamanho == 0)
        {
            throw new InvalidOperationException("A pilha está vazia");
        }
        return _elementos[_tamanho - 1];
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(_elementos, 0, newArray, 0, _tamanho);
        _elementos = newArray;
    }
}

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(3);
        stack.Push(1);
        stack.Push(2);

        Console.WriteLine("O elemento do topo é: " + stack.Peek()); 

        Console.WriteLine("Elementos:");
        while (stack.Contador > 0)
        {
            Console.WriteLine(stack.Pop());
        }
       
    }
}
