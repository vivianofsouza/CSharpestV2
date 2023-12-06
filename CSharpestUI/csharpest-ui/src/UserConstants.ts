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

    // static currUser = "";
    // static currCart = "";
    // static isAdmin = false;
    // static firstName = "";
    // static lastName = "";

    // static getCurrUser() {
    //     return this.currUser;
    // }

    // static setCurrUser(newCurrUser : UUID) {
    //     this.currUser = newCurrUser;
    // }

    // static getCurrCart() {
    //     return this.currCart;
    // }

    // static setCurrCart(newCurrCart : string) {
    //     this.currCart = newCurrCart;
    // }

    // static getIsAdmin() {
    //     return this.isAdmin;
    // }

    // static setIsAdmin(newIsAdmin : boolean) {
    //     this.isAdmin = newIsAdmin;
    // }

    // static getFirstName() {
    //     return this.firstName;
    // }

    // static setFirstName(newFirstName : string) {
    //     this.firstName = newFirstName;
    // }

    // static getLastName() {
    //     return this.lastName;
    // }

    // static setLastName(newLastName : string) {
    //     this.lastName = newLastName;
    // }
}

export default UserConstants;
