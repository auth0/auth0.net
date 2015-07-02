using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Auth0;
using System.Configuration;
using SharpTestsEx;
using Newtonsoft.Json;

namespace Auth0.Net_tests
{
    [TestFixture]
    public class DiagnosticsHeaderTests
    {

        [SetUp]
        public void setup()
        {
            DiagnosticsHeader.Reset();
        }

        [Test]
        public void Default_instance_is_the_same_each_time()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Default.Should().Be.Equals(target);
            DiagnosticsHeader.Default.Should().Be.Equals(target);
        }

        [Test]
        public void Suppress_instance_is_the_same_each_time()
        {
            var target = DiagnosticsHeader.Suppress;

            DiagnosticsHeader.Suppress.Should().Be.Equals(target);
            DiagnosticsHeader.Suppress.Should().Be.Equals(target);
        }

        [Test]
        public void Suppress_instance_is_not_the_same_as_Default()
        {
            DiagnosticsHeader.Suppress.Should().Not.Be.Equals(DiagnosticsHeader.Default);
        }

        [Test]
        public void Reset_should_create_a_new_Default_instance()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Reset();

            DiagnosticsHeader.Default.Should().Not.Be.Equals(target);
        }

        [Test]
        public void Reset_should_create_a_new_Suppress_instance()
        {
            var target = DiagnosticsHeader.Suppress;

            DiagnosticsHeader.Reset();

            DiagnosticsHeader.Suppress.Should().Not.Be.Equals(target);
        }

        [Test]
        public void AddDependency_with_values_should_return_same_instance_for_fluency()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Default.AddDependency("foo", "1.2.3")
                .Should().Be.Equals(target);
        }

        [Test]
        public void AddDependency_instance_should_return_same_instance_for_fluency()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Default.AddDependency(new DiagnosticsComponent("foo", "1.2.3"))
                .Should().Be.Equals(target);
        }

        [Test]
        public void AddDependency_with_values_should_add_a_new_dependency()
        {
            DiagnosticsHeader.Default.AddDependency("foo", "1.2.3");

            var target = DiagnosticsHeader.Default.Dependencies.Last();

            target.Name.Should().Be.Equals("foo");
            target.Version.Should().Be.Equals("1.2.3");
        }

        [Test]
        public void AddDependency_instance_should_add_a_new_dependency()
        {
            DiagnosticsHeader.Default.AddDependency(new DiagnosticsComponent("foo", "1.2.3"));

            var target = DiagnosticsHeader.Default.Dependencies.Last();

            target.Name.Should().Be.Equals("foo");
            target.Version.Should().Be.Equals("1.2.3");
        }

        [Test]
        public void AddEnvironment_with_values_should_return_same_instance_for_fluency()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Default.AddEnvironment("foo", "1.2.3")
                .Should().Be.Equals(target);
        }

        [Test]
        public void AddEnvironment_instance_should_return_same_instance_for_fluency()
        {
            var target = DiagnosticsHeader.Default;

            DiagnosticsHeader.Default.AddEnvironment(new DiagnosticsComponent("foo", "1.2.3"))
                .Should().Be.Equals(target);
        }

        [Test]
        public void AddEnvironment_with_values_should_add_a_new_dependency()
        {
            DiagnosticsHeader.Default.AddEnvironment("foo", "1.2.3");

            var target = DiagnosticsHeader.Default.Environments.Last();

            target.Name.Should().Be.Equals("foo");
            target.Version.Should().Be.Equals("1.2.3");
        }

        [Test]
        public void AddEnvironment_instance_should_add_a_new_dependency()
        {
            DiagnosticsHeader.Default.AddEnvironment(new DiagnosticsComponent("foo", "1.2.3"));

            var target = DiagnosticsHeader.Default.Environments.Last();

            target.Name.Should().Be.Equals("foo");
            target.Version.Should().Be.Equals("1.2.3");
        }

        private string DeserializeHeaderToJson(string serialized)
        {
            var output = serialized;
            output = output.Replace('-', '+');
            output = output.Replace('_', '/');

            switch (output.Length % 4)
            {
                case 0: 
                    break;
                case 2: 
                    output += "=="; 
                    break;
                default: 
                    throw new InvalidOperationException("Illegal base64url string!");
            }

            var bytes = Convert.FromBase64String(output);
            var json = Encoding.UTF8.GetString(bytes);

            return json;
        }

        [Test]
        public void ToString_should_produce_a_base64_url_encoded_json_representation_of_the_DiagnosticsHeader_instance()
        {
            var target = DiagnosticsHeader.Default.ToString();

            var json = DeserializeHeaderToJson(target);
            dynamic obj = JsonConvert.DeserializeObject(json);

            Console.WriteLine(obj);

            Assert.AreEqual(obj.name.ToString(), "Auth0");
            Assert.IsNotEmpty(obj.version.ToString());

            Assert.IsNotEmpty(obj.dependencies);
            foreach (var dep in obj.dependencies)
            {
                Assert.IsNotEmpty(dep.name.ToString());
                Assert.IsNotEmpty(dep.version.ToString());
            }

            Assert.IsNotEmpty(obj.environment);
            foreach (var env in obj.dependencies)
            {
                Assert.IsNotEmpty(env.name.ToString());
                Assert.IsNotEmpty(env.version.ToString());
            }
        }

        [Test]
        public void ToString_should_produce_serialized_json_that_contains_an_added_dependency()
        {
            var target = DiagnosticsHeader.Default.AddDependency("foo", "1.2.3").ToString();

            var json = DeserializeHeaderToJson(target);
            dynamic obj = JsonConvert.DeserializeObject(json);

            Console.WriteLine(obj);

            var dep = obj.dependencies[obj.dependencies.Count - 1];

            Assert.AreEqual(dep.name.ToString(), "foo");
            Assert.AreEqual(dep.version.ToString(), "1.2.3");
        }

        [Test]
        public void ToString_should_produce_serialized_json_that_contains_an_added_environment_entry()
        {
            var target = DiagnosticsHeader.Default.AddEnvironment("bar", "3.2.1").ToString();

            var json = DeserializeHeaderToJson(target);
            dynamic obj = JsonConvert.DeserializeObject(json);

            Console.WriteLine(obj);

            var env = obj.environment[obj.environment.Count - 1];

            Assert.AreEqual(env.name.ToString(), "bar");
            Assert.AreEqual(env.version.ToString(), "3.2.1");
        }
    }
}
