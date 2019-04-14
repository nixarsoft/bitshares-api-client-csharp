using System;
namespace BitshareApiClient.BitsharesApiModel {
	public class BitsharesRequest {
		public String jsonrpc = "2.0";
		public Int32 id = 1;
		public String method;
		public Object[] @params;

		public BitsharesRequest(String method, Object[] @params) {
			this.@params = @params;
			this.method = method;
		}
	}
}
