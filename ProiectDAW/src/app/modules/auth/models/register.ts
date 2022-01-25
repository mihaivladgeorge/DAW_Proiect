export class Register {
    public Email : string | undefined;
    public Password : string | undefined;
    public RoleId : string | undefined;

    public constructor(init? : Partial<Register>) {
        Object.assign(this, init);
        this.RoleId = "BasicUser"
    }
}