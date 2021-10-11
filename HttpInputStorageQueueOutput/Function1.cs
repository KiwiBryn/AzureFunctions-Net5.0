// Copyright (c) October 2021, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// https://github.com/Azure/azure-functions-dotnet-worker/wiki/.NET-Worker-bindings
//---------------------------------------------------------------------------------
namespace HttpInputStorageQueueOutput
{
	using System.Net;
	using System.Threading.Tasks;

	using Microsoft.Azure.Functions.Worker;
	using Microsoft.Azure.Functions.Worker.Http;
	using Microsoft.Azure.WebJobs;
	using Microsoft.Extensions.Logging;


	[StorageAccount("AzureWebJobsStorage")]
	public static class Function1
	{
		[Function("Uplink")]
		public static async Task<HttpTriggerUplinkOutputBindingType> Uplink([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req, FunctionContext context)
		{
			var logger = context.GetLogger("UplinkMessage");

			logger.LogInformation("Uplink processed");
			
			var response = req.CreateResponse(HttpStatusCode.OK);

			return new HttpTriggerUplinkOutputBindingType()
			{
				Name = await req.ReadAsStringAsync(),
				HttpReponse = response
			};
		}

		public class HttpTriggerUplinkOutputBindingType
		{
			[QueueOutput("uplink")]
			public string Name { get; set; }

			public HttpResponseData HttpReponse { get; set; }
		}
	}
}
