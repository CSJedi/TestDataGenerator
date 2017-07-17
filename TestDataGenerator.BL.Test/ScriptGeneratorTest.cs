using System;
using NUnit.Framework;
using TestDataGenerator.Data;

namespace TestDataGenerator.BL.Test
{
    [TestFixture]
    class ScriptGeneratorTest
    {
        private ScriptGenerator _generator;

        [SetUp]
        public void Init()
        {
            IRepository repository = new RepositoryMock();
            _generator = new ScriptGenerator(repository);
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
            UserEntity entity = _generator.GenerateUser();
            string password = entity.Password;
            Assert.That(password, Is.Not.Empty);
        }

        [Test]
        [Repeat(1000)]
        public void GenerateUser_RegistrationDatePeriod()
        {
            UserEntity entity = _generator.GenerateUser();
            DateTime registrationDate = entity.RegistrationDate;
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
                RegistrationDate = new DateTime(2017, 1, 1)
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

        [Test]
        public void MergeLines_Test()
        {
            const string INSERT_LINE = "INSERT LINE";
            string[] valueLines = { "VALUE LINE 1", "VALUE LINE 2"};
            string EXPECTED_RESULT = $"INSERT LINE{Environment.NewLine}VALUE LINE 1{Environment.NewLine},VALUE LINE 2{Environment.NewLine}";

            string result = _generator.MergeLines(valueLines, INSERT_LINE);
            Assert.That(result, Is.EqualTo(EXPECTED_RESULT));

        }
    }
}
