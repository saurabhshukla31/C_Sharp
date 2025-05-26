using System;
using System.Collections;


public class Album
{
    public string Title { get; set; }
    public string Artist { get; set; }

   
}
public class Program
{
    private static bool IsValidInput(string input)
    {
        return String.IsNullOrWhiteSpace(input);
    }

    private static void DisplayAlbums(ArrayList albums)
    {
        foreach(Album items in albums)
        {
            Console.WriteLine($"Title: {items.Title}, Artist: {items.Artist}");
        }
    }

    public static void Main(string[] args)
    {
        ArrayList a = new ArrayList();
        while(true)
        {
            string title = Console.ReadLine();
            Album album = new Album();
            if(title=="quit")
            {
                break;
            }
            else
            {
                album.Title=title;
            }
            
            string artist = Console.ReadLine();
            if(artist=="quit")
            {
                break;
            }
            else
            {
                album.Artist=artist;
            }

            a.Add(album);

        }
        DisplayAlbums(a);

    }
}
