

namespace Dispatcher
{
    using System;

    class HTMLDispatcherTest
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 3);

            // ElementBuilder invalidTag = new ElementBuilder("dfd"); // matched against list of valid tags
            ElementBuilder p = new ElementBuilder("p");
            // p.AddAttribute("", ""); // empty attribute not accepted
            p.AddAttribute("style", "font-size: 5px;");
            Console.WriteLine(p);
            p.AddContent("This is a paragraph");
            Console.WriteLine(p);
            // Console.WriteLine(p * 0); // only positive values defined for operator
            Console.WriteLine(p * 15);

            ElementBuilder image = HTMLDispatcher.CreateImage(@"http://www.google.bg", "missing", "Google");
            Console.WriteLine(image);
            // image.AddContent("can't do that"); // self-closing tag doesn't have content
            ElementBuilder link = HTMLDispatcher.CreateURL(@"https://facebook.com", "Facebook", "Click me!");
            Console.WriteLine(link);
            ElementBuilder input = HTMLDispatcher.CreateInput("radio", "gender", "0");
            Console.WriteLine(input);
            // input.AddContent("nope...");

            string[] tags = ElementBuilder.GetValidHtmlTags();
            tags[0] = "removed";
            Console.WriteLine(ElementBuilder.ValidHtmlTags[0]); // List of valid tags cannot be modified
        }
    }
}


