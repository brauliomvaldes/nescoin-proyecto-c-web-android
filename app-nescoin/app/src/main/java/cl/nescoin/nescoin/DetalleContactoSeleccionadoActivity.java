package cl.nescoin.nescoin;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class DetalleContactoSeleccionadoActivity extends AppCompatActivity {
    String id_usuario;
    String nombre;
    String apellido;
     @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detalle_contacto_seleccionado);
        TextView nom = (TextView) findViewById(R.id.textView1);
        TextView ape = (TextView) findViewById(R.id.textView2);
        TextView pro = (TextView) findViewById(R.id.textView3);
        TextView des = (TextView) findViewById(R.id.textView4);
        TextView tel = (TextView) findViewById(R.id.textView5);

        Bundle datosContacto = getIntent().getExtras();
        setTitle("Detalle del contacto");

        if (datosContacto!=null){
            id_usuario = datosContacto.getString("id_usuario");
            nombre = datosContacto.getString("nombre");
            apellido= datosContacto.getString("apellido");
            nom.setText(nombre);
            ape.setText(apellido);
            pro.setText(datosContacto.getString("profesion"));
            des.setText(datosContacto.getString("descripcion"));
            tel.setText(datosContacto.getString("telefono"));
        }
    }

    // visualiza las publicaciones del contacto en una nueva activity
    public void listapublicaciones(View v){
        Intent i = new Intent(getApplicationContext(), Publicaciones.class);
        // recuperar id usuario
        Bundle idusuario = getIntent().getExtras();
        i.putExtra("id", id_usuario);
        i.putExtra("nombre", nombre);
        i.putExtra("apellido", apellido);
        startActivity(i);
    }
}