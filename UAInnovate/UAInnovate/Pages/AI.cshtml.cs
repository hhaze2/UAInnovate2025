using System;
using Microsoft.AspNetCore.Mvc;
using UAInnovate.Data;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OpenAI.Chat;
using System.ClientModel;
using Azure.AI.OpenAI;
using System.Diagnostics;

namespace UAInnovate.Pages
{
	public class AI : PageModel
	{
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        private const string ApiEndpoint = "https://fall2024-hrhazelwood-openai.openai.azure.com/";
        private const string AiDeployment = "gpt-35-turbo";

        public string supplyRun { get; set; }

        public AI(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        public async Task OnGetAsync()
        {
            supplyRun = await suggestSupplyRun();
        }
        

        public async Task<string> suggestSupplyRun()
        {
            var InventoryCall = _context.Inventory.Select(g => new { itemName = g.ItemName, avg = g.AvgAmount, curr = g.CurrentAmount, percent = g.CurrentAmount / g.AvgAmount })
                                                    .ToArray();

            var secret = _config["OpenAi:API_Key"] ?? throw new Exception("OpenAI:API_Key does not exist in the current Configuration");
            ApiKeyCredential ApiCredential = new(secret);
            ChatClient client = new AzureOpenAIClient(new Uri(ApiEndpoint), ApiCredential).GetChatClient(AiDeployment);
            //var connectionstring = _configuration.GetConnectionString("SecretConnection");

            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlite(connectionstring);

            //using (ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options))
            //{

            //}

            var lowOrNoneNames = new List<string>();
            var lowOrNoneNums = new List<int?>();
            foreach (var item in InventoryCall)
            {
                if (item.percent <= 0.25)
                {
                    lowOrNoneNames.Add(item.itemName);
                    if (item.avg == null)
                    {
                        //placeholder num
                        lowOrNoneNums.Add(30);
                    }
                    else
                    {
                        lowOrNoneNums.Add(item.avg);
                    }


                }
            }

            if(lowOrNoneNames.Count() == 0)
            {
                return "All items in stock, no order needed!";
            }
            

            var messages = new ChatMessage[]
            {
                    new SystemChatMessage($"You are in charge of managing office supplies. You need the following items: { string.Join(",", lowOrNoneNames)}. For each item, you need the following amounts in the same order of the items: { string.Join(",", lowOrNoneNums)} "),
                    //new UserChatMessage($"Generate a shopping list based on the following needed items: {lowOrNoneNames}. Corresponding with the index of each item is the number that should be ordered in this list: {lowOrNoneNums}")
                    new UserChatMessage($"Generate a shopping list based on only the needed items. Start your response with [.")
            };
            ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages);

            string reviewsJsonString = result.Value.Content.FirstOrDefault()?.Text ?? "[]";
            Console.WriteLine(reviewsJsonString);
            //JsonArray json = JsonNode.Parse(reviewsJsonString)!.AsArray();

            //var reviews = json.Select(t => new { Review = t!["review"]?.ToString() ?? "", Rating = t!["rating"]?.ToString() ?? "" }).ToArray();

            return reviewsJsonString;
        }
        
	}
}

