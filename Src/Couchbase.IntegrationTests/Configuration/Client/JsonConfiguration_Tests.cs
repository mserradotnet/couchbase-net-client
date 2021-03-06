﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Configuration.Client;
using Couchbase.Configuration.Client.Providers;
using NUnit.Framework;

namespace Couchbase.IntegrationTests.Configuration.Client
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class JsonConfiguration_Tests
    {
        [Test]
        public void ClientConfiguration_IgnoreHostnameValidation_IsTrue()
        {
            //arrange/act
            var clientConfig = Utils.TestConfiguration.GetJsonConfiguration("basic");

            //assert
            Assert.IsTrue(ClientConfiguration.IgnoreRemoteCertificateNameMismatch);
        }

        [Test]
        public void ClientConfiguration_IgnoreHostnameValidation_IsFalse()
        {
            //arrange/act
            var clientConfig = Utils.TestConfiguration.GetJsonConfiguration("multiplexio");

            //assert
            Assert.IsFalse(ClientConfiguration.IgnoreRemoteCertificateNameMismatch);
        }
    }
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2015 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion
