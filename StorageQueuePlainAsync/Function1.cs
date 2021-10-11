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
namespace StorageQueuePlainAsync
{
   using System.Threading.Tasks;
   using Microsoft.Azure.Functions.Worker;
   using Microsoft.Extensions.Logging;


   public static class Function1
    {
        [Function("Function1")]
        public static async Task Run([QueueTrigger("uplinkmessages", Connection = "AzureWebJobsStorage")] string myQueueItem, FunctionContext context)
        {
            var logger = context.GetLogger("Function1");

            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
