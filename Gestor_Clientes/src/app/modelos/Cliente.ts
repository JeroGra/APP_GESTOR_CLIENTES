import { Direccion } from "./Direccion";
import { Usuario } from "./Usuario";

export class Cliente extends Usuario
{
    public direccion  : Direccion;
    public estado : Boolean;

    constructor(direccion : Direccion = new Direccion, estado : Boolean = true){

        super();
        this.direccion = direccion;
        this.estado = estado;
    }

}