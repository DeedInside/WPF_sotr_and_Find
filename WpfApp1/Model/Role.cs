namespace WpfApp1.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
