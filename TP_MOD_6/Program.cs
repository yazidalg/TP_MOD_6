public class MainProgram
{
    static void Main(string[] args)
    {
        SayaTubeVideo test = new SayaTubeVideo("Tutorial Design By Contract - Yazid Al Ghozali");
        test.PrintVideoDetails();
    }
}


public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    Random random = new Random();
    public SayaTubeVideo(string title)
    {
        this.title = title;
        playCount = 0;
        id = random.Next(1, 12);
    }

    public void IncreasePlayCount(int count)
    {
        playCount = count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID : " + id);
        Console.WriteLine("Title : " + title);
        Console.WriteLine("Lagu diputar : " + playCount);
    }
}