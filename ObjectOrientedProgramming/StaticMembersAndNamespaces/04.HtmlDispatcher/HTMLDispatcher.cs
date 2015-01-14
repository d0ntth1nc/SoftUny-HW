
namespace _04.HtmlDispatcher
{
    public static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string imgSrc, string alt, string title)
        {
            var img = new ElementBuilder("img");
            img.AddAttribute("title", title);
            img.AddAttribute("alt", alt);
            img.AddAttribute("src", imgSrc);
            return img;
        }

        public static ElementBuilder CreateURL(string url, string title, string text)
        {
            var a = new ElementBuilder("a");
            a.AddAttribute("href", url);
            a.AddAttribute("title", title);
            a.AddContent(text);
            return a;
        }

        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            var input = new ElementBuilder("input");
            input.AddAttribute("name", name);
            input.AddAttribute("type", type);
            input.AddAttribute("value", value);
            return input;
        }
    }
}
