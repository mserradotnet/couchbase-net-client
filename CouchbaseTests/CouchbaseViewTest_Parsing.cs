﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Couchbase;
using System.IO;
using Enyim.Caching;
using FluentAssertions;
using Moq;
using Couchbase.Configuration;

namespace CouchbaseTests
{
	public partial class CouchbaseViewTest
	{
		[TestMethod, DeploymentItem("MixedResponse.txt")]
		public void ItemsShouldBeReturnedByView()
		{
			var content = File.ReadAllText(@"MixedResponse.txt");

			var response = new Mock<IHttpResponse>();
			response.Setup(r => r.GetResponseStream()).Returns(() => new MemoryStream(Encoding.UTF8.GetBytes(content), false));

			var request = new Mock<IHttpRequest>();
			request.Setup(r => r.GetResponse()).Returns(response.Object);
			request.SetupAllProperties();

			var client = new Mock<IHttpClient>();
			client.Setup(c => c.CreateRequest(It.IsAny<string>())).Returns(request.Object);

			var locator = new Mock<IHttpClientLocator>();
			locator.Setup(l => l.Locate(It.IsAny<string>())).Returns(client.Object);

			var view = new CouchbaseView(new Mock<IMemcachedClient>().Object, locator.Object, "doc", "index");

			var expectedKeys = (from index in Enumerable.Range(0, 10)
								from prefix in new[] { "binary", "json" }
								select prefix + "_" + index).ToList();

			var resultKeys = view.Select(row => row.ItemId).ToList();

			resultKeys.Should().BeEquivalentTo(expectedKeys);
		}
	}
}
