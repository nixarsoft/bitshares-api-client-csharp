using System;
namespace BitshareApiClient.BitsharesApiModel {
	public class GetAccountsResult : Result {
		public String id;
		public String membership_expiration_date;
		public Int64 network_fee_percentage;
		public Int64 referrer_rewards_percentage;
		public String name;
	}
}
