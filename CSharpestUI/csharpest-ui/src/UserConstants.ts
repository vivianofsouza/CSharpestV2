class UserConstants {
  static setLocalStorage(key: string, value: any) {
    try {
      window.localStorage.setItem(key, JSON.stringify(value));
    } catch (e) {
      console.log(e);
    }
  }
    static getLocalStorage(key: string, initialValue: any) {
        try {
          const value = window.localStorage.getItem(key);
          return value ? JSON.parse(value) : initialValue;
        } catch (e) {
          // if error, return initial value
          return initialValue;
        }
      }

    static logOut() {
      this.setLocalStorage("userId", "");
      this.setLocalStorage("cartId", "");
      this.setLocalStorage("isAdmin", "");
      this.setLocalStorage("firstName", "");
      this.setLocalStorage("lastName", "");
    }
}

export default UserConstants;
