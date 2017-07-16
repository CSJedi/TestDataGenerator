using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using TestDataGenerator.BL;
using TestDataGenerator.Data;

namespace TestDataGenerator.BL.Test
{
    [TestFixture]
    class ScriptGeneratorTest
    {
        private IScriptGenerator _generator;
        public void Init()
        {
            _generator = null;
        }

        [Test]
        public void GenerateUser_NameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string name = entity.Name;
            Assert.That(name, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_SurnameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string surname= entity.Surname;
            Assert.That(surname, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_EmailRequired()
        {
   
            UserEntity entity = _generator.GenerateUser();
            string email = entity.Email;
            Assert.That(email, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_LoginRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string login = entity.UserLogin;
            Assert.That(login, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_PasswordRequired()
        {
            IScriptGenerator generator = null;
            UserEntity entity = generator.GenerateUser();
            string password = entity.Password;
            Assert.That(password, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_RegistrationDatePeriod()
        {
            UserEntity entity = _generator.GenerateUser();
            DateTime registrationDate = entity.ReggistrationDate;
            Assert.That(registrationDate, Is.InRange(new DateTime(2010, 1, 1), DateTime.Now ));
        }

        [Test]
        public void GenerateUser_GetValueLine()
        {
            UserEntity user = new UserEntity()
            {
                Name = "Vasya",
                Surname = "Petrov",
                Patronymic = "Olegovich",
                UserLogin = "Vasya",
                Email = "vasya@gmail.com",
                Password = "Vasya123",
                ReggistrationDate = new DateTime(2017, 1, 1)
            };

            const string EXPECTED_RESULT = @"VALUES ('Vasya', 'Petrov', 'Olegovich', 'vasya@gmail.com', 'Vasya', 'Vasya123', '20170101')";
            string result = _generator.GetValueLine(user);
            Assert.That(result, Is.EqualTo(EXPECTED_RESULT));
        }

        [Test]
        public void GenerateUser_GetInsertLine()
        {
            const string EXPECTED_RESULT = @"INSERT INTO BlogUser (Name, Surname, Patronymic, Email, UserLogin, Password, RegistrationDate )";
            string result = _generator.GetInsertLine();
            Assert.That(result, Is.EqualTo(EXPECTED_RESULT));
        }
    }
}
