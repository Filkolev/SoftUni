
namespace Dispatcher
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class ElementBuilder
    {
        public static readonly string[] ValidHtmlTags = 
        { 
            "!DOCTYPE", "a", "abbr", "acronym", "address", "applet", "area", "article", "aside","audio","b","base", "basefont","bdi","bdo","big",
            "blockquote","body", "br","button", "canvas","caption","center","cite","code","col","colgroup","datalist","dd","del","details","dfn",
            "dialog","dir","div","dl","dt","em","embed","fieldset","figcaption","figure","font","footer","form","frame","frameset","h1","h2","h3",
            "h4","h5","h6","head","header","hgroup","hr","html","i","iframe","img","input","ins","kbd","keygen","label","legend","li","link",
            "main","map","mark","menu","menuitem","meta","meter","nav","noframes","noscript","object","ol","optgroup","option","output","p","param",
            "pre","progress","q","rp","rt","ruby","s","samp","script","section","select","small","source","span","strike","strong","style","sub",
            "summary","sup","table","tbody","td","textarea","tfoot","th","thead","time","title","tr","track","tt","u","ul","var","video","wbr"
        };

        public static readonly string[] SelfClosingTags =
        {
            "area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta", "param", "source", "track", "wbr"
        };

        private string tag;
        private int repetitions;
        private bool isSelfClosing;

        public string Tag
        {
            get { return this.tag; }
            private set
            {
                if (Array.IndexOf(ValidHtmlTags, value) == -1)
                {
                    throw new ArgumentException("The value entered isn't a valid HTML5 element.", "tag");
                }

                this.tag = value;
            }
        }

        public string Content { get; private set; }

        private Dictionary<string, string> Attributes { get; set; }

        public int Repetitions
        {
            get { return this.repetitions; }
            private set { this.repetitions = value; }
        }

        public bool IsSelfClosing
        {
            get { return this.isSelfClosing; }
            private set { this.isSelfClosing = value; }
        }

        public ElementBuilder(string tag)
        {
            this.Tag = tag;
            this.IsSelfClosing = Array.IndexOf(SelfClosingTags, tag) != -1;
            this.Attributes = new Dictionary<string, string>();
            this.Content = "";
            this.Repetitions = 1;
        }

        public void AddAttribute(string attribute, string value)
        {
            if (String.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentNullException("attribute", "Attribute cannot be empty.");
            }

            this.Attributes.Add(attribute, value);
        }

        public void AddContent(string contentToAdd)
        {
            if (this.IsSelfClosing)
            {
                throw new ArgumentException("Self-closing HTML element cannot have inner content.", "content");
            }

            this.Content = this.Content + contentToAdd;
        }

        public static ElementBuilder operator *(ElementBuilder currentElement, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count", "Count should be greater than zero.");
            }

            ElementBuilder newElement = new ElementBuilder(currentElement.Tag);
            newElement.Attributes = currentElement.Attributes;
            newElement.Content = currentElement.Content;
            newElement.Repetitions *= count;
            newElement.IsSelfClosing = currentElement.IsSelfClosing;

            return newElement;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            StringBuilder initial = new StringBuilder();

            initial.Append(String.Format("<{0}", this.Tag));

            foreach (var attribute in this.Attributes)
            {
                initial.Append(String.Format(" {0}=\"{1}\"", attribute.Key, attribute.Value));
            }

            if (this.IsSelfClosing)
            {
                initial.Append(" />");
            }
            else
            {
                initial.Append(String.Format(">{0}</{1}>", this.Content, this.Tag));
            }

            for (int i = 0; i < this.Repetitions; i++)
            {
                result.Append(initial);
            }

            return result.ToString();
        }
    }
}