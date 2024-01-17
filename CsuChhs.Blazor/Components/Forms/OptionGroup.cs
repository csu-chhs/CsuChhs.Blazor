namespace CsuChhs.Blazor.Components.Forms
{
    public class OptionGroup
    {
        public int OpenIndex { get; set; }
        public int CloseIndex { get; set; }
        public string Label { get; set; }

        public OptionGroup(int openIndex, int closeIndex, string label)
        {
            OpenIndex = openIndex;
            CloseIndex = closeIndex;
            Label = label;
        }
    }
}
