import { UUID } from "crypto";

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
}

export default UserConstants;
