namespace Entities
{
    /// <summary>
    /// Clase POCO que permite almacenar información del la personas 
    /// </summary>
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public decimal Amount { get; set; }
    }
}
