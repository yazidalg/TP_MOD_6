using System.Diagnostics.Contracts;

public class MainProgram
{
    static void Main(string[] args)
    {
        SayaTubeVideo test = null;
        try
        {
            test = new SayaTubeVideo("Tutorial Design By Contract - Yazid Al Ghozali");

            for (int i = 0; i < 1000000; i++)
            {
                test.IncreasePlayCount(1);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            if (test != null)
            {
                test.PrintVideoDetails();
            }
        }
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
        Contract.Requires(title != null && title.Length <= 100, "Judul Video Memiliki Panjang Maksimal 100 Char dan tidak boleh null");
        this.title = title;
        playCount = 0;
        id = random.Next(1, 12);
    }

    public void IncreasePlayCount(int count)
    {
        Contract.Requires(count > 0 && count <= 10000000, "Input Penambahan Play Count 10000000");
        Contract.Requires(playCount <= int.MaxValue - count, "Play Count melebihi jumlah");
        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Penambahan Play Count Melebihi Batas");
        }
        playCount = count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID : " + id);
        Console.WriteLine("Title : " + title);
        Console.WriteLine("Lagu diputar : " + playCount);
    }
}