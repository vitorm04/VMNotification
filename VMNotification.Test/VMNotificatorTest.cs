using FluentAssertions;
using System.Linq;
using Xunit;

namespace VMNotification.Test
{
    public class VMNotificatorTest
    {
        private readonly Notificator _notificator;

        public VMNotificatorTest()
        {
            _notificator = new Notificator();
        }

        [Fact(DisplayName = "Must Add Error Message - String")]
        public void VMNotificator_AddError_Must_Add_Error_By_String()
        {
            //Arrange
            var errorMessage = "Error Message";
            var errorCode = "001";

            //Act
            _notificator.AddError(errorMessage, errorCode);

            //Assert
            var result = _notificator.GetErrors();
            result.Should().Contain(new Notification(errorMessage, errorCode));
        }

        [Fact(DisplayName = "Must Add Error Message - Notification Struct")]
        public void VMNotificator_AddError_Must_Add_Error_By_Notification()
        {
            //Arrange
            var error = new Notification("Error Message", "001");

            //Act
            _notificator.AddError(error);

            //Assert
            var result = _notificator.GetErrors();
            result.Should().Contain(error);
        }

        [Fact(DisplayName = "Must Add Errors Messages - Notification Struct")]
        public void VMNotificator_AddErrors_Must_Add_Errors_By_Notifications()
        {
            //Arrange
            var errors = new[]
            {
                new Notification("Error Message", "001"),
                new Notification("Error Message 2", "002")
            };

            //Act
            _notificator.AddErrors(errors);

            //Assert
            var result = _notificator.GetErrors();
            result.Should().Contain(errors);
        }

        [Fact(DisplayName = "Must Add Errors Messages - String")]
        public void VMNotificator_AddErrors_Must_Add_Errors_By_String()
        {
            //Arrange
            var errors = new[]
            {
                "Error Message",
                "Error Message 2"
            };

            //Act
            _notificator.AddErrors(errors);

            //Assert
            var result = _notificator.GetErrors();
            result.Select(x => x.Message).Should().Contain(errors);
        }


        [Fact(DisplayName = "Must Remove All Errors")]
        public void VMNotificator_ClearNotifications_Must_Remove_Errors()
        {
            //Arrange
            var notification = new Notification("Notification Message", "001");
            _notificator.AddError(notification);

            //Act
            _notificator.ClearErrors();

            //Assert
            var result = _notificator.GetErrors();
            result.Should().BeEmpty();
        }

        [Fact(DisplayName = "Must Add Notification Message - String")]
        public void VMNotificator_AddNotification_Must_Add_Notification_By_String()
        {
            //Arrange
            var notificationMessage = "Notification Message";
            var notificationCode = "001";

            //Act
            _notificator.AddNotification(notificationMessage, notificationCode);

            //Assert
            var result = _notificator.GetNotifications();
            result.Should().Contain(new Notification(notificationMessage, notificationCode));
        }

        [Fact(DisplayName = "Must Add Notification Message - Notification")]
        public void VMNotificator_AddNotification_Must_Add_Notification_By_NotificationStruct()
        {
            //Arrange
            var notification = new Notification("Notification Message", "001");

            //Act
            _notificator.AddNotification(notification);

            //Assert
            var result = _notificator.GetNotifications();
            result.Should().Contain(notification);
        }

        [Fact(DisplayName = "Must Add Notifications Messages - Notification Struct")]
        public void VMNotificator_AddNotifications_Must_Add_Notification_By_NotificationStruct()
        {
            //Arrange
            var notifications = new[]
            {
                new Notification("Notification Message", "001"),
                new Notification("Notification Message 2", "002")
            };

            //Act
            _notificator.AddNotifications(notifications);

            //Assert
            var result = _notificator.GetNotifications();
            result.Should().Contain(notifications);
        }

        [Fact(DisplayName = "Must Add Notifications Messages - String")]
        public void VMNotificator_AddNotifications_Must_Add_Notification_By_String()
        {
            //Arrange
            var notifications = new[]
            {
                "Notification Message", "001",
                "Notification Message 2", "002"
            };

            //Act
            _notificator.AddNotifications(notifications);

            //Assert
            var result = _notificator.GetNotifications();
            result.Select(x => x.Message).Should().Contain(notifications);
        }


        [Fact(DisplayName = "Must Remove All Notifications")]
        public void VMNotificator_ClearNotifications_Must_Remove_Notifications()
        {
            //Arrange
            var notification = new Notification("Notification Message", "001");
            _notificator.AddNotification(notification);

            //Act
            _notificator.ClearNotifications();

            //Assert
            var result = _notificator.GetNotifications();
            result.Should().BeEmpty();
        }
    }
}
