package cl.nescoin.nescoin;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.appcompat.widget.Toolbar;

import cl.nescoin.nescoin.models.Globales;


public class MenuPrincipal extends AppCompatActivity {

    Toolbar toolbar;
    boolean cierra = false;
    
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_principal);
        toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return  true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();
        if/*(id==R.id.opcion1){
            Intent i = new Intent(getApplicationContext(),ListaContactos.class);
            String id_usuario="";
            // recuperar id usuario
            Bundle idusuario = getIntent().getExtras();
            id_usuario=idusuario.getString("id");
            i.putExtra("id",id_usuario);
            startActivity(i);

        }else if*/(id==R.id.opcion2){
            Intent i = new Intent(getApplicationContext(),AgregarNuevoContacto.class);
            String id_usuario="";
            // recuperar id usuario
            Bundle idusuario = getIntent().getExtras();
            id_usuario=idusuario.getString("id");
            i.putExtra("id",id_usuario);
            startActivity(i);
        }else if(id==R.id.opcion3) {
            Intent i = new Intent(getApplicationContext(), Publicaciones.class);
            String id_usuario = "";
            // recuperar id usuario
            Bundle idusuario = getIntent().getExtras();
            id_usuario = idusuario.getString("id");
            i.putExtra("id", id_usuario);
            startActivity(i);
        }else if(id==R.id.opcion4){
            Globales.setId(null);
            cierra=true;
            this.finish();
        }
        return true;
    }

    @Override
    public void onResume(){
        super.onResume();
        if(cierra){
            finish();
        }
    }

}