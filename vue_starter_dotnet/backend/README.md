# Overview

This project is a basic template that provides the following capabilities out of the box:

* JWT creating and handling
* Authentication
* Authorization

## What is a JWT

When working with front-end applications, a JSON Web Token (JWT) is often used as a way to define a compact, self-contained piece of information between two parties. JWTs for us will be specifically used as a way for the front-end to communicate to the back-end the user making the request so that the back-end can ensure that they are properly
authenticated and authorized to make such a request.

[JWT Introduction](https://jwt.io/introduction/)

## JWT Creation & Handling

This project is designed to handle authentication using stateless JSON Web Tokens (JWTs). The user can log in by sending a POST request to `/api/account/login` with the user's credentials
in the request body:

```
{
	"username": "joe@techelevator.com",
	"password": "Password1234"
}
```

Upon successfully authenticating, the service will return the JWT, which a front-end or mobile application will be able to use to authorize each new request. A sample JWT will look like:

```
{
	"sub": "joe@techelevator.com",
	"rol": "User",
	"iat": 1552613405,
	"exp": 1552617005
}
```

This gets encoded when sent to the client and ultimately looks like:

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjcmFpZ0B0ZS5jb20iLCJyb2wiOiJqb2VzY2htb2UiLCJpYXQiOjE1NTI1OTc3MDYsImV4cCI6MTU1MjYwMTMwNn0.0HPRoj6am6zOxrDm-ok0aT2DuzvjFL1N15QW9dnoSsw
```

JWTs will be taken from each incoming request and handled before the request reaches the controller action. This is done through the usage of code called *middleware*. Middleware for JWT
verifies the validity of the incoming token (if provided) and updates the user's identity and role based on what was in the token.

## Getting the User Identity

If the request includes a JWT in the header, then Microsoft's Identity Framework will pluck these values and assign them to a Claim. Getting the user's name from within a controller can
be done by writing `User.Identity.Name`.

## Restricting Access to an Action

If access to a particular API call needs to be restricted (by requiring user authentication or ensuring the user belongs to a specific role), the following attribute should be added above
the controller or specific action.

To lock down an action to authenticated users only:

```csharp
using Microsoft.AspNetCore.Authorization;

[Authorize]
public IActionResult DoSomething()
{
	return Ok();
}
```

To lock down an action to users belonging to a specific role:

```csharp
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Administrator")]
public IActionResult DoSomething()
{
	return Ok();
}
```

## Dependency Mappings

The project automatically hashes passwords and generates tokens in the account controller (assuming the following dependencies have been configured).

```csharp
// Configures the Token Generation to use Jwt using a secret signing key
services.AddSingleton<ITokenGenerator>(tk => new JwtGenerator("clientsecretsignaturekey"));
// Configures the Password Hashing dependency
services.AddSingleton<IPasswordHasher>(ph => new PasswordHasher());
// Configures a User DAO based off of Sql
services.AddTransient<IUserDAO>(m => new UserSqlDAO("connection-string-here"));
```

## Database

There are 2 scripts located in the database folder. You will need to run `database/schema.sql` first which will setup the users table. Once the users table is in place you can run `database/data.sql` to add a default user into the table.

