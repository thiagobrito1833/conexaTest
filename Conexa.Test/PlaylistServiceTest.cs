using Conexa.Domain.Contracts.Service;
using Conexa.Domain.Entities;
using Conexa.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Conexa.Test
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistService playlistService;
        private readonly ServiceCollection services;

        public PlaylistServiceTest()
        {
            services = new ServiceCollection();
            services.AddTransient<IPlaylistService, PlaylistService>();
            var serviceProvider = services.BuildServiceProvider();
            playlistService = serviceProvider.GetService<IPlaylistService>();
        }

        [Theory]
        [InlineData(31, EnumGenre.festa)]
        [InlineData(15, EnumGenre.pop)]
        [InlineData(30, EnumGenre.pop)]
        [InlineData(10, EnumGenre.rock)]
        [InlineData(14, EnumGenre.rock)]
        [InlineData(13, EnumGenre.rock)]
        [InlineData(2, EnumGenre.classica)]
        [InlineData(50, EnumGenre.festa)]
        public async void Get_MusicalGenre(double temperature, EnumGenre expectedResult)
        {
            var result = await playlistService.GetMusicalGenre(temperature); ;
            Assert.Equal(expectedResult, result.Result);
        }
    }
}
