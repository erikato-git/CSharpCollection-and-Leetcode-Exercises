using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly IDNS _dns;
        private readonly NetworkService _networkService;

        public NetworkServiceTests()
        {
            // Dependencies - Fake
            _dns = A.Fake<IDNS>();

            // SUT
            _networkService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange 
            A.CallTo(() => _dns.SendDNS()).Returns(true);   // The makes sure that SendDNS returns 'true', what it already did in the first place and is required for SendPing will work

            //Act
            var result = _networkService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Ping Sent!");
            result.Should().Contain("Ping", Exactly.Once());
        }


        [Theory]
        [InlineData(1,1,2)]
        [InlineData(1,2,3)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange 

            //Act
            var result = _networkService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
        }


        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange 

            //Act
            var result = _networkService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }



        [Fact]
        public void NetworkService_GetPingOptions_ReturnPingOptionsObj()
        {
            //Arrange 
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1,
            };

            //Act
            var result = _networkService.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }


        [Fact]
        public void NetworkService_GetPingOptionsList_ReturnPingOptionsList()
        {
            //Arrange 

            //Act
            var result = _networkService.GetPingOptionsList();

            //Assert
            //result.Should().BeOfType<IEnumerable<PingOptions>>();     // TODO
        }





    }
}


//Arrange 


//Act


//Assert


