using FluentAssertions;
using CleanArchMvc.Domain.Entities;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName ="Create Product With Valid State")]
        public void CreateProduct_WithValidaState_ObjectValidState()
        {
            Action action = () => new Product(1,"Product", "Product", 9.99m, 10, "Image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id Value")]
        public void CreateProduct_WithInvalidIdValue_ObjectValidState()
        {
            Action action = () => new Product(-1, "Product", "Product", 9.99m, 10, "Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Null Name Value")]
        public void CreateProduct_WithNullNameValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, null, "Product", 9.99m, 10, "Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyNameValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "","Product", 9.99m, 10, "Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Pr", "Produto", 9.99m, 10, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Null Description Value")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", null, 9.99m, 10, "Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, Description is required");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", "", 9.99m, 10, "Image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, Description is required");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", "Pr", 9.99m, 10, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", "Product", -1, 10, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock Value")]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", "Product", 9.99m, -1, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Invalid Image Name")]
        public void CreateProduct_WithInvalidImageName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Product", "Product", 9.99m, 10, "Image Toooooooooooooooooo Longggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Crate Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product", "Product", 9.28m, 10, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Null Image Name NullReference")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product", "Product", 9.28m, 10, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Theory(DisplayName ="Create Product With Stock Value Negative")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product", 9.09m, value, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }
    }
}
