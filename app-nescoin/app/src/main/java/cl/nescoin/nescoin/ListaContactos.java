package cl.nescoin.nescoin;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

import cl.nescoin.nescoin.adapters.AListaContactos;
import cl.nescoin.nescoin.models.Globales;
import cl.nescoin.nescoin.models.MListaContacto;

public class ListaContactos extends AppCompatActivity {

    private String URL ="http://"+ Globales.miIP+"/webnescoin/contactos/datosContactos?id=";

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;
    private List<MListaContacto> listaContacto;
    private JsonArrayRequest request;
    private RequestQueue requestQueue;

    Toolbar toolbar;
    boolean cierra = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista_contactos);
        toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        String id_usuario="";
        String nombre_usuario ="";
        String apellido_usuario="";
        // recuperar id usuario
        Bundle idusuario = getIntent().getExtras();
        if(idusuario!=null){
            id_usuario=idusuario.getString("id");
            nombre_usuario = idusuario.getString("nombre");
            apellido_usuario = idusuario.getString("apellido");

            //Toast.makeText(getApplicationContext(), "id enviado:"+id_usuario, Toast.LENGTH_LONG).show();
            // agrega id a la consulta url
            URL=URL+id_usuario;

            toolbar.setTitle("Usuario: "+nombre_usuario + " " + apellido_usuario) ;
    
            /** Dibuja el Recicler View con los datos*/
            recyclerView = (RecyclerView) findViewById(R.id.recyclerListaContacto);
            recyclerView.setHasFixedSize(true);
            recyclerView.setLayoutManager(new LinearLayoutManager(this));
            listaContacto = new ArrayList<>();
            parseJson();
        }else{
            Toast.makeText(getApplicationContext(), "id usuario inválido"+id_usuario, Toast.LENGTH_LONG).show();
        }
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
            String nombre = "";
            String apellido = "";
            // recuperar id usuario
            Bundle idusuario = getIntent().getExtras();

            id_usuario = idusuario.getString("id");
            nombre = idusuario.getString("nombre");
            apellido = idusuario.getString("apellido");
            i.putExtra("id", id_usuario);
            i.putExtra("nombre", nombre);
            i.putExtra("apellido", apellido);
            startActivity(i);
        }else if(id==R.id.opcion4){
            cierra=true;
            Globales.setId(null);
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


    //permite realizar la busqueda de los datos en la api webNescoin
    private void parseJson() {
        ProgressDialog progressDialog = new ProgressDialog(this);
        progressDialog.setMessage("Cargando");

        progressDialog.show();

        request = new JsonArrayRequest(URL, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                JSONObject jsonObject = null;
                for (int i = 0; i < response.length(); i++) {
                    try {
                        jsonObject = response.getJSONObject(i);
                        MListaContacto ipl = new MListaContacto();
                        //Toast.makeText(getApplicationContext(), "id:"+jsonObject.getString("id_usuario"), Toast.LENGTH_LONG).show();
                        ipl.setId_usuario(Integer.parseInt(jsonObject.getString("id_usuario")));
                        ipl.setAutonumerico(Integer.parseInt(jsonObject.getString("Autonumerico")));
                        ipl.setNombre(jsonObject.getString("nick"));
                        ipl.setNombre(jsonObject.getString("nombre"));
                        ipl.setApellido(jsonObject.getString("apellido"));
                        ipl.setProfesion(jsonObject.getString("Profesion"));
                        ipl.setNumeroTelefono(Integer.parseInt(jsonObject.getString("numero_telefono")));
                        ipl.setRating(Float.parseFloat(jsonObject.getString("promedio_calificacion")));

                        listaContacto.add(ipl);

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }
                setuprecyclerview(listaContacto);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                error.printStackTrace();
            }
        });

        requestQueue = Volley.newRequestQueue(this);
        requestQueue.add(request);
        progressDialog.dismiss();
    }

    //Permite llenar la vista del reciclerview con la información del adaptador (AListaContactos.java)
    private void setuprecyclerview(List<MListaContacto> listaContactos) {
        AListaContactos myAdapter = new AListaContactos(listaContactos, this);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        // antes de cargas lalista de contactos se agregar el escuchador onclick
        myAdapter.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View v) {


                /*
                Toast.makeText(getApplicationContext(), "Contacto:"+
                                listaContactos.get(recyclerView.getChildAdapterPosition(v)).getId_usuario(),
                        Toast.LENGTH_LONG).show();
                 */

                Intent intent = new Intent(getApplicationContext(), DetalleContactoSeleccionadoActivity.class);
                intent.putExtra("id_usuario", String.valueOf(listaContactos.get(recyclerView.getChildAdapterPosition(v)).getId_usuario()));
                intent.putExtra("nombre", listaContactos.get(recyclerView.getChildAdapterPosition(v)).getNombre());
                intent.putExtra("apellido", listaContactos.get(recyclerView.getChildAdapterPosition(v)).getApellido());
                intent.putExtra("profesion",listaContactos.get(recyclerView.getChildAdapterPosition(v)).getProfesion());
                intent.putExtra("descripcion", listaContactos.get(recyclerView.getChildAdapterPosition(v)).getDescripcion());
                intent.putExtra("telefono", String.valueOf(listaContactos.get(recyclerView.getChildAdapterPosition(v)).getNumeroTelefono()));
                intent.putExtra("promedio_calificacion",listaContactos.get(recyclerView.getChildAdapterPosition(v)).getRating());

                startActivity(intent);

            }
        });

        recyclerView.setAdapter(myAdapter);

    }

}