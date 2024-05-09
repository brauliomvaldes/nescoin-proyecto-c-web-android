package cl.nescoin.nescoin.models;

public class Globales {
    public static final String miIP = "192.168.0.10";
    public static String id;
    public static String nombre;
    public static String apellido;
    public static String getId() {
        return id;
    }

    public static void setId(String id) {
        Globales.id = id;
    }

    public static String getNombre () {return nombre;}
    public static void setNombre(String nombre){
        Globales.nombre = nombre;}

    public static String getApellido(){return  apellido;}
    public static void setApellido(String apellido){
        Globales.apellido = apellido;}
}
