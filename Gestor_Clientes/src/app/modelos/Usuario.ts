export class Usuario 
{
    public id : Number;
    public nombre : String;
    public apellido : String;
    public fechaNacimiento : Date;
    public dni : Number;
    public correo : String;

    constructor(id : Number = 0, nombre : String = "", apellido : String = "", fechaNacimiento : Date = new Date, dni : Number = 0, correo : String = "" ){

        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaNacimiento = fechaNacimiento;
        this.dni = dni;
        this.correo = correo;

    }

}


