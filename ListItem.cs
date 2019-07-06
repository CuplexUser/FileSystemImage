namespace FileSystemImage
{
    public class ListItem
    {
        public ListItem()
        {
        }

        public ListItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}