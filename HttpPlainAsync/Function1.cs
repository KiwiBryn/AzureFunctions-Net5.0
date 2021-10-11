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
//---------------------------------------------------------------------------------
namespace HttpPlainAsync
{
	using System.Net;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Azure.Functions.Worker;
	using Microsoft.Azure.Functions.Worker.Http;
	using Microsoft.Extensions.Logging;


	public static class Function1
	{
		// AuthorizationLevel.Function changed to anonymous to make calls from Fiddler easier
		[Function("PlainAsync")]
		public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData request, FunctionContext executionContext)
		{
			var logger = executionContext.GetLogger("UplinkMessage");

			logger.LogInformation("C# HTTP trigger function processed a request.");

			var response = request.CreateResponse(HttpStatusCode.OK);

			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			response.WriteString("Welcome to Azure Functions!");

			return new OkResult();
		}
	}
}
