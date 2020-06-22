using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Application.Commands;
using Application.Dto;
using Application.Services;
using DataAccess;
using Domen.Entities;
using FluentValidation;
using Implementation.Services;
using Implementation.Validation;

namespace Implementation.Commands
{
    public class RegistrationCommand : IRegistrationCommand
    {
        private readonly DataContext _context;
        private readonly IEmailService _email;
        private readonly CreateUserValidate _validations;
        public RegistrationCommand(DataContext context, CreateUserValidate validations, IEmailService email)
        {
            _context = context;
            _validations = validations;
            _email = email;
        }

        public string Name => "User registration";

        public void Execute(UserDto request)
        {
            _validations.ValidateAndThrow(request);

            var newUser = new User();
            newUser.Email = request.Email;
            newUser.Password = request.Password;
            newUser.Username = request.Username;
            newUser.RoleId = 1;

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var body = String.Empty;
            using (StreamReader reader = new StreamReader(@"C:\Users\Rajko\Desktop\C#\MercedesProject\MercedesImplementation\Newsletters\EmailRegister.html"))
            {

                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Email}}", request.Email);
            _email.EmailSender(request.Email, body);     
        }
    }
}
