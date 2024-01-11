using Auth0.AuthenticationApi.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class UserInfoDeserializationTests
    {

        [Fact]
        public void Can_read_standard_claims()
        {
            var jsonPayload = @"{
   'sub': '123456',
   'name': 'Robert Smith',
   'given_name': 'Robert',
   'family_name': 'Smith',
   'middle_name': 'Franklin',
   'nickname': 'Bob',
   'preferred_username': 'b.smith',
   'profile': 'http://profiles.com/bsmith',
   'picture': 'http://mycompany.com/bob_photo.jpg',
   'website': 'http://mycompany.com/users/bob',
   'email': 'bob@mycompany.com',
   'email_verified': true,
   'gender': 'male',
   'birthdate': '0000-05-22',
   'zoneinfo': 'Europe/Paris',
   'locale': 'en-US',
   'phone_number': '+1 (604) 555-1234;ext5678',
   'phone_number_verified': false,
   'address': { 
     'formatted' : '123 Main St., Anytown, TX 77777',
     'street_address': '123 Main St.',
     'locality': 'Anytown',
     'region': 'Texas',
     'postal_code': '77777',
     'country': 'US'
    },
   'updated_at': 1233233333
}";
            var userInfo = GetUserInfoFromJsonPayload(jsonPayload);

            userInfo.UserId.Should().Be("123456");
            userInfo.FullName.Should().Be("Robert Smith");
            userInfo.FirstName.Should().Be("Robert");
            userInfo.LastName.Should().Be("Smith");
            userInfo.MiddleName.Should().Be("Franklin");
            userInfo.NickName.Should().Be("Bob");
            userInfo.PreferredUsername.Should().Be("b.smith");
            userInfo.Profile.Should().Be("http://profiles.com/bsmith");
            userInfo.Picture.Should().Be("http://mycompany.com/bob_photo.jpg");
            userInfo.Website.Should().Be("http://mycompany.com/users/bob");
            userInfo.Email.Should().Be("bob@mycompany.com");
            userInfo.EmailVerified.Should().Be(true);
            userInfo.Gender.Should().Be("male");
            userInfo.Birthdate.Should().Be("0000-05-22");
            userInfo.ZoneInformation.Should().Be("Europe/Paris");
            userInfo.Locale.Should().Be("en-US");
            userInfo.PhoneNumber.Should().Be("+1 (604) 555-1234;ext5678");
            userInfo.PhoneNumberVerified.Should().Be(false);
            userInfo.Address.Formatted.Should().Be("123 Main St., Anytown, TX 77777");
            userInfo.Address.StreetAddress.Should().Be("123 Main St.");
            userInfo.Address.Locality.Should().Be("Anytown");
            userInfo.Address.Region.Should().Be("Texas");
            userInfo.Address.PostalCode.Should().Be("77777");
            userInfo.Address.Country.Should().Be("US");
            userInfo.UpdatedAt.Should().Be(new DateTime(2009, 1, 29, 12, 48, 53));
        }

        [Fact]
        public void Can_read_custom_locale_claim()
        {
            var jsonPayload = @"{
   'sub': '123456',
   'locale': {
        'country': 'US',
        'language': 'en'
   },
   'updated_at': 1233233333
}";
            var userInfo = GetUserInfoFromJsonPayload(jsonPayload);

            userInfo.UserId.Should().Be("123456");
            userInfo.Locale.Should().NotBeNull();
            JObject.Parse(userInfo.Locale).GetValue("country")!.Value<string>().Should().Be("US");
            JObject.Parse(userInfo.Locale).GetValue("language")!.Value<string>().Should().Be("en");
        }
        
        [Fact]
        public void Missing_values_are_null()
        {
            var jsonPayload = @"{ 'sub': '123456'}";
            var userInfo = GetUserInfoFromJsonPayload(jsonPayload);
            Assert.Null(userInfo.FullName);
            Assert.Null(userInfo.EmailVerified);
            Assert.Null(userInfo.PhoneNumberVerified);
            Assert.Null(userInfo.Address);
            Assert.Null(userInfo.UpdatedAt);
        }

        [Fact]
        public void Can_read_additional_claims()
        {
            var jsonPayload = @"{
   'sub': '123456',
   'http://acme.com/claims/groupIds': [ 'bobsdepartment','administrators' ], 
   'http://acme.com/claims/manager': { 'name' : 'John Doe' }, 
   'http://acme.com/claims/office': 'building 125'
}";
            var userInfo = GetUserInfoFromJsonPayload(jsonPayload);

            var groups = (JArray)userInfo.AdditionalClaims["http://acme.com/claims/groupIds"];

            Assert.Equal(2, groups.Count);
            Assert.Equal("bobsdepartment", (string)groups[0]);
            Assert.Equal("administrators", (string)groups[1]);

            dynamic manager = userInfo.AdditionalClaims["http://acme.com/claims/manager"];
            string managerName = manager.name;
            managerName.Should().Be("John Doe");
        }

        private UserInfo GetUserInfoFromJsonPayload(string jsonPayload)
        {
            return JsonConvert.DeserializeObject<UserInfo>(jsonPayload);
        }
    }
}