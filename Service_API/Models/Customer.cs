namespace Service_API.Models
{
    public class Customer
    {

        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}