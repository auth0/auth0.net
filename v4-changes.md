## Breaking changes

* Removal of previously marked obsolete methods and properties

  Most members previously marked as obsolete were removed.
  
* `AuthenticationClient.AuthenticateAsync()` is now calling the `/oauth/token` endpoint using the [Resource Owner Password grant type](https://auth0.com/docs/api/authentication#resource-owner-password),
and thus it requires a `ClientSecret` in the `AuthenticationRequest` for confidential clients.

* The token refresh exchange must be done using the `AuthenticationClient.GetRefreshedTokenAsync()` with a `TokenRefreshRequest` 
instead of using `AuthenticationClient.GetDelegationTokenAsync()` with a `RefreshTokenDelegationRequest`.

* The `AuthenticationClient.GetUserInfoAsync()` method now returns a `UserInfo` class instead of `User`.

* `AuthenticationClient.AuthenticateAsync()` now returns an `AccessToken` instead of `AuthorizationResponse`. 

* Removed `GetTokenInfoAsync` method, based on the deprecated `/tokeninfo` endpoint.

* Removed `GetAccessTokenAsync` method, based on the deprecated `/oauth/access_token` endpoint.

* Remove `WithDevice()` method from `AuthorizationUrlBuilder`, because of obsoleted `device` parameter.

## Non-breaking changes

* `AuthenticationClient.AuthenticateAsync()` does not require a `Connection` value in the `AuthenticationRequest`. If not provided, the Authentication API will use the connection specified as the Default Directory in the [Account Settings](https://manage.auth0.com/#/account).

* `AuthorizationUrlBuilder` now supports `nonce`, `audience` and multiple `response_type`s.

* `LogoutUrlBuilder` now uses the `v2/logout` endpoint, and supports the `federated` and `clientId` values.

* Removal of (unused) class `OAuthToken`. 