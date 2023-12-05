import { UUID } from "crypto";

class UserConstants {
    static currUser = "";

    static getCurrUser() {
        return this.currUser;
    }

    static setCurrUser(newCurrUser : UUID) {
        this.currUser = newCurrUser;
    }

}

export default UserConstants;
