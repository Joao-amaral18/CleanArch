using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(name),
            "Invalid name. Name is required.");

        DomainExceptionValidation.When(
            name.Length < 3,
            "Invalid name. Name length has to be minimum 3.");

        DomainExceptionValidation.When(
            string.IsNullOrEmpty(description),
            "Invalid Description. Description is required.");

        DomainExceptionValidation.When(
            description.Length < 5,
            "Invalid description. Description length has to be minimum 5.");

        DomainExceptionValidation.When(
            price < 0,
            "Invalid price. Price has to be greater than zero.");

        DomainExceptionValidation.When(
            stock < 0,
            "Invalid stock. Stock has to be greater than zero.");

        DomainExceptionValidation.When(
            image?.Length > 250 || image?.Length < 3,
            "Invalid image. Image length has to be minimum 2 and maximum 250.");
    }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}