using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VbApi.Controllers;

namespace VbApi.Controllers
{
	public class Staff
	{
		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? Phone { get; set; }

		public decimal? HourlySalary { get; set; }
	}
	public class StaffValidator : AbstractValidator<Staff>
	{
		public StaffValidator()
		{
			RuleFor(f => f.Name)
				.NotNull()
				.Length(4, 30)
				.WithMessage("İsim kısmı boş bırakılamaz yada en az 4,en fazla 30 karakter içermelidir");
			RuleFor(f => f.Email)
				.NotEmpty()
				.EmailAddress()
				.Length(13, 30)
				.WithMessage("Girilen email adresi doğru değildir.");
			RuleFor(f => f.Phone)
				.NotEmpty()
				.Matches(@"^[\d]+$")
				.WithMessage("Lütfen Sadece sayı giriniz.");
			RuleFor(f => f.HourlySalary)
				.NotEmpty()
				.GreaterThan(0)
				.WithMessage("0 dan küçük 3000 den büyük olamaz")
				.LessThanOrEqualTo(3000)
				.WithMessage("0 dan küçük 3000 den büyük olamaz");

		}

	}
}

	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		public StaffController()
		{
		}

		[HttpPost]
		public Staff Post([FromBody] Staff value)
		{
			return value;
		}
	}
