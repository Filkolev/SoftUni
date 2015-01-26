namespace Dispatcher
{

    static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string source, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAttribute("src", source);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);

            return image;
        }

        public static ElementBuilder CreateURL(string url, string title, string text)
        {
            ElementBuilder link = new ElementBuilder("a");
            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);

            return link;
        }

        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);

            return input;
        }
    }
}

