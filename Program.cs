using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(title.Length <= 100 && title != null, "Judul video memiliki panjang maksimal 100 karakter dan tidak berupa null.");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 10000000, "Input penambahan play count maksimal 10.000.000 per panggilan method-nya.");

        try
        {
            checked { this.playCount += count; }
        }
        catch (OverflowException err)
        {
            Console.WriteLine(err.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Detail Video:");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Video: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount.ToString("N0"));
    }
}

public class Program
{
    public static void Main()
    {
        SayaTubeVideo vid = new SayaTubeVideo("Tutorial Design By Contract – MuhammadZaidanRafif_Praktikan");
        for (int i = 0; i < 1000; i++)
        {
            vid.IncreasePlayCount(1000000);
        }
        vid.PrintVideoDetails();
    }
}
