using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VMNotification
{
    public class Notificator
    {
        public List<Notification> _notifications { get; }
        public List<Notification> _errors { get; }

        public Notificator()
        {
            _notifications = new List<Notification>();
            _errors = new List<Notification>();
        }

        /// <summary>
        /// Add a Notification in the current list of Notifications.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        /// <param name="notification"></param>
        public void AddNotification(Notification notification)
        {
            ValidateNullArgument(notification.Message);
            _notifications.Add(notification);
        }

        /// <summary>
        /// Add a Notification in the current list of Notifications, using a message and code string.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddNotification(string message, string code = default)
        {
            ValidateNullArgument(message);
            _notifications.Add(new Notification(message, code));
        }

        /// <summary>
        /// Add a range of notifications in the current list of Notifications.
        /// </summary>
        /// <param name="notifications"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notifications or message is null</exception>
        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            ValidateNullArgument(notifications);
            if (notifications.Any(notification => notification.Message is null))
                throw new ArgumentNullException(nameof(Notification.Message));
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Add a range of string messages in the current list of notifications.
        /// </summary>
        /// <param name="messages"></param>
        /// /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddNotifications(IEnumerable<string> messages)
        {
            ValidateNullArgument(messages);
            if (messages.Any(message => message is null))
                throw new ArgumentNullException(nameof(messages));
            _notifications.AddRange(messages.Select(message => new Notification(message)));
        }


        /// <summary>
        /// Return all Errors.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetErrors()
        {
            return _errors;
        }

        /// <summary>
        /// Remove all Notifications.
        /// </summary>
        public void ClearNotifications()
        {
            _notifications.Clear();
        }


        /// <summary>
        /// Add an Error in the current list of Errors.
        /// </summary>
        /// <param name="error"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddError(Notification error)
        {
            ValidateNullArgument(error.Message);
            _errors.Add(error);
        }

        /// <summary>
        /// Add errors by ValidateResult - FluentValidator.
        /// </summary>
        /// <param name="result"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when result is null</exception>
        public void AddError(ValidationResult result)
        {
            ValidateNullArgument(result);
            _errors.AddRange(result.Errors.Select(error => new Notification(error.ErrorMessage, error.ErrorCode)));
        }

        /// <summary>
        /// Add a Notification in the current list of Errors, using a message and code string.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddError(string message, string code = default)
        {
            ValidateNullArgument(message);
            _errors.Add(new Notification(message, code));
        }

        /// <summary>
        /// Return All Notifications.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        /// Add a Notification in the current list of Errors.
        /// </summary>
        /// <param name="errors"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddErrors(IEnumerable<Notification> errors)
        {
            if (errors.Any(error => error.Message is null))
                throw new ArgumentNullException(nameof(Notification.Message));
            _errors.AddRange(errors);
        }

        /// <summary>
        /// Add a range of string messages in the current list of Errors.
        /// </summary>
        /// <param name="messages"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when notification message is null</exception>
        public void AddErrors(IEnumerable<string> messages)
        {
            ValidateNullArgument(messages);

            if (messages.Any(message => message == null))
                throw new ArgumentNullException(nameof(messages));
            _errors.AddRange(messages.Select(message => new Notification(message)));
        }

        /// <summary>
        /// Remove all Errors.
        /// </summary>
        public void ClearErrors()
        {
            _errors.Clear();
        }

        /// <summary>
        /// Return true if the error list is empty.
        /// </summary>
        public bool IsValid => !_errors.Any();

        private void ValidateNullArgument(object message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));
        }
    }
}
