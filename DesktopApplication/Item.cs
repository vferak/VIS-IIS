namespace DesktopApplication
{
    public class Item<T>
    {
        public T Model { get; set; }

        public string Text { get; set; }

        public Item(T model, string text)
        {
            Model = model;
            Text = text;
        }
        
        public override string ToString()
        {
            return Text;
        }
    }
}