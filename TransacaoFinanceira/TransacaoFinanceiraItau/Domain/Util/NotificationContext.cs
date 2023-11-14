using System;
using System.Collections.Generic;
using System.Linq;
using TransacaoFinanceira.Domain.Entities;

namespace TransacaoFinanceira.Domain.Util
{

	public class NotificationContext
    {
		private readonly List<Notification> _notifications;
		public IReadOnlyCollection<Notification> Notifications => _notifications;
		public bool HasNotifications => _notifications.Any();

		public NotificationContext()
		{
			_notifications = new List<Notification>();
		}

		public void AddNotification(string key, string message, object data)
		{
			_notifications.Add(new Notification(key, message, data));
		}

		public Notification GetNotifications() 
		{
			return _notifications[0];
		}


	}

}
