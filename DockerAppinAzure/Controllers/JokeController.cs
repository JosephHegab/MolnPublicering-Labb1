using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DockerAppinAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private static readonly string[] Jokes = new[]
        {
            "Why did the chicken cross the road? To get to the other side!",
            "What do you call fake spaghetti? An Impasta!",
            "Why did the scarecrow win an award? Because he was outstanding in his field!",
            "I would tell you a chemistry joke but I know I wouldn't get a reaction.",
            "Why did the tomato turn red? Because it saw the salad dressing!"
        };

        private readonly ILogger<JokeController> _logger;

        public JokeController(ILogger<JokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetJoke")]
        public string Get()
        {
            int jokeIndex = new System.Random().Next(Jokes.Length);
            return Jokes[jokeIndex];
        }
    }
}
