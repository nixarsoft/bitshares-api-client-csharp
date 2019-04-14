using System;
using System.Collections.Generic;

namespace BitshareApiClient.BitsharesApiModel {
	public class GetAccountBalancesResult : Result {
		public List<GetAccountBalancesResultItem> result;

		public class GetAccountBalancesResultItem {
			public int amount;
			public String asset_id;
		}
	}
}
