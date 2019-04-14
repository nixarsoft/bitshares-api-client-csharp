using System;
namespace BitshareApiClient.BitsharesApiModel {
	public class Result {
		public int id;
		public String jsonrpc;
		public ErrorResult error = null;

		public class ErrorResult {
			public int code;
			public String message;
			public ErrorData data;

			public class ErrorData {
				public int code;
				public String name;
				public String message;
			}
		}
	}
}
