using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API.Controllers;
using SocialNetwork.DataAccess;
using Microsoft.Data.Sqlite;
using Xunit;
using System;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.API.DTO;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.API.Searches;

namespace SocialNetwork.API.Tests
{
    public class ReactionsControllerTests
    {
        [Fact]
        public void ReturnsResponse200WithObject_WhenProvidedIdExists()
        {
            SocialNetworkContext context = GetContext();

            var controller = new ReactionsController(context);

            IActionResult result = controller.Get(5);

            result.Should().BeOfType<OkObjectResult>();

            OkObjectResult okResult = result as OkObjectResult;
            okResult.Value.Should().BeOfType<ReadReactionDto>();

            var value = okResult.Value as ReadReactionDto;
            value.Id.Should().Be(5);
            value.ReactionName.Should().Be("Test Reaction");
            value.FilePath.Should().Be("image.png");
        }

        [Fact]
        public void ReturnsResponse404_WhenProvidedIdDoesntExist()
        {
            SocialNetworkContext context = GetContext();

            var controller = new ReactionsController(context);

            IActionResult result = controller.Get(101);

            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public void ReturnsFilteredReactions_WhenKeywordIsProvided()
        {
            SocialNetworkContext context = GetContext();

            var controller = new ReactionsController(context);

            var search = new ReactionSearch { Keyword = "o" };

            IActionResult result = controller.Get(search);

            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeAssignableTo<IEnumerable<ReadReactionDto>>();

            var items = okResult.Value as IEnumerable<ReadReactionDto>;

            items.Should().HaveCount(3);
            items.All(x => x.ReactionName.Contains("o")).Should().BeTrue();
        }



        private static SocialNetworkContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            optionsBuilder.UseSqlite(connection);

            var context = new SocialNetworkContext(optionsBuilder.Options);

            var reactions = new List<Reaction>
            {
                new Reaction
                {
                    Id = 5,
                    CreatedAt = DateTime.Now,
                    Name = "Test Reaction",
                    Icon = new File
                    {
                        Path = "image.png",
                        Size = 100,
                        CreatedAt = DateTime.Now
                    }},
                new Reaction
                {
                    Id = 6,
                    CreatedAt = DateTime.Now,
                    Name = "Like",
                    Icon = new File
                    {
                        Path = "image.png",
                        Size = 100,
                        CreatedAt = DateTime.Now
                    }},
                new Reaction
                {
                    Id = 7,
                    CreatedAt = DateTime.Now,
                    Name = "Thumbs Down",
                    Icon = new File
                    {
                        Path = "image.png",
                        Size = 100,
                        CreatedAt = DateTime.Now
                    }},
                new Reaction
                {
                    Id = 8,
                    CreatedAt = DateTime.Now,
                    Name = "Angry Face",
                    Icon = new File
                    {
                        Path = "image.png",
                        Size = 100,
                        CreatedAt = DateTime.Now
                    }},
                new Reaction
                {
                    Id = 9,
                    CreatedAt = DateTime.Now,
                    Name = "Wow",
                    Icon = new File
                    {
                        Path = "image.png",
                        Size = 100,
                        CreatedAt = DateTime.Now
                    }}
            };

            context.Reactions.AddRange(reactions);

            context.SaveChanges();
            
            return context;
        }
    }
}
