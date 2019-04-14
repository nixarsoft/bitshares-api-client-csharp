using System;
using System.Collections.Generic;

using BitshareApiClient.BitsharesApiModel;

namespace BitshareApiClient {
	class MainClass {
		public static void Main(string[] args) {
			BitsharesApiClient apiClient;
			String result;
			Result resultObj;

			// http://docs.bitshares.org/api/rpc.html
			apiClient = new BitsharesApiClient("http://66.165.226.154:8090/rpc");

			// manuel call and get result as json string
			var requestParams = new Dictionary<string, Object[]>();
			requestParams.Add("get_accounts", new Object[] { new Object[] { "1.2.0", "1.2.1" } });
			requestParams.Add("get_account_balances", new Object[] { "committee-account", new object[] { } });
			requestParams.Add("list_assets", new Object[] { 0, 100 });
			requestParams.Add("get_order_book", new Object[] { "BTC", "META1", 10 });
			requestParams.Add("get_ticker", new Object[] { "BTC", "META1" });
			requestParams.Add("get_24_volume", new Object[] { "BTC", "META1" });
			requestParams.Add("get_trade_history", new Object[] { "BTC", "META1" });
			requestParams.Add("help", new Object[] { });

			foreach (var pair in requestParams) {
				result = apiClient.request(new BitsharesRequest(pair.Key, pair.Value));
				Console.WriteLine(apiClient.Result);
				Console.WriteLine();
			}

			//call directly methods

			// success example
			resultObj = apiClient.getAccountBalancesResult("get_account_balances", new Object[] { "committee-account", new object[] { } });
			if (resultObj.error != null) {
				Console.WriteLine(resultObj.error.message);
			}
			else {
				var accountBalancesResult = (GetAccountBalancesResult)resultObj;

				if (accountBalancesResult.result != null & accountBalancesResult.result.Count > 0)
					Console.WriteLine(accountBalancesResult.result[0].amount);
				else
					Console.WriteLine("Account has zero balance");
			}

			// error example
			resultObj = apiClient.getAccountBalancesResult("get_account_balances", new Object[] { "committee-account" });
			if (resultObj.error != null) {
				Console.WriteLine(resultObj.error.message);
			}
			else {
				var accountBalancesResult = (GetAccountBalancesResult)resultObj;

				if (accountBalancesResult.result != null & accountBalancesResult.result.Count > 0)
					Console.WriteLine(accountBalancesResult.result[0].amount);
				else
					Console.WriteLine("Account has zero balance");
			}
		}
	}
}
