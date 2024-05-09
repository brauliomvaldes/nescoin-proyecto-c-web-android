package cl.nescoin.nescoin.models;

public class MListaContacto {
    private int id_usuario, getId_usuarioLogueado,Autonumerico, numeroTelefono;
    private float rating;
    private String nick, nombre, apellido,profesion,descripcion, foto;

    public MListaContacto(){

    }

    public float getRating() {
        return rating;
    }

    public void setRating(float rating) {
        this.rating = rating;
    }

    public int getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(int id_usuario) {
        this.id_usuario = id_usuario;
    }

    public int getGetId_usuarioLogueado() {
        return getId_usuarioLogueado;
    }

    public void setGetId_usuarioLogueado(int getId_usuarioLogueado) {
        this.getId_usuarioLogueado = getId_usuarioLogueado;
    }

    public int getAutonumerico() {
        return Autonumerico;
    }

    public void setAutonumerico(int autonumerico) {
        Autonumerico = autonumerico;
    }

    public int getNumeroTelefono() {
        return numeroTelefono;
    }

    public void setNumeroTelefono(int numeroTelefono) {
        this.numeroTelefono = numeroTelefono;
    }

    public String getNick() {
        return nick;
    }

    public void setNick(String nick) {
        this.nick = nick;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellido() {
        return apellido;
    }

    public void setApellido(String apellido) {
        this.apellido = apellido;
    }

    public String getProfesion() {
        return profesion;
    }

    public void setProfesion(String profesion) {
        this.profesion = profesion;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getFoto() {
        return foto;
    }

    public void setFoto(String foto) {
        this.foto = foto;
    }
}
