using BadgeViewer.Core.Services;
using BadgeViewer.Dal.Dal;
using BadgeViewer.Dal.Models;
using BadgeViewer.Dal.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Core.CLTest.Services
{
    public class UserManagerServiceTests
    {
        private Mock<IBadgeDataRepository> badgeDataRepository;
        private Mock<IUserDal> userDal; 
        private UserManagerService userManagerService;

        void Setup()
        {
            badgeDataRepository = new Mock<IBadgeDataRepository>();
            userDal = new Mock<IUserDal>();

            badgeDataRepository.Setup(m => m.User).Returns(userDal.Object);

            userManagerService = new UserManagerService(badgeDataRepository.Object);
        }

        [Fact]
        public async Task ReadAsync_Returns_UserWithSameUID()
        {
            //Arrange
            Setup();

            var userUid = Guid.NewGuid();

            userDal.Setup(u => u.ReadByUIDAsync(userUid)).ReturnsAsync(new UserDto { uid = userUid });

            //Act
            var user = await userManagerService.ReadAsync(userUid);

            //Assert
            Assert.Equal(userUid, user.uid);
        }

        [Fact]
        public async Task ClearUser_CallUpdateLastViewedTime_ThrowsException()
        {
           //Arrange
            Setup();

            var userUid = Guid.NewGuid();
            var user = await userManagerService.ReadAsync(userUid);

            userDal.Setup(u => u.ReadByUIDAsync(userUid)).ReturnsAsync(new UserDto { uid = userUid });

            //Act
            userManagerService.ClearUser();

            //Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => userManagerService.UpdateLastViewedTime(DateTime.Now));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        public async void UpdateUsername_Returns_UserWithUpdatedUsername(string username)
        {
            //Arrange
            Setup();
            var userUid = Guid.NewGuid();

            userDal.Setup(u => u.ReadByUIDAsync(userUid)).ReturnsAsync(new UserDto { uid = userUid });
            userDal.Setup(u => u.UpdateAsync(It.IsAny<UserDto>())).ReturnsAsync(new UserDto { username = username });

            await userManagerService.ReadAsync(userUid);

            //Act
            var user = await userManagerService.UpdateUsername(username);

            //Assert
            Assert.Equal(username, user.username);
        }

    }
}
