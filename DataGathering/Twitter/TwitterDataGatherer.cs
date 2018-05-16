using Common.DataGathering.Interfaces;
using DataGathering.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DataGathering.Twitter
{
	public class TwitterDataGatherer : IDataGatherer
	{
		public TwitterDataGatherer(string credentials)
		{
			string access_token = "";
			HttpWebRequest post = WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;
			post.Method = "POST";
			post.ContentType = "application/x-www-form-urlencoded";
			post.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
			byte[] reqbody = Encoding.UTF8.GetBytes("grant_type=client_credentials");
			post.ContentLength = reqbody.Length;
			using (var req = post.GetRequestStream())
			{
				req.Write(reqbody, 0, reqbody.Length);
			}
			try
			{
				string respbody = null;
				using (var resp = post.GetResponse().GetResponseStream())//there request sends
				{
					var respR = new StreamReader(resp);
					respbody = respR.ReadToEnd();
				}
				//TODO use a library to parse json
				access_token = respbody.Substring(respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length, respbody.IndexOf("\"}") - (respbody.IndexOf("access_token\":\"") + "access_token\":\"".Length));
			}
			catch //if credentials are not valid (403 error)
			{
				//TODO
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IDataItem Get()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IDataItem> Stream()
		{
			throw new NotImplementedException();
		}
	}
}
