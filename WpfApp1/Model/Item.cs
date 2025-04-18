namespace WpfApp1.Model
{
    public class Item
    {
        public int Id { get; set; }
        /// <summary>
        /// Вид инвентаря;
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// − Описание инвентаря;
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// − Размер инвентаря
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// − Цена бронирования(на час);
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// − Наличие инвентаря;
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// − Наличие скидок;
        /// </summary>
        public int? Discount { get; set; } = null;
        public int? IdClient { get; set; }
        public User? Client { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description} - {Price} ({IsValid})";
        }
        public Item() { }
    }
}
