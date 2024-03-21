export class Direccion
{
    public id : Number;
    public provincia : String;
    public localidad : String;
    public calle : String;
    public numero : Number;
    public codigoPostal : Number;
    public numeroTelefono : Number;

    constructor(id : Number = 0, provincia : String = "", localidad : String = "", calle : String = "", numero : Number = 0, codigoPostal : Number = 0, numeroTelefono : Number = 0){

        this.id = id;
        this.provincia = provincia;
        this.localidad = localidad;
        this.calle = calle;
        this.numero = numero;
        this.codigoPostal = codigoPostal;
        this.numeroTelefono = numeroTelefono;

    }


}