using EquipmentRental.Data.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EquipmentRental.Tests
{
    public class ControllerIntegrationTests
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;


        public ControllerIntegrationTests()
        {
            _factory = new WebApplicationFactory<Api.Startup>();
        }

        [Fact]
        public async Task GetEquipmentEndpointReturnsSuccessAndData()
        {            
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("/equipment");
            response.EnsureSuccessStatusCode(); 
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObjectList = JsonConvert.DeserializeObject<List<Equipment>>(responseString);
            
            Assert.NotEmpty(responseObjectList);
        }

    }
}
