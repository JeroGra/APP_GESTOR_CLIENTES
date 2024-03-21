import { Usuario } from "./Usuario";

export class Administrador extends Usuario
{
    public clave : String;

    constructor(clave : String = ""){
        super();
        this.clave = clave;

    }

}
