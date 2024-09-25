using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Source.Pages;

namespace UITests.Test.BadgeViewingTests
{
    public class MainPageTests
    { 
        MainPage mainPage;

        [SetUp]
        public void BeforeEachTest()
        {
            mainPage = new MainPage(AppiumSetup.App);
        }

        [Test]
        public void ClickGreetUserButton_ShouldDisplayGreeting()
        {
            try
            {
                // Arrange
                var username = mainPage.GetUsername();
                var expectedGreeting = $"Hello, {username}!";

                // Act
                mainPage.GreetUser();

                // Assert
                var greetingText = mainPage.GetGreeting();
                Assert.That(greetingText, Is.EqualTo(expectedGreeting));
            }
            catch (Exception e) 
            {
                Console.WriteLine("An error occurred while trying to greet the user: ");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
