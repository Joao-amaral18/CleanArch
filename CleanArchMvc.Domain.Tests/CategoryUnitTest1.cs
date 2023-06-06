using System.ComponentModel.DataAnnotations;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [TestCase(TestName="Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () =>
        {
            var category = new Category(1, "Category Name");
        };
        action.Should()
            .NotThrow<ValidationException>();
    }
    [TestCase(TestName="Create Category With Negative Id")]
    public void CreateCategory_NegativeIdValue_ResultObjectValidState()
    {
        Action action = () =>
        {
            var category = new Category(-1, "Category Name");
        };
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid ID value.");
    }

    [TestCase(TestName = "Create Category With Short Name")]
    public void CreateCategory_ShortNameValue_ResultObjectValidState()
    {
        Action action = () =>
        {
            var category = new Category(1, "Ca");
        };
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name length has to be minimum 3.");
    }

    [TestCase(TestName = "Create Category With Null Name")]
    public void CreateCategory_NullNameValue_ResultObjectValidState()
    {
        Action action = () =>
        {
            var category = new Category(1, null);
        };
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required.");
    }
}