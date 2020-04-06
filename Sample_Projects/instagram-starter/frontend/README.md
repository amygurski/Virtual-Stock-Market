# TEGram

## Components

Each of the components (located in `components` and `views`) have a comment block at the top of them indicating what their purpose is and what (if any) dependencies they may have.

## Environment Variables

Given that your API may change depending on where it is hosted (locally or remotely) there is an `.env` file which is the reserved extension for environment variables. Settings that are applied to the project go here. At the moment there is only one:

    VUE_APP_REMOTE_API=YOUR_API_URL_HERE

This environment variable will be used to store the API in a single location, avoiding the need to copy and paste it all over the project. The value of the variable is accessible anywhere in the project via `process.env.VUE_APP_REMOTE_API`.

## Async / Await

You are most likely familiar with the common syntax of `fetch().then().then()`. While this is used where possible, to remain consistent with what was learned, using this in registration and login would have created very complex code.

If the user attempts to register and the user name is unavailable or they attempt to login and the credentials are invalid, the API returns a 401 (Unauthorized) or 400 (Bad Request). It made more sense to write the code here in a way that the `response.statusCode` was always in scope. This required the usage of [async/await](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/async_function).

The async/await can be used in place of promise `then` syntax. Take the following code

```javascript
doSomething() {
    fetch(url)
        .then((response) => response.json())
        .then((json) => {
            console.log(json);
        })
}
```

This can be translated to

```javascript
async doSomething() {
    const response = await fetch(url);
    const json = await response.json();
    console.log(json);
}
```

In the second example `await` indicates that the code should **wait** before proceeding to the next line. Notice the function must have `async` in front of it.

## Authentication

In a modern application that relies on a stateless web api, it is commont to maintain state or identity in the client (not the server). One approach is to use something called a JWT (JSON Web Token).

The token (when encoded) looks something like

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjcmFpZ0B0ZS5jb20iLCJyb2wiOiJqb2VzY2htb2UiLCJpYXQiOjE1NTI1OTc3MDYsImV4cCI6MTU1MjYwMTMwNn0.0HPRoj6am6zOxrDm-ok0aT2DuzvjFL1N15QW9dnoSsw
```

When decoded it looks like:

```
{
	"sub": "joe@techelevator.com",
	"rol": "User",
	"iat": 1552613405,
	"exp": 1552617005
}
```

From here you can tell the user's name, their role, when the token was issued and when it expires (seconds since 1970).

The token itself is stored on the client in a place called **localStorage**. Local Storage is a key/value storage repository in the browser. Everytime you need to send a request to the server (that requires authentication) you should get the token from local storage and provide it in the header of the request. The integration with local storage has been encapsulated away in the `auth.js` file. The usage will look like:

```
fetch(url, {
    method: "GET",
    headers: {
        // A Header with our authentication token.
        Authorization: "Bearer " + auth.getToken()
    }
})
```

When the API receives this header, it parses the token and ensures that the requestor is valid and that they have permission to perform such a request (either by being authenticated or authorized).

## Routing

Until now, your Vue application has been a single page. This application consists of multiple pages. In order to do such, it relies on a library called VueRouter. Ultimately, the `App.vue` looks like such:

```
<template>
  <div id="app">
    <the-header v-if="showHeader"></the-header>
    <router-view />
  </div>
</template>
```

The `<router-view />` part is a placeholder and a component is loaded there depending on what URL the user navigated to in the browser. The configuration for these URLs is in `router.js` (included with Vue Router). Here is a sample configuration:

```
{
    path: "/post",
    name: "post",
    component: NewPost,
    meta: {
        requiresAuth: true
    }
}
```

If the user nagivates to `/post`, then the `NewPost` component is loaded into `<router-view />`. Additionally the `meta` part indicates that this URL requires the user to have been authenticated. If a JWT token (see previous section) is absent (or expired), then the user is redirected to `/login`.
