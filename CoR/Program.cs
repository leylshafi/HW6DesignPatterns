abstract class Translator
{
    protected Translator? Next { get; set; }

    public virtual Translator SetNext(Translator next)
    {
        Next = next;
        return this;
    }

    public abstract void Translate();
}


class EngToGerman : Translator
{
    public override void Translate()
    {
        Console.WriteLine("Translated from English to German");
        Next?.Translate();
    }
}

class EngToChn : Translator
{
    public override void Translate()
    {
        Console.WriteLine("Translated from English to Chinese");
        Next?.Translate();
    }
}

class EngToRus : Translator
{
    public override void Translate()
    {
        Console.WriteLine("Translated from English to Russian");
        Next?.Translate();
    }
}


class Program
{
    static void Main()
    {
        Translator translator = new EngToGerman();
        translator.Translate();

        Console.WriteLine();
        translator = new EngToChn()
            .SetNext(new EngToRus());
        translator.Translate();


    }
}