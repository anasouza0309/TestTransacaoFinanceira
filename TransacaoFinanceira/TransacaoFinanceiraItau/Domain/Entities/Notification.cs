using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Domain.Entities
{
    public class Notification
    {
		public string Key { get; }
		public string Message { get; }
		public object Data { get; set; }

		public Notification(string key, string message, object data)
		{
			Key = key;
			Message = message;
			Data = data;
		}
	}
}
