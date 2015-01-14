using System;

namespace _04.HtmlDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("localhost/asd.jpg", "meaningless", "meaningless"));
            Console.WriteLine(HTMLDispatcher.CreateInput("text", "nameless", "Sexy"));
            Console.WriteLine(HTMLDispatcher.CreateURL("https://google.com", "google", "google.com"));
        }
    }
}
