using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace VkAkb.Controllers
{
	public class Employee 
	{
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public double HourlySalary { get; set; }

	}
	public class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator() 
		{ 
			RuleFor(f => f.Name)
				.NotEmpty()
				.Length(3,25)
				.WithMessage("İsim kısmı boş bırakılamaz yada en az 3,en fazla 25 karakter içermelidir");
			RuleFor(f => f.DateOfBirth)
				.NotEmpty()
				.LessThanOrEqualTo(new DateTime(2005, 01, 01))
				.WithMessage("Girlen doğum tarihi 18 yaşından küçük olamaz")
				.GreaterThanOrEqualTo(new DateTime(1933,01, 01))
				.WithMessage("Girlen doğum tarihi 90 yaşından büyük olamaz");
			RuleFor(f => f.Email)
				.NotEmpty()
				.EmailAddress()
				.Length(13, 30);
			RuleFor(f => f.Phone)
				.NotEmpty()
				.Matches(@"^[\d]+$")
				.WithMessage("Lütfen Sadece sayı giriniz.");
			RuleFor(f => f.HourlySalary)
				.NotEmpty()
				.GreaterThanOrEqualTo(0)
				.LessThanOrEqualTo(2000)
				.WithMessage("0 dan küçük 2000 den büyük olamaz");

		}

	}

	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		public EmployeeController()
		{
		}

		[HttpPost]
		public Employee Post([FromBody] Employee value)
		{
			return value;
		}
	}
}