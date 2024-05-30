namespace DDD.Domain.Entities;

public class Customer : Entity
{
    public Customer(string name, string document)
    {
        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        IsActive = true;
    }
    public string Name { get; set; }
    public string Document { get; set; }
    public bool IsActive { get; set; }
}