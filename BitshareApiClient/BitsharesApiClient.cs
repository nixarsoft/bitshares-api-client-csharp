using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

using BitshareApiClient.BitsharesApiModel;

/******************************************************
 * 
 * http://docs.bitshares.org/api/rpc.html
 * 
 * 
 */

namespace BitshareApiClient {
	public class BitsharesApiClient {
		private String result = null;
		private readonly String url;

		public String Result {
			get { return result; }
			set { result = value; }
		}

		public BitsharesApiClient(String url) {
			this.url = url;
		}

		public String request(BitsharesRequest bitsharesRequest) {
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.ContentType = "application/json";
				request.Method = "POST";

				using (var streamWriter = new StreamWriter(request.GetRequestStream())) {
					string json = new JavaScriptSerializer().Serialize(bitsharesRequest);
					Console.WriteLine(">>>json: " + json);

					streamWriter.Write(json);
				}

				var response = (HttpWebResponse)request.GetResponse();
				using (var streamReader = new StreamReader(response.GetResponseStream())) {
					this.result = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("<<<result: " + result);
			return this.result;
		}

		// http://docs.bitshares.org/api/database.html get_account_balances
		public Result getAccountBalancesResult(String accountName, object[] assets) {
			BitsharesRequest requestObj = new BitsharesRequest("get_account_balances", assets);
			return getAccountBalancesResult(requestObj);
		}

		public Result getAccountBalancesResult(BitsharesRequest requestObj) {
			String resultStr = request(requestObj);
			Result resultObj;

			resultObj = new JavaScriptSerializer().Deserialize<GetAccountBalancesResult>(resultStr);
			return resultObj;
		}

		// http://docs.bitshares.org/api/database.html get_accounts
		public Result getAccounts(String accountName, object[] assets) {
			BitsharesRequest requestObj = new BitsharesRequest("get_accounts", assets);
			return getAccounts(requestObj);
		}

		public Result getAccounts(BitsharesRequest requestObj) {
			String resultStr = request(requestObj);
			Result resultObj;

			resultObj = new JavaScriptSerializer().Deserialize<GetAccountsResult>(resultStr);
			return resultObj;
		}
	}
}
