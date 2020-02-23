namespace NorthWindCoreLibrary.HelperClasses
{
    public class CustomerLister
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public override string ToString() => Name;

    }
}