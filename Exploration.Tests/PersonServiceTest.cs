using Spw4.Exploration;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using Xunit;
using System.Net.WebSockets;

namespace Exploration.Tests
{
    public class PersonServiceTest
    {
        private readonly PersonService _personService;  
        private readonly IPersonRepository _personRepository;

        public PersonServiceTest()
        {
            _personRepository = Substitute.For<IPersonRepository>();
            _personService = new PersonService(_personRepository);
        }

        [Fact]
        void GetAverageAge_ShouldReturnCorrectAverage()
        {
            // Arrange
            var expected = 35;
            _personRepository.ReadAllPersons().Returns(new List<Person>
            {
                new Person("Alice", 30),
                new Person("Bob", 40),
            });

            // Act
            var actual = _personService.GetAverageAge();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        void Register_WithValidNameAndAge_Succeeds()
        {
            // Arrange
            var name = "Alice";
            var age = 30;

            // Act
            _personService.Register(name, age);

            // Assert
            _personRepository.Received(1).CreatePerson(Arg.Is<Person>(p => p.Name == name && p.Age == age));
        }

        [Fact]
        void FindPerson_ReturnsCorrectResult()
        {
            // Arrange
            var alice = new Person("Alice", 30);
            _personRepository.ReadPersonByName("Alice").Returns(alice);

            // Act
            var actual = _personService.FindPerson("Alice");

            // Assert
            Assert.Equal(alice.Name, actual?.Name);
            Assert.Equal(alice.Age, actual?.Age);
        }
    }
}
