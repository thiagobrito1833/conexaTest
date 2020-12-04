using Conexa.Domain.Contracts.Service;
using Conexa.Domain.Entities;
using Conexa.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace Conexa.Domain.Tests
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
        public async void Get_MusicalGenre(decimal temperature, EnumGenre genre)
        {
            //Arrange

       
            var TemperaturaPop = 16;
            var TemperaturaRock = 11;
            var TemperaturaClassica = 1;

            //Act          
            var actPop = await playlistService.GetMusicalGenre(TemperaturaPop);
            var actRock = await playlistService.GetMusicalGenre(TemperaturaRock);
            var actClassica = await playlistService.GetMusicalGenre(TemperaturaClassica);

            //Assert

            Assert.Equals(temperature, genre);
            Assert.Equals(actPop, EnumGenre.pop);
            Assert.Equals(actRock, EnumGenre.rock);
            Assert.Equals(actClassica, EnumGenre.classica);
        }




    }


}