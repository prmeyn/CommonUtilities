using Meyn.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Meyn.Utilities.Tests
{
    public class HttpContextExtensionsTests
    {
        [Fact]
        public void GetPublicIP_PrefersCloudflareHeader()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers["CF-Connecting-IP"] = "203.0.113.5";
            context.Request.Headers["X-Forwarded-For"] = "198.51.100.7";

            Assert.Equal("203.0.113.5", context.GetPublicIP());
        }

        [Fact]
        public void GetPublicIP_FallsBackToForwardedForAndTakesFirstNonLoopback()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers["X-Forwarded-For"] = "203.0.113.5, 10.0.0.1";

            Assert.Equal("203.0.113.5", context.GetPublicIP());
        }

        [Fact]
        public void GetPublicIP_TrimsWhitespaceAndSkipsLoopback()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers["X-Forwarded-For"] = "127.0.0.1, 203.0.113.5";

            Assert.Equal("203.0.113.5", context.GetPublicIP());
        }

        [Fact]
        public void GetPublicIP_FallsBackToRemoteIpAddress()
        {
            var context = new DefaultHttpContext();
            context.Connection.RemoteIpAddress = IPAddress.Parse("203.0.113.9");

            Assert.Equal("203.0.113.9", context.GetPublicIP());
        }

        [Fact]
        public void GetPublicIP_ReturnsNullWhenOnlyLoopbackIsAvailable()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers["X-Forwarded-For"] = "::1, 127.0.0.1";

            Assert.Null(context.GetPublicIP());
        }

        [Fact]
        public void GetPublicIP_ReturnsNullWhenNoAddressIsAvailable()
        {
            var context = new DefaultHttpContext();

            Assert.Null(context.GetPublicIP());
        }
    }
}
