export default {
  /**
   * Returns the authentication token from local storage.
   */
  getToken: function() {
    try {
      return localStorage.getItem('Authorization');
    } catch {
      return null;
    }
  },
  /**
   * Parses and saves the authentication token.
   * @param {String} token A JWT encoded token.
   */
  saveToken(token) {
    localStorage.setItem('Authorization', token);
  },
  /**
   * Invalidates the local authentication token.
   */
  destroyToken() {
    localStorage.removeItem('Authorization');
  },
  /**
   * Returns the user represented by the authentication token (null if user is not authenticated).
   * @function
   */
  getUser() {
    const token = localStorage.getItem('Authorization');
    let user = null;

    // If a token exists then decode it
    if (token) {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const secondsSinceEpoch = new Date() / 1000;
      const parsedToken = JSON.parse(window.atob(base64));

      // If current date is after expiration date then destroy it
      if (secondsSinceEpoch > parsedToken.exp) {
        this.destroyToken();
      } else {
        user = parsedToken;
      }
    }

    return user;
  },
  logout() {
    localStorage.removeItem('Authorization');
  },
};
